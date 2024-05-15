using Microsoft.EntityFrameworkCore;
using Sinsay.Domain;
using Sinsay.Models;

namespace Sinsay.Sevices.AuthService
{
    public class AuthService
    {
        AppDbContext _appDbContext = new();
        public AppUser Register(string email, string userName, string password, string? phoneNumber)
        {
            try
            {
                AppUser newUser = new()
                {
                    Email = email,
                    UserName = userName,
                    PasswordHash = PasswordHashService.CreateHash(password),
                    PhoneNumber = phoneNumber,
                    RoleId = 2,
                    isBloced = false
                };
                _appDbContext.Users.Add(newUser);
                _appDbContext.SaveChanges();
                return newUser;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public AppUser SignIn(string email, string password)
        {
            try
            {
                password = PasswordHashService.CreateHash(password);

                AppUser? user = _appDbContext.Users.Include(x=>x.Role).Where(x=>x.Email == email && x.PasswordHash == password).First();
                return user;
            }
            catch (Exception ex) 
            {
                throw new Exception($"{ex.Message}");
            }
        }

       
    }
}
