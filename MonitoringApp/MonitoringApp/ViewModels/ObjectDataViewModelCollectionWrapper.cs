using System.Collections.ObjectModel;

namespace MonitoringApp.ViewModels
{
    public class ObjectDataViewModelCollectionWrapper
    {
        public ObjectDataViewModelCollectionWrapper()
        {
            ObjectCollectionViewModels = new ObservableCollection<ObjectDataViewModel>();
        }

        public ObservableCollection<ObjectDataViewModel> ObjectCollectionViewModels { get; set; }
    }
}