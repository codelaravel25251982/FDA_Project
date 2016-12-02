using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace BeyondThemes.BeyondAdmin.Models.Reportcatagorymonth
{ 
    public class ReportcatagorymonthView
    {
        [Display(Name ="วันที่")]
        public string H_Date { get; set; }

        [Display(Name = "ลำดับประเภทบริการ")]
        public byte ServID { get; set; }

        [Display(Name = "ชื่อประเภทบริการ")]
        public string ServiceFullName { get; set; }

        [Display(Name = "จำนวนคนที่ให้บริการ")]
        public string H_Number { get; set; }

    }
}