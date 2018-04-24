using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CZBK.ItcastProject.Model;
using CZBK.ItcastProject.DAL;

namespace CZBK.ItcastProject.BLL
{
    public class ImageInfoService
    {
        ImageInfoDal imageInfoDal = new ImageInfoDal();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="imageInfo"></param>
        /// <returns></returns>
        public bool create(ImageInfo imageInfo)
        {
            return imageInfoDal.CreateImageInfo(imageInfo) > 0;
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <returns></returns>
        public List<ImageInfo> read()
        {
            return imageInfoDal.GetImageInfo();
        }

        /// <summary>
        /// Read single
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ImageInfo read(int id)
        {
            return imageInfoDal.GetImageInfo(id);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="imageInfo"></param>
        /// <returns></returns>
        public bool Update(ImageInfo imageInfo)
        {
            return imageInfoDal.UpdateImageInfo(imageInfo) > 0;
        }

        public bool Delete(ImageInfo imageInfo)
        {
            return imageInfoDal.DeleteImageinfo(imageInfo) > 0;
        }
    }
}
