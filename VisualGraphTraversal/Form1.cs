using VisualGraphTraversal.Graph;
using VisualGraphTraversal.GraphVisualizer;
namespace VisualGraphTraversal
{
    public partial class Form1 : Form
    {
        Graph<int> graph;
        bool isRunning = false;
        bool stopped = false;
        public Form1()
        {
            InitializeComponent();
            // Here i create this graph
            //       1
            //    /     \
            //   2       3
            //  / \     /  \
            // 4   5   6    7
            // You can create your own and test visualizer 
            graph = new Graph<int>(1);
            graph.AddLeftChild(2);
            graph.AddRightChild(3);
            graph?.RootNode.Left?.AddLeftChild(4);
            graph?.RootNode.Left?.AddRightChild(5);
            graph?.RootNode.Right?.AddLeftChild(6);
            graph?.RootNode.Right?.AddRightChild(7);
        }

        private async void NLRMode_Click(object sender, EventArgs e)
        {
            VisualizeMode(graph.GetNLREnumerator());
        }

        private async void LNRMode_Click(object sender, EventArgs e)
        {
            VisualizeMode(graph.GetLNREnumerator());
        }

        private async void RLNMode_Click(object sender, EventArgs e)
        {
            VisualizeMode(graph.GetRLNEnumerator());
        }
        private async void VisualizeMode(System.Collections.IEnumerable enumer)
        {
            if (!isRunning)
            {
                OutputTextBox.Clear();
                isRunning = true;
                IGraphVisualizer<int> visualizer = new GraphVisualizer.GraphVisualizer<int>(graph, pictureBox1);
                foreach (Node<int> node in enumer)
                {
                    stopped = true;
                    visualizer.Visualize(node);
                    OutputTextBox.Text += $"{node.Value.ToString()} ";
                    await Task.Run(() =>
                    {
                        while (stopped) { }
                    });
                }
                isRunning = false;
            }
        }
        private void NextElemBtn_Click(object sender, EventArgs e)
        {
            stopped = false;
        }
        private void StopBtn_Click(object sender, EventArgs e)
        {
            stopped=true;
        }
    }
}