using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Base
{
    [Table("NewsClass")]
    public class NewsClass : BaseEntity
    {
        [Required]
        [DisplayName("标题")]
        public string Title { get; set; }

        [DisplayName("父类编号")]
        public int ParentID { get; set; }

        [DisplayName("图片路径")]
        public string ImageUrlList { get; set; }

        [DisplayName("排序")]
        public int Sort { get; set; }

        [DisplayName("有效标示")]
        public bool DataFlag { get; set; }

        [DisplayName("SEO标题")]
        public string SeoTitle { get; set; }

        [DisplayName("SEO关键词")]
        public string SeoKeyWords { get; set; }

        [DisplayName("SEO描述")]
        public string SeoDescription { get; set; }

        [DisplayName("备注")]
        public string Remark { get; set; }

    }
}
