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
    public partial class OrderProductForm : Form
    {
        private MyContext db;
        private List<Order_product> orderProducts = new();
        private List<Order> orders = new();
        private List<Product> products = new();

        public OrderProductForm(MyContext context)
        {
            InitializeComponent();
            db = context ?? throw new ArgumentNullException(nameof(context));
            RefreshOrderProductGrid();
            LoadOrders();
            LoadProducts();
            EnableTextBoxes(false);
            buttonUpdate.Enabled = false;
        }

        private void RefreshOrderProductGrid()
        {
            try
            {
                orderProducts = db.Orders_products
                    .Include("Order")
                    .Include("Product")
                    .ToList();

                dataGridViewOrderProducts.DataSource = null;
                dataGridViewOrderProducts.DataSource = orderProducts.Select(op => new
                {
                    op.ID,
                    op.OrderID,
                    ProductName = op.Product?.Name ?? "N/A",
                    op.Qty,
                    op.PriceEach
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrders()
        {
            try
            {
                orders = db.Orders.ToList();
                comboBoxOrder.DataSource = null;
                comboBoxOrder.DisplayMember = "ID";
                comboBoxOrder.ValueMember = "ID";
                comboBoxOrder.DataSource = orders;
                comboBoxOrder.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                products = db.Products.ToList();
                comboBoxProduct.DataSource = null;
                comboBoxProduct.DisplayMember = "Name";
                comboBoxProduct.ValueMember = "Code";
                comboBoxProduct.DataSource = products;
                comboBoxProduct.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            EnableTextBoxes(true);
            buttonAdd.Enabled = true;
            buttonUpdate.Enabled = false;
            dataGridViewOrderProducts.ClearSelection();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxOrder.SelectedValue == null || !(comboBoxOrder.SelectedValue is int))
                {
                    MessageBox.Show("Please select an Order.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxProduct.SelectedValue == null || !(comboBoxProduct.SelectedValue is int))
                {
                    MessageBox.Show("Please select a Product.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBoxQty.Text, out int qty))
                {
                    MessageBox.Show("Quantity must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (qty <= 0)
                {
                    MessageBox.Show("Quantity must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(textBoxPriceEach.Text, out decimal priceEach))
                {
                    MessageBox.Show("Price must be a valid decimal number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (priceEach < 0)
                {
                    MessageBox.Show("Price cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int orderId = (int)comboBoxOrder.SelectedValue;
                int productCode = (int)comboBoxProduct.SelectedValue;

                // Check for duplicate order_product combination
                var exists = db.Orders_products.Any(op => op.OrderID == orderId && op.ProductCode == productCode);
                if (exists)
                {
                    MessageBox.Show("This product is already in this order.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newOrderProduct = new Order_product
                {
                    OrderID = orderId,
                    ProductCode = productCode,
                    Qty = qty,
                    PriceEach = priceEach
                };

                db.Orders_products.Add(newOrderProduct);
                db.SaveChanges();

                MessageBox.Show("Order Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshOrderProductGrid();
                ClearTextBoxes();
                EnableTextBoxes(false);
                buttonAdd.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding order product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewOrderProducts.CurrentRow == null)
                {
                    MessageBox.Show("Please select an order product to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxOrder.SelectedValue == null || !(comboBoxOrder.SelectedValue is int))
                {
                    MessageBox.Show("Please select an Order.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBoxProduct.SelectedValue == null || !(comboBoxProduct.SelectedValue is int))
                {
                    MessageBox.Show("Please select a Product.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBoxQty.Text, out int qty))
                {
                    MessageBox.Show("Quantity must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (qty <= 0)
                {
                    MessageBox.Show("Quantity must be greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(textBoxPriceEach.Text, out decimal priceEach))
                {
                    MessageBox.Show("Price must be a valid decimal number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (priceEach < 0)
                {
                    MessageBox.Show("Price cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int opId = (int)dataGridViewOrderProducts.CurrentRow.Cells["ID"].Value;
                var orderProduct = db.Orders_products.FirstOrDefault(op => op.ID == opId);

                if (orderProduct == null)
                {
                    MessageBox.Show("Order Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                orderProduct.OrderID = (int)comboBoxOrder.SelectedValue;
                orderProduct.ProductCode = (int)comboBoxProduct.SelectedValue;
                orderProduct.Qty = qty;
                orderProduct.PriceEach = priceEach;

                db.SaveChanges();
                MessageBox.Show("Order Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshOrderProductGrid();
                ClearTextBoxes();
                EnableTextBoxes(false);
                buttonUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating order product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewOrderProducts.CurrentRow == null)
                {
                    MessageBox.Show("Please select an order product to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int opId = (int)dataGridViewOrderProducts.CurrentRow.Cells["ID"].Value;
                var orderProduct = db.Orders_products.FirstOrDefault(op => op.ID == opId);

                if (orderProduct == null)
                {
                    MessageBox.Show("Order Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Are you sure you want to delete this order product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Orders_products.Remove(orderProduct);
                    db.SaveChanges();
                    MessageBox.Show("Order Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshOrderProductGrid();
                    ClearTextBoxes();
                    EnableTextBoxes(false);
                    buttonUpdate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting order product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            EnableTextBoxes(false);
            buttonAdd.Enabled = false;
            buttonUpdate.Enabled = false;
            dataGridViewOrderProducts.ClearSelection();
        }

        private void dataGridViewOrderProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dataGridViewOrderProducts.Rows.Count)
                    return;

                int opId = (int)dataGridViewOrderProducts.CurrentRow.Cells["ID"].Value;
                var selectedOrderProduct = db.Orders_products
                    .Include("Order")
                    .Include("Product")
                    .FirstOrDefault(op => op.ID == opId);

                if (selectedOrderProduct != null)
                {
                    comboBoxOrder.SelectedValue = selectedOrderProduct.OrderID;
                    comboBoxProduct.SelectedValue = selectedOrderProduct.ProductCode;
                    textBoxQty.Text = selectedOrderProduct.Qty?.ToString() ?? "";
                    textBoxPriceEach.Text = selectedOrderProduct.PriceEach?.ToString() ?? "";

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
            comboBoxOrder.SelectedIndex = -1;
            comboBoxProduct.SelectedIndex = -1;
            textBoxQty.Text = "";
            textBoxPriceEach.Text = "";
        }

        private void EnableTextBoxes(bool enable)
        {
            comboBoxOrder.Enabled = enable;
            comboBoxProduct.Enabled = enable;
            textBoxQty.Enabled = enable;
            textBoxPriceEach.Enabled = enable;
        }
    }
}
