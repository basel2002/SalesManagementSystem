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
    public partial class OrderForm : Form
    {
        private MyContext db;
        private List<Order> orders = new();
        private List<Customer> customers = new();

        public OrderForm(MyContext context)
        {
            InitializeComponent();
            db = context ?? throw new ArgumentNullException(nameof(context));
            RefreshOrderGrid();
            LoadCustomers();
            EnableTextBoxes(false);
            buttonUpdate.Enabled = false;
        }

        private void RefreshOrderGrid()
        {
            try
            {
                orders = db.Orders.Include("Customer").ToList();
                dataGridViewOrders.DataSource = null;
                dataGridViewOrders.DataSource = orders.Select(o => new
                {
                    o.ID,
                    CustomerName = o.Customer?.Name ?? "N/A",
                    o.OrderDate,
                    o.RequiredDate,
                    o.ShippedDate,
                    o.Status,
                    o.Comments
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dataGridViewOrders.ClearSelection();
            dateTimePickerOrderDate.Value = DateTime.Now;
            dateTimePickerRequiredDate.Value = DateTime.Now;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxCustomer.SelectedValue == null || !(comboBoxCustomer.SelectedValue is int))
                {
                    MessageBox.Show("Please select a Customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime orderDate = dateTimePickerOrderDate.Value;
                DateTime requiredDate = dateTimePickerRequiredDate.Value;

                if (requiredDate < orderDate)
                {
                    MessageBox.Show("Required Date cannot be before Order Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime? shippedDate = null;
                if (dateTimePickerShippedDate.Checked)
                {
                    shippedDate = dateTimePickerShippedDate.Value;
                    if (shippedDate < orderDate)
                    {
                        MessageBox.Show("Shipped Date cannot be before Order Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                int? status = null;
                if (int.TryParse(textBoxStatus.Text, out int statusValue))
                    status = statusValue;

                var newOrder = new Order
                {
                    CustomerID = (int)comboBoxCustomer.SelectedValue,
                    OrderDate = orderDate,
                    RequiredDate = requiredDate,
                    ShippedDate = shippedDate,
                    Status = status,
                    Comments = textBoxComments.Text
                };

                db.Orders.Add(newOrder);
                db.SaveChanges();

                MessageBox.Show("Order added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshOrderGrid();
                ClearTextBoxes();
                EnableTextBoxes(false);
                buttonAdd.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewOrders.CurrentRow == null)
                {
                    MessageBox.Show("Please select an order to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxCustomer.SelectedValue == null || !(comboBoxCustomer.SelectedValue is int))
                {
                    MessageBox.Show("Please select a Customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedId = (int)dataGridViewOrders.CurrentRow.Cells["ID"].Value;
                var order = db.Orders.FirstOrDefault(o => o.ID == selectedId);

                if (order == null)
                {
                    MessageBox.Show("Order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime orderDate = dateTimePickerOrderDate.Value;
                DateTime requiredDate = dateTimePickerRequiredDate.Value;

                if (requiredDate < orderDate)
                {
                    MessageBox.Show("Required Date cannot be before Order Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime? shippedDate = null;
                if (dateTimePickerShippedDate.Checked)
                {
                    shippedDate = dateTimePickerShippedDate.Value;
                    if (shippedDate < orderDate)
                    {
                        MessageBox.Show("Shipped Date cannot be before Order Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                int? status = null;
                if (int.TryParse(textBoxStatus.Text, out int statusValue))
                    status = statusValue;

                order.CustomerID = (int)comboBoxCustomer.SelectedValue;
                order.OrderDate = orderDate;
                order.RequiredDate = requiredDate;
                order.ShippedDate = shippedDate;
                order.Status = status;
                order.Comments = textBoxComments.Text;

                db.SaveChanges();
                MessageBox.Show("Order updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshOrderGrid();
                ClearTextBoxes();
                EnableTextBoxes(false);
                buttonUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewOrders.CurrentRow == null)
                {
                    MessageBox.Show("Please select an order to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedId = (int)dataGridViewOrders.CurrentRow.Cells["ID"].Value;
                var order = db.Orders.Include("Order_Products").FirstOrDefault(o => o.ID == selectedId);

                if (order == null)
                {
                    MessageBox.Show("Order not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Are you sure you want to delete Order #{order.ID}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Orders.Remove(order);
                    db.SaveChanges();
                    MessageBox.Show("Order deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshOrderGrid();
                    ClearTextBoxes();
                    EnableTextBoxes(false);
                    buttonUpdate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            EnableTextBoxes(false);
            buttonAdd.Enabled = false;
            buttonUpdate.Enabled = false;
            dataGridViewOrders.ClearSelection();
        }

        private void dataGridViewOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dataGridViewOrders.Rows.Count)
                    return;

                int selectedId = (int)dataGridViewOrders.CurrentRow.Cells["ID"].Value;
                var selectedOrder = db.Orders.Include("Customer").FirstOrDefault(o => o.ID == selectedId);

                if (selectedOrder != null)
                {
                    comboBoxCustomer.SelectedValue = selectedOrder.CustomerID;
                    dateTimePickerOrderDate.Value = selectedOrder.OrderDate ?? DateTime.Now;
                    dateTimePickerRequiredDate.Value = selectedOrder.RequiredDate ?? DateTime.Now;

                    if (selectedOrder.ShippedDate.HasValue)
                    {
                        dateTimePickerShippedDate.Value = selectedOrder.ShippedDate.Value;
                        dateTimePickerShippedDate.Checked = true;
                    }
                    else
                    {
                        dateTimePickerShippedDate.Checked = false;
                    }

                    textBoxStatus.Text = selectedOrder.Status?.ToString() ?? "";
                    textBoxComments.Text = selectedOrder.Comments ?? "";

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
            comboBoxCustomer.SelectedIndex = -1;
            dateTimePickerOrderDate.Value = DateTime.Now;
            dateTimePickerRequiredDate.Value = DateTime.Now;
            dateTimePickerShippedDate.Checked = false;
            textBoxStatus.Text = "";
            textBoxComments.Text = "";
        }

        private void EnableTextBoxes(bool enable)
        {
            comboBoxCustomer.Enabled = enable;
            dateTimePickerOrderDate.Enabled = enable;
            dateTimePickerRequiredDate.Enabled = enable;
            dateTimePickerShippedDate.Enabled = enable;
            textBoxStatus.Enabled = enable;
            textBoxComments.Enabled = enable;
        }
    }
}
