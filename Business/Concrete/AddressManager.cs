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
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;
        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }
        public IResult Add(Address address)
        {
            _addressDal.Add(address);
            return new SuccessResult(AddressMessage.AddressAdded);
        }
    

        public IResult Delete(Address address)
        {
            _addressDal.Delete(address);
            return new SuccessResult(AddressMessage.AddressDeleted);
        }

        public IDataResult<List<Address>> GetAll()
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(), AddressMessage.AddressListed);
        }

        public IDataResult<Address> GetById(int addressId)
        {
            return new SuccessDataResult<Address>(_addressDal.Get(a=>a.Id==addressId));
        }

        public IDataResult<List<Address>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<Address>>(_addressDal.GetAll(u=>u.UserId==userId), AddressMessage.AddressListed);
        }

        public IResult Update(Address address)
        {
            _addressDal.Update(address);
            return new SuccessResult(AddressMessage.AddressUpdated);
        }
    }
}
