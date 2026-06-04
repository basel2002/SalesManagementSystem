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

namespace ProjectForm
{
    public partial class ProductLineForm : Form
    {
        private MyContext db;
        private List<ProductLine> productLines = new();

        public ProductLineForm(MyContext context)
        {
            InitializeComponent();
            db = context ?? throw new ArgumentNullException(nameof(context));
            RefreshProductLineGrid();
            EnableTextBoxes(false);
            buttonUpdate.Enabled = false;
        }

        private void RefreshProductLineGrid()
        {
            try
            {
                productLines = db.ProductLines.ToList();
                dataGridViewProductLines.DataSource = null;
                dataGridViewProductLines.DataSource = productLines;

                if (dataGridViewProductLines.Columns.Count > 0)
                {
                    dataGridViewProductLines.Columns["Products"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product lines: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            EnableTextBoxes(true);
            buttonAdd.Enabled = true;
            buttonUpdate.Enabled = false;
            dataGridViewProductLines.ClearSelection();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxDescription.Text))
                {
                    MessageBox.Show("Product Line Description is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check for duplicates
                var exists = db.ProductLines.Any(pl => pl.DescinText == textBoxDescription.Text);
                if (exists)
                {
                    MessageBox.Show("A product line with this description already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newProductLine = new ProductLine
                {
                    DescinText = textBoxDescription.Text,
                    DescinHTML = textBoxHTML.Text,
                    Image = textBoxImage.Text
                };

                db.ProductLines.Add(newProductLine);
                db.SaveChanges();

                MessageBox.Show("Product Line added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshProductLineGrid();
                ClearTextBoxes();
                EnableTextBoxes(false);
                buttonAdd.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product line: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewProductLines.CurrentRow == null)
                {
                    MessageBox.Show("Please select a product line to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxDescription.Text))
                {
                    MessageBox.Show("Product Line Description is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedId = (int)dataGridViewProductLines.CurrentRow.Cells["ID"].Value;
                var productLine = db.ProductLines.FirstOrDefault(pl => pl.ID == selectedId);

                if (productLine == null)
                {
                    MessageBox.Show("Product Line not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check for duplicates (excluding current record)
                var exists = db.ProductLines.Any(pl => pl.DescinText == textBoxDescription.Text && pl.ID != selectedId);
                if (exists)
                {
                    MessageBox.Show("A product line with this description already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                productLine.DescinText = textBoxDescription.Text;
                productLine.DescinHTML = textBoxHTML.Text;
                productLine.Image = textBoxImage.Text;

                db.SaveChanges();
                MessageBox.Show("Product Line updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshProductLineGrid();
                ClearTextBoxes();
                EnableTextBoxes(false);
                buttonUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product line: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewProductLines.CurrentRow == null)
                {
                    MessageBox.Show("Please select a product line to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedId = (int)dataGridViewProductLines.CurrentRow.Cells["ID"].Value;
                var productLine = db.ProductLines.FirstOrDefault(pl => pl.ID == selectedId);

                if (productLine == null)
                {
                    MessageBox.Show("Product Line not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Are you sure you want to delete '{productLine.DescinText}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.ProductLines.Remove(productLine);
                    db.SaveChanges();
                    MessageBox.Show("Product Line deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshProductLineGrid();
                    ClearTextBoxes();
                    EnableTextBoxes(false);
                    buttonUpdate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product line: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            EnableTextBoxes(false);
            buttonAdd.Enabled = false;
            buttonUpdate.Enabled = false;
            dataGridViewProductLines.ClearSelection();
        }

        private void dataGridViewProductLines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= dataGridViewProductLines.Rows.Count)
                    return;

                dataGridViewProductLines.CurrentCell = dataGridViewProductLines.Rows[e.RowIndex].Cells[0];
                var selectedProductLine = (ProductLine)dataGridViewProductLines.Rows[e.RowIndex].DataBoundItem;

                if (selectedProductLine != null)
                {
                    textBoxDescription.Text = selectedProductLine.DescinText ?? "";
                    textBoxHTML.Text = selectedProductLine.DescinHTML ?? "";
                    textBoxImage.Text = selectedProductLine.Image ?? "";

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
            textBoxDescription.Text = "";
            textBoxHTML.Text = "";
            textBoxImage.Text = "";
        }

        private void EnableTextBoxes(bool enable)
        {
            textBoxDescription.Enabled = enable;
            textBoxHTML.Enabled = enable;
            textBoxImage.Enabled = enable;
        }
    }
}
