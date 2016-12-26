using System; 
using System.ComponentModel.DataAnnotations.Schema; 

namespace Entity.Base
{
    [Table("Sys_Log")]
    public class LogEntity
    {
        //private ILog logger;
        //public LogEntity(ILog log)
        //{
        //    this.logger = log;
        //}
        //public void Debug(object message)
        //{
        //    this.logger.Debug(message);
        //}
        //public void Error(object message)
        //{
        //    this.logger.Error(message);
        //}
        //public void Info(object message)
        //{
        //    this.logger.Info(message);
        //}
        //public void Warn(object message)
        //{
        //    this.logger.Warn(message);
        //}
        public string ID { get; set; }
        public DateTime? F_Date { get; set; }
        public string F_Account { get; set; }
        public string F_NickName { get; set; }
        public string F_Type { get; set; }
        public string F_IPAddress { get; set; }
        public string F_IPAddressName { get; set; }
        public string F_ModuleId { get; set; }
        public string F_ModuleName { get; set; }
        public bool? F_Result { get; set; }
        public string F_Description { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public string F_CreatorUserId { get; set; }
    }
}
