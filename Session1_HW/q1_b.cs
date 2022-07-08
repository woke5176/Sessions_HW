using System;

public class squares
{
	public static void Main()
	{
		Console.WriteLine("Enter number until you want to print");
        int n = Convert.ToInt32(Console.ReadLine());
      
        for(int i=1;i*i<=n;i++){
        	Console.Write(i*i);
        	Console.Write("\n");
        }
	}
}