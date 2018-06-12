using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
using Prism.Regions;

namespace DesktopGui.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel([Dependency] IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public string MainContentControlName { get; } = "ContentPanel";
        public Brush NavigationBackground { get; } = Brushes.AntiqueWhite;
        public ObservableCollection<ListBoxItem> NavigationEntries { get; }
            = new ObservableCollection<ListBoxItem>(new List<ListBoxItem>
            {
                new ListBoxItem { Tag = "CreateRehearsalView", Content = "Create Rehearsal" }
            });
        public IRegionManager _regionManager { get; }

        private ListBoxItem _currentView;
        public ListBoxItem CurrentView
        {
            get { return _currentView; }
            set { SetProperty(ref _currentView, value); Navigate(_currentView?.Tag?.ToString() ?? ""); }
        }

        private void Navigate(string tag)
        {
            _regionManager.RequestNavigate(MainContentControlName, tag);
        }
    }
}
