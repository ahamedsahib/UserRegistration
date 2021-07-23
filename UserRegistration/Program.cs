using System;

namespace UserRegistration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to User Registration Validation Program");
            UserFieldValidation userFieldValidation = new UserFieldValidation();
            userFieldValidation.ValidateUser();
        }
    }
}
