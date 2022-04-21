using System.Collections;

class Program
{
    // Iterator interface
    abstract class Iterator : IEnumerator
    {
        public abstract object Current();
        object IEnumerator.Current => Current();
        public abstract bool MoveNext();
        public abstract void Reset();
    }
    // We need this class to make our collection work with foreach cycle
    abstract class IteratorAggregator : IEnumerable
    {
        abstract public IEnumerator GetEnumerator();
    }
    class IntCollectionIterator : Iterator
    {
        private IntCollection _collection;
        private bool _reverse;
        private int _currentKey = -1;
        public IntCollectionIterator(IntCollection agregator, bool reverse)
        {
            _collection = agregator;
            _reverse = reverse;
            Reset();
        }
        public override object Current()
        {
            return _collection.GetList()[_currentKey];
        }
        public override bool MoveNext()
        {
            int nextKey = _currentKey+=(_reverse? -1 : 1);
            if(nextKey >= 0 && nextKey < _collection.GetList().Count)
            {
                _currentKey = nextKey;
                return true;
            }
            return false;

        }

        public override void Reset()
        {
            this._currentKey = (_reverse ? _collection.GetList().Count : -1);
        }
    }
    class IntCollection : IteratorAggregator
    {
        private List<int> _list = new List<int>();
        private bool _reverse = false;
        public void Reverse()
        {
            if (!_reverse)
            {
                _reverse = true;
            }
        }
        public void CancelReverse()
        {
            if (_reverse)
            {
                _reverse = false;
            }
        }
        public List<int> GetList()
        {
            return _list;
        }
        public void Add(int item)
        {
            _list.Add(item);
        }
        public override IEnumerator GetEnumerator()
        {
            return new IntCollectionIterator(this, _reverse);
        }
    }
    static void Main()
    {
        IntCollection collection = new IntCollection();
        collection.Add(1);
        collection.Add(2);
        collection.Add(3);
        // Normal order
        foreach(int item in collection)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("");
        // Reverse order
        collection.Reverse();
        foreach (int item in collection)
        {
            Console.WriteLine(item);
        }

    }
}