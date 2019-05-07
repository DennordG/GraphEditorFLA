using System.Linq;
using System.Windows;
using NodeNetwork.ViewModels;

namespace GraphEditorFLA
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public NetworkViewModel Network { get; }

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;

			Network = new NetworkViewModel();

			var node1 = new NodeViewModel
			{
				Name = "Node 1"
			};
			Network.Nodes.Add(node1);

			var node1Input = new NodeInputViewModel
			{
				Name = "Node 1 input"
			};
			node1.Inputs.Add(node1Input);

			var node2 = new NodeViewModel
			{
				Name = "Node 2"
			};
			Network.Nodes.Add(node2);

			var node2Output = new NodeOutputViewModel
			{
				Name = "Node 2 output"
			};
			node2.Outputs.Add(node2Output);

			networkView.ViewModel = Network;
		}

		private void AddNode_Click(object sender, RoutedEventArgs e)
		{
			var newNode = new NodeViewModel
			{
				Name = $"New node {Network.Nodes.Count}"
			};

			Network.Nodes.Add(newNode);
		}

		private void AddInput_Click(object sender, RoutedEventArgs e)
		{
			foreach (var node in Network.SelectedNodes)
			{
				node.Inputs.Add(new NodeInputViewModel
				{
					Name = $"New input {node.Inputs.Count}"
				});
			}
		}

		private void AddOutput_Click(object sender, RoutedEventArgs e)
		{
			foreach (var node in Network.SelectedNodes)
			{
				node.Outputs.Add(new NodeOutputViewModel
				{
					Name = $"New output {node.Outputs.Count}"
				});
			}
		}

		private void RemoveInput_Click(object sender, RoutedEventArgs e)
		{
			foreach (var node in Network.SelectedNodes)
			{
				if (node.Inputs.Count > 0)
				{
					node.Inputs.RemoveAt(node.Inputs.Count - 1);
				}
			}
		}

		private void RemoveOutput_Click(object sender, RoutedEventArgs e)
		{
			foreach (var node in Network.SelectedNodes)
			{
				if (node.Outputs.Count > 0)
				{
					node.Outputs.RemoveAt(node.Outputs.Count - 1);
				}
			}
		}

		private void RenameNode_Click(object sender, RoutedEventArgs e)
		{
			var node = Network.SelectedNodes.FirstOrDefault();
			if (node != null)
			{
				node.Name = NodeName.Text;
			}
		}
	}
}
