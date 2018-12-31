using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PR0T0TYP3
{
	class Listener
	{
		public int port { get; set; }
		public IPAddress ip { get; set; }
		public ArrayList addresses { get; private set; }
		public List<TcpClient> list_clients = new List<TcpClient>();

		Thread listenThread;
		TcpListener tcplistener;

		public void serverstart()
		{
			this.tcplistener = new TcpListener(ip, port);
			this.listenThread = new Thread(new ThreadStart(ListenForClients));
			this.listenThread.Start();
			this.listenThread.Join();
		}

		private void ListenForClients()
		{
			while (true)
			{
				Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
			}
		}

		private void HandleClientComm(object client)
		{
			TcpClient tcpClient = (TcpClient)client;
			list_clients.Add(tcpClient);
			addresses.Add(((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString());
		}
	}
}
