using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmployeeList
{
    public partial class Form1 : Form
    {
        private List<Employee> employees;

        public Form1()
        {
            InitializeComponent();
            employees = new List<Employee>();
        }

        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string id = textBoxID.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Please enter both name and ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            employees.Add(new Employee { Name = name, ID = id });
            textBoxName.Clear();
            textBoxID.Clear();
            MessageBox.Show("Employee added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonViewEmployees_Click(object sender, EventArgs e)
        {
            if (employees.Count == 0)
            {
                MessageBox.Show("No employees to display.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string employeeList = "Current Employees:\n";
            foreach (var employee in employees)
            {
                employeeList += $"Name: {employee.Name}, ID: {employee.ID}\n";
            }

            MessageBox.Show(employeeList, "Employee List", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
}
