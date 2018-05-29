﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastProject.Model
{
    [Serializable]
    public class UserInfo
    {
        public int? ID { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string Email { get; set; }
        public DateTime RegTime { get; set; }
    }
}
