using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IceCreamShopClientView
{
    public partial class FormMessages : Form
    {
        public FormMessages()
        {
            InitializeComponent();
            Load_Data();
        }

        private void Load_Data()
        {
            try
            {
                dataGridViewClientMessages.DataSource =
                    ApiClient.GetRequest<List<MessageInfoViewModel>>($"api/client/getmessages?clientid={Program.Client.Id}");
                dataGridViewClientMessages.Columns[0].Visible = false;
                dataGridViewClientMessages.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка получения списка сообщений", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}   
