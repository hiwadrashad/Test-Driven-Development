using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Driven_Development_Library.DTOs;

namespace Test_Driven_Development_Library.Interfaces
{
    public interface IUserREpository<T> where T : User
    {
        bool Validate(T user);
        void Save(T user);
        List<T> GetAll();
        public void OrderEmailAlphabetically();
        public List<T> SaveAndReturnAll(ref Action<T> Save,ref Func<List<T>> GetAll, T user);
        public (bool?, List<T>)? VerifyAndReturnAll(ref Func<T, bool> Verify, ref Func<List<T>> GetAll, T user);
    }
}
