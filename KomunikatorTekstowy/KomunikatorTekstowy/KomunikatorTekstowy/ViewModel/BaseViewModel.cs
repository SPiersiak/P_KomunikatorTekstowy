using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using KomunikatorTekstowy.Sevices;
using KomunikatorTekstowy.Models;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace KomunikatorTekstowy.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<UserDetailData> DataStore => DependencyService.Get<IDataStore<UserDetailData>>();
        public IDataMessage<UserMessage> MessageStore => DependencyService.Get<IDataMessage<UserMessage>>();
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
