using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Todo.Entities;

namespace Todo.Repository
{
    internal class UserRepository
    {
        private static List<UserModel> _users = new ();


        public UserModel? Authorize(string Password, string post)
        {
            ValidateLogin(Password, post);
            if (Validator.Errors.Any())
            {
                MessageBox.Show(string.Join(Environment.NewLine, Validator.Errors));
                return null;
            }
            else
                return _users.Where(u => u.Email == post).FirstOrDefault();
        }

        public UserModel? Register(string Name, string post, string Password, string PasswordConfirm)
        {
            ValidateRegistration(Name, post, Password, PasswordConfirm);
            if (Validator.Errors.Any())
            {
                MessageBox.Show(string.Join(Environment.NewLine, Validator.Errors));
                return null;
            }
            else
            {
                var user = new UserModel()
                {
                    Email = post,
                    Password = Password,
                    Name = Name,
                };
                _users.Add(user);
                return user;
            }
        }

        private void ValidateLogin(string password, string post)
        {
            Validator.Errors.Clear();
            Validator.ValidateEmail(post);
            Validator.ValidatePassword(password);
        }

        private void ValidateRegistration(string Name, string post, string Password, string PassConfirm)
        {
            Validator.Errors.Clear();
            Validator.ValidateName(Name);
            Validator.ValidateEmail(post);
            Validator.ValidatePassword(Password);
            Validator.PasswordsEquality(Password, PassConfirm);

            if (_users.Any(u => u.Name == Name))
                Validator.Errors.Add("Имя пользователя должно быть уникально");
        }
    }
}
