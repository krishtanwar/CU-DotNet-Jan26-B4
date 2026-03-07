namespace Polymorphism
{
    abstract class Vehicle
    {
         protected string message;
        public string Model_Name { get; set; }

        public abstract void Move();

        public virtual void GetFuelStatus()
        {
             message="Fuel level is stable";
        }
    }

    class ElectricCar : Vehicle
    {
        public ElectricCar(string name)
        {
            Model_Name=name;
        }
        public override void Move()
        {
            Console.WriteLine($"{Model_Name} is gliding silently on battery power. ");
        }
        public override void GetFuelStatus()
        {
            Console.WriteLine($"{Model_Name} battery is at 80% ");
            
        }

    }
    class HeavyTruck : Vehicle
    {
        public HeavyTruck(string name)
        {
            Model_Name=name;
        }
        public override void Move()
        {
            Console.WriteLine($"{Model_Name} is hauling cargo with high-torque diesel power. ");
            base.GetFuelStatus();
            Console.WriteLine(message);
        }

    }

    class CargoPlane : Vehicle
    {
        public CargoPlane(string name)
        {
            Model_Name=name;
        }
        public override void Move()
        {
            Console.WriteLine($"{Model_Name} is ascending to 30,000 feet. ");
        }
        public override void GetFuelStatus()
        {
            base.GetFuelStatus();
            Console.WriteLine(message+ " Checking jet fuel reserves....");
            
        }

    }
    class program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles =
            {
                new ElectricCar("Tesla"),
                new HeavyTruck("Tata"),
                new CargoPlane("Boeing")
                
                
            };
            foreach(var vh in vehicles)
            {
                vh.Move();
                vh.GetFuelStatus();
            }
        }
    }
}
