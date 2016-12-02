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
        [Display(Name ="วันที่")]
        public string H_Date { get; set; }
        [Key]
        [Display(Name = "ลำดับ")]
        public byte ServID { get; set; }
        [Display(Name = "ประเภทบริการ")]
        public string ServiceFullName { get; set; }
        [Display(Name = "จำนวนผู้มารับบริการ")]
        public int? H_Number { get; set; }
        

    }
}