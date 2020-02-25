using System.Net.Sockets;
using System.Net;
using System.Threading;
using System;
using System.Text;

namespace Monitor_receiver
{
    public class server
    {
        private int myProt = 8080;   //port
        Socket serverSocket;
        // This is equivalent to defining a function pointer
        public DllClass opt;

        public server(DllClass O)
        {
            this.opt = O;
        }

        public void run()
        {
            //server ip address
            var ip = IPAddress.Parse("127.0.0.2");
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(ip, myProt));  //bind ip address and port.
            serverSocket.Listen(10);    //Set up to 10 queued connection requests
            Console.WriteLine("Start listening {0} successfully", serverSocket.LocalEndPoint.ToString());
            //Sending data through Clientsoket
            Thread myThread = new Thread(ListenClientConnect);
            myThread.Start(this.opt);
            Console.ReadLine();
        }

        /// <summary>
        /// Listening for client connections
        /// </summary>
        private void ListenClientConnect(object opt)
        {
            ReceiverMess thread_receiver = new ReceiverMess();
            while (true)
            {
                Socket clientSocket = serverSocket.Accept();
                thread_receiver.myClientSocket = clientSocket;
                thread_receiver.label =(DllClass) opt;
                clientSocket.Send(Encoding.ASCII.GetBytes("Server Say Hello"));
                Thread receiveThread = new Thread(thread_receiver.ReceiveMessage);
                receiveThread.Start();
            }
        }
        public class ReceiverMess
        {
            private byte[] result = new byte[1024];

            public Socket myClientSocket;
            public DllClass label;

            public void ReceiveMessage()
            {
                while (true)
                {
                    try
                    {
                        //Receive data via clientSocket
                        int receiveNumber = myClientSocket.Receive(result);
                        string[] sArray = Encoding.ASCII.GetString(result, 0, receiveNumber).Split('.');

                        label.opt(sArray[0], sArray[1], sArray[2], sArray[3]);
                        Console.WriteLine("Receive client {0} message {1} {2} {3} {4}", myClientSocket.RemoteEndPoint.ToString(),
                            sArray[0], sArray[1], sArray[2], sArray[3]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        myClientSocket.Shutdown(SocketShutdown.Both);
                        myClientSocket.Close();
                        break;
                    }
                }
            }
        }

    }
}
