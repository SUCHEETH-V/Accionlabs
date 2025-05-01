using System;
class DigitTransformer
{
    public int Transform(int x)
    {
        if (x < 0 || x > 9)
            throw new ArgumentException("Input must be a single digit (0 - 9)");
        string s = x.ToString();
        int result = int.Parse(s) + int.Parse(s + s) + int.Parse(s + s + s) + int.Parse(s + s + s + s);
        return result;
    }
}
class Program
{
    static void Main()
    {
        var transformer = new DigitTransformer();
        Console.WriteLine(transformer.Transform(3));
    }
}
