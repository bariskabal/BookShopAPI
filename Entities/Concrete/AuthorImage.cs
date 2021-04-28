using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class AuthorImage : IEntity
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
