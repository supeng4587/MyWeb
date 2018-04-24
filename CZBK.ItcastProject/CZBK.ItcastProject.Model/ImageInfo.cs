using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastProject.Model
{
    public class ImageInfo
    {
        public int ID { get; set; }
        public string OriginalName { get; set; }
        public string Path { get; set; }
        public string GuidName { get; set; }
        public string Extension { get; set; }
        public string ThumbName { get; set; }
        public string Size { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
