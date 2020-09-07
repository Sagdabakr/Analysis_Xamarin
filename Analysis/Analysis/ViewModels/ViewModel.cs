using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Analysis.ViewModels
{
    public class Organs
    {
        public int OrganID { get; set; }
        public string OrganName { get; set; }
        public string OrganIcon { get; set; }

        //public string OrganIcon { get; set; }
    }
    public class ViewModel
    {      
        public ObservableCollection<Organs> OrgansList { get; set; }
        

        public ViewModel()
        {
            OrgansList = new ObservableCollection<Organs>();
        }

        public ObservableCollection<Organs> GetOrgans()
        {
            var organsList = new ObservableCollection<Organs>
                {
                    new Organs{OrganID=0 , OrganName ="Eyes" ,OrganIcon="eye.png" },
                    new Organs{OrganID=1 , OrganName ="Nose" ,OrganIcon="nose.png"},
                    new Organs{OrganID=2 , OrganName ="Hands" ,OrganIcon="hand.png"},
                    new Organs{OrganID=3 , OrganName ="Ears" ,OrganIcon="ear.png"},
                    new Organs{OrganID=4 , OrganName ="Hair" ,OrganIcon="hair.png"},
                    new Organs{OrganID=5 , OrganName ="Eyebrows" ,OrganIcon="eyebrow.png"},
                    new Organs{OrganID=6 , OrganName ="Chin" ,OrganIcon="chin.png"},
                    new Organs{OrganID=7 , OrganName ="Lips" ,OrganIcon="lips.png"},                    
                };
            return organsList;
        }
    }
}
