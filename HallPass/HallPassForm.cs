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
        SheetsService service;
        public HallPassForm()
        {
            InitializeComponent();
        }
        List<Student> students;
        private void HallPassForm_Load(object sender, EventArgs e)
        {


            using (var reader = new StreamReader("students.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                students = csv.GetRecords<Student>().ToList();
            }

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

        private void studentSearch_TextChanged(object sender, EventArgs e)
        {
            studentList.Items.Clear();

            var values = search(studentSearch.Text);
            foreach (Student s in values) {
                studentList.Items.Add(s);
            }
        }

        List<Student> search(String name) {
            List<Student> results = new List<Student>();

            foreach (var student in students) {
                if (Regex.Match(student.ToString(), name,RegexOptions.IgnoreCase).Success)
                    results.Add(student);
            }
            return results;
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            var type = morningRadio.Checked ? "Morning Pass" : "Passing Period";
            var time = DateTime.Now;
            labelPreview.Text = "";

            foreach (Student student in studentList.SelectedItems) {

                labelPreview.Text += $@"
            Type: {type}
            Time: { time }
            ID: {student.studentNumber}
            Name: {student}
            Homeroom: {student.homeroomTeacher}
            Grade: {student.grade}
            ";

                var range = new ValueRange()
                {
                    Values = new List<IList<object>> { new List<object> {
                    time.ToString(), type, student.studentNumber, student.firstName + " " + student.lastName
                } } };
                var append = service.Spreadsheets.Values.Append(range, spreadsheetId, "Passes!A:A");
                append.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                var resp = append.Execute();
            }

        }
    }
}
