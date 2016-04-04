using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboru.Models
{
    public class SkillDataModel
    {
        public int? ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
