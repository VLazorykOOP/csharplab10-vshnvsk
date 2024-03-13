using System;

namespace Task1
{
    class ArrayTypeMismatchException : Exception
    {
        public ArrayTypeMismatchException(string message) : base(message) { }
    }

    class DivideByZeroException : Exception
    {
        public DivideByZeroException(string message) : base(message) { }
    }

    class IndexOutOfRangeException : Exception
    {
        public IndexOutOfRangeException(string message) : base(message) { }
    }

    class InvalidCastException : Exception
    {
        public InvalidCastException(string message) : base(message) { }
    }

    class OutOfMemoryException : Exception
    {
        public OutOfMemoryException(string message) : base(message) { }
    }

    class OverflowException : Exception
    {
        public OverflowException(string message) : base(message) { }
    }

    class StackOverflowException : Exception
    {
        public StackOverflowException(string message) : base(message) { }
    }

    class Program
    {
        static double Sum(double n, double m)
        {
            try
            {
                double z;

                if (m == 0)
                {
                    throw new DivideByZeroException("Divide by zero error occurred.");
                }

                z = (n + m) * (((n + 1) / (m + 1)) + 5 / m);

                return Math.Round(z, 2);
            }
            catch (OverflowException ex)
            {
                throw new OverflowException("Overflow error occurred: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }

        }

        public static void Main_Task1()
        {
            try
            {
                Console.WriteLine("Enter two numbers: ");
                int x = Convert.ToInt32(Console.ReadLine());
                int y = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Result: ");
                Console.WriteLine(Sum(x, y));
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format: " + ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Overflow error occurred: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
