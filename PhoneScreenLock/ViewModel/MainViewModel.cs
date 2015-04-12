using GalaSoft.MvvmLight;
using PhoneScreenLock.ViewModel.MainWindow.Commands;
using System.Runtime.InteropServices;
using InTheHand.Net.Sockets;
using System;
using InTheHand.Net.Bluetooth;
using System.Windows;
using System.Collections.Generic;

namespace PhoneScreenLock.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        [DllImport("user32")]
        public static extern void LockWorkStation();

        public LockCommand screenLock {get; set;}
        public List<BluetoothDeviceInfo> blueToothDevices { get; private set; }

        public MainViewModel()
        {
            screenLock = new LockCommand(this);

            blueToothDevices = FindConnectedBluetoothDevices();

        }

        public void LockScreen()
        {
            LockWorkStation();
        }

        //http://stackoverflow.com/questions/9391746/how-can-i-data-bind-a-list-of-strings-to-a-listbox-in-wpf-wp7
        public List<BluetoothDeviceInfo> FindConnectedBluetoothDevices()
        {
            BluetoothClient client = new BluetoothClient();
            BluetoothDeviceInfo[] devices = client.DiscoverDevicesInRange();
            List<BluetoothDeviceInfo> items = new List<BluetoothDeviceInfo>();
            foreach (BluetoothDeviceInfo d in devices)
            {
                items.Add(d);
            }

            return items;
        }

       
    }
}