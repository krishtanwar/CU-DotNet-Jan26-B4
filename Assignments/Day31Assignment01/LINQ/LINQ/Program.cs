namespace LINQ
{
    public class Student
    {
        public int Id;
        public string Name;
        public string Class;
        public int Marks;


    }
    class Employee
    {
        public int Id;
        public string Name;
        public string Dept;
        public double Salary;
        public DateTime JoinDate;
    }
    class Product
    {
        public int Id;
        public string Name;

        public string Category;
        public double Price;
    }
    class Sale
    {
        public int ProductId;
        public int Qty;
    }
    class Book { public string Title; public string Author; public string Genre; public int Year; public double Price; }

    class Customer { public int Id; public string Name; public string City; }
    class Order { public int OrderId; public int CustomerId; public double Amount; }
    class Movie { public string Title; public string Genre; public double Rating; public int Year; }
    class Transaction { public int Acc; public double Amount; public string Type; }
    class CartItem { public string Name; public string Category; public double Price; public int Qty; }
    class User { public int Id; public string Name; public string Country; }
    class Post { public int UserId; public int Likes; }

    internal class Program
    {
        public static void Main(string[] args)
        {



            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Amit", Class = "10A", Marks = 85 },
                new Student { Id = 2, Name = "Neha", Class = "10A", Marks = 72 },
                new Student { Id = 3, Name = "Rahul", Class = "10B", Marks = 90 },
                new Student { Id = 4, Name = "Pooja", Class = "10B", Marks = 60 },
                new Student { Id = 5, Name = "Kiran", Class = "10A", Marks = 95 }
            };
            // Top 3 students by marks
            var top3 = students.OrderByDescending(s => s.Marks).Take(3);

            // Group by Class and average marks
            var avgByClass = students.GroupBy(s => s.Class)
                .Select(g => new { Class = g.Key, AvgMarks = g.Average(s => s.Marks) });

            // Students below class average
            var belowAvg = students.GroupBy(s => s.Class)
                .SelectMany(g => g.Where(s => s.Marks < g.Average(x => x.Marks)));

            // Order by Class then Marks desc
            var ordered = students.OrderBy(s => s.Class)
                       .ThenByDescending(s => s.Marks);


            var employees = new List<Employee>
{
    new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
    new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
    new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
    new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
};

            // Highest & lowest salary per department
            var salaryStats = employees.GroupBy(e => e.Dept)
                .Select(g => new
                {
                    Dept = g.Key,
                    Max = g.Max(e => e.Salary),
                    Min = g.Min(e => e.Salary)
                });

            // Count per department
            var countDept = employees.GroupBy(e => e.Dept)
                .Select(g => new { Dept = g.Key, Count = g.Count() });

            // Joined after 2020
            var joinedAfter2020 = employees.Where(e => e.JoinDate.Year > 2020);

            // Anonymous object with annual salary
            var annualSalary = employees.Select(e => new
            {
                e.Name,
                AnnualSalary = e.Salary * 12
            });

            var products = new List<Product>
{
    new Product{Id=1, Name="Laptop", Category="Electronics", Price=50000},
    new Product{Id=2, Name="Phone", Category="Electronics", Price=20000},
    new Product{Id=3, Name="Table", Category="Furniture", Price=5000}
};

            var sales = new List<Sale>
{
    new Sale{ProductId=1, Qty=10},
    new Sale{ProductId=2, Qty=20}
};
            // Join Products & Sales
            var joined = products.Join(sales,
                p => p.Id,
                s => s.ProductId,
                (p, s) => new { p.Name, Revenue = p.Price * s.Qty });

            // Total revenue per product
            var revenuePerProduct = products.GroupJoin(sales,
                p => p.Id,
                s => s.ProductId,
                (p, sg) => new
                {
                    p.Name,
                    Revenue = sg.Sum(x => x.Qty * p.Price)
                });

            // Best-selling product
            var bestProduct = revenuePerProduct.OrderByDescending(r => r.Revenue).First();

            // Products with zero sales
            var zeroSales = products.GroupJoin(sales,
                p => p.Id,
                s => s.ProductId,
                (p, sg) => new { p.Name, Count = sg.Count() })
                .Where(x => x.Count == 0);

            var books = new List<Book>
{
    new Book{Title="C# Basics", Author="John", Genre="Tech", Year=2018, Price=500},
    new Book{Title="Java Advanced", Author="Mike", Genre="Tech", Year=2016, Price=700},
    new Book{Title="History India", Author="Raj", Genre="History", Year=2019, Price=400}
};
            // Published after 2015
            var after2015 = books.Where(b => b.Year > 2015);

            // Group by Genre & count
            var countByGenre = books.GroupBy(b => b.Genre)
                .Select(g => new { Genre = g.Key, Count = g.Count() });

            // Most expensive per genre
            var expensiveByGenre = books.GroupBy(b => b.Genre)
                .Select(g => g.OrderByDescending(b => b.Price).First());

            // Distinct authors
            var authors = books.Select(b => b.Author).Distinct();

            var customers = new List<Customer>
{
    new Customer{Id=1, Name="Ajay", City="Delhi"},
    new Customer{Id=2, Name="Sunita", City="Mumbai"}
};

            var orders = new List<Order>
{
    new Order{OrderId=1, CustomerId=1, Amount=20000},
    new Order{OrderId=2, CustomerId=1, Amount=40000}
};
            // Total order amount per customer
            var totalPerCustomer = customers.GroupJoin(orders,
                c => c.Id,
                o => o.CustomerId,
                (c, og) => new
                {
                    c.Name,
                    Total = og.Sum(x => x.Amount)
                });

            // Customers with no orders
            var noOrders = customers.GroupJoin(orders,
                c => c.Id,
                o => o.CustomerId,
                (c, og) => new { c.Name, Count = og.Count() })
                .Where(x => x.Count == 0);

            // Customers who spent above 50000
            var above50k = totalPerCustomer.Where(x => x.Total > 50000);

            // Sort by total spending
            var sortedBySpending = totalPerCustomer.OrderByDescending(x => x.Total);
            var movies = new List<Movie>
{
    new Movie{Title="Inception", Genre="SciFi", Rating=9, Year=2010},
    new Movie{Title="Avatar", Genre="SciFi", Rating=8.5, Year=2009},
    new Movie{Title="Titanic", Genre="Drama", Rating=8, Year=1997}
};
            // Rating > 8
            var highRated = movies.Where(m => m.Rating > 8);

            // Avg rating by genre
            var avgRating = movies.GroupBy(m => m.Genre)
                .Select(g => new { Genre = g.Key, Avg = g.Average(m => m.Rating) });

            // Latest movie per genre
            var latestByGenre = movies.GroupBy(m => m.Genre)
                .Select(g => g.OrderByDescending(m => m.Year).First());

            // Top 5 rated movies
            var top5 = movies.OrderByDescending(m => m.Rating).Take(5);

            var transactions = new List<Transaction>
{
    new Transaction{Acc=101, Amount=5000, Type="Credit"},
    new Transaction{Acc=101, Amount=2000, Type="Debit"},
    new Transaction{Acc=102, Amount=10000, Type="Debit"}
};
            // Total balance per account
            var balance = transactions.GroupBy(t => t.Acc)
                .Select(g => new
                {
                    Acc = g.Key,
                    Balance = g.Sum(t => t.Type == "Credit" ? t.Amount : -t.Amount)
                });

            // Suspicious (debit > credit)
            var suspicious = transactions.GroupBy(t => t.Acc)
                .Where(g => g.Where(t => t.Type == "Debit").Sum(t => t.Amount) >
                            g.Where(t => t.Type == "Credit").Sum(t => t.Amount));

            // Group by account (monthly needs Date – skipped here)
            var grouped = transactions.GroupBy(t => t.Acc);

            // Highest transaction per account
            var maxTxn = transactions.GroupBy(t => t.Acc)
                .Select(g => new { Acc = g.Key, Max = g.Max(t => t.Amount) });
            var cart = new List<CartItem>
{
    new CartItem{Name="TV", Category="Electronics", Price=30000, Qty=1},
    new CartItem{Name="Sofa", Category="Furniture", Price=15000, Qty=1}
};
            // Total cart value
            var totalValue = cart.Sum(c => c.Price * c.Qty);

            // Category total
            var categoryTotal = cart.GroupBy(c => c.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Total = g.Sum(x => x.Price * x.Qty)
                });

            // 10% discount on Electronics
            var discounted = cart.Select(c => new
            {
                c.Name,
                FinalPrice = c.Category == "Electronics"
                    ? c.Price * c.Qty * 0.9
                    : c.Price * c.Qty
            });

            // DTO summary
            var summary = cart.Select(c => new
            {
                c.Name,
                c.Category,
                Total = c.Price * c.Qty
            });
            var users = new List<User>
{
    new User{Id=1, Name="A", Country="India"},
    new User{Id=2, Name="B", Country="USA"}
};

            var posts = new List<Post>
{
    new Post{UserId=1, Likes=100},
    new Post{UserId=1, Likes=50}
};
            // Top users by total likes
            var topUsers = users.GroupJoin(posts,
                u => u.Id,
                p => p.UserId,
                (u, pg) => new
                {
                    u.Name,
                    Likes = pg.Sum(x => x.Likes)
                }).OrderByDescending(x => x.Likes);

            // Group users by country
            var byCountry = users.GroupBy(u => u.Country);

            // Inactive users
            var inactive = users.GroupJoin(posts,
                u => u.Id,
                p => p.UserId,
                (u, pg) => new { u.Name, Count = pg.Count() })
                .Where(x => x.Count == 0);

            // Average likes per post
            var avgLikes = posts.Average(p => p.Likes);
        }
    }
}
