using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace BeyondThemes.BeyondAdmin.Models
{
    [Table("sumall")]
    public class Sumallweek
    {
        [Key]
        public string Prefix { get; set; }
        public int? H_Number { get; set; }
        public string H_Date { get; set; }
    }
}