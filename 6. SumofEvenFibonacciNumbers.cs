using System;
class EvenFibonacciSum
{
    public int Calculate(int count)
    {
        int a = 0, b = 1, sum = 0;
        int found = 0;
        while (found < count)
        {
            long next = a + b;
            a = b;
            b = next;
            if (a % 2 == 0)
            {
                sum += a;
                found++;
            }
        }
        return sum;
    }
}

class Program
{
    static void Main()
    {
        var fibSum = new EvenFibonacciSum();
        Console.WriteLine(fibSum.Calculate(100));
    }
}
