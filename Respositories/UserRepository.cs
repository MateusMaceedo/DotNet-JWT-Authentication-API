using System.Collections.Generic;
using System.Linq;
using ApiAuth.Models;

namespace ApiAuth.Respositories
{
  public static class UserRepository
    {
        public static User Get(string username, string password)
        {
           var users = new List<User>
           {
              new() { Id = 1, Username = "Mateus", Password = "mateus", Role = "manager"},
              new() { Id = 1, Username = "Macedo", Password = "macedo", Role = "employee"}
           };
           return users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
