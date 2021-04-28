using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.BookName).NotEmpty();
            RuleFor(b => b.BookName).MinimumLength(2);

            RuleFor(b => b.CategoryId).NotEmpty();

            RuleFor(b => b.NumberOfPages).NotEmpty();
            RuleFor(p => p.NumberOfPages).GreaterThan(0);

            RuleFor(b => b.ReleaseDate).NotEmpty();
            RuleFor(b => b.AuthorId).NotEmpty();

            RuleFor(b => b.UnitsInStock).NotEmpty();

            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);

        }

    }
}
