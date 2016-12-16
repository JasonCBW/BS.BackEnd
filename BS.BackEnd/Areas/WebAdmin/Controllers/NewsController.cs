using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BS.RepositoryIService;
using Entity.Base;
using System.IO;
using System.Text;
using PagedList;
using System.Configuration;

namespace BS.BackEnd.Areas.WebAdmin.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _news;
        private readonly INewsClassService _newsclass;

        public NewsController(INewsService newsServices, INewsClassService newsclassServices)
        {
            _news = newsServices;
            _newsclass = newsclassServices;
        }

        // GET: WebAdmin/News
        public ActionResult Index(int? page = 1)
        {
            //获取新闻列表
            var newslist = _news.GetList();

            //第几页  
            int pageNumber = page ?? 1;

            //每页显示多少条  
            int pageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);

            //通过ToPagedList扩展方法进行分页  
            IPagedList<News> pagedList = newslist.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }

        /// <summary>
        /// 编辑视图
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            var news = _news.FirstOrDefault(Convert.ToInt32(id));
            if (news == null)
                return HttpNotFound();
            PopulateNewsClassDropDownList(news.NewsClassID);
            return View(news);
        }

        /// <summary>
        /// 编辑提交
        /// </summary>
        /// <param name="news">数据实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                _news.Update(news);
                return RedirectToAction("Index");
            }
            else
            {
                return View(news);
            }
        }

        /// <summary>
        /// 新增视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            PopulateNewsClassDropDownList();
            return View();
        }

        /// <summary>
        /// 新增提交
        /// </summary>
        /// <param name="news">数据实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(News news)
        {
            if (ModelState.IsValid)
            {
                news.CreateDate = DateTime.Now;
                _news.Add(news);
                return RedirectToAction("Index");
            }
            else
            {
                return View(news);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var news = _news.FirstOrDefault(id);
            if (news != null)
                _news.Delete(news);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 批量勾选删除
        /// </summary>
        /// <param name="idlist">主键ID数组</param>
        /// <returns></returns>
        public ActionResult DeleteByIDList(int[] idlist)
        {
            if (_news.Delete(p => idlist.Contains(p.ID)) > 0)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// 分类下拉框
        /// </summary>
        /// <param name="selectedNewsClass"></param>
        private void PopulateNewsClassDropDownList(object selectedNewsClass = null)
        {
            var selectedNewsClassTitle = _newsclass.GetTopList();
            ViewBag.NewsClassID = new SelectList(selectedNewsClassTitle, "ID", "Title", selectedNewsClass);
        }


        /// <summary>
        /// 图片上传,支持单个图片最大3MB
        /// </summary>
        /// <returns></returns> 
        [HttpPost]
        public JsonResult ImgUpload()
        {
            var ImageUrlList = "";
            for (var fileId = 0; fileId < Request.Files.Count; fileId++)
            {
                var curFile = Request.Files[fileId];

                if (curFile.ContentLength < 1) { continue; }
                else
                {
                    //文件名
                    var filenName = curFile.FileName;
                    //根据当前日期生成文件夹名称
                    var dir = DateTime.Now.ToString("yyyyMMdd").ToString();
                    //设定上传的文件路径
                    var path = Server.MapPath("~/Areas/WebAdmin/UploadFile/" + dir + "/");
                    try
                    {
                        if (!Directory.Exists(path))
                        {
                            //不存在则根据日期创建一个文件夹
                            Directory.CreateDirectory(path);

                            curFile.SaveAs(path + filenName);
                            ImageUrlList += path + filenName + "|";
                        }
                        else
                        {
                            //存在该目录则保存
                            curFile.SaveAs(path + filenName);
                            ImageUrlList += path + filenName + "|";
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new Exception("上传失败!", exception);
                    }
                }
            }
            return Json(ImageUrlList.TrimEnd('|'));
        }
    }
}