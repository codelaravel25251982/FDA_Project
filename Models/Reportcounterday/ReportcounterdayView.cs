using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace BeyondThemes.BeyondAdmin.Models.Reportcounterday
{

    public class ReportcounterdayView
    {
        [Display(Name ="วันที่")]
        public string HDate { get; set; }
        [Key]
        [Display(Name = "ลำดับ")]
        public string CounterNo { get; set; }

        [Display(Name = "ประเภทบริการ")]
        public string CounterName { get; set; }

        [Display(Name = "จำนวนผู้มารับบริการ")]
        public int? HNumber { get; set; }

        [Display(Name = "เวลารอเฉลี่ย")]
        public int? WaitAvgTime { get; set; }

        [Display(Name = "เวลารอต่ำสุด")]
        public int? WaitMinTime { get; set; }

        [Display(Name = "เวลารอสูงสุด")]
        public int? WaitMaxTime { get; set; }

        [Display(Name = "เวลาให้บริการเฉลี่ย")]
        public int? ServiceAvgTime { get; set; }

        [Display(Name = "เวลาให้บริการต่ำสุด")]
        public int? ServiceMinTime { get; set; }

        [Display(Name = "เวลาให้บริการสูงสุด")]
        public int? ServiceMaxTime { get; set; }


    }
}