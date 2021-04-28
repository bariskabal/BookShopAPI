using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICartItemService
    {
        IResult Add(CartItem cartItem);
        IResult Update(CartItem cartItem);
        IResult Delete(CartItem cartItem);
        IDataResult<List<CartItemDto>> GetCartItems(int userId);
    }
}
