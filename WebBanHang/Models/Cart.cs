using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class TinItem
    {
        public TINTUC Tintuc { get; set; }
    }
    public class Cart
    {
         private List<TinItem> _items;
        public Cart()
        {
            _items = new List<TinItem>();
        }
        public List<TinItem> Items { get { return _items; } }
        public void AddItem(TINTUC p)
        {
            TinItem item = Items.Find(x => x.Tintuc.ID_TinTuc == p.ID_TinTuc);
            if (item == null)
            {
                Items.Add(new TinItem { Tintuc = p });
            }
        }
        public void UpdateItem(TINTUC p)
        {
            TinItem item = Items.Find(x => x.Tintuc.ID_TinTuc == p.ID_TinTuc);
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        public void DeleteItem(TINTUC p)
        {
            TinItem item = Items.Find(x => x.Tintuc.ID_TinTuc == p.ID_TinTuc);
            if (item != null)
            {
                Items.Remove(item);
            }
        }
    }
}