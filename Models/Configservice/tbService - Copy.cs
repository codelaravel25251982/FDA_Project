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
//        [Required(ErrorMessage = "��سҡ�͡���������ú���¤��")]
//        [Display(Name = "���ͻ�������ԡ��")]
//        public string ServiveName { get; set; }

//        [StringLength(2)]
//        [Required(ErrorMessage = "��سҡ�͡���������ú���¤��")]
//        [Display(Name = "�ѡ�ù�˹��")]
//        [RegularExpression(@"A-Z", ErrorMessage = "��سҡ�͡���������١��ͧ���¤��(A-Z)")]
//        public string Prefix { get; set; }

//        [Required(ErrorMessage = "��سҡ�͡���������ú���¤��")]
//        [DefaultValue(1)]
//        [Display(Name = "�ӹǹ�ѵä�Ƿ������")]
//        public byte? CCopy { get; set; }

    
//        [DefaultValue(10)]
//        public short? ExpWait { get; set; }

//        [StringLength(1)]

//        public string Announce { get; set; }

//        [StringLength(4)]
//        [Display(Name = "�Ţ��Ƿ���������")]
//        [Required(ErrorMessage = "��سҡ�͡���������ú���¤��")]
//        public string StartQ { get; set; }

//        [StringLength(4)]
//        [Display(Name = "�Ţ����ش����")]
//        [Required(ErrorMessage = "��سҡ�͡���������ú���¤��")]
//        public string EndQ { get; set; }

//        [StringLength(4)]
//        [Display(Name = "�Ţ�������ش���١���¡�")]
//        [Required(ErrorMessage = "��سҡ�͡���������ú���¤��")]
//        public string LastQ { get; set; }

//        [StringLength(8)]
//        [Display(Name = "�ѹ���Ѩ�غѹ")]
//        [Required(ErrorMessage = "��سҡ�͡���������ú���¤��")]
//        public string QDate { get; set; }

//        [StringLength(150)]
//        [Display(Name = "��ͤ������ѵä�Ǫش��� 1")]
//        [Required(ErrorMessage = "��سҡ�͡���������ú���¤��")]
//        public string Remark { get; set; }

//        [StringLength(150)]
//        [Display(Name = "��ͤ������ѵä�Ǫش��� 2")]
//        [Required(ErrorMessage = "��سҡ�͡���������ú���¤��")]
//        public string Remark1 { get; set; }

//        [StringLength(1)]
//        [Display(Name = "��⾧")]
//        [DefaultValue("L")]
//        [Required(ErrorMessage = "��سҡ�͡���������ú���¤�� �����⾧��ҧ��������������ѡ�� 'L' �����⾧��ҹ����������� 'R'")]
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

//        [Display(Name = "������ҹ��������ԡ��")]
//        [Required(ErrorMessage = "��سҡ�͡���������ú���¤��")]
//        public int? DeptID { get; set; }

//        [StringLength(150)]
//        [Display(Name = "��������ͧ��������ԡ��")]
//        [Required(ErrorMessage = "��سҡ�͡���������ú���¤��")]
//        public string ServiceFullName { get; set; }
//    }
//}
