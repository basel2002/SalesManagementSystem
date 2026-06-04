using CodeFirst.Context;
using System.Data;
namespace ProjectForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm frm = new CustomerForm(DbContextHelper.GetContext());
            frm.Show();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeForm frm = new EmployeeForm(DbContextHelper.GetContext());
            frm.Show();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductForm frm = new ProductForm(DbContextHelper.GetContext());
            frm.Show();
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderForm frm = new OrderForm(DbContextHelper.GetContext());
            frm.Show();
        }

        private void orderProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderProductForm frm = new OrderProductForm(DbContextHelper.GetContext());
            frm.Show();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentForm frm = new PaymentForm(DbContextHelper.GetContext());
            frm.Show();
        }

        private void productLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductLineForm frm = new ProductLineForm(DbContextHelper.GetContext());
            frm.Show();
        }

        private void officeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OfficeForm frm = new OfficeForm(DbContextHelper.GetContext());
            frm.Show();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            // Dispose the shared context when the main form closes
            DbContextHelper.DisposeContext();
        }
    }
}
