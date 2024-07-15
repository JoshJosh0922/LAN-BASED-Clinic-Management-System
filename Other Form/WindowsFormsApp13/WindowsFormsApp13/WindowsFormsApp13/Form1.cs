using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;user id=root;Database=report;sslMode=none;");
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;
        PrintDocument printDocument = new PrintDocument();
        PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();


        public Form1()
        {
            InitializeComponent();

            printDocument.PrintPage += new PrintPageEventHandler(export);
            printDocument.PrintPage += new PrintPageEventHandler(print);
            printPreviewDialog.Document = printDocument;

        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Open the database connection
                connection.Open();

                // Set up the SQL command and data adapter
                string query = "SELECT * FROM logbook";
                command = new MySqlCommand(query, connection);
                adapter = new MySqlDataAdapter(command);

                // Create a new DataTable and fill it with the data from the adapter
                table = new DataTable();
                adapter.Fill(table);

                // Set the DataGridView's DataSource property to the DataTable
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the database connection
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }

        private void export(object sender, PrintPageEventArgs e)
        {
            // Set up the font and brush for drawing the text
            Font font = new Font("Arial", 12);
            Brush brush = Brushes.Black;

            // Set up the starting coordinates for drawing the text
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            // Loop through each selected row in the DataGridView and print the data
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Draw the cell value at the current coordinates
                    e.Graphics.DrawString(cell.Value.ToString(), font, brush, x, y);

                    // Move the y coordinate down to the next row
                    y += font.GetHeight();
                }

                // Move the x coordinate back to the left and reset the y coordinate for the next row
                x = e.MarginBounds.Left;
                y += font.GetHeight();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Creating Print Document
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = pd;

            // Displaying Print Preview
            DialogResult result = printPreviewDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void print(object sender, PrintPageEventArgs e)
        {
            // Set up the font and brush for drawing the text
            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Black;

            // Set up the starting coordinates for drawing the text
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;

            // Loop through each selected row in the DataGridView and print the data
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Draw the cell value at the current coordinates
                    e.Graphics.DrawString(cell.Value.ToString(), font, brush, x, y);

                    // Move the y coordinate down to the next row
                    y += font.GetHeight();
                }

                // Move the x coordinate back to the left and reset the y coordinate for the next row
                x = e.MarginBounds.Left;
                y += font.GetHeight();
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            // Create a new PrintDocument object
            PrintDocument printDocument = new PrintDocument();

            // Set the PrintPage event handler
            printDocument.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            // Create a new PrintPreviewDialog object
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

            // Set the Document property of the PrintPreviewDialog to the PrintDocument
            printPreviewDialog.Document = printDocument;

            // Show the PrintPreviewDialog
            printPreviewDialog.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Set the row and column count
            int rowCount = dataGridView1.Rows.Count;
            int columnCount = dataGridView1.Columns.Count;

            // Set the margin and padding values
            int margin = 20;
            int padding = 30;

            // Set the font
            Font font = new Font("Courier New", 10);

            // Calculate the cell width and height
            int cellWidth = (e.PageBounds.Width - margin * 2) / columnCount;
            int cellHeight = font.Height + padding;

            // Create the cell rectangle
            Rectangle cellRectangle = new Rectangle(margin, 0, cellWidth, cellHeight);

            // Draw the column headers
          
            for (int col = 0; col < columnCount; col++)
            {
                string headerText = dataGridView1.Columns[col].HeaderText;
                e.Graphics.DrawString(headerText, font, Brushes.Black, cellRectangle);
                cellRectangle.X += cellWidth;
            }

            cellRectangle.Y += cellHeight;

            // Draw the rows
            for (int row = 0; row < rowCount; row++)
            {
                cellRectangle.X = margin;

                for (int col = 0; col < columnCount; col++)
                {
                    // Check for null value in cell
                    var cell = dataGridView1.Rows[row].Cells[col];
                    if (cell.Value != null)
                    {
                        string cellText = cell.Value.ToString();
                        e.Graphics.DrawString(cellText, font, Brushes.Black, cellRectangle);
                    }

                    cellRectangle.X += cellWidth;
                }

                cellRectangle.Y += cellHeight;
            }

            // Draw the receipt footer
            cellRectangle.X = margin;
            cellRectangle.Width = e.PageBounds.Width - margin * 2;
            cellRectangle.Y += padding * 2;

            e.Graphics.DrawLine(Pens.Black, margin, cellRectangle.Y, e.PageBounds.Width - margin, cellRectangle.Y);

            cellRectangle.Y += padding;

            string totalAmount = string.Format("{0:C}", 1000.00); // Replace with your own total amount value
            e.Graphics.DrawString("TOTAL AMOUNT DUE:", font, Brushes.Black, cellRectangle);
            cellRectangle.X += cellWidth * 3;
            e.Graphics.DrawString(totalAmount, font, Brushes.Black, cellRectangle);
            cellRectangle.X -= cellWidth * 3;
            cellRectangle.Y += cellHeight;

            e.Graphics.DrawString("THANK YOU FOR YOUR PURCHASE!", font, Brushes.Black, cellRectangle);

        }
    }
    }


