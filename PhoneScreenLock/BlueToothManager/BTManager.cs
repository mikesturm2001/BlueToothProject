using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneScreenLock.BlueToothManager
{
    class BTManager
    {
        private static BluetoothDeviceInfo[] peers;
        private BluetoothClient client;
        private bool _isConnected = false;
        private string _match;
        private const string defpin = "0000";
        private TcpListener tcpListener;
        private int _port;
        private string _name = "Not Named";

        [DllImport("user32")]
        public static extern void LockWorkStation();


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        public bool IsConnected
        {
            get { return _isConnected; }
            private set { _isConnected = value; }
        }

        public string match
        {
            get { return _match; }

            set { _match = value; }
        }

        public BTManager()
        {
            client = new BluetoothClient();
        }


        public void HandleThread(BluetoothDeviceInfo device)
        {
            //while (!this.findDevice(out device)) ;

            Console.WriteLine("About to pair");
            int count = 0;
            int max = 5;
            while ((!(BluetoothSecurity.PairRequest(device.DeviceAddress, defpin))) && count < max)
            {
                Console.WriteLine("Pairing Failed, retrying");
                count++;
                Thread.Sleep(100);
            }

            if (count == max)
            {
                HandleThread(device);
            }
            else
            {
                Console.WriteLine("Paired..Beginning connect");
                client.BeginConnect(device.DeviceAddress, BluetoothService.SerialPort, this.callback, client);
            }
        }

        private void callback(IAsyncResult result)
        {
            client.EndConnect(result);

            /*
            this.tcpListener = new TcpListener(IPAddress.Loopback, _port);
            this.tcpListener.Start();
            TcpClient TcpClient = this.tcpListener.AcceptTcpClient();
            NetworkStream networkStream = TcpClient.GetStream();
            Stream bluetoothStream = client.GetStream();

            byte[] fromNetwork = new byte[1024];
            byte[] fromBluetooth = new byte[1024];
             * 
            while (client.Connected && TcpClient.Connected)
            {

                try
                {
                    if (networkStream.CanRead)
                    {
                        Array.Clear(fromNetwork, 0, 1024);
                        networkStream.Read(fromNetwork, 0, 1024);
                        Console.WriteLine(Encoding.ASCII.GetString(fromNetwork));
                        bluetoothStream.Write(fromNetwork, 0, 1024);
                        bluetoothStream.Flush();

                        while (bluetoothStream.CanRead)
                        {
                            Array.Clear(fromBluetooth, 0, 1024);
                            bluetoothStream.Read(fromBluetooth, 0, 1024);
                            Console.WriteLine(Encoding.ASCII.GetString(fromNetwork));
                            networkStream.Write(fromBluetooth, 0, 1024);
                            networkStream.Flush();
                        }
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
             * */
            while (client.Connected)
            {
                //do nothing
            }
            LockWorkStation();

            //this.HandleThread();
        }

        private bool findDevice(out BluetoothDeviceInfo device)
        {
            peers = client.DiscoverDevicesInRange();
            device = Array.Find(peers, element => element.DeviceName == match);

            foreach (BluetoothDeviceInfo btdi in peers)
            {
                Console.WriteLine(btdi.DeviceName);
            }


            if (device == null)
            {
                Console.WriteLine(Name + ": Not Found");
                return false;
            }
            else
            {
                Console.WriteLine(Name + ": Found");
                return true;
            }

        }
    }
}
