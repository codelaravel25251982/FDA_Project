namespace BeyondThemes.BeyondAdmin.Models.Configdepartment
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("tbDepartMent")]
    public partial class tbDepartMent
    {
        internal SelectList tdm;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "������ҹ��������ԡ��")]
        [Required(ErrorMessage = "��سҡ�͡���������ú���¤��")]
        public int DeptID { get; set; }

        [StringLength(100)]
        [Display(Name = "����Ἱ�")]
        public string DeptName { get; set; }
    }
}
