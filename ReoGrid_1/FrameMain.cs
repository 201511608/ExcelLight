using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;


using unvell.ReoGrid;

using System.Text.RegularExpressions;

using System.Data.OleDb;
using System.Data.SqlClient;



namespace ReoGrid_1
{

    public partial class FrameMain : Form
    {
            string connetionString = null;
            public static OleDbConnection cnn;
            OleDbCommand sqlcommand = new OleDbCommand();
            OleDbDataAdapter sqladapter = new OleDbDataAdapter();
            string file = "StuDB1.accdb";
            public static IDictionary<string, List<string>> TabColNam;




        public FrameMain()
        {
            // Initialize All Gui GUI 
            InitializeComponent();
            DataBase_Proc();


        }
      
        public void DataBase_Proc()
        {

            // DB
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + file + " ;Persist Security Info=False;";
            cnn = new OleDbConnection(connetionString);
            cnn.Open();
            TabColNam = Db_TabColName(cnn);

            // Tree
            Tree(cnn, TabColNam);
         
            

            // Read all tables
            //foreach (string key in TabColNam.Keys.ToArray())
            //{ 
            //        foreach (string ColNam in TabColNam[key])
            //        {
            //            var ColNam1 = ColNam; // dummty delete
            //        }
            //}

        }


        void Tree(OleDbConnection cnn, IDictionary<string, List<string>> TabColNam)
        {

            // Tree
            treeView1.Nodes.Add("COLLEGE_NAME"); // Node [0]  Nodes must be recorded

            //
            ////
            /////
            //////
            string TableNam = TabColNam.Keys.ElementAt(0);
            var ColNam = TabColNam[TableNam].ElementAt(1);
            string sqlquery = "SELECT DISTINCT " + ColNam + " FROM " + TableNam + " ;";
            var TotBatches = Sql_Query(
                cnn,
                TableNam = TabColNam.Keys.ElementAt(0),
                ColNam = TabColNam[TableNam].ElementAt(1),
                sqlquery = "SELECT DISTINCT " + ColNam + " FROM " + TableNam + " ;"
                );
            var TotSems = Sql_Query(
                   cnn,
                   TableNam = TabColNam.Keys.ElementAt(1),
                   ColNam = TabColNam[TableNam].ElementAt(1),
                   sqlquery = "SELECT DISTINCT " + ColNam + " FROM " + TableNam + " ;"
                   );
            var TotSub = Sql_Query(
                  cnn,
                  TableNam = TabColNam.Keys.ElementAt(4),
                  ColNam = TabColNam[TableNam].ElementAt(3),
                  sqlquery = "SELECT DISTINCT " + ColNam + " FROM " + TableNam + " ;"
                  );
            var TotSubParts = Sql_Query(
          cnn,
          TableNam = TabColNam.Keys.ElementAt(2),
          ColNam = TabColNam[TableNam].ElementAt(1),
          sqlquery = "SELECT DISTINCT " + ColNam + " FROM " + TableNam + " ;"
          );

            // Tree formation
            int count = 0;
            int count_sem = 0;
            int count_sub = 0;
            foreach (DataRow row in TotBatches.Rows)
            {
                treeView1.Nodes[0].Nodes.Add(row.Field<string>(0));
                count_sem = 0;
                foreach (DataRow row2 in TotSems.Rows)
                {

                    treeView1.Nodes[0].Nodes[count].Nodes.Add(row2.Field<string>(0));
                    count_sub = 0;
                    foreach (DataRow row3 in TotSub.Rows)
                    {
                        treeView1.Nodes[0].Nodes[count].Nodes[count_sem].Nodes.Add(row3.Field<string>(0));

                        foreach (DataRow row4 in TotSubParts.Rows)
                        {
                            treeView1.Nodes[0].Nodes[count].Nodes[count_sem].Nodes[count_sub].Nodes.Add(row4.Field<string>(0));

                        }
                        count_sub = count_sub + 1;
                    }
                    count_sem = count_sem + 1;
                }
                count = count + 1;
            }
            ////////
            //////
            ////
            //
        }

        public static DataTable Sql_Query(OleDbConnection cnn, string TableNam, string ColNam, string sqlquery)
        {
            // Returns table of Sql query
            OleDbCommand sqlcommand = new OleDbCommand();
            OleDbDataAdapter sqladapter = new OleDbDataAdapter();

            //var TableNam = TabColNam.Keys.ElementAt(0);
            //var ColNam = TabColNam[TableNam];
            //var sqlquery = "SELECT *  FROM " + TableNam + " WHERE 1=0 ;";
            DataTable table = new DataTable();
            sqlcommand.CommandText = sqlquery;
            sqlcommand.Connection = cnn;
            sqladapter.SelectCommand = sqlcommand;
            sqladapter.Fill(table);

            return table;

        }

                public static void Sql_Query_Insert(OleDbConnection cnn, string sqlquery)
        {
            // Returns table of Sql query

            //var TableNam = TabColNam.Keys.ElementAt(0);
            //var ColNam = TabColNam[TableNam];
            //var sqlquery = "SELECT *  FROM " + TableNam + " WHERE 1=0 ;";


            OleDbCommand sqlcommand = new OleDbCommand();
            OleDbDataAdapter sqladapter = new OleDbDataAdapter();
          
            DataTable table = new DataTable();
            sqlcommand.CommandText = sqlquery;
            sqlcommand.Connection = cnn;
            sqladapter.InsertCommand = new OleDbCommand(sqlquery, cnn);
            sqladapter.InsertCommand.ExecuteNonQuery();
            MessageBox.Show("Row(s) Inserted !! ");
                  
             
        }
               
           public static void Sql_Query_Update(OleDbConnection cnn, string sqlquery)
        {


            OleDbCommand sqlcommand = new OleDbCommand();
            OleDbDataAdapter sqladapter = new OleDbDataAdapter();
            sqladapter.UpdateCommand = cnn.CreateCommand();
            sqladapter.UpdateCommand.CommandText = sqlquery;
            sqladapter.UpdateCommand.ExecuteNonQuery();
            MessageBox.Show ("Row updated !! ");
        }
             





        public List<string> DataTable_Names(OleDbConnection cnn)
        {
            // Retrun Table names from Dataset

            DataTable userTables = null;
            string[] restrictions = new string[4];
            restrictions[3] = "Table";
            userTables = cnn.GetSchema("Tables", restrictions);

            List<string> tableNames = new List<string>();
            for (int i = 0; i < userTables.Rows.Count; i++)
            {
                tableNames.Add(userTables.Rows[i][2].ToString());
                // treeView1.Nodes.Add(tableNames[i]); // Tree add all tables

            }
            return tableNames;
        }
        public IDictionary<string, List<string>> Db_TabColName(OleDbConnection cnn) 
        {
            // Return Tables and Column names from DataSet


            DataTable table = new DataTable();
            List<DataTable> tables = new List<DataTable>();
            IDictionary<string, List<string>> TableColNames = new Dictionary<string, List<string>>();
            //List<string> ColNames = new List<string>();
            OleDbCommand sqlcommand = new OleDbCommand();
            OleDbDataAdapter sqladapter = new OleDbDataAdapter();

            var Dd_Tablelist = DataTable_Names(cnn);
            string sqlquery = "";


            foreach (string table_name in Dd_Tablelist)
            {

                sqlquery = "SELECT *  FROM " + table_name + " WHERE 1=0 ;";
                sqlcommand.CommandText = sqlquery;
                sqlcommand.Connection = cnn;
                sqladapter.SelectCommand = sqlcommand;
                sqladapter.Fill(table);

                List<string> ColNames = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    ColNames.Add(column.ColumnName);
                }
                TableColNames.Add(table_name, ColNames);

                //table.Clear(); // Clear table 
                table.Columns.Clear();
                //ColNames.Clear(); // Clear List
            }


            //
            //

         
            //
            //
            return TableColNames;

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            rGrid.Reset();
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            rGrid.CurrentWorksheet.Reset();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;
            openFileDialog1.Title = "Open file...";
            openFileDialog1.Filter = "Excel (*.xlsx) |*.xlsx";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                var FileLoc = openFileDialog1.FileName;
                rGrid.Load(FileLoc, unvell.ReoGrid.IO.FileFormat.Excel2007, Encoding.UTF8);
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Title = "Save file...";
            SaveFileDialog1.Filter = "Excel (*.xlsx) |*.xlsx";
            DialogResult result = SaveFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                var FileLoc = SaveFileDialog1.FileName;
                rGrid.Save(FileLoc, unvell.ReoGrid.IO.FileFormat.Excel2007, Encoding.UTF8);
            }



        }


        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        

     
        private void FrameMain_Load(object sender, EventArgs e)
        {

        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            var sheet = rGrid.CurrentWorksheet;
            var session3 = sheet.CreatePrintSession();
            PrintPreviewDialog ppd = new PrintPreviewDialog();
            // using(PrintPreviewDialog ppd = new PrintPreviewDialog)

            ppd.Document = session3.PrintDocument;
            ppd.SetBounds(200, 200, 1024, 768);
            ppd.PrintPreviewControl.Zoom = 1.0;
            ppd.ShowDialog(this);



        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var session = rGrid.CurrentWorksheet.CreatePrintSession();
            session.Print();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (rGrid.CanUndo() == true)
            {
                rGrid.Undo();
            }
        
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (rGrid.CanRedo() == true)
            {
                rGrid.Redo();
            }
        }

        private void btnRepeat_Click(object sender, EventArgs e)
        {
            rGrid.RepeatLastAction(rGrid.CurrentWorksheet.SelectionRange);
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            if (rGrid.CurrentWorksheet.CanCut() == true)
            {
                rGrid.CurrentWorksheet.Cut();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (rGrid.CurrentWorksheet.CanCopy() == true)
            {
                rGrid.CurrentWorksheet.Copy();
            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (rGrid.CurrentWorksheet.CanPaste() == true)
            {
                rGrid.CurrentWorksheet.CanPaste();
            }
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            rGrid.CurrentWorksheet.MergeRange(rGrid.CurrentWorksheet.SelectionRange);
        }

        private void btnUnMerge_Click(object sender, EventArgs e)
        {
            rGrid.CurrentWorksheet.UnmergeRange(rGrid.CurrentWorksheet.SelectionRange);
        }

        private void cboZoom_Click(object sender, EventArgs e)
        {
           
        }
        private double Val(string source)
        {
            string initialNumber;
            double result;

            // ----- Locate the text number.
            if (string.IsNullOrEmpty(source))
                return 0D;
            initialNumber = Regex.Match(source, @"^\s*(\d+\.?\d*)").Value;

            // ----- Attempt conversion.
            if (double.TryParse(initialNumber, out result))
                return result;
            else
                return 0D;
        }
        private void cboZoom_TextChanged(object sender, EventArgs e)
        {
            var check = Convert.ToSingle((cboZoom.Text.Replace("%", "")))/100.0F;
            rGrid.CurrentWorksheet.ScaleFactor = check;
            //cboZoom.Text.Replace("%", String.Empty).Trim();
       
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
             var worksheet = this.rGrid.CurrentWorksheet;
             rGrid.CurrentWorksheet.Reset();


        }

        private void cboFontSize_TextChanged(object sender, EventArgs e)
        {
            // Change this
            var MyStyleFont1 = new WorksheetRangeStyle();
            MyStyleFont1.Flag = PlainStyleFlag.FontSize;
            MyStyleFont1.FontSize = Convert.ToInt16(cboFontSize.Text);
            rGrid.CurrentWorksheet.SetRangeStyles(rGrid.CurrentWorksheet.SelectionRange, MyStyleFont1);
            rGrid.CurrentWorksheet["A2"] = "Later";
        
        }

        private void btnFunctions_Click(object sender, EventArgs e)
        {

            rGrid.CurrentWorksheet.Reset();
            rGrid.CurrentWorksheet["A2"] = "Later";
          
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
        var MyStyleFont4 = new WorksheetRangeStyle();
           //Update this
            if (MyStyleFont4.Bold == true)
            {
                rGrid.Undo();
                return;
            }
              
        MyStyleFont4.Flag = PlainStyleFlag.FontStyleBold ;
        MyStyleFont4.Bold = true;
        rGrid.CurrentWorksheet.SetRangeStyles(rGrid.CurrentWorksheet.SelectionRange, MyStyleFont4);
       
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
          var MyStyleFont4 = new WorksheetRangeStyle();
        MyStyleFont4.Flag = PlainStyleFlag.FontStyleItalic ;
        MyStyleFont4.Italic = true;
        rGrid.CurrentWorksheet.SetRangeStyles(rGrid.CurrentWorksheet.SelectionRange, MyStyleFont4);
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
             var MyStyleFont4 = new WorksheetRangeStyle();
        MyStyleFont4.Flag = PlainStyleFlag.FontStyleUnderline ;
        MyStyleFont4.Underline = true;
        rGrid.CurrentWorksheet.SetRangeStyles(rGrid.CurrentWorksheet.SelectionRange, MyStyleFont4);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
               var MyStyleFont5 = new WorksheetRangeStyle();
        MyStyleFont5.Flag = PlainStyleFlag.HorizontalAlign;
        MyStyleFont5.HAlign = ReoGridHorAlign.Left;
        rGrid.CurrentWorksheet.SetRangeStyles(rGrid.CurrentWorksheet.SelectionRange, MyStyleFont5);
        }

        private void btnCenter_Click(object sender, EventArgs e)
        {
             var MyStyleFont5 = new WorksheetRangeStyle();
        MyStyleFont5.Flag = PlainStyleFlag.HorizontalAlign;
        MyStyleFont5.HAlign = ReoGridHorAlign.Center;
        rGrid.CurrentWorksheet.SetRangeStyles(rGrid.CurrentWorksheet.SelectionRange, MyStyleFont5);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
             var MyStyleFont5 = new WorksheetRangeStyle();
        MyStyleFont5.Flag = PlainStyleFlag.HorizontalAlign;
        MyStyleFont5.HAlign = ReoGridHorAlign.Right;
        rGrid.CurrentWorksheet.SetRangeStyles(rGrid.CurrentWorksheet.SelectionRange, MyStyleFont5);
        }

        private void btnTop_Click(object sender, EventArgs e)
        {
        var MyStyleFont6 = new WorksheetRangeStyle();
        MyStyleFont6.Flag = PlainStyleFlag.VerticalAlign;
        MyStyleFont6.VAlign = ReoGridVerAlign.Top;
        rGrid.CurrentWorksheet.SetRangeStyles(rGrid.CurrentWorksheet.SelectionRange, MyStyleFont6);
        }

        private void btnMiddle_Click(object sender, EventArgs e)
        {
             var MyStyleFont6 = new WorksheetRangeStyle();
        MyStyleFont6.Flag = PlainStyleFlag.VerticalAlign;
        MyStyleFont6.VAlign = ReoGridVerAlign.Middle;
        rGrid.CurrentWorksheet.SetRangeStyles(rGrid.CurrentWorksheet.SelectionRange, MyStyleFont6);
        }

        private void btnBottom_Click(object sender, EventArgs e)
        {
             var  MyStyleFont6 = new WorksheetRangeStyle();
        MyStyleFont6.Flag = PlainStyleFlag.VerticalAlign;
        MyStyleFont6.VAlign = ReoGridVerAlign.Top;
        rGrid.CurrentWorksheet.SetRangeStyles(rGrid.CurrentWorksheet.SelectionRange, MyStyleFont6);
        }

        private void btnMiddleCenter_Click(object sender, EventArgs e)
        {
              var MyStyleFont6 = new WorksheetRangeStyle();
        MyStyleFont6.Flag = PlainStyleFlag.AlignAll ;
        MyStyleFont6.VAlign = ReoGridVerAlign.Middle;
        MyStyleFont6.HAlign = ReoGridHorAlign.Center;
        rGrid.CurrentWorksheet.SetRangeStyles(rGrid.CurrentWorksheet.SelectionRange, MyStyleFont6);
        }

        private void btnBordersAll_Click(object sender, EventArgs e)
        {
        var MyStyleBorder1 = new RangeBorderStyle();
        MyStyleBorder1.Style = BorderLineStyle.BoldSolid;
        MyStyleBorder1.Color = Color.Black;
        rGrid.CurrentWorksheet.SetRangeBorders(rGrid.CurrentWorksheet.SelectionRange, BorderPositions.All, MyStyleBorder1);
        }

        private void btnBordersOutline_Click(object sender, EventArgs e)
        {
            var MyStyleBorder1 = new RangeBorderStyle();
            MyStyleBorder1.Style = BorderLineStyle.BoldSolid;
            MyStyleBorder1.Color = Color.Black;
            rGrid.CurrentWorksheet.SetRangeBorders(rGrid.CurrentWorksheet.SelectionRange, BorderPositions.Outside, MyStyleBorder1);
        }

        private void btnBordersInside_Click(object sender, EventArgs e)
        {
            var MyStyleBorder1 = new RangeBorderStyle();
            MyStyleBorder1.Style = BorderLineStyle.BoldSolid;
            MyStyleBorder1.Color = Color.Black;
            rGrid.CurrentWorksheet.SetRangeBorders(rGrid.CurrentWorksheet.SelectionRange, BorderPositions.InsideAll, MyStyleBorder1);
        }

        private void btnBordersClear_Click(object sender, EventArgs e)
        {
        var MyStyleBorder2 = new RangeBorderStyle();
        MyStyleBorder2.Color = Color.Empty;
        rGrid.CurrentWorksheet.RemoveRangeBorders(rGrid.CurrentWorksheet.SelectionRange, BorderPositions.All);
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

            string connetionString = null;
            OleDbConnection cnn;
            OleDbCommand sqlcommand = new OleDbCommand();
            OleDbDataAdapter sqladapter = new OleDbDataAdapter();
            string file = "StuDB1.accdb";
            connetionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + file + " ;Persist Security Info=False;";
            cnn = new OleDbConnection(connetionString);
            cnn.Open();
            var TabColNam = Db_TabColName(cnn);

            string TableNam = TabColNam.Keys.ElementAt(0);
            var ColNam = TabColNam[TableNam].ElementAt(1);
            string sqlquery = "SELECT DISTINCT " + ColNam + " FROM " + TableNam + " ;";



           var TotSems = Sql_Query(
           cnn,
           TableNam = TabColNam.Keys.ElementAt(5),
           ColNam = "*",
           sqlquery = "SELECT DISTINCT " + ColNam + " FROM " + TableNam + " ;"
           );

            

           rGrid.CurrentWorksheet[2,1] = "Later";

           for (int r = 0; r < TotSems.Rows.Count; r++)
           {
               
               for (int c = 0; c < TotSems.Columns.Count; c++)
               {
                   rGrid.CurrentWorksheet[0, c] = TotSems.Columns[c].ColumnName;
                   rGrid.CurrentWorksheet[r+1, c] = TotSems.Rows[r].ItemArray[c].ToString();
               }
           }


           

           foreach (DataRow row in TotSems.Rows)

           {
               //object field = TotSems.Rows[0].ItemArray[3]
               //treeView1.Nodes[0].Nodes.Add(row.Field<string>(0));
            
           }


        }

        private void rGrid_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hurray! You Can Add");
        }

        // Just to enabel disable
        private void treeView1_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {
            //Important for selection
            treeView1.SelectedNode = e.Node;
  
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Tree_RtCl_MenuStrip.Show(treeView1, e.Location);
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            AddSujPart_Form1 objUI = new AddSujPart_Form1();
            objUI.ShowDialog();
            //objUI.Close();
            

        }

        private void toolStripLabel3_Click_1(object sender, EventArgs e)
        {
            AddSujPart_Form1 objUI = new AddSujPart_Form1();// for default values

            //for (int r = 0; r < TotSems.Rows.Count; r++)
            //{
            //    for (int c = 0; c < TotSems.Columns.Count; c++)
            //    {
            //        rGrid.CurrentWorksheet[0, c] = TotSems.Columns[c].ColumnName;
            //        rGrid.CurrentWorksheet[r + 1, c] = TotSems.Rows[r].ItemArray[c].ToString();
            //    }
            //}

            var  rGrid2 = new unvell.ReoGrid.ReoGridControl();
            rGrid2.BackColor = System.Drawing.Color.White;
            rGrid2.ColumnHeaderContextMenuStrip = null;
            rGrid2.LeadHeaderContextMenuStrip = null;
            rGrid2.Location = new System.Drawing.Point(175, 64);
            rGrid2.Name = "rGrid";
            rGrid2.RowHeaderContextMenuStrip = null;
            rGrid2.Script = null;
            rGrid2.SheetTabContextMenuStrip = null;
            rGrid2.SheetTabNewButtonVisible = true;
            rGrid2.SheetTabVisible = true;
            rGrid2.SheetTabWidth = 400;
            rGrid2.ShowScrollEndSpacing = true;
            rGrid2.Size = new System.Drawing.Size(805, 491);
            rGrid2.TabIndex = 2;
            rGrid2.Text = "reoGridControl1";
            rGrid2.Click += new System.EventHandler(this.rGrid_Click);



            Form3_AddGrid objUI3 = new Form3_AddGrid();
            objUI3.ShowDialog();
           


        }

    }
}


