using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myportfolio.Core.Dtos
{
    public class PortfolioItemDetailDto
    {
        [StringLength(250)]
        public string ProjectNmae { get; set; }
        [StringLength(2500)]
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ProjectUrl { get; set; }
    }
}
