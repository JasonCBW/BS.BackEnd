using System;
using System.ComponentModel.DataAnnotations.Schema; 

namespace Entity.Base
{
    [Table("Product")]
    public class Product
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SmallImageUrlList { get; set; }

        public string BigImageUrlList { get; set; }

        public string ProductClassTitle { get; set; }

        public int ProductClassID { get; set; }

        public string FileName { get; set; }

        public string Tag { get; set; }

        public string SeoTitle { get; set; }

        public string SeoKeyWords { get; set; }

        public string SeoDescription { get; set; }

        public string Remark { get; set; }

        public int Hits { get; set; }

        public int Sort { get; set; }

        public int Status { get; set; }

        public DateTime? StartTime { get; set; }

        public decimal Price { get; set; }

    }
}
