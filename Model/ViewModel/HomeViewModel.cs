using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class HomeViewModel
    {
        public string ComNameOfUser { get; set; }
        public string NameOfUser { get; set; }
        public string IdOfUser { get; set; }
        public bool IsHideButtonByComName { get; set; }

        public IEnumerable<UserEventListHomeViewModel> ListUserForHome { get; set; }
    }
}
