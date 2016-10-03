using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using Prism.Commands;

namespace Demo
{
	public class DemoViewModel : INotifyPropertyChanged
	{
		private readonly DispatcherTimer restartEventTimer = new DispatcherTimer();

		public DemoViewModel()
		{
			restartEventTimer.Interval = TimeSpan.FromSeconds(1.5);
			restartEventTimer.Tick += delegate { restartEventTimer.Stop(); RestartToggleChecked = false; };

            MyCommand = new DelegateCommand<bool?>(ExecuteMethod);
		}

	    private void ExecuteMethod(bool? val)
	    {

	        MessageBox.Show(val.ToString());

	    }

	    private bool restartToggleChecked;
		public bool RestartToggleChecked
		{
			get
			{
				return restartToggleChecked;
			}
			set
			{
				if (restartToggleChecked != value)
				{
					restartToggleChecked = value;
					InvokePropertyChanged("RestartToggleChecked");

					if (restartToggleChecked)
					{
						restartEventTimer.Start();
					}
				}
			}
		}

        public DelegateCommand<bool?> MyCommand { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;
		public void InvokePropertyChanged(string propertyName)
		{
		    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
