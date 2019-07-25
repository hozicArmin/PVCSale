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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace PVC_3
{
    public partial class Form1 : Form
    {
        private string selectedFolderFileDialog = "";
        PvcP1 pvcP1, pvcP2, pvcP3, pvcP4, pvcP5, pvcP6;
        PvcP7 pvcP7;
        PvcP8 pvcP8;
        PvcP9 pvcP9;
        PvcP10 pvcP10;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pvcP1 = new PvcP1((int)numObj1.Value, (int)numericUpHeight1.Value, (int)numericUpWidth1.Value);
            pvcP2 = new PvcP1((int)numObj2.Value, (int)numericUpHeight2.Value, (int)numericUpWidth2.Value);
            pvcP3 = new PvcP1((int)numObj3.Value, (int)numericUpHeight3.Value, (int)numericUpWidth3.Value);
            pvcP4 = new PvcP1((int)numObj4.Value, (int)numericUpHeight4.Value, (int)numericUpWidth4.Value);
            pvcP5 = new PvcP1((int)numObj5.Value, (int)numericUpHeight5.Value, (int)numericUpWidth5.Value);
            pvcP6 = new PvcP1((int)numObj6.Value, (int)numericUpHeight6.Value, (int)numericUpWidth6.Value);
            pvcP7 = new PvcP7((int)numObj7.Value, (int)numericUpHeight7.Value, (int)numericUpWidth7.Value);
            pvcP8 = new PvcP8((int)numObj8.Value, (int)numericUpHeight8.Value, (int)numericUpWidth8.Value);
            pvcP9 = new PvcP9((int)numObj9.Value, (int)numericUpHeight9.Value, (int)numericUpWidth9.Value);
            pvcP10 = new PvcP10((int)numObj10.Value, (int)numericUpWidth10.Value);

            //DisplayCostOfAll();
        }

        private void DisplayPrices()
        {
            txtPriceP1.Text = pvcP1.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";
            txtPriceP2.Text = pvcP2.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";
            txtPriceP3.Text = pvcP3.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";
            txtPriceP4.Text = pvcP4.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";
            txtPriceP5.Text = pvcP5.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";
            txtPriceP6.Text = pvcP6.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";
            txtPriceP7.Text = pvcP7.CalculateCostOfAllDoors() + " KM";
            txtPriceP8.Text = pvcP8.CalculateCostOfAllBlinds(checkBoxBlinds.Checked) + " KM";
            txtPriceP9.Text = pvcP9.CalculateCostOfAllFence(checkBoxAluFence.Checked, rF80.Checked, rF90.Checked, rF100.Checked, rF110.Checked, rF120.Checked, rF130.Checked, rF140.Checked, rF150.Checked) + " KM";
            txtPriceP10.Text = pvcP10.CalculateCostOfAllSills(checkBoxSills.Checked, radioS10.Checked, radioS20.Checked, radioS30.Checked, radioS40.Checked, radioS50.Checked) + " KM";
            txtPriceTotal.Text = UkupnaCijenaSvihArtikala();
        }

        /// <summary>
        /// It's just display of all prices on comboBox
        /// </summary>
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            toolStripComboBox1.Items.Clear();

            string price1 = "Price 01: " + pvcP1.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";
            string price2 = "Price 02: " + pvcP2.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";
            string price3 = "Price 03: " + pvcP3.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";
            string price4 = "Price 04: " + pvcP4.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";
            string price5 = "Price 05: " + pvcP5.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";
            string price6 = "Price 06: " + pvcP6.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";
            string price7 = "Price 07: " + pvcP7.CalculateCostOfAllDoors() + " KM";
            string price8 = "Price 08: " + pvcP8.CalculateCostOfAllBlinds(checkBoxBlinds.Checked) + " KM";
            string price9 = "Price 09: " + pvcP9.CalculateCostOfAllFence(checkBoxAluFence.Checked, rF80.Checked, rF90.Checked, rF100.Checked, rF110.Checked, rF120.Checked, rF130.Checked, rF140.Checked, rF150.Checked) + " KM";
            string price10 = "Price 10: " + pvcP10.CalculateCostOfAllSills(checkBoxSills.Checked, radioS10.Checked, radioS20.Checked, radioS30.Checked, radioS40.Checked, radioS50.Checked) + " KM";
            string price11 = "Total Price: " + UkupnaCijenaSvihArtikala();

            toolStripComboBox1.Items.Add(price1);
            toolStripComboBox1.Items.Add(price2);
            toolStripComboBox1.Items.Add(price3);
            toolStripComboBox1.Items.Add(price4);
            toolStripComboBox1.Items.Add(price5);
            toolStripComboBox1.Items.Add(price6);
            toolStripComboBox1.Items.Add(price7);
            toolStripComboBox1.Items.Add(price8);
            toolStripComboBox1.Items.Add(price9);
            toolStripComboBox1.Items.Add(price10);
            toolStripComboBox1.Items.Add(price11);
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = @"C:\Default";  // Postavljama selektovanje foldera
            DialogResult result = folderBrowserDialog1.ShowDialog();              //dodjeljujemo enumu result-u da Show-a Dialog 
            if (result == DialogResult.OK)                                        //ako klik Ok 
            {
                selectedFolderFileDialog = folderBrowserDialog1.SelectedPath;  //Dodjeljuje stringu selectedFolder"Selekted Path" browser-a
            }
        }

        //private string selectedPdf = "";
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = selectedFolderFileDialog;
            DialogResult result = openFileDialog1.ShowDialog();  //openFileDialog1.ShowDialog() dodjeljujemo enumu result-u
            if (result == DialogResult.OK)                       //da bi na klik OK Show-a Dialog.if(ako je klik Ok)
            {
                //Ime file-a od Komponente openFileDialog sada prosljedjujemo za PDF objektu 
                axAcroPDF1.src = openFileDialog1.FileName;
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        { }

        /// <summary>
        /// Cost of all
        /// </summary>
        private string UkupnaCijenaSvihArtikala()
        {
            decimal p1 = Convert.ToDecimal(pvcP1.CalculateCostOfAll(checkBoxIsoGlass.Checked)); //Dodaj za PDF
            decimal p2 = Convert.ToDecimal(pvcP2.CalculateCostOfAll(checkBoxIsoGlass.Checked));
            decimal p3 = Convert.ToDecimal(pvcP3.CalculateCostOfAll(checkBoxIsoGlass.Checked));
            decimal p4 = Convert.ToDecimal(pvcP4.CalculateCostOfAll(checkBoxIsoGlass.Checked));
            decimal p5 = Convert.ToDecimal(pvcP5.CalculateCostOfAll(checkBoxIsoGlass.Checked));
            decimal p6 = Convert.ToDecimal(pvcP6.CalculateCostOfAll(checkBoxIsoGlass.Checked));
            decimal p7 = Convert.ToDecimal(pvcP7.CalculateCostOfAllDoors());
            decimal p8 = Convert.ToDecimal(pvcP8.CalculateCostOfAllBlinds(checkBoxBlinds.Checked));
            decimal p9 = Convert.ToDecimal(pvcP9.CalculateCostOfAllFence(checkBoxAluFence.Checked, rF80.Checked, rF90.Checked, rF100.Checked, rF110.Checked, rF120.Checked, rF130.Checked, rF140.Checked, rF150.Checked));
            decimal p10 = Convert.ToDecimal(pvcP10.CalculateCostOfAllSills(checkBoxSills.Checked, radioS10.Checked, radioS20.Checked, radioS30.Checked, radioS40.Checked, radioS50.Checked));

            decimal finCost = p1 + p2 + p3 + p4 + p5 + p6 + p7 + p8 + p9 + p10;

            return finCost.ToString("0,0.00.##") + " KM"; //Set total price output for PDF descpiption 
        }

        private void DisplayCostOfAll()
        {
            //CostOfWindowPer_m2() method is needed to handle events of checkBoxes
            //pvcP1.CostOfAluplastWindowPer_m2(checkBoxIdeal400.Checked, checkBoxIdeal500.Checked, checkBoxIdeal800.Checked, checkBoxWintech5K.Checked, checkBoxWintech6K.Checked);
            if (cbxI400.Checked || cbxI500.Checked || cbxI800.Checked)
            {
                pvcP1.CostOfAluplastWindowPer_m2(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                pvcP2.CostOfAluplastWindowPer_m2(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                pvcP3.CostOfAluplastWindowPer_m2(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                pvcP4.CostOfAluplastWindowPer_m2(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                pvcP5.CostOfAluplastWindowPer_m2(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                pvcP6.CostOfAluplastWindowPer_m2(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
            }
            if (cbxW5.Checked || cbxW6.Checked)
            {
                pvcP1.CostOfWintechWindowPer_m2(cbxW5.Checked, cbxW6.Checked);
                pvcP2.CostOfWintechWindowPer_m2(cbxW5.Checked, cbxW6.Checked);
                pvcP3.CostOfWintechWindowPer_m2(cbxW5.Checked, cbxW6.Checked);
                pvcP4.CostOfWintechWindowPer_m2(cbxW5.Checked, cbxW6.Checked);
                pvcP5.CostOfWintechWindowPer_m2(cbxW5.Checked, cbxW6.Checked);
                pvcP6.CostOfWintechWindowPer_m2(cbxW5.Checked, cbxW6.Checked);
            }
            txtCijenaPoKom1.Text = pvcP1.CalculateOnlyOne() + " KM";
            txtUkupnaCijena1.Text = pvcP1.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";
            txtCijenaPoKom2.Text = pvcP2.CalculateOnlyOne() + " KM";
            txtUkupnaCijena2.Text = pvcP2.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";
            txtCijenaPoKom3.Text = pvcP3.CalculateOnlyOne() + " KM";
            txtUkupnaCijena3.Text = pvcP3.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";
            txtCijenaPoKom4.Text = pvcP4.CalculateOnlyOne() + " KM";
            txtUkupnaCijena4.Text = pvcP4.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";
            txtCijenaPoKom5.Text = pvcP5.CalculateOnlyOne() + " KM";
            txtUkupnaCijena5.Text = pvcP5.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";
            txtCijenaPoKom6.Text = pvcP6.CalculateOnlyOne() + " KM";
            txtUkupnaCijena6.Text = pvcP6.CalculateCostOfAll(checkBoxIsoGlass.Checked) + " KM";

            txtCijenaPoKom7.Text = pvcP7.CalculateCostOfOneDoorAluplast(checkBoxIdealDoor.Checked, rT1.Checked, rT2.Checked, rT3.Checked, rT4.Checked, rT5.Checked) + " KM";
            txtUkupnaCijena7.Text = pvcP7.CalculateCostOfAllDoors() + " KM";

            txtCijenaPoKom8.Text = pvcP8.CalculateCostOfOnlyOneBlinds(checkBoxBlinds.Checked) + " KM";
            txtUkupnaCijena8.Text = pvcP8.CalculateCostOfAllBlinds(checkBoxBlinds.Checked) + " KM";

            //txtUkupnaCijena9 and txtUkupnaCijena10 are resolved in doffrent way on another part of code
            //Rest of prices 9 & 10 are built in different pattern, find it in their event-handlers 9 & 10

            DisplayPrices();
        }

        /// <summary>
        /// Set controls 1     ----------------------------------------------------
        /// </summary>
        private void numericUpNumOfObjects1_ValueChanged(object sender, EventArgs e)
        {
            pvcP1.NumberOfObjects = (int)numObj1.Value;
            DisplayCostOfAll();
        }

        private void numericUpHeight_ValueChanged(object sender, EventArgs e)
        {
            pvcP1.Height = (int)numericUpHeight1.Value;
            DisplayCostOfAll();
        }

        private void numericUpWidth_ValueChanged(object sender, EventArgs e)
        {
            pvcP1.Width = (int)numericUpWidth1.Value;
            DisplayCostOfAll();
        }
        /// <summary>
        /// Set controls 2 ----------------------------------------------------------
        /// </summary>
        private void numericUpNumOfObjects2_ValueChanged(object sender, EventArgs e)
        {
            pvcP2.NumberOfObjects = (int)numObj2.Value;
            DisplayCostOfAll();
        }

        private void numericUpHeight2_ValueChanged(object sender, EventArgs e)
        {
            pvcP2.Height = (int)numericUpHeight2.Value;
            DisplayCostOfAll();
        }

        private void numericUpWidth2_ValueChanged(object sender, EventArgs e)
        {
            pvcP2.Width = (int)numericUpWidth2.Value;
            DisplayCostOfAll();
        }

        /// <summary>
        /// Set controls 3   -------------------------------------------------------
        /// </summary>
        private void numericUpNumOfObjects3_ValueChanged(object sender, EventArgs e)
        {
            pvcP3.NumberOfObjects = (int)numObj3.Value;
            DisplayCostOfAll();
        }

        private void numericUpHeight3_ValueChanged(object sender, EventArgs e)
        {
            pvcP3.Height = (int)numericUpHeight3.Value;
            DisplayCostOfAll();
        }

        private void numericUpWidth3_ValueChanged(object sender, EventArgs e)
        {
            pvcP3.Width = (int)numericUpWidth3.Value;
            DisplayCostOfAll();
        }

        /// <summary>
        /// Set controls 4   -------------------------------------------------------
        /// </summary>
        private void numericUpNumOfObjects4_ValueChanged(object sender, EventArgs e)
        {
            pvcP4.NumberOfObjects = (int)numObj4.Value;
            DisplayCostOfAll();
        }

        private void numericUpHeight4_ValueChanged(object sender, EventArgs e)
        {
            pvcP4.Height = (int)numericUpHeight4.Value;
            DisplayCostOfAll();
        }

        private void numericUpWidth4_ValueChanged(object sender, EventArgs e)
        {
            pvcP4.Width = (int)numericUpWidth4.Value;
            DisplayCostOfAll();
        }

        /// <summary>
        /// Set controls 5    -------------------------------------------------------
        /// </summary>
        private void numericUpNumOfObjects5_ValueChanged(object sender, EventArgs e)
        {
            pvcP5.NumberOfObjects = (int)numObj5.Value;
            DisplayCostOfAll();
        }

        private void numericUpHeight5_ValueChanged(object sender, EventArgs e)
        {
            pvcP5.Height = (int)numericUpHeight5.Value;
            DisplayCostOfAll();
        }

        private void numericUpWidth5_ValueChanged(object sender, EventArgs e)
        {
            pvcP5.Width = (int)numericUpWidth5.Value;
            DisplayCostOfAll();
        }

        /// <summary>
        /// Set controls 6   -------------------------------------------------------
        /// </summary>
        private void numericUpNumOfObjects6_ValueChanged(object sender, EventArgs e)
        {
            pvcP6.NumberOfObjects = (int)numObj6.Value;
            DisplayCostOfAll();
        }

        private void numericUpHeight6_ValueChanged(object sender, EventArgs e)
        {
            pvcP6.Height = (int)numericUpHeight6.Value;
            DisplayCostOfAll();
        }

        private void numericUpWidth6_ValueChanged(object sender, EventArgs e)
        {
            pvcP6.Width = (int)numericUpWidth6.Value;
            DisplayCostOfAll();
        }

        /// <summary>
        /// Set controls 7    -------------------------------------------------------
        /// </summary>
        private void numericUpNumberOfObject7_ValueChanged(object sender, EventArgs e)
        {
            CalculateCostOfDoors();
        }

        private void numericUpHeight7_ValueChanged(object sender, EventArgs e)
        {
            pvcP7.Height = (int)numericUpHeight7.Value;
            DisplayCostOfAll();
        }

        private void numericUpWidth7_ValueChanged(object sender, EventArgs e)
        {
            pvcP7.Width = (int)numericUpWidth7.Value;
            DisplayCostOfAll();
        }

        /// <summary>
        /// Set controls 8    -------------------------------------------------------
        /// </summary>
        private void numericUpNumOfObjects8_ValueChanged(object sender, EventArgs e)
        {
            pvcP8.NumberOfObjects = (int)numObj8.Value;
            if (checkBoxBlinds.Checked)
            {
                DisplayCostOfAll();
            }
            else
            {
                txtCijenaPoKom8.Text = "0 KM";
                txtUkupnaCijena8.Text = "0 KM";
            }
        }

        private void checkBoxBlinds_CheckedChanged(object sender, EventArgs e)
        {
            pvcP8.Height = (int)numericUpHeight8.Value;
            if (checkBoxBlinds.Checked)
            {
                checkBoxBlinds.Text = "Selected";
                DisplayCostOfAll();
            }
            else
            {
                checkBoxBlinds.Text = "Select";
                txtUkupnaCijena8.Text = "00.00 KM";
            }
        }

        private void numericUpHeight8_ValueChanged_1(object sender, EventArgs e)
        {
            pvcP8.Height = (int)numericUpHeight8.Value;
            DisplayCostOfAll();
        }

        private void numericUpWidth8_ValueChanged_1(object sender, EventArgs e)
        {
            pvcP8.Width = (int)numericUpWidth8.Value;
            DisplayCostOfAll();
        }

        /// <summary>
        /// Set controls 9    -------------------------------------------------------
        /// </summary>

        private void checkBoxAluFence_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAluFence.Checked)
            {
                checkBoxAluFence.Text = "Selected";
                CalculateCostOfFence();
            }
            else
            {
                checkBoxAluFence.Text = "Select";
                //txtCijenaPoKom9.Text = "00.00 KM";
                txtUkupnaCijena9.Text = "00.00 KM";
            }
        }

        private void numericUpNumOfObjects9_ValueChanged(object sender, EventArgs e)
        {
            //pvcP9.NumberOfObjects = (int)numericUpNumOfObjects9.Value;
            CalculateCostOfFence();
        }

        private void numericUpHeight9_ValueChanged(object sender, EventArgs e)
        {
            pvcP9.Height = (int)numericUpHeight9.Value;
            CalculateCostOfFence();
            //DisplayCostOfAll();
        }

        private void numericUpWidth9_ValueChanged(object sender, EventArgs e)
        {
            pvcP9.Width = (int)numericUpWidth9.Value;
            CalculateCostOfFence();
            //DisplayCostOfAll();
        }


        //SVJESTAN SAM DA OVO NIJE BACKGROUNDWORKER KOJI KORISTI NITOVANJE I TREADING SLEEP(ms)
        //ali za ovaj projekat je bitno postaviti sto vise backgrounda zbog rutine i podsjecanja!

        /// <summary>
        /// Backgroundworker 1
        /// </summary>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                // Use the BackgroundWorker.ReportProgress method to report the % complete
                backgroundWorker1.ReportProgress(i);

                // If the BackgroundWorker.CancellationPending property is true, cancel
                if (backgroundWorker1.CancellationPending)
                {
                    MessageBox.Show("Process Cancelled", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // toolStripProgressBar1.Value = e.ProgressPercentage; //Postavlja proces promjena iz _DoWork(s, e)
            toolStripProgressBar2.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!backgroundWorker1.CancellationPending)
            {
                backgroundWorker1.CancelAsync(); //Zahtjeva zatvaranje toka background operacije
                MessageBox.Show("PDF-file has successfully created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripProgressBar2.Value = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(CreatePDF1(new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35)));
        }

        /// <summary>
        /// BackgroundWorker 2
        /// </summary>
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                // Use the BackgroundWorker.ReportProgress method to report the % complete
                backgroundWorker2.ReportProgress(i);

                // If the BackgroundWorker.CancellationPending property is true, cancel
                if (backgroundWorker2.CancellationPending)
                {
                    MessageBox.Show("Process Cancelled", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // toolStripProgressBar1.Value = e.ProgressPercentage; //Postavlja proces promjena iz _DoWork(s, e)
            toolStripProgressBar2.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!backgroundWorker2.CancellationPending)
            {
                backgroundWorker2.CancelAsync(); //Zahtjeva zatvaranje toka background operacije
                MessageBox.Show("PDF-file has successfully created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripProgressBar2.Value = 0;
            }
        }

        private void btnCreatePDF2_Click(object sender, EventArgs e)
        {
            backgroundWorker2.RunWorkerAsync(CreatePDF2(new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35)));
        }

        /// <summary>
        /// Backgroundworker 3
        /// </summary>
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                // Use the BackgroundWorker.ReportProgress method to report the % complete
                backgroundWorker3.ReportProgress(i);

                // If the BackgroundWorker.CancellationPending property is true, cancel
                if (backgroundWorker3.CancellationPending)
                {
                    MessageBox.Show("Process Cancelled", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }

        private void backgroundWorker3_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //toolStripProgressBar1.Value = e.ProgressPercentage; //Postavlja proces promjena iz _DoWork(s, e)
            toolStripProgressBar2.Value = e.ProgressPercentage;
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!backgroundWorker3.CancellationPending)
            {
                backgroundWorker3.CancelAsync(); //Zahtjeva zatvaranje toka background operacije
                MessageBox.Show("PDF-file has successfully created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripProgressBar2.Value = 0;
            }
        }

        private void btnCreatePDF3_Click(object sender, EventArgs e)
        {
            backgroundWorker3.RunWorkerAsync(CreatePDF3(new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35)));
        }

        /// <summary>
        /// Backgroundworker 4
        /// </summary>
        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                //System.Threading.Thread.Sleep(7);

                // Use the BackgroundWorker.ReportProgress method to report the % complete
                backgroundWorker4.ReportProgress(i);

                // If the BackgroundWorker.CancellationPending property is true, cancel
                if (backgroundWorker4.CancellationPending)
                {
                    MessageBox.Show("Process Cancelled", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }

        private void backgroundWorker4_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //toolStripProgressBar1.Value = e.ProgressPercentage; //Postavlja proces promjena iz _DoWork(s, e)
            toolStripProgressBar2.Value = e.ProgressPercentage;
        }

        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!backgroundWorker4.CancellationPending)
            {
                backgroundWorker4.CancelAsync(); //Zahtjeva zatvaranje toka backgroundW operacije
                MessageBox.Show("PDF-file has successfully created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripProgressBar2.Value = 0;
            }
        }

        private void btnCreatePDF4_Click(object sender, EventArgs e)
        {
            backgroundWorker4.RunWorkerAsync(CreatePDF4(new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35)));
        }

        /// <summary>
        /// BackgroundWorker 5
        /// </summary>
        private void btnCreatePDF5_Click(object sender, EventArgs e)
        {
            backgroundWorker5.RunWorkerAsync(CreatePDF5(new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35)));
        }

        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                // Use the BackgroundWorker.ReportProgress method to report the % complete
                backgroundWorker5.ReportProgress(i);

                // If the BackgroundWorker.CancellationPending property is true, cancel
                if (backgroundWorker5.CancellationPending)
                {
                    MessageBox.Show("Process Cancelled", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }

        private void backgroundWorker5_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //toolStripProgressBar1.Value = e.ProgressPercentage; //Postavlja proces promjena iz _DoWork(s, e)
            toolStripProgressBar2.Value = e.ProgressPercentage;
        }

        private void backgroundWorker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!backgroundWorker5.CancellationPending)
            {
                backgroundWorker5.CancelAsync(); //Zahtjeva zatvaranje toka backgroundW operacije
                MessageBox.Show("PDF-file has successfully created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripProgressBar2.Value = 0;
            }
        }

        /// <summary>
        /// BackgroundWorker 6
        /// </summary>
        private void btnCreatePDF6_Click(object sender, EventArgs e)
        {
            backgroundWorker6.RunWorkerAsync(CreatePDF6(new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35)));
        }

        private void backgroundWorker6_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                // Use the BackgroundWorker.ReportProgress method to report the % complete
                backgroundWorker6.ReportProgress(i);

                // If the BackgroundWorker.CancellationPending property is true, cancel
                if (backgroundWorker6.CancellationPending)
                {
                    MessageBox.Show("Process Cancelled", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }

        private void backgroundWorker6_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //toolStripProgressBar1.Value = e.ProgressPercentage; //Postavlja proces promjena iz _DoWork(s, e)
            toolStripProgressBar2.Value = e.ProgressPercentage;
        }

        private void backgroundWorker6_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!backgroundWorker6.CancellationPending)
            {
                backgroundWorker6.CancelAsync(); //Zahtjeva zatvaranje toka backgroundW operacije
                MessageBox.Show("PDF-file has successfully created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripProgressBar2.Value = 0;
            }
        }

        /// <summary>
        /// BackgroundWorker 7 - - - - - - - - - - - - - - -  - - - - - - - - -  - -
        /// </summary>
        private void btnCreatePDF7_Click(object sender, EventArgs e)
        {
            backgroundWorker7.RunWorkerAsync(CreatePDF7(new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35)));
        }

        private void backgroundWorker7_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                // Use the BackgroundWorker.ReportProgress method to report the % complete
                backgroundWorker7.ReportProgress(i);

                // If the BackgroundWorker.CancellationPending property is true, cancel
                if (backgroundWorker7.CancellationPending)
                {
                    MessageBox.Show("Process Cancelled", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
        }

        private void backgroundWorker7_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //toolStripProgressBar1.Value = e.ProgressPercentage; //Postavlja proces promjena iz _DoWork(s, e)
            toolStripProgressBar2.Value = e.ProgressPercentage;
        }

        private void backgroundWorker7_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!backgroundWorker7.CancellationPending)
            {
                backgroundWorker7.CancelAsync(); //Zahtjeva zatvaranje toka backgroundW operacije
                MessageBox.Show("PDF-file has successfully created", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toolStripProgressBar2.Value = 0;
            }
        }


        /// <summary>
        /// Settings of checkboxes to do include an exclude elementary execution to each other
        /// </summary>
        private void SetRadioCheckBoxesWindows()
        {
            if (cbxI400.Checked)
            {
                txtProfil1.Text = pvcP1.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                txtProfil2.Text = pvcP2.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                txtProfil3.Text = pvcP3.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                txtProfil4.Text = pvcP4.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                txtProfil5.Text = pvcP5.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                txtProfil6.Text = pvcP6.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
            }
            if (cbxI500.Checked)
            {
                txtProfil1.Text = pvcP1.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                txtProfil2.Text = pvcP2.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                txtProfil3.Text = pvcP3.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                txtProfil4.Text = pvcP4.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                txtProfil5.Text = pvcP5.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                txtProfil6.Text = pvcP6.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
            }
            if (cbxI800.Checked)
            {
                txtProfil1.Text = pvcP1.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                txtProfil2.Text = pvcP2.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                txtProfil3.Text = pvcP3.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                txtProfil4.Text = pvcP4.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                txtProfil5.Text = pvcP5.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
                txtProfil6.Text = pvcP6.SetAluplastProfil(cbxI400.Checked, cbxI500.Checked, cbxI800.Checked);
            }
            if (cbxW5.Checked) //Razdvoji IDEAL I WINTECH NA 2 METODE
            {
                txtProfil1.Text = pvcP1.SetWintechProfil(cbxW5.Checked, cbxW6.Checked);
                txtProfil2.Text = pvcP2.SetWintechProfil(cbxW5.Checked, cbxW6.Checked);
                txtProfil3.Text = pvcP3.SetWintechProfil(cbxW5.Checked, cbxW6.Checked);
                txtProfil4.Text = pvcP4.SetWintechProfil(cbxW5.Checked, cbxW6.Checked);
                txtProfil5.Text = pvcP5.SetWintechProfil(cbxW5.Checked, cbxW6.Checked);
                txtProfil6.Text = pvcP6.SetWintechProfil(cbxW5.Checked, cbxW6.Checked);
            }
            if (cbxW6.Checked)
            {
                txtProfil1.Text = pvcP1.SetWintechProfil(cbxW5.Checked, cbxW6.Checked);
                txtProfil2.Text = pvcP2.SetWintechProfil(cbxW5.Checked, cbxW6.Checked);
                txtProfil3.Text = pvcP3.SetWintechProfil(cbxW5.Checked, cbxW6.Checked);
                txtProfil4.Text = pvcP4.SetWintechProfil(cbxW5.Checked, cbxW6.Checked);
                txtProfil5.Text = pvcP5.SetWintechProfil(cbxW5.Checked, cbxW6.Checked);
                txtProfil6.Text = pvcP6.SetWintechProfil(cbxW5.Checked, cbxW6.Checked);
            }
            DisplayCostOfAll();
        }

        private void cbxI400_CheckedChanged(object sender, EventArgs e)
        {
            SetRadioCheckBoxesWindows();
            if (cbxI400.Checked)
                cbxI400.Text = "Selected";
            else
                cbxI400.Text = "Select";
        }

        private void cbxI500_CheckedChanged(object sender, EventArgs e)
        {
            SetRadioCheckBoxesWindows();
            if (cbxI500.Checked)
                cbxI500.Text = "Selected";
            else
                cbxI500.Text = "Select";
        }

        private void cbxI800_CheckedChanged(object sender, EventArgs e)
        {
            SetRadioCheckBoxesWindows();
            if (cbxI800.Checked)
                cbxI800.Text = "Selected";
            else
                cbxI800.Text = "Select";
        }

        private void cbxW5_CheckedChanged_1(object sender, EventArgs e)
        {
            SetRadioCheckBoxesWindows();
            if (cbxW5.Checked)
                cbxW5.Text = "Selected";
            else
                cbxW5.Text = "Select";
        }

        private void cbxW6_CheckedChanged_1(object sender, EventArgs e)
        {
            SetRadioCheckBoxesWindows();
            if (cbxW6.Checked)
                cbxW6.Text = "Selected";
            else
                cbxW6.Text = "Select";
        }

        /// <summary>
        /// Set the door in idealProfile-checkbox
        /// </summary>
        private void checkBoxIdealDoor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIdealDoor.Checked)
            {
                checkBoxIdealDoor.Text = "Selected";
                checkBoxWintechDoor.Checked = false;
                CalculateCostOfDoors();
            }
            else
            {
                checkBoxIdealDoor.Text = "Select";
                txtUkupnaCijena7.Text = "00.00 KM";
            }
        }

        /// <summary>
        /// I'm setting number of doors through numericUpDown7 then in following
        ///cost of one door then cost of all doors with pass their values to appropreate textBoxes
        /// </summary>
        private void CalculateCostOfDoors()
        {
            pvcP7.NumberOfObjects = (int)numObj7.Value;
            if (checkBoxIdealDoor.Checked)
            {
                txtProfil7.Text = "Aluplast IDEAL 4000, petokomorni sistem";
                txtCijenaPoKom7.Text = pvcP7.CalculateCostOfOneDoorAluplast(checkBoxIdealDoor.Checked, rT1.Checked, rT2.Checked, rT3.Checked, rT4.Checked, rT5.Checked) + " KM";
                txtUkupnaCijena7.Text = pvcP7.CalculateCostOfAllDoors() + " KM";
            }
            else if (checkBoxWintechDoor.Checked)
            {
                txtProfil7.Text = "WINTECH, petokomorni sistem";
                txtCijenaPoKom7.Text = pvcP7.CalculateCostOfOneDoorWintech(checkBoxWintechDoor.Checked, rW3.Checked, rW5.Checked, rW7.Checked) + " KM";
                txtUkupnaCijena7.Text = pvcP7.CalculateCostOfAllDoors() + " KM";
            }
            else
            {
                txtCijenaPoKom7.Text = "0 KM";
                txtUkupnaCijena7.Text = "0 KM";
            }
            DisplayPrices();
        }

        private void rT1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfDoors();
        }

        private void rT2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfDoors();
        }

        private void rT3_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfDoors();
        }

        private void rT4_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfDoors();
        }

        private void rT5_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfDoors();
        }

        private void radioWintech300_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfDoors();
        }

        private void radioWintech500_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfDoors();
        }

        private void radioWintech700_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfDoors();
        }

        private void checkBoxWintechDoor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWintechDoor.Checked)
            {
                checkBoxWintechDoor.Text = "Selected";
                checkBoxIdealDoor.Checked = false;
                CalculateCostOfDoors();
            }
            else
            {
                checkBoxWintechDoor.Text = "Select";
                txtUkupnaCijena7.Text = "00.00 KM";
            }
        }

        /// <summary>
        /// Setting fence method which will be passed through every single handler like radioBox 
        /// of fence, numericUpdown, Height and width of fence
        /// </summary>
        private void CalculateCostOfFence()
        {
            pvcP9.NumberOfObjects = (int)numObj9.Value;
            if (checkBoxAluFence.Checked)
            {
                txtCijenaPoKom9.Text = pvcP9.CalculateCostOfFencePer_m2(checkBoxAluFence.Checked, rF80.Checked, rF90.Checked, rF100.Checked, rF110.Checked, rF120.Checked, rF130.Checked, rF140.Checked, rF150.Checked) + " KM";
                txtUkupnaCijena9.Text = pvcP9.CalculateCostOfAllFence(checkBoxAluFence.Checked, rF80.Checked, rF90.Checked, rF100.Checked, rF110.Checked, rF120.Checked, rF130.Checked, rF140.Checked, rF150.Checked) + " KM";
            }
            else
            {
                txtCijenaPoKom9.Text = "0 KM";
                txtUkupnaCijena9.Text = "0 KM";
            }
            DisplayPrices();
        }

        private void rF80_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfFence();
        }

        private void rF90_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfFence();
        }

        private void rF100_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfFence();
        }

        private void rF110_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfFence();
        }

        private void rF120_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfFence();
        }

        private void rF130_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfFence();
        }

        private void rF140_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfFence();
        }

        private void rF150_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfFence();
        }

        /// <summary>
        ///  Set controls 10    ------------------------------------------------------
        /// </summary>
        private void checkBoxSills_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSills.Checked)
            {
                checkBoxSills.Text = "Selected";
                pvcP10.NumberOfObjects = (int)numObj10.Value;
                CalculateCostOfSills();
            }
            else
            {
                checkBoxSills.Text = "Select";
                txtUkupnaCijena10.Text = "0 KM";
            }
        }

        private void numericUpNumOfObjects10_ValueChanged(object sender, EventArgs e)
        {
            pvcP10.NumberOfObjects = (int)numObj10.Value;
            CalculateCostOfSills();
        }

        private void numericUpWidth10_ValueChanged(object sender, EventArgs e)
        {
            pvcP10.Width = (int)numericUpWidth10.Value;
            CalculateCostOfSills();
        }

        private void CalculateCostOfSills()
        {
            pvcP10.NumberOfObjects = (int)numObj10.Value;
            if (checkBoxSills.Checked)
            {
                txtCijenaPoKom10.Text = pvcP10.CalculateCostOfSillsPer_m(checkBoxSills.Checked, radioS10.Checked, radioS20.Checked, radioS30.Checked, radioS40.Checked, radioS50.Checked) + " KM";
                txtUkupnaCijena10.Text = pvcP10.CalculateCostOfAllSills(checkBoxSills.Checked, radioS10.Checked, radioS20.Checked, radioS30.Checked, radioS40.Checked, radioS50.Checked) + " KM";
            }
            else
            {
                txtCijenaPoKom10.Text = "0 KM";
                txtUkupnaCijena10.Text = "0 KM";
            }
            DisplayPrices();
        }

        private void radioS10_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfSills();
        }

        private void tabPage9_Click(object sender, EventArgs e)
        { }



        private void radioS20_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfSills();
        }

        private void radioS30_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfSills();
        }

        private void radioS40_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfSills();
        }

        private void radioS50_CheckedChanged(object sender, EventArgs e)
        {
            CalculateCostOfSills();
        }

        /// <summary>
        /// Adding optional price for triple glass from parent class
        /// </summary>
        private void checkBoxIsoGlass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsoGlass.Checked)
                checkBoxIsoGlass.Text = "Selected";
            else
                checkBoxIsoGlass.Text = "Select";
            DisplayCostOfAll();
        }

        private Document CreatePDF1(Document document)
        {
            Document doc = document;
            //doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = selectedFolderFileDialog;
            saveFileDialog1.Filter = "Pdf Files|*.pdf"; //Postavljamo filter tj.koji format da spasi!!!
            saveFileDialog1.FileName = "Ponuda_1.pdf"; //Postavljamo ime file-a
            DialogResult result = saveFileDialog1.ShowDialog();

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(saveFileDialog1.FileName, FileMode.Create));
            }
            doc.Open();    //Open document to write
                           //Write some content

            //Postavka slike Ikona Firme
            iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("Icon.jpg");
            PNG.ScalePercent(70f);//Odredi procenat velcine slike

            //Pozicioniranje slike:  doc.PageSize.Width - 36f (36f) postavlja lijevu poziciju, a
            //doc.PageSize.Height - 36f - 472f (472f) 
            PNG.SetAbsolutePosition(doc.PageSize.Width - 510f - 72f, doc.PageSize.Height - 36f - 120.6f);
            doc.Add(PNG); //Dodaj za nas dokument Sliku
                          //Paragraph paragraph = new Paragraph(labelInformacije1.Text); //<-"n\"
                          //Now add the above created text using different class object to pdf dcument
                          // doc.Add(paragraph);

            //Roman list nam postavlja Rimske brojeve ispred svake stavke sa inkrementom
            //RomanList romanlist = new RomanList(true, 20);
            List romanlist = new List();

            romanlist.Add(new ListItem("Sarajevo  " + dateTimePicker1.Value));//Ovdje imenujemo kontent nase liste
            romanlist.IndentationLeft = -110f; //Uvuci listu ljevo za 30f; - odredi parametar
            romanlist.Add("PONUDA:  " + txtBPonudaBroj.Text);
            romanlist.Add("Stambeni objekat:  " + txtStambeni.Text);


            //Dodajemo standardnu Listu u Listu koja je postavljena tipa- List.ORDERED
            List list = new List();
            //List list = new List(List.ALPHABETICAL, 40F);
            list.SetListSymbol("\u2022");
            list.IndentationLeft = 150f;
            list.Add(labelInformacije1.Text + "\n" + "\n");
            list.Add(romanlist);    //<= <= <= <= <= DODAJEMO Romanlist
            doc.Add(list);

            //Dodajemo praznu liniju kao u HTML "/hr" tj.kao separator odma poslje Liste
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            p.IndentationLeft = 36f;
            p.IndentationRight = 36f;
            doc.Add(p);

            List list2 = new List();
            list2.IndentationLeft = 36f;
            list2.Add("Pozicija: 1   Kolicina: " + numObj1.Value + "\nP1 Jednokrilni PVC prozor");
            doc.Add(list2);

            List list3 = new List();
            list3.IndentationLeft = 230f;
            //list3
            string podatci_Stavke1 = "Profil: " + txtProfil1.Text + "\n" + "Boja: " + txtBoja1.Text + "\n"
                + "Okov: " + txtOkov1.Text + "\n" + "Ispuna: " + txtIspuna1.Text + "\n" +
                "Visina: " + numericUpHeight1.Value + " cm \n" + "Sirina: " + numericUpWidth1.Value + " cm";

            list3.Add(podatci_Stavke1 + "\n" + "\n" + "Vrijednost sa PDV-om: " + txtCijenaPoKom1.Text +
                "/kom = " + txtUkupnaCijena1.Text + "\n" + "\n");
            doc.Add(list3);

            //Postavka slike Prvog prozara
            iTextSharp.text.Image PNG2 = iTextSharp.text.Image.GetInstance("pvc1.png");
            PNG2.ScalePercent(150f);//Odredi procenat velcine slike

            //Pozicioniranje slike:  doc.PageSize.Width - 36f - 72 "(36f) postavlja lijevu poziciju", a
            //doc.PageSize.Height - 36f - 472f (472f) poziciju za visinu
            PNG2.SetAbsolutePosition(doc.PageSize.Width - 490f - 72f, doc.PageSize.Height - 36f - 410.6f);
            doc.Add(PNG2); //Dodaj za nas dokument Sliku
                           //Paragraph paragraph = new Paragraph(labelInformacije1.Text); //<-"n\"
                           //Now add the above created text using different class object to pdf dcument
                           // doc.Add(paragraph);


            //STAVKA BR. 22222222222222222222222222222222222222222222222222222222222222222222
            //OVDJE DODAJEMO PROIZVOD BROJ 2 Tj. DRUGU STAVKU 
            List list4 = new List();
            list4.IndentationLeft = 36f;
            list4.Add("Pozicija: 2   Kolicina: " + numObj2.Value + "\nP2 Jednokrilni PVC prozor");
            doc.Add(list4);

            List list5 = new List();
            list5.IndentationLeft = 230f;
            //list5
            string podatci_Stavke2 = "Profil: " + txtProfil2.Text + "\n" + "Boja: " + txtBoja2.Text + "\n"
                + "Okov: " + txtOkov2.Text + "\n" + "Ispuna: " + txtIspuna2.Text + "\n" +
                "Visina: " + numericUpHeight2.Value + " cm \n" + "Sirina: " + numericUpWidth2.Value + " cm";

            list5.Add(podatci_Stavke2 + "\n" + "\n" + "Vrijednost sa PDV-om: " + txtCijenaPoKom2.Text +
                "/kom = " + txtUkupnaCijena2.Text + "\n" + "\n");
            doc.Add(list5);


            //Postavka slike DRUGOG PROZORA
            iTextSharp.text.Image PNG3 = iTextSharp.text.Image.GetInstance("pvc2.png");
            PNG3.ScalePercent(140f);//Odredi procenat velcine slike

            //Pozicioniranje slike:  doc.PageSize.Width - 36f - 72 "(36f) postavlja lijevu poziciju", a
            //doc.PageSize.Height - 36f - 472f (472f) poziciju za visinu
            PNG3.SetAbsolutePosition(doc.PageSize.Width - 490f - 72f, doc.PageSize.Height - 36f - 600.6f);
            doc.Add(PNG3); //Dodaj sliku pvc2.png nasem dokumentu

            if (numObj3.Value == 0 && numObj4.Value == 0 || numObj5.Value == 0 && numObj6.Value == 0 || numObj7.Value == 0)
            {
                List list6 = new List();
                list6.IndentationLeft = 36f;
                //string content1 =  "Ukupna cijena sa PDV-om: ";
                list6.Add("Ukupna cijena sa PDV-om: " + UkupnaCijenaSvihArtikala() + "\n" +
                "Uzimanje mjera, prevoz i montaza besplatno." + "\n" +
                "Nacin placanja: Avans 50 - 70 % od dogovorenog iznosa." + "\n" +
                "Ostatak novca isplatiti po izvrsenoj montazi." + "\n" +
                "                                                                                                     S poštovanjem");
                doc.Add(list6);
            }
            doc.Close();
            return doc;
        }

        private Document CreatePDF2(Document document2)
        {
            Document doc2 = document2;
            //doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);

            SaveFileDialog saveFileDialog2 = new SaveFileDialog();
            saveFileDialog2.InitialDirectory = selectedFolderFileDialog;
            saveFileDialog2.Filter = "Pdf Files|*.pdf"; //Postavljamo filter tj.koji format da spasi!!!
            saveFileDialog2.FileName = "Ponuda_2.pdf"; //Postavljamo ime file-a
            DialogResult result = saveFileDialog2.ShowDialog();

            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                PdfWriter wri = PdfWriter.GetInstance(doc2, new FileStream(saveFileDialog2.FileName, FileMode.Create));
            }
            doc2.Open();    //Open document to write
                            //Write some content

            //Postavka slike Ikona Firme
            iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("Icon.jpg");
            PNG.ScalePercent(70f);//Odredi procenat velcine slike

            //Pozicioniranje slike:  doc.PageSize.Width - 36f (36f) postavlja lijevu poziciju, a
            //doc.PageSize.Height - 36f - 472f (472f) 
            PNG.SetAbsolutePosition(doc2.PageSize.Width - 510f - 72f, doc2.PageSize.Height - 36f - 120.6f);
            doc2.Add(PNG); //Dodaj za nas dokument Sliku
                           //Paragraph paragraph = new Paragraph(labelInformacije1.Text); //<-"n\"
                           //Now add the above created text using different class object to pdf dcument
                           // doc.Add(paragraph);

            //Roman list nam postavlja Rimske brojeve ispred svake stavke sa inkrementom
            //RomanList romanlist = new RomanList(true, 20);
            List romanlist = new List();

            romanlist.Add(new ListItem("Sarajevo  " + dateTimePicker1.Value));//Ovdje imenujemo kontent nase liste
            romanlist.IndentationLeft = -110f; //Uvuci listu ljevo za 30f; - odredi parametar
            romanlist.Add("PONUDA:  " + txtBPonudaBroj.Text);
            romanlist.Add("Stambeni objekat:  " + txtStambeni.Text);


            //Dodajemo standardnu Listu u Listu koja je postavljena tipa- List.ORDERED
            List list = new List();
            //List list = new List(List.ALPHABETICAL, 40F);
            list.SetListSymbol("\u2022");
            list.IndentationLeft = 150f;
            list.Add(labelInformacije1.Text + "\n" + "\n");
            list.Add(romanlist);    //<= <= <= <= <= DODAJEMO Romanlist
            doc2.Add(list);

            //Dodajemo praznu liniju kao u HTML "/hr" tj.kao separator odma poslje Liste
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            p.IndentationLeft = 36f;
            p.IndentationRight = 36f;
            doc2.Add(p);

            List list2 = new List();
            list2.IndentationLeft = 36f;
            list2.Add("Pozicija: 3   Kolicina: " + numObj3.Value + "\nP3 Dvokrilni PVC prozor");
            doc2.Add(list2);

            List list3 = new List();
            list3.IndentationLeft = 230f;
            //list3
            string podatci_Stavke3 = "Profil: " + txtProfil3.Text + "\n" + "Boja: " + txtBoja3.Text + "\n"
                + "Okov: " + txtOkov3.Text + "\n" + "Ispuna: " + txtIspuna3.Text + "\n" +
                "Visina: " + numericUpHeight3.Value + " cm \n" + "Sirina: " + numericUpWidth3.Value + " cm";

            list3.Add(podatci_Stavke3 + "\n" + "\n" + "Vrijednost sa PDV-om: " + txtCijenaPoKom3.Text +
                "/kom = " + txtUkupnaCijena3.Text + "\n" + "\n");
            doc2.Add(list3);

            //Postavka slike Prvog prozara
            iTextSharp.text.Image PNG2 = iTextSharp.text.Image.GetInstance("pvc3.png");
            PNG2.ScalePercent(140f);//Odredi procenat velcine slike

            //Pozicioniranje slike:  doc.PageSize.Width - 36f - 72 "(36f) postavlja lijevu poziciju", a
            //doc.PageSize.Height - 36f - 472f (472f) poziciju za visinu
            PNG2.SetAbsolutePosition(doc2.PageSize.Width - 490f - 72f, doc2.PageSize.Height - 36f - 410.6f);
            doc2.Add(PNG2); //Dodaj za nas dokument Sliku
                            //Paragraph paragraph = new Paragraph(labelInformacije1.Text); //<-"n\"
                            //Now add the above created text using different class object to pdf dcument
                            // doc.Add(paragraph);



            //STAVKA BR. 44444444444444444444444444444444444444444444444444444444444444444444444444444

            List list4 = new List();
            list4.IndentationLeft = 36f;
            list4.Add("Pozicija: 4   Kolicina: " + numObj4.Value + "\nP4 Dvokrilni PVC prozor");
            doc2.Add(list4);

            List list5 = new List();
            list5.IndentationLeft = 230f;
            //list5
            string podatci_Stavke4 = "Profil: " + txtProfil4.Text + "\n" + "Boja: " + txtBoja4.Text + "\n"
                + "Okov: " + txtOkov4.Text + "\n" + "Ispuna: " + txtIspuna4.Text + "\n" +
                "Visina: " + numericUpHeight4.Value + " cm \n" + "Sirina: " + numericUpWidth4.Value + " cm";

            list5.Add(podatci_Stavke4 + "\n" + "\n" + "Vrijednost sa PDV-om: " + txtCijenaPoKom4.Text +
                "/kom = " + txtUkupnaCijena4.Text + "\n" + "\n");
            doc2.Add(list5);

            //Postavka slike CETVRTOG PROZORA
            iTextSharp.text.Image PNG3 = iTextSharp.text.Image.GetInstance("pvc4.png");
            PNG3.ScalePercent(140f);//Odredi procenat velcine slike

            //Pozicioniranje slike:  doc.PageSize.Width - 36f - 72 "(36f) postavlja lijevu poziciju", a
            //doc.PageSize.Height - 36f - 472f (472f) poziciju za visinu
            PNG3.SetAbsolutePosition(doc2.PageSize.Width - 490f - 72f, doc2.PageSize.Height - 36f - 600.6f);
            doc2.Add(PNG3); //Dodaj sliku pvc2.png nasem dokumentu

            if (numObj5.Value == 0 && numObj6.Value == 0 || numObj7.Value == 0)
            {
                List list6 = new List();
                list6.IndentationLeft = 36f;
                //string content1 =  "Ukupna cijena sa PDV-om: ";
                list6.Add("Ukupna cijena sa PDV-om: " + UkupnaCijenaSvihArtikala() + "\n" +
                "Uzimanje mjera, prevoz i montaza besplatno." + "\n" +
                "Nacin placanja: Avans 50 - 70 % od dogovorenog iznosa." + "\n" +
                "Ostatak novca isplatiti po izvrsenoj montazi." + "\n" +
                "                                                                                                     S poštovanjem");
                doc2.Add(list6);
            }
            doc2.Close();
            return doc2;
        }

        private void tabPage10_Click(object sender, EventArgs e)
        { }

        private void pictureBox8_Click(object sender, EventArgs e)
        { }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private Document CreatePDF3(Document document3)
        {
            Document doc3 = document3;
            //doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);

            SaveFileDialog saveFileDialog3 = new SaveFileDialog();
            saveFileDialog3.InitialDirectory = selectedFolderFileDialog;
            saveFileDialog3.Filter = "Pdf Files|*.pdf"; //Postavljamo filter tj.koji format da spasi!!!
            saveFileDialog3.FileName = "Ponuda_3.pdf"; //Postavljamo ime file-a
            DialogResult result = saveFileDialog3.ShowDialog();

            if (saveFileDialog3.ShowDialog() == DialogResult.OK)
            {
                PdfWriter wri = PdfWriter.GetInstance(doc3, new FileStream(saveFileDialog3.FileName, FileMode.Create));
            }
            doc3.Open();    //Open document to write
                            //Write some content

            //Postavka slike Ikona Firme
            iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("Icon.jpg");
            PNG.ScalePercent(70f);//Odredi procenat velcine slike

            //Pozicioniranje slike:  doc.PageSize.Width - 36f (36f) postavlja lijevu poziciju, a
            //doc.PageSize.Height - 36f - 472f (472f) 
            PNG.SetAbsolutePosition(doc3.PageSize.Width - 510f - 72f, doc3.PageSize.Height - 36f - 120.6f);
            doc3.Add(PNG); //Dodaj za nas dokument Sliku
                           //Paragraph paragraph = new Paragraph(labelInformacije1.Text); //<-"n\"
                           //Now add the above created text using different class object to pdf dcument
                           // doc.Add(paragraph);

            //Roman list nam postavlja Rimske brojeve ispred svake stavke sa inkrementom
            //RomanList romanlist = new RomanList(true, 20);
            List romanlist = new List();

            romanlist.Add(new ListItem("Sarajevo  " + dateTimePicker1.Value));//Ovdje imenujemo kontent nase liste
            romanlist.IndentationLeft = -110f; //Uvuci listu ljevo za 30f; - odredi parametar
            romanlist.Add("PONUDA:  " + txtBPonudaBroj.Text);
            romanlist.Add("Stambeni objekat:  " + txtStambeni.Text);


            //Dodajemo standardnu Listu u Listu koja je postavljena tipa- List.ORDERED
            List list = new List();
            //List list = new List(List.ALPHABETICAL, 40F);
            list.SetListSymbol("\u2022");
            list.IndentationLeft = 150f;
            list.Add(labelInformacije1.Text + "\n" + "\n");
            list.Add(romanlist);    //<= <= <= <= <= DODAJEMO Romanlist
            doc3.Add(list);

            //Dodajemo praznu liniju kao u HTML "/hr" tj.kao separator odma poslje Liste
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            p.IndentationLeft = 36f;
            p.IndentationRight = 36f;
            doc3.Add(p);

            List list2 = new List();
            list2.IndentationLeft = 36f;
            list2.Add("Pozicija: 5   Kolicina: " + numObj5.Value + "\nP5 Trokrilni PVC prozor");
            doc3.Add(list2);

            List list3 = new List();
            list3.IndentationLeft = 230f;
            //list3
            string podatci_Prve_Stavke = "Profil: " + txtProfil5.Text + "\n" + "Boja: " + txtBoja5.Text + "\n"
                + "Okov: " + txtOkov5.Text + "\n" + "Ispuna: " + txtIspuna5.Text + "\n" +
                "Visina: " + numericUpHeight5.Value + " cm \n" + "Sirina: " + numericUpWidth5.Value + " cm";

            list3.Add(podatci_Prve_Stavke + "\n" + "\n" + "Vrijednost sa PDV-om: " + txtCijenaPoKom5.Text +
                "/kom = " + txtUkupnaCijena5.Text + "\n" + "\n");
            doc3.Add(list3);

            //Postavka slike Prvog prozara
            iTextSharp.text.Image PNG2 = iTextSharp.text.Image.GetInstance("pvc5.png");
            PNG2.ScalePercent(140f);//Odredi procenat velcine slike

            //Pozicioniranje slike:  doc.PageSize.Width - 36f - 72 "(36f) postavlja lijevu poziciju", a
            //doc.PageSize.Height - 36f - 472f (472f) poziciju za visinu
            PNG2.SetAbsolutePosition(doc3.PageSize.Width - 490f - 72f, doc3.PageSize.Height - 36f - 410.6f);
            doc3.Add(PNG2); //Dodaj za nas dokument Sliku
                            //Paragraph paragraph = new Paragraph(labelInformacije1.Text); //<-"n\"
                            //Now add the above created text using different class object to pdf dcument
                            // doc.Add(paragraph);



            //STAVKA BR. 6666666666666666666666666666666666666666666666666666666666666666666666
            //OVDJE DODAJEMO PROIZVOD BROJ 6
            List list4 = new List();
            list4.IndentationLeft = 36f;
            list4.Add("Pozicija: 6   Kolicina: " + numObj6.Value + "\nP5 Cetverokrilni PVC prozor");
            doc3.Add(list4);

            List list5 = new List();
            list5.IndentationLeft = 230f;

            string podatci_Stavke = "Profil: " + txtProfil6.Text + "\n" + "Boja: " + txtBoja6.Text + "\n"
                + "Okov: " + txtOkov6.Text + "\n" + "Ispuna: " + txtIspuna6.Text + "\n" +
                "Visina: " + numericUpHeight6.Value + " cm \n" + "Sirina: " + numericUpWidth6.Value + " cm";

            list5.Add(podatci_Stavke + "\n" + "\n" + "Vrijednost sa PDV-om: " + txtCijenaPoKom6.Text +
                "/kom = " + txtUkupnaCijena6.Text + "\n" + "\n");
            doc3.Add(list5);

            //Postavka slike CETVRTOG PROZORA
            iTextSharp.text.Image PNG3 = iTextSharp.text.Image.GetInstance("pvc6.png");
            PNG3.ScalePercent(140f);//Odredi procenat velcine slike

            //Pozicioniranje slike:  doc.PageSize.Width - 36f - 72 "(36f) postavlja lijevu poziciju", a
            //doc.PageSize.Height - 36f - 472f (472f) poziciju za visinu
            PNG3.SetAbsolutePosition(doc3.PageSize.Width - 490f - 72f, doc3.PageSize.Height - 36f - 600.6f);
            doc3.Add(PNG3); //Dodaj sliku pvc2.png nasem dokumentu

            if (numObj7.Value == 0)
            {
                List list6 = new List();
                list6.IndentationLeft = 36f;
                //string content1 =  "Ukupna cijena sa PDV-om: ";
                list6.Add("Ukupna cijena sa PDV-om: " + UkupnaCijenaSvihArtikala() + "\n" +
                "Uzimanje mjera, prevoz i montaza besplatno." + "\n" +
                "Nacin placanja: Avans 50 - 70 % od dogovorenog iznosa." + "\n" +
                "Ostatak novca isplatiti po izvrsenoj montazi." + "\n" +
                "                                                                                                     S poštovanjem");
                doc3.Add(list6);
            }
            doc3.Close();

            return doc3;
        }

        /// <summary>
        /// Doors
        /// </summary>
        private Document CreatePDF4(Document document4)
        {
            Document doc4 = document4;
            //doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);

            SaveFileDialog saveFileDialog4 = new SaveFileDialog();
            saveFileDialog4.InitialDirectory = selectedFolderFileDialog;
            saveFileDialog4.Filter = "Pdf Files|*.pdf"; //Postavljamo filter tj.koji format da spasi!!!
            saveFileDialog4.FileName = "Ponuda_4.pdf"; //Postavljamo ime file-a
            DialogResult result = saveFileDialog4.ShowDialog();

            if (saveFileDialog4.ShowDialog() == DialogResult.OK)
            {
                PdfWriter wri = PdfWriter.GetInstance(doc4, new FileStream(saveFileDialog4.FileName, FileMode.Create));
            }
            doc4.Open();    //Open document to write
                            //Write some content

            //Postavka slike Ikona Firme
            iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("Icon.jpg");
            PNG.ScalePercent(70f);//Odredi procenat velcine slike

            //Pozicioniranje slike:  doc.PageSize.Width - 36f (36f) postavlja lijevu poziciju, a
            //doc.PageSize.Height - 36f - 472f (472f) 
            PNG.SetAbsolutePosition(doc4.PageSize.Width - 510f - 72f, doc4.PageSize.Height - 36f - 120.6f);
            doc4.Add(PNG); //Dodaj za nas dokument Sliku
                           //Paragraph paragraph = new Paragraph(labelInformacije1.Text); //<-"n\"
                           //Now add the above created text using different class object to pdf dcument
                           // doc.Add(paragraph);

            //Roman list nam postavlja Rimske brojeve ispred svake stavke sa inkrementom
            //RomanList romanlist = new RomanList(true, 20);
            List romanlist = new List();

            romanlist.Add(new ListItem("Sarajevo  " + dateTimePicker1.Value));//Ovdje imenujemo kontent nase liste
            romanlist.IndentationLeft = -110f; //Uvuci listu ljevo za 30f; - odredi parametar
            romanlist.Add("PONUDA:  " + txtBPonudaBroj.Text);
            romanlist.Add("Stambeni objekat:  " + txtStambeni.Text);


            //Dodajemo standardnu Listu u Listu koja je postavljena tipa- List.ORDERED
            List list = new List();
            //List list = new List(List.ALPHABETICAL, 40F);
            list.SetListSymbol("\u2022");
            list.IndentationLeft = 150f;
            list.Add(labelInformacije1.Text + "\n" + "\n");
            list.Add(romanlist);    //<= <= <= <= <= DODAJEMO Romanlist
            doc4.Add(list);

            //Dodajemo praznu liniju kao u HTML "/hr" tj.kao separator odma poslje Liste
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            p.IndentationLeft = 36f;
            p.IndentationRight = 36f;
            doc4.Add(p);

            List list2 = new List();
            list2.IndentationLeft = 36f;
            list2.Add("Pozicija: 7   Kolicina: " + numObj7.Value + "\nP7 Jednokrilna PVC vrata");
            doc4.Add(list2);

            List list3 = new List();
            list3.IndentationLeft = 230f;
            //list3
            string podatci_Stavke = "Profil: " + txtProfil7.Text + "\n" + "Boja: " + txtBoja7.Text + "\n"
                + "Okov: " + txtOkov7.Text + "\n" + "Ispuna: " + txtIspuna7.Text + "\n" +
                "Visina: " + numericUpHeight7.Value + " cm \n" + "Sirina: " + numericUpWidth7.Value + " cm";

            list3.Add(podatci_Stavke + "\n" + "\n" + "Vrijednost sa PDV-om: " + txtCijenaPoKom7.Text +
                "/kom = " + txtUkupnaCijena7.Text + "\n" + "\n");
            doc4.Add(list3);

            //Postavka slike Prvog prozara
            iTextSharp.text.Image PNG2 = iTextSharp.text.Image.GetInstance("pvc7.png");
            PNG2.ScalePercent(170f);//Odredi procenat velcine slike

            //Pozicioniranje slike:  doc.PageSize.Width - 36f - 72 "(36f) postavlja lijevu poziciju", a
            //doc.PageSize.Height - 36f - 472f (472f) poziciju za visinu
            PNG2.SetAbsolutePosition(doc4.PageSize.Width - 490f - 72f, doc4.PageSize.Height - 36f - 420.6f);
            doc4.Add(PNG2); //Dodaj za nas dokument Sliku
                            //Paragraph paragraph = new Paragraph(labelInformacije1.Text);
                            //Now add the above created text using different class object to pdf dcument doc.Add(paragraph);


            List list6 = new List();
            list6.IndentationLeft = 36f;

            //string content1 =  "Ukupna cijena sa PDV-om: ";
            list6.Add("\n");
            list6.Add("Ukupna cijena sa PDV-om: " + UkupnaCijenaSvihArtikala() + "\n" +
             "Uzimanje mjera, prevoz i montaza besplatno." + "\n" +
             "Nacin placanja: Avans 50 - 70 % od dogovorenog iznosa." + "\n" +
             "Ostatak novca isplatiti po izvrsenoj montazi." + "\n" +
             "                                                                                                     S poštovanjem");
            doc4.Add(list6);
            doc4.Close();

            return doc4;
        }

        private Document CreatePDF5(Document document5)
        {
            Document doc5 = document5;

            SaveFileDialog saveFileDialog5 = new SaveFileDialog();
            saveFileDialog5.InitialDirectory = selectedFolderFileDialog;
            saveFileDialog5.Filter = "Pdf Files|*.pdf"; //Postavljamo filter tj.koji format da spasi!!!
            saveFileDialog5.FileName = "Ponuda_5.pdf"; //Postavljamo ime file-a
            DialogResult result = saveFileDialog5.ShowDialog();

            if (saveFileDialog5.ShowDialog() == DialogResult.OK)
            {
                PdfWriter wri = PdfWriter.GetInstance(doc5, new FileStream(saveFileDialog5.FileName, FileMode.Create));
            }
            doc5.Open();    //Open document to write
                            //Write some content

            //Postavka slike Ikona Firme
            iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("Icon.jpg");
            PNG.ScalePercent(70f);//Odredi procenat velcine slike

            //Pozicioniranje slike:  doc.PageSize.Width - 36f (36f) postavlja lijevu poziciju, a
            //doc.PageSize.Height - 36f - 472f (472f) 
            PNG.SetAbsolutePosition(doc5.PageSize.Width - 510f - 72f, doc5.PageSize.Height - 36f - 120.6f);
            doc5.Add(PNG); //Dodaj za nas dokument Sliku
                           //Paragraph paragraph = new Paragraph(labelInformacije1.Text); //<-"n\"
                           //Now add the above created text using different class object to pdf dcument
                           // doc.Add(paragraph);

            //Roman list nam postavlja Rimske brojeve ispred svake stavke sa inkrementom
            //RomanList romanlist = new RomanList(true, 20);
            List romanlist = new List();

            romanlist.Add(new ListItem("Sarajevo  " + dateTimePicker1.Value));//Ovdje imenujemo kontent nase liste
            romanlist.IndentationLeft = -110f; //Uvuci listu ljevo za 30f; - odredi parametar
            romanlist.Add("PONUDA:  " + txtBPonudaBroj.Text);
            romanlist.Add("Stambeni objekat:  " + txtStambeni.Text);


            //Dodajemo standardnu Listu u Listu koja je postavljena tipa- List.ORDERED
            List list = new List();
            //List list = new List(List.ALPHABETICAL, 40F);
            list.SetListSymbol("\u2022");
            list.IndentationLeft = 150f;
            list.Add(labelInformacije1.Text + "\n" + "\n");
            list.Add(romanlist);                // DODAJEMO Romanlist
            doc5.Add(list);

            //Dodajemo praznu liniju kao u HTML "/hr" tj.kao separator odma poslje Liste
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            p.IndentationLeft = 36f;
            p.IndentationRight = 36f;
            doc5.Add(p);

            List list2 = new List();
            list2.IndentationLeft = 36f;
            list2.Add("Pozicija: 8   Kolicina: " + numObj8.Value + "\nP8 ALU-roletna");
            doc5.Add(list2);

            List list3 = new List();
            list3.IndentationLeft = 230f;
            //list3
            string podatci_Stavke = "Profil: " + txtProfil8.Text + "\n" + "Boja: " + txtBoja8.Text + "\n"
                + "Visina: " + numericUpHeight8.Value + " cm \n" + "Sirina: " + numericUpWidth8.Value + " cm";

            list3.Add(podatci_Stavke + "\n" + "\n" + "Vrijednost sa PDV-om: " + txtCijenaPoKom8.Text +
                "/kom = " + txtUkupnaCijena8.Text + "\n" + "\n");
            doc5.Add(list3);

            //Postavka slike Prvog prozara
            iTextSharp.text.Image PNG2 = iTextSharp.text.Image.GetInstance("pvc8.png");
            PNG2.ScalePercent(27f);//Odredi procenat velcine slike

            //Pozicioniranje slike:  doc.PageSize.Width - 36f - 72 "(36f) postavlja lijevu poziciju", a
            //doc.PageSize.Height - 36f - 472f (472f) poziciju za visinu
            PNG2.SetAbsolutePosition(doc5.PageSize.Width - 490f - 72f, doc5.PageSize.Height - 36f - 410.6f);
            doc5.Add(PNG2); //Dodaj za nas dokument Sliku
                            //Paragraph paragraph = new Paragraph(labelInformacije1.Text); //<-"n\"
                            //Now add the above created text using different class object to pdf dcument
                            // doc.Add(paragraph);


            List list6 = new List();
            list6.IndentationLeft = 36f;
            //string content1 =  "Ukupna cijena sa PDV-om: ";
            list6.Add("\n" + "\n" + "\n");
            list6.Add("Ukupna cijena sa PDV-om: " + UkupnaCijenaSvihArtikala() + "\n" +
            "Uzimanje mjera, prevoz i montaza besplatno." + "\n" +
            "Nacin placanja: Avans 50 - 70 % od dogovorenog iznosa." + "\n" +
            "Ostatak novca isplatiti po izvrsenoj montazi." + "\n" +
            "                                                                                                     S poštovanjem");
            doc5.Add(list6);
            doc5.Close();

            return doc5;
        }

        private Document CreatePDF6(Document document6)
        {
            Document doc6 = document6;
            //doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);

            SaveFileDialog saveFileDialog6 = new SaveFileDialog();
            saveFileDialog6.InitialDirectory = selectedFolderFileDialog;
            saveFileDialog6.Filter = "Pdf Files|*.pdf"; //Postavljamo filter tj.koji format da spasi!!!
            saveFileDialog6.FileName = "Ponuda_6.pdf"; //Postavljamo ime file-a
            DialogResult result = saveFileDialog6.ShowDialog();

            if (saveFileDialog6.ShowDialog() == DialogResult.OK)
            {
                PdfWriter wri = PdfWriter.GetInstance(doc6, new FileStream(saveFileDialog6.FileName, FileMode.Create));
            }
            doc6.Open();    //Open document to write
                            //Write some content

            //Postavka slike Ikona Firme
            iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("Icon.jpg");
            PNG.ScalePercent(70f);//Odredi procenat velcine slike

            //Pozicioniranje slike:  doc.PageSize.Width - 36f (36f) postavlja lijevu poziciju, a
            //doc.PageSize.Height - 36f - 472f (472f) 
            PNG.SetAbsolutePosition(doc6.PageSize.Width - 510f - 72f, doc6.PageSize.Height - 36f - 120.6f);
            doc6.Add(PNG); //Dodaj za nas dokument Sliku
                           //Paragraph paragraph = new Paragraph(labelInformacije1.Text); //<-"n\"
                           //Now add the above created text using different class object to pdf dcument
                           // doc.Add(paragraph);

            //Roman list nam postavlja Rimske brojeve ispred svake stavke sa inkrementom
            //RomanList romanlist = new RomanList(true, 20);
            List romanlist = new List();

            romanlist.Add(new ListItem("Sarajevo  " + dateTimePicker1.Value));//Ovdje imenujemo kontent nase liste
            romanlist.IndentationLeft = -110f; //Uvuci listu ljevo za 30f; - odredi parametar
            romanlist.Add("PONUDA:  " + txtBPonudaBroj.Text);
            romanlist.Add("Stambeni objekat:  " + txtStambeni.Text);


            //Dodajemo standardnu Listu u Listu koja je postavljena tipa- List.ORDERED
            List list = new List();
            //List list = new List(List.ALPHABETICAL, 40F);
            list.SetListSymbol("\u2022");
            list.IndentationLeft = 150f;
            list.Add(labelInformacije1.Text + "\n" + "\n");
            list.Add(romanlist);    //<= <= <= <= <= DODAJEMO Romanlist
            doc6.Add(list);

            //Dodajemo praznu liniju kao u HTML "/hr" tj.kao separator odma poslje Liste
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            p.IndentationLeft = 36f;
            p.IndentationRight = 36f;
            doc6.Add(p);

            List list2 = new List();
            list2.IndentationLeft = 36f;
            list2.Add("Pozicija: 9   Kolicina: " + numObj9.Value + "\nP9 Aluminiska ograda");
            doc6.Add(list2);

            List list3 = new List();
            list3.IndentationLeft = 230f;
            //list3
            string podatci_Stavke = "Profil: " + txtProfil9.Text + "\n" + "Boja: " + txtBoja9.Text + "\n"
                + "Visina: " + numericUpHeight9.Value + " cm \n" + "Sirina: " + numericUpWidth9.Value + " cm";

            list3.Add(podatci_Stavke + "\n" + "\n" + "Vrijednost sa PDV-om: " + txtCijenaPoKom9.Text +
                "/kom = " + txtUkupnaCijena9.Text + "\n" + "\n");
            doc6.Add(list3);

            //Postavka slike Prvog prozara
            iTextSharp.text.Image PNG2 = iTextSharp.text.Image.GetInstance("pvc9.png");
            PNG2.ScalePercent(30f);//Odredi procenat velcine slike

            //Pozicioniranje slike:  doc.PageSize.Width - 36f - 72 "(36f) postavlja lijevu poziciju", a
            //doc.PageSize.Height - 36f - 472f (472f) poziciju za visinu
            PNG2.SetAbsolutePosition(doc6.PageSize.Width - 490f - 72f, doc6.PageSize.Height - 36f - 420.6f);
            doc6.Add(PNG2); //Dodaj za nas dokument Sliku
                            //Paragraph paragraph = new Paragraph(labelInformacije1.Text); //<-"n\"
                            //Now add the above created text using different class object to pdf dcument
                            // doc.Add(paragraph);

            List list6 = new List();
            list6.IndentationLeft = 36f;
            //string content1 =  "Ukupna cijena sa PDV-om: ";
            list6.Add("\n" + "\n" + "\n");
            list6.Add("Ukupna cijena sa PDV-om: " + UkupnaCijenaSvihArtikala() + "\n" +
            "Uzimanje mjera, prevoz i montaza besplatno." + "\n" +
            "Nacin placanja: Avans 50 - 70 % od dogovorenog iznosa." + "\n" +
            "Ostatak novca isplatiti po izvrsenoj montazi." + "\n" +
            "                                                                                                     S poštovanjem");
            doc6.Add(list6);
            doc6.Close();

            return doc6;
        }

        private Document CreatePDF7(Document document7)
        {
            Document doc7 = document7;
            //doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);

            SaveFileDialog saveFileDialog7 = new SaveFileDialog();
            saveFileDialog7.InitialDirectory = selectedFolderFileDialog;
            saveFileDialog7.Filter = "Pdf Files|*.pdf"; //Postavljamo filter tj.koji format da spasi!!!
            saveFileDialog7.FileName = "Ponuda_7.pdf"; //Postavljamo ime file-a
            DialogResult result = saveFileDialog7.ShowDialog();

            if (saveFileDialog7.ShowDialog() == DialogResult.OK)
            {
                PdfWriter wri = PdfWriter.GetInstance(doc7, new FileStream(saveFileDialog7.FileName, FileMode.Create));
            }
            doc7.Open();    //Open document to write
                            //Write some content

            //Postavka slike Ikona Firme
            iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("Icon.jpg");
            PNG.ScalePercent(70f);//Odredi procenat velcine slike

            //Pozicioniranje slike:  doc.PageSize.Width - 36f (36f) postavlja lijevu poziciju, a
            //doc.PageSize.Height - 36f - 472f (472f) 
            PNG.SetAbsolutePosition(doc7.PageSize.Width - 510f - 72f, doc7.PageSize.Height - 36f - 120.6f);
            doc7.Add(PNG); //Dodaj za nas dokument Sliku
                           //Paragraph paragraph = new Paragraph(labelInformacije1.Text); //<-"n\"
                           //Now add the above created text using different class object to pdf dcument
                           // doc.Add(paragraph);

            //Roman list nam postavlja Rimske brojeve ispred svake stavke sa inkrementom
            //RomanList romanlist = new RomanList(true, 20);
            List romanlist = new List();

            romanlist.Add(new ListItem("Sarajevo  " + dateTimePicker1.Value));//Ovdje imenujemo kontent nase liste
            romanlist.IndentationLeft = -110f; //Uvuci listu ljevo za 30f; - odredi parametar
            romanlist.Add("PONUDA:  " + txtBPonudaBroj.Text);
            romanlist.Add("Stambeni objekat:  " + txtStambeni.Text);


            //Dodajemo standardnu Listu u Listu koja je postavljena tipa- List.ORDERED
            List list = new List();
            //List list = new List(List.ALPHABETICAL, 40F);
            list.SetListSymbol("\u2022");
            list.IndentationLeft = 150f;
            list.Add(labelInformacije1.Text + "\n" + "\n");
            list.Add(romanlist);    //<= <= <= <= <= DODAJEMO Romanlist
            doc7.Add(list);

            //Dodajemo praznu liniju kao u HTML "/hr" tj.kao separator odma poslje Liste
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            p.IndentationLeft = 36f;
            p.IndentationRight = 36f;
            doc7.Add(p);

            List list2 = new List();
            list2.IndentationLeft = 36f;
            list2.Add("Pozicija: 7   Kolicina: " + numObj7.Value + "\nP10 Klupica PVC");
            doc7.Add(list2);

            List list3 = new List();
            list3.IndentationLeft = 230f;
            //list3
            string podatci_Stavke = "Profil: " + txtProfil10.Text + "\n" + "Boja: " + txtBoja10.Text + "\n"
                                            + "Sirina: " + numericUpWidth10.Value + " cm";

            list3.Add(podatci_Stavke + "\n" + "\n" + "Vrijednost sa PDV-om: " + txtCijenaPoKom10.Text +
                                            "/kom = " + txtUkupnaCijena10.Text + "\n" + "\n");
            doc7.Add(list3);

            //Postavka slike Prvog prozara
            iTextSharp.text.Image PNG2 = iTextSharp.text.Image.GetInstance("pvc10.png");
            PNG2.ScalePercent(110f);//Odredi procenat velcine slike

            //Pozicioniranje slike:  doc.PageSize.Width - 36f - 72 "(36f) postavlja lijevu poziciju", a
            //doc.PageSize.Height - 36f - 472f (472f) poziciju za visinu
            PNG2.SetAbsolutePosition(doc7.PageSize.Width - 490f - 72f, doc7.PageSize.Height - 36f - 425.6f);
            doc7.Add(PNG2); //Dodaj za nas dokument Sliku
                            //Paragraph paragraph = new Paragraph(labelInformacije1.Text); //<-"n\"
                            //Now add the above created text using different class object to pdf dcument
                            // doc.Add(paragraph);


            List list6 = new List();
            list6.IndentationLeft = 36f;
            //string content1 =  "Ukupna cijena sa PDV-om: ";
            list6.Add("\n" + "\n" + "\n");
            list6.Add("Ukupna cijena sa PDV-om: " + UkupnaCijenaSvihArtikala() + "\n" +
            "Uzimanje mjera, prevoz i montaza besplatno." + "\n" +
            "Nacin placanja: Avans 50 - 70 % od dogovorenog iznosa." + "\n" +
            "Ostatak novca isplatiti po izvrsenoj montazi." + "\n" +
            "                                                                                                     S poštovanjem");
            doc7.Add(list6);
            doc7.Close();

            return doc7;
        }

    }
}
