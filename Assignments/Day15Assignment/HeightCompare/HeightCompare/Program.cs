namespace HeightCompare
{


    class Height
    {
        public int Feet { get; set; }

        public double Inches { get; set; }

        public Height()
        {
            Feet = 0;
            Inches = 0;
        }

        public Height(int feet, double inches)
        {
            Feet = feet;
            Inches = inches;
        }
        public Height(double inches)
        {
            Feet = (int)inches / 12;
            Inches = inches % 12;
        }

        public Height AddHeights(Height h)
        {
            double totalInches = this.Inches + h.Inches;
            int extraFeet = (int)totalInches / 12;
            double resultInches = totalInches % 12;
            int totalFeet=h.Feet+extraFeet+this.Feet;
            return new Height(totalFeet, resultInches);
        }
        public override string ToString()
        {
            return $"Height- {Feet} feet {Inches} inches";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Height h1= new Height(5,7);
            Height h2= new Height(5,7.24);
            Height h3 = new Height(170);
            Height h4=h1.AddHeights(h2);
            Console.WriteLine(h1);
            Console.WriteLine(h2);
            Console.WriteLine(h3);
            Console.WriteLine(h4);
            Console.WriteLine();
        }
    }
}
