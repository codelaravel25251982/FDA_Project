namespace BeyondThemes.BeyondAdmin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RcdSummary")]
    public class RSCD
    {

        public string H_Date { get; set; }
        public string ServiceFullName { get; set; }
        public int? H_Number { get; set; }
        [Key]
        public byte ServID { get; set; }
    }
}