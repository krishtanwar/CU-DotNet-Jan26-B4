namespace GraphSocialNetwork
{
    class Person
    {
        public string Name { get; private set; }

        private List<Person> friends = new List<Person>();

        public IReadOnlyList<Person> Friends
        {
            get { return friends.AsReadOnly(); }
        }

        public Person(string name)
        {
            Name = name;
        }

        public void AddFriend(Person p)
        {
            if (p == null || p == this)
                return; // prevent null or self-friendship

            if (!friends.Contains(p))
            {
                friends.Add(p);
                p.AddFriend(this); // reciprocal friendship
            }
        }
    }
    class SocialNetwork
    {
        private List<Person> people = new List<Person>();

        public void AddPerson(Person p)
        {
            if (!people.Contains(p))
                people.Add(p);
        }

        public void ShowNetwork()
        {
            foreach (Person p in people)
            {
                string friendNames = string.Join(", ",
                    p.Friends.Select(f => f.Name));

                Console.WriteLine($"{p.Name} -> {friendNames}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            SocialNetwork network = new SocialNetwork();

            Person aman = new Person("Aman");
            Person ravi = new Person("Ravi");
            Person neha = new Person("Neha");

            network.AddPerson(aman);
            network.AddPerson(ravi);
            network.AddPerson(neha);

            aman.AddFriend(ravi);
            ravi.AddFriend(neha);

            aman.AddFriend(aman);

            network.ShowNetwork();
        }
    }
}
