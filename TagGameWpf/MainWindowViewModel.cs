using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TagGameLib;
using TagGameWpf.Annotations;

namespace TagGameWpf
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
        private Game _game;
        private ObservableCollection<Tag> _tags;

        public MainWindowViewModel()
        {
            _game = new Game();
            _game.Start(4);
            _tags = new ObservableCollection<Tag>();
            
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
