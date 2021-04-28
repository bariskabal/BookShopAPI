using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BookImageManager : IBookImageService
    {
        private readonly IBookImageDal _bookImageDal;
        public BookImageManager(IBookImageDal bookImageDal)
        {
            _bookImageDal = bookImageDal;
        }
        public IResult Add(IFormFile file, BookImage bookImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(bookImage.BookId));
            if (result != null)
            {
                return result;
            }
            bookImage.ImagePath = FileHelper.Add(file);
            bookImage.Date = DateTime.Now;
            _bookImageDal.Add(bookImage);
            return new SuccessResult();
        }
        public IResult Delete(BookImage bookImage)
        {
            FileHelper.Delete(bookImage.ImagePath);
            _bookImageDal.Delete(bookImage);
            return new SuccessResult();
        }

        public IDataResult<List<BookImage>> GetAll()
        {
            return new SuccessDataResult<List<BookImage>>(_bookImageDal.GetAll());
        }
        public IDataResult<BookImage> GetById(int id)
        {
            IResult result = BusinessRules.Run(CheckIfBookImageNull(id));
            if (result != null)
            {
                return new ErrorDataResult<BookImage>(BookImageMessages.BookImageLimitExceeded);
            }
            return new SuccessDataResult<BookImage>(_bookImageDal.Get(c => c.BookId == id), BookImageMessages.BookImageHasArrived);
        }
        public IResult Update(IFormFile file, BookImage bookImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(bookImage.BookId));
            if (result != null)
            {
                return result;
            }
            bookImage.ImagePath = FileHelper.Update(_bookImageDal.Get(p => p.Id == bookImage.Id).ImagePath, file);
            bookImage.Date = DateTime.Now;
            _bookImageDal.Update(bookImage);
            return new SuccessResult();
        }
        private IResult CheckImageLimitExceeded(int bookId)
        {
            var bookImageCount = _bookImageDal.GetAll(c => c.BookId == bookId).Count;
            if (bookImageCount >= 1)
            {
                return new ErrorResult(BookImageMessages.BookImageLimitExceeded);
            }
            return new SuccessResult();
        }
        private IDataResult<BookImage> CheckIfBookImageNull(int id)
        {
            try
            {
                string path = @"book.jpg";
                var result = _bookImageDal.Get(c => c.BookId == id);
                if (result==null)
                {
                    BookImage bookImage = new BookImage { BookId = id, ImagePath = path, Date = DateTime.Now };
                    _bookImageDal.Add(bookImage);
                    return new SuccessDataResult<BookImage>(bookImage);
                }
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<BookImage>(ex.Message);
            }
            return new SuccessDataResult<BookImage>(_bookImageDal.Get(c => c.BookId == id));
        }
    }
}
