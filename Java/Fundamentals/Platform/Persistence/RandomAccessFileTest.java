import java.io.*;

class RandomAccessFileTest{

	public static void main(String[] args) throws Exception{
		RandomAccessFile file = new RandomAccessFile(args[0], "rw");
		int sz = (int)file.length();
		byte[] buffer = new byte[sz];
		file.read(buffer);
		for(int i = 0, j = sz - 1; i < j; ++i, j--){
			byte ib = buffer[i];
			byte jb = buffer[j];
			buffer[i] = jb;
			buffer[j] = ib;
		}
		file.seek(0);
		file.write(buffer);
		file.close();
	}
}


