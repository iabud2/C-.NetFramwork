using System;
using System.IO;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;



[Serializable]
public class Program
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
    }

    public static void XmlSerialize(Person person1)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Person));
        using(StreamWriter writer = new StreamWriter("person.xml"))
        {
            serializer.Serialize(writer, person1);
        }
    }
    
    public static void XmlDeserialize(string path)
    {   
        XmlSerializer serializer = new XmlSerializer(typeof(Person));
        using (StreamReader reader = new StreamReader(path))
        {
            Person person = (Person)serializer.Deserialize(reader);
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}, Country: {person.Country}");
        }
    }

    public static void JsonSerialize(Person person)
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));
        using (MemoryStream ms = new MemoryStream())
        {
            serializer.WriteObject(ms, person);
            string jsonString = System.Text.Encoding.UTF8.GetString(ms.ToArray());
            File.WriteAllText("Person.json", jsonString);
        }
    }

    public static void JsonDeserialize(string path)
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            Person DeserializePerson = (Person)serializer.ReadObject(fs);
            Console.WriteLine($"Name: {DeserializePerson.Name},   Age: {DeserializePerson.Age}, Country: {DeserializePerson.Country}");
        }
    }

    public static void Main()
    {
        string path = "person.xml";
        Person person1 = new Person();
        person1.Name = "Alice";
        person1.Age = 30;
        person1.Country = "Wonderland";

        XmlSerialize(person1);
        XmlDeserialize(path);


        string path1 = "Person.json";
        Person person2 = new Person();
        person2.Age = 20;
        person2.Name = "Ahmed";
        person2.Country = "Saudi Arabia";

        JsonSerialize(person2);
        JsonDeserialize(path1);

    }
}
