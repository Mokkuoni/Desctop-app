using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Entities;

namespace Todo.Repository
{
    internal interface IUserRepository 
    {
        UserModel? Authorize(string Password, string post);

        UserModel? Register(string Name, string post, string Password, string PasswordConfirm);
    }
}
