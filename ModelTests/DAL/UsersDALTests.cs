using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.DAL;
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
    }
}