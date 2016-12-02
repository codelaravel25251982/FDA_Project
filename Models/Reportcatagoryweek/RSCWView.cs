namespace BeyondThemes.BeyondAdmin.Models.Reportcatagoryweek
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class RSCWView
    {
        [Display(Name = "วันที่")]
        public string H_Date { get; set; }
        [Display(Name = "ลำดับ")]
        public byte ServID { get; set; }
        [Display(Name = "ประเภทบริการ")]
        public string ServiceFullName { get; set; }
        [Display(Name = "จำนวนผู้มารับบริการ")]
        public int? H_Number { get; set; }

    }
}