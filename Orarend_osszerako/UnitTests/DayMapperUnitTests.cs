using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orarend_osszerako.Model;
using Orarend_osszerako.Mapper;

namespace UnitTests
{
    [TestClass]
    public class DayMapperTests
    {
        [TestMethod]
        public void ModelToEntity_DayToModelDay_ReturnsTrue()
        {
            //Arrange
            var day = new DayModel();
            day.Id = 1;
            day.Day1 = DayEnum.Monday;

            //Act
            var result = DayMapper.ModelToEntity(day);

            //Assert
            Assert.AreEqual(day.Id, result.Id);            
        }

        

    }
}
