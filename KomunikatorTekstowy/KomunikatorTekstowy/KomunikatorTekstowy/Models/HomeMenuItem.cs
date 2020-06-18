using System;
using System.Collections.Generic;
using System.Text;

namespace KomunikatorTekstowy.Models
{
    public enum MenuItemType
    {
        UserList,
        MessageUserList,
        MyData,
        Logout
    }
    class HomeMenuItem
    {
        public MenuItemType id { get; set; }
        public string Title { get; set; }
    }
}
