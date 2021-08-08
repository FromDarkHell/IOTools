using System;
using System.Security.Cryptography;
namespace IOTools.Encryption
{
	public class RSA
	{
		public RSA()
		{
			RSAProvider = new RSACryptoServiceProvider();
			RSAProvider.ImportParameters(default(RSAParameters));
		}
		public RSA(RSAParameters Parameters)
		{
			RSAProvider = new RSACryptoServiceProvider();
			RSAProvider.ImportParameters(Parameters);
		}
		public RSA(byte[] CspBlob)
		{
			RSAProvider = new RSACryptoServiceProvider();
			RSAProvider.ImportCspBlob(CspBlob);
		}
		public RSAParameters Parameters
		{
			get
			{
				return RSAProvider.ExportParameters(true);
			}
			set
			{
				RSAProvider.ImportParameters(value);
			}
		}
		public byte[] CspBlob
		{
			get
			{
				return RSAProvider.ExportCspBlob(true);
			}
			set
			{
				RSAProvider.ImportCspBlob(value);
			}
		}
		public KeySizes[] LegalKeySizes
		{
			get
			{
				return RSAProvider.LegalKeySizes;
			}
		}
		public bool PublicKeyOnly
		{
			get
			{
				return RSAProvider.PublicOnly;
			}
		}
		public string KeyExchangeAlgorithm
		{
			get
			{
				return RSAProvider.KeyExchangeAlgorithm;
			}
		}
		public int KeySize
		{
			get
			{
				return RSAProvider.KeySize;
			}
		}
		public string SignatureAlgorithm
		{
			get
			{
				return RSAProvider.SignatureAlgorithm;
			}
		}
		public CspKeyContainerInfo CspKeyContainerInfo
		{
			get
			{
				return RSAProvider.CspKeyContainerInfo;
			}
		}
		public byte[] Encrypt(byte[] Buffer, bool OAEP_Padding)
		{
			return RSAProvider.Encrypt(Buffer, OAEP_Padding);
		}
		public byte[] Encrypt(byte[] Buffer)
		{
			return Encrypt(Buffer, true);
		}
		public byte[] Decrypt(byte[] Buffer, bool OAEP_Padding)
		{
			return RSAProvider.Decrypt(Buffer, OAEP_Padding);
		}
		public byte[] Decrypt(byte[] Buffer)
		{
			return Decrypt(Buffer, true);
		}
		private RSACryptoServiceProvider RSAProvider;
	}
}
