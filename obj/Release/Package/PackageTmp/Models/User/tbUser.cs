namespace BeyondThemes.BeyondAdmin.Models.User
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbUser")]
    public partial class tbUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(3)]
        public string LoginID { get; set; }

        [StringLength(3)]
        public string PassWord { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        public int? authtype { get; set; }
    }
}
