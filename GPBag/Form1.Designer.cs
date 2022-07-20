﻿
using System.Windows.Forms;

namespace GPBag
{
    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_PhNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Size = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_No = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ReturnBaggage = new System.Windows.Forms.DataGridViewButtonColumn();
            this.PaidByCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBox_Search = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Checkout = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Type = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.parentclock = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Name
            // 
            resources.ApplyResources(this.txt_Name, "txt_Name");
            this.txt_Name.Name = "txt_Name";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txt_PhNo
            // 
            resources.ApplyResources(this.txt_PhNo, "txt_PhNo");
            this.txt_PhNo.Name = "txt_PhNo";
            this.txt_PhNo.TextChanged += new System.EventHandler(this.txt_PhNo_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cmb_Size
            // 
            this.cmb_Size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Size.FormattingEnabled = true;
            this.cmb_Size.Items.AddRange(new object[] {
            resources.GetString("cmb_Size.Items"),
            resources.GetString("cmb_Size.Items1"),
            resources.GetString("cmb_Size.Items2"),
            resources.GetString("cmb_Size.Items3")});
            resources.ApplyResources(this.cmb_Size, "cmb_Size");
            this.cmb_Size.Name = "cmb_Size";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txt_No
            // 
            resources.ApplyResources(this.txt_No, "txt_No");
            this.txt_No.Name = "txt_No";
            // 
            // dataGridView1
            // 
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReturnBaggage,
            this.PaidByCustomer});
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 41;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ReturnBaggage
            // 
            this.ReturnBaggage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(this.ReturnBaggage, "ReturnBaggage");
            this.ReturnBaggage.Name = "ReturnBaggage";
            this.ReturnBaggage.Text = "Return";
            this.ReturnBaggage.UseColumnTextForButtonValue = true;
            // 
            // PaidByCustomer
            // 
            resources.ApplyResources(this.PaidByCustomer, "PaidByCustomer");
            this.PaidByCustomer.Name = "PaidByCustomer";
            // 
            // Add
            // 
            this.Add.ForeColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.Add, "Add");
            this.Add.Name = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // dateTimePicker1
            // 
            resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
            this.dateTimePicker1.Name = "dateTimePicker1";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtBox_Search
            // 
            resources.ApplyResources(this.txtBox_Search, "txtBox_Search");
            this.txtBox_Search.Name = "txtBox_Search";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Checkout
            // 
            this.Checkout.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.Checkout, "Checkout");
            this.Checkout.ForeColor = System.Drawing.Color.Green;
            this.Checkout.Name = "Checkout";
            this.Checkout.UseVisualStyleBackColor = false;
            this.Checkout.Click += new System.EventHandler(this.Checkout_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Type);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_PhNo);
            this.groupBox1.Controls.Add(this.txt_Name);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Add);
            this.groupBox1.Controls.Add(this.cmb_Size);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_No);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // txt_Type
            // 
            resources.ApplyResources(this.txt_Type, "txt_Type");
            this.txt_Type.Name = "txt_Type";
            this.txt_Type.TextChanged += new System.EventHandler(this.txt_Type_TextChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtBox_Search);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button3);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.ForeColor = System.Drawing.Color.Green;
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.button5, "button5");
            this.button5.ForeColor = System.Drawing.Color.Red;
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // parentclock
            // 
            resources.ApplyResources(this.parentclock, "parentclock");
            this.parentclock.BackColor = System.Drawing.SystemColors.Desktop;
            this.parentclock.ForeColor = System.Drawing.Color.Yellow;
            this.parentclock.Name = "parentclock";
            this.parentclock.Click += new System.EventHandler(this.label7_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            resources.ApplyResources(this.button7, "button7");
            this.button7.Name = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Controls.Add(this.button7);
            this.Controls.Add(this.Checkout);
            this.Controls.Add(this.parentclock);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_PhNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_Size;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_No;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBox_Search;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewButtonColumn ReturnBaggage;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidByCustomer;
        private Button Checkout;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label6;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Button button4;
        private Button button3;
        private Button button5;
        private Label parentclock;
        private Timer timer1;
        private Button button6;
        private Button button7;
        private TextBox txt_Type;
        private Label label7;
    }
}

