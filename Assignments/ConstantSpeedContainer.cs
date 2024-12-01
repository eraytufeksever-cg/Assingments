using System.Collections;

namespace Assignments
{
    public class ConstantSpeedContainer<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> _items;
        private readonly HashSet<T> _set;
        private readonly object _lock = new();

        public ConstantSpeedContainer()
        {
            _items = new LinkedList<T>();
            _set = new HashSet<T>();
        }

        public void AddFront(T element)
        {
            lock (_lock)
            {
                if (_set.Contains(element))
                    return;

                _items.AddFirst(element);
                _set.Add(element);
            }
        }

        public void AddBack(T element)
        {
            lock (_lock)
            {
                if (!_set.Add(element))
                    return;

                _items.AddLast(element);
            }
        }

        public void InsertBefore(T element, T before)
        {
            lock (_lock)
            {
                if (_set.Contains(element) || !_set.Contains(before))
                    return;

                var node = _items.Find(before);
                if (node != null)
                {
                    _items.AddBefore(node, element);
                    _set.Add(element);
                }
            }
        }

        public void Delete(T element) 
        {
            lock (_lock)
            {
                if (!_set.Remove(element))
                    return;

                var node = _items.Find(element);
                if (node != null)
                {
                    _items.Remove(node);
                }
            }
        }

        public int Count 
        { 
            get 
            { 
                lock (_lock) 
                { 
                    return _items.Count; 
                } 
            } 
        }

        public IEnumerator<T> GetEnumerator() 
        { 
            lock (_lock) 
            { 
                return _items.ToList().GetEnumerator(); 
            } 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
