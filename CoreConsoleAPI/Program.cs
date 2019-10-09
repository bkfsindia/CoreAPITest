using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using w = System.Console;

namespace CoreConsoleAPI
{
    #region SingleResponsibilityClass
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;
        public int AddEntry(string val)
        {
            entries.Add($"{ ++count}: {val}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
        
    }
    public class Persistance
    {
        public void saveToFile(Journal j,string fileName,bool overRide=false)
        {
            if((overRide)|| !(File.Exists(fileName)))
            {
                File.WriteAllText(fileName, j.ToString());
            }
        }
    }
    #endregion

    public enum  Color
    {
        red,green,blue
    }
    public enum Size
    {
        small,medium,large,huge
    }
    public class product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public product(string name, Color color, Size size)
        {
            if(name == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
               
            }
            Name = name;
            Color = color;
            Size = size;
        }
        
    }

    public  class ProductFilter
    {
        public  IEnumerable<product> FilterBySize(IEnumerable<product> products,Size size)
        {
            foreach(var p in products)
            {
                if(p.Size== size)
                {
                    yield return p;
                }
            }
        }

        public  IEnumerable<product> FilterByColor(IEnumerable<product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.Color == color)
                {
                    yield return p;
                }
            }
        }

        
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region SingleResponsibilityCalling
            //var j = new Journal();
            //j.AddEntry("I started Git");
            //j.AddEntry("After that i learn github in hindi");
            //Console.WriteLine(j.ToString());

            //var p = new Persistance();
            //p.saveToFile(j, @"D:\temp\journal.txt", true);
            #endregion

            var apple = new product("Apple", Color.green, Size.small);
            var tree = new product("Tree", Color.green, Size.large);
            var house = new product("House", Color.blue, Size.huge);
            product[] p = {apple,tree,house };
            var pf = new ProductFilter();
            w.WriteLine("Green Product Old");
            foreach(var v in pf.FilterByColor(p,Color.green))
            {
                w.WriteLine($"{v.Name} is green");
            }
                


        }
    }
}
