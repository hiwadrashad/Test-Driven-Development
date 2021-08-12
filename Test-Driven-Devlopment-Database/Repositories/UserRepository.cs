using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Driven_Development_Library.DTOs;
using Test_Driven_Development_Library.Interfaces;
using Test_Driven_Devlopment_Database.Database;

namespace Test_Driven_Devlopment_Database.Repositories
{
    public class UserRepository : IUserREpository
    {
        private readonly UserDbContext _userDbContext;

        public UserRepository(UserDbContext userDbcontext)
        {
            _userDbContext = userDbcontext;
        }

        public bool Validate(User user)
        {


            if (user.Emailadress == "" || user.Emailadress == null)
            {
                throw new NullReferenceException("emptyinput");
            }

            if (user.LastName == "" || user.LastName == null)
            {
                throw new NullReferenceException("emptyinput");
            }

            var emailmatches = _userDbContext.Users.Where(a => a.Emailadress == user.Emailadress);

            if (emailmatches.Count() > 0)
            {
                throw new ArgumentException("wrongvalue");
            }

            if (!(Test_Driven_Development_Library.Methods.Email.EmailIsValid(user.Emailadress)))
            {
                throw new ArgumentException("wrongvalue");
            }

            return true;
        }

        public void OrderEmailAlphabetically()
        {
            _userDbContext.Users.OrderBy(a => a.Emailadress);
        }

        public void Save(User user)
        {

            if (Validate(user))
            {
                _userDbContext.Users.Add(user);
                _userDbContext.SaveChanges();
            }
        }

        public List<User> GetAll()
        {
           return _userDbContext.Users.ToList();
        }


    }
}
