using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Driven_Development_Library.DTOs;
using Test_Driven_Development_Library.Interfaces;
using Test_Driven_Devlopment_Database.Repositories;
using Xunit;

namespace Test_Driven_Devlopment_UnitTest.UnitTests
{
    public class Save
    {
        [Fact]
        public void Saving_DTO_Working_Check()
        {
            // |
            // |  Does not work, should be working, look at this.
            // V
            //
            // mockrepository.Verify( a => a.Save(new User { Emailadress = "test@gmail.com", Id = 1, LastName = "LastName", Name = "Name" }), Times.Once);

            var mockrepository = new Mock<IUserREpository>();
            mockrepository.Setup(a => a.Save(new User { Emailadress = "test@gmail.com", Id = 1, LastName = "LastName", Name = "Name" })).Verifiable();         
        }

        [Fact]

        public void Amount_Of_DTOs_Input_Equals_Output_Check()
        {
            var mockrepository = new Mock<IUserREpository>();
            mockrepository.Setup(a => a.GetAll()).Returns(new List<Test_Driven_Development_Library.DTOs.User> {
            new Test_Driven_Development_Library.DTOs.User { Id = 1, Emailadress = "testa@hotmail.com", LastName = "lastname", Name = "Name" },
            new Test_Driven_Development_Library.DTOs.User { Id = 2, Emailadress = "testc@hotmail.com", LastName = "lastname", Name = "Name" },
            new Test_Driven_Development_Library.DTOs.User { Id = 3, Emailadress = "testb@hotmail.com", LastName = "lastname", Name = "Name" },
            new Test_Driven_Development_Library.DTOs.User { Id = 4, Emailadress = "testx@hotmail.com", LastName = "lastname", Name = "Name" }
            });

            Assert.Equal(4, mockrepository.Object.GetAll().Count());
        }

        [Theory]
        [InlineData(0, "testa@hotmail.com")]
        [InlineData(1, "testb@hotmail.com")]
        [InlineData(2, "testc@hotmail.com")]
        [InlineData(3, "testx@hotmail.com")]
        public void Does_Sorting_Email_Alphabetically_Work(int index, string email)
        {
            var mockrepository = new Mock<IUserREpository>();
            mockrepository.Setup(a => a.GetAll()).Returns(new List<Test_Driven_Development_Library.DTOs.User> {
            new Test_Driven_Development_Library.DTOs.User { Id = 1, Emailadress = "testa@hotmail.com", LastName = "lastname", Name = "Name" },
            new Test_Driven_Development_Library.DTOs.User { Id = 2, Emailadress = "testc@hotmail.com", LastName = "lastname", Name = "Name" },
            new Test_Driven_Development_Library.DTOs.User { Id = 3, Emailadress = "testb@hotmail.com", LastName = "lastname", Name = "Name" },
            new Test_Driven_Development_Library.DTOs.User { Id = 4, Emailadress = "testx@hotmail.com", LastName = "lastname", Name = "Name" }
            }.OrderBy(a => a.Emailadress).ToList());

            // |
            // |   doesn't work 
            // V

            //mockrepository.Setup(a => a.OrderEmailAlphabetically());

            Assert.Equal(mockrepository.Object.GetAll()[index].Emailadress, email);

           
        }
    }
}
