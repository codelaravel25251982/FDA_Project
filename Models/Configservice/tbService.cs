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
        public byte ServID { get; set; }

        [StringLength(100)]
        public string ServiveName { get; set; }

        [StringLength(2)]
        public string Prefix { get; set; }

        public byte? CCopy { get; set; }

        public short? ExpWait { get; set; }

        [StringLength(1)]
        public string Announce { get; set; }

        [StringLength(4)]
        public string StartQ { get; set; }

        [StringLength(4)]
        public string EndQ { get; set; }

        [StringLength(4)]
        public string LastQ { get; set; }

        [StringLength(8)]
        public string QDate { get; set; }

        [StringLength(150)]
        public string Remark { get; set; }

        [StringLength(150)]
        public string Remark1 { get; set; }

        [StringLength(1)]
        public string Speaker { get; set; }

        public int? OverTime { get; set; }

        public int? ProCS1 { get; set; }

        public int? ProCS2 { get; set; }

        public int? ProCS3 { get; set; }

        public int? ProCS4 { get; set; }

        public int? QLimit { get; set; }

        public int? QLimitTime { get; set; }

        public int? ProCS5 { get; set; }

        public int? DeptID { get; set; }

        [StringLength(150)]
        public string ServiceFullName { get; set; }
    }
}
