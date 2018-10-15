using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public partial class Destination
    {
        [Key]
        public int DestinationId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
