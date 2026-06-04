namespace ProjectForm
{
    partial class OrderProductForm
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
            dataGridViewOrderProducts = new DataGridView();
            labelOrder = new Label();
            comboBoxOrder = new ComboBox();
            labelProduct = new Label();
            comboBoxProduct = new ComboBox();
            labelQty = new Label();
            textBoxQty = new TextBox();
            labelPriceEach = new Label();
            textBoxPriceEach = new TextBox();
            buttonCreate = new Button();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrderProducts).BeginInit();
            SuspendLayout();

            dataGridViewOrderProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrderProducts.Location = new Point(12, 12);
            dataGridViewOrderProducts.Name = "dataGridViewOrderProducts";
            dataGridViewOrderProducts.RowTemplate.Height = 25;
            dataGridViewOrderProducts.Size = new Size(776, 250);
            dataGridViewOrderProducts.TabIndex = 0;
            dataGridViewOrderProducts.CellClick += dataGridViewOrderProducts_CellClick;

            labelOrder.AutoSize = true;
            labelOrder.Location = new Point(12, 280);
            labelOrder.Name = "labelOrder";
            labelOrder.Size = new Size(39, 15);
            labelOrder.TabIndex = 1;
            labelOrder.Text = "Order:";

            comboBoxOrder.FormattingEnabled = true;
            comboBoxOrder.Location = new Point(93, 277);
            comboBoxOrder.Name = "comboBoxOrder";
            comboBoxOrder.Size = new Size(200, 23);
            comboBoxOrder.TabIndex = 2;

            labelProduct.AutoSize = true;
            labelProduct.Location = new Point(12, 310);
            labelProduct.Name = "labelProduct";
            labelProduct.Size = new Size(54, 15);
            labelProduct.TabIndex = 3;
            labelProduct.Text = "Product:";

            comboBoxProduct.FormattingEnabled = true;
            comboBoxProduct.Location = new Point(93, 307);
            comboBoxProduct.Name = "comboBoxProduct";
            comboBoxProduct.Size = new Size(200, 23);
            comboBoxProduct.TabIndex = 4;

            labelQty.AutoSize = true;
            labelQty.Location = new Point(400, 280);
            labelQty.Name = "labelQty";
            labelQty.Size = new Size(64, 15);
            labelQty.TabIndex = 5;
            labelQty.Text = "Quantity:";

            textBoxQty.Location = new Point(481, 277);
            textBoxQty.Name = "textBoxQty";
            textBoxQty.Size = new Size(200, 23);
            textBoxQty.TabIndex = 6;

            labelPriceEach.AutoSize = true;
            labelPriceEach.Location = new Point(400, 310);
            labelPriceEach.Name = "labelPriceEach";
            labelPriceEach.Size = new Size(72, 15);
            labelPriceEach.TabIndex = 7;
            labelPriceEach.Text = "Price Each:";

            textBoxPriceEach.Location = new Point(481, 307);
            textBoxPriceEach.Name = "textBoxPriceEach";
            textBoxPriceEach.Size = new Size(200, 23);
            textBoxPriceEach.TabIndex = 8;

            buttonCreate.Location = new Point(12, 350);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(75, 23);
            buttonCreate.TabIndex = 9;
            buttonCreate.Text = "Create";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;

            buttonAdd.Location = new Point(93, 350);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 10;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;

            buttonUpdate.Location = new Point(174, 350);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 23);
            buttonUpdate.TabIndex = 11;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;

            buttonDelete.Location = new Point(255, 350);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 12;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;

            buttonClear.Location = new Point(336, 350);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(75, 23);
            buttonClear.TabIndex = 13;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonClear);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Controls.Add(buttonCreate);
            Controls.Add(textBoxPriceEach);
            Controls.Add(labelPriceEach);
            Controls.Add(textBoxQty);
            Controls.Add(labelQty);
            Controls.Add(comboBoxProduct);
            Controls.Add(labelProduct);
            Controls.Add(comboBoxOrder);
            Controls.Add(labelOrder);
            Controls.Add(dataGridViewOrderProducts);
            Name = "OrderProductForm";
            Text = "Order Products Management";
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrderProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dataGridViewOrderProducts;
        private Label labelOrder;
        private ComboBox comboBoxOrder;
        private Label labelProduct;
        private ComboBox comboBoxProduct;
        private Label labelQty;
        private TextBox textBoxQty;
        private Label labelPriceEach;
        private TextBox textBoxPriceEach;
        private Button buttonCreate;
        private Button buttonAdd;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonClear;
    }
}
