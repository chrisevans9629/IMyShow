using System;
using System.Linq;
using System.Xml.Linq;

namespace Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = @"D:\OneDrive\Documents\xmltest.txt";

            var doc = XDocument.Load(url);
            var name = "http://www.w3.org/2005/Atom";
            var media = "http://search.yahoo.com/mrss/";

            Console.WriteLine(doc.Root.Elements(XName.Get("entry", name)).First().Element(XName.Get("content", media)).Attribute(XName.Get("url")));
        }
    }
}
