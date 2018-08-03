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
    public partial class AddSujPart_Form1 : Form 

    {
        ComboBox comboBox_batch = new ComboBox();  // Class global
        ComboBox comboBox_branch = new ComboBox();
        ComboBox comboBox_stuName = new ComboBox();

        public AddSujPart_Form1()
        {
            InitializeComponent();
            
            // Add Label
            //Label StuName = new Label();
            //StuName.Location = new Point(13, 13);
            //StuName.Text = "Student Name";
            //this.Controls.Add(StuName);
            //StuName.Hide();

            ////string name = "Muzafar";
            ////
            //TextBox StuName_input = new TextBox();
            //StuName_input.Location = new Point(StuName.Location.X+150, StuName.Location.Y);
            //StuName_input.Text = "";
            //this.Controls.Add(StuName_input);


            //FrameMain.TabColNam.Keys.ElementAt(0)
            //FrameMain.TabColNam.Keys.Count();

            // Add table in ComboBox1
            for (int r = 0; r < FrameMain.TabColNam.Keys.Count(); r++)
            {
                comboBox1_Tables.Items.Add(FrameMain.TabColNam.Keys.ElementAt(r));
            }
            comboBox1_Tables.SelectedIndex = 0; // try catch // if mtdosent works



            var TableNam = FrameMain.TabColNam.Keys.ElementAt(0);
            var ColNam = FrameMain.TabColNam[TableNam].ElementAt(1);
            string sqlquery = null;
            // Batch
            var TotBatch = FrameMain.Sql_Query(
                                   FrameMain.cnn,
                                   TableNam = FrameMain.TabColNam.Keys.ElementAt(1),
                                   ColNam = "*",
                                   sqlquery = "SELECT DISTINCT " + "*" + " FROM " + TableNam + " ;"
                                   );

            //BOX
            // Add to Box
            for (int r = 0; r < TotBatch.Rows.Count; r++)
            {
                comboBox_batch.Items.Add(TotBatch.Rows[r].ItemArray[1].ToString());
            }
            comboBox_batch.SelectedIndex = 0;  // Error if no rows // Try catch

            //Branch
            var TotBranch = FrameMain.Sql_Query(
               FrameMain.cnn,
               TableNam = FrameMain.TabColNam.Keys.ElementAt(0),
               ColNam = "*",
               sqlquery = "SELECT DISTINCT " + "*" + " FROM " + TableNam + " ;"
               );
            // Add to Box
            for (int r = 0; r < TotBranch.Rows.Count; r++)
            {
                comboBox_branch.Items.Add(TotBranch.Rows[r].ItemArray[1].ToString());
            }
            comboBox_branch.SelectedIndex = 0;  // Error if no rows // Try catch



            // Student id Box

            var TotStuName = FrameMain.Sql_Query(
                                  FrameMain.cnn,
                                  TableNam = FrameMain.TabColNam.Keys.ElementAt(2),
                                  ColNam =  FrameMain.TabColNam[TableNam].ElementAt(1),
                                  sqlquery = "SELECT DISTINCT " + "*" + " FROM " + TableNam + " ;"
                                  );
            for (int r = 0; r < TotStuName.Rows.Count; r++)
            {
                comboBox_stuName.Items.Add(TotStuName.Rows[r].ItemArray[1].ToString());
            }
            comboBox_stuName.SelectedIndex = 0;  // Error if no rows // Try catch

            

        }



        private void button_ADD_Click(object sender, EventArgs e)
        {


        }

        private void comboBox1_Tables_SelectedIndexChanged(object sender, EventArgs e)
        {

            var index_box = comboBox1_Tables.SelectedIndex;
            var TableNam = FrameMain.TabColNam.Keys.ElementAt(0);
            var ColNam = FrameMain.TabColNam[TableNam].ElementAt(1);


            List<string> TestList = new List<string>();
            TestList.Add("apple"); TestList.Add("bananaapple"); TestList.Add("cat");
            ////
            //
            //Box
            comboBox_batch.Location = new Point(textBox1.Location.X, label2.Location.Y);
            panel1.Controls.Add(comboBox_batch);
            comboBox_batch.Size = textBox1.Size; //new System.Drawing.Size(221, 21);
            comboBox_batch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox_batch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_batch.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboBox_branch.Location = new Point(textBox1.Location.X, label3.Location.Y);
            panel1.Controls.Add(comboBox_branch);
            comboBox_branch.Size = textBox1.Size; //new System.Drawing.Size(221, 21);
            comboBox_branch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox_branch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_branch.AutoCompleteSource = AutoCompleteSource.ListItems;
            

            comboBox_stuName.Location = new Point(textBox1.Location.X, textBox1.Location.Y);
            panel1.Controls.Add(comboBox_stuName);
            comboBox_stuName.Size = textBox1.Size;
            comboBox_stuName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            comboBox_stuName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox_stuName.AutoCompleteSource = AutoCompleteSource.ListItems;
             

            //
            ////
            switch (index_box)
            {
                case 0:
                    TableNam = FrameMain.TabColNam.Keys.ElementAt(0);
                    ColNam = FrameMain.TabColNam[TableNam].ElementAt(1);
                    label1.Text = ColNam;


                    //
                    label2.Hide();
                    label3.Hide();
                    label4.Hide();
                    label5.Hide();
                    label6.Hide();
                    label7.Hide();
                    label8.Hide();                
                    textBox1.Show();comboBox_batch.Hide();
                    textBox2.Hide();comboBox_batch.Hide();
                    textBox3.Hide();comboBox_branch.Hide();
                    textBox4.Hide();
                    textBox5.Hide();
                    textBox6.Hide();
                    textBox7.Hide();
                    textBox8.Hide();
                    //

                  
                    break;

                case 1:
                    TableNam = FrameMain.TabColNam.Keys.ElementAt(index_box);
                    ColNam = FrameMain.TabColNam[TableNam].ElementAt(1);
                    label1.Text = ColNam;

                    //
                    label2.Hide();
                    label3.Hide();
                    label4.Hide();
                    label5.Hide();
                    label6.Hide();
                    label7.Hide();
                    label8.Hide();
                    textBox1.Show();comboBox_batch.Hide();
                    textBox2.Hide();comboBox_batch.Hide();
                    textBox3.Hide();comboBox_branch.Hide();
                    textBox4.Hide();
                    textBox5.Hide();
                    textBox6.Hide();
                    textBox7.Hide();
                    textBox8.Hide();
                    
                    break;

                case 2:
                    TableNam = FrameMain.TabColNam.Keys.ElementAt(index_box);
                    //ColNam = FrameMain.TabColNam[TableNam].ElementAt(1);

                    label1.Text = FrameMain.TabColNam[TableNam].ElementAt(1);
                    label2.Text = FrameMain.TabColNam[TableNam].ElementAt(2);
                    label3.Text = FrameMain.TabColNam[TableNam].ElementAt(3);
                    label4.Text = FrameMain.TabColNam[TableNam].ElementAt(4);
                    label5.Text = FrameMain.TabColNam[TableNam].ElementAt(5);
                                         
                    //
                    label2.Show();
                    label3.Show();
                    label4.Show();
                    label5.Show();
                    label6.Hide();
                    label7.Hide();
                    label8.Hide();             
                    textBox1.Show();comboBox_batch.Hide();
                    textBox2.Hide(); comboBox_batch.Show();
                    textBox3.Hide();comboBox_branch.Show();
                    textBox4.Show();
                    textBox5.Show();
                    textBox6.Hide();
                    textBox7.Hide();
                    textBox8.Hide();
                    break;
                  


                case 3:
                    TableNam = FrameMain.TabColNam.Keys.ElementAt(index_box);
                    //ColNam = FrameMain.TabColNam[TableNam].ElementAt(1);

                    label1.Text = FrameMain.TabColNam[TableNam].ElementAt(0);
                    label2.Text = FrameMain.TabColNam[TableNam].ElementAt(1);
                    label3.Text = FrameMain.TabColNam[TableNam].ElementAt(2);
                    label4.Text = FrameMain.TabColNam[TableNam].ElementAt(3);
                    label5.Text = FrameMain.TabColNam[TableNam].ElementAt(4);
                    label6.Text = FrameMain.TabColNam[TableNam].ElementAt(5);
                    label7.Text = FrameMain.TabColNam[TableNam].ElementAt(6);
                    label8.Text = FrameMain.TabColNam[TableNam].ElementAt(7);

                    //
                    label1.Show();
                    label2.Show();
                    label3.Show();
                    label4.Show();
                    label5.Show();
                    label6.Show();
                    label7.Show();
                    label8.Show();
                    textBox1.Hide();comboBox_batch.Show();
                    textBox2.Show();comboBox_batch.Hide();
                    textBox3.Show();comboBox_branch.Hide();
                    textBox4.Show();
                    textBox5.Show();
                    textBox6.Show();
                    textBox7.Show();
                    textBox8.Show();
                    break;
                case 4:
                    break;
                case 5:
                    TableNam = FrameMain.TabColNam.Keys.ElementAt(index_box);
                    label1.Text = FrameMain.TabColNam[TableNam].ElementAt(1);
                    //
                    label1.Show();
                    label2.Hide();
                    label3.Hide();
                    label4.Hide();
                    label5.Hide();
                    label6.Hide();
                    label7.Hide();
                    label8.Hide();
                    textBox1.Show(); comboBox_batch.Hide();
                    textBox2.Hide(); comboBox_batch.Hide();
                    textBox3.Hide(); comboBox_branch.Hide();
                    textBox4.Hide();
                    textBox5.Hide();
                    textBox6.Hide();
                    textBox7.Hide();
                    textBox8.Hide();
                    break;
                    
                    //
          
                    break;
            

            }
        }
    }
}
