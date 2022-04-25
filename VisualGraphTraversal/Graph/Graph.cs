using System.Collections;

namespace VisualGraphTraversal.Graph
{
    internal class Graph<type>
    {
        Node<type> _rootNode;
        public Node<type> RootNode { get => _rootNode; }
        public Graph(type rootValue)
        {
            _rootNode = new Node<type>(null, rootValue);
        }
        public void AddLeftChild(type value)
        {
            _rootNode.AddLeftChild(value);
        }
        public void AddRightChild(type value)
        {
            _rootNode.AddRightChild(value);
        }
        public List<type> GetAllChildrenValues()
        {
            return _rootNode.GetAllChildrenValues();
        }
        public IEnumerable GetNLREnumerator()
        {
            return new NLRIterator<type>(RootNode);
        }
        public IEnumerable GetLNREnumerator()
        {
            return new LNRIterator<type>(RootNode);
        }
        public IEnumerable GetRLNEnumerator()
        {
            return new RLNIterator<type>(RootNode);
        }
    }
}
