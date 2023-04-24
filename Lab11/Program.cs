using System;

class Program
{
    static void Main(string[] args)
    {
        int[] intArr = { 1, 2, 3 };
        Swap(ref intArr, 0, 2);
        Console.WriteLine(string.Join(", ", intArr)); 

        string[] strArr = { "foo", "bar", "baz" };
        Swap(ref strArr, 1, 2); 
        Console.WriteLine(string.Join(", ", strArr));

        int[] intArrr = { 1, 2, 3 };
        int[] result = RemoveAt(intArrr, 1); 
        Console.WriteLine(string.Join(", ", result));

        string[] strArrr = { "foo", "bar", "baz" };
        string[] result2 = RemoveAt(strArrr, 2);
        Console.WriteLine(string.Join(", ", result2));

    }
    static void Swap<T>(ref T[] arr, int i, int j)
    {
        T temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    static T[] RemoveAt<T>(T[] arr, int index)
    {
        if (index < 0 || index >= arr.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");
        }

        T[] result = new T[arr.Length - 1];
        for (int i = 0, j = 0; i < arr.Length; i++)
        {
            if (i != index)
            {
                result[j++] = arr[i];
            }
        }
        return result;
    }

}
