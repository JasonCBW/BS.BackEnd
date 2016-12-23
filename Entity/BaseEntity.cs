using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Base
{
    public class BaseEntity
    {
        [DisplayName("编号")]
        public string ID { get; set; }

        [DisplayName("状态")]
        public bool Status { get; set; }

        [DisplayName("开始时间")]
        public DateTime CreateDate { get; set; }

        [DisplayName("修改时间")]
        public DateTime ModifyDate { get; set; }
    }
}
