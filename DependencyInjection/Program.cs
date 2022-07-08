using System;

public interface IClass
{
    void Serve();
}
// Initialize the Resource1
public class Resource1 : IClass
{
    public void Serve()
    {
        Console.WriteLine("Resource1 Fetched");
    }
}
// Initialize the Resource2
public class Resource2 : IClass
{
    public void Serve()
    {
        Console.WriteLine("Resource12 Fetched");
    }
}
// create an instance of Iclass
public class Client
{
    private IClass _service;
    public void Start(IClass service)
    {
        service.Serve();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Resource1 r1 = new Resource1();
       
        Client client = new Client();
        client.Start(r1);

        Resource2 r2 = new Resource2();
       
        client.Start(r2);
    }
}
