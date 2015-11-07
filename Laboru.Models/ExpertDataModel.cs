using Laboru.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace Laboru.Models
{
    public partial class ExpertDataModel : Plenum.Models.BaseDataModel
    {
        public int? ID { get; set; }
        public string Name { get; set; }
		public string  LastName { get; set; }
		public string  Mobile { get; set; }
		public string  Bio { get; set; }
						
    }    
}

