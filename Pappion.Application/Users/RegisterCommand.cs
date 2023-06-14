using AutoMapper;
using FluentValidation;
using Pappion.Application.Common.Exceptions;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Constants;
using Pappion.Domain.Entities;

namespace Pappion.Application.Users
{
    public record RegisterCommand(string FirstName, string LastName, string Email, string Password, string PasswordConfirmation) : ICommand<string>;

    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(command => command.FirstName).NotEmpty();
            RuleFor(command => command.FirstName).NotEmpty();
            RuleFor(command => command.Email).EmailAddress();
            RuleFor(command => command.Password).NotEmpty().MaximumLength(15);
            RuleFor(command => command.PasswordConfirmation).Equal(c => c.Password).WithMessage($"Password and PasswordConfirmation must be equal.");
        }
    }

    public class RegisterCommandHandler : ICommandHandler<RegisterCommand, string>
    {
        private readonly IGenericRepository<User> _usersRepository;
        private readonly IGenericRepository<Role> _rolesRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly IJwtProvider _jwtProvider;


        public RegisterCommandHandler(IGenericRepository<User> usersRepository, IGenericRepository<Role> rolesRepository, IMapper mapper, IPasswordService passwordService, IJwtProvider jwtProvider)
        {
            _usersRepository = usersRepository;
            _rolesRepository = rolesRepository;
            _mapper = mapper;
            _passwordService = passwordService;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var newUser = _mapper.Map<User>(request);
            HashPassword(newUser);
            AssignRole(newUser);

            await _usersRepository.AddAsync(newUser);
            await _usersRepository.SaveChangesAsync();

            return _jwtProvider.Generate(newUser);
        }

        private void HashPassword(User newUser)
        {
            newUser.Password = _passwordService.Hash(newUser.Password);
        }

        private void AssignRole(User newUser)
        {
            var userRole = _rolesRepository.Filter(role => role.Name == UserRoles.User).FirstOrDefault();
            if (userRole is null)
            {
                throw new EntityNotFoundException(nameof(Role), $"Cannot found {nameof(Role)} with name {UserRoles.User}");
            }

            newUser.Role = userRole;
        }
    }
}
