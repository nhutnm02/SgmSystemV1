using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Helper
{
    public class Enums
    {
        public enum AlertStyle
        {
            Success,
            Warning,
            Danger,
            Info
        }
        public enum LoaiCong
        {
            CongTre = 0,
            CongDung = 1,
            CongThem = 2,
            CongPhep = 3,
            ChoDuyet = 4
        }

        public enum EventType
        {
            CongTac = 1,
            NghiPhep = 2
        }
    }
}
