using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleEnumerator
{
    enum ItemType
    {
        Shirt, Trouser, Jean, Blazer
    }

    enum ItemSize
    {
        Small, Medium, Large
    }

    class Inventory
    {
        Dictionary<Item, int> items;

        public IComparer<Item> InventoryComparer
        {
            set;
            private get;
        }
        
        public Inventory()
        {
            if (InventoryComparer == null)
                InventoryComparer = new TypeWiseComparer();
            items = new Dictionary<Item, int>();
        }
        public void add(Item item, int units)
        {
            if (items.ContainsKey(item))
                items[item] = units;
            else
                items.Add(item, units);
        }

        public void add(ItemType type, ItemSize size, int units)
        {
            Item i = new Item(type, size);
            add(i, units);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in items)
            {
                sb.AppendLine(String.Format("{0} contains {1} units", item.Key.ToString(), item.Value));
            }
            return sb.ToString();
            
        }

        private InventoryEnumerator EnumerateAs()
        {
            return new InventoryEnumerator(items);
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)EnumerateAs();
        }
    }

    class TypeWiseComparer : IComparer<Item>
    {
 
    }

    class InventoryEnumerator : IEnumerator<KeyValuePair<Item, int>>
    {
        Dictionary<Item, int> _items;
        private KeyValuePair<Item, int> _current;
        public IComparer<Item> InventoryComparer { get; set; }

        public InventoryEnumerator(Dictionary<Item, int> items)
            : this(items, new TypeWiseComparer())
        {
            
        }

        public InventoryEnumerator(Dictionary<Item, int> items, IComparer<Item> comparer)
        {
            _items = items;
            InventoryComparer = comparer;
        }


        public KeyValuePair<Item, int> Current
        {
            get { return _current; }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        object IEnumerator.Current
        {
            get { return _current; }
        }

        public bool MoveNext()
        {
            bool moved = false;
            KeyValuePair<Item, int> NGE;
            foreach (var i in _items)
            {
                if (Current.Key.CompareTo(i.Key) < 0 && NGE.Key.CompareTo(i.Key) < 0)
                {
                    NGE = i;
                    moved = true;
                }
            }
            if (moved)
                _current = NGE;

            return moved;
        }

        public void Reset()
        {
            KeyValuePair<Item, int> first = _items.First();
            foreach (var i in _items)
            {
                if (first.Key.CompareTo(i.Key) < 0)
                {
                    first = i;
                }
            }
            _current = first;
        }
    }



}
