using System;
using System.Collections.Generic;
using System.Text;

namespace Analysis.Models
{
    public class OrganDetail
    {
        public int ID { get; set; }
        public string Shape { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int OrganID { get; set; }
        public int MessageID { get; set; }

        public List<UserChoice> UserChoices { get; set; }
    }
}
