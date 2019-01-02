using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR0T0TYP3
{
	class Listener
	{
		private PR0T0TYP3_SERVER thing;
		public int port { get; set; }
		public int count { get; set; }
		public IPAddress ip { get; set; }

		Thread listenThread;
		TcpListener tcplistener;

		public void serverstart()
		{
			try
			{
				MessageBox.Show("Listening!", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
				count = 0;
				this.tcplistener = new TcpListener(ip, port);
				this.listenThread = new Thread(new ThreadStart(ListenForClients));
				this.tcplistener.Start();
				this.listenThread.Start();
				this.listenThread.Join();
			}
			catch (Exception) { }
		}

		private void ListenForClients()
		{
			while (true)
			{
				if (thing.listenerWorker.CancellationPending)
				{
					thing.Clear();
					break;
				}
				Thread clientThread = new Thread(new ThreadStart(HandleClientComm));
			}
		}

		private void HandleClientComm()
		{
			Console.WriteLine("Connecting");
			TcpClient tcpClient = this.tcplistener.AcceptTcpClient();
			thing.connectedList.Add(tcpClient);
			thing.AddIPAddresses(((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString(),count);
			count += 1;
		}

		public void start_data(PR0T0TYP3_SERVER form)
		{
			thing = form;
		}
	}
}
