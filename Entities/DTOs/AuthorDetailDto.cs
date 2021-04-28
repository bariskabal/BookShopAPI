using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class AuthorDetailDto : IDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public List<Book> Books { get; set; }
    }
}
