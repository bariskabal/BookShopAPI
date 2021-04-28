using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EFCore.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EFCore.Repositories
{
    public class EFCartItemRepository : EFGenericRepositoryBase<CartItem, BookShopContext>, ICartItemDal
    {
        public List<CartItemDto> GetCartItems(int userId)
        {
            using (BookShopContext context = new BookShopContext())
            {
                var result = from c in context.CartItems
                             join b in context.Books
                             on c.BookId equals b.Id
                             where (c.UserId == userId)
                             select new CartItemDto
                             {
                                 Id = c.Id,
                                 BookId = c.BookId,
                                 Book = new Book
                                 {
                                     Id=b.Id,
                                     AuthorId=b.AuthorId,
                                     BookName=b.BookName,
                                     CategoryId=b.CategoryId,
                                     Description=b.Description,
                                     NumberOfPages=b.NumberOfPages,
                                     ReleaseDate=b.ReleaseDate,
                                     UnitPrice=b.UnitPrice,
                                     UnitsInStock=b.UnitsInStock
                                 },
                                 Quantity = c.Quantity,
                                 UserId = c.UserId
                             };
                return result.ToList();

            }
        }
    }
}
