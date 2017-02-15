using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ViewModel;
using Model.EF;

namespace Model.DAL.Tests
{
    [TestClass()]
    public class AttandanceDALTests
    {
        

        [TestMethod()]
        public void ChamCongThemTest()
        {
            //arrange
            //DateTime fromDate = new DateTime(2017, 02, 10);
            //bool expected = true;
            //var model = new AttandanceDAL();

            ////act
            //var actual = model.CheckCongThem(fromDate);

            ////assert
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CheckCongThemTest()
        {
            //arrange
            DateTime fromDate = new DateTime(2017, 02, 12);
            DateTime toDate = new DateTime(2017, 02, 15);
            var model = new UserEventCreateViewModel();
            model.UeID = 3;
            model.UeCreateDate = DateTime.Now;
            model.UeDateExpires = fromDate.Date;
            model.UeWillExpires = toDate.Date;
            model.UserID = 1;

            AttandanceDAL modelAtt = new AttandanceDAL();
            var expected = 1;

            //act
            var actual = modelAtt.CheckCongThem(model);

            //assert
            Assert.AreEqual(expected, actual);
        }


    }
}