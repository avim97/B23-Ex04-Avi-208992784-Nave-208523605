using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    internal class MenuItemCollection : IEnumerable<MenuItem>
    {
        public LinkedList<MenuItem> MenuItems { get; }
        public int Count => MenuItems.Count;

        public MenuItemCollection()
        {
            MenuItems = new LinkedList<MenuItem>();
        }
        public void Add(MenuItem i_SubMenuItemToAdd)
        {
            MenuItems.AddLast(i_SubMenuItemToAdd);
        }
        public void AddRange(params MenuItem[] i_SubMenuItemsToAdd)
        {
            foreach (var item in i_SubMenuItemsToAdd)
            {
                this.Add(item);
            }
        }
        public override string ToString()
        {
            StringBuilder itemsTitles = new StringBuilder();
            int itemIdx = 1;

            foreach (MenuItem item in MenuItems)
            {
                string lineToAdd = string.Format(@"
{0} -> {1}", itemIdx, item.Title);

                itemsTitles.Append(lineToAdd);
                itemIdx++;
            }

            return itemsTitles.ToString();
        }
        public IEnumerator<MenuItem> GetEnumerator()
        {
            return MenuItems.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
