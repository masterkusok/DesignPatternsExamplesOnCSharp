using System;
using System.Collections.Generic;
using System.Collections;
namespace VisualGraphTraversal.Graph
{
    internal class RLNIterator<type> : IEnumerable
    {
        private Node<type> _root;
        public RLNIterator(Node<type> root)
        {
            _root = root;
        }

        public IEnumerator GetEnumerator()
        {
            if (_root.Right != null)
            {
                foreach (var node in new RLNIterator<type>(_root.Right))
                {
                    yield return node;
                }
            }
            if (_root.Left != null)
            {
                foreach (var node in new RLNIterator<type>(_root.Left))
                {
                    yield return node;
                }
            }
            yield return _root;
            
        }
    }
}
