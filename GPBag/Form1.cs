using GPBag.Models;
using GPBag.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace GPBag
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeDateTimePicker()
        {
            this.dateTimePicker1.Format = DateTimePickerFormat.Long;
            this.dateTimePicker1.ShowUpDown = true;
        }
        private void InitializeGrid()
        {
            dataGridView1.DataSource = CSV_Read_Write<BaggageGridModel>.ReadDataFromCSV();
            dataGridView1.Columns["Bagsize"].ReadOnly = true;
            dataGridView1.Columns["BaggageReceived"].ReadOnly = true;
            dataGridView1.Columns["BaggageReturned"].ReadOnly = true;
            dataGridView1.Columns["Price"].ReadOnly = true;
            dataGridView1.Columns["Price"].HeaderText = "Price to be paid";
            dataGridView1.Columns["Id"].Visible = false;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var valueToBeAdded = new BaggageGridModel
            {
                Bagsize = cmb_Size.SelectedItem.ToString(),
                Name = txt_Name.Text,
                NoOfBoxes = Convert.ToInt32(txt_No.Text),
                RackNo = txt_PhNo.Text,
                BaggageReceived = dateTimePicker1.Value,
                Id = dataGridView1.RowCount + 1
            };

            CSV_Read_Write<BaggageGridModel>.WriteDataToCSV(valueToBeAdded);
            var values = CSV_Read_Write<BaggageGridModel>.ReadDataFromCSV();

            dataGridView1.DataSource = values;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            var clickedColumn = senderGrid.Columns[e.ColumnIndex];

            if (clickedColumn is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                var values = CSV_Read_Write<BaggageGridModel>.ReadDataFromCSV();
                var send = sender;
                BaggageGridModel rows = (BaggageGridModel)((DataGridView)send).Rows[e.RowIndex].DataBoundItem;

                var csvValues = CSV_Read_Write<BaggageGridModel>.ReadDataFromCSV();

                if (rows.BaggageReturned == null)
                {
                    rows.BaggageReturned = DateTime.Now;
                }
                var releaseData = rows;
                csvValues.Remove(releaseData);
                csvValues.Add(releaseData);
                File.Delete("bagdata.csv");

                foreach(var item in ((List< BaggageGridModel>)dataGridView1.DataSource))
                {
                    CSV_Read_Write<BaggageGridModel>.WriteDataToCSV(item);
                }
                InitializeGrid();
                var events = e;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var source = (IList<BaggageGridModel>)dataGridView1.DataSource;
            dataGridView1.DataSource = source.Where(t => t.Name.ToLower().Contains(txtBox_Search.Text.ToLower())).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtBox_Search.Text = "";
            InitializeGrid();
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }

        private void Checkout_Click(object sender, EventArgs e)
        {
            var source = (List<BaggageGridModel>)dataGridView1.DataSource;
            var checkoutList = source.Where(t => t.BaggageReturned != null).ToList();
            dataGridView1.DataSource = source.Where(t => !t.BaggageReturned.HasValue).ToList();
            var checkoutdata = CSV_Read_Write<BaggageGridModel>.ReadDataFromCSV("checkout.csv");
            checkoutdata.AddRange(checkoutList);
            File.Delete("checkout.csv");
            foreach (var item in checkoutdata)
            {
                CSV_Read_Write<BaggageGridModel>.WriteDataToCSV(item, "checkout.csv");
            }
            File.Delete("bagdata.csv");

            foreach(var item in (List<BaggageGridModel>)dataGridView1.DataSource)
            {
                CSV_Read_Write<BaggageGridModel>.WriteDataToCSV(item);
            }

        }
    }
}
