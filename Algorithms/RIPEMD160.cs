using System;
using System.Security.Cryptography;
namespace IOTools.Algorithms
{
	public class RIPEMD160
	{
		public RIPEMD160()
		{
			this.RIPE = new RIPEMD160Managed();
			this.Hash = new byte[20];
		}
		public byte[] GetHashBytes
		{
			get
			{
				return this.Hash;
			}
		}
		public void TransformBlock(byte[] Buffer, uint Index, uint Length)
		{
			checked
			{
				this.RIPE.TransformBlock(Buffer, (int)Index, (int)Length, this.Hash, 0);
			}
		}
		public void TransformBlock(byte[] Buffer, uint Length)
		{
			this.TransformBlock(Buffer, 0U, Length);
		}
		public void TransformBlock(byte[] Buffer)
		{
			this.TransformBlock(Buffer, 0U, checked((uint)Buffer.Length));
		}
		public byte[] TransformFinalBlock(byte[] Buffer, uint Index, uint Length)
		{
			return checked(this.RIPE.TransformFinalBlock(Buffer, (int)Index, (int)Length));
		}
		public byte[] TransformFinalBlock(byte[] Buffer, uint Length)
		{
			return this.TransformFinalBlock(Buffer, 0U, Length);
		}
		public byte[] TransformFinalBlock(byte[] Buffer)
		{
			return this.TransformFinalBlock(Buffer, 0U, checked((uint)Buffer.Length));
		}
		public byte[] Compute(byte[] Buffer, uint Index, uint Length)
		{
			return checked(this.RIPE.ComputeHash(Buffer, (int)Index, (int)Length));
		}
		public byte[] Compute(byte[] Buffer, uint Length)
		{
			return this.Compute(Buffer, 0U, Length);
		}
		public byte[] Compute(byte[] Buffer)
		{
			return this.Compute(Buffer, 0U, checked((uint)Buffer.Length));
		}
		public void Clear()
		{
			this.RIPE = new RIPEMD160Managed();
			this.Hash = new byte[20];
		}
		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
		private RIPEMD160Managed RIPE;
		private byte[] Hash;
	}
}
