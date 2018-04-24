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
    public class ImageInfoDal
    {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="imageInfo"></param>
        /// <returns></returns>
        public int CreateImageInfo(ImageInfo imageInfo)
        {
            string sql = @"INSERT INTO dbo.ImageInfo(OriginalName,Path,GuidName,Extension,ThumbName,Size,CreateTime) VALUES(@OriginalName,@Path,@GuidName,@Extension,@ThumbName,@Size,@CreateTime)";
            SqlParameter[] pars = {
                new SqlParameter("@OriginalName",SqlDbType.NVarChar,128),
                new SqlParameter("@Path",SqlDbType.NVarChar,128),
                new SqlParameter("@GuidName",SqlDbType.NVarChar,128),
                new SqlParameter("@Extension",SqlDbType.NVarChar,128),
                new SqlParameter("@ThumbName",SqlDbType.NVarChar,128),
                new SqlParameter("@Size",SqlDbType.NVarChar),
                new SqlParameter("@CreateTime",SqlDbType.DateTime)
            };
            pars[0].Value = imageInfo.OriginalName;
            pars[1].Value = imageInfo.Path;
            pars[2].Value = imageInfo.GuidName;
            pars[3].Value = imageInfo.Extension;
            pars[4].Value = imageInfo.ThumbName;
            pars[5].Value = imageInfo.Size;
            pars[6].Value = imageInfo.CreateTime;

            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }

        /// <summary>
        /// Read List
        /// </summary>
        /// <returns>List<ImageInfo></returns>
        public List<ImageInfo> GetImageInfo()
        {
            string sql = "SELECT ID,OriginalName,Path,GuidName,Extension,ThumbName,Size,CreateTime FROM dbo.ImageInfo ORDER BY ID";
            DataTable dt = SqlHelper.GetDataTable(sql, CommandType.Text);
            List<ImageInfo> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<ImageInfo>();
                ImageInfo imageInfo = null;
                foreach (DataRow item in dt.Rows)
                {
                    imageInfo = new ImageInfo();
                    LoadImageInfo(imageInfo, item);
                    list.Add(imageInfo);
                }
            }
            return list;

        }

        /// <summary>
        /// Read Single
        /// </summary>
        /// <param name="id">image primary id</param>
        /// <returns>imageInfo</returns>
        public ImageInfo GetImageInfo(int id)
        {
            string sql = "SELECT ID,OriginalName,Path,GuidName,Extension,Size,CreateTime,ThumbName FROM dbo.ImageInfo WHERE ID=@id";
            SqlParameter par = new SqlParameter("@id", SqlDbType.Int) ;
            par.Value = id;
            ImageInfo imageInfo = new ImageInfo();
            DataTable dt = SqlHelper.GetDataTable(sql, CommandType.Text, par);
            LoadImageInfo(imageInfo, dt.Rows[0]);
            return imageInfo;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="imageInfo"></param>
        /// <returns></returns>
        public int UpdateImageInfo(ImageInfo imageInfo)
        {
            List<string> listStr= null;
            string sql;
            if(imageInfo.ID > -1)
            {
                listStr = new List<string>();
                if (imageInfo.OriginalName != null)
                {
                    listStr.Add("OriginalName = @OriginalName, ");
                }
                if (imageInfo.Path != null)
                {
                    listStr.Add("Path = @Path, ");
                }
                if(imageInfo.GuidName != null)
                {
                    listStr.Add("GuidName = @GuidName, ");
                }
                if (imageInfo.Extension != null)
                {
                    listStr.Add("Extension = @Extension, ");
                }
                if (imageInfo.ThumbName != null)
                {
                    listStr.Add("ThumbName  = @ThumbName");
                }
                if (imageInfo.Size != null)
                {
                    listStr.Add("Size = @Size, ");
                }
                if (imageInfo.CreateTime != null)
                {
                    listStr.Add("CreateTime = @CreateTime, ");
                }
                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE ImageInfo SET ");
                sb.Append(listStr);
                sb.Append("1 =1 WHERE ID = @ID");
                sql = sb.ToString();


                SqlParameter[] pars =
                {
                    new SqlParameter("ID",SqlDbType.Int),
                    new SqlParameter("@OriginalName",SqlDbType.NVarChar,128),
                    new SqlParameter("@Path",SqlDbType.NVarChar,128),
                    new SqlParameter("@GuidName",SqlDbType.NVarChar,128),
                    new SqlParameter("@Extension",SqlDbType.NVarChar,128),
                    new SqlParameter("@ThumbName",SqlDbType.NVarChar,128),
                    new SqlParameter("@Size",SqlDbType.NVarChar,50),
                    new SqlParameter("@CreateTime",SqlDbType.DateTime)
                };

                pars[0].Value = imageInfo.ID;
                pars[1].Value = imageInfo.OriginalName;
                pars[2].Value = imageInfo.Path;
                pars[3].Value = imageInfo.GuidName;
                pars[4].Value = imageInfo.Extension;
                pars[5].Value = imageInfo.ThumbName;
                pars[6].Value = imageInfo.Size;
                pars[7].Value = imageInfo.CreateTime;

                return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="imageInfo"></param>
        /// <returns></returns>
        public int DeleteImageinfo(ImageInfo imageInfo)
        {
            string sql = "DELETE FROM ImageInfo WHERE ID = @ID";
            SqlParameter par = new SqlParameter("@ID", SqlDbType.Int);
            par.Value = imageInfo.ID;

            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, par);
        }

        /// <summary>
        /// Load imageInfo from datarow
        /// </summary>
        /// <param name="imageInfo"></param>
        /// <param name="item"></param>
        public void LoadImageInfo(ImageInfo imageInfo,DataRow item)
        {
            imageInfo.ID = int.Parse(item["ID"].ToString());
            imageInfo.OriginalName = item["OriginalName"] != DBNull.Value ? item["OriginalName"].ToString() : string.Empty;
            imageInfo.Path = item["Path"] != DBNull.Value ? item["Path"].ToString() : string.Empty;
            imageInfo.GuidName = item["GuidName"] != DBNull.Value ? item["GuidName"].ToString() : string.Empty;
            imageInfo.Extension = item["Extension"] != DBNull.Value ? item["Extension"].ToString() : string.Empty;
            imageInfo.ThumbName = item["ThumbName"] != DBNull.Value ? item["ThumbName"].ToString() : string.Empty;
            imageInfo.Size = item["Size"] != DBNull.Value ? item["Size"].ToString() : string.Empty;
            imageInfo.CreateTime = item["CreateTime"] != DBNull.Value ? DateTime.Parse(item["CreateTime"].ToString()) : DateTime.MinValue;
        }
    }
}
