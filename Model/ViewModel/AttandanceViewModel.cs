using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Model.ViewModel
{
    public class AttandanceViewModel
    {
        public int UserID { get; set; }
        public string ClientName { get; set; }
        public int CongDung { get; set; }
        public int CongThem { get; set; }
        public int CongTre { get; set; }
        public int CongPhep { get; set; }

        public string CurrentMonth { get; set; }
        public IEnumerable<ListAttandanceModel> ListAttan { get; set; }

        public SelectList DdlMonth { get; set;}


    }

    public class ListAttandanceModel
    {
        public string Day { get; set; }
        public string CheckIn { get; set; }
        public string TimeCheckIn { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public string Color { get; set; }

    }


}
