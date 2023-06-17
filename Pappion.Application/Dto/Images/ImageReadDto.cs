using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Dto.Images
{
    public class ImageReadDto
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = string.Empty;
    }
}
