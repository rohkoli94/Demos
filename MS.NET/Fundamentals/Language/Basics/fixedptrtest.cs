using System;

enum RoomType {Economy, Business, Executive, Deluxe};

struct HotelRoom
{
	public int Number;
	public RoomType Category;
	public bool Taken;

	public void Print()
	{
		Console.WriteLine("Room {0} is of {1} class and is currently {2}.", Number, Category, Taken ? "Occupied" : "Available");
	}
}

unsafe static class Program
{
	private static void Checkin(HotelRoom* room)
	{
		if(room->Taken)
			throw new ArgumentException("Room is already occupied.");
		
		room->Taken = true;
	}

	public static void Main(string[] args)
	{
		int n = args.Length > 0 ? int.Parse(args[0]) : 10;
		//HotelRoom* myfloor = stackalloc HotelRoom[n];
		HotelRoom[] myfloor = new HotelRoom[n];

		for(int i = 0; i < n; ++i)
		{
			myfloor[i].Number = 501 + i;
			myfloor[i].Category = RoomType.Business;
			myfloor[i].Taken = false;
		}

		myfloor[2].Print();
		Console.WriteLine($"Checking into room {myfloor[2].Number}");
		//Checkin(&myfloor[2]);
		fixed(HotelRoom* pRoom = &myfloor[2])
		{
			Checkin(pRoom);
		}
		myfloor[2].Print();
	}
}