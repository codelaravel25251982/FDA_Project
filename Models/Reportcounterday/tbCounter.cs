using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace BeyondThemes.BeyondAdmin.Models.Reportcounterday
{   

    [Table("tbCounter")]
    public partial class TbCounter
    {
        [Key]
        public string CounterNo { get; set; }

        [StringLength(150)]
        public string CounterName { get; set; }
    }
}
