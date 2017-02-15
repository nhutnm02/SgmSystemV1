using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SgmSystemV1.Common
{
    [Serializable]
    public class UserLogin
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string ComName { get; set; }
        public bool IsLeader { get; set; }
    }


}