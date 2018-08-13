using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReoGrid_1
{
    public partial class Form3_AddGrid : Form
    {
        public Form3_AddGrid()
        {
            InitializeComponent();

            comboBox1_branch.Items.Clear(); comboBox1_branch.Items.Add("All"); comboBox1_branch.Items.AddRange(AddSujPart_Form1.textbox1_branch.ToArray()); comboBox1_branch.SelectedIndex = 0; comboBox1_branch.Update();
            comboBox1_batch.Items.Clear(); comboBox1_batch.Items.Add("All"); comboBox1_batch.Items.AddRange(AddSujPart_Form1.textbox1_batch.ToArray()); comboBox1_batch.SelectedIndex = 0; comboBox1_batch.Update();
            comboBox1_Subject.Items.Clear(); comboBox1_Subject.Items.Add("All"); comboBox1_Subject.Items.AddRange(AddSujPart_Form1.textbox1_subject.ToArray()); comboBox1_Subject.SelectedIndex = 0; comboBox1_Subject.Update();
            comboBox1_sem.Items.Clear(); comboBox1_sem.Items.Add("All"); comboBox1_sem.Items.AddRange(AddSujPart_Form1.sem_id); comboBox1_sem.SelectedIndex = 0; comboBox1_sem.Update();


            

        }




        private void comboBox1_batch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
