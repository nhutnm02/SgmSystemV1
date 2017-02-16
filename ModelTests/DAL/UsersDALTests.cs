using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.DAL;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL.Tests
{
    [TestClass()]
    public class UsersDALTests
    {
        [TestMethod()]
        public void GetListForClientTest()
        {
            //arrange

            UsersDAL userDal = new UsersDAL();
            //act
            var result = userDal.GetListForClient();
            //Assert
            Assert.IsNotNull(result);
        }
        [TestMethod()]
        public void TestLogin()
        {
            //arrange
            UserLoginViewModel model = new UserLoginViewModel();
            model.UserName = "nhutnm";
            model.Password = "123123";
            model.UserStatus = true;
            var userDAL = new UsersDAL();

            //act
            var result = userDAL.Login(model);

            //assert
            Assert.AreEqual(true, result);

        }
    }
}