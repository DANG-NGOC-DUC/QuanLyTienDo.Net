using System;

using System.Windows.Input;
using WorkProgressManagement.Helpers;

namespace WorkProgressManagement.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        // 1. Biến chứa màn hình hiện tại
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        // 2. Danh sách 6 nút bấm
        public ICommand NavDashboardCommand { get; }
        public ICommand NavProjectsCommand { get; }
        public ICommand NavTasksCommand { get; }
        public ICommand NavUsersCommand { get; }
        public ICommand NavReportsCommand { get; }
        public ICommand NavProfileCommand { get; }

        public MainViewModel()
        {
            // Vừa mở app lên thì gán mồi trang Dashboard vào trước
            CurrentView = new DashboardViewModel();

            // Gán lệnh: Cứ bấm nút nào thì new ViewModel của trang đó ném vào CurrentView
            NavDashboardCommand = new RelayCommand(o => CurrentView = new DashboardViewModel());
            NavProjectsCommand = new RelayCommand(o => CurrentView = new ProjectsViewModel());
            NavTasksCommand = new RelayCommand(o => CurrentView = new TasksViewModel());
            NavUsersCommand = new RelayCommand(o => CurrentView = new UsersViewModel());
            NavReportsCommand = new RelayCommand(o => CurrentView = new ReportsViewModel());
            NavProfileCommand = new RelayCommand(o => CurrentView = new ProfileViewModel());
        }
    }
}