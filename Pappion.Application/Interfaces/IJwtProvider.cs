using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Interfaces
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
