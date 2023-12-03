using System.Diagnostics;

namespace oopLab2
{
    internal class GcdCalculator
    {
        Stopwatch stopwatch = new Stopwatch();

        public long CalculateGCD(long a, long b, out long time)
        {
            stopwatch.Start();
            long Gcd = CalculateGCD(a, b);
            stopwatch.Stop();
            time = stopwatch.ElapsedTicks;
            stopwatch.Reset();
            return Gcd;
        }
        public long CalculateGCD(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == b) return a;
            if (a == 0) return b;
            if (b == 0) return a;

            while ((a != 0) && (b != 0))
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return Math.Max(a, b);
        }

        // Overloaded method for calculating GCD of 3 numbers
        public long CalculateGCD(long a, long b, long c)
        {
            return CalculateGCD(a, CalculateGCD(b, c));
        }

        // Overloaded method for calculating GCD of 4 numbers
        public long CalculateGCD(long a, long b, long c, long d)
        {
            return CalculateGCD(a, CalculateGCD(b, CalculateGCD(c, d)));
        }

        // Overloaded method for calculating GCD of 5 numbers
        public long CalculateGCD(long a, long b, long c, long d, long e)
        {
            return CalculateGCD(a, CalculateGCD(b, CalculateGCD(c, CalculateGCD(d, e))));
        }

        public long CalculateBinaryGCD(long a, long b, out long time)
        {
            stopwatch.Start();
            long Gcd = CalculateBinaryGCD(a, b);
            stopwatch.Stop();
            time = stopwatch.ElapsedTicks;
            stopwatch.Reset();
            return Gcd;
        }

        public long CalculateBinaryGCD(long a, long b)
        {
            // Base cases
            if (a == 0)
                return b;
            if (b == 0)
                return a;

            // Find the greatest power of 2 that divides both a and b
            long commonDivisor = 1;
            while ((a & 1) == 0 && (b & 1) == 0)
            {
                a >>= 1;
                b >>= 1;
                commonDivisor <<= 1;
            }

            // Continue with Euclidean algorithm
            while (a != 0)
            {
                while ((a & 1) == 0)
                    a >>= 1;

                while ((b & 1) == 0)
                    b >>= 1;

                long difference = Math.Abs(a - b) >> 1;
                if (a >= b)
                {
                    a = difference;
                }
                else
                {
                    b = difference;
                }
            }

            // Multiply back the common divisor
            return commonDivisor * b;
        }
    }
}
