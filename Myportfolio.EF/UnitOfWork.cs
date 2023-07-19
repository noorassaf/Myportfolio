using Microsoft.AspNetCore.Identity;
using Myportfolio.Core;
using Myportfolio.Core.Interfaces;
using Myportfolio.Core.Models;
using Myportfolio.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myportfolio.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public IBase<PortfolioItem> PortfolioItem { get; private set; }
        public IOwner Owner { get; private set; }
        public UnitOfWork(ApplicationDbContext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager; 
            PortfolioItem=new Base<PortfolioItem>(_context);
            Owner=new Owner(_context, _userManager);
        }
        public int complet()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
