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
    public class EFBookRepository : EFGenericRepositoryBase<Book, BookShopContext>, IBookDal
    {
        public List<BookDetailDto> GetBookDetails(int id)
        {
            using (BookShopContext context = new BookShopContext())
            {
                var result = from b in context.Books
                             join c in context.Categories
                             on b.CategoryId equals c.Id
                             join a in context.Authors
                             on b.AuthorId equals a.Id
                             where (b.Id == id)
                             select new BookDetailDto
                             {
                                 Id = b.Id,
                                 BookName = b.BookName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = b.UnitsInStock,
                                 AuthorName = a.AuthorName,
                                 ReleaseDate = b.ReleaseDate,
                                 UnitPrice = b.UnitPrice,
                                 Status = context.Books.Any(b => b.Id == id && b.UnitsInStock > 0),
                                 NumberOfPages = b.NumberOfPages,
                                 Description=b.Description
                             };

                return result.ToList();
            }
        }

        public List<Book> GetPopularBooks()
        {
            using (BookShopContext context = new BookShopContext())
            {
                var result = from b in context.Books
                             where b.UnitsInStock >= 10
                             select new Book
                             {
                                 Id = b.Id,
                                 BookName = b.BookName,
                                 CategoryId = b.CategoryId,
                                 AuthorId = b.AuthorId,
                                 ReleaseDate = b.ReleaseDate,
                                 UnitPrice = b.UnitPrice,
                                 UnitsInStock = b.UnitsInStock,
                                 NumberOfPages = b.NumberOfPages,
                                 Description = b.Description
                             };
                return result.Take(3).ToList();
            }
        }
        public List<Book> GetNewestsBooks()
        {
            using (BookShopContext context = new BookShopContext())
            {
                var result = from b in context.Books
                             where b.ReleaseDate>=2010
                             select new Book
                             {
                                 Id = b.Id,
                                 BookName = b.BookName,
                                 CategoryId = b.CategoryId,
                                 AuthorId = b.AuthorId,
                                 ReleaseDate = b.ReleaseDate,
                                 UnitPrice = b.UnitPrice,
                                 UnitsInStock = b.UnitsInStock,
                                 NumberOfPages = b.NumberOfPages,
                                 Description = b.Description
                             };
                return result.Take(3).ToList();
            }
        }

        public List<Book> GetBookByFilter(string textFilter)
        {
            using (BookShopContext context = new BookShopContext())
            {
                var result = from b in context.Books
                             where b.BookName.Contains(textFilter)
                             select new Book
                             {
                                 Id = b.Id,
                                 BookName = b.BookName,
                                 CategoryId = b.CategoryId,
                                 AuthorId = b.AuthorId,
                                 ReleaseDate = b.ReleaseDate,
                                 UnitPrice = b.UnitPrice,
                                 UnitsInStock = b.UnitsInStock,
                                 NumberOfPages = b.NumberOfPages,
                                 Description = b.Description
                             };
                return result.ToList();
            }
        }
    }
}
