using System;

namespace DIMTest
{
	public interface ICoffeeBar {
		void Charge (int price);
		public void Brew (int amount) => Console.WriteLine ($"Brewing {amount}");
	}

	public class CoffeeBar : ICoffeeBar {
		public void Charge (int price) => Console.WriteLine ($"Charging {price}");
	}

	public class FancyCoffeeBar : ICoffeeBar {
		public void Charge (int price) => Console.WriteLine ($"Charging {price}");
		public void Brew (int amount) => Console.WriteLine ($"Super brewing {amount}");
	}

	public static class EntryPoint 
	{
		public static void Main ()
		{
			ICoffeeBar first = new CoffeeBar ();
			ICoffeeBar second = new FancyCoffeeBar ();
			first.Brew (1);
			second.Brew (1);
		}
	}
}
