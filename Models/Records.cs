using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Covid.Models
{
    public class Records
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string CountryId { set; get; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
