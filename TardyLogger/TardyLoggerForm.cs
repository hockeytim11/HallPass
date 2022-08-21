using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace TardyLogger
{
    public partial class TardyLoggerForm : Form
    {

        // Define request parameters.
        String spreadsheetId = ConfigurationManager.AppSettings["sheet"];
        String logSheet = ConfigurationManager.AppSettings["log"];
        String studentsSheet = ConfigurationManager.AppSettings["students"];
        DataTable studentsData = new DataTable();
        SheetsService service;
        Font font;
        Font font2;
        PrinterSettings printSettings;
        public TardyLoggerForm()
        {
            InitializeComponent();
        }
        private void TardyLogger_load(object sender, EventArgs e)
        {
            UserCredential credential;

            // The file token.json stores the user's access and refresh tokens, and is created
            // automatically when the authorization flow completes for the first time.
            string credPath = "token.json";
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromFile("credentials.json").Secrets,
                new string[] { "https://www.googleapis.com/auth/spreadsheets" },
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
            Console.WriteLine("Credential file saved to: " + credPath);
            // Create Google Sheets API service.
            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Hall Pass",
            });

            font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            font2 = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            studentsData.Columns.Add("StudentID", typeof(string));
            studentsData.Columns.Add("LastName", typeof(string));
            studentsData.Columns.Add("FirstName", typeof(string));
            studentsData.Columns.Add("Grade", typeof(string));
            studentsData.Columns.Add("HomeroomTeacher", typeof(string));

            var req = service.Spreadsheets.Values.Get(spreadsheetId, studentsSheet+"!A:E");
            var studentsResp = req.Execute();
            studentsResp.Values.RemoveAt(0); // remove header row


            foreach (List<Object> student in studentsResp.Values)
            {
                // google strips off trailing empty columns, make them empty strings
                for (int missing = student.Count; missing < 5; missing++)
                {
                    student.Add("");
                }
                studentsData.Rows.Add(student.ToArray());
                if (!gradeSelect.Items.Contains(student[3]))
                {
                    gradeSelect.Items.Add(student[3]);
                }
                if (!homeroom.Items.Contains(student[4]))
                {
                    homeroom.Items.Add(student[4]);
                }
            }
            studentsSearch.DataSource = studentsData;
        }

        String content = "";
        String content2 = "";
        private void PrintButton_Click(object sender, EventArgs e)
        {


            var type = morningRadio.Checked ? "Morning Tardy" : passingRadio.Checked ? "Passing Period Tardy" : "Hall Pass";
            var time = DateTime.Now;

            foreach (DataGridViewRow student in studentsSearch.SelectedRows) {
                string id = (string)student.Cells[0].Value;
                string name = (string)student.Cells[1].Value + ", " + (string)student.Cells[2].Value;
                string grade = (string)student.Cells[3].Value;
                string homeroom = (string)student.Cells[4].Value;
                string from = fromInput.Text;
                string to = toInput.Text;

                content = $@"
STUDENT:
{name}
";
                content2 = $@"
DATE/TIME:
{time.ToString("MMMM d, yyyy  -  hh:mm tt")}

";
                if (hallRadio.Checked)
                {
                    content2 += $@"
FROM: {from}
TO: {to}
";
                } else
                {
                    content2 += $@"
PASS TYPE:
{type}
";
                }

                PrintDocument doc = new PrintDocument();
                doc.DocumentName = $"{type} for {name}";

                if (printSettings == null) {
                    PrintDialog printDialog = new PrintDialog();
                    if (printDialog.ShowDialog() == DialogResult.OK)
                        printSettings = printDialog.PrinterSettings;
                }

                if (printSettings!=null) {
                    printLog.Items.Add($"STUDENT: {name} ID: {id} TIME: {time}");
                    doc.QueryPageSettings += Doc_QueryPageSettings;
                    doc.PrinterSettings = printSettings;
                    doc.PrintPage += new PrintPageEventHandler(passPrint);
                    doc.Print();

                    var range = new ValueRange()
                    {
                        Values = new List<IList<object>> {
                            new List<object> {
                                time.ToString(), type, id, name, grade, homeroom, from, to
                            }
                        }
                    };
                    var append = service.Spreadsheets.Values.Append(range, spreadsheetId, logSheet+"!A1:A");
                    append.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                    append.InsertDataOption = SpreadsheetsResource.ValuesResource.AppendRequest.InsertDataOptionEnum.INSERTROWS;
                    var resp = append.Execute();
                }
            }
        }

        private void Doc_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            e.PageSettings.Margins.Top = 0;
            e.PageSettings.Margins.Bottom = 0;
            e.PageSettings.Margins.Left = 0;
            e.PageSettings.Margins.Right = 0;
        }
        private string EscapeLikeValue(string value)
        {
            StringBuilder sb = new StringBuilder(value.Length);
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                switch (c)
                {
                    case ']':
                    case '[':
                    case '%':
                    case '*':
                        sb.Append("[").Append(c).Append("]");
                        break;
                    case '\'':
                        sb.Append("''");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }

        private void updateFilter() {
            string queries = "";
            if (!String.IsNullOrEmpty(studentId.Text)) {
                queries = $"StudentID LIKE '%{EscapeLikeValue(studentId.Text)}%'";
            } else {
                if (!String.IsNullOrEmpty(nameSearch.Text))
                {
                    string[] parts = nameSearch.Text.Split(',');
                    string lastQuery = parts[0];
                    string firstQuery = parts.Length > 1 ? parts[1] : "";
                    queries += $"(FirstName LIKE '%{EscapeLikeValue(firstQuery.Trim())}%' AND LastName LIKE '%{EscapeLikeValue(lastQuery.Trim())}%')";
                }
                if (gradeSelect.SelectedItem != null && gradeSelect.SelectedItem != "-ALL-")
                {
                    if (queries.Length > 0) queries += " AND ";
                    queries += $"Grade = '{gradeSelect.SelectedItem}'";
                }
                if (homeroom.SelectedItem != null && homeroom.SelectedItem != "-ALL-")
                {
                    if (queries.Length > 0) queries += " AND ";
                    queries += $"HomeroomTeacher = '{homeroom.SelectedItem}'";
                }
            }
            studentsData.DefaultView.RowFilter = queries;
        }

        private void studentId_TextChanged(object sender, EventArgs e)
        {
            updateFilter();
        }

        private void nameSearch_TextChanged(object sender, EventArgs e)
        {
            updateFilter(); 
        }

        private void gradeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateFilter();
        }

        private void homeroom_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateFilter();
        }

        private void passPrint(object sender, PrintPageEventArgs ev)
        {
            var fmt = new StringFormat();
            fmt.Alignment = StringAlignment.Center;
            var headerFile = hallRadio.Checked ? "pass_header.png" : "tardy_header.png";
            var footerFile = hallRadio.Checked ? "pass_footer.png" : "tardy_footer.png";
            ev.Graphics.DrawImage(Image.FromFile(headerFile), new Rectangle(new Point(0,0), new Size(280,140)));
            ev.Graphics.DrawString(content, font, Brushes.Black, new Point(140, 150), fmt);
            ev.Graphics.DrawString(content2, font2, Brushes.Black, new Point(140, 230), fmt);
            ev.Graphics.DrawImage(Image.FromFile(footerFile), new Rectangle(new Point(0, 390), new Size(280, 140)));
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            if(hallRadio.Checked)
            {
                toLabel.Show();
                fromLabel.Show();
                toInput.Show();
                fromInput.Show();
            } else
            {
                toLabel.Hide();
                fromLabel.Hide();
                toInput.Hide();
                fromInput.Hide();
            }
        }
    }
}
