using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BS.RepositoryIService;
using Entity.Base;
using Newtonsoft.Json;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace BS.BackEnd.Areas.WebAdmin.Controllers
{
    public class NewsApiController : ApiController
    {
        private readonly INewsService _news;

        public NewsApiController(INewsService newsservices)
        {
            this._news = newsservices;
        }

        /// <summary>
        /// 获取全部新闻
        /// </summary>
        /// <returns></returns>
        [Route("api/NewsApi/GetAll")]
        public string GetAll()
        {
            var results = JsonConvert.SerializeObject(_news.GetList());

            return results;
        }

        /// <summary>
        /// 根据页码获取新闻
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        [Route("api/NewsApi/GetNewsByPage")]
        public string GetNewsByPage(int pageIndex)
        {
            int count;

            var results = "{ \"Rows\":";

            int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);

            var list = _news.FindPageList(p => p.ID != 0, p => p.Sort != 0, pageIndex, pageSize, out count);

            int totalPages = Convert.ToInt32(Math.Ceiling((double)count / (double)pageSize));

            results += JsonConvert.SerializeObject(list);

            results += ",\"CurrentPage\":" + pageIndex.ToString();

            results += ",\"PageCount\":" + totalPages.ToString() + "}";

            return results;
        }

        /// <summary>
        /// 根据ID编号删除单个
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        [Route("api/NewsApi/DeleteNews")]
        [HttpDelete]
        public bool DeleteNews(int id)
        {
            if (id != 0)
            {
                var news = _news.FirstOrDefault(id);
                if (news != null)
                    _news.Delete(news);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据ID数组进行批量删除
        /// </summary>
        /// <param name="idlist">ID数组</param>
        /// <returns></returns>
        [Route("api/NewsApi/DeleteByIDList")]
        [HttpDelete]
        public bool DeleteByIDList(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                int[] intArray = BS.Common.Converter.StringToIntArry(ids);

                if (_news.Delete(p => intArray.Contains(p.ID)) > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
