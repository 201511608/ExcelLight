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
        public static List<string> textbox1_branch = new List<string>(); // textbox1
        public static List<string> textbox1_batch = new List<string>();  // textbox1
        public static List<string> textbox1_subject = new List<string>();       // textbox1
        List<string> textbox1_student = new List<string>();       // textbox1
        List<string> textbox1_student_uID = new List<string>();       // textbox1
        List<string> textbox1_student_Detinfo = new List<string>(); 
        int index_box;
        public static string[] sem_id;  // Store Sem Data


        public AddSujPart_Form1()
        {
            textbox1_branch.Clear();
            textbox1_batch.Clear();
            textbox1_subject.Clear();



            InitializeComponent();
            Update_tableADD();
            comboBox_stuName.SelectedIndexChanged += new System.EventHandler(comboBox_stuName_SelectedIndexChanged); // Add Real Time Function
            comboBox_batch.SelectedIndexChanged += new System.EventHandler(comboBox_batch_SelectedIndexChanged); // Add Real Time Function
           
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



        }


        private bool wasExecuted = true;
        private void comboBox_batch_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            if (wasExecuted == true) // to get updated with data first
            {
                comboBox_branch.Show();
                comboBox_branch.Items.Clear();
                comboBox_branch.Items.AddRange(textbox1_subject.ToArray());
                comboBox_branch.SelectedIndex = 0;
                comboBox_branch.Update();
                wasExecuted = false;
            }
            

               if (comboBox1_Tables.SelectedIndex == 4) 
                {
                    var TableNam = FrameMain.TabColNam.Keys.ElementAt(4);
                    var Col1_stu =   FrameMain.TabColNam[TableNam].ElementAt(1);
                    var Col2_sub =   FrameMain.TabColNam[TableNam].ElementAt(2);
                    var Col3_sem = FrameMain.TabColNam[TableNam].ElementAt(3);
                   //////
                   TableNam = FrameMain.TabColNam.Keys.ElementAt(5);
                   var Col_Name = FrameMain.TabColNam[TableNam].ElementAt(1);
                   var test_1 = comboBox_branch.Text.ToUpper();
                   var sqlquery = "SELECT * FROM " + TableNam + " WHERE " + Col_Name + " = '" + comboBox_branch.Text.ToUpper() + "' ;"; //comboBox_branch = subject       
                   var sub_id_tem = FrameMain.Sql_Query(
                    FrameMain.cnn,
                    TableNam,
                    "*",
                    sqlquery
                    );
                   var sub_id = sub_id_tem.Rows[0].ItemArray[0].ToString();
                   //////
                   

                   /////////////
                   // for change in values student id display the data form Stusub Table
                   TableNam = FrameMain.TabColNam.Keys.ElementAt(4);
                   sqlquery = "SELECT " + "*" + " FROM " + TableNam + " WHERE " + Col1_stu + " = " + comboBox_batch.Text + " AND " + Col2_sub + " = '" + sub_id + "' AND " + Col3_sem + " = '" + comboBox_stuName.Text + "' ;"; ;
                   var StusubTabSearch = FrameMain.Sql_Query(
                                    FrameMain.cnn,
                                    TableNam,
                                    "*",
                                    sqlquery
                                    );
                   ///////////

                   if (StusubTabSearch.Rows.Count > 0)
                   {
                       //MessageBox.Show("Data Availale");
                       textBox1.Text = StusubTabSearch.Rows[0].ItemArray[0].ToString();
                       textBox5.Text = StusubTabSearch.Rows[0].ItemArray[4].ToString();
                       textBox6.Text = StusubTabSearch.Rows[0].ItemArray[5].ToString();
                       textBox7.Text = StusubTabSearch.Rows[0].ItemArray[6].ToString();
                       textBox8.Text = StusubTabSearch.Rows[0].ItemArray[7].ToString();
                       textBox9.Text = StusubTabSearch.Rows[0].ItemArray[8].ToString();
                       textBox10.Text = StusubTabSearch.Rows[0].ItemArray[9].ToString();
                       textBox11.Text = StusubTabSearch.Rows[0].ItemArray[10].ToString();
                       textBox12.Text = StusubTabSearch.Rows[0].ItemArray[11].ToString();
                       textBox13.Text = StusubTabSearch.Rows[0].ItemArray[12].ToString();
                       textBox14.Text = StusubTabSearch.Rows[0].ItemArray[13].ToString();
                   }
                   else
                   {
                       textBox1.Clear();
                       textBox5.Clear();
                       textBox6.Clear();
                       textBox7.Clear();
                       textBox8.Clear();
                       textBox9.Clear();
                       textBox10.Clear();
                       textBox11.Clear();
                       textBox12.Clear();
                       textBox13.Clear();
                       textBox14.Clear();
                   }
                }

         }

        private void comboBox_stuName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( comboBox1_Tables.SelectedIndex ==3)
            {
                textBox2.Clear();

                textBox3.Clear();

                textBox4.Clear();

                textBox5.Clear();

                textBox6.Clear();

                textBox7.Clear();

                textBox8.Clear();




                var TableNam = FrameMain.TabColNam.Keys.ElementAt(2);
                var ColNam = FrameMain.TabColNam[TableNam].ElementAt(0);
                string sqlquery = null;
                string condition1 = " " + ColNam + " =" + comboBox_stuName.Text;
                // Batch
                var select_studentName = FrameMain.Sql_Query(
                                      FrameMain.cnn,
                                      TableNam = FrameMain.TabColNam.Keys.ElementAt(2),
                                      ColNam = "*",
                                      sqlquery = "SELECT " + "*" + " FROM " + TableNam + " WHERE " + condition1 + " ;"
                                      );


                textBox2.Text = select_studentName.Rows[0].ItemArray[1].ToString();
                textBox2.Update();


                if (textbox1_student_Detinfo.Contains(comboBox_stuName.Text))
                {
                    TableNam = FrameMain.TabColNam.Keys.ElementAt(3);
                    ColNam = FrameMain.TabColNam[TableNam].ElementAt(0);
                    condition1 = " WHERE  " + ColNam + " = " + comboBox_stuName.Text + " ";
                    var TotStudInfo = FrameMain.Sql_Query(
                    FrameMain.cnn,
                    TableNam = FrameMain.TabColNam.Keys.ElementAt(3),
                      "*",
                      "SELECT " + "*" + " FROM " + TableNam + " " + condition1 + " ;"
                    );

                    textBox2.Text = TotStudInfo.Rows[0].ItemArray[1].ToString();
                    textBox2.Update();
                    textBox3.Text = TotStudInfo.Rows[0].ItemArray[2].ToString();
                    textBox3.Update();
                    textBox4.Text = TotStudInfo.Rows[0].ItemArray[3].ToString();
                    textBox4.Update();
                    textBox5.Text = TotStudInfo.Rows[0].ItemArray[4].ToString();
                    textBox5.Update();
                    textBox6.Text = TotStudInfo.Rows[0].ItemArray[5].ToString();
                    textBox6.Update();
                    textBox7.Text = TotStudInfo.Rows[0].ItemArray[6].ToString();
                    textBox7.Update();
                    textBox8.Text = TotStudInfo.Rows[0].ItemArray[7].ToString();
                    textBox8.Update();



                    update_tableAdd_Studinfo();
                }
             
            }
            else if (comboBox1_Tables.SelectedIndex == 4)
            {
 


                /////////////
                // for change in values student id display the data form Stusub Table
                var TableNam = FrameMain.TabColNam.Keys.ElementAt(4);
                var Col1_sub = FrameMain.TabColNam[TableNam].ElementAt(3);
                var sqlquery = "SELECT DISTINCT " + "*" + " FROM " + TableNam + " WHERE " + Col1_sub + " = '" + comboBox_stuName.Text + "' ;";
                var StusubTabSearch = FrameMain.Sql_Query(
                                 FrameMain.cnn,
                                 TableNam,
                                 "*",
                                 sqlquery
                                 );


                textbox1_student.Clear();
                 for (int r = 0; r < StusubTabSearch.Rows.Count; r++)
                 {
                     textbox1_student.Add(StusubTabSearch.Rows[r].ItemArray[3].ToString());
                 }
              
 
             
            }

        }

        public void Update_tableADD()
        {
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
            //for (int r = 0; r < TotBatch.Rows.Count; r++)
            //{
            //    comboBox_batch.Items.Add(TotBatch.Rows[r].ItemArray[1].ToString());

            //}
            //comboBox_batch.SelectedIndex = 0;  // Error if no rows // Try catch
            //comboBox_batch.Items.AddRange(textbox1_batch.ToArray());


            //Branch
            var TotBranch = FrameMain.Sql_Query(
               FrameMain.cnn,
               TableNam = FrameMain.TabColNam.Keys.ElementAt(0),
               ColNam = "*",
               sqlquery = "SELECT DISTINCT " + "*" + " FROM " + TableNam + " ;"
               );

            // Add to Box
            //for (int r = 0; r < TotBranch.Rows.Count; r++)
            //{
            //    comboBox_branch.Items.Add(TotBranch.Rows[r].ItemArray[1].ToString());
            //}
            //comboBox_branch.Items.AddRange(textbox1_branch.ToArray());
            //comboBox_branch.SelectedIndex = 0;  // Error if no rows // Try catch



            // Student id Box

            var TotStuName = FrameMain.Sql_Query(
                                  FrameMain.cnn,
                                  TableNam = FrameMain.TabColNam.Keys.ElementAt(2),
                                  ColNam = FrameMain.TabColNam[TableNam].ElementAt(1),
                                  sqlquery = "SELECT DISTINCT " + "*" + " FROM " + TableNam + " ;"
                                  );
            //for (int r = 0; r < TotStuName.Rows.Count; r++)
            //{
            //    comboBox_stuName.Items.Add(TotStuName.Rows[r].ItemArray[1].ToString());
            //}
            //comboBox_stuName.SelectedIndex = 0;  // Error if no rows // Try catch


            // textbox1_student
            for (int r = 0; r < TotStuName.Rows.Count; r++)
            {
                textbox1_student.Add(TotStuName.Rows[r].ItemArray[1].ToString().ToUpper());
                textbox1_student_uID.Add(TotStuName.Rows[r].ItemArray[0].ToString().ToUpper());
            }

            // comboBox student  // Add update
            comboBox_stuName.Items.AddRange(textbox1_student_uID.ToArray());
            //comboBox_stuName.SelectedIndex = 0;

            
            // Total student Detail info   textbox1
               var TotStudInfo = FrameMain.Sql_Query(
               FrameMain.cnn,
               TableNam = FrameMain.TabColNam.Keys.ElementAt(3),
               ColNam = "*",
               sqlquery = "SELECT " + "*" + " FROM " + TableNam + " ;"
               );

               for (int r = 0; r < TotStudInfo.Rows.Count; r++)
            {
                textbox1_student_Detinfo.Add(TotStudInfo.Rows[r].ItemArray[0].ToString().ToUpper());
            }

         

            //Branch
            var TotSubject = FrameMain.Sql_Query(
               FrameMain.cnn,
               TableNam = FrameMain.TabColNam.Keys.ElementAt(5),
               ColNam = "*",
               sqlquery = "SELECT DISTINCT " + "*" + " FROM " + TableNam + " ;"
               );




            // textbox1 :: Branch
            //List<string> textbox1_branch = new List<string>();  // Local global function
            for (int r = 0; r < TotBranch.Rows.Count; r++)
            {
                textbox1_branch.Add(TotBranch.Rows[r].ItemArray[1].ToString().ToUpper());
            }

            // combobox branch
            comboBox_branch.Items.AddRange(textbox1_branch.ToArray());
            comboBox_branch.SelectedIndex = 0;  // Error if no rows // Try catch
            //
            //
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox1.AutoCompleteCustomSource.Clear();
            this.textBox1.AutoCompleteCustomSource.AddRange(textbox1_branch.ToArray()); // takes array  // list to array

            // textbox1 :: Batch
            for (int r = 0; r < TotBatch.Rows.Count; r++)
            {
                textbox1_batch.Add(TotBatch.Rows[r].ItemArray[1].ToString().ToUpper());
            }

            // combobox batch   // add update
            comboBox_batch.Items.AddRange(textbox1_batch.ToArray());
            comboBox_batch.SelectedIndex = 0;  // Error if no rows // Try catch



            //textbox1 ::  textbox1_subject
            for (int r = 0; r < TotSubject.Rows.Count; r++)
            {
                textbox1_subject.Add(TotSubject.Rows[r].ItemArray[1].ToString().ToUpper());
            }


            // textbox 2 for student detail info
            //
            this.textBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox2.AutoCompleteCustomSource.Clear();
            this.textBox2.AutoCompleteCustomSource.AddRange(textbox1_student_Detinfo.ToArray()); // takes array  // list to array


            // textbox 4 
            // For student detail info
            this.textBox4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox4.AutoCompleteCustomSource.Clear();
      
            sem_id = new string[10] {"1","2","3","4","5","6","7","8","9","10" };
            this.textBox4.AutoCompleteCustomSource.AddRange(sem_id); // takes array  // list to array


        }
        void update_tableAdd_Studinfo()
        {
            // Total student Detail info   textbox1
            var TableNam = "";
            var TotStudInfo = FrameMain.Sql_Query(
            FrameMain.cnn,
            TableNam = FrameMain.TabColNam.Keys.ElementAt(3),
              "*",
              "SELECT " + "*" + " FROM " + TableNam + " ;"
            );

            textbox1_student_Detinfo.Clear();
            for (int r = 0; r < TotStudInfo.Rows.Count; r++)
            {
                textbox1_student_Detinfo.Add(TotStudInfo.Rows[r].ItemArray[0].ToString().ToUpper());
            }

        }
        void update_tableAdd_subject()
        {
            var TableNam = FrameMain.TabColNam.Keys.ElementAt(5);
            var ColNam = "*";
            var sqlquery = "SELECT DISTINCT " + "*" + " FROM " + TableNam + " ;";

            var TotSubject = FrameMain.Sql_Query(
            FrameMain.cnn,
            TableNam = FrameMain.TabColNam.Keys.ElementAt(5),
            ColNam = "*",
            sqlquery = "SELECT DISTINCT " + "*" + " FROM " + TableNam + " ;"
            );

            textbox1_subject.Clear();  // Clear once
            for (int r = 0; r < TotSubject.Rows.Count; r++)
            {
                textbox1_subject.Add(TotSubject.Rows[r].ItemArray[1].ToString().ToUpper());
            }


        }

        void update_tableAdd_Branch()
        {
            var TableNam = FrameMain.TabColNam.Keys.ElementAt(0);
            var ColNam = "*";
            var sqlquery = "SELECT DISTINCT " + "*" + " FROM " + TableNam + " ;";

            var TotBranch = FrameMain.Sql_Query(
              FrameMain.cnn,
              TableNam = FrameMain.TabColNam.Keys.ElementAt(0),
              ColNam = "*",
              sqlquery = "SELECT DISTINCT " + "*" + " FROM " + TableNam + " ;"
              );

            textbox1_branch.Clear();  // Clear once
            for (int r = 0; r < TotBranch.Rows.Count; r++)
            {
                textbox1_branch.Add(TotBranch.Rows[r].ItemArray[1].ToString().ToUpper());
            }
        }

        void update_tableAdd_Batch()
        {
            var TableNam = FrameMain.TabColNam.Keys.ElementAt(1);
            var ColNam = "*";
            var sqlquery = "SELECT DISTINCT " + "*" + " FROM " + TableNam + " ;";

            var TotBranch = FrameMain.Sql_Query(
              FrameMain.cnn,
              TableNam = FrameMain.TabColNam.Keys.ElementAt(1),
              ColNam = "*",
              sqlquery = "SELECT DISTINCT " + "*" + " FROM " + TableNam + " ;"
              );

            textbox1_batch.Clear();  // Clear once
            for (int r = 0; r < TotBranch.Rows.Count; r++)
            {
                textbox1_batch.Add(TotBranch.Rows[r].ItemArray[1].ToString().ToUpper());
            }
        }

        void update_tableAdd_student()
        {
            var TableNam = FrameMain.TabColNam.Keys.ElementAt(2);
            var ColNam = "*";
            var sqlquery = "SELECT DISTINCT " + "*" + " FROM " + TableNam + " ;";

            var TotBranch = FrameMain.Sql_Query(
              FrameMain.cnn,
              TableNam = FrameMain.TabColNam.Keys.ElementAt(2),
              ColNam = "*",
              sqlquery = "SELECT DISTINCT " + "*" + " FROM " + TableNam + " ;"
              );

            textbox1_student.Clear();  // Clear once
            for (int r = 0; r < TotBranch.Rows.Count; r++)
            {
                textbox1_student.Add(TotBranch.Rows[r].ItemArray[1].ToString().ToUpper());

            }
        }

        private void button_ADD_Click(object sender, EventArgs e)
        {
            var TableNam = FrameMain.TabColNam.Keys.ElementAt(0);
            var Col_Name = FrameMain.TabColNam[TableNam].ElementAt(0);
            string value2 = "";
            string sqlquery = "";

            try
            {
                switch (index_box)
                {
                    case 0:
                        value2 = textBox1.Text.ToUpper();

                        if (textbox1_branch.Contains(value2))
                        {
                            MessageBox.Show("Already Exist");
                        }
                        else
                        {

                            TableNam = FrameMain.TabColNam.Keys.ElementAt(index_box);
                            Col_Name = FrameMain.TabColNam[TableNam].ElementAt(1);
                            FrameMain.Sql_Query_Insert(
                            FrameMain.cnn,
                            sqlquery = "INSERT INTO " + TableNam + " (" + Col_Name + ") VALUES  " + "(" + "'" + value2 + "'" + ")" + ";"
                            );
                            update_tableAdd_Branch();  // Update sql _> table -> list -> array
                            comboBox1_Tables_SelectedIndexChanged(sender, e);// Updatin GUI // Auto
                        }
                        break;

                    case 1:
                        value2 = textBox1.Text.ToUpper();
                        if (textbox1_batch.Contains(value2))
                        {
                            MessageBox.Show("Already Exist");
                        }
                        else
                        {
                            TableNam = FrameMain.TabColNam.Keys.ElementAt(index_box);
                            Col_Name = FrameMain.TabColNam[TableNam].ElementAt(1);
                            FrameMain.Sql_Query_Insert(
                            FrameMain.cnn,
                            sqlquery = "INSERT INTO " + TableNam + " (" + Col_Name + ") VALUES  " + "(" + "'" + value2 + "'" + ")" + ";"
                            );
                            update_tableAdd_Batch();  // Update sql _> table -> list -> array
                            comboBox1_Tables_SelectedIndexChanged(sender, e);// Updatin GUI // Auto
                        }
                        break;
                    case 2:
                        value2 = textBox1.Text.ToUpper();
                        if (textbox1_student.Contains(value2))
                        {
                            MessageBox.Show("Already Exist");
                        }
                        else

                        {
                            if (textBox1.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                            {
                                MessageBox.Show("Can Add");

                                TableNam = FrameMain.TabColNam.Keys.ElementAt(index_box);
                                Col_Name = FrameMain.TabColNam[TableNam].ElementAt(1);
                                string col_student_name = FrameMain.TabColNam[TableNam].ElementAt(1); value2 = textBox1.Text;
                                string col_Batch_id = FrameMain.TabColNam[TableNam].ElementAt(2); string value3 = comboBox_batch.Text;
                                string col_Branch_id = FrameMain.TabColNam[TableNam].ElementAt(3); string value4 = comboBox_branch.Text;
                                string col_stu_id = FrameMain.TabColNam[TableNam].ElementAt(4); string value5 = textBox4.Text;
                                string col_uni_id = FrameMain.TabColNam[TableNam].ElementAt(5); string value6 = textBox5.Text;



                                TableNam = FrameMain.TabColNam.Keys.ElementAt(1);
                                var ColNam = FrameMain.TabColNam[TableNam].ElementAt(1);
                                string condition1 = " " + ColNam + " =" + " '" + value3 + "' ";
                                var col_Batch_id_selected = FrameMain.Sql_Query(
                                                FrameMain.cnn,
                                                TableNam,
                                                 "*",
                                                sqlquery = "SELECT * FROM " + TableNam + " WHERE " + condition1 + ";"
                                                );
                                value3 = col_Batch_id_selected.Rows[0].ItemArray[0].ToString();



                                TableNam = FrameMain.TabColNam.Keys.ElementAt(0);
                                ColNam = FrameMain.TabColNam[TableNam].ElementAt(1);
                                condition1 = " " + ColNam + " =" + " '" + value4 + "' ";
                                var col_Branch_id_selected = FrameMain.Sql_Query(
                                                 FrameMain.cnn,
                                                 TableNam,
                                                  "*",
                                                 sqlquery = "SELECT * FROM " + TableNam + " WHERE " + condition1 + ";"
                                                 );
                                value4 = col_Branch_id_selected.Rows[0].ItemArray[0].ToString();





                                TableNam = FrameMain.TabColNam.Keys.ElementAt(2);
                                FrameMain.Sql_Query_Insert(
                                FrameMain.cnn,
                                sqlquery = "INSERT INTO " + TableNam + " (" + col_student_name + "," + col_Batch_id + "," + col_Branch_id + "," + col_stu_id + "," + col_uni_id + ") VALUES  ('" + value2 + "'," + value3 + "," + value4 + ",'" + value5 + "'," + "'" + value6 + "'" + ")" + ";"
                                );
                                update_tableAdd_student();  // Update sql _> table -> list -> array
                                comboBox1_Tables_SelectedIndexChanged(sender, e);// Updatin GUI // Auto
       

                            }
                            else
                            {
                                MessageBox.Show("Please Fill the Data");
                            }
                           
                        }

                        break;
                    case 3:

                        if (textbox1_student_Detinfo.Contains(comboBox_stuName.Text))
                        {
                            MessageBox.Show("Already Exist.. If Require Please Update");
                        }
                        else
                        {
                            TableNam = FrameMain.TabColNam.Keys.ElementAt(index_box);
                            //Col_Name = FrameMain.TabColNam[TableNam].ElementAt(1);
                            FrameMain.Sql_Query_Insert(
                            FrameMain.cnn,
                            sqlquery = "INSERT INTO " + TableNam + " VALUES (" + comboBox_stuName.Text.ToUpper() + "," + "'" + textBox2.Text.ToUpper() + "'," + "'" + textBox3.Text.ToUpper() + "'," + "'" + textBox4.Text.ToUpper() + "'," + "'" + textBox5.Text.ToUpper() + "'," + "'" + textBox6.Text.ToUpper() + "'," + "'" + textBox7.Text.ToUpper() + "'," + "'" + textBox8.Text.ToUpper() + "'" + " )" + ";"
                            );
                            update_tableAdd_Studinfo();
                            comboBox1_Tables_SelectedIndexChanged(sender, e);
                        }
                        break;
                   
                            
                    case 4:
                        var stu_id = comboBox_batch.Text.ToUpper();  // convert to id
                        var sub_id = comboBox_branch.Text.ToUpper(); // convert to id
                        stu_id = "1";sub_id="1"; // del this use SQL


                        // sub_id
                        //
                        TableNam = FrameMain.TabColNam.Keys.ElementAt(5);
                        Col_Name = FrameMain.TabColNam[TableNam].ElementAt(1);
                        sqlquery = "SELECT * FROM " + TableNam + " WHERE " + Col_Name + " = '"+comboBox_branch.Text.ToUpper() + "' ;"; //comboBox_branch = subject 
                        var sub_id_tem = FrameMain.Sql_Query(
                                            FrameMain.cnn,
                                            TableNam,
                                            "*",
                                            sqlquery
                                            );
                        sub_id = sub_id_tem.Rows[0].ItemArray[0].ToString();



                         TableNam = FrameMain.TabColNam.Keys.ElementAt(index_box);
                            //Col_Name = FrameMain.TabColNam[TableNam].ElementAt(1);
                            FrameMain.Sql_Query_Insert(
                            FrameMain.cnn,
                            sqlquery = "INSERT INTO " + TableNam + " ( "+ 
                            FrameMain.TabColNam[TableNam].ElementAt(1)  +","+
                            FrameMain.TabColNam[TableNam].ElementAt(2) + "," +
                            FrameMain.TabColNam[TableNam].ElementAt(3) + "," +
                            FrameMain.TabColNam[TableNam].ElementAt(4) + "," +
                            FrameMain.TabColNam[TableNam].ElementAt(5) + "," +
                            FrameMain.TabColNam[TableNam].ElementAt(6) + "," +
                            FrameMain.TabColNam[TableNam].ElementAt(7) + "," +
                            FrameMain.TabColNam[TableNam].ElementAt(8) + "," +
                            FrameMain.TabColNam[TableNam].ElementAt(9) + "," +
                            FrameMain.TabColNam[TableNam].ElementAt(10) + "," +
                            FrameMain.TabColNam[TableNam].ElementAt(11) + "," +
                            FrameMain.TabColNam[TableNam].ElementAt(12) + "," +
                            FrameMain.TabColNam[TableNam].ElementAt(13) +
                            " ) "+
                            " VALUES (" +
                            stu_id + "," +
                            sub_id + "," +                           // subject id
                            comboBox_stuName.Text.ToUpper() + "," + // sem id
                            textBox5.Text.ToUpper() + "," +
                            textBox6.Text.ToUpper() + "," +
                            textBox7.Text.ToUpper() + "," +
                            textBox8.Text.ToUpper() + "," +
                            textBox9.Text.ToUpper() + "," +
                            textBox10.Text.ToUpper() + "," +
                            textBox11.Text.ToUpper() + "," +
                            textBox12.Text.ToUpper() + "," +
                            textBox13.Text.ToUpper() + ",'"+
                            textBox14.Text.ToUpper() + "'" +
                            " )" + ";"
                            );


                        
                     
                        break;
                    case 5:
                        value2 = textBox1.Text.ToUpper();
                        if (textbox1_subject.Contains(value2))
                        {
                            MessageBox.Show("Already Exist");
                        }
                        else
                        {
                            TableNam = FrameMain.TabColNam.Keys.ElementAt(index_box);
                            Col_Name = FrameMain.TabColNam[TableNam].ElementAt(1);
                            FrameMain.Sql_Query_Insert(
                            FrameMain.cnn,
                            sqlquery = "INSERT INTO " + TableNam + " (" + Col_Name + ") VALUES  " + "(" + "'" + value2 + "'" + ")" + ";"
                            );
                            update_tableAdd_subject();  // Update sql _> table -> list -> array
                            comboBox1_Tables_SelectedIndexChanged(sender, e);// Updatin GUI // Auto
                        }

                        break;
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void comboBox1_Tables_SelectedIndexChanged(object sender, EventArgs e)
        {

            index_box = comboBox1_Tables.SelectedIndex;
            var TableNam = FrameMain.TabColNam.Keys.ElementAt(0);
            var ColNam = FrameMain.TabColNam[TableNam].ElementAt(1);


            //List<string> TestList = new List<string>();
            //TestList.Add("apple"); TestList.Add("bananaapple"); TestList.Add("cat");
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

            // textBox1
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;

            //      textBox2     
            this.textBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;



            ////
            // clear all textsBoxes
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox1.Enabled = true; label1.Enabled = true;
            //
            ////
            wasExecuted = true;
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
                    label9.Hide();
                    label10.Hide();
                    label11.Hide();
                    label12.Hide();
                    label13.Hide();
                    label14.Hide();
                    textBox1.Show(); comboBox_batch.Hide(); textBox1.Clear(); this.textBox1.AutoCompleteCustomSource.Clear(); this.textBox1.AutoCompleteCustomSource.AddRange(textbox1_branch.ToArray());comboBox_stuName.Hide();
                    textBox2.Hide(); comboBox_batch.Hide();this.textBox2.AutoCompleteCustomSource.Clear();
                    textBox3.Hide(); comboBox_branch.Hide();
                    textBox4.Hide(); 
                    textBox5.Hide();
                    textBox6.Hide();
                    textBox7.Hide();
                    textBox8.Hide();
                    textBox9.Hide();
                    textBox10.Hide();
                    textBox11.Hide();
                    textBox12.Hide();
                    textBox13.Hide();
                    textBox14.Hide();
                    //

                    // TextBox1 auto display




                    button_ADD.Enabled = true;
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
                    label9.Hide();
                    label10.Hide();
                    label11.Hide();
                    label12.Hide();
                    label13.Hide();
                    label14.Hide();
                    textBox1.Show(); comboBox_batch.Hide(); textBox1.Clear(); this.textBox1.AutoCompleteCustomSource.Clear(); this.textBox1.AutoCompleteCustomSource.AddRange(textbox1_batch.ToArray());comboBox_stuName.Hide(); // takes array  // list to array
                    textBox2.Hide(); comboBox_batch.Hide();this.textBox2.AutoCompleteCustomSource.Clear();
                    textBox3.Hide(); comboBox_branch.Hide();
                    textBox4.Hide();
                    textBox5.Hide();
                    textBox6.Hide();
                    textBox7.Hide();
                    textBox8.Hide();
                    textBox9.Hide();
                    textBox10.Hide();
                    textBox11.Hide();
                    textBox12.Hide();
                    textBox13.Hide();
                    textBox14.Hide();

                    button_ADD.Enabled = true;
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
                    label9.Hide();
                    label10.Hide();
                    label11.Hide();
                    label12.Hide();
                    label13.Hide();
                    label14.Hide();
                    textBox1.Show(); comboBox_batch.Hide(); textBox1.Clear(); this.textBox1.AutoCompleteCustomSource.Clear(); this.textBox1.AutoCompleteCustomSource.AddRange(textbox1_student.ToArray());comboBox_stuName.Hide(); // takes array  // list to array
                    textBox2.Hide(); comboBox_batch.Show();this.textBox2.AutoCompleteCustomSource.Clear();comboBox_batch.Update();comboBox_batch.Items.Clear(); comboBox_batch.Items.AddRange(textbox1_batch.ToArray());comboBox_batch.SelectedIndex=0;
                    textBox3.Hide(); comboBox_branch.Show(); comboBox_branch.Update();comboBox_branch.Items.Clear(); comboBox_branch.Items.AddRange(textbox1_branch.ToArray());comboBox_branch.SelectedIndex=0;
                    textBox4.Show();
                    textBox5.Show();
                    textBox6.Hide();
                    textBox7.Hide();
                    textBox8.Hide();
                    textBox9.Hide();
                    textBox10.Hide();
                    textBox11.Hide();
                    textBox12.Hide();
                    textBox13.Hide();
                    textBox14.Hide();



                    button_ADD.Enabled = true;
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
                    label9.Hide();
                    label10.Hide();
                    label11.Hide();
                    label12.Hide();
                    label13.Hide();
                    label14.Hide();
                    textBox1.Hide(); comboBox_stuName.Show();comboBox_stuName.Items.Clear();comboBox_stuName.Items.AddRange(textbox1_student_uID.ToArray());comboBox_stuName.SelectedIndex=0;comboBox_stuName.Update();          textBox1.Clear(); this.textBox1.AutoCompleteCustomSource.Clear();
                    textBox2.Show(); comboBox_batch.Hide();this.textBox2.AutoCompleteCustomSource.Clear(); this.textBox2.AutoCompleteCustomSource.AddRange(textbox1_student.ToArray()); // takes array  // list to array
                    textBox3.Show(); comboBox_branch.Hide();
                    textBox4.Show();
                    textBox5.Show();
                    textBox6.Show();
                    textBox7.Show();
                    textBox8.Show();
                    textBox9.Hide();
                    textBox10.Hide();
                    textBox11.Hide();
                    textBox12.Hide();
                    textBox13.Hide();
                    textBox14.Hide();

                    button_ADD.Enabled=true;
                    break;
                case 4:
                    //panel1.Size = panel1.Size + panel1.Size;
                    TableNam = FrameMain.TabColNam.Keys.ElementAt(index_box);

                    label1.Text = FrameMain.TabColNam[TableNam].ElementAt(0);
                    label2.Text = FrameMain.TabColNam[TableNam].ElementAt(1);
                    label3.Text = FrameMain.TabColNam[TableNam].ElementAt(2);
                    label4.Text = FrameMain.TabColNam[TableNam].ElementAt(3);
                    label5.Text = FrameMain.TabColNam[TableNam].ElementAt(4);
                    label6.Text = FrameMain.TabColNam[TableNam].ElementAt(5);
                    label7.Text = FrameMain.TabColNam[TableNam].ElementAt(6);
                    label8.Text = FrameMain.TabColNam[TableNam].ElementAt(7);
                    label9.Text = FrameMain.TabColNam[TableNam].ElementAt(8);
                    label10.Text = FrameMain.TabColNam[TableNam].ElementAt(9);
                    label11.Text = FrameMain.TabColNam[TableNam].ElementAt(10);
                    label12.Text = FrameMain.TabColNam[TableNam].ElementAt(11);
                    label13.Text = FrameMain.TabColNam[TableNam].ElementAt(12);
                    label14.Text = FrameMain.TabColNam[TableNam].ElementAt(13);
                    //
                    label1.Show();
                    label2.Show();
                    label3.Show();
                    label4.Show();
                    label5.Show();
                    label6.Show();
                    label7.Show();
                    label8.Show();
                    label9.Show();
                    label10.Show();
                    label11.Show();
                    label12.Show();
                    label13.Show();
                    label14.Show();
                    textBox1.Show();                      textBox1.Clear(); this.textBox1.AutoCompleteCustomSource.Clear();
                    textBox2.Hide(); comboBox_batch.Show();this.textBox2.AutoCompleteCustomSource.Clear();comboBox_batch.Update();comboBox_batch.Items.Clear(); comboBox_batch.Items.AddRange(textbox1_student_uID.ToArray()); comboBox_batch.SelectedIndex=0;
                    textBox3.Hide(); comboBox_branch.Show();comboBox_branch.Update();comboBox_branch.Items.Clear(); comboBox_branch.Items.AddRange(textbox1_subject.ToArray());comboBox_branch.SelectedIndex=0;
                    textBox4.Hide(); comboBox_stuName.Show();comboBox_stuName.Location=new  Point(textBox4.Location.X,textBox4.Location.Y); comboBox_stuName.Items.Clear(); comboBox_stuName.Items.AddRange(sem_id);comboBox_stuName.SelectedIndex=0;  comboBox_stuName.Update();
                    textBox5.Show();
                    textBox6.Show();
                    textBox7.Show();
                    textBox8.Show();
                    textBox9.Show();
                    textBox10.Show();
                    textBox11.Show();
                    textBox12.Show();
                    textBox13.Show();
                    textBox14.Show();


                    button_ADD.Enabled = true;
                    textBox1.Enabled = false; label1.Enabled = false;
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
                    label9.Hide();
                    label10.Hide();
                    label11.Hide();
                    label12.Hide();
                    label13.Hide();
                    label14.Hide();
                    textBox1.Show(); comboBox_batch.Hide(); textBox1.Clear(); this.textBox1.AutoCompleteCustomSource.AddRange(textbox1_subject.ToArray()); comboBox_stuName.Hide(); // takes array  // list to array
                    textBox2.Hide(); comboBox_batch.Hide();this.textBox2.AutoCompleteCustomSource.Clear();
                    textBox3.Hide(); comboBox_branch.Hide();
                    textBox4.Hide(); 
                    textBox5.Hide();
                    textBox6.Hide();
                    textBox7.Hide();
                    textBox8.Hide();
                    textBox9.Hide();
                    textBox10.Hide();
                    textBox11.Hide();
                    textBox12.Hide();
                    textBox13.Hide();
                    textBox14.Hide();


                    button_ADD.Enabled = true;
                    break;

                //
                // SQL ADD QUERY
                //Branch





            }
        }

        private void button_UPDATE_Click(object sender, EventArgs e)
        {

        }


        private void textBox1_Enter(object sender, EventArgs e)
        {
      
         
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 index_box = comboBox1_Tables.SelectedIndex;
             switch (index_box)
             {
                 case 2:
                     if (textbox1_student.Contains(textBox1.Text))  
                     {
                         string TableNam = FrameMain.TabColNam.Keys.ElementAt(2);
                         string ColNam = "*";
                         string condition1 = " Student_Name = '" + textBox1.Text + "'";
                         string sqlquery = "SELECT " + "*" + " FROM " + TableNam + " WHERE " + condition1 + " ;";


                         var TableStudent =
                         FrameMain.Sql_Query(
                                            FrameMain.cnn,
                                            TableNam,
                                            ColNam,
                                            sqlquery
                                            );

                         textBox4.Text = TableStudent.Rows[0].ItemArray[4].ToString();
                         textBox4.Update();
                         textBox5.Text = TableStudent.Rows[0].ItemArray[5].ToString();
                         textBox5.Update();

                         var batch_id = TableStudent.Rows[0].ItemArray[2].ToString();
                         var branch_id = TableStudent.Rows[0].ItemArray[3].ToString();


                         TableNam = FrameMain.TabColNam.Keys.ElementAt(1);
                         ColNam = "*";
                         condition1 = " BatchID = " + batch_id + " ";
                           sqlquery = "SELECT " + "*" + " FROM " + TableNam + " WHERE " + condition1 + " ;";

                       var Tablebatch=
                       FrameMain.Sql_Query(
                                          FrameMain.cnn,
                                          TableNam,
                                          ColNam,
                                          sqlquery
                                          );


                       comboBox_batch.Text = Tablebatch.Rows[0].ItemArray[1].ToString();
                       comboBox_batch.Update();
                         //MessageBox.Show(TotBranch.Rows.Count.ToString());

                         //

                       TableNam = FrameMain.TabColNam.Keys.ElementAt(0);
                       ColNam = "*";
                       var ColNam_Con = FrameMain.TabColNam[TableNam].ElementAt(0);
                       condition1 = " "+ ColNam_Con +" = " + branch_id + " ";
                       sqlquery = "SELECT " + "*" + " FROM " + TableNam + " WHERE " + condition1 + " ;";

                       var Tablebranch =
                    FrameMain.Sql_Query(
                                       FrameMain.cnn,
                                       TableNam,
                                       ColNam,
                                       sqlquery
                                       );


                       comboBox_branch.Text = Tablebranch.Rows[0].ItemArray[1].ToString();
                       comboBox_branch.Update();
                     }


                     break;
                 case 3:


                     break;
             }
            }
        }
    }
}
