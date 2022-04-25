using VisualGraphTraversal.Graph;
namespace VisualGraphTraversal.GraphVisualizer
{
    internal class GraphVisualizer<type> : IGraphVisualizer<type>
    {
        private class VisualNode
        {
            public Rectangle Bounds;
            public Node<type> Node;
            public int NumberInRow;
            public VisualNode(Node<type> node, Rectangle bounds, int num)
            {
                Bounds = bounds;
                Node = node;
                NumberInRow = num;
            }
            public VisualNode GetParent(List<VisualNode> visualNodes)
            {
                foreach(VisualNode node in visualNodes)
                {
                    if(Node.Parent == node.Node)
                    {
                        return node;
                    }
                }
                return null;
            }
            
        }
        Graph<type> _graph;
        PictureBox _pictureBox;
        int _rowHeight;
        int _edgeSize = 5;
        private List<VisualNode> _visualNodes = new List<VisualNode>();
        public GraphVisualizer(Graph<type> graph, PictureBox picBox)
        {
            _graph = graph;
            _pictureBox = picBox;
            SetUpSizes();
        }
        private void SetUpSizes()
        {
            _rowHeight = (_pictureBox.Height / GetNumberOfRows()) - 5;
            SetCoordsForAllNodes();
        }

        private int GetNumberOfRows()
        {
            int biggestNum = 0;
            foreach(Node<type> node in _graph.GetNLREnumerator())
            {
                if (node.GetNumberOfRow() > biggestNum)
                {
                    biggestNum = node.GetNumberOfRow();
                }
            }
            return biggestNum;
        }
        private List<Node<type>> GetAllNodesFromRow(int rowNumber)
        {
            List<Node<type>> neighbourNodes = new List<Node<type>>();
            foreach (Node<type> node in _graph.GetNLREnumerator())
            {
                if(node.GetNumberOfRow() == rowNumber)
                {
                    neighbourNodes.Add(node);
                }
            }
            return neighbourNodes;
        }
        private void SetCoordsForAllNodes()
        {
            for(int i = 0; i < GetNumberOfRows(); i++)
            {
                List<Node<type>> neighbourNodes = GetAllNodesFromRow(i+1);
                for(int j = 0; j < neighbourNodes.Count; j++)
                {
                    int numberInRow;
                    if(neighbourNodes[j].Parent == null)
                    {
                        numberInRow = 1;
                    }
                    else
                    {
                        numberInRow = GetVisualNodeFromNode(neighbourNodes[j].Parent).NumberInRow * 2;
                        if(neighbourNodes[j] == neighbourNodes[j].Parent.Left)
                        {
                            numberInRow--;
                        }
                    }
                    _visualNodes.Add(new VisualNode(neighbourNodes[j],
                            new Rectangle(Convert.ToInt32((numberInRow)*(_pictureBox.Width/(Math.Pow(2, i)+1))),
                            i * _rowHeight, _rowHeight, _rowHeight), numberInRow));
                }
            }
        }
        private VisualNode GetVisualNodeFromNode(Node<type> node)
        {
            foreach(VisualNode visualNode in _visualNodes)
            {
                if(visualNode.Node == node)
                {
                    return visualNode;
                }
            }
            return null;
        }
        private void DrawAllNodes(Graphics g, Node<type> currentNode)
        {
            SolidBrush currentNodeBrush = new SolidBrush(Color.Red);
            SolidBrush otherNodeBrush = new SolidBrush(Color.Blue);
            foreach (VisualNode visualNode in _visualNodes)
            {
                if (visualNode.Node == currentNode)
                {
                    g.FillEllipse(currentNodeBrush, visualNode.Bounds);
                    continue;
                }
                g.FillEllipse(otherNodeBrush, visualNode.Bounds);
            }
        }
        private void DrawAllEdges(Graphics g, Pen pen)
        {
            foreach (VisualNode visualNode in _visualNodes)
            {
                VisualNode parent = visualNode.GetParent(_visualNodes);
                if (parent != null)
                {
                    Point startPoint = new Point(parent.Bounds.X + _rowHeight / 2,
                        parent.Bounds.Y + _rowHeight / 2);
                    Point endPoint = new Point(visualNode.Bounds.X + _rowHeight / 2,
                        visualNode.Bounds.Y + _rowHeight / 2); ;
                    g.DrawLine(pen, startPoint, endPoint);
                }
            }
        }
        private void DrawValues(Graphics g)
        {
            Font font = new Font(FontFamily.GenericSerif, _edgeSize*2);
            foreach (VisualNode visualNode in _visualNodes)
            {
                string value = visualNode.Node.Value.ToString();
                if (value.Length > 5)
                {
                    value = value.Substring(0, 2);
                    value += "...";
                }
                g.DrawString(value, font, new SolidBrush(Color.White),
                    visualNode.Bounds.X+_rowHeight/4, visualNode.Bounds.Y + _rowHeight / 4);
            }
        }
    
        public void Visualize(Node<type> currentNode)
        {
            Bitmap bitmap = new Bitmap(_pictureBox.Width, _pictureBox.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            DrawAllEdges(g, new Pen(new SolidBrush(Color.Blue)){Width=10});
            DrawAllNodes(g, currentNode);
            DrawValues(g);
            _pictureBox.Image = bitmap;
        }
    }
}
