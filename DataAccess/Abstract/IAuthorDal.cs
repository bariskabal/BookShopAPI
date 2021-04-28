using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IAuthorDal : IGenericDal<Author>
    {
        List<AuthorDetailDto> GetAuthorDetailById(int id);
    }
}
