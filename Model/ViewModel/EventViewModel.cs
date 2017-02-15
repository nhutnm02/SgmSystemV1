using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class EventViewModel
    {
        public long EventID { get; set; }

        [DisplayName("Lí Do")]
        [StringLength(200)]
        public string EventName { get; set; }

        [StringLength(200)]
        public string EventNote { get; set; }
    }


}
