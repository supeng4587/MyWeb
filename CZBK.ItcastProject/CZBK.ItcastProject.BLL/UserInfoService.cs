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
    }
}
