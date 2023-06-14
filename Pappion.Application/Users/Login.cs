using FluentValidation;
using MediatR;
using Pappion.Application.Common.Exceptions;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;

namespace Pappion.Application.Users
{
    public record LoginCommand(string Email, string Password) : ICommand<string>;

    public record LoginRequest(string Email, string Password);

    public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MaximumLength(15);
        }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IGenericRepository<User> _genericRepository;
        private readonly IJwtProvider _iwtProvider;
        private readonly IPasswordService _passwordService;

        public LoginCommandHandler(IGenericRepository<User> genericRepository, IJwtProvider iwtProvider, IPasswordService authService)
        {
            _genericRepository = genericRepository;
            _iwtProvider = iwtProvider;
            _passwordService = authService;
        }

        public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = _genericRepository.Filter(u => u.Email == request.Email).FirstOrDefault();
            if (user != null && _passwordService.IsValid(user.Password, request.Password))
            {
                return Task.FromResult(_iwtProvider.Generate(user));
            }
            
            throw new EntityNotFoundException(nameof(User));
        }
    }

}
