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
    }
}
