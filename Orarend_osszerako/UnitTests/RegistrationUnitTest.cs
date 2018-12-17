using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orarend_osszerako.BusinessLogic;
using Orarend_osszerako.Model;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class RegistrationUnitTest
    {
        //[TestMethod]
        //public void TestIfSubject_IsEntity()
        //{
        //    //Arrange
        //    var subject = new SubjectModel();
        //    subject.SubjectId = 1;
        //    subject.SubjectName = subject.SubjectName;
        //    subject.IsLecture = subject.IsLecture == false ? Convert.ToByte(0) : Convert.ToByte(1);
        //    subject.User_Id = subject.User_Id;

        //    //Act
        //    var result = SubjectMapper.ModelToEntity(subject);

        //    //Assert
        //    Assert.AreEqual(subject.SubjectId, result.Id);
        //}

        [TestMethod]
        public void TestRegistration()
        {
            Registration.RegisterUser("xXxGasTheJews88", "jelszo", "jelszo", "Kalányos", "Dakota");
            using (var context = new Classmaister5000Entities())
            {
                bool hasUser = context.Users.Any(user => user.UserName.ToLower() == "xXxGasTheJews88".ToLower());
                Assert.IsTrue(hasUser);
            }
        }
    }
}
