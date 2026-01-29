using System.Security.Cryptography.X509Certificates;

namespace Order
{
    internal class Order
    {
        int _orderId;
        string _customerName;
        double _totalAmount;
        string status;

        public int OrderId { get; return }

        private string name;

        public string CustomerName
        {
            get { return name; }
            set { name = value; }
        }
        public double TotalAmount { get;  }

        public Order()
        {
            DateOnly orderDate;
            status = "NEW";
        }
        public Order(int orderId,string customerName)
        {
            OrderId = _orderId;
            CustomerName = _customerName;
        }

        public void AddItem(double price)
        {
            _totalAmount += price;
        }

        public void ApplyDiscount(double percent)
        {
            if(percent>0 && percent <= 30)
            {
                double x = percent / 100;
                _totalAmount = _totalAmount - _totalAmount * x;
            }
        }

        public void GetOrderSummary()
        {
            Console.WriteLine($"Order id: {OrderId}");
            Console.WriteLine($"Customer: {CustomerName}");
            Console.WriteLine($"Total Amount: {TotalAmount}");
            Console.WriteLine($"Status: {status}");
        }
        static void Main(string[] args)
        {
            Order order = new Order(101, "Krish");
            order.AddItem(300);
            order.AddItem(100);
            order.ApplyDiscount(20);

            order.GetOrderSummary();
        }
    }
}
