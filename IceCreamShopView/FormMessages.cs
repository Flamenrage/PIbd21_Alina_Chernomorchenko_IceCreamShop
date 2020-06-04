using IceCreamShopServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceCreamShopView
{
    public partial class FormMessages : Form
    {
        private readonly IMessageInfoLogic messageInfoLogic;

        public FormMessages(IMessageInfoLogic messageInfoLogic)
        {
            InitializeComponent();
            this.messageInfoLogic = messageInfoLogic;
            Load_Data();
        }

        private void Load_Data()
        {
            try
            {
                dataGridViewMessages.DataSource = messageInfoLogic.Read(null);
                dataGridViewMessages.Columns[0].Visible = false;
                dataGridViewMessages.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridViewMessages.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка получения списка сообщений", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
