using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboru.Models
{
    public class ExpertSearchResultDataModel
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public int? Recommendations { get; set; }
        public int? FriendsRecommendations { get; set; }
    }
}
