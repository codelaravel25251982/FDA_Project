//namespace BeyondThemes.BeyondAdmin.Models.Configservice
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;


//    [Table("tbService")]
//    public partial class tbService
//    {
//        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public byte ServID { get; set; }

//        [StringLength(100)]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบด้วยค่ะ")]
//        [Display(Name = "ชื่อประเภทบริการ")]
//        public string ServiveName { get; set; }

//        [StringLength(2)]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบด้วยค่ะ")]
//        [Display(Name = "อักษรนำหน้า")]
//        [RegularExpression(@"A-Z", ErrorMessage = "กรุณากรอกข้อมูลให้ถูกต้องด้วยค่ะ(A-Z)")]
//        public string Prefix { get; set; }

//        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบด้วยค่ะ")]
//        [DefaultValue(1)]
//        [Display(Name = "จำนวนบัตรคิวที่พิมพ์")]
//        public byte? CCopy { get; set; }

    
//        [DefaultValue(10)]
//        public short? ExpWait { get; set; }

//        [StringLength(1)]

//        public string Announce { get; set; }

//        [StringLength(4)]
//        [Display(Name = "เลขคิวที่เริ่มต้น")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบด้วยค่ะ")]
//        public string StartQ { get; set; }

//        [StringLength(4)]
//        [Display(Name = "เลขคิวสุดท้าย")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบด้วยค่ะ")]
//        public string EndQ { get; set; }

//        [StringLength(4)]
//        [Display(Name = "เลขคิวล่าสุดที่ถูกเรียกไป")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบด้วยค่ะ")]
//        public string LastQ { get; set; }

//        [StringLength(8)]
//        [Display(Name = "วันที่ปัจจุบัน")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบด้วยค่ะ")]
//        public string QDate { get; set; }

//        [StringLength(150)]
//        [Display(Name = "ข้อความบนบัตรคิวชุดที่ 1")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบด้วยค่ะ")]
//        public string Remark { get; set; }

//        [StringLength(150)]
//        [Display(Name = "ข้อความบนบัตรคิวชุดที่ 2")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบด้วยค่ะ")]
//        public string Remark1 { get; set; }

//        [StringLength(1)]
//        [Display(Name = "ลำโพง")]
//        [DefaultValue("L")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบด้วยค่ะ ถ้าลำโพงข้างซ้ายให้พิมพ์ตัวอักศร 'L' และลำโพงด้านขวาให่้พิมพ์ 'R'")]
//        public string Speaker { get; set; }
//        [DefaultValue(0)]
//        public int? OverTime { get; set; }
//        [DefaultValue(6)]
//        public int? ProCS1 { get; set; }
//        [DefaultValue(0)]
//        public int? ProCS2 { get; set; }
//        [DefaultValue(0)]
//        public int? ProCS3 { get; set; }
//        [DefaultValue(0)]
//        public int? ProCS4 { get; set; }
//        [DefaultValue(0)]
//        public int? QLimit { get; set; }
//        [DefaultValue(0)]
//        public int? QLimitTime { get; set; }
//        [DefaultValue(0)]
//        public int? ProCS5 { get; set; }

//        [Display(Name = "กลุ่มงานประเภทบริการ")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบด้วยค่ะ")]
//        public int? DeptID { get; set; }

//        [StringLength(150)]
//        [Display(Name = "ชื่อเต็มของประเภทบริการ")]
//        [Required(ErrorMessage = "กรุณากรอกข้อมูลให้ครบด้วยค่ะ")]
//        public string ServiceFullName { get; set; }
//    }
//}
