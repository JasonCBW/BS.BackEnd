using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BS.RepositoryIService;
using Entity.Base;
using BS.Code;

namespace BS.BackEnd.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginRepository;

        public LoginController(ILoginService loginService)
        {
            _loginRepository = loginService;
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OutLogin()
        {
            //new LogApp().WriteDbLog(new LogEntity
            //{
            //    F_ModuleName = "系统登录",
            //    F_Type = DbLogType.Exit.ToString(),
            //    F_Account = OperatorProvider.Provider.GetCurrent().UserCode,
            //    F_NickName = OperatorProvider.Provider.GetCurrent().UserName,
            //    F_Result = true,
            //    F_Description = "安全退出系统",
            //});
            Session.Abandon();
            Session.Clear();
            OperatorProvider.Provider.RemoveCurrent();
            return RedirectToAction("Index", "Login");
        }

        /// <summary>
        /// 用户登录检查
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckLogin(string username, string password, string code)
        {

            //logEntity.F_ModuleName = "系统登录";
            //logEntity.F_Type = DbLogType.Login.ToString();
            try
            {
                if (Session["bs_session_verifycode"].IsEmpty() || Md5.md5(code.ToLower()) != Session["bs_session_verifycode"].ToString())
                {
                    throw new Exception("验证码错误，请重新输入");
                }

                User user = _loginRepository.FirstOrDefault(username, password);

                if (user != null)
                {
                    OperatorModel operatorModel = new OperatorModel();
                    operatorModel.UserId = user.ID;
                    //operatorModel.UserCode = user.LoginName;
                    operatorModel.UserName = user.LoginName;
                    operatorModel.LoginIPAddress = Net.Ip;
                    operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
                    operatorModel.LoginTime = DateTime.Now;
                    operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                    if (user.LoginName == "admin")
                    {
                        operatorModel.IsSystem = true;
                    }
                    else
                    {
                        operatorModel.IsSystem = false;
                    }
                    //OperatorProvider.Provider.AddCurrent(operatorModel);
                    //logEntity.F_Account = userEntity.F_Account;
                    //logEntity.F_NickName = userEntity.F_RealName;
                    //logEntity.F_Result = true;
                    //logEntity.F_Description = "登录成功";
                    //new LogApp().WriteDbLog(logEntity);

                }
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
            }
            catch (Exception ex)
            {
                //logEntity.F_Account = username;
                //logEntity.F_NickName = username;
                //logEntity.F_Result = false;
                //logEntity.F_Description = "登录失败，" + ex.Message;
                //new LogApp().WriteDbLog(logEntity);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        } 
    }
}