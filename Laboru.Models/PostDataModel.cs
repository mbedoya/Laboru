using Plenum.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace Laboru.Models
{
    public partial class PostDataModel : BaseDataModel
    {   
		public string  Title { get; set; }
		public string  Description { get; set; }
		public int?  SkillPageID { get; set; }
		public int?  FromExpertID { get; set; }
		public DateTime  DateCreated { get; set; }
						
    }    
}

