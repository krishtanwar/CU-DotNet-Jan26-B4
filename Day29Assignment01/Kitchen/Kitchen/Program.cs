using System.Formats.Asn1;
using System.Runtime.InteropServices;

namespace Kitchen
{

    abstract class KitchenElectricAppliances
    {
        public int ElecVoltage { get; set; }
        public string ModelName { get; set; }
        public double Price { get; set; }

        protected KitchenElectricAppliances(int v, string m, double p)
        {
            ElecVoltage = v;
            ModelName = m;
            Price = p;
        }
        public void display()
        {
            Console.WriteLine($"The Appliance with model name {ModelName} is used");
            Console.WriteLine($"This Appliance uses {ElecVoltage} voltage");
            Console.WriteLine($"The price of the appliance is: {Price}");
        }
        public abstract void Cooking();
    }
    interface Itimer
    {
        void SetTimer(int minutes)
        {
            Console.WriteLine();
        }
    }
    interface Ismart
    {
        void CheckSmart(bool b);
    }

    class MicroWave : KitchenElectricAppliances, Itimer, Ismart
    {
        
        public MicroWave(int v, string m, double p) : base(v, m, p)
        {


        }

        public void CheckSmart(bool c)
        {
            if (c)
                Console.WriteLine("The device is smart");
        }

        public override void Cooking()
        {
            Console.WriteLine("Something is Cooking in Microwave");
        }

        public void SetTimer(int minutes)

        {
            if (minutes > 0)
                Console.WriteLine($"Timer set to {minutes} minutes");
        }


    }
    class Kettle : KitchenElectricAppliances
    {
        public Kettle(int v, string m, double p) : base(v, m, p)
        {
        }

        public override void Cooking()
        {
            Console.WriteLine("Something is cooking in Kettle");
        }
    }

    class Airfyer : KitchenElectricAppliances, Itimer, Ismart
    {

        public Airfyer(int v, string m, double p) : base(v, m, p)
        {

        }

        public void CheckSmart(bool c)
        {
            if (c)
                Console.WriteLine("The device is smart");
        }

        public override void Cooking()
        {
            Console.WriteLine("Something is Cooking in Airfryer");
        }

        public void SetTimer(int minutes)
        {
            Console.WriteLine($"Timer set to {minutes} minutes");
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<KitchenElectricAppliances> appliances = new List<KitchenElectricAppliances>()
            {
                new Airfyer(220,"Bajaj",10000),
                new MicroWave(200,"Philips",5500),
                new Kettle(240,"Finserv",2000)
            };


            try
            {
                foreach (var item in appliances)
                {


                    if (item is MicroWave)
                    {
                        MicroWave a = new MicroWave(item.ElecVoltage, item.ModelName, item.Price);

                        a.display();
                        a.Cooking();
                        a.SetTimer(20);
                        a.CheckSmart(true);
                        Console.WriteLine("--------------------------------");
                    }
                    else if (item is Airfyer)
                    {
                        Airfyer a = new Airfyer(item.ElecVoltage, item.ModelName, item.Price);

                        a.display();
                        a.Cooking();
                        a.SetTimer(30);
                        a.CheckSmart(true);
                        Console.WriteLine("--------------------------------");
                    }
                    else
                    {
                        item.display();
                        item.Cooking();
                        Console.WriteLine("--------------------------------");
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
