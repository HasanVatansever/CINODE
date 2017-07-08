using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinode.Models
{
    public class Skill
    {
        public static List<Models.Skill> SkillList = new List<Models.Skill>();

        public string Name { get; set; }

        public int Rate { get; set; }

        public int Id { get; set; }
    }
}