using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }

    }
}