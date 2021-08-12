using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Driven_Development_Library.DTOs;

namespace Test_Driven_Development_Library.Interfaces
{
    public interface IUserREpository
    {
        bool Validate(User user);
        void Save(User user);
        List<User> GetAll();
        public void OrderEmailAlphabetically();
    }
}
