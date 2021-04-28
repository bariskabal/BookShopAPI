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
    public class AuthorImageManager : IAuthorImageService
    {
        private readonly IAuthorImageDal _authorImageDal;
        public AuthorImageManager(IAuthorImageDal authorImageDal)
        {
            _authorImageDal = authorImageDal;
        }
        public IResult Add(IFormFile file, AuthorImage authorImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(authorImage.AuthorId));
            if (result != null)
            {
                return result;
            }
            authorImage.ImagePath = FileHelper.Add(file);
            authorImage.Date = DateTime.Now;
            _authorImageDal.Add(authorImage);
            return new SuccessResult();
        }
        public IResult Delete(AuthorImage authorImage)
        {
            FileHelper.Delete(authorImage.ImagePath);
            _authorImageDal.Delete(authorImage);
            return new SuccessResult();
        }

        public IDataResult<List<AuthorImage>> GetAll()
        {
            return new SuccessDataResult<List<AuthorImage>>(_authorImageDal.GetAll());
        }
        public IDataResult<AuthorImage> GetById(int id)
        {
            return new SuccessDataResult<AuthorImage>(_authorImageDal.Get(c => c.Id == id), AuthorImageMessages.AuthorImagesListed);
        }
        public IResult Update(IFormFile file, AuthorImage authorImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(authorImage.AuthorId));
            if (result != null)
            {
                return result;
            }
            authorImage.ImagePath = FileHelper.Update(_authorImageDal.Get(p => p.Id == authorImage.Id).ImagePath, file);
            authorImage.Date = DateTime.Now;
            _authorImageDal.Update(authorImage);
            return new SuccessResult();
        }
        private IResult CheckImageLimitExceeded(int authorId)
        {
            var carImageCount = _authorImageDal.GetAll(c => c.AuthorId == authorId).Count;
            if (carImageCount >= 1)
            {
                return new ErrorResult(AuthorImageMessages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }
        private IDataResult<AuthorImage> CheckIfAuthorImageNull(int id)
        {
            try
            {
                string path = @"book.jpg";
                var result = _authorImageDal.Get(c => c.AuthorId == id);
                if (result == null)
                {
                    AuthorImage authorImage = new AuthorImage { AuthorId = id, ImagePath = path, Date = DateTime.Now };
                    _authorImageDal.Add(authorImage);
                    return new SuccessDataResult<AuthorImage>(authorImage);
                }
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<AuthorImage>(ex.Message);
            }
            return new SuccessDataResult<AuthorImage>(_authorImageDal.Get(c => c.AuthorId == id));
        }

        public IDataResult<AuthorImage> GetByAuthorId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfAuthorImageNull(id));
            if (result != null)
            {
                return new ErrorDataResult<AuthorImage>(AuthorMessages.AuthorHasArrived);
            }
            return new SuccessDataResult<AuthorImage>(_authorImageDal.Get(c => c.AuthorId == id), BookImageMessages.BookImagesListed);
        }
    }
}
