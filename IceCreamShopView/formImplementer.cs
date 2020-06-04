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
    public partial class FormImplementer : Form
    {
        public int? Id { set; get; }
        public string ImplementerFIO { set; get; }
        public int ImplementerWorkTime { set; get; }
        public int ImplementerDelay { set; get; }

        public FormImplementer()
        {
            InitializeComponent();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxImplementerFIO.Text.ToString()) ||
                !string.IsNullOrEmpty(textBoxWorkTime.Text.ToString()) ||
                !string.IsNullOrEmpty(textBoxDelay.Text.ToString()))
            {
                ImplementerFIO = textBoxImplementerFIO.Text.ToString();
                ImplementerWorkTime = Convert.ToInt32(textBoxWorkTime.Text);
                ImplementerDelay = Convert.ToInt32(textBoxDelay.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormImplementer_Load(object sender, EventArgs e)
        {
            if (ImplementerFIO != null)
            {
                textBoxImplementerFIO.Text = ImplementerFIO;
                textBoxWorkTime.Text = ImplementerWorkTime.ToString();
                textBoxDelay.Text = ImplementerDelay.ToString();
            }
        }

    }
}
