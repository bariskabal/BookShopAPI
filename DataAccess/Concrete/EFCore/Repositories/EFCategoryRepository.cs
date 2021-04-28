using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EFCore.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EFCore.Repositories
{
    public class EFCategoryRepository : EFGenericRepositoryBase<Category, BookShopContext>, ICategoryDal
    {
        
    }
}
