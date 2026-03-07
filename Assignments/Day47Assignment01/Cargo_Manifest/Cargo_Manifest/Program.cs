using System.Collections;
using System.Security;

namespace Cargo_Manifest
{
    class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Category { get; set; }

        public Item(string n,double w,string c)
        {
            Name = n;
            Weight=w;
            Category = c;
        }

    }
    class Container
    {
        public string ContainerID { get; set; }
        public List<Item> Items { get; set; }

        public Container(string c,List<Item> i)
        {
            ContainerID = c;
            Items = i;
        }
        
       
        

    }
    internal class Program
    {
        public static List<string> FindHeavyContainers(double weightThreshold, List<List<Container>> c)
        {
            List<string> containers = new List<string>();
            foreach (var container in c)
            {
                foreach (var itemlist in container)
                {
                    double weight = 0;
                    foreach (var item in itemlist.Items)
                    {
                        weight += item.Weight;
                    }
                    if (weight > weightThreshold) containers.Add(itemlist.ContainerID);
                }
            }

            return containers;
        }
        public static Dictionary<string, int> GetItemCountByCategory(List<List<Container>> c)
        {

            return c
         .SelectMany(row => row)
         .SelectMany(container => container.Items)

         .GroupBy(item => item.Category)
         .ToDictionary(g => g.Key, g => g.Count());


        }
        public static List<Item> FlattenAndSortShipment(List<List<Container>> c)
        {

            return c
         .SelectMany(row => row)
         .SelectMany(container => container.Items)

         .OrderBy(item => item.Category)
         .ThenBy(item => item.Weight > item.Weight)
         .ToList();




        }
        static void Main(string[] args)
        {
            
            var cargoBay = new List<List<Container>>
{
    // ROW 0: High-Value Tech Row
    new List<Container>
    {
        new Container("C001", new List<Item>
        {
            new Item("Laptop", 2.5, "Tech"),
            new Item("Monitor", 5.0, "Tech"),
            new Item("Smartphone", 0.5, "Tech")
        }),
        new Container("C104", new List<Item>
        {
            new Item("Server Rack", 45.0, "Tech"), // Heavy Item
            new Item("Cables", 1.2, "Tech")
        })
    },

    // ROW 1: Mixed Consumer Goods
    new List<Container>
    {
        new Container("C002", new List<Item>
        {
            new Item("Apple", 0.2, "Food"),
            new Item("Banana", 0.2, "Food"),
            new Item("Milk", 1.0, "Food")
        }),
        new Container("C003", new List<Item>
        {
            new Item("Table", 15.0, "Furniture"),
            new Item("Chair", 7.5, "Furniture")
        })
    },

    // ROW 2: Fragile & Perishables (Includes an Empty Container)
    new List<Container>
    {
        new Container("C205", new List<Item>
        {
            new Item("Vase", 3.0, "Decor"),
            new Item("Mirror", 12.0, "Decor")
        }),
        new Container("C206", new List<Item>()) // EDGE CASE: Container with no items
    },

    // ROW 3: EDGE CASE - Empty Row
    new List<Container>() // A row that exists but has no containers
};
            var result = FindHeavyContainers(10, cargoBay);
            Console.WriteLine($"The containers with exceeding Threshold Weight are");
            foreach (var container in result)
            {
                Console.WriteLine(container);
            }
            var result1 = GetItemCountByCategory(cargoBay);
            Console.WriteLine("The Categories wise count is: ");
            foreach(var entry in result1)
            {
                Console.WriteLine($"{entry.Key}-> {entry.Value}");
            }
            var result2=FlattenAndSortShipment(cargoBay);
            Console.WriteLine("The Sorted Transformation of the shipment: ");
            foreach (var item in result2)
            {
                Console.WriteLine($"{item.Name,-12}:{item.Category,-10}:{item.Weight,-10}");
            }
        }
    }
}
