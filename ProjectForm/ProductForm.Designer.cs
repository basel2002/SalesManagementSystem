namespace ProjectForm
{
    partial class ProductForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvProducts = new DataGridView();
            lblName = new Label();
            txtName = new TextBox();
            lblScale = new Label();
            txtScale = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            lblStock = new Label();
            txtStock = new TextBox();
            lblVendor = new Label();
            txtVendor = new TextBox();
            lblBuyPrice = new Label();
            txtBuyPrice = new TextBox();
            lblMSRP = new Label();
            txtMSRP = new TextBox();
            lblProductLine = new Label();
            cmbProductLine = new ComboBox();
            btnCreate = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();

            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(12, 12);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowTemplate.Height = 25;
            dgvProducts.Size = new Size(776, 250);
            dgvProducts.TabIndex = 0;
            dgvProducts.CellClick += dgvProducts_CellClick;

            lblName.AutoSize = true;
            lblName.Location = new Point(12, 280);
            lblName.Name = "lblName";
            lblName.Size = new Size(49, 15);
            lblName.TabIndex = 1;
            lblName.Text = "Name:";

            txtName.Location = new Point(93, 277);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 2;

            lblScale.AutoSize = true;
            lblScale.Location = new Point(12, 310);
            lblScale.Name = "lblScale";
            lblScale.Size = new Size(42, 15);
            lblScale.TabIndex = 3;
            lblScale.Text = "Scale:";

            txtScale.Location = new Point(93, 307);
            txtScale.Name = "txtScale";
            txtScale.Size = new Size(200, 23);
            txtScale.TabIndex = 4;

            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(12, 340);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(79, 15);
            lblDescription.TabIndex = 5;
            lblDescription.Text = "Description:";

            txtDescription.Location = new Point(93, 337);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(200, 23);
            txtDescription.TabIndex = 6;

            lblStock.AutoSize = true;
            lblStock.Location = new Point(12, 370);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(43, 15);
            lblStock.TabIndex = 7;
            lblStock.Text = "Stock:";

            txtStock.Location = new Point(93, 367);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(200, 23);
            txtStock.TabIndex = 8;

            lblVendor.AutoSize = true;
            lblVendor.Location = new Point(400, 280);
            lblVendor.Name = "lblVendor";
            lblVendor.Size = new Size(51, 15);
            lblVendor.TabIndex = 9;
            lblVendor.Text = "Vendor:";

            txtVendor.Location = new Point(481, 277);
            txtVendor.Name = "txtVendor";
            txtVendor.Size = new Size(200, 23);
            txtVendor.TabIndex = 10;

            lblBuyPrice.AutoSize = true;
            lblBuyPrice.Location = new Point(400, 310);
            lblBuyPrice.Name = "lblBuyPrice";
            lblBuyPrice.Size = new Size(65, 15);
            lblBuyPrice.TabIndex = 11;
            lblBuyPrice.Text = "Buy Price:";

            txtBuyPrice.Location = new Point(481, 307);
            txtBuyPrice.Name = "txtBuyPrice";
            txtBuyPrice.Size = new Size(200, 23);
            txtBuyPrice.TabIndex = 12;

            lblMSRP.AutoSize = true;
            lblMSRP.Location = new Point(400, 340);
            lblMSRP.Name = "lblMSRP";
            lblMSRP.Size = new Size(47, 15);
            lblMSRP.TabIndex = 13;
            lblMSRP.Text = "MSRP:";

            txtMSRP.Location = new Point(481, 337);
            txtMSRP.Name = "txtMSRP";
            txtMSRP.Size = new Size(200, 23);
            txtMSRP.TabIndex = 14;

            lblProductLine.AutoSize = true;
            lblProductLine.Location = new Point(12, 400);
            lblProductLine.Name = "lblProductLine";
            lblProductLine.Size = new Size(82, 15);
            lblProductLine.TabIndex = 15;
            lblProductLine.Text = "Product Line:";

            cmbProductLine.FormattingEnabled = true;
            cmbProductLine.Location = new Point(93, 397);
            cmbProductLine.Name = "cmbProductLine";
            cmbProductLine.Size = new Size(200, 23);
            cmbProductLine.TabIndex = 16;

            btnCreate.Location = new Point(12, 440);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 17;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;

            btnAdd.Location = new Point(93, 440);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 18;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            btnUpdate.Location = new Point(174, 440);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 19;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;

            btnDelete.Location = new Point(255, 440);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            btnClear.Location = new Point(336, 440);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 21;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 490);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnCreate);
            Controls.Add(cmbProductLine);
            Controls.Add(lblProductLine);
            Controls.Add(txtMSRP);
            Controls.Add(lblMSRP);
            Controls.Add(txtBuyPrice);
            Controls.Add(lblBuyPrice);
            Controls.Add(txtVendor);
            Controls.Add(lblVendor);
            Controls.Add(txtStock);
            Controls.Add(lblStock);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(txtScale);
            Controls.Add(lblScale);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(dgvProducts);
            Name = "ProductForm";
            Text = "Product Management";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dgvProducts;
        private Label lblName;
        private TextBox txtName;
        private Label lblScale;
        private TextBox txtScale;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblStock;
        private TextBox txtStock;
        private Label lblVendor;
        private TextBox txtVendor;
        private Label lblBuyPrice;
        private TextBox txtBuyPrice;
        private Label lblMSRP;
        private TextBox txtMSRP;
        private Label lblProductLine;
        private ComboBox cmbProductLine;
        private Button btnCreate;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
    }
}
