using MedicalPlusFront.WebModels;
using System;
using System.Windows;
using Xceed.Words.NET;

using System.IO;
using System.Windows.Xps.Packaging;
using Spire.Doc;

namespace MedicalPlusFront.View
{
    /// <summary>
    /// Interaction logic for PrintWindow.xaml
    /// </summary>
    public partial class PrintWindow : Window
    {
        private readonly PatientModel _selectedPatient;
        private readonly ProblemModel _selectedProblem;
        private XpsDocument _document;

        public PrintWindow()
        {
            InitializeComponent();
        }

        public PrintWindow(PatientModel patient, ProblemModel problem)
        {
            InitializeComponent();
            _selectedPatient = patient;
            _selectedProblem = problem;
            FillDocument();
            ConvertDocument();
        }


        private void FillDocument()
        {
            using (DocX documentWord = DocX.Load(@"form14.docx"))
            {
                documentWord.InsertAtBookmark($" {DateTime.Now.Day}", "day");
                documentWord.InsertAtBookmark(GetMonthName(DateTime.Now.Month), "month");
                documentWord.InsertAtBookmark(DateTime.Now.Year.ToString(), "year");
                documentWord.InsertAtBookmark(DateTime.Now.ToShortTimeString(), "time");
                documentWord.InsertAtBookmark("NEED DATA", "department");
                documentWord.InsertAtBookmark(_selectedPatient.MedicalCardNumber.ToString(), "medicalCardNumber");
                documentWord.InsertAtBookmark(_selectedPatient.Fio.ToString(), "fio");
                documentWord.InsertAtBookmark(_selectedPatient.BirthDate.Year.ToString(), "age");
                documentWord.InsertAtBookmark(_selectedProblem.OperationDate.ToLocalTime().ToString() + " " + _selectedProblem.OperationType, "operationDateType");
                documentWord.InsertAtBookmark(_selectedProblem.ClinicalData, "clinicalData");
                documentWord.InsertAtBookmark(_selectedProblem.Diagnosis, "clinicalDiagnosis");
                documentWord.InsertAtBookmark(_selectedProblem.MacroDesc + " \n " + _selectedProblem.MicroDesc, "macroMicroDesc");
                if(!Directory.Exists("output"))
                    Directory.CreateDirectory("output");
                documentWord.SaveAs("output/form14Full.docx");
            }


        }

        private void ConvertDocument()
        {
            Spire.Doc.Document doc = new Spire.Doc.Document();
            doc.LoadFromFile("output/form14Full.docx");
            doc.SaveToFile("output/form14Xps.XPS", FileFormat.XPS);

           _document = new XpsDocument("output/form14Xps.XPS", FileAccess.Read);
            DocView.Document = _document.GetFixedDocumentSequence();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _document.Close();
            File.Delete("form14Full.docx");
            File.Delete("form14Xps.XPS");
        }

        private string GetMonthName(int index)
        {
            return index switch
            {
                1 => " січня ",
                2 => " лютого ",
                3 => " березня ",
                4 => " квітня ",
                5 => " травня ",
                6 => " червня ",
                7 => " липня ",
                8 => " серпня ",
                9 => " вересня ",
                10 => " жовтня ",
                11 => " листопада ",
                12 => " грудня ",
                _ => "",
            };
        }
    }
}
