using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GitDashDemo
{
	class GitMainViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		private string username;

		public string Username
		{
			get => username;
			 set { username = value; OnPropertyChanged(); }
		}
		private readonly GithubApiService _api = new GithubApiService();

		public ICommand btnSearch { get; }

		private bool _isBusy { get; set; }

		public bool IsBusy
		{
			get => _isBusy;
			private set { _isBusy = value; OnPropertyChanged(); }
		}

		private GitUserModel user { get; set; }

		public GitUserModel User
		{
			get => user;
			set { user = value; OnPropertyChanged(); }
		}

		public ObservableCollection<RepoModel> Repo { get; set; }




		public GitMainViewModel()
		{
			btnSearch = new RelayCommand(async () => await DoSearch(), () => !IsBusy);
		}

		private void OnPropertyChanged(string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));



		private async Task DoSearch()
		{
			if (string.IsNullOrWhiteSpace(Username)) return;

			IsBusy = true;
			User = await _api.GetUserAsync(Username);
            Repo = new ObservableCollection<RepoModel>((IEnumerable<RepoModel>)await _api.GetReposAsync(Username));
            IsBusy = false;
		}


		public string UserName
		{
			get
			{
				return username;
			}
			set { username = value; OnPropertyChanged(); }

		}

		private GitUserModel gitUser { get; set; }

		public GitUserModel GitUser
		{
			get => gitUser; set { gitUser = value; OnPropertyChanged(); }

		}


	}
}
