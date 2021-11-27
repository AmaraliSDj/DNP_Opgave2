using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;


namespace DNP.Data
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;
        


        public async Task<User> ValidateUser(string userName, string Password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(Password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}