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
            string address = textBoxAddress.Text;
            string phone = textBoxPhone.Text;
            string jobTitle = comboBoxJobTitle.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(id) || comboBoxJobTitle.SelectedIndex == -1)
            {
                string extraMessage;
                extraMessage = (comboBoxJobTitle.SelectedIndex == -1) ? "No Job Title given. " : "";

                MessageBox.Show($"Please enter input for all fields. {extraMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            employees.Add(new Employee { Name = name, ID = id, JobTitle = jobTitle, Address = address, Phone = phone });
            clearEmployeeFields();
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
                employeeList += $" Name: {employee.Name}\n Job: {employee.JobTitle}\n ID: {employee.ID}\n Address: {employee.Address}\n Phone: {employee.Phone}\n\n";
            }

            MessageBox.Show(employeeList, "Employee List", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clearEmployeeFields()
        {
            textBoxName.Clear();
            textBoxID.Clear();
            textBoxAddress.Clear();
            textBoxPhone.Clear();
            comboBoxJobTitle.SelectedIndex = -1;
            comboBoxJobTitle.Text = "Select Job Title...";
        }

        private void comboBoxJobTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }
    }
}
