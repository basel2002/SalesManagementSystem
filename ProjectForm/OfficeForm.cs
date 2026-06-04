using CodeFirst.Context;
using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjectForm
{
    public partial class OfficeForm : Form
    {
        private MyContext db;
        private List<Office> offices = new();

        public OfficeForm(MyContext context)
        {
            InitializeComponent();
            db = context ?? throw new ArgumentNullException(nameof(context));
            RefreshOfficeGrid();
            EnableTextBoxes(false);
            btnUpdate.Enabled = false;
        }

        private void RefreshOfficeGrid()
        {
            try
            {
                offices = db.Offices.ToList();
                dgvOffices.DataSource = null;
                dgvOffices.DataSource = offices.Select(o => new
                {
                    o.Code,
                    o.City,
                    o.Phone,
                    o.Address1,
                    o.State,
                    o.PostalCode,
                    o.Country,
                    o.Territory
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading offices: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableTextBoxes(true);
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            dgvOffices.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCity.Text))
                {
                    MessageBox.Show("City is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? postalCode = null;
                if (!string.IsNullOrWhiteSpace(txtPostalCode.Text) && int.TryParse(txtPostalCode.Text, out int pc))
                    postalCode = pc;

                var newOffice = new Office
                {
                    City = txtCity.Text,
                    Phone = txtPhone.Text,
                    Address1 = txtAddress.Text,
                    State = txtState.Text,
                    PostalCode = postalCode,
                    Country = txtCountry.Text,
                    Territory = txtTerritory.Text
                };

                db.Offices.Add(newOffice);
                db.SaveChanges();

                MessageBox.Show("Office added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshOfficeGrid();
                ClearForm();
                EnableTextBoxes(false);
                btnAdd.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding office: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOffices.CurrentRow == null)
                {
                    MessageBox.Show("Please select an office to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCity.Text))
                {
                    MessageBox.Show("City is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedCode = (int)dgvOffices.CurrentRow.Cells["Code"].Value;
                var office = db.Offices.FirstOrDefault(o => o.Code == selectedCode);

                if (office == null)
                {
                    MessageBox.Show("Office not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                office.City = txtCity.Text;
                office.Phone = txtPhone.Text;
                office.Address1 = txtAddress.Text;
                office.State = txtState.Text;
                office.Country = txtCountry.Text;
                office.Territory = txtTerritory.Text;

                if (!string.IsNullOrWhiteSpace(txtPostalCode.Text) && int.TryParse(txtPostalCode.Text, out int pc))
                    office.PostalCode = pc;
                else
                    office.PostalCode = null;

                db.SaveChanges();
                MessageBox.Show("Office updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshOfficeGrid();
                ClearForm();
                EnableTextBoxes(false);
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating office: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOffices.CurrentRow == null)
                {
                    MessageBox.Show("Please select an office to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedCode = (int)dgvOffices.CurrentRow.Cells["Code"].Value;
                var office = db.Offices.FirstOrDefault(o => o.Code == selectedCode);

                if (office == null)
                {
                    MessageBox.Show("Office not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Are you sure you want to delete office '{office.City}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Offices.Remove(office);
                    db.SaveChanges();
                    MessageBox.Show("Office deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshOfficeGrid();
                    ClearForm();
                    EnableTextBoxes(false);
                    btnUpdate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting office: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableTextBoxes(false);
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            dgvOffices.ClearSelection();
        }

        private void dgvOffices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvOffices.Rows.Count)
                    return;

                int selectedCode = (int)dgvOffices.CurrentRow.Cells["Code"].Value;
                var selectedOffice = db.Offices.FirstOrDefault(o => o.Code == selectedCode);

                if (selectedOffice != null)
                {
                    txtCity.Text = selectedOffice.City ?? "";
                    txtPhone.Text = selectedOffice.Phone ?? "";
                    txtAddress.Text = selectedOffice.Address1 ?? "";
                    txtState.Text = selectedOffice.State ?? "";
                    txtPostalCode.Text = selectedOffice.PostalCode?.ToString() ?? "";
                    txtCountry.Text = selectedOffice.Country ?? "";
                    txtTerritory.Text = selectedOffice.Territory ?? "";

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
            txtCity.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtState.Text = "";
            txtPostalCode.Text = "";
            txtCountry.Text = "";
            txtTerritory.Text = "";
        }

        private void EnableTextBoxes(bool enable)
        {
            txtCity.Enabled = enable;
            txtPhone.Enabled = enable;
            txtAddress.Enabled = enable;
            txtState.Enabled = enable;
            txtPostalCode.Enabled = enable;
            txtCountry.Enabled = enable;
            txtTerritory.Enabled = enable;
        }
    }
}
