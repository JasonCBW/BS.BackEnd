using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using BS.RepositoryIService;
using BS.RepositoryDAL;
using Entity.Base;
using Newtonsoft.Json; 

namespace BS.BackEnd.Areas.WebAdmin.Api
{
    public class PictureApiController : ApiController
    {
        private readonly IPictureService _pictureRepository;

        public PictureApiController(IPictureService pictureRepository)
        {
            this._pictureRepository = pictureRepository;
        }

        [Route("api/PictureApi/GetPicByParentID")]
        public HttpResponseMessage GetPicByParentID(string parentId)
        {
            HttpResponseMessage result = null;

            if (parentId != "")
            {
                string str = JsonConvert.SerializeObject(_pictureRepository.GetPicByParentID(parentId));

                result = BS.Code.Converter.StringToJson(str);
            }

            //var db = new DBContext();

            //string strSql = string.Format(@"select * from News where id!= 0"); 

            //var list = db.Database.SqlQuery<News>(strSql).ToList<News>();

            return result;
        }

        /// <summary>
        /// 根据ID编号删除单个
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        [Route("api/PictureApi/DeleteByID")]
        [HttpDelete]
        public bool DeleteByID(string id)
        {
            if (id != "")
            {
                var pic = _pictureRepository.FirstOrDefault(id);
                if (pic != null)
                    _pictureRepository.Delete(pic);
                return true;
            }
            return false;
        }
    }
}
