using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Utilities.Business;
using System.Threading;

namespace Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookDal _bookDal;
        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }
        [SecuredOperation("book.add,admin")]
        [ValidationAspect(typeof(BookValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Book book)
        {
            IResult result = BusinessRules.Run(CheckIfBookNameExists(book.BookName));
            if (result != null)
            {
                return result;
            }
            _bookDal.Add(book);
            return new SuccessResult(BookMessages.BookAdded);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(),BookMessages.BooksListed);
        }
        public IDataResult<List<Book>> GetPopularBooks()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetPopularBooks(), BookMessages.BooksListed);
        }
        public IDataResult<List<Book>> GetNewestsBooks()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetNewestsBooks(), BookMessages.BooksListed);
        }
        public IDataResult<List<Book>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(c => c.CategoryId == id),BookMessages.BooksHasArrivedWithByCategory);
        }
        public IDataResult<List<Book>> GetAllByAuthorId(int id)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(c => c.AuthorId == id), BookMessages.BooksHasArrivedWithByAuthor);
        }
        public IDataResult<List<Book>> GetByAuthorCategoryId(int authorId, int categoryId)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(c => c.AuthorId == authorId && c.CategoryId == categoryId));
        }
        public IDataResult<List<Book>> GetBookByFilter(string textFilter)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetBookByFilter(textFilter));
        }
        public IDataResult<List<BookDetailDto>> GetBookDetailsById(int bookId)
        {
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetails(bookId), BookMessages.BookHasArrived);
        }
        public IDataResult<List<Book>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll(b => b.UnitPrice >= min && b.UnitPrice <= max),BookMessages.BooksHasArrivedWithByUnitPrice);
        }
        [ValidationAspect(typeof(BookValidator))]
        [SecuredOperation("book.update,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Book book)
        {
            _bookDal.Update(book);
            return new SuccessResult(BookMessages.BookUpdated);
        }
        private IResult CheckIfBookNameExists(string bookName)
        {

            var result = _bookDal.GetAll(b => b.BookName == bookName).Any();
            if (result)
            {
                return new ErrorResult(BookMessages.BookNameAlreadyExists);
            }

            return new SuccessResult();
        }
        public IResult TransactionalOperation(Book book)
        {
            _bookDal.Update(book);
            _bookDal.Add(book);
            return new SuccessResult(BookMessages.BookUpdated);
        }


    }
}
