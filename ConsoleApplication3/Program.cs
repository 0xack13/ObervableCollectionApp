using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
namespace ConsoleApplicationForTestingCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            var ds = new DataService();
            ds.Init();
            // Note 1: here that we're using a "readonly" collection...
            Console.WriteLine(ds.Persons[0].FullName);
            Console.Read();
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }
    }
    public class DataService
    {
        public ReadOnlyObservableCollection<Person> Persons { get; private set; }
        private ObservableCollection<Person> _myPeople;
        public DataService()
        {
            _myPeople = new ObservableCollection<Person>();
            this.Persons = new ReadOnlyObservableCollection<Person>(_myPeople);
        }
        public void Init()
        {
            // Note 2: here, we're adding an item in a private, unexposed, collection
            _myPeople.Add(new Person() { FirstName = "Foo", LastName = "Bar" });


        }
    }
}