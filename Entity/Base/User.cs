using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Base
{
    [Table("News")]
    public class User : BaseEntity
    {
        public string LoginName { get; set; }

        public string LoginPassword { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string RoleList { get; set; }

        public string Remark { get; set; }
    }
}
