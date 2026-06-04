namespace ProjectForm
{
    partial class ProductLineForm
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
            dataGridViewProductLines = new DataGridView();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            labelHTML = new Label();
            textBoxHTML = new TextBox();
            labelImage = new Label();
            textBoxImage = new TextBox();
            buttonCreate = new Button();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            buttonClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductLines).BeginInit();
            SuspendLayout();

            dataGridViewProductLines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductLines.Location = new Point(12, 12);
            dataGridViewProductLines.Name = "dataGridViewProductLines";
            dataGridViewProductLines.RowTemplate.Height = 25;
            dataGridViewProductLines.Size = new Size(776, 250);
            dataGridViewProductLines.TabIndex = 0;
            dataGridViewProductLines.CellClick += dataGridViewProductLines_CellClick;

            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(12, 280);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(75, 15);
            labelDescription.TabIndex = 1;
            labelDescription.Text = "Description:";

            textBoxDescription.Location = new Point(93, 277);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(200, 23);
            textBoxDescription.TabIndex = 2;

            labelHTML.AutoSize = true;
            labelHTML.Location = new Point(12, 310);
            labelHTML.Name = "labelHTML";
            labelHTML.Size = new Size(42, 15);
            labelHTML.TabIndex = 3;
            labelHTML.Text = "HTML:";

            textBoxHTML.Location = new Point(93, 307);
            textBoxHTML.Name = "textBoxHTML";
            textBoxHTML.Size = new Size(200, 23);
            textBoxHTML.TabIndex = 4;

            labelImage.AutoSize = true;
            labelImage.Location = new Point(12, 340);
            labelImage.Name = "labelImage";
            labelImage.Size = new Size(45, 15);
            labelImage.TabIndex = 5;
            labelImage.Text = "Image:";

            textBoxImage.Location = new Point(93, 337);
            textBoxImage.Name = "textBoxImage";
            textBoxImage.Size = new Size(200, 23);
            textBoxImage.TabIndex = 6;

            buttonCreate.Location = new Point(12, 380);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(75, 23);
            buttonCreate.TabIndex = 7;
            buttonCreate.Text = "Create";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;

            buttonAdd.Location = new Point(93, 380);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 8;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;

            buttonUpdate.Location = new Point(174, 380);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 23);
            buttonUpdate.TabIndex = 9;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;

            buttonDelete.Location = new Point(255, 380);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 10;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;

            buttonClear.Location = new Point(336, 380);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(75, 23);
            buttonClear.TabIndex = 11;
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
            Controls.Add(textBoxImage);
            Controls.Add(labelImage);
            Controls.Add(textBoxHTML);
            Controls.Add(labelHTML);
            Controls.Add(textBoxDescription);
            Controls.Add(labelDescription);
            Controls.Add(dataGridViewProductLines);
            Name = "ProductLineForm";
            Text = "Product Line Management";
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductLines).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridView dataGridViewProductLines;
        private Label labelDescription;
        private TextBox textBoxDescription;
        private Label labelHTML;
        private TextBox textBoxHTML;
        private Label labelImage;
        private TextBox textBoxImage;
        private Button buttonCreate;
        private Button buttonAdd;
        private Button buttonUpdate;
        private Button buttonDelete;
        private Button buttonClear;
    }
}
