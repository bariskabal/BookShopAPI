using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CartItemManager : ICartItemService
    {
        private readonly ICartItemDal _cartItemDal;
        public CartItemManager(ICartItemDal cartItemDal)
        {
            _cartItemDal = cartItemDal;
        }
        public IResult Add(CartItem cartItem)
        {
            _cartItemDal.Add(cartItem);
            return new SuccessResult(CartItemMessage.CartItemAdded);
        }

        public IResult Delete(CartItem cartItem)
        {
            _cartItemDal.Add(cartItem);
            return new SuccessResult(CartItemMessage.CartItemUpdated);
        }

        public IDataResult<List<CartItemDto>> GetCartItems(int userId)
        {
            return new SuccessDataResult<List<CartItemDto>>(_cartItemDal.GetCartItems(userId), CartItemMessage.CartItemsListed);
        }

        public IResult Update(CartItem cartItem)
        {
            _cartItemDal.Update(cartItem);
            return new SuccessResult(CartItemMessage.CartItemDeleted);
        }
    }
}
