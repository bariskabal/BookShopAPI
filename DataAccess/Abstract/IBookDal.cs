using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBookDal : IGenericDal<Book>
    {
        List<BookDetailDto> GetBookDetails(int id);
        List<Book> GetBookByFilter(string textFilter);
        List<Book> GetPopularBooks();
        List<Book> GetNewestsBooks();
    }
}
