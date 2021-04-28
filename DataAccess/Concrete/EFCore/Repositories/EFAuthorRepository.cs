using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EFCore.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EFCore.Repositories
{
    public class EFAuthorRepository : EFGenericRepositoryBase<Author, BookShopContext>, IAuthorDal
    {
        public List<AuthorDetailDto> GetAuthorDetailById(int id)
        {
            using (BookShopContext context = new BookShopContext())
            {
            var books = from b in context.Books
                        join a in context.Authors
                        on b.AuthorId equals id
                        where(a.Id==id)
                        select new Book
                        {
                            Id = b.Id,
                            AuthorId = a.Id,
                            BookName = b.BookName,
                            CategoryId = b.CategoryId,
                            NumberOfPages = b.NumberOfPages,
                            ReleaseDate = b.ReleaseDate,
                            UnitPrice = b.UnitPrice,
                            UnitsInStock = b.UnitsInStock
                        };
            var result = from a in context.Authors
                         where(a.Id==id)
                         select new AuthorDetailDto
                         {
                             Id = a.Id,
                             AuthorName = a.AuthorName,
                             Description = a.Description,
                             Books = books.ToList()
                         };
            return result.ToList();

            }
        }

    }
}
