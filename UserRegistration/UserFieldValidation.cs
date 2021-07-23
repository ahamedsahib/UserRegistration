using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserRegistration
{
    public class UserFieldValidation
    {
        UserRegistrationFieldConstrains FieldConstrains = new UserRegistrationFieldConstrains();
        public void ValidateUser()
        {

            Console.Write("Enter first name :");
            FieldConstrains.firstName = Console.ReadLine();
            Console.Write("Enter Last name : ");
            FieldConstrains.lastName = Console.ReadLine();
            Console.Write("Enter Email Id : ");
            FieldConstrains.emailId = Console.ReadLine();
            Console.Write("Enter Phone Number :");
            FieldConstrains.phoneNumber = Console.ReadLine();
            Console.Write("Enter Password : ");
            FieldConstrains.password = Console.ReadLine();
            ValidateUserAnnotationFields();
        }

        public void ValidateUserAnnotationFields()
        {
            ValidationContext validationContext = new ValidationContext(FieldConstrains, null, null);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(FieldConstrains, validationContext, validationResults, true);

            if (!isValid)
            {
                foreach (ValidationResult validationResult in validationResults)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }

        }
    }
}
