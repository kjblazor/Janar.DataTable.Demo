using Janar.DataTable.Data;
using Microsoft.AspNetCore.Components;
using System;

namespace Janar.DataTable.Demo.Components.Pages
{
    public partial class NugetDemo : ComponentBase
    {
        public class Employee
        {
            public string Name { get; set; } = "";
            public decimal Salary { get; set; }
            public DateTime JoiningDate { get; set; }
            public string Position { get; set; } = "";
            public int YearsAtCompany => DateTime.Now.Year - JoiningDate.Year;
        }

        List<Employee> employees = new()
        {
            new Employee() { Name = "John Doe", Salary = 50000m, JoiningDate = new DateTime(2015, 5, 1), Position = "Software Developer" },
            new Employee() { Name = "Jane Smith", Salary = 75000m, JoiningDate = new DateTime(2018, 9, 10), Position = "Project Manager" },
            new Employee() { Name = "Emma Brown", Salary = 60000m, JoiningDate = new DateTime(2020, 1, 20), Position = "Data Analyst" },
            new Employee() { Name = "James White", Salary = 55000m, JoiningDate = new DateTime(2017, 3, 15), Position = "HR Specialist" },
            new Employee() { Name = "Emily Green", Salary = 67000m, JoiningDate = new DateTime(2019, 7, 30), Position = "UX Designer" },
            new Employee() { Name = "Michael Johnson", Salary = 85000m, JoiningDate = new DateTime(2014, 10, 12), Position = "Lead Developer" },
            new Employee() { Name = "Sophia Davis", Salary = 72000m, JoiningDate = new DateTime(2016, 3, 5), Position = "Product Manager" },
            new Employee() { Name = "Benjamin Clark", Salary = 40000m, JoiningDate = new DateTime(2021, 8, 19), Position = "Marketing Associate" },
            new Employee() { Name = "Isabella Lewis", Salary = 67000m, JoiningDate = new DateTime(2019, 11, 25), Position = "Sales Executive" },
            new Employee() { Name = "Oliver Walker", Salary = 95000m, JoiningDate = new DateTime(2013, 1, 14), Position = "CTO" },
            new Employee() { Name = "Ava Martinez", Salary = 72000m, JoiningDate = new DateTime(2017, 6, 1), Position = "Business Analyst" },
            new Employee() { Name = "Ethan Robinson", Salary = 85000m, JoiningDate = new DateTime(2016, 9, 17), Position = "Backend Developer" },
            new Employee() { Name = "Mia Gonzalez", Salary = 60000m, JoiningDate = new DateTime(2019, 3, 23), Position = "Content Writer" },
            new Employee() { Name = "Alexander Lee", Salary = 105000m, JoiningDate = new DateTime(2011, 12, 5), Position = "Senior Software Engineer" },
            new Employee() { Name = "Charlotte Harris", Salary = 68000m, JoiningDate = new DateTime(2020, 7, 8), Position = "Graphic Designer" },
            new Employee() { Name = "Samuel King", Salary = 57000m, JoiningDate = new DateTime(2018, 5, 30), Position = "QA Engineer" },
            new Employee() { Name = "Zoe Scott", Salary = 63000m, JoiningDate = new DateTime(2019, 2, 22), Position = "Customer Support" },
            new Employee() { Name = "Jack Adams", Salary = 54000m, JoiningDate = new DateTime(2020, 6, 11), Position = "Financial Analyst" },
            new Employee() { Name = "Amelia Baker", Salary = 78000m, JoiningDate = new DateTime(2015, 4, 20), Position = "Marketing Manager" },
            new Employee() { Name = "Henry Harris", Salary = 92000m, JoiningDate = new DateTime(2012, 8, 9), Position = "CFO" },
        };

        private Dictionary<string, string> columnFormats = new()
        {
            { "Salary", "C2" }, // $62,000.00
            { "JoiningDate", "dd-MMM-yyyy" }, // 10-Apr-2018
            { "YearsAtCompany", "N0" } // 5
        };

        // Booking Date Template
        private static RenderFragment<Employee> slryDtl => employee => builder =>
        {
            builder.OpenElement(0, "span");
            builder.AddAttribute(1, "class", "text-success fw-bold");
            builder.AddContent(2, @employee.Salary.ToString("C0"));
            builder.CloseElement();
        };

        // FromTime Template (24-hour format)
        private static RenderFragment<Employee> yrDtl => employee => builder =>
        {
            builder.OpenElement(0, "span");
            builder.AddAttribute(1, "class", "badge bg-info");
            builder.AddContent(2, @employee.YearsAtCompany);
            builder.CloseElement();
        };

        private List<ColumnConfigWithOrder<Employee>> clmnOrderConfigs => new() {
            new() { PropertyName = "Name", Header = "👤 Name", Align = "left", Order = 1 },
            new() { PropertyName = "Position", Header = "🎯 Position", Align = "center", Order = 2 },
            new() { PropertyName = "Salary", Header = "💰 Salary", Align = "right", Order = 3, Template = slryDtl },
            new () { PropertyName = "YearsAtCompany", Header = "⏳ Yrs @ Co.", Align = "center", Order = 4, Template = yrDtl }
        };

        private void EditEmployee(Employee emp)
        {
            Console.WriteLine($"Edit clicked for: {emp.Name}");
            // show modal or navigate to edit
        }

        private void DeleteEmployee(Employee emp)
        {
            Console.WriteLine($"Delete clicked for: {emp.Name}");
            employees.Remove(emp);
        }
    }
}
