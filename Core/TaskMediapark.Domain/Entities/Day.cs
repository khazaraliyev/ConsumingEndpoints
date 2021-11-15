using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskMediapark.Domain.Entities
{
    public class Day : BaseEntity
    {
        public DateTime Date { get; set; }

        [MaxLength(25)]
        public string Country { get; set; }

        [MaxLength(25)]
        public string Status { get; set; }
    }
}
