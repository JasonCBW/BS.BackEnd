using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Base
{
    [Table("Cases")]
    public class Cases : BaseEntity
    {
        public string Title { get; set; }
        public int IsHot { get; set; }
        public int IsElite { get; set; }
        public string SmallImageUrlList { get; set; }
        public string BigImageUrlList { get; set; }
        public string CasesClassTitle { get; set; }
        public int CasesClassID { get; set; }
        public decimal Price { get; set; }
        public string FileName { get; set; }
        public int Hits { get; set; }
        public string Tag { get; set; }
        public int Sort { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyWords { get; set; }
        public string SeoDescription { get; set; }
        public string Content { get; set; }
        public string Remark { get; set; }
    }
}
