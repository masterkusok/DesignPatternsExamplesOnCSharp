using System.Collections;

namespace VisualGraphTraversal.Graph
{
    internal class NLRIterator<type> : IEnumerable
    {
        private Node<type> _root;
        public NLRIterator(Node<type> root)
        {
            _root = root;
        }

        public IEnumerator GetEnumerator()
        {
            yield return _root;
            if(_root.Left != null)
            {
                foreach(var node in new NLRIterator<type>(_root.Left))
                {
                    yield return node;
                }
            }
            if(_root.Right != null)
            {
                foreach (var node in new NLRIterator<type>(_root.Right))
                {
                    yield return node;
                }
            }
        }
    }
}
