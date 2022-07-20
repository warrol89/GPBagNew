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

            decimal width = dataGridView1.Width / dataGridView1.ColumnCount;
            var columns = dataGridView1.ColumnCount;
            for (var i = 0; i < columns; i++)
            {
                dataGridView1.Columns[i].Width = (int)Math.Floor(width);
            }

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
                Bagtype = txt_Type.Text,
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
           if(!File.Exists("bagdata.csv"))
            {
                File.Create("bagadata.csv");
            }
            if (!File.Exists("checkout.csv"))
            {
                File.Create("checkout.csv");
            }
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

        private void txt_PhNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled= false;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            parentclock.Enabled = true;
            timer1.Enabled = true;
            parentclock.Text=Convert.ToString(DateTime.Now);
                    }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //pictureBox1.Enabled = true;
            //pictureBox1.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //pictureBox1.Visible = false;
            //pictureBox1.Enabled=false;
        }

        private void txt_Type_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
