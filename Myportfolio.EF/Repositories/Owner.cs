using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Myportfolio.Core.Interfaces;
using Myportfolio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myportfolio.EF.Repositories
{
    public class Owner : IOwner
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public Owner(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<ApplicationUser> GetInfo(int Id)
        {
          var user= await _userManager.Users.FirstOrDefaultAsync(u => u.Id == Id);
            return user;
        }
    }
}
