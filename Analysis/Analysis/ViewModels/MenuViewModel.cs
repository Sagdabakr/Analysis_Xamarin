using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Analysis.ViewModels
{
    public class MenuItems
    {
        public string PageName { get; set; }
        public string PageIcon { get; set; }
        public int ID { get; set; }
    }
    public class MenuViewModel
    {
        public ObservableCollection<MenuItems> MenuItems { get; set; }

        public MenuViewModel()
        {
            MenuItems = new ObservableCollection<MenuItems>();
        }

        public ObservableCollection<MenuItems> GetMenuItems()
        {
            var menuItems = new ObservableCollection<MenuItems>
                {
                    new MenuItems{ID=0 , PageName="حـسـابـي" , PageIcon ="menuUser.png"},                    
                    new MenuItems{ID=1 , PageName="إضـافـه حـسـاب" , PageIcon ="menuAdd.png"},                    
                    new MenuItems{ID=2 , PageName="تـعديـل الأخـتـبار" , PageIcon ="menuEdit.png"},                    
                    new MenuItems{ID=3 ,PageName="الأشـعـارات" , PageIcon ="menuRing.png"},                    
                    new MenuItems{ID=4, PageName="تـسجـيل الدخول" , PageIcon ="menuLogout.png"}                                       
                };
            return menuItems;
        }
    }
}
