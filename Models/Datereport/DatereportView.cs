namespace BeyondThemes.BeyondAdmin.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class DatereportView
    {
        [Key]
        public int Row { get; set; }

        public byte H_ServID { get; set; }

        [StringLength(150)]
        public string H_Date { get; set; }

        [StringLength(150)]
        public string ServiceFullName { get; set; }

        public int People { get; set; }
    }
}
