﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhoneScreenLock.ViewModel.MainWindow.Commands
{
    public class ConnectCommand : ICommand
    {
        private MainViewModel mainWindow;

        public ConnectCommand(MainViewModel MainWindow)
        {
            mainWindow = MainWindow;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object paramter)
        {
            mainWindow.connectToDevice();
        }
    }
}
