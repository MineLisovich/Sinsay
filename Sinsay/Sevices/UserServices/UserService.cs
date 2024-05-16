using Microsoft.EntityFrameworkCore;
using Sinsay.Domain;
using Sinsay.Models;

namespace Sinsay.Sevices.UserServices
{
    public static class UserService 
    {

        public static List<Role> GetAllRoles()
        {
            using (AppDbContext db = new())
            {
                List<Role> roles = db.Roles.ToList();
                return roles;
            }
        }

        public static List<AppUser> GetAllUsers()
        {
            using (AppDbContext db = new())
            {
                List<AppUser> users = db.Users.Include(x=> x.Role).ToList();
                return users;
            }
        }

        public static List<AppUser> SearchUserList(string search)
        {
            using (AppDbContext db = new())
            {

                List<AppUser> users = db.Users.Include(x => x.Role).Where(x => x.Email.Contains(search)).ToList();
                return users;
            }
        }

        public static bool AddUser(string email, string username, string phone, Role _role)
        {
            
            try
            {
              using (AppDbContext db = new())
              {
                 bool userExist = db.Users.Any(x => x.Email ==email);
                 if(userExist is true) { return false; }

                    string tempPassword = Guid.NewGuid().ToString("N").Substring(0, 10); // Получите первые 10 символов из GUID


                    AppUser user = new()
                {
                    Email = email,
                    UserName = username,
                    PasswordHash = PasswordHashService.CreateHash(tempPassword),
                    PhoneNumber = phone,
                    RoleId = _role.Id,
                    LastVisit = null,
                    isBloced = false
                };
               
                    db.Users.Add(user);
                    db.SaveChanges();

                    SendEmailService send = new();
                    send.SendEmailAsync(email:email, subject:"Аккаунт создан", message: "Пароль для входа: " + tempPassword);

                    return true;
              }
            }
            catch { return false; }
        }

        public static bool EditUser(AppUser user, string email, string username, string phone, Role _role, string emailCurrUser)
        {
            try
            {
                using (AppDbContext db = new())
                {
                    AppUser? getUser = db.Users.FirstOrDefault(x => x.Id == user.Id);
                    if(getUser.Email != emailCurrUser) { getUser.RoleId = _role.Id; }
                    getUser.Email = email;
                    getUser.UserName = username;
                    getUser.PhoneNumber = phone;
                    db.SaveChanges();
                }
                return true;
            }
            catch { return false; }
        }

        public static bool DeleteUser(int id, string emailCurrUser)
        {
            using (AppDbContext db = new())
            {
               AppUser? user = db.Users.FirstOrDefault(x=>x.Id == id);
                string userEmail = user.Email;
               if(user is null) { return false; }
               if (user.Email == emailCurrUser) { return false; }
                try
                {
                    db.Users.Remove(user);
                    db.SaveChanges();

                    SendEmailService send = new();
                    send.SendEmailAsync(email: userEmail, subject: "Аккаунт удалён", message: "Ваш аккаунт был удалён администратором");

                    return true;
                }
                catch { return false; }
            }
        }


        public static bool BlockUnBlockUser (int id, string emailCurrUser, bool isblock)
        {
            using (AppDbContext db = new())
            {
                AppUser? user = db.Users.FirstOrDefault(x => x.Id == id);
                if (user is null) { return false; }
                if (user.Email == emailCurrUser) { return false; }
                try
                {
                    if(isblock is true)
                    {
                        user.isBloced = true;
                        SendEmailService send = new();
                        send.SendEmailAsync(email: user.Email, subject: "Аккаунт заблокирован", message: "Ваш аккаунт был заблокирован");
                    }
                    else
                    {
                        user.isBloced = false;
                        SendEmailService send = new();
                        send.SendEmailAsync(email: user.Email, subject: "Аккаунт разблокирован", message: "Ваш аккаунт был разблокироан");
                    }
                    db.SaveChanges();
                    return true;
                }
                catch { return false; }
            }
        }

       public static bool ChangePassword(int userId, string newpass)
       {
            try
            {
                using(AppDbContext db = new())
                {
                    AppUser? getuser = db.Users.FirstOrDefault(x=>x.Id == userId);
                    getuser.PasswordHash = PasswordHashService.CreateHash(newpass);
                    db.SaveChanges();  
                }
                return true;
            }
            catch { return false; }
       }
    }
}
