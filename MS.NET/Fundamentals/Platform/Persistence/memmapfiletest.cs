using System;
using System.IO;
using System.IO.MemoryMappedFiles;

static class Program
{
	public static void Main(string[] args)
	{
		FileInfo file = new FileInfo(args[0]);
		using(MemoryMappedFile mapping = MemoryMappedFile.CreateFromFile(file.Name))
		{	
			using(MemoryMappedViewAccessor view = mapping.CreateViewAccessor())
			{
				for(long i = 0, j = file.Length - 1; i < j; ++i, j--)
				{
					byte ib = view.ReadByte(i);	
					byte jb = view.ReadByte(j);
					view.Write(i, jb);
					view.Write(j, ib);
				}
			}	
		}
	}
}