using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Common.Exceptions
{
    [Serializable]
    public class AccessDeniedExeption : Exception
    {
        public Guid UserId { get; set; }

        public AccessDeniedExeption(Guid userId) : base(BuildExceptionMessage(userId))
        {
            UserId = userId;
        }

        private static string BuildExceptionMessage(Guid userId) => $"Access denied for user '{userId}'.";
    }
}
