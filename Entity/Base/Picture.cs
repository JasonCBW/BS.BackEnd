using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Base
{
    [Table("Picture")]
    public class Picture : BaseEntity
    {
        public string Title { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public decimal FileSize { get; set; }

        public string ParentID { get; set; }

        public int Sort { get; set; } 

        public string Remark { get; set; }
    }
}
