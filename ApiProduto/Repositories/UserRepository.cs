using ApiProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProduto.Repositories
{
    public static class UserRepository
    {
        // Criei uma classe básica e statica com dados fictícios só pra agilizar o processo
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "lionel messi", Password = "0copasdomundo" });
            users.Add(new User { Id = 2, Username = "vampeta", Password = "1copadomundo" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
