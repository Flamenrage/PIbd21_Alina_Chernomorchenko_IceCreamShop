using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IceCreamShopClientView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            LoadList();
        }

        private void LoadList()
        {
            try
            {
                //dataGridViewClientOrders.DataSource = //прописать запрос;
                dataGridViewClientOrders.Columns[0].Visible = false;
                dataGridViewClientOrders.Columns[1].Visible = false;
                dataGridViewClientOrders.Columns[2].Visible = false;
                dataGridViewClientOrders.Columns[3].Visible = false;
                dataGridViewClientOrders.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void UpdateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* var form = new FormUpdateData();
            form.ShowDialog();*/
        }

        private void CreateOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
         /*   var form = new FormCreateOrder();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }*/
        }

        private void RefreshOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadList();
        }
    }
}
