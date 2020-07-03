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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            Program.Client = null;
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            FormRegister form = new FormRegister();
            form.ShowDialog();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxLogin.Text) &&
           !string.IsNullOrEmpty(textBoxPassword.Text))
            {
                try
                {
                    Program.Client = ApiClient.GetRequest<ClientViewModel>($"api/client/login?login={textBoxLogin.Text}&password={ textBoxPassword.Text}");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}
