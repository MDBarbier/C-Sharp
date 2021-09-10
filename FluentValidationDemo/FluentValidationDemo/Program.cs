using FluentValidationDemo.Models;
using FluentValidationDemo.Validators;
using System;

namespace FluentValidationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            PersonValidator pv = new PersonValidator();
            var validationResult = pv.Validate(p);

            Console.WriteLine($"Validation result: {validationResult.IsValid}");

            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine($"  Error: {error.ErrorMessage}");
            }
        }
    }
}
