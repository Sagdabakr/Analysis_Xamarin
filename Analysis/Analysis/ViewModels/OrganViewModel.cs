using Analysis.Models;
using Analysis.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Analysis.ViewModels
{
    public class OrganViewModel : BaseViewModel
    {
        public ObservableCollection<Organ>  Organs
        {
            get { return _organs; }
            set { SetProperty(ref _organs, value); }
        }

        private ObservableCollection<Organ> _organs;

        public OrganViewModel()
        {
            Organs = new ObservableCollection<Organ>();
            _organs = new ObservableCollection<Organ>();
        }
        public async Task<ObservableCollection<Organ>> GetOrgan(int id)
        {
            OrganService organService = new OrganService();
            var Organs =await organService.GetOrgan(id);
            return Organs;
        }
    }
}
