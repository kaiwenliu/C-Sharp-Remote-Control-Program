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
		public ArrayList messages { get; private set; }
		public ArrayList addresses { get; private set; }

		Thread listenThread;
		string bufferincmessage;
		TcpListener tcplistener;

		public void serverstart()
		{
			this.tcplistener = new TcpListener(this.ip, this.port);
			this.listenThread = new Thread(new ThreadStart(ListenForClients));
			this.listenThread.Start();
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
			NetworkStream clientStream = tcpClient.GetStream();
			byte[] message = new byte[4096];
			int bytesRead;
			while (true)
			{
				bytesRead = 0;
				try
				{
					bytesRead = clientStream.Read(message, 0, 4096);
				}
				catch
				{
					break;
				}
				if (bytesRead == 0)
				{
					break;
				}
				ASCIIEncoding encoder = new ASCIIEncoding();
				bufferincmessage = encoder.GetString(message, 0, bytesRead);
			}
			addresses.Add(((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString());
			messages.Add(bufferincmessage);
		}
	}
}
