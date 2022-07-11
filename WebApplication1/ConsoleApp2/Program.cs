using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] arr = new string[] { "1", "2", "3" };
            ////int[] arri = Array.ConvertAll(arr, new Converter<string, int>(StrToInt));

            //int[] inttem = new int[arr.Length];
            //for (int i = 0; i < arr.Length; i++)
            //{ 
            //    int.TryParse(arr[i], out inttem[i]);
            //}
            string[] arr = new string[] { "1", "2", "3" };
            int[] arr1 ;
            arr1 = Array.ConvertAll(arr, int.Parse);
            string[] arr3 = new string[] { "1", "2", "3" };
            int[] arr4;
            arr4 = Array.ConvertAll(arr3, m => int.Parse(m));
            Console.WriteLine(arr1[1]);

            Console.ReadLine();
        }
    }
}
