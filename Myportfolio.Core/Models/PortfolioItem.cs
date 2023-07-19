using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myportfolio.Core.Models
{
    public class PortfolioItem
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string ProjectNmae { get; set; }
        [MaxLength(2500)]
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ProjectUrl { get; set; }
    }
}
