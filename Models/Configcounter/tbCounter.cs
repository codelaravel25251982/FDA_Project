namespace BeyondThemes.BeyondAdmin.Models.Configcounter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbCounter")]
    public partial class tbCounter
    {
        [Key]
        [StringLength(3)]
        [Display(Name = "ลำดับ")]
        public string CounterNo { get; set; }

        [StringLength(50)]
        [Display(Name = "ชื่อช่องบริการ")]
        public string CounterName { get; set; }
        [Display(Name = "ประเภทบริการลำดับที่ 1")]
        public int? ServID { get; set; }
      
        public int? ID { get; set; }
        [Display(Name = "ประเภทบริการลำดับที่ 2")]
        public int? ServID1 { get; set; }
        [Display(Name = "ประเภทบริการลำดับที่ 3")]
        public int? ServID2 { get; set; }

        public int? Summary { get; set; }

        public int? CallNum { get; set; }

        public int? CGroup { get; set; }

        [StringLength(3)]
        [Display(Name = "เสียงเรียก")]
        public string CallCounter { get; set; }

        public int? Announce { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        public int? Process { get; set; }

        [StringLength(10)]
        [Display(Name = "ตำแหน่งลูกศรบนบอร์ดใหญ่")]
        public string CPos { get; set; }
    }
}
