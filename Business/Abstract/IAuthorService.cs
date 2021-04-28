using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        IDataResult<List<Author>> GetAll();
        IDataResult<List<AuthorDetailDto>> GetById(int authorId);
        IResult Add(Author author);
        IResult Update(Author author);
    }
}
