﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.AuthorName).NotEmpty();
            RuleFor(a => a.AuthorName).MinimumLength(2);

            RuleFor(a => a.Description).NotEmpty();


        }
    }
}
