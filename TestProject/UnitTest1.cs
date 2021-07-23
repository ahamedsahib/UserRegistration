using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserRegistration;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetObjectUsingReflection()
        {
            UserFieldValidation userFieldValidation = new UserFieldValidation();
            object obj = null;
            try
            {
                UserRegFactory factory = new UserRegFactory();
                obj = factory.CreateUserObject("UserRegistration.UserFieldValidation", "UserFieldValidation");
                obj.Equals(userFieldValidation);
            }
            catch (UserRegistrationCustomException ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [TestMethod]
        public void ReflectionTestSetField()
        {
            string expected = "Validating user details";
            UserRegFactory urf = new UserRegFactory();
            string actual = urf.SetField(expected, "message");
            Assert.AreEqual(expected, actual);
        }
    }
}
