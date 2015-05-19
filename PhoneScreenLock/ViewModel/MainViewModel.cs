using GalaSoft.MvvmLight;
using PhoneScreenLock.ViewModel.MainWindow.Commands;
using System.Runtime.InteropServices;
using InTheHand.Net.Sockets;
using System;
using InTheHand.Net.Bluetooth;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using InTheHand.Net;
using System.Diagnostics;
using PhoneScreenLock.BlueToothManager;
using System.Threading;

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

        public LockCommand screenLock { get; set; }
        public RefreshBluetoothListCommand refreshList { get; set; }
        public ConnectCommand connectDevice { get; set; }

        public int EndPointIndex { get; set; }

        public ObservableCollection<BluetoothDeviceInfo> blueToothDevices { get; private set; }

        public MainViewModel()
        {
            screenLock = new LockCommand(this);
            refreshList = new RefreshBluetoothListCommand(this);
            connectDevice = new ConnectCommand(this);
            blueToothDevices = new ObservableCollection<BluetoothDeviceInfo>();

            FindConnectedBluetoothDevices();

        }

        public void LockScreen()
        {
            LockWorkStation();
        }

        //http://stackoverflow.com/questions/9391746/how-can-i-data-bind-a-list-of-strings-to-a-listbox-in-wpf-wp7
        public void FindConnectedBluetoothDevices()
        {
            BluetoothClient client = new BluetoothClient();
            BluetoothDeviceInfo[] devices = client.DiscoverDevicesInRange();
            ObservableCollection<BluetoothDeviceInfo> items = new ObservableCollection<BluetoothDeviceInfo>();
            blueToothDevices.Clear();
            foreach (BluetoothDeviceInfo d in devices)
            {
                blueToothDevices.Add(d);
            }

        }

        public void connectToDevice()
        {
            BTManager manager = new BTManager();
            manager.Port = 0xba5e;
            manager.Name = "Base";

            BluetoothDeviceInfo device = blueToothDevices[EndPointIndex];

            Thread Base = new Thread(
                o =>
                {
                    manager.HandleThread((BluetoothDeviceInfo)o);
                });

            Base.Start(device);

            Base.Join();

        }

    }
}