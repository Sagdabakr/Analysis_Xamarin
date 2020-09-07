using System;
using System.Collections.Generic;
using System.Text;

namespace Analysis.Models
{
    public class UserChoice
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        public bool IsFav { get; set; }

        public OrganDetail organDetail { get; set; }

        public int OrganDetailID { get; set; }
    }
}
