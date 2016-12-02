namespace BeyondThemes.BeyondAdmin.Models.Reportcatagoryyear
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

        [StringLength(150)]
        public string ServiceFullName { get; set; }

        public int? DeptID { get; set; }
    }
}
