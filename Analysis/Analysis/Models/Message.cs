using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Analysis.Models
{
    public class Message : ViewModels.BaseViewModel
    {
        private static bool _IsVisibleStared;
        private static bool _IsVisibleStar;
        private ImageSource _starImageSource;

        public int ID { get; set; }
        public string MessageBody { get; set; }
        public DateTime DateTime { get; set; }
        public int OrganDetailID { get; set; }
        public bool IsFavourited { get; set; }
        public Message()
        {
            IsVisibleStar = new bool();
            IsVisibleStared = new bool();
            _IsVisibleStar = new bool();
            _IsVisibleStared = new bool();


        }

        public ImageSource StarImageSource
        {
            get { return _starImageSource; }
            set { SetProperty(ref _starImageSource, value); }
        }

        public bool IsVisibleStared
        {

            get
            {
                if (IsFavourited)
                    _IsVisibleStared = true;
                else _IsVisibleStared = false;
                return _IsVisibleStared;
            }
            set
            {
                SetProperty(ref _IsVisibleStared, value);
            }
        }

        public bool IsVisibleStar
        {

            get
            {
                if (!IsFavourited)
                    _IsVisibleStar = true;
                else _IsVisibleStar = false;
                return _IsVisibleStar;
            }
            set
            {
                SetProperty(ref _IsVisibleStar, value);
            }
        }

    }
}
