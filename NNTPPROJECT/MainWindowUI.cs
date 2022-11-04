using System;
using System.Collections.ObjectModel;

namespace NNTPPROJECT;

public class MainWindowUI : Bindable
{
    public ObservableCollection<GetGroups> GetGroups
    {
        get
        {
            if (GetGroups is null)
                throw new ArgumentNullException();
            return GetGroups;
        }
        set
        {
            if (GetGroups is null)
                throw new ArgumentNullException();
            GetGroups = value;
            OnPropertyChanged();
        }
    }
}