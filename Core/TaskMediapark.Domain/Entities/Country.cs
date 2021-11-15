using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskMediapark.Domain.Entities
{
    public class Country:BaseEntity
    {
        [MaxLength(25)]
        public string Name { get; set; }

        [MaxLength(25)]
        public string CountryCode { get; set; }
    }
}
