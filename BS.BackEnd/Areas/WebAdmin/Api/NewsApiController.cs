﻿using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using BS.RepositoryIService;
using Entity.Base;
using Newtonsoft.Json;

namespace BS.BackEnd.Areas.WebAdmin.Api
{
    public class NewsApiController : ApiController
    {
        private readonly INewsService _news;

        public NewsApiController(INewsService newsservices)
        {
            this._news = newsservices;
        }

        /// <summary>
        /// 根据ID获取新闻详细
        /// </summary>
        /// <returns></returns>
        [Route("api/NewsApi/GetByID")]
        public HttpResponseMessage GetByID(string id)
        {
            HttpResponseMessage result = null;

            if (id != "")
            {
                string str = JsonConvert.SerializeObject(_news.FirstOrDefault(id));

                result = BS.Code.Converter.StringToJson(str);
            }
            return result;
        }

        /// <summary>
        /// 获取全部信息（分页方式为Client用这个）
        /// </summary>
        /// <returns></returns>
        [Route("api/NewsApi/GetAll")]
        public HttpResponseMessage GetAll()
        {
            //数据列表
            var list = _news.GetList();

            //待返回的JSON数据
            HttpResponseMessage result = null;

            if (list != null)
            {
                result = BS.Code.Converter.StringToJson(JsonConvert.SerializeObject(list));
            }
            return result;
        }

        /// <summary>
        /// 根据页码获取新闻（分页方式为server时用这个）
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <returns></returns>
        [Route("api/NewsApi/GetNewsByPage")]
        public HttpResponseMessage GetNewsByPage(int limit, int offset)
        {
            HttpResponseMessage result = null;

            var list = _news.GetList();

            if (list != null)
            {
                var totalPages = list.Count();

                var results = "{ \"total\":" + totalPages;

                results += ",\"rows\":" + JsonConvert.SerializeObject(list.Skip(offset).Take(limit).ToList()) + "}";

                result = BS.Code.Converter.StringToJson(results);
            }
            return result;
        }

        /// <summary>
        /// 根据ID编号删除单个
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        [Route("api/NewsApi/DeleteNews")]
        [HttpDelete]
        public bool DeleteNews(string id)
        {
            if (id != "")
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
                int[] intArray = BS.Code.Converter.StringToIntArry(ids);

                string[] strArray = ids.Split(',');

                if (_news.Delete(p => strArray.Contains(p.ID)) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <param name="newsEntity"></param>
        /// <returns></returns>
        public bool AddNews(News newsEntity)
        {
            newsEntity.CreateDate = DateTime.Now;
            _news.Add(newsEntity);
            return false;
        }
    }
}
