using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.ViewModel;
using Model.DAL;
using System.Diagnostics;

namespace ModelTests.DAL
{
    [TestClass]
    public class UserEventDALTests
    {

        [TestMethod]
        public void CreateUserEvents()
        {
            //arrange
            DateTime fromDate = new DateTime(2017, 02, 13);
            DateTime toDate = new DateTime(2017, 02, 15);
            var model = new UserEventCreateViewModel();
            model.UeCreateDate = DateTime.Now;
            model.UeDateExpires = fromDate.Date;
            model.UeWillExpires = toDate.Date;
            model.UserID = 2;
            model.EventID = 1;
            model.UeOk = false;
            model.UeType = 1;
            model.UeNote = "D2ND-BLLD-120217";

            UserEventDAL modelUe = new UserEventDAL();

            //act
            var actual = modelUe.CreateUserEvent(model);

            //assert
            Assert.IsNotNull(actual);

        }

        [TestMethod]
        public void CheckUniqueDate()
        {
            //arrange
            DateTime fromDate = new DateTime(2017, 02, 13);
            AttandanceDAL attDal = new AttandanceDAL();

            //act
            var result = attDal.CheckDateUnique(fromDate,2);

            //Assert
            Assert.AreEqual(false, result);
        }


        [TestMethod]
        public void GetListUserEventTest()
        {
            //arrange
            UserEventDAL ueDal = new UserEventDAL();
            //act
            var result = ueDal.UeListAllHome();

            //assert

            Assert.IsNotNull(result);
        }

        [TestMethod]

        public void CheckFromDateToDateTest()
        {
            //arrange
            UserEventDAL ueDAL = new UserEventDAL();
            DateTime fromDate = new DateTime(2017, 02, 16);
            DateTime toDate = new DateTime(2017, 02, 15);

            //act
            var result = ueDAL.CheckFromDateToDate(fromDate, toDate, 2);


            //assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]

        public void CheckFromDateToDateTestTrue()
        {
            //arrange
            UserEventDAL ueDAL = new UserEventDAL();
            DateTime fromDate = new DateTime(2017, 02, 18);
            DateTime toDate = new DateTime(2017, 02, 19);

            //act
            var result = ueDAL.CheckFromDateToDate(fromDate, toDate, 2);


            //assert
            Assert.AreEqual(true, result);
        }


    }
}
