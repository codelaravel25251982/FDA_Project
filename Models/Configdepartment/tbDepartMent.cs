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
        [Display(Name = "กลุ่มงานประเภทบริการ")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบด้วยค่ะ")]
        public int DeptID { get; set; }

        [StringLength(100)]
        [Display(Name = "ชื่อแผนก")]
        public string DeptName { get; set; }
    }
}
