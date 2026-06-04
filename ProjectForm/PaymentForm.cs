using CodeFirst.Context;
using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace ProjectForm
{
    public partial class PaymentForm : Form
    {
        private MyContext db;
        private List<Payment> payments = new();
        private List<Customer> customers = new();

        public PaymentForm(MyContext context)
        {
            InitializeComponent();
            db = context ?? throw new ArgumentNullException(nameof(context));
            RefreshPaymentGrid();
            LoadCustomers();
            EnableTextBoxes(false);
            buttonUpdate.Enabled = false;
        }

        private void RefreshPaymentGrid()
        {
            try
            {
                payments = db.Payments.Include("Customer").ToList();
                dataGridViewPayments.DataSource = null;
                dataGridViewPayments.DataSource = payments.Select(p => new
                {
                    p.CheckNum,
                    CustomerName = p.Customer?.Name ?? "N/A",
                    p.PaymentDate,
                    p.Amount
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomers()
        {
            try
            {
                customers = db.Customers.ToList();
                comboBoxCustomer.DataSource = null;
                comboBoxCustomer.DisplayMember = "Name";
                comboBoxCustomer.ValueMember = "ID";
                comboBoxCustomer.DataSource = customers;
                comboBoxCustomer.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            EnableTextBoxes(true);
            buttonAdd.Enabled = true;
            buttonUpdate.Enabled = false;
            dataGridViewPayments.ClearSelection();
            dateTimePickerPaymentDate.Value = DateTime.Now;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxCheckNum.Text))
                {
                    MessageBox.Show("Check Number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxCustomer.SelectedValue == null || !(comboBoxCustomer.SelectedValue is int))
                {
                    MessageBox.Show("Please select a Customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(textBoxAmount.Text, out decimal amount))
                {
                    MessageBox.Show("Amount must be a valid decimal number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (amount <= 0)
                {
                    MessageBox.Show("Amount must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check for duplicate check number
                var exists = db.Payments.Any(p => p.CheckNum == textBoxCheckNum.Text);
                if (exists)
                {
                    MessageBox.Show("A payment with this Check Number already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newPayment = new Payment
                {
                    CheckNum = textBoxCheckNum.Text,
                    CustomerID = (int)comboBoxCustomer.SelectedValue,
                    PaymentDate = dateTimePickerPaymentDate.Value,
                    Amount = amount
                };

                db.Payments.Add(newPayment);
                db.SaveChanges();

                MessageBox.Show("Payment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshPaymentGrid();
                ClearTextBoxes();
                EnableTextBoxes(false);
                buttonAdd.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPayments.CurrentRow == null)
                {
                    MessageBox.Show("Please select a payment to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxCheckNum.Text))
                {
                    MessageBox.Show("Check Number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxCustomer.SelectedValue == null || !(comboBoxCustomer.SelectedValue is int))
                {
                    MessageBox.Show("Please select a Customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(textBoxAmount.Text, out decimal amount))
                {
                    MessageBox.Show("Amount must be a valid decimal number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (amount <= 0)
                {
                    MessageBox.Show("Amount must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string selectedCheckNum = (string)dataGridViewPayments.CurrentRow.Cells["CheckNum"].Value;
                var payment = db.Payments.FirstOrDefault(p => p.CheckNum == selectedCheckNum);

                if (payment == null)
                {
                    MessageBox.Show("Payment not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check for duplicate check number (excluding current record)
                var exists = db.Payments.Any(p => p.CheckNum == textBoxCheckNum.Text && p.CheckNum != selectedCheckNum);
                if (exists)
                {
                    MessageBox.Show("A payment with this Check Number already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                payment.CheckNum = textBoxCheckNum.Text;
                payment.CustomerID = (int)comboBoxCustomer.SelectedValue;
                payment.PaymentDate = dateTimePickerPaymentDate.Value;
                payment.Amount = amount;

                db.SaveChanges();
                MessageBox.Show("Payment updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshPaymentGrid();
                ClearTextBoxes();
                EnableTextBoxes(false);
                buttonUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPayments.CurrentRow == null)
                {
                    MessageBox.Show("Please select a payment to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string selectedCheckNum = (string)dataGridViewPayments.CurrentRow.Cells["CheckNum"].Value;
                var payment = db.Payments.FirstOrDefault(p => p.CheckNum == selectedCheckNum);

                if (payment == null)
                {
                    MessageBox.Show("Payment not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Are you sure you want to delete payment {payment.CheckNum}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Payments.Remove(payment);
                    db.SaveChanges();
                    MessageBox.Show("Payment deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshPaymentGrid();
                    ClearTextBoxes();
                    EnableTextBoxes(false);
                    buttonUpdate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            EnableTextBoxes(false);
            buttonAdd.Enabled = false;
            buttonUpdate.Enabled = false;
            dataGridViewPayments.ClearSelection();
        }

        private void dataGridViewPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dataGridViewPayments.Rows.Count)
                    return;

                string selectedCheckNum = (string)dataGridViewPayments.CurrentRow.Cells["CheckNum"].Value;
                var selectedPayment = db.Payments.Include("Customer").FirstOrDefault(p => p.CheckNum == selectedCheckNum);

                if (selectedPayment != null)
                {
                    textBoxCheckNum.Text = selectedPayment.CheckNum ?? "";
                    comboBoxCustomer.SelectedValue = selectedPayment.CustomerID;
                    dateTimePickerPaymentDate.Value = selectedPayment.PaymentDate ?? DateTime.Now;
                    textBoxAmount.Text = selectedPayment.Amount?.ToString() ?? "";

                    EnableTextBoxes(true);
                    buttonAdd.Enabled = false;
                    buttonUpdate.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearTextBoxes()
        {
            textBoxCheckNum.Text = "";
            comboBoxCustomer.SelectedIndex = -1;
            dateTimePickerPaymentDate.Value = DateTime.Now;
            textBoxAmount.Text = "";
        }

        private void EnableTextBoxes(bool enable)
        {
            textBoxCheckNum.Enabled = enable;
            comboBoxCustomer.Enabled = enable;
            dateTimePickerPaymentDate.Enabled = enable;
            textBoxAmount.Enabled = enable;
        }
    }
}
