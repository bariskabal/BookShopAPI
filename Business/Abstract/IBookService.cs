
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBookService
    {
        IDataResult<List<Book>> GetAll();
        IDataResult<List<Book>> GetPopularBooks();
        IDataResult<List<Book>> GetNewestsBooks();
        IDataResult<List<Book>> GetAllByCategoryId(int id);
        IDataResult<List<Book>> GetAllByAuthorId(int id);
        IDataResult<List<Book>> GetBookByFilter(string textFilter);
        IDataResult<List<Book>> GetByAuthorCategoryId(int authorId,int categoryId);
        IDataResult<List<Book>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<BookDetailDto>> GetBookDetailsById(int bookId);
        IResult Add(Book book);
        IResult Update(Book book);
    }
}
