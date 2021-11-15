using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskMediapark.Domain.Entities
{
    public class Holiday : BaseEntity
    {
        [MaxLength(25)]
        public string Country { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(25)]
        public string HolidayType { get; set; }
    }
}
