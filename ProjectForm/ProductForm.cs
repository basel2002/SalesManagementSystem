using CodeFirst.Context;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProjectForm
{
    public partial class ProductForm : Form
    {
        private MyContext db;
        private List<Product> products = new();
        private List<ProductLine> productLines = new();

        public ProductForm(MyContext context)
        {
            InitializeComponent();
            db = context ?? throw new ArgumentNullException(nameof(context));
            RefreshProductGrid();
            LoadProductLines();
            EnableTextBoxes(false);
            btnUpdate.Enabled = false;
        }

        private void RefreshProductGrid()
        {
            try
            {
                products = db.Products.Include("ProductLine").ToList();
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = products.Select(p => new
                {
                    p.Code,
                    p.Name,
                    p.Scale,
                    p.PdtDescription,
                    p.QtyInStock,
                    p.Vendor,
                    p.BuyPrice,
                    p.MSRP,
                    ProductLineName = p.ProductLine?.DescinText ?? "N/A"
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductLines()
        {
            try
            {
                productLines = db.ProductLines.ToList();
                cmbProductLine.DataSource = null;
                cmbProductLine.DisplayMember = "DescinText";
                cmbProductLine.ValueMember = "ID";
                cmbProductLine.DataSource = productLines;
                cmbProductLine.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product lines: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableTextBoxes(true);
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            dgvProducts.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Product name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbProductLine.SelectedValue == null)
                {
                    MessageBox.Show("Please select a Product Line.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? scale = null;
                if (!string.IsNullOrWhiteSpace(txtScale.Text) && int.TryParse(txtScale.Text, out int s))
                    scale = s;

                int stock = 0;
                if (!string.IsNullOrWhiteSpace(txtStock.Text) && int.TryParse(txtStock.Text, out int st))
                    stock = st;

                decimal buyPrice = 0;
                if (!string.IsNullOrWhiteSpace(txtBuyPrice.Text) && decimal.TryParse(txtBuyPrice.Text, out decimal bp))
                    buyPrice = bp;

                var newProduct = new Product
                {
                    Name = txtName.Text,
                    Scale = scale,
                    PdtDescription = txtDescription.Text,
                    QtyInStock = stock,
                    Vendor = txtVendor.Text,
                    BuyPrice = buyPrice,
                    MSRP = txtMSRP.Text,
                    ProductLineID = (int)cmbProductLine.SelectedValue
                };

                db.Products.Add(newProduct);
                db.SaveChanges();

                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshProductGrid();
                ClearForm();
                EnableTextBoxes(false);
                btnAdd.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProducts.CurrentRow == null)
                {
                    MessageBox.Show("Please select a product to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Product name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbProductLine.SelectedValue == null)
                {
                    MessageBox.Show("Please select a Product Line.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedCode = (int)dgvProducts.CurrentRow.Cells["Code"].Value;
                var product = db.Products.FirstOrDefault(p => p.Code == selectedCode);

                if (product == null)
                {
                    MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                product.Name = txtName.Text;
                product.PdtDescription = txtDescription.Text;
                product.Vendor = txtVendor.Text;
                product.MSRP = txtMSRP.Text;
                product.ProductLineID = (int)cmbProductLine.SelectedValue;

                if (!string.IsNullOrWhiteSpace(txtScale.Text) && int.TryParse(txtScale.Text, out int s))
                    product.Scale = s;
                else
                    product.Scale = null;

                if (!string.IsNullOrWhiteSpace(txtStock.Text) && int.TryParse(txtStock.Text, out int st))
                    product.QtyInStock = st;

                if (!string.IsNullOrWhiteSpace(txtBuyPrice.Text) && decimal.TryParse(txtBuyPrice.Text, out decimal bp))
                    product.BuyPrice = bp;

                db.SaveChanges();
                MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshProductGrid();
                ClearForm();
                EnableTextBoxes(false);
                btnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProducts.CurrentRow == null)
                {
                    MessageBox.Show("Please select a product to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedCode = (int)dgvProducts.CurrentRow.Cells["Code"].Value;
                var product = db.Products.FirstOrDefault(p => p.Code == selectedCode);

                if (product == null)
                {
                    MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Are you sure you want to delete product '{product.Name}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                    MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshProductGrid();
                    ClearForm();
                    EnableTextBoxes(false);
                    btnUpdate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableTextBoxes(false);
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            dgvProducts.ClearSelection();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dgvProducts.Rows.Count)
                    return;

                int selectedCode = (int)dgvProducts.CurrentRow.Cells["Code"].Value;
                var selectedProduct = db.Products.Include("ProductLine").FirstOrDefault(p => p.Code == selectedCode);

                if (selectedProduct != null)
                {
                    txtName.Text = selectedProduct.Name ?? "";
                    txtScale.Text = selectedProduct.Scale?.ToString() ?? "";
                    txtDescription.Text = selectedProduct.PdtDescription ?? "";
                    txtStock.Text = selectedProduct.QtyInStock.ToString();
                    txtVendor.Text = selectedProduct.Vendor ?? "";
                    txtBuyPrice.Text = selectedProduct.BuyPrice.ToString();
                    txtMSRP.Text = selectedProduct.MSRP ?? "";

                    if (selectedProduct.ProductLineID.HasValue)
                        cmbProductLine.SelectedValue = selectedProduct.ProductLineID;
                    else
                        cmbProductLine.SelectedIndex = -1;

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
            txtScale.Text = "";
            txtDescription.Text = "";
            txtStock.Text = "";
            txtVendor.Text = "";
            txtBuyPrice.Text = "";
            txtMSRP.Text = "";
            cmbProductLine.SelectedIndex = -1;
        }

        private void EnableTextBoxes(bool enable)
        {
            txtName.Enabled = enable;
            txtScale.Enabled = enable;
            txtDescription.Enabled = enable;
            txtStock.Enabled = enable;
            txtVendor.Enabled = enable;
            txtBuyPrice.Enabled = enable;
            txtMSRP.Enabled = enable;
            cmbProductLine.Enabled = enable;
        }
    }
}
