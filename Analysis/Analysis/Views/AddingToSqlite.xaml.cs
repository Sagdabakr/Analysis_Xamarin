using Analysis.LocalServices;
using Analysis.Models;
using Analysis.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Analysis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddingToSqlite : ContentPage
    {
        HomeViewModel HomeViewModel;
       
        SQLiteAsyncConnection _connection;
      //  ObservableCollection<Organ> _organs;
      //  ObservableCollection<DescribeOrgan> organsDescription;
        public AddingToSqlite()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            HomeViewModel = new HomeViewModel();
          

            //   BindingContext = DescribeOrganViewModel.describeOrgans ;
          //  BindingContext = HomeViewModel;

        }

        protected override void OnAppearing()
        {
          /*  _organs = new ObservableCollection<Organ>(await _connection.Table<Organ>().ToListAsync());
            OrganListView.ItemsSource = _organs;*/
           //    organsDescription = new ObservableCollection<DescribeOrgan>(await _connection.Table<DescribeOrgan>().ToListAsync());
           //  OrganListView.ItemsSource = organsDescription;
           //  OrganListView.BindingContext = organsDescription;
           //   DescribeOrganViewModel.describeOrgans = await DescribeOrganViewModel.GetDescribeOrgans(1);
           //   BindingContext = DescribeOrganViewModel;
           /*  HomeViewModel.Organs =await HomeViewModel.GetOrgans(1);
              BindingContext = HomeViewModel;*/
        }
        private void SaveButton_Clicked(object sender, EventArgs e)
        {
             /* DescribeOrgan OrganDescription = new DescribeOrgan()
              {
                  ID = int.Parse(ID.Text),
                  OrganTableID = int.Parse(OrganTableID.Text),
                  Description = description.Text,
              };
              await _connection.CreateTableAsync<DescribeOrgan>();
              await _connection.InsertAsync(OrganDescription);*/
           /* Organ organ = new Organ();
            organ.ID = int.Parse(ID.Text);
            organ.OrganID = int.Parse(OragnID.Text);
            organ.OrganShape = OrganShape.Text;
            organ.ShapeImage = ShapeImage.Text;                     
             
             await _connection.CreateTableAsync<Organ>();
             await _connection.InsertAsync(organ);*/
         
        }
        }
    }
