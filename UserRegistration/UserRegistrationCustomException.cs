using System;
namespace UserRegistration
{
    public class UserRegistrationCustomException:Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            FIELD_NOT_EXIST, EMPTY_MESSAGE, CLASS_NOT_FOUND, CONSTRUCTOR_NOT_FOUND, METHOD_NOT_FOUND
        }
        public UserRegistrationCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
