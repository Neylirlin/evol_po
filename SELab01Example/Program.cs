using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using NUnit.Framework;
using ClassLibrary;

namespace SELab01Example
{
    class Program
    {
        static void Main(string[] args)
        {
            YAMLFile file = new YAMLFile();
            string bill = file.CreateBill();
            Console.WriteLine(bill);
            Console.ReadKey();
        }
    }
}
