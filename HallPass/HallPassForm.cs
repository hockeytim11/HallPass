using CsvHelper;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HallPass
{
    public partial class HallPassForm : Form
    {
        // Define request parameters.
        String spreadsheetId = ConfigurationManager.AppSettings["sheet"];
        DataTable studentsData = new DataTable();
        SheetsService service;
        public HallPassForm()
        {
            InitializeComponent();
        }
        private void HallPassForm_Load(object sender, EventArgs e)
        {

            studentsData.Columns.Add("studentNumber", typeof(string));
            studentsData.Columns.Add("lastName", typeof(string));
            studentsData.Columns.Add("firstName", typeof(string));
            studentsData.Columns.Add("grade", typeof(string));
            studentsData.Columns.Add("homeroomTeacher", typeof(string));

            using (var reader = new StreamReader("students.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                
                foreach (Student student in csv.GetRecords<Student>())
                {
                    studentsData.Rows.Add(student.toRow());
                    if (!gradeSelect.Items.Contains(student.grade))
                    {
                        gradeSelect.Items.Add(student.grade);
                    }
                    if (!homeroom.Items.Contains(student.homeroomTeacher))
                    {
                        homeroom.Items.Add(student.homeroomTeacher);
                    }
                }
            }
            studentsSearch.DataSource = studentsData;

            UserCredential credential;

            // The file token.json stores the user's access and refresh tokens, and is created
            // automatically when the authorization flow completes for the first time.
            string credPath = "token.json";
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromFile("credentials.json").Secrets,
                new string[]{"https://www.googleapis.com/auth/spreadsheets" },
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

        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            var type = morningRadio.Checked ? "Morning Pass" : "Passing Period";
            var time = DateTime.Now;
            labelPreview.Text = "";

            foreach (DataGridViewRow student in studentsSearch.SelectedRows) {
                string id = (string)student.Cells[0].Value;
                string name = (string)student.Cells[1].Value + ", " + (string)student.Cells[2].Value;
                string grade = (string)student.Cells[3].Value;
                string homeroom = (string)student.Cells[4].Value;

                labelPreview.Text += $@"
            Type: {type}
            Time: { time }
            ID: {id}
            Name: {name}
            Homeroom: {homeroom}
            Grade: {grade}
            ";

                var range = new ValueRange()
                {
                    Values = new List<IList<object>> { new List<object> {
                    time.ToString(), type, id, name
                } } };
                var append = service.Spreadsheets.Values.Append(range, spreadsheetId, "Passes!A:A");
                append.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                var resp = append.Execute();
            }

        }

        private void updateFilter() {
            string queries = "";
            if(!String.IsNullOrEmpty(nameSearch.Text))
            {
                queries += $"(firstName LIKE '%{nameSearch.Text}%' OR lastName LIKE '%{nameSearch.Text}%')";
            }
            if(gradeSelect.SelectedItem != null && gradeSelect.SelectedItem != "any")
            {
                if (queries.Length > 0) queries += " AND ";
                queries += $"grade = '{gradeSelect.SelectedItem}'";
            }
            if (homeroom.SelectedItem != null && homeroom.SelectedItem != "any")
            {
                if (queries.Length > 0) queries += " AND ";
                queries += $"homeroomTeacher = '{homeroom.SelectedItem}'";
            }
            studentsData.DefaultView.RowFilter = queries;
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
    }
}
