using System;
using System.Linq;
using System.Windows;

namespace WpfChatApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private MainWindowViewModel viewModel;

		private MainWindowViewModel ViewModel
		{
			get
			{
				if (this.viewModel == null)
				{
					this.viewModel = new MainWindowViewModel();
				}

				return this.viewModel;
			}	
		}

		public MainWindow()
		{
			InitializeComponent();

			this.DataContext = this.ViewModel;
		}

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			this.ViewModel.Dispose();

			base.OnClosing(e);
		}
	}
}
