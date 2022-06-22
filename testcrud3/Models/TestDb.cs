using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testcrud3.Models
{
    public partial class TestDb
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte SystemInformationId { get; set; }
        [Display(Name = "版本號")]
        public string DatabaseVersion { get; set; } = null!;
        [Display(Name = "版本時間")]
        public DateTime VersionDate { get; set; }
        [Display(Name = "異動時間")]
        public DateTime ModifiedDate { get; set; }
    }
}
