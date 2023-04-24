using System;
using System.Collections.Generic;

class Person : IComparable<Person>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }

    public Person(string name, string surname, DateTime dateOfBirth, string gender)
    {
        Name = name;
        Surname = surname;
        DateOfBirth = dateOfBirth;
        Gender = gender;
    }

    public int CompareTo(Person other)
    {
        return Name.CompareTo(other.Name);
    }
}

class AgeComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        return x.DateOfBirth.CompareTo(y.DateOfBirth);
    }
}

class GenderComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        return x.Gender.CompareTo(y.Gender);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person[] people = new Person[]
        {
            new Person("John", "Doe", new DateTime(1990, 10, 12), "M"),
            new Person("Mary", "Smith", new DateTime(1985, 5, 7), "F"),
            new Person("Bob", "Johnson", new DateTime(1988, 2, 15), "M")
        };

        // Сортировка по имени с помощью IComparable
        Array.Sort(people);
        foreach (Person p in people)
        {
            Console.WriteLine($"{p.Name} {p.Surname}, {p.DateOfBirth}, {p.Gender}");
        }

        // Сортировка по возрасту с помощью AgeComparer
        Array.Sort(people, new AgeComparer());
        foreach (Person p in people)
        {
            Console.WriteLine($"{p.Name} {p.Surname}, {p.DateOfBirth}, {p.Gender}");
        }

        // Сортировка по полу с помощью GenderComparer
        Array.Sort(people, new GenderComparer());
        foreach (Person p in people)
        {
            Console.WriteLine($"{p.Name} {p.Surname}, {p.DateOfBirth}, {p.Gender}");
        }

       
        Console.WriteLine($"Максимальный по возрасту: {GetMax(people, new AgeComparer()).Name}");

        
        Console.WriteLine($"Максимальный по полу: {GetMax(people, new GenderComparer()).Name}");
    }

    static Person GetMax(Person[] people, IComparer<Person> comparer)
    {
        Person maxPerson = people[0];
        for (int i = 1; i < people.Length; i++)
        {
            if (comparer.Compare(people[i], maxPerson) > 0)
            {
                maxPerson = people[i];
            }
        }
        return maxPerson;
    }
}
