using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Base
{
    [Table("Sys_UserLogOn")]
    public class UserLogOnEntity
    {
        public string F_Id { get; set; }
        public string F_UserId { get; set; } 
        public DateTime? F_AllowStartTime { get; set; }
        public DateTime? F_AllowEndTime { get; set; }
        public DateTime? F_LockStartDate { get; set; }
        public DateTime? F_LockEndDate { get; set; }
        
    }
}
