using FluentValidation;
using Microsoft.AspNetCore.Routing.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Features.Students.Commands.CreateStudent
{
    public class StudentValidations : AbstractValidator<CreateStudentCommand>
    {
        public StudentValidations()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("وارد کردن نام اجباری است")
                .MaximumLength(30)
                .WithMessage("طول نام دانش اموز 50 کارکتر است");
            RuleFor(x => x.BirthDate).Must(ValidAge).WithMessage("سن وارد شده باید از 7 سال بیشتر باشد");
        }
        private bool ValidAge(DateTime birthDate)
        {
            bool result;
            int age = new DateTime((DateTime.Now - birthDate).Ticks).Year;
            result = age > 7 ? true : false;
            return result;
        }
    }
}
