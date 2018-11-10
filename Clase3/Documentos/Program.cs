using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentos
{
    public class Program
    {
        static void Main(string[] args)
        {
            Document resume = new Resume();

            foreach (Page page in resume.GetPages())
            {
                Console.WriteLine(page.GetType().Name);
            }

        }
    }

    abstract class Document
    {
        protected List<Page> pages = new List<Page>();

        public List<Page> GetPages()
        {
            return this.pages;
        }

        public Document()
        {
            CreatePages();
        }

        public abstract void CreatePages();
    }

    class Resume : Document
    {
        public override void CreatePages()
        {
            this.pages.Add(new Skill());
            this.pages.Add(new AcademicalHistory());
        }
    }

    class Invoice : Document
    {
        public override void CreatePages()
        {
            this.pages.Add(new Header());
        }
    }

    class Page
    {

    }

    class Skill : Page
    {

    }

    class Header : Page
    {

    }

    class AcademicalHistory : Page
    {

    }
}
