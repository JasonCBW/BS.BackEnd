using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BS.RepositoryIService;
using Entity.Base;
using System.IO;
using System.Text; 
using System.Configuration;

namespace BS.BackEnd.Areas.WebAdmin.Controllers
{
    public class NewsClassController : Controller
    {
        private readonly INewsClassService _newsclass;

        public NewsClassController(INewsClassService newsclassServices)
        {
            _newsclass = newsclassServices;
        }

        // GET: WebAdmin/NewsClass  
        public ActionResult Index()
        { 
            return View();
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
        public ActionResult Create(NewsClass newsClass)
        {
            if (ModelState.IsValid)
            {
                newsClass.CreateDate = DateTime.Now;
                _newsclass.Add(newsClass);
                return Content("添加成功");
            }
            else
            {
                PopulateNewsClassDropDownList();
                return View(newsClass);
            }
        }

        /// <summary>
        /// 编辑视图
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            var n = _newsclass.FirstOrDefault(Convert.ToInt32(id));
            if (n == null)
                return HttpNotFound();
            PopulateNewsClassDropDownList(n.ParentID);
            return View(n);
        }

        /// <summary>
        /// 编辑提交
        /// </summary>
        /// <param name="news">数据实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NewsClass newsClass)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(newsClass);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public ContentResult DeleteByID()
        {
            var result = "";
            try
            {
                if (Request["ID"] != null)
                {
                    var id = Convert.ToInt32(Request["ID"]);
                    var news = _newsclass.FirstOrDefault(id);
                    if (news != null)
                    {
                        _newsclass.Delete(news);
                        result = "数据已成功删除!";
                        return Content(result);
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Content(result);
        }

        /// <summary>
        /// 批量勾选删除
        /// </summary>
        /// <returns></returns>
        public ContentResult DeleteByIDList()
        {
            var result = "";
            try
            {
                var idList = Request["Ids"];
                if (!string.IsNullOrEmpty(idList))
                {
                    int[] ids = Array.ConvertAll<string, int>(idList.Split(','), s => int.Parse(s));
                    if (_newsclass.Delete(p => ids.Contains(p.ID)) > 0)
                    {
                        result = "数据已成功删除!";
                        return Content(result);
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Content(result);
        }

        /// <summary>
        /// 分类下拉框
        /// </summary>
        /// <param name="selectedNewsClass"></param>
        private void PopulateNewsClassDropDownList(object selectedNewsClass = null)
        {
            var selectedNewsClassTitle = _newsclass.GetTopList();
            ViewBag.ParentID = new SelectList(selectedNewsClassTitle, "ID", "Title", selectedNewsClass);
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
                            ImageUrlList += path + filenName;
                        }
                        else
                        {
                            //存在该目录则保存
                            curFile.SaveAs(path + filenName);
                            ImageUrlList = path + filenName;
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new Exception("上传失败!", exception);
                    }
                }
            }
            return Json(ImageUrlList);
        }
    }
}