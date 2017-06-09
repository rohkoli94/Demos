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

static class Program
{
	private static void Checkin(ref HotelRoom room)
	{
		if(room.Taken)
			throw new ArgumentException("Room is already occupied.");
		
		room.Taken = true;
	}

	private static int count = 0;

	private static bool CreateBusinessRoom(out HotelRoom room)
	{
		room.Number = ++count + 500;
		room.Category = RoomType.Business;
		room.Taken = false;

		return count < 10;
	}

	public static void Main()
	{
		HotelRoom myroom;
		
		if(CreateBusinessRoom(out myroom))
		{
			myroom.Print();		
			Console.WriteLine($"Checking into room {myroom.Number}");
			Checkin(ref myroom);
			myroom.Print();
		}
	}
}