using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Models
{
    public class InventoryList : IList<Inventory>, INotifyCollectionChanged
    {
        private readonly IList<Inventory> inventories;

        public InventoryList(IList<Inventory> myInventories) => inventories = myInventories;

        public Inventory this[int index]
        {
            get => inventories?[index];
            set
            {
                inventories[index] = value;
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, inventories[index]));
            }
        }

        public int Count => inventories.Count;

        public bool IsReadOnly => inventories.IsReadOnly;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private void OnCollectionChanged(NotifyCollectionChangedEventArgs args) => CollectionChanged?.Invoke(this, args);

        public void Add(Inventory item)
        {
            inventories.Add(item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

        public void Clear()
        {
            inventories.Clear();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(Inventory item) => inventories.Contains(item);

        public void CopyTo(Inventory[] array, int arrayIndex) => inventories.CopyTo(array, arrayIndex);

        public IEnumerator<Inventory> GetEnumerator() => inventories.GetEnumerator();

        public int IndexOf(Inventory item) => inventories.IndexOf(item);

        public void Insert(int index, Inventory item)
        {
            inventories.Insert(index, item);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));
        }

        public bool Remove(Inventory item)
        {
            bool removed = inventories.Remove(item);
            if (removed) OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
            return removed;
        }

        public void RemoveAt(int index)
        {
            Inventory itm = inventories[index];
            inventories.RemoveAt(index);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, itm, index));
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
