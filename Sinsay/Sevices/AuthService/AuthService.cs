using Sinsay.Domain;
using Sinsay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinsay.Sevices.AuthService
{
    public class AuthService
    {
        AppDbContext _appDbContext = new();
        public AppUser Register()
        {
            throw new NotImplementedException();
        }

        public AppUser SignIn(string email, string password)
        {
            try
            {
                password = PasswordHashService.CreateHash(password);

                AppUser? user = _appDbContext.Users.Where(x=>x.Email == email && x.PasswordHash == password).First();
                return user;
            }
            catch (Exception ex) 
            {
                throw new Exception($"{ex.Message}");
            }
        }

       
    }
}
