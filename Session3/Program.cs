using System;

using System.IO;
using System.Xml;
using System.Xml.Serialization;
var kduer = new Kduer()
{
    ID = 106,
    FirstName = "Vaibhav",
    LastName = "Singh",
    DateOfJoining = new DateTime(2022, 07, 04),

  
};
var serializer = new XmlSerializer(typeof(Kduer));
using (var writer = new StreamWriter("kduinfo.xml"))
{
    serializer.Serialize(writer, kduer);
}
Kduer DeserializeObject() 
{ 
   Kduer objectToDeserialize = new Kduer(); 
   XmlSerializer xmlserializer = new System.Xml.Serialization.XmlSerializer(typeof(objectToDeserialize)); 

   using(StreamReader streamReader = new StreamReader("D:\\kduinfo.xml")) 
   { 
     return (Kduer)xmlserializer.Deserialize(streamReader); 
   }
}
public class Kduer
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfJoining { get; set; }

}

