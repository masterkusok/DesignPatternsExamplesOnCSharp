using System.Collections;
namespace VisualGraphTraversal.Graph
{
    internal class LNRIterator<type> : IEnumerable
    {
        private Node<type> _root;
        public LNRIterator(Node<type> root)
        {
            _root = root;
        }

        public IEnumerator GetEnumerator()
        {
            if (_root.Left != null)
            {
                foreach (var node in new LNRIterator<type>(_root.Left))
                {
                    yield return node;
                }
            }
            yield return _root;
            if (_root.Right != null)
            {
                foreach (var node in new LNRIterator<type>(_root.Right))
                {
                    yield return node;
                }
            }
        }
    }
}
