using MedicalPlusFront.WebModels;
using System;
using System.Windows;
using Xceed.Words.NET;

using System.IO;
using System.Windows.Xps.Packaging;
using Spire.Doc;
using System.Drawing.Printing;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Forms;

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
            Document doc = new Document();
            doc.LoadFromFile("output/form14Full.docx");
            doc.SaveToFile("output/form14Xps.xps", FileFormat.XPS);
            doc.Close();    

            _document = new XpsDocument("output/form14Xps.xps", FileAccess.ReadWrite);
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

        private void CommandBinding_Executed_1(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Document doc = new Document();
            doc.LoadFromFile("output/form14Full.docx");

            System.Windows.Forms.PrintDialog dialog = new System.Windows.Forms.PrintDialog
           {
               Document = doc.PrintDocument,
               UseEXDialog = true,
               AllowSomePages = true,
           };

            doc.PrintDocument.PrinterSettings.Duplex = Duplex.Horizontal;
            doc.PrintDocument.PrinterSettings.DefaultPageSettings.Landscape = true;
            doc.PrintDocument.PrinterSettings.DefaultPageSettings.Color = false;

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
           {
               doc.PrintDocument.Print();
           }
           doc.Close();
        }

    }
}
