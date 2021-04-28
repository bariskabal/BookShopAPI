using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private readonly ICreditCardDal _creditCard;
        public CreditCardManager(ICreditCardDal creditCard)
        {
            _creditCard = creditCard;
        }
        public IResult Add(CreditCard creditCard)
        {
            _creditCard.Add(creditCard);
            return new SuccessResult(CreditCardMessage.CreditCardAdded);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCard.Delete(creditCard);
            return new SuccessResult(CreditCardMessage.CreditCardDeleted);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCard.GetAll(), CreditCardMessage.CreditCardListed);
        }

        public IDataResult<CreditCard> GetById(int creditCardId)
        {
            return new SuccessDataResult<CreditCard>(_creditCard.Get(a => a.Id == creditCardId));
        }

        public IDataResult<List<CreditCard>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCard.GetAll(u => u.UserId == userId), CreditCardMessage.CreditCardListed);
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCard.Update(creditCard);
            return new SuccessResult(CreditCardMessage.CreditCardUpdated);
        }
    }
}
