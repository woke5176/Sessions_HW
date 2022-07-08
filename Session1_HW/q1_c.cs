using System;
public class Test{
	public static void Main(String []args)
	{
	Console.Write("Enter the number upto \n");
	int n = Convert.ToInt32(Console.ReadLine());
 int t1 = 1, t2=1;
   while(t1 <= n)
   {
    if(t2%3!=0)
    {
     Console.Write(t1);
     Console.Write("\n");
     t1+=4*t2;
    } 
     t2++; 
   }
  }
   
}
