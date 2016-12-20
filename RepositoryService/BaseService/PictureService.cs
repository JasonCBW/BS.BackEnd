using System.Linq;
using Entity.Base;
using BS.RepositoryIService;
using BS.RepositoryDAL;

namespace BS.RepositoryService
{
    public class PictureService : BaseService<Picture>, IPictureService
    {
        public PictureService() : base(RepositoryFactory.PictureRepository) { }

        //扩展方法的实现

        /// <summary>
        /// 获取全部的图片信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<Picture> GetList() { return CurrentRepository.FindList(pic => pic.ID != 0).OrderBy(n => n.ID); }

        /// <summary>
        /// 根据ID获取指定图片信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Picture FirstOrDefault(int ID)
        {
            return CurrentRepository.Find(t => t.ID == ID);
        }

        /// <summary>
        /// 根据ParentID获取指定分类下的图片信息
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        public IQueryable<Picture> GetPicByParentID(int ParentID)
        {
            return CurrentRepository.FindList(pic => pic.ParentID == ParentID).OrderBy(p => p.ID).ThenByDescending(p => p.Sort);
        }
    }
}
