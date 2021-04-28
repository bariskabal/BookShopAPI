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
using System.Threading;

namespace Business.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorDal _authorDal;
        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }
        [ValidationAspect(typeof(AuthorValidator))]
        [CacheRemoveAspect("IAuthorService.Get")]
        public IResult Add(Author author)
        {
            _authorDal.Add(author);
            return new SuccessResult(AuthorMessages.AuthorAdded);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Author>> GetAll()
        {
            return new SuccessDataResult<List<Author>>(_authorDal.GetAll(), AuthorMessages.AuthorListed);
        }
        public IDataResult<List<AuthorDetailDto>> GetById(int authorId)
        {
            return new SuccessDataResult<List<AuthorDetailDto>>(_authorDal.GetAuthorDetailById(authorId), AuthorMessages.AuthorHasArrived);
        }
        [ValidationAspect(typeof(AuthorValidator))]
        [CacheRemoveAspect("IAuthorService.Get")]
        public IResult Update(Author author)
        {
            _authorDal.Update(author);
            return new SuccessResult(AuthorMessages.AuthorAdded);
        }
    }
}
