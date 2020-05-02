using IceCreamShopServiceDAL.BindingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IceCreamShopClientView
{
    public partial class FormEditProfile : Form
    {
        public FormEditProfile()
        {
            InitializeComponent();
            textBoxFIO.Text = Program.Client.ClientFIO;
            textBoxLogin.Text = Program.Client.Login;
            textBoxPassword.Text = Program.Client.Password;
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxLogin.Text) &&
           !string.IsNullOrEmpty(textBoxPassword.Text) &&
           !string.IsNullOrEmpty(textBoxFIO.Text))
            {
                try
                {
                    ApiClient.PostRequest($"api/client/updatedata", new ClientBindingModel()
                    {
                        Id = Program.Client.Id,
                        ClientFIO = textBoxFIO.Text,
                        Login = textBoxLogin.Text.ToString(),
                        Password = textBoxPassword.Text.ToString()
                    });
                    MessageBox.Show("Обновление прошло успешно", "Сообщение",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.Client.ClientFIO = textBoxFIO.Text;
                    Program.Client.Login = textBoxLogin.Text;
                    Program.Client.Password = textBoxPassword.Text;
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
                MessageBox.Show("Введите логин, пароль и ФИО", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
