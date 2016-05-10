using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleEnumerator
{
    class Item
    {
        private ItemType ItemType;
        private ItemSize ItemSize;

        public Item(ItemType type, ItemSize size)
        {
            ItemType = type;
            ItemSize = size;
        }

        public override string ToString() 
        {
            return String.Format("{0} {1}", ItemType, ItemSize);
        }

        internal int CompareTo(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
