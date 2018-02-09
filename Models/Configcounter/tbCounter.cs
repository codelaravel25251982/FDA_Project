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
        public string CounterNo { get; set; }

        [StringLength(50)]
        public string CounterName { get; set; }

        public int? ServID { get; set; }

        public int? ID { get; set; }

        public int? ServID1 { get; set; }

        public int? ServID2 { get; set; }

        public int? Summary { get; set; }

        public int? CallNum { get; set; }

        public int? CGroup { get; set; }

        [StringLength(3)]
        public string CallCounter { get; set; }

        public int? Announce { get; set; }

        [StringLength(1)]
        public string Status { get; set; }

        public int? Process { get; set; }

        [StringLength(10)]
        public string CPos { get; set; }
    }
}
