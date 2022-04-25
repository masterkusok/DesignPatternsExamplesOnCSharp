namespace VisualGraphTraversal.Graph
{
    internal class Node<type>
    {
        private Node<type> _parent;
        public Node<type>? Left { get; private set; }
        public Node<type>? Right { get; private set; }
        private type _value;
        public type Value { get => _value; }
        public Node<type> Parent { get => _parent; }
        public Node(Node<type> parent, type value)
        {
            _parent = parent;
            _value = value;
        }
        public void AddLeftChild(type value)
        {
            Left = new Node<type>(this, value);
        }
        public void AddRightChild(type value)
        {
            Right = new Node<type>(this, value);
        }
        public List<type> GetAllChildrenValues()
        {
            List<type> allChildrenValues = new List<type>();
            allChildrenValues.Add(_value);
            if(Left != null)
            {
                foreach(type child in Left.GetAllChildrenValues())
                {
                    allChildrenValues.Add(child);
                }
            }
            if(Right!= null)
            {
                foreach (type child in Right.GetAllChildrenValues())
                {
                    allChildrenValues.Add(child);
                }
            }
            return allChildrenValues;
        }
        public int GetNumberOfRow()
        {
            Node<type> thisNode = this;
            int num = 1;
            while (thisNode.Parent != null)
            {
                num++;
                thisNode = thisNode.Parent;
            }
            return num;
        }
        
    }
}
