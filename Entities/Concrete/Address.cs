using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string AddressName { get; set; }
        public string Description { get; set; }
        public string Gsm { get; set; }
        public int UserId { get; set; }
        
    }
}
