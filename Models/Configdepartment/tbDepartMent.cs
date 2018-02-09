namespace BeyondThemes.BeyondAdmin.Models.Configdepartment
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbDepartMent")]
    public partial class tbDepartMent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeptID { get; set; }

        [StringLength(100)]
        public string DeptName { get; set; }
    }
}
