namespace ProjectForm
{
    partial class PaymentForm
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
            dataGridViewPayments = new DataGridView();
            labelCheckNum = new Label();
            textBoxCheckNum = new TextBox();
            labelCustomer = new Label();
            comboBoxCustomer = new ComboBox();
            labelPaymentDate = new Label();
            dateTimePickerPaymentDate = new DateTimePicker();
            labelAmount = new Label();
            textBoxAmount = new TextBox();
            buttonCreate = new Button();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPayments).BeginInit();
            SuspendLayout();

            dataGridViewPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPayments.Location = new Point(12, 12);
            dataGridViewPayments.Name = "dataGridViewPayments";
            dataGridViewPayments.RowTemplate.Height = 25;
            dataGridViewPayments.Size = new Size(776, 250);
            dataGridViewPayments.TabIndex = 0;
            dataGridViewPayments.CellClick += dataGridViewPayments_CellClick;

            labelCheckNum.AutoSize = true;
            labelCheckNum.Location = new Point(12, 280);
            labelCheckNum.Name = "labelCheckNum";
            labelCheckNum.Size = new Size(80, 15);
            labelCheckNum.TabIndex = 1;
            labelCheckNum.Text = "Check Number:";

            textBoxCheckNum.Location = new Point(93, 277);
            textBoxCheckNum.Name = "textBoxCheckNum";
            textBoxCheckNum.Size = new Size(200, 23);
            textBoxCheckNum.TabIndex = 2;

            labelCustomer.AutoSize = true;
            labelCustomer.Location = new Point(12, 310);
            labelCustomer.Name = "labelCustomer";
            labelCustomer.Size = new Size(59, 15);
            labelCustomer.TabIndex = 3;
            labelCustomer.Text = "Customer:";

            comboBoxCustomer.FormattingEnabled = true;
            comboBoxCustomer.Location = new Point(93, 307);
            comboBoxCustomer.Name = "comboBoxCustomer";
            comboBoxCustomer.Size = new Size(200, 23);
            comboBoxCustomer.TabIndex = 4;

            labelPaymentDate.AutoSize = true;
            labelPaymentDate.Location = new Point(12, 340);
            labelPaymentDate.Name = "labelPaymentDate";
            labelPaymentDate.Size = new Size(81, 15);
            labelPaymentDate.TabIndex = 5;
            labelPaymentDate.Text = "Payment Date:";

            dateTimePickerPaymentDate.Location = new Point(93, 337);
            dateTimePickerPaymentDate.Name = "dateTimePickerPaymentDate";
            dateTimePickerPaymentDate.Size = new Size(200, 23);
            dateTimePickerPaymentDate.TabIndex = 6;

            labelAmount.AutoSize = true;
            labelAmount.Location = new Point(400, 280);
            labelAmount.Name = "labelAmount";
            labelAmount.Size = new Size(54, 15);
            labelAmount.TabIndex = 7;
            labelAmount.Text = "Amount:";

            textBoxAmount.Location = new Point(481, 277);
            textBoxAmount.Name = "textBoxAmount";
            textBoxAmount.Size = new Size(200, 23);
            textBoxAmount.TabIndex = 8;

            buttonCreate.Location = new Point(12, 380);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(75, 23);
            buttonCreate.TabIndex = 9;
            buttonCreate.Text = "Create";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;

            buttonAdd.Location = new Point(93, 380);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 10;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;

            buttonUpdate.Location = new Point(174, 380);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 23);
            buttonUpdate.TabIndex = 11;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;

            buttonDelete.Location = new Point(255, 380);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 12;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;

            buttonClear.Location = new Point(336, 380);
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
            Controls.Add(textBoxAmount);
            Controls.Add(labelAmount);
            Controls.Add(dateTimePickerPaymentDate);
            Controls.Add(labelPaymentDate);
            Controls.Add(comboBoxCustomer);
            Controls.Add(labelCustomer);
            Controls.Add(textBoxCheckNum);
            Controls.Add(labelCheckNum);
            Controls.Add(dataGridViewPayments);
            Name = "PaymentForm";
            Text = "Payment Management";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPayments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dataGridViewPayments;
        private Label labelCheckNum;
        private TextBox textBoxCheckNum;
        private Label labelCustomer;
        private ComboBox comboBoxCustomer;
        private Label labelPaymentDate;
        private DateTimePicker dateTimePickerPaymentDate;
        private Label labelAmount;
        private TextBox textBoxAmount;
        private Button buttonCreate;
        private Button buttonAdd;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonClear;
    }
}
