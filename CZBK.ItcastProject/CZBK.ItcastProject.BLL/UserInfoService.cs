using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CZBK.ItcastProject.Model;
using CZBK.ItcastProject.DAL;

namespace CZBK.ItcastProject.BLL
{
    public class UserInfoService
    {
        DAL.UserInfoDal userInfoDal = new DAL.UserInfoDal();

        /// <summary>
        /// Read
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetList()
        {
            return userInfoDal.GetList();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示行数</param>
        /// <returns></returns>
        public List<UserInfo> GetList(int pageIndex, int pageSize)
        {
            int startIndex = (pageIndex - 1) * pageSize + 1;
            int endIndex = pageIndex * pageSize;

            return userInfoDal.GetList(startIndex, endIndex);
        }

        /// <summary>
        /// 按ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfo GetList(int id)
        {
            return userInfoDal.GetList(id);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public bool Create(UserInfo userInfo)
        {
            return userInfoDal.CreatUserInfo(userInfo) > 0;
        }

        public bool Update(UserInfo userInfo)
        {
            return userInfoDal.UpdateUserInfo(userInfo) > 0;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return userInfoDal.DeleteUserInfo(id) > 0;
        }

        public int GetPageCount(int pageSiza)
        {
            int recordCount = userInfoDal.GetRecordCount();
            int pageCount = Convert.ToInt32(Math.Ceiling((double)recordCount / pageSiza));
            return pageCount;
        }

        /// <summary>
        /// 完成用户登陆检验并返回用户和信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPass">用户密码</param>
        /// <param name="msg">返回信息 string</param>
        /// <param name="userInfo">返回用户 UserInfo</param>
        /// <returns></returns>
        public bool ValidateUserInfo(string userName, string userPass, out string msg, out UserInfo userInfo)
        {
            bool isSucess = false;
            userInfo = userInfoDal.GetList(userName);
            if (userInfo != null)
            {
                if (userInfo.UserPass == userPass)
                {
                    msg = "登陆成功。";
                    isSucess = true;
                }
                else
                {
                    msg = "用户名或密码错误。";
                }
            }
            else
            {
                msg = "无此用户。";
            }
            return isSucess;
        }
    }
}
