using System;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace BloodAnalysisApplication_Client.Model.BloodAnalysis
{
    public class BloodAnalyzer
    {
        private readonly Bitmap InputBloodImage;

        private string analysisNumber;

        private string resultsDirectory;

        public BloodAnalyzer(Bitmap _InputBloodImage, string _analysisNumber)
        {
            InputBloodImage = _InputBloodImage;
            analysisNumber = _analysisNumber;
            resultsDirectory = Environment.CurrentDirectory + @"\Database\Results";
        }

        public void RunAnalysis()
        {
            Directory.CreateDirectory(resultsDirectory + @"\" + analysisNumber);
            string imageFileName = resultsDirectory + @"\" +
                analysisNumber + @"\Изображение.jpg";
            InputBloodImage.Save(imageFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            string startProcessParameters =
                @"C:\Applications\BloodAnalysisApplication\BloodAnalysisApplication_Classificator\StartApplication.py " +
                imageFileName;

            Process process = new Process();
            process.StartInfo =
                new ProcessStartInfo(@"C:\Program Files (x86)\Microsoft Visual Studio\Shared\Python36_64\python.exe",
            startProcessParameters)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
        }

        public int ErythrocyteCountImage()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(resultsDirectory + @"\" + analysisNumber + @"\Результат.xml");
            XmlElement XMLImage = xDoc.DocumentElement;
            XmlNode XMLCount = XMLImage.SelectSingleNode("count");
            XmlNode XMLErythrocytes = XMLCount.SelectSingleNode("erithrocytes");
            int erythrocytes = Convert.ToInt32(XMLErythrocytes.InnerText);
            return erythrocytes;
        }

        public double CalculateSmearErythrocytes()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(resultsDirectory + @"\" + analysisNumber + @"\Результат.xml");
            XmlElement XMLImage = xDoc.DocumentElement;
            XmlNode XMLradius = XMLImage.SelectSingleNode("mean_radius");
            XmlNode XMLCount = XMLImage.SelectSingleNode("count");
            XmlNode XMLErythrocytes = XMLCount.SelectSingleNode("erithrocytes");
            int meanBloodRadius = Convert.ToInt32(XMLradius.InnerText);
            int erythrocytes = Convert.ToInt32(XMLErythrocytes.InnerText);
            double smearErythrocytes = (0.001 * erythrocytes * 5.5) / (meanBloodRadius * 0.00179);
            return Math.Round(smearErythrocytes, 1);
        }

        public int LeukocyteCountImage()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(resultsDirectory + @"\" + analysisNumber + @"\Результат.xml");
            XmlElement XMLImage = xDoc.DocumentElement;
            XmlNode XMLCount = XMLImage.SelectSingleNode("count");
            XmlNode XMLLeukocytes = XMLCount.SelectSingleNode("leukocytes");
            int leukocytes = Convert.ToInt32(XMLLeukocytes.InnerText);
            return leukocytes;
        }

        public double CalculateSmearLeukocytes()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(resultsDirectory + @"\" + analysisNumber + @"\Результат.xml");
            XmlElement XMLImage = xDoc.DocumentElement;
            XmlNode XMLradius = XMLImage.SelectSingleNode("mean_radius"); 
            XmlNode XMLCount = XMLImage.SelectSingleNode("count");
            XmlNode XMLLeukocytes = XMLCount.SelectSingleNode("leukocytes");
            int meanBloodRadius = Convert.ToInt32(XMLradius.InnerText);
            int leukocytes = Convert.ToInt32(XMLLeukocytes.InnerText);
            double smearLeukocytes = (leukocytes * 5.5) / (meanBloodRadius * 0.08);
            return Math.Round(smearLeukocytes, 1);
        }

        public void SaveResultAnalysisImage()
        {
            string saveDirectory = Environment.CurrentDirectory + @"\Database\Images\" + analysisNumber;
            Directory.CreateDirectory(saveDirectory);
            InputBloodImage.Save(saveDirectory + @"\Исходное изображение.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}