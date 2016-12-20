using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using BS.RepositoryIService;
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
        public HttpResponseMessage GetPicByParentID(int parentId)
        {
            HttpResponseMessage result = null;

            if (parentId != 0)
            {
                string str = JsonConvert.SerializeObject(_pictureRepository.GetPicByParentID(parentId));

                result = BS.Common.Converter.StringToJson(str);
            }
            return result;
        }

        /// <summary>
        /// 根据ID编号删除单个
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        [Route("api/PictureApi/DeleteByID")]
        [HttpDelete]
        public bool DeleteByID(int id)
        {
            if (id != 0)
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
