using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace UserRegistration
{
    public class UserRegFactory
    {
        /// <summary>
        /// object Creation using reflection 
        /// </summary>
        public Object CreateUserObject(string className, string constructorName)
        {
            //check class name and constructor name are same
            string pattern = constructorName + "$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    //create assembly object
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type classType = assembly.GetType(className);
                    //create object
                    var obj = Activator.CreateInstance(classType);
                    return obj;
                }
                catch (UserRegistrationCustomException ex)
                {
                   
                    throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.CLASS_NOT_FOUND, "Class Not found");
                }
            }
            else
            {
             
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor Not found");
            }

        }

        /// <summary>
        /// Test method for setting field
        /// </summary>
        public string SetField(string message, string fieldName)
        {
            try
            {
                UserFieldValidation user = new UserFieldValidation();
                Type type = typeof(UserFieldValidation);
                FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.EMPTY_MESSAGE, "Message should not be null");
                }
                fieldInfo.SetValue(user, message);
                return user.message;
            }
            catch (NullReferenceException)
            {
                throw new UserRegistrationCustomException(UserRegistrationCustomException.ExceptionType.FIELD_NOT_EXIST, "Feild is not found");
            }
        }
    }

}
