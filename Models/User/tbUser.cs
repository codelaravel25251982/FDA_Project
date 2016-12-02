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
        [Display(Name = "ชื่อผู้ใช้งาน")]
        //[Required(ErrorMessage = "กรุณากรอกข้อมูลด้วยครับ")]
        public string UserName { get; set; }

        [StringLength(3,ErrorMessage = "กรุณากรอกข้องมูลไม่เกิน 3 ตัวอักษรค่ะ")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูลด้วยครับ")]
        [Display(Name = "ชื่อในการเข้าโปรแกรม")]
        public string LoginID { get; set; }

        [StringLength(3, ErrorMessage = "กรุณากรอกข้องมูลไม่เกิน 3 ตัวอักษรค่ะ")]
        [Required(ErrorMessage = "กรุณากรอกข้อมูลด้วยครับ")]
        [Display(Name = "รหัสในการเข้าโปรแกรม")]
        public string PassWord { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "กรุณากรอกข้อมูลด้วยครับ")]
        [Display(Name = "ชื่อ")]
        public string Name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "กรุณากรอกข้อมูลด้วยครับ")]
        [Display(Name = "นามสกุล")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "กรุณากรอกข้อมูลด้วยครับ")]
        [Display(Name = "ระดับในการเข้าถึงข้อมูล")]
        public int? authtype { get; set; }
    }
}
