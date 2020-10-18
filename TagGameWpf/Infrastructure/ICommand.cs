using System;
using System.Collections.Generic;
using System.Text;

namespace TagGameWpf.Infrastructure
{
    interface ICommand
    {
        event EventHandler CanExecuteChanged;
        void Execute(object parameter);
        bool CanExecute(object parameter);
    }
}
