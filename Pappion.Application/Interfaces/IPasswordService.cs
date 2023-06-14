using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Interfaces
{
    public interface IPasswordService
    {
        string Hash(string password);
        bool IsValid(string passwordHash, string password);
    }
}
