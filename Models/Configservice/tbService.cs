namespace BeyondThemes.BeyondAdmin.Models.Configservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbService")]
    public partial class tbService
    {
        [Key]
        [Display(Name = "ลำดับ")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte ServID { get; set; }

        [StringLength(100)]

        [Display(Name = "ชื่อประเภทบริการ")]
        public string ServiveName { get; set; }

        [StringLength(2)]
        [Display(Name = "อักษรนำ")]
        public string Prefix { get; set; }
        [Display(Name = "จำนวนบัตร")]
        public byte? CCopy { get; set; }
        [Display(Name = "เวลารอ")]
        public short? ExpWait { get; set; }

        [StringLength(1)]
        public string Announce { get; set; }

        [StringLength(4)]
        [Display(Name = "คิวแรก")]
        public string StartQ { get; set; }

        [StringLength(4)]
        [Display(Name = "คิวสุดท้าย")]
        public string EndQ { get; set; }

        [StringLength(4)]
        public string LastQ { get; set; }

        [StringLength(8)]
        public string QDate { get; set; }

        [StringLength(150)]
        [Display(Name = "หมายเหตุ 1")]
        public string Remark { get; set; }

        [StringLength(150)]
        [Display(Name = "หมายเหตุ 2")]
        public string Remark1 { get; set; }

        [StringLength(1)]
        public string Speaker { get; set; }

        public int? OverTime { get; set; }
        [Display(Name = "ขั้นตอน 1")]
        public int? ProCS1 { get; set; }
        [Display(Name = "ขั้นตอน 2")]
        public int? ProCS2 { get; set; }
        [Display(Name = "ขั้นตอน 3")]
        public int? ProCS3 { get; set; }
        [Display(Name = "ขั้นตอน 4")]
        public int? ProCS4 { get; set; }

        public int? QLimit { get; set; }

        public int? QLimitTime { get; set; }
        [Display(Name = "ขั้นตอน 5")]
        public int? ProCS5 { get; set; }
        [Display(Name = "แผนก")]
        public int DeptID { get; set; }

        [StringLength(150)]
        public string ServiceFullName { get; set; }
    }
}
