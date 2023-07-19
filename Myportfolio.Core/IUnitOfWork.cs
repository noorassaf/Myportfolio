using Myportfolio.Core.Interfaces;
using Myportfolio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myportfolio.Core
{
    public interface IUnitOfWork:IDisposable
    {
        IBase<PortfolioItem> PortfolioItem { get; }
        IOwner Owner { get; }
        int complet();
    }
}
