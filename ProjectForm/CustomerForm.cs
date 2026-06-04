using CodeFirst.Context;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjectForm
{
    public partial class CustomerForm : Form
    {
        private MyContext db;
        private List<Customer> customers = new();
        private List<Employee> employees = new();

        public CustomerForm(MyContext context)
        {
            InitializeComponent();
            db = context ?? throw new ArgumentNullException(nameof(context));
            RefreshCustomerGrid();
            LoadEmployees();
            EnableTextBoxes(false);
            btnUpdate.Enabled = false;
        }

        private void RefreshCustomerGrid()
        {
            try
            {
                customers = db.Customers.Include("Employee").ToList();
                dgvCustomers.DataSource = null;
                dgvCustomers.DataSource = customers.Select(c => new
                {
                    c.ID,
                    c.Name,
                    c.FirstName,
                    c.LastName,
                    c.Phone,
                    c.Address1,
                    c.City,
                    c.State,
                    c.PostalCode,
                    c.Country,
                    c.CreditLimit,
                    SalesEmployeeName = c.Employee?.FirstName + " " + c.Employee?.LastName ?? "N/A"
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEmployees()
        {
            try
            {
                employees = db.Employees.ToList();
                cmbSalesEmployee.DataSource = null;
                cmbSalesEmployee.DisplayMember = "FirstName";
                cmbSalesEmployee.ValueMember = "ID";
                cmbSalesEmployee.DataSource = employees;
                cmbSalesEmployee.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableTextBoxes(true);
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            dgvCustomers.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Customer name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal? creditLimit = null;
                if (!string.IsNullOrWhiteSpace(txtCreditLimit.Text) && decimal.TryParse(txtCreditLimit.Text, out decimal cl))
                    creditLimit = cl;

                int? postalCode = null;
                if (!string.IsNullOrWhiteSpace(txtPostalCode.Text) && int.TryParse(txtPostalCode.Text, out int pc))
                    postalCode = pc;

                int? employeeId = null;
                if (cmbSalesEmployee.SelectedValue != null && int.TryParse(cmbSalesEmployee.SelectedValue.ToString(), out int empId))
                    employeeId = empId;

                var newCustomer = new Customer
                {
                    Name = txtName.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Phone = txtPhone.Text,
                    Address1 = txtAddress.Text,
                    City = txtCity.Text,
                    State = txtState.Text,
                    PostalCode = postalCode,
                    Country = txtCountry.Text,
                    CreditLimit = creditLimit,
                    SalesRepEmployeeNum = employeeId
                };

                db.Customers.Add(newCustomer);
                db.SaveChanges();

                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshCustomerGrid();
                ClearForm();
                EnableTextBoxes(false);
                btnAdd.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomers.CurrentRow == null)
                {
                    MessageBox.Show("Please select a customer to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Customer name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedId = (int)dgvCustomers.CurrentRow.Cells["ID"].Value;
                var customer = db.Customers.FirstOrDefault(c => c.ID == selectedId);

                if (customer == null)
                {
                    MessageBox.Show("Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                customer.Name = txtName.Text;
                customer.FirstName = txtFirstName.Text;
                customer.LastName = txtLastName.Text;
                customer.Phone = txtPhone.Text;
                customer.Address1 = txtAddress.Text;
                customer.City = txtCity.Text;
                customer.State = txtState.Text;
                customer.Country = txtCountry.Text;

                if (!string.IsNullOrWhiteSpace(txtPostalCode.Text) && int.TryParse(txtPostalCode.Text, out int pc))
                    customer.PostalCode = pc;
                else
                    customer.PostalCode = null;

                if (!string.IsNullOrWhiteSpace(txtCreditLimit.Text) && decimal.TryParse(txtCreditLimit.Text, out decimal cl))
                    customer.CreditLimit = cl;
                else
                    customer.CreditLimit = null;

                if (cmbSalesEmployee.SelectedValue != null && int.TryParse(cmbSalesEmployee.SelectedValue.ToString(), out int empId))
                    customer.SalesRepEmployeeNum = empId;
                else
                    customer.SalesRepEmployeeNum = null;

                db.SaveChanges();
                MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshCustomerGrid();
                ClearForm();
                EnableTextBoxes(false);
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomers.CurrentRow == null)
                {
                    MessageBox.Show("Please select a customer to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedId = (int)dgvCustomers.CurrentRow.Cells["ID"].Value;
                var customer = db.Customers.FirstOrDefault(c => c.ID == selectedId);

                if (customer == null)
                {
                    MessageBox.Show("Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Are you sure you want to delete customer '{customer.Name}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Customers.Remove(customer);
                    db.SaveChanges();
                    MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshCustomerGrid();
                    ClearForm();
                    EnableTextBoxes(false);
                    btnUpdate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableTextBoxes(false);
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            dgvCustomers.ClearSelection();
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvCustomers.Rows.Count)
                    return;

                int selectedId = (int)dgvCustomers.CurrentRow.Cells["ID"].Value;
                var selectedCustomer = db.Customers.Include("Employee").FirstOrDefault(c => c.ID == selectedId);

                if (selectedCustomer != null)
                {
                    txtName.Text = selectedCustomer.Name ?? "";
                    txtFirstName.Text = selectedCustomer.FirstName ?? "";
                    txtLastName.Text = selectedCustomer.LastName ?? "";
                    txtPhone.Text = selectedCustomer.Phone ?? "";
                    txtAddress.Text = selectedCustomer.Address1 ?? "";
                    txtCity.Text = selectedCustomer.City ?? "";
                    txtState.Text = selectedCustomer.State ?? "";
                    txtPostalCode.Text = selectedCustomer.PostalCode?.ToString() ?? "";
                    txtCountry.Text = selectedCustomer.Country ?? "";
                    txtCreditLimit.Text = selectedCustomer.CreditLimit?.ToString() ?? "";

                    if (selectedCustomer.SalesRepEmployeeNum.HasValue)
                        cmbSalesEmployee.SelectedValue = selectedCustomer.SalesRepEmployeeNum;
                    else
                        cmbSalesEmployee.SelectedIndex = -1;

                    EnableTextBoxes(true);
                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtPostalCode.Text = "";
            txtCountry.Text = "";
            txtCreditLimit.Text = "";
            cmbSalesEmployee.SelectedIndex = -1;
        }

        private void EnableTextBoxes(bool enable)
        {
            txtName.Enabled = enable;
            txtFirstName.Enabled = enable;
            txtLastName.Enabled = enable;
            txtPhone.Enabled = enable;
            txtAddress.Enabled = enable;
            txtCity.Enabled = enable;
            txtState.Enabled = enable;
            txtPostalCode.Enabled = enable;
            txtCountry.Enabled = enable;
            txtCreditLimit.Enabled = enable;
            cmbSalesEmployee.Enabled = enable;
        }
    }
}
