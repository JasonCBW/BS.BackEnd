using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Base
{
    [Table("News")]
    public class News : BaseEntity
    {
        [DisplayName("标题")]
        public string Title { get; set; }

        [DisplayName("作者")]
        public string Author { get; set; }

        [DisplayName("来源")]
        public string Source { get; set; }

        [DisplayName("内容")]
        public string Content { get; set; }

        [DisplayName("推荐")]
        public bool IsElite { get; set; }

        [DisplayName("选中")]
        public bool Selected { get; set; }

        [DisplayName("小图")]
        public string SmallImageUrlList { get; set; }

        [DisplayName("大图")]
        public string BigImageUrlList { get; set; }

        [DisplayName("所属分类")]
        public int NewsClassID { get; set; }

        [DisplayName("点击数")]
        public int Hits { get; set; }

        [DisplayName("排序")]
        public int Sort { get; set; }

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
