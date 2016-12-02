namespace BeyondThemes.BeyondAdmin.Models.Reportcatagorymonth
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbQueueHist")]
    public partial class tbQueueHist
    {
        [Key]
        public int H_Index { get; set; }

        [StringLength(20)]
        public string H_Date { get; set; }

        [StringLength(4)]
        public string H_Number { get; set; }

        public int? H_ServID { get; set; }
    }
}
