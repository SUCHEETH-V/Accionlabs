using System;
using System.Collections.Generic;
class ArrayIntersection
{
    public List<int> FindCommon(int[] arr1, int[] arr2)
    {
        var result = new List<int>();
        int i = 0, j = 0;
        while (i < arr1.Length && j < arr2.Length)
        {
            if (arr1[i] == arr2[j])
            {
                if (result.Count == 0 || result[result.Count - 1] != arr1[i])
                    result.Add(arr1[i]);
                i++;
                j++;
            }
            else if (arr1[i] < arr2[j]) i++;
            else j++;
        }
        return result;
    }
}

class Program
{
    static void Main()
    {
        int[] arr1 = { 1, 2, 3, 4, 5 };
        int[] arr2 = { 2, 4, 6 };
        var intersector = new ArrayIntersection();
        var result = intersector.FindCommon(arr1, arr2);
        result.ForEach(Console.WriteLine);
    }
}
