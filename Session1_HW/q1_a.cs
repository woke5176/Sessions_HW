using System;

public class Test
{
	public static void Main()
	{
		Console.WriteLine("Enter number until you want to print");
        int n = Convert.ToInt32(Console.ReadLine());
        int t1=1;
        int t2=4;
        int t3=7;
        Console.Write(t1);
        Console.Write("\n");
        Console.Write(t2);
        Console.Write("\n");
        Console.Write(t3);
        Console.Write("\n");
        int i=t1+t2+t3;
        while(i<=n){
        Console.Write(i);
        Console.Write("\n");
        t1=t2;
        t2=t3;
        t3=i;
        i=t1+t2+t3;
        }
	}
}