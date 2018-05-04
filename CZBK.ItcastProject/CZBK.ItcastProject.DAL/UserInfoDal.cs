using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CZBK.ItcastProject.Model;
using CZBK.ItcastProject.Common;
using System.Data;
using System.Data.SqlClient;

namespace CZBK.ItcastProject.DAL
{
    public class UserInfoDal
    {
        /// <summary>
        /// 获取用户列表,通查
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetList()
        {
            string sql = "SELECT UserInfo.ID,UserInfo.UserName,UserInfo.UserPass,UserInfo.Email,UserInfo.RegTime FROM UserInfo ORDER BY ID DESC";
            DataTable dt = SqlHelper.GetDataTable(sql, CommandType.Text);
            List<UserInfo> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<UserInfo>();
                UserInfo userInfo = null;
                foreach (DataRow row in dt.Rows)
                {
                    userInfo = new UserInfo();
                    LoadEntity(userInfo, row);
                    list.Add(userInfo);
                }
            }
            return list;
        }
        /// <summary>
        /// 获取用户，按ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserInfo GetList(int id)
        {
            string sql = "SELECT UserInfo.ID,UserInfo.UserName,UserInfo.UserPass,UserInfo.Email,UserInfo.RegTime FROM UserInfo WHERE UserInfo.ID = @id ORDER BY ID DESC";
            sql = sql.Replace("@id", id.ToString());
            DataTable dt = SqlHelper.GetDataTable(sql, CommandType.Text);
            UserInfo userInfo = new UserInfo();
            if (dt.Rows.Count > 0)
            {
                userInfo.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                userInfo.UserName = dt.Rows[0]["UserName"] != DBNull.Value ? dt.Rows[0]["UserName"].ToString() : string.Empty;
                userInfo.UserPass = dt.Rows[0]["UserPass"] != DBNull.Value ? dt.Rows[0]["UserPass"].ToString() : string.Empty;
                userInfo.Email = dt.Rows[0]["Email"] != DBNull.Value ? dt.Rows[0]["Email"].ToString() : string.Empty;
                userInfo.RegTime = dt.Rows[0]["RegTime"] != DBNull.Value ? DateTime.Parse(dt.Rows[0]["RegTime"].ToString()) : DateTime.MinValue;
            }
            return userInfo;
        }

        /// <summary>
        /// 分页取指定范围内的数据
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<UserInfo> GetList(int startIndex, int endIndex)
        {
            string sql = "SELECT * FROM (SELECT  UserInfo.ID,UserInfo.UserName,UserInfo.UserPass,UserInfo.Email,UserInfo.RegTime,ROW_NUMBER() OVER(ORDER BY ID DESC) AS number FROM UserInfo) t WHERE t.number >= @startIndex AND t.number <=@endIndex ORDER BY t.number; ";

            SqlParameter[] ps = { new SqlParameter("@startIndex", SqlDbType.Int), new SqlParameter("@endIndex", SqlDbType.Int) };
            ps[0].Value = startIndex;
            ps[1].Value = endIndex;

            DataTable dt = SqlHelper.GetDataTable(sql, CommandType.Text, ps);
            List<UserInfo> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<UserInfo>();
                UserInfo userInfo = null;
                foreach (DataRow row in dt.Rows)
                {
                    userInfo = new UserInfo();
                    LoadEntity(userInfo, row);
                    list.Add(userInfo);
                }
            }
            return list;
        }

        public int CreatUserInfo(UserInfo userInfo)
        {
            string sql = "INSERT INTO UserInfo ( UserName, UserPass, Email, RegTime ) VALUES  (@UserName,@UserPass,@Email,@RegTime)";
            SqlParameter[] pars ={
                new SqlParameter("@UserName",SqlDbType.NVarChar,64),
                new SqlParameter("@UserPass",SqlDbType.NVarChar,64),
                new SqlParameter("@Email",SqlDbType.NVarChar,64),
                new SqlParameter("@RegTime",SqlDbType.DateTime)
            };
            pars[0].Value = userInfo.UserName;
            pars[1].Value = userInfo.UserPass;
            pars[2].Value = userInfo.Email;
            pars[3].Value = userInfo.RegTime;

            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }

        public int DeleteUserInfo(int id)
        {
            string sql = "DELETE FROM dbo.UserInfo WHERE ID = @id";
            SqlParameter par = new SqlParameter("@id", SqlDbType.Int);
            par.Value = id;
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, par);
        }

        public int UpdateUserInfo(UserInfo userInfo)
        {
            string sql = "UPDATE UserInfo SET UserName=@userName,UserPass=@userPass,Email=@email WHERE ID=@id";
            SqlParameter[] pars =
            {
                new SqlParameter("@id",SqlDbType.Int),
                new SqlParameter("@userName",SqlDbType.NVarChar,64),
                new SqlParameter("@userPass",SqlDbType.NVarChar,64),
                new SqlParameter("@email",SqlDbType.NVarChar,64)
            };
            pars[0].Value = userInfo.ID;
            pars[1].Value = userInfo.UserName;
            pars[2].Value = userInfo.UserPass;
            pars[3].Value = userInfo.Email;
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }

        public int GetRecordCount()
        {
            string sql = "SELECT COUNT(1) FROM UserInfo";
            int count;
            if(!int.TryParse(SqlHelper.ExecuteScalar(sql,CommandType.Text).ToString(),out count))
            {
                count = 1;
            }
            return count;
        }

        /// <summary>
        /// datarow内容加载到userinfo
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="row"></param>
        private void LoadEntity(UserInfo userInfo, DataRow row)
        {
            userInfo.ID = int.Parse(row["ID"].ToString());
            userInfo.UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : string.Empty;
            userInfo.UserPass = row["UserPass"] != DBNull.Value ? row["UserPass"].ToString() : string.Empty;
            userInfo.Email = row["Email"] != DBNull.Value ? row["Email"].ToString() : string.Empty;
            userInfo.RegTime = DateTime.Parse(row["RegTime"].ToString());
        }
    }
}
