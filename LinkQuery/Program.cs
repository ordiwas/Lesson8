using System;
using System.Linq;

class famousPeople
{
    public string Name { get; set; }
    public int? BirthYear { get; set; } = null;
    public int? DeathYear { get; set; } = null;
}
class Program
{
    public static void Main(string[] args)
    {

        IList<famousPeople> stemPeople = new List<famousPeople>() {
                new famousPeople() { Name= "Michael Faraday", BirthYear=1791,DeathYear=1867 },
                new famousPeople() { Name= "James Clerk Maxwell", BirthYear=1831,DeathYear=1879 },
                new famousPeople() { Name= "Marie Skłodowska Curie", BirthYear=1867,DeathYear=1934 },
                new famousPeople() { Name= "Katherine Johnson", BirthYear=1918,DeathYear=2020 },
                new famousPeople() { Name= "Jane C. Wright", BirthYear=1919,DeathYear=2013 },
                new famousPeople() { Name = "Tu YouYou", BirthYear= 1930 },
                new famousPeople() { Name = "Françoise Barré-Sinoussi", BirthYear=1947 },
                new famousPeople() {Name = "Lydia Villa-Komaroff", BirthYear=1947},
                new famousPeople() {Name = "Mae C. Jemison", BirthYear=1956},
                new famousPeople() {Name = "Stephen Hawking", BirthYear=1942,DeathYear=2018 },
                new famousPeople() {Name = "Tim Berners-Lee", BirthYear=1955 },
                new famousPeople() {Name = "Terence Tao", BirthYear=1975 },
                new famousPeople() {Name = "Florence Nightingale", BirthYear=1820,DeathYear=1910 },
                new famousPeople() {Name = "George Washington Carver", DeathYear=1943 },
                new famousPeople() {Name = "Frances Allen", BirthYear=1932,DeathYear=2020 },
                new famousPeople() {Name = "Bill Gates", BirthYear=1955 }
        };
        var result = from s in stemPeople
                     where s.BirthYear > 1900
                     select s;
        var result2 = from z in stemPeople
                     where z.Name.Contains("ll")
                     select z;
        var count = from z in stemPeople
                      where z.BirthYear > 1950
                      select z;

        var countAge = count.Count();

        var result3 = from z in stemPeople
                      where (z.BirthYear > 1920 && z.BirthYear < 2000)
                      select z;
        var countAge2 = result3.Count();
      
        var sort = from z in stemPeople
                   where z.BirthYear > 0
                   orderby z.BirthYear
                   select z;
        var result4 = from z in stemPeople
                      where (z.DeathYear > 1960 && z.DeathYear < 2015)
                      orderby z.Name
                      select z;

        foreach (var s in result)
        {
            Console.WriteLine(s.Name);
        }

        Console.WriteLine("------------------");

        foreach (var z in result2)
        {
            Console.WriteLine(z.Name);
        }
        Console.WriteLine("------------------");

        Console.WriteLine($"People born after 1950 {countAge}");
        Console.WriteLine("------------------");

        foreach (var z in result3)
        {
            Console.WriteLine(z.Name);
        }
        Console.WriteLine($"People born between 1920 and 2000 {countAge2}");
        Console.WriteLine("------------------");

        foreach (var z in sort)
        {
            Console.WriteLine(z.Name);
        }
        Console.WriteLine("------------------");

        foreach (var z in result4)
        {
            Console.WriteLine(z.Name);
        }
        Console.WriteLine("------------------");
    }
}