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
        private readonly IUserService _userRepository;

        private readonly ILogService _logRepository;

        public LoginController(IUserService loginService, ILogService logservice)
        {
            _userRepository = loginService;
            _logRepository = logservice;
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
            LogEntity logEntity = new LogEntity();
            logEntity.ID = Common.GuId();
            logEntity.F_ModuleName = "系统登录";
            logEntity.F_IPAddress = Net.Ip;
            logEntity.F_IPAddressName= Net.GetLocation(logEntity.F_IPAddress);
            logEntity.F_Type = DbLogType.Login.ToString();
            try
            {
                if (Session["bs_session_verifycode"].IsEmpty() || Md5.md5(code.ToLower()) != Session["bs_session_verifycode"].ToString())
                {
                    throw new Exception("验证码错误，请重新输入");
                }

                UserEntity user = _userRepository.CheckLogin(username, password);

                if (user != null)
                {
                    logEntity.F_Account = user.F_Account;
                    logEntity.F_NickName = user.F_NickName;
                    logEntity.F_Result = true;
                    logEntity.F_Description = "登录成功";
                    _logRepository.Add(logEntity);

                }
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
            }
            catch (Exception ex)
            {
                logEntity.F_Account = username;
                logEntity.F_NickName = username;
                logEntity.F_Result = false;
                logEntity.F_Description = "登录失败，" + ex.Message;
                _logRepository.Add(logEntity);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }
    }
}