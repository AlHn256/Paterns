using System;
using System.Collections.Generic;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>{
                new Employee {Id = 2,Name = "Ted"},
                new Employee {Id = 6,Name = "Sten"},
                new Employee {Id = 0,Name = "Bob"},
                new Employee {Id = 1,Name = "Jek"}
            };

            ShowEmploees(employees);
            employees = SortLists(employees);
            Console.WriteLine("\n\nSort By Id");
            ShowEmploees(employees);

            Console.WriteLine("\n\nSort By Name");
            employees.Sort(new EmployeeByNameComparer());
            ShowEmploees(employees);
        }

        //class LogProcessor
        //{
        //    private readonly Func<List<LogEntry>> _logImporter;
        //    public LogProcessor(Func<List<LogEntry>> logImporter)
        //    {
        //    _logImporter = logImporter;
        //    }
        //    public void ProcessLogs()
        //    {
        //        foreach (var logEntry in _logImporter.Invoke())
        //        {
        //            SaveLogEntry(logEntry);
        //        }
        //    }
        //    // Остальные методы пропущены...
        //}

        class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return string.Format("Id = {0}, Name = {1}", Id, Name);
            }
        }
        class EmployeeByIdComparer : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                return x.Id.CompareTo(y.Id);
            }
        }

        class EmployeeByNameComparer : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }

        private static List<Employee> SortLists(List<Employee> list)
        {
            // Используем "функтор"
            list.Sort(new EmployeeByIdComparer());

            //list.Sort(new EmployeeByNameComparer());

            // Используем делегат
            //list.Sort((x, y) => x.Name.CompareTo(y.Name));
            //list.Sort((x, y) => x.Id.CompareTo(y.Id));

            return list;
        }

        private static void ShowEmploees(List<Employee> employees)
        {
            foreach (Employee emploer in employees)
            {
                Console.WriteLine(emploer.Id + " - " + emploer.Name);
            }
        }

        //Фабричный класс для создания экземпляров IComparer
        class ComparerFactory
        {
            public static IComparer<T> Create<T>(Comparison<T> comparer)
            {
                return new DelegateComparer<T>(comparer);
            }

            private class DelegateComparer<T> : IComparer<T>
            {
                private readonly Comparison<T> _comparer;
                public DelegateComparer(Comparison<T> comparer)
                {
                    _comparer = comparer;
                }

            public int Compare(T x, T y)
                {
                    return _comparer(x, y);
                }
            }
        }

    }
}
