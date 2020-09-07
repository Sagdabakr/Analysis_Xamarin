using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Analysis.Models
{
     public class Organ
    {
        
        [PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<OrganDetail> OrganDetails { get; set; }

    }
}
