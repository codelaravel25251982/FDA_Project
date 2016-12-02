namespace BeyondThemes.BeyondAdmin.Models
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
        public byte H_ServID { get; set; }

        [StringLength(150)]
        public string H_Date { get; set; }

        [StringLength(4)]
        public string H_Number { get; set; }
    }
}
