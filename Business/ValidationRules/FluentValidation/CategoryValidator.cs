using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(b => b.CategoryName).NotEmpty();
            RuleFor(b => b.CategoryName).MinimumLength(2);
        }

    }
}
