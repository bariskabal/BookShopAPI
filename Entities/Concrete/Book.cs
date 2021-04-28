using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string BookName { get; set; }
        public int ReleaseDate { get; set; }
        public int NumberOfPages { get; set; }
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }

    }
}
