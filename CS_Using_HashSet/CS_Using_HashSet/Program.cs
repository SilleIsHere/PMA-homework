using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Collections.Specialized.BitVector32;

namespace CS_Using_HashSet
{
    class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("Using HashSet");
            //1. Defining String Array - An array of string names is declared here, and it keeps names in it. There is a duplicate item in this array for the string "mahesh."
            string[] names = new string[]  
            {
                "mahesh",
                "vikram",
                "mahesh",
                "mayur",
                "suprotim",
                "saket",
                "manish"
            };
            //2. Length of Array and Printing array - Prints the length of the array and the data contained within it.
            Console.WriteLine("Length of Array " + names.Length);
            Console.WriteLine();
            Console.WriteLine("The Data in Array");
            foreach (var n in names) 
            {
                Console.WriteLine(n);
            }

            Console.WriteLine();
            //3. Defining HashSet by passing an Array of string to it - A string HashSet is defined. This object is initialized using an array, which automatically adds entries to HashSet from the array.
            HashSet<string> hSet = new HashSet<string>(names);
            //4. Count of Elements in HashSet
            Console.WriteLine("Count of Data in HashSet " + hSet.Count);
            Console.WriteLine();
            //5. Printing Data in HashSet eliminates the need for "mahesh" - this will displays the data in HashSet.
            Console.WriteLine("Data in HashSet");
            foreach (var n in hSet)
            {
                Console.WriteLine(n);
            }
            Console.ReadLine();

            //Here we modify HashSet Using UnionWith() Method
            //1. Array objects declare names1 and names2 which contains string data in it.
            string[] names1 = new string[] 
                {
                "mahesh","sabnis","manish","sharma","saket","karnik"
                };

            string[] names2 = new string[] 
                {
                "suprotim","agarwal","vikram","pendse","mahesh","mitkari"
                };
            //2. This step defines two HashSet objects hSetN1 and hSetN2 based on names1 and names2 respectively and data from both HashSet is printed.

            HashSet<string> hSetN1 = new HashSet<string>(names1);
            Console.WriteLine("Data in First HashSet");
            foreach (var n in hSetN1)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("_______________________________________________________________");
            HashSet<string> hSetN2 = new HashSet<string>(names2);
            Console.WriteLine("Data in Second HashSet");
            foreach (var n in hSetN2)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("________________________________________________________________");
            //3. This step calls UnionWith() method on the hSetN1 and passes hSetN2 object to it and displays all data from hSetN1 after union.
            Console.WriteLine("Data After Union");
            hSetN1.UnionWith(hSetN2);
            foreach (var n in hSetN1)
            {
                Console.WriteLine(n);
            }


            //Here we modify Hashset Using ExceptWith() Method
            //Here the code uses hSetN2 which was declared in modify HashSet Using UnionWith() Method, and declares a new HashSet using the names1 array which is used to declare hSetN1.
            Console.WriteLine();
            Console.WriteLine("_________________________________");
            Console.WriteLine("Data in HashSet before using Except With");
            Console.WriteLine("_________________________________");
            //storing data of hSetN3 in temporary HashSet
            HashSet<string> hSetN3 = new HashSet<string>(names1);
            foreach (var n in hSetN3)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();
            Console.WriteLine("_________________________________");
            Console.WriteLine("Using Except With");
            Console.WriteLine("_________________________________");
            hSetN3.ExceptWith(hSetN2);
            foreach (var n in hSetN3)
            {
                Console.WriteLine(n);
            }


            //New we coming to where we modify Hashset with using SymmetricExceptWith() method
            //Here the code useshSetN2 which was declared before in modify HashSet Using UnionWith() Method, and declares a new HashSet hSet4 using an array names1.
            HashSet<string> hSetN4 = new HashSet<string>(names1);
            Console.WriteLine("_________________________________");
            Console.WriteLine("Elements in HashSet before using SymmetricExceptWith");
            Console.WriteLine("_________________________________");
            Console.WriteLine("HashSet 1");
            foreach (var n in hSetN4)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("HashSet 2");
            foreach (var n in hSetN2)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("_________________________________");
            Console.WriteLine("Using SymmetricExceptWith");
            Console.WriteLine("_________________________________");
            hSetN4.SymmetricExceptWith(hSetN2); //The SymmetircExceptWith() method is called on hSetN4 HashSet by passing hSetN2 HashSet to it. Both these HashSets contains a string name “mahesh
            foreach (var n in hSetN4) //The hSetN4 will be merged with values from hSetN2 by eliminating the matching entry. After running the application, the result will be as follows:
            {
                Console.WriteLine(n);
            }

        }

        //Now we are going to check the performance of operations like Add, Remove, Contains on HashSet vs List.
        static string[] names = new string[]   
        {
    "Tejas", "Mahesh", "Ramesh", "Ram", "GundaRam", "Sabnis", "Leena",
    "Neema", "Sita" , "Tejas", "Mahesh", "Ramesh", "Ram",
    "GundaRam", "Sabnis", "Leena", "Neema", "Sita" ,
    "Tejas", "Mahesh", "Ramesh", "Ram", "GundaRam",
    "Sabnis", "Leena", "Neema", "Sita" , "Tejas",
    "Mahesh", "Ramesh", "Ram", "GundaRam", "Sabnis",
    "Leena", "Neema", "Sita","Tejas", "Mahesh", "Ramesh", "Ram", "GundaRam", "Sabnis" };


        //New we see the method performs Add() operation on the List and HashSet by iterating strings from the names array
        static void Get_Add_Performance_HashSet_vs_List()
        {

            Console.WriteLine("____________________________________");
            Console.WriteLine("List Performance while Adding Item");
            Console.WriteLine();
            List<string> lstNames = new List<string>();
            var s2 = Stopwatch.StartNew();
            foreach (string s in names)
            {
                lstNames.Add(s);
            }
            s2.Stop();

            Console.WriteLine(s2.Elapsed.TotalMilliseconds.ToString("0.000 ms")); Console.WriteLine();
            Console.WriteLine("Ends Here");
            Console.WriteLine();
            Console.WriteLine("____________________________________");
            Console.WriteLine("HashSet Performance while Adding Item");
            Console.WriteLine();

            HashSet<string> hStringNames = new HashSet<string>(StringComparer.Ordinal);
            var s1 = Stopwatch.StartNew();
            foreach (string s in names)
            {
                hStringNames.Add(s);
            }
            s1.Stop();

            Console.WriteLine(s1.Elapsed.TotalMilliseconds.ToString("0.000 ms")); Console.WriteLine();
            Console.WriteLine("Ends Here");
            Console.WriteLine("____________________________________");
            Console.WriteLine();

            //The List<> takes less time to add strings when compared to HashSet, because the List.Add() simply adds an item to the list whereas HashSet.Add() will skip new item if it(is)equal to one of the existing items. This takes time to execute HashSet.Add() method as compare to List.Add() method.
        }


        //New we looking at HashSet vs List – Contains() method - This method checks if the List and HashSet contains item passed as an input parameter to the Contains() method.
        static void Get_Contains_Performance_HashSet_vs_List()
        {

            Console.WriteLine("____________________________________");
            Console.WriteLine("List Performance while checking Contains operation");
            Console.WriteLine();
            List<string> lstNames = new List<string>();
            var s2 = Stopwatch.StartNew();
            foreach (string s in names)
            {
                lstNames.Contains(s);
            }
            s2.Stop();

            Console.WriteLine(s2.Elapsed.TotalMilliseconds.ToString("0.000 ms")); Console.WriteLine();
            Console.WriteLine("Ends Here");
            Console.WriteLine();
            Console.WriteLine("____________________________________");
            Console.WriteLine("HashSet Performance while checking Contains operation");
            Console.WriteLine();

            HashSet<string> hStringNames = new HashSet<string>(StringComparer.Ordinal);
            var s1 = Stopwatch.StartNew();
            foreach (string s in names)
            {
                hStringNames.Contains(s);
            }
            s1.Stop();

            Console.WriteLine(s1.Elapsed.TotalMilliseconds.ToString("0.000 ms"));
            Console.WriteLine();
            Console.WriteLine("Ends Here");
            Console.WriteLine("____________________________________");
            Console.WriteLine();

        }

        //New we looking at HashSet vs List – Remove() method. This method performs remove operation on List and HashSet using Remove() method.

        static void Get_Remove_Performance_HashSet_vs_List()
        {

            Console.WriteLine("____________________________________");
            Console.WriteLine("List Performance while performing Remove item operation");
            Console.WriteLine();
            List<string> lstNames = new List<string>();
            var s2 = Stopwatch.StartNew();
            foreach (string s in names)
            {
                lstNames.Remove(s);
            }
            s2.Stop();

            Console.WriteLine(s2.Elapsed.TotalMilliseconds.ToString("0.000 ms")); Console.WriteLine();
            Console.WriteLine("Ends Here");
            Console.WriteLine();
            Console.WriteLine("____________________________________");
            Console.WriteLine("HashSet Performance while performing Remove item operation");
            Console.WriteLine();

            HashSet<string> hStringNames = new HashSet<string>(StringComparer.Ordinal);
            var s1 = Stopwatch.StartNew();
            foreach (string s in names)
            {
                hStringNames.Remove(s);
            }
            s1.Stop();

            Console.WriteLine(s1.Elapsed.TotalMilliseconds.ToString("0.000 ms")); Console.WriteLine();
            Console.WriteLine("Ends Here");
            Console.WriteLine("____________________________________");
            Console.WriteLine();

        }




    }
}
