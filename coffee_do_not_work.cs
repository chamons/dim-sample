using System;

namespace DIMTest
{
	public interface ICoffeeBar {
		void Charge (int price);
		public void Brew (int amount) => Console.WriteLine ($"Brewing {amount}");
	}

	public class CoffeeBar : ICoffeeBar {
		public void Charge (int price)
		{
			// Case #2 - You can not call extensions on this
			// coffee_do_not_work.cs(15,4): error CS0103: The name 'Brew' does not exist in the current context
			Brew (price);
			// Case #2.1 - Without this ugly cast
			((ICoffeeBar)this).Brew (price); 
		}
	}

	public class FancyCoffeeBar : ICoffeeBar {
		public void Charge (int price) => Console.WriteLine ($"Charging {price}");
		public void Brew (int amount) => Console.WriteLine ($"Super brewing {amount}");
	}

	public static class EntryPoint 
	{
		public static void Main ()
		{
			CoffeeBar first = new CoffeeBar ();
			FancyCoffeeBar second = new FancyCoffeeBar ();
			// Case #1 - Can not call extension on concrete type that does not override
			// coffee_do_not_work.cs(34,10): error CS1061: 'CoffeeBar' does not contain a definition for 'Brew' and no extension method 'Brew' accepting a first argument of type 'CoffeeBar' could be found (are you missing a using directive or an assembly reference?)
			first.Brew (1);
			// Case #1.1 - However, you can call it on a type that overrides ?!
			second.Brew (1);
			// Case 1.2 - You can also use this ugly cast
			((ICoffeeBar)first).Brew (1);
		}
	}
}
