using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		public class Djur
		{
			public class Whatever {
				public event Action WhateverEvent;
			}
			public Whatever w;
			public event Action DjurEvent;
		}
		private Djur djur;
		private event Action MainEvent;
		private void Subscriber() { }
		private void Grid_Loaded(object sender, RoutedEventArgs e)
		{
			myListBox.SelectionChanged += MyListBox_SelectionChanged;
			MainEvent += Subscriber;
			djur.DjurEvent += Subscriber;
			djur.w.WhateverEvent += Subscriber;
			List<Action> actions = new List<Action>();
			actions.Add(MainEvent);
			actions.Add(djur.DjurEvent);
		}

		private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void addButton_Click(object sender, RoutedEventArgs e)
		{
			myListBox.Items.Add("item 1");
			myListBox.Items.Add("item 2");
			myListBox.Items.Add("item 3");
			//removeButton.IsEnabled = myListBox.SelectedIndex >= 0;
		}

		private void removeButton_Click(object sender, RoutedEventArgs e)
		{
			if (myListBox.SelectedIndex >= 0)
			{
				int position = myListBox.SelectedIndex;
				myListBox.Items.RemoveAt(position);
				if (myListBox.Items.Count <= position)
					myListBox.SelectedIndex = position - 1;
				else
					myListBox.SelectedIndex = position;

				if (myListBox.Items.Count == 0)
					removeButton.IsEnabled = false;
			}
		}

		private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			removeButton.IsEnabled = myListBox.SelectedIndex >= 0;
		}
		// addButton, removeButton, myListBox
	}
}
