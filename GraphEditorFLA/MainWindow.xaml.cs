using System.Windows;
using NodeNetwork.ViewModels;

namespace GraphEditorFLA
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		NetworkViewModel network;

		public MainWindow()
		{
			InitializeComponent();

			network = new NetworkViewModel();

			var node1 = new NodeViewModel
			{
				Name = "Node 1"
			};
			network.Nodes.Add(node1);

			var node1Input = new NodeInputViewModel
			{
				Name = "Node 1 input"
			};
			node1.Inputs.Add(node1Input);

			var node2 = new NodeViewModel();
			node2.Name = "Node 2";
			network.Nodes.Add(node2);

			var node2Output = new NodeOutputViewModel();
			node2Output.Name = "Node 2 output";
			node2.Outputs.Add(node2Output);

			networkView.ViewModel = network;
		}

		private void AddNode_Click(object sender, RoutedEventArgs e)
		{
			var newNode = new NodeViewModel
			{
				Name = $"New node {network.Nodes.Count}"
			};

			network.Nodes.Add(newNode);
		}

		private void AddInput_Click(object sender, RoutedEventArgs e)
		{
			foreach (var node in network.SelectedNodes)
			{
				node.Inputs.Add(new NodeInputViewModel
				{
					Name = $"New input {node.Inputs.Count}"
				});
			}
		}

		private void AddOutput_Click(object sender, RoutedEventArgs e)
		{
			foreach (var node in network.SelectedNodes)
			{
				node.Outputs.Add(new NodeOutputViewModel
				{
					Name = $"New output {node.Outputs.Count}"
				});
			}
		}

		private void RemoveInput_Click(object sender, RoutedEventArgs e)
		{
			foreach (var node in network.SelectedNodes)
			{
				if (node.Inputs.Count > 0)
				{
					node.Inputs.RemoveAt(node.Inputs.Count - 1);
				}
			}
		}

		private void RemoveOutput_Click(object sender, RoutedEventArgs e)
		{
			foreach (var node in network.SelectedNodes)
			{
				if (node.Outputs.Count > 0)
				{
					node.Outputs.RemoveAt(node.Outputs.Count - 1);
				}
			}
		}
	}
}
