using VisualGraphTraversal.Graph;
namespace VisualGraphTraversal.GraphVisualizer
{
    interface IGraphVisualizer<type>
    {
        void Visualize(Node<type> currentNode);
    }
}
