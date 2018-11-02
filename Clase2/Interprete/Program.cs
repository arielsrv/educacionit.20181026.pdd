using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interprete
{
    class Program
    {
        static void Main(string[] args)
        {
            IShell shell = new MsDosShell();

            // Backup 
            ITask backup = new BackupTask(shell);
            backup.Execute();

            // Restore 
            ITask restore = new RestoreTask(shell);
            restore.Execute();

            ITask runner = new Runner(new List<ITask> { backup, restore });
            runner.Execute();


        }
    }

    class Runner : ITask
    {
        private List<ITask> tasks;

        public Runner(List<ITask> tasks)
        {
            this.tasks = tasks;
        }
        public void Execute()
        {
            foreach (ITask task in tasks)
            {
                task.Execute();
            }            
        }
    }

    interface ITask
    {
        void Execute();
    }

    class BackupTask : ITask
    {
        private IShell shell;

        public BackupTask(IShell shell)
        {
            this.shell = shell;
        }

        public void Execute()
        {
            shell.Copy();
            shell.Zip();
            shell.Delete();
            shell.Move();
        }
    }

    class RestoreTask : ITask
    {
        private IShell shell;

        public RestoreTask(IShell shell)
        {
            this.shell = shell;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }

    interface IShell
    {
        void Copy();
        void Move();
        void Delete();
        void List();
        void Zip();
    }

    class MsDosShell : IShell
    {
        public void Copy()
        {
            Console.WriteLine("Copying files...");
        }

        public void Delete()
        {
            Console.WriteLine("Deleteing files...");
        }

        public void List()
        {
            Console.WriteLine("Listing files...");
        }

        public void Move()
        {
            Console.WriteLine("Moving files...");
        }

        public void Zip()
        {
            Console.WriteLine("Ziping files...");
        }
    }

    class BashShell : IShell
    {
        public void Copy()
        {
            Console.WriteLine("Copying files...");
        }

        public void Delete()
        {
            Console.WriteLine("Deleteing files...");
        }

        public void List()
        {
            Console.WriteLine("Listing files...");
        }

        public void Move()
        {
            Console.WriteLine("Moving files...");
        }

        public void Zip()
        {
            Console.WriteLine("Ziping files...");
        }
    }
}
