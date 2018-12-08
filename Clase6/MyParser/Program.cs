using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Document document = new Document();

            document.Add(new JsonElement());
            document.Add(new XmlElement());
            document.Add(new JsonElement());
            document.Add(new XmlElement());

            document.Accept(new SearchFeature());
        }
    }

    abstract class Element
    {
        public abstract void Accept(Feature feature);
    }

    class Document : Element
    {
        List<Element> elements = new List<Element>();

        public override void Accept(Feature feature)
        {
            foreach (Element element in elements)
            {
                element.Accept(feature);
            }
        }

        public void Add(Element element)
        {
            this.elements.Add(element);
        }
    }

    class JsonElement : Element
    {
        public override void Accept(Feature feature)
        {
            feature.Apply(this);
        }
    }

    class XmlElement : Element
    {
        public override void Accept(Feature feature)
        {
            feature.Apply(this);
        }
    }

    abstract class Feature
    {
        public abstract void Apply(JsonElement jsonElement);
        public abstract void Apply(XmlElement xmlElement);
    }

    class SearchFeature : Feature
    {
        public override void Apply(JsonElement jsonElement)
        {
            Console.WriteLine("Searching element in json element...");
        }

        public override void Apply(XmlElement xmlElement)
        {
            Console.WriteLine("Searching element in xml element...");
        }
    }
}
