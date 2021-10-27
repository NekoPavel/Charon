using ExcelDataReader;
using Microsoft.Win32;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Charon
{
    public partial class Charon : Form
    {
        public ConcurrentQueue<PrinterResponse> outQueue = new ConcurrentQueue<PrinterResponse>();
        public ConcurrentQueue<string> outQueueAcc = new ConcurrentQueue<string>();

        public Color green = Color.FromArgb(255, 87, 154, 64);
        public Color red = Color.FromArgb(255, 172, 36, 32);
        public Color blue = Color.FromArgb(255, 43, 112, 170);
        public Color yellow = Color.FromArgb(255, 178, 108, 9);
        public Charon(string[] arg)
        {
            InitializeComponent();
            InitializeTheme();
            if (arg.Count() > 0 && arg[0] == "ValmenyBoot")
            {
                using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE", true))
                {
                    if (rk.OpenSubKey("NekoPavel", true) != null)
                    {
                        openFileDialog.InitialDirectory = rk.OpenSubKey("NekoPavel", true).GetValue("SavePath").ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Programmet startades inte via valmenyn!" + Environment.NewLine + @"Använd valmenyn som finns under \\dfs\gem$\Lit\IT-Service\Fabriken Solna\Pavels Program", "Fel!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE", true))
                {
                    if (rk.OpenSubKey("NekoPavel", true) != null)
                    {
                        openFileDialog.InitialDirectory = rk.OpenSubKey("NekoPavel", true).GetValue("SavePath").ToString();
                    }
                    else
                    {
                        if (!WindowsIdentity.GetCurrent().Name.StartsWith("GAIA\\gaisys"))
                        {
                            MessageBox.Show("Programmet kördes inte som gaisys!" + Environment.NewLine + "Startar om", "Fel!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            ProcessStartInfo proc = new ProcessStartInfo();
                            proc.WorkingDirectory = Environment.CurrentDirectory;
                            proc.FileName = "runas.exe";
                            proc.Arguments = $"/user:gaia\\gaisys{WindowsIdentity.GetCurrent().Name.Substring(5)} \"{Assembly.GetEntryAssembly().Location}\"";
                            Process.Start(proc);
                            Environment.Exit(0);
                        }
                    }
                }
            }
        }
        private void InitializeTheme()
        {
            if (ThemeExists())
            {
                SetColours(OpenTheme(GetSelectedTheme()));
            }
        }

        private string GetSelectedTheme()
        {
            using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE", true))
            {
                return rk.OpenSubKey("NekoPavel", true).GetValue("ThemeName").ToString();
            }
        }

        private Color[] OpenTheme(string themeName)
        {
            using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE", true))
            {
                Color[] colours = {
                Color.FromArgb((int)rk.OpenSubKey($"NekoPavel\\{themeName}").GetValue("BackColour")),
                Color.FromArgb((int)rk.OpenSubKey($"NekoPavel\\{themeName}").GetValue("ForeColour")),
                Color.FromArgb((int)rk.OpenSubKey($"NekoPavel\\{themeName}").GetValue("TextColour"))
                };
                return colours;
            }
        }

        private bool ThemeExists()
        {
            using (RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey("SOFTWARE", true))
            {
                return (rk.OpenSubKey("NekoPavel", true) != null && rk.OpenSubKey("NekoPavel", true).GetValue("ThemeName") != null && rk.OpenSubKey("NekoPavel", true).OpenSubKey(rk.OpenSubKey("NekoPavel", true).GetValue("ThemeName").ToString()) != null);
            }
        }

        private void SetColours(Color[] colours)
        {
            foreach (var control in Controls)
            {
                ((Control)control).BackColor = colours[1];
                ((Control)control).ForeColor = colours[2];
            }
            foreach (var control in tableLayoutPanel1.Controls)
            {
                ((Control)control).BackColor = colours[0];
                ((Control)control).ForeColor = colours[2];
            }
            foreach (var control in tableLayoutPanel2.Controls)
            {
                ((Control)control).BackColor = colours[1];
                ((Control)control).ForeColor = colours[2];
            }
            BackColor = colours[0];
            ForeColor = colours[2];
            tableLayoutPanel1.BackColor = BackColor;
            tableLayoutPanel2.BackColor = BackColor;
            openFileButton.BackColor = BackColor;
            defaultSafeprintComboBox.BackColor = colours[1];
        }
        private void showMoreCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (showMoreCheckbox.Checked)
            {
                this.Height = 570;
                outputTextbox1.Visible = true;
                outputTextbox2.Visible = true;
                showMoreCheckbox.Text = "▲ Visa Mer ▲";
            }
            else
            {
                this.Height = 220;
                outputTextbox1.Visible = false;
                outputTextbox2.Visible = false;
                showMoreCheckbox.Text = "▼ Visa Mer ▼";
            }
        }
        private void SFFS_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }
        private void SFFS_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files != null && files.Any() && files.First().Substring(files.First().Length - 5, 5) == ".xlsx")
                inputTextbox.Text = files.First();
        }
        private void openFileButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                inputTextbox.Text = openFileDialog.FileName;

            }
        }
        private void safeprintListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string printer = safeprintListBox.SelectedItem.ToString();
            if (safeprintListBox.CheckedItems.Contains(printer) && !defaultSafeprintComboBox.Items.Contains(printer))
            {
                defaultSafeprintComboBox.Items.Add(printer);
            }
            else if (defaultSafeprintComboBox.Items.Contains(printer))
            {
                if (defaultSafeprintComboBox.SelectedItem != null && defaultSafeprintComboBox.SelectedItem.ToString() == printer)
                {
                    defaultSafeprintComboBox.Items.Remove(printer);
                    defaultSafeprintComboBox.Text = "Välj en:";
                }
                else
                {
                    defaultSafeprintComboBox.Items.Remove(printer);
                }
            }
            if (defaultSafeprintComboBox.Items.Count > 0)
            {
                defaultSafeprintComboBox.Enabled = true;
            }
            else
            {
                defaultSafeprintComboBox.Enabled = false;
            }

        }
        public void WriteToTextbox(string input, bool isFirst)
        {
            if (input != "")
            {
                this.Invoke(new Action(() =>
                {
                    if (isFirst)
                    {
                        outputTextbox1.AppendText(input + Environment.NewLine);
                    }
                    else
                    {
                        outputTextbox2.AppendText(input + Environment.NewLine);
                    }

                }));
            }
        }
        public List<PrinterObject> GetSafeprinters()
        {
            List<PrinterObject> safeprinters = new List<PrinterObject>();
            int printerInt;
            if (safeprintListBox.CheckedItems.Count == 0)
            {
                return null;
            }
            foreach (string printerStr in safeprintListBox.CheckedItems)
            {
                switch (printerStr)
                {
                    case "NKS_Safeprint_01":
                        printerInt = 6015;
                        break;
                    case "SäkerUtskrift_SV_Enkelsidig":
                        printerInt = 3021;
                        break;
                    case "SäkerUtskrift_SV_Dubbelsidig":
                        printerInt = 3295;
                        break;
                    case "SOS_SU_MFP_SV_D_01":
                        printerInt = 4137;
                        break;
                    case "DAN_SU_MFP_SV_D_01":
                        printerInt = 4861;
                        break;
                    case "KAR_SU_MFP_SV_D_01":
                        printerInt = 5302;
                        break;
                    default:
                        printerInt = 0;
                        break;
                }
                bool printerBool;
                if (printerStr == defaultSafeprintComboBox.SelectedItem.ToString())
                {
                    printerBool = true;
                }
                else
                {
                    printerBool = false;
                }
                if (printerInt != 0)
                {
                    safeprinters.Add(new PrinterObject(printerInt, printerBool));
                }
            }
            return safeprinters;
        }
        private void runButton_Click(object sender, EventArgs e)
        {
            runButton.Enabled = false;
            UseWaitCursor = true;
            progressBar.Value = 0;
            showMoreCheckbox.UseWaitCursor = false;
            safeprintListBox.Enabled = false;
            defaultSafeprintComboBox.Enabled = false;
            openFileButton.Enabled = false;
            progressBar.ProgressBarColor = blue;
            DataSet result;
            try
            {
                using (FileStream stream = File.Open(inputTextbox.Text, FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true,
                                ReadHeaderRow = (rowReader) =>
                                {
                                    rowReader.Read();
                                }
                            }
                        });
                    }
                }
                progressBar.Maximum = result.Tables[0].Rows.Count * 3;
                WriteToTextbox($"Flyttar skrivare för {result.Tables[0].Rows.Count} datorer", true);
                Task printerTask = new Task(() => MovePrintersTask(result.Tables[0]));
                printerTask.Start();
                WriteToTextbox($"Flyttar eventuella funktionskonton för {result.Tables[0].Rows.Count} datorer", false);
                Task accountTask = new Task(() => MoveFAccountTask(result.Tables[0]));
                accountTask.Start();
                Task handlePrintersTask = new Task(() =>
                {
                    try
                    {
                        while (!printerTask.IsCompleted || outQueue.Count > 0)
                        {
                            PrinterResponse tempResponse = new PrinterResponse();
                            if (outQueue.TryDequeue(out tempResponse))
                            {
                                string tempString = "";
                                if (tempResponse.installedPrinters[0].name == "Dator hittas inte i SysMan")
                                {
                                    tempString = $"Dator {tempResponse.installedClients[0].name} hittas inte i SysMan";
                                }
                                else if (tempResponse.installedPrinters.Count > 0)
                                {
                                    if (tempResponse.installedPrinters.Count == 1)
                                    {
                                        tempString = $"Installerat skrivaren {tempResponse.installedPrinters[0].name} på {tempResponse.installedClients[0].name}";
                                    }
                                    else if (tempResponse.installedPrinters.Count > 1)
                                    {
                                        string[] printers = new string[tempResponse.installedPrinters.Count];
                                        for (int i = 0; i < tempResponse.installedPrinters.Count; i++)
                                        {
                                            printers[i] = tempResponse.installedPrinters[0].name;
                                        }
                                        tempString = "Installerat skrivarna " + String.Join(" och ", printers) + " på " + tempResponse.installedClients[0].name;
                                    }
                                }
                                else
                                {
                                    tempString = $"Datorn {tempResponse.installedClients[0].name} har inte fått några skrivare";
                                }
                                WriteToTextbox(tempString, true);
                                this.Invoke(new Action(() =>
                                {
                                    progressBar.Value += 1;
                                }));
                            }
                        }
                        WriteToTextbox("Färdig med att flytta skrivare.", true);
                    }
                    catch (Exception ex)
                    {
                        WriteToTextbox(ex.ToString(), true);
                        this.Invoke(new Action(() =>
                        {
                            progressBar.ProgressBarColor = red;
                        }));
                    }
                });
                handlePrintersTask.Start();
                Task handleAccountsTask = new Task(() =>
                {
                    while (!accountTask.IsCompleted || outQueueAcc.Count > 0)
                    {
                        if (outQueueAcc.TryDequeue(out string tempResponse))
                        {
                            WriteToTextbox(tempResponse, false);
                            this.Invoke(new Action(() =>
                            {
                                progressBar.Value += 1;
                            }));
                        }
                    }
                    WriteToTextbox("Färdig med att flytta funktionskonton.", false);
                });
                handleAccountsTask.Start();
                Task unlockGUITask = new Task(() =>
                {
                    handleAccountsTask.Wait();
                    handlePrintersTask.Wait();
                    this.Invoke(new Action(() =>
                    {
                        runButton.Enabled = true;
                        UseWaitCursor = false;
                        safeprintListBox.Enabled = true;
                        defaultSafeprintComboBox.Enabled = true;
                        openFileButton.Enabled = true;

                        if (progressBar.ProgressBarColor == blue)
                        {
                            progressBar.ProgressBarColor = green;
                        }
                    }));
                });
                unlockGUITask.Start();
            }
            catch (IOException)
            {
                MessageBox.Show("Filen du försöker köra är öppen i ett annat program. Vänligen stäng filen i alla andra program!", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                runButton.Enabled = true;
                UseWaitCursor = false;
                safeprintListBox.Enabled = true;
                defaultSafeprintComboBox.Enabled = true;
                openFileButton.Enabled = true;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Välj en fil!", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                runButton.Enabled = true;
                UseWaitCursor = false;
                safeprintListBox.Enabled = true;
                defaultSafeprintComboBox.Enabled = true;
                openFileButton.Enabled = true;
            }
        }
        static string NetResponseToString(string uriString)
        {
            Uri uri = new Uri(uriString);
            WebRequest webRequest = WebRequest.Create(uri);
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            WebResponse webResponse = webRequest.GetResponse();
            Stream receiveStream = webResponse.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(receiveStream, encode);
            Char[] read = new Char[256];

            int count = readStream.Read(read, 0, 256);
            string output = "";
            while (count > 0)
            {
                String Str = new String(read, 0, count);
                output += Str;
                count = readStream.Read(read, 0, 256);
            }
            readStream.Close();
            webResponse.Close();
            return output;
        }
        static string NetRequestToString<T>(string uriString, T requestBody, string requestMethod = "POST")
        {
            var request = WebRequest.Create(uriString);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = requestMethod;
            string json = JsonSerializer.Serialize(requestBody);
            byte[] byteArray = Encoding.UTF8.GetBytes(json);

            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;

            Stream reqStream = request.GetRequestStream();
            reqStream.Write(byteArray, 0, byteArray.Length);

            WebResponse response = request.GetResponse();

            Stream respStream = response.GetResponseStream();

            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(respStream, encode);
            Char[] read = new Char[256];

            int count = readStream.Read(read, 0, 256);
            string output = "";
            while (count > 0)
            {
                String Str = new String(read, 0, count);
                output += Str;
                count = readStream.Read(read, 0, 256);
            }
            readStream.Close();
            respStream.Close();
            reqStream.Close();
            return output;
        }
        public void MovePrintersTask(DataTable dataTable)
        {
            List<PrinterObject> safeprint = GetSafeprinters();
            ParallelOptions options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 10
            };
            _ = Parallel.For(0, dataTable.Rows.Count, options, i =>
              {
                  try
                  {
                      IdLookup idLookupOld = JsonSerializer.Deserialize<IdLookup>(NetResponseToString("http://sysman.sll.se/SysMan/api/Client?name=" + dataTable.Rows[i][0].ToString() + "&take=1&skip=0&type=0&targetActive=1"));
                      IdLookup idLookupNew = JsonSerializer.Deserialize<IdLookup>(NetResponseToString("http://sysman.sll.se/SysMan/api/Client?name=" + dataTable.Rows[i][3].ToString() + "&take=1&skip=0&type=0&targetActive=1"));

                      if (idLookupNew.result.Count > 0 && idLookupOld.result.Count > 0)
                      {
                          InfoLookup infoLookupOld = JsonSerializer.Deserialize<InfoLookup>(NetResponseToString("http://sysman.sll.se/SysMan/api/Reporting/Client?clientId=" + idLookupOld.result[0].id));
                          PrinterRequestBody requestBody = infoLookupOld.ReturnPrinterRequestBody(idLookupNew.result[0].id, safeprint);
                          if (requestBody.printers.Count > 0)
                          {
                              PrinterResponse tempResponce = JsonSerializer.Deserialize<PrinterResponse>(NetRequestToString("http://sysman.sll.se/SysMan/api/v2/printer/install", requestBody));
                              outQueue.Enqueue(tempResponce);
                          }
                          else
                          {
                              outQueue.Enqueue(new PrinterResponse("Datorn har inga skrivare, hoppar över", dataTable.Rows[i][3].ToString()));
                          }
                      }
                      else if (idLookupNew.result.Count == 0)
                      {
                          outQueue.Enqueue(new PrinterResponse("Dator hittas inte i SysMan", dataTable.Rows[i][3].ToString()));
                      }
                      else if (idLookupOld.result.Count == 0)
                      {
                          outQueue.Enqueue(new PrinterResponse("Dator hittas inte i SysMan", dataTable.Rows[i][3].ToString()));
                      }
                  }
                  catch (Exception e)
                  {
                      outQueue.Enqueue(new PrinterResponse(e.ToString(), dataTable.Rows[i][3].ToString()));
                  }


              });
        }
        static string FindFunkKonto(string computerName)
        {
            try
            {
                SearchResultCollection resultCollection = FindADObjects("user", $"(userworkstations=*{computerName}*)(cn=F*)", "cn,userworkstations");
                if (resultCollection.Count > 0)
                {
                    return resultCollection[0].Properties["cn"][0].ToString();
                }
                else
                {
                    return "Nej";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught:\n\n" + e.ToString());
                return null;
            }
        }
        static SearchResultCollection FindADObjects(string adClass, string filter, string attributes = "distinguishedName")
        {
            DirectoryContext dc = new DirectoryContext(DirectoryContextType.Domain, "gaia");
            Domain dn = Domain.GetDomain(dc);
            DirectorySearcher ds = new DirectorySearcher(dn.GetDirectoryEntry(), $"(&(objectCategory={adClass}){filter})");
            ds.SearchScope = SearchScope.Subtree;
            ds.PageSize = 1024;
            ds.PropertiesToLoad.AddRange(attributes.Split(','));
            SearchResultCollection result = ds.FindAll();
            ds.Dispose();

            return result;
        }
        public void MoveFAccountTask(DataTable dataTable)
        {
            ParallelOptions options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 10
            };
            _ = Parallel.For(0, dataTable.Rows.Count, options, i =>
            {
                string fkonto = FindFunkKonto(dataTable.Rows[i][0].ToString());
                if (fkonto == "Nej")
                {
                    //Gamla datorn har inte fkonto
                    outQueueAcc.Enqueue($"{dataTable.Rows[i][0]} har inte funktionskonto");
                    outQueueAcc.Enqueue("");
                }
                else if (fkonto == null)
                {
                    //felmeddelande kekw
                    outQueueAcc.Enqueue($"Dator {dataTable.Rows[i][0]} hittades inte i AD, skippar");
                    outQueueAcc.Enqueue("");
                }
                else
                {
                    //hittat konto
                    SearchResult fkontoResult = FindADObjects("user", $"(name={fkonto})", "*")[0];
                    DirectoryEntry userDE = fkontoResult.GetDirectoryEntry();
                    string hexUserAccountControl = Convert.ToInt32(userDE.Properties["userAccountControl"][0].ToString()).ToString("X");
                    if (hexUserAccountControl.EndsWith("2") || hexUserAccountControl.EndsWith("3") || hexUserAccountControl.EndsWith("a") || hexUserAccountControl.EndsWith("A"))
                    {
                        outQueueAcc.Enqueue($"{fkonto} är inaktivt");
                        outQueueAcc.Enqueue("");
                        //Konto inaktivt
                    }
                    else
                    {
                        if (!userDE.Properties["userWorkstations"].Value.ToString().Contains(dataTable.Rows[i][3].ToString()))
                        {
                            userDE.InvokeSet("userWorkstations", userDE.Properties["userWorkstations"].Value + "," + dataTable.Rows[i][3].ToString());
                            userDE.CommitChanges();
                            outQueueAcc.Enqueue($"Funktionskontot {fkonto} fungerar nu på {String.Join(" och ", userDE.Properties["userWorkstations"].Value.ToString().Split(','))}");
                        }
                        else
                        {
                            outQueueAcc.Enqueue($"Funktionskontot {fkonto} fanns redan på {dataTable.Rows[i][3]}");
                        }
                        SearchResultCollection newComputerResultCollection = FindADObjects("computer", $"(cn={dataTable.Rows[i][3]})", "*");
                        DirectoryEntry newComputerDE = newComputerResultCollection[0].GetDirectoryEntry();
                        if (!newComputerDE.Properties["memberOf"].Cast<string>().ToList().Any(x => x.Contains("F-kontoWS")))
                        {
                            SearchResult fKontoWSGroup = FindADObjects("group", $"(name={dataTable.Rows[i][3].ToString().Substring(0, 3)}_Wrk_F-kontoWS_SLLeKlient)")[0];
                            //SearchResult fKontoWSGroup = FindADObjects("group", $"(name=Kar_Wrk_F-kontoWS_SLLeKlient)")[0];
                            DirectoryEntry groupDE = fKontoWSGroup.GetDirectoryEntry();
                            groupDE.Properties["member"].Add(newComputerDE.Properties["distinguishedName"].Value);
                            groupDE.CommitChanges();
                            outQueueAcc.Enqueue($"Dator {dataTable.Rows[i][3]} har blivit tillagd i {dataTable.Rows[i][3].ToString().Substring(0, 3)}_Wrk_F-kontoWS_SLLeKlient)");
                            //Tillagd i ad-gruppen
                        }
                        else
                        {
                            outQueueAcc.Enqueue($"Dator {dataTable.Rows[i][3]} fanns redan i {dataTable.Rows[i][3].ToString().Substring(0, 3)}_Wrk_F-kontoWS_SLLeKlient)");
                            //redan i F-konto gruppen
                        }


                    }

                }

            });
        }
    }
}
