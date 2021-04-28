using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthorImageService
    {
        IDataResult<List<AuthorImage>> GetAll();
        IDataResult<AuthorImage> GetById(int id);
        IResult Add(IFormFile file, AuthorImage authorImage);
        IResult Delete(AuthorImage authorImage);
        IResult Update(IFormFile file, AuthorImage authorImage);
        IDataResult<AuthorImage> GetByAuthorId(int id);
    }
}
