﻿using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopServiceDAL.ServicesDal;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace IceCreamShopView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly MainService service;
        private readonly IBookingService bookingService;
        private readonly ReportLogic reportLogic;

        public FormMain(MainService service, IBookingService bookingService, ReportLogic reportLogic)
        {
            InitializeComponent();
            this.service = service;
            this.bookingService = bookingService;
            this.reportLogic = reportLogic;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = bookingService.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = true;
                    dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[8].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void ингредиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormIngredients>();
            form.ShowDialog();
        }

        private void мороженоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormIceCreams>();
            form.ShowDialog();
        }
        private void buttonCreateBooking_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateBooking>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonTakeBookingInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    service.TakeBookingInWork(new ChangeStatusBindingModel { BookingId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonBookingReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    service.FinishBooking(new ChangeStatusBindingModel { BookingId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonPayBooking_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    service.PayBooking(new ChangeStatusBindingModel { BookingId = id });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void buttonCreateBooking_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateBooking>();
            form.ShowDialog();
            LoadData();
        }
        private void складыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormStorages>();
            form.ShowDialog();
        }

        private void пополнитьСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormFillStorage>();
            form.ShowDialog();
        }
        private void ingredientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    reportLogic.SaveIceCreamsToWordFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void iceCreamIngredientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportIceCreamIngredients>();
            form.ShowDialog();
        }

        private void orderDatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportOrders>();
            form.ShowDialog();
        }
        private void списокИнгредиентовToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportIngredient>();
            form.ShowDialog();
        }
        private void списокИнгредиентовПоСкладамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportStorageIngredient>();
            form.ShowDialog();
        }

        private void списокСкладовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    reportLogic.SaveStoragesToWordFile(new ReportBindingModel { FileName = dialog.FileName });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClients>();
            form.ShowDialog();
        }
    }
}