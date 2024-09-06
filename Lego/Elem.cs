using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lego
{
    internal class Elem
    {
        string itemID;
        string itemName;
        string categoryName;
        string colorName;
        int qty;

        public Elem(string itemID, string itemName, string categoryName, string colorName, int qty)
        {
            this.itemID = itemID;
            this.itemName = itemName;
            this.categoryName = categoryName;
            this.colorName = colorName;
            this.qty = qty;
        }

        public string ItemID { get => itemID; }
        public string ItemName { get => itemName; }
        public string CategoryName { get => categoryName; }
        public string ColorName { get => colorName; }
        public int Qty { get => qty; }
    }
}
