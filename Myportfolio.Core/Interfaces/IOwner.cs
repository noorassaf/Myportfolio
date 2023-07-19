using Myportfolio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myportfolio.Core.Interfaces
{
    public interface IOwner
    {
        Task<ApplicationUser> GetInfo(int Id);
    }
}
