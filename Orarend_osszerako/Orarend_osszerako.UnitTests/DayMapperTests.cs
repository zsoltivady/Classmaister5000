using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orarend_osszerako;
using Orarend_osszerako.Model;
using Orarend_osszerako.Mapper;

namespace Orarend_osszerako.UnitTests
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
            var result = ModelToEntity(day);
            
            //Assert
        }
    }
}
