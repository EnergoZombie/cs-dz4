namespace dz4
{
    internal class Program
    {
        class PassportException : Exception
        {
            public PassportException(string message)
                : base(message) { }
        }
        class Passport
        {
            private int passportNumber = 0;
            private string name = null;
            private DateTime date = DateTime.Today;

            public int PassportNumber
            {
                get { return passportNumber; }
                set
                {
                    if (value > 0) { passportNumber = value; }
                    else { throw new PassportException("Invalid passport number"); }
                }
            }
            public string Name
            {
                get { return name; }
                set
                {
                    if (!string.IsNullOrWhiteSpace(value) && !string.IsNullOrEmpty(value) ) { name = value; }
                    else { throw new PassportException("Invalid name");  }
                }
            }
            public DateTime Date
            {
                get { return date; }
                set
                {
                    int a = DateTime.Compare(value, DateTime.Today);
                    if (a <= 0) { date = value; }
                    else { throw new PassportException("Invalid date, date cannot be later than today"); }
                }
            }
            public void Print()
            {
                Console.WriteLine($"Name: {name}");
                Console.WriteLine( $"Number: {passportNumber}");
                Console.WriteLine($"Date: {Date.ToString()}");

            }
        }
        static void Main(string[] args)
        {
            //try
            //{
            //    Console.Write("Enter number: ");
            //    int n = Convert.ToInt32(Console.ReadLine());
            //    if (n < 1) { throw new Exception("Invalid number. Number shouldn't lesser than 1"); }
            //    Console.Write("Enter number 2: ");
            //    int v = Convert.ToInt32(Console.ReadLine());
            //    if (v < 2 || v > 10) { throw new Exception("Invalid value. Value shouldn't be lesser than 2 and bigger than 10 "); }
            //    string r = "";
            //    while (n != 0)
            //    {
            //        r += Convert.ToString(n % v);
            //        n /= v;
            //    }
            //    char[] r2 = r.ToCharArray();
            //    Array.Reverse(r2);
            //    Console.WriteLine(r2);
            //}
            //catch (Exception a) { Console.WriteLine(a.Message); }

            try
            {
                Passport passport = new Passport() {Name = "John", Date = Convert.ToDateTime("12.10.2025"), PassportNumber = 123 };
                passport.Print();
            }
            catch (Exception a)
            {
                Console.WriteLine(a.Message);
            }
        }
    }
}
