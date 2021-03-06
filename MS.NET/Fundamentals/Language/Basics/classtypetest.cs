using System;

enum RoomType {Economy, Business, Executive, Deluxe};

class HotelRoom
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
	private static void Checkin(HotelRoom room)
	{
		if(room.Taken)
			throw new ArgumentException("Room is already occupied.");
		
		room.Taken = true;
	}

	public static void Main()
	{
		HotelRoom myroom = new HotelRoom();
		myroom.Number = 503;
		myroom.Category = RoomType.Business;
		myroom.Taken = false;

		myroom.Print();		
		Console.WriteLine($"Checking into room {myroom.Number}");
		Checkin(myroom);
		myroom.Print();
	}
}