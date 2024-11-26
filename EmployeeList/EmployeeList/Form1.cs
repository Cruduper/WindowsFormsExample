﻿using System;
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

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Please enter both name and ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            employees.Add(new Employee { Name = name, ID = id, Address = address, Phone = phone });
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
                employeeList += $"Name: {employee.Name}, ID: {employee.ID}, Address: {employee.Address}, Phone: {employee.Phone}\n";
            }

            MessageBox.Show(employeeList, "Employee List", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void clearEmployeeFields()
        {
            textBoxName.Clear();
            textBoxID.Clear();
            textBoxAddress.Clear();
            textBoxPhone.Clear();
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
