namespace ProjectForm
{
    partial class OrderForm
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
            dataGridViewOrders = new DataGridView();
            labelCustomer = new Label();
            comboBoxCustomer = new ComboBox();
            labelOrderDate = new Label();
            dateTimePickerOrderDate = new DateTimePicker();
            labelRequiredDate = new Label();
            dateTimePickerRequiredDate = new DateTimePicker();
            labelShippedDate = new Label();
            dateTimePickerShippedDate = new DateTimePicker();
            labelStatus = new Label();
            textBoxStatus = new TextBox();
            labelComments = new Label();
            textBoxComments = new TextBox();
            buttonCreate = new Button();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            SuspendLayout();

            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Location = new Point(12, 12);
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.RowTemplate.Height = 25;
            dataGridViewOrders.Size = new Size(776, 250);
            dataGridViewOrders.TabIndex = 0;
            dataGridViewOrders.CellClick += dataGridViewOrders_CellClick;

            labelCustomer.AutoSize = true;
            labelCustomer.Location = new Point(12, 280);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(59, 15);
            labelCustomer.TabIndex = 1;
            labelCustomer.Text = "Customer:";

            comboBoxCustomer.FormattingEnabled = true;
            comboBoxCustomer.Location = new Point(93, 277);
            comboBoxCustomer.Name = "comboBoxCustomer";
            comboBoxCustomer.Size = new Size(200, 23);
            comboBoxCustomer.TabIndex = 2;

            labelOrderDate.AutoSize = true;
            labelOrderDate.Location = new Point(12, 310);
            labelOrderDate.Name = "labelOrderDate";
            labelOrderDate.Size = new Size(71, 15);
            labelOrderDate.TabIndex = 3;
            labelOrderDate.Text = "Order Date:";

            dateTimePickerOrderDate.Location = new Point(93, 307);
            dateTimePickerOrderDate.Name = "dateTimePickerOrderDate";
            dateTimePickerOrderDate.Size = new Size(200, 23);
            dateTimePickerOrderDate.TabIndex = 4;

            labelRequiredDate.AutoSize = true;
            labelRequiredDate.Location = new Point(12, 340);
            labelRequiredDate.Name = "labelRequiredDate";
            labelRequiredDate.Size = new Size(83, 15);
            labelRequiredDate.TabIndex = 5;
            labelRequiredDate.Text = "Required Date:";

            dateTimePickerRequiredDate.Location = new Point(93, 337);
            dateTimePickerRequiredDate.Name = "dateTimePickerRequiredDate";
            dateTimePickerRequiredDate.Size = new Size(200, 23);
            dateTimePickerRequiredDate.TabIndex = 6;

            labelShippedDate.AutoSize = true;
            labelShippedDate.Location = new Point(400, 280);
            labelShippedDate.Name = "labelShippedDate";
            labelShippedDate.Size = new Size(80, 15);
            labelShippedDate.TabIndex = 7;
            labelShippedDate.Text = "Shipped Date:";

            dateTimePickerShippedDate.Location = new Point(481, 277);
            dateTimePickerShippedDate.Name = "dateTimePickerShippedDate";
            dateTimePickerShippedDate.Size = new Size(200, 23);
            dateTimePickerShippedDate.TabIndex = 8;

            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(400, 310);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(42, 15);
            labelStatus.TabIndex = 9;
            labelStatus.Text = "Status:";

            textBoxStatus.Location = new Point(481, 307);
            textBoxStatus.Name = "textBoxStatus";
            textBoxStatus.Size = new Size(200, 23);
            textBoxStatus.TabIndex = 10;

            labelComments.AutoSize = true;
            labelComments.Location = new Point(400, 340);
            labelComments.Name = "labelComments";
            labelComments.Size = new Size(67, 15);
            labelComments.TabIndex = 11;
            labelComments.Text = "Comments:";

            textBoxComments.Location = new Point(481, 337);
            textBoxComments.Name = "textBoxComments";
            textBoxComments.Multiline = true;
            textBoxComments.Size = new Size(200, 50);
            textBoxComments.TabIndex = 12;

            buttonCreate.Location = new Point(12, 410);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(75, 23);
            buttonCreate.TabIndex = 13;
            buttonCreate.Text = "Create";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;

            buttonAdd.Location = new Point(93, 410);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 14;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;

            buttonUpdate.Location = new Point(174, 410);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 23);
            buttonUpdate.TabIndex = 15;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;

            buttonDelete.Location = new Point(255, 410);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 16;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;

            buttonClear.Location = new Point(336, 410);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(75, 23);
            buttonClear.TabIndex = 17;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(buttonClear);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Controls.Add(buttonCreate);
            Controls.Add(textBoxComments);
            Controls.Add(labelComments);
            Controls.Add(textBoxStatus);
            Controls.Add(labelStatus);
            Controls.Add(dateTimePickerShippedDate);
            Controls.Add(labelShippedDate);
            Controls.Add(dateTimePickerRequiredDate);
            Controls.Add(labelRequiredDate);
            Controls.Add(dateTimePickerOrderDate);
            Controls.Add(labelOrderDate);
            Controls.Add(comboBoxCustomer);
            Controls.Add(labelCustomer);
            Controls.Add(dataGridViewOrders);
            Name = "OrderForm";
            Text = "Order Management";
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dataGridViewOrders;
        private Label labelCustomer;
        private ComboBox comboBoxCustomer;
        private Label labelOrderDate;
        private DateTimePicker dateTimePickerOrderDate;
        private Label labelRequiredDate;
        private DateTimePicker dateTimePickerRequiredDate;
        private Label labelShippedDate;
        private DateTimePicker dateTimePickerShippedDate;
        private Label labelStatus;
        private TextBox textBoxStatus;
        private Label labelComments;
        private TextBox textBoxComments;
        private Button buttonCreate;
        private Button buttonAdd;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonClear;
    }
}
