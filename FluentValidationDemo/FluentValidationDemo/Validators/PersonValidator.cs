using FluentValidation;
using FluentValidationDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationDemo.Validators
{
    class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Age).GreaterThan(0);
            RuleFor(p => p.Dob).NotEmpty();
            RuleFor(p => p.Name).NotNull();
        }
    }
}
