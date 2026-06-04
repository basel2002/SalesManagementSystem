using CodeFirst.Context;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjectForm
{
    public partial class EmployeeForm : Form
    {
        private MyContext db;
        private List<Employee> employees = new();
        private List<Office> offices = new();

        public EmployeeForm(MyContext context)
        {
            InitializeComponent();
            db = context ?? throw new ArgumentNullException(nameof(context));
            RefreshEmployeeGrid();
            LoadOffices();
            LoadManagers();
            EnableTextBoxes(false);
            btnUpdate.Enabled = false;
        }

        private void RefreshEmployeeGrid()
        {
            try
            {
                employees = db.Employees.Include("Office").Include("Manager").ToList();
                dgvEmployees.DataSource = null;
                dgvEmployees.DataSource = employees.Select(e => new
                {
                    e.ID,
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Extension,
                    e.Email,
                    OfficeName = e.Office?.City ?? "N/A",
                    ManagerName = e.Manager?.FirstName + " " + e.Manager?.LastName ?? "N/A"
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOffices()
        {
            try
            {
                offices = db.Offices.ToList();
                cmbOfficeCode.DataSource = null;
                cmbOfficeCode.DisplayMember = "Code";
                cmbOfficeCode.ValueMember = "Code";
                cmbOfficeCode.DataSource = offices;
                cmbOfficeCode.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading offices: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadManagers()
        {
            try
            {
                var managers = db.Employees.ToList();
                cmbReportsTo.DataSource = null;
                cmbReportsTo.DisplayMember = "FirstName";
                cmbReportsTo.ValueMember = "ID";
                cmbReportsTo.DataSource = managers;
                cmbReportsTo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading managers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableTextBoxes(true);
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            dgvEmployees.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFirstName.Text))
                {
                    MessageBox.Show("First name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    MessageBox.Show("Last name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? reportsTo = null;
                if (cmbReportsTo.SelectedValue != null && int.TryParse(cmbReportsTo.SelectedValue.ToString(), out int repId))
                    reportsTo = repId;

                var newEmployee = new Employee
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    JobTitle = txtJobTitle.Text,
                    Extension = txtExtension.Text,
                    Email = txtEmail.Text,
                    OfficeCode = cmbOfficeCode.SelectedValue != null ? (int)cmbOfficeCode.SelectedValue : null,
                    ReportsTo = reportsTo
                };

                db.Employees.Add(newEmployee);
                db.SaveChanges();

                MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshEmployeeGrid();
                ClearForm();
                EnableTextBoxes(false);
                btnAdd.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmployees.CurrentRow == null)
                {
                    MessageBox.Show("Please select an employee to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text))
                {
                    MessageBox.Show("First name and last name are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedId = (int)dgvEmployees.CurrentRow.Cells["ID"].Value;
                var employee = db.Employees.FirstOrDefault(e => e.ID == selectedId);

                if (employee == null)
                {
                    MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                employee.FirstName = txtFirstName.Text;
                employee.LastName = txtLastName.Text;
                employee.JobTitle = txtJobTitle.Text;
                employee.Extension = txtExtension.Text;
                employee.Email = txtEmail.Text;
                employee.OfficeCode = cmbOfficeCode.SelectedValue != null ? (int)cmbOfficeCode.SelectedValue : null;

                if (cmbReportsTo.SelectedValue != null && int.TryParse(cmbReportsTo.SelectedValue.ToString(), out int repId))
                    employee.ReportsTo = repId;
                else
                    employee.ReportsTo = null;

                db.SaveChanges();
                MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshEmployeeGrid();
                ClearForm();
                EnableTextBoxes(false);
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmployees.CurrentRow == null)
                {
                    MessageBox.Show("Please select an employee to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedId = (int)dgvEmployees.CurrentRow.Cells["ID"].Value;
                var employee = db.Employees.FirstOrDefault(e => e.ID == selectedId);

                if (employee == null)
                {
                    MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Are you sure you want to delete employee '{employee.FirstName} {employee.LastName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                    MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshEmployeeGrid();
                    ClearForm();
                    EnableTextBoxes(false);
                    btnUpdate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableTextBoxes(false);
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            dgvEmployees.ClearSelection();
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvEmployees.Rows.Count)
                    return;

                int selectedId = (int)dgvEmployees.CurrentRow.Cells["ID"].Value;
                var selectedEmployee = db.Employees.Include("Office").Include("Manager").FirstOrDefault(e => e.ID == selectedId);

                if (selectedEmployee != null)
                {
                    txtFirstName.Text = selectedEmployee.FirstName ?? "";
                    txtLastName.Text = selectedEmployee.LastName ?? "";
                    txtJobTitle.Text = selectedEmployee.JobTitle ?? "";
                    txtExtension.Text = selectedEmployee.Extension ?? "";
                    txtEmail.Text = selectedEmployee.Email ?? "";

                    if (selectedEmployee.OfficeCode.HasValue)
                        cmbOfficeCode.SelectedValue = selectedEmployee.OfficeCode;
                    else
                        cmbOfficeCode.SelectedIndex = -1;

                    if (selectedEmployee.ReportsTo.HasValue)
                        cmbReportsTo.SelectedValue = selectedEmployee.ReportsTo;
                    else
                        cmbReportsTo.SelectedIndex = -1;

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
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtJobTitle.Text = "";
            txtExtension.Text = "";
            txtEmail.Text = "";
            cmbOfficeCode.SelectedIndex = -1;
            cmbReportsTo.SelectedIndex = -1;
        }

        private void EnableTextBoxes(bool enable)
        {
            txtFirstName.Enabled = enable;
            txtLastName.Enabled = enable;
            txtJobTitle.Enabled = enable;
            txtExtension.Enabled = enable;
            txtEmail.Enabled = enable;
            cmbOfficeCode.Enabled = enable;
            cmbReportsTo.Enabled = enable;
        }
    }
}
