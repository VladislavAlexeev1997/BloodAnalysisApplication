using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Threading;
using System.Xml;

namespace BloodAnalysisApplication_Client.Model.BloodAnalysis
{
    class Point
    {
        public int x_coord;

        public int y_coord;

        public Point(int x, int y)
        {
            x_coord = x;
            y_coord = y;
        }
    }

    class CellObject
    {
        public Point center_object;

        public string type_object;

        public CellObject(Point center, string type)
        {
            center_object = center;
            type_object = type;
        }
    }

    class ImageContour
    {
        public List<Point> points;

        public ImageContour()
        {
            points = new List<Point>();
        }
    }

    class ImageParameters
    {
        public List<CellObject> objects;

        public List<ImageContour> contours;

        public int allCellsCount;

        public int erithrocyteCount;

        public int leukocyteCount;

        public int nonObjectCount;

        private string analysisResultDirectory;

        private Bitmap imageWithContours;

        public ImageParameters(string analysisNumber)
        {
            objects = new List<CellObject>();
            contours = new List<ImageContour>();
            allCellsCount = 0;
            erithrocyteCount = 0;
            leukocyteCount = 0;
            nonObjectCount = 0;
            analysisResultDirectory = Environment.CurrentDirectory + @"\Database\Results\" + analysisNumber;
            imageWithContours = new Bitmap(analysisResultDirectory + @"\Изображение.jpg");
            ReadImageParameters(analysisNumber);
            DrawContours();
        }

        private void ReadImageParameters(string analysisNumber)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(analysisResultDirectory + @"\Результат.xml");
            XmlElement XMLImage = xDoc.DocumentElement;
            XmlNode XMLCount = XMLImage.SelectSingleNode("count");
            allCellsCount = Convert.ToInt32(XMLCount.SelectSingleNode("all").InnerText);
            erithrocyteCount = Convert.ToInt32(XMLCount.SelectSingleNode("erithrocytes").InnerText);
            leukocyteCount = Convert.ToInt32(XMLCount.SelectSingleNode("leukocytes").InnerText);
            nonObjectCount = Convert.ToInt32(XMLCount.SelectSingleNode("non").InnerText);
            XmlNode XMLObjects = XMLImage.SelectSingleNode("objects");
            foreach (XmlNode XMLObject in XMLObjects.ChildNodes)
            {
                XmlNode XMLContour = XMLObject.SelectSingleNode("contour");
                ImageContour newContour = new ImageContour();
                foreach (XmlNode XMLPoint in XMLContour.ChildNodes)
                {
                    XmlNode XML_x = XMLPoint.SelectSingleNode("x");
                    XmlNode XML_y = XMLPoint.SelectSingleNode("y");
                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    newContour.points.Add(new Point((int)Convert.ToDouble(XML_x.InnerText),
                        (int)Convert.ToDouble(XML_y.InnerText)));
                    Thread.CurrentThread.CurrentCulture = temp_culture;
                }
                contours.Add(newContour);
                XmlNode XMLCells = XMLObject.SelectSingleNode("cells");
                foreach (XmlNode XMLCell in XMLCells.ChildNodes)
                {
                    XmlNode XMLCenter = XMLCell.SelectSingleNode("center");
                    XmlNode XML_x_center = XMLCenter.SelectSingleNode("x");
                    XmlNode XML_y_center = XMLCenter.SelectSingleNode("y");
                    CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    Point center = new Point((int)Convert.ToDouble(XML_x_center.InnerText),
                        (int)Convert.ToDouble(XML_y_center.InnerText));
                    Thread.CurrentThread.CurrentCulture = temp_culture;
                    string type = XMLCell.SelectSingleNode("type").InnerText;
                    CellObject cell_object = new CellObject(center, type);
                    objects.Add(cell_object);
                }
            }
        }

        private void DrawContours()
        {
            foreach (ImageContour contour in contours)
            {
                foreach (Point point in contour.points)
                {
                    imageWithContours.SetPixel(point.x_coord, point.y_coord, Color.Red);
                }
            }
        }

        public Bitmap DrawAllObjects()
        {
            Image image = (Image)imageWithContours.Clone();
            Bitmap imageWithObjects = new Bitmap(image);
            Graphics graphic = Graphics.FromImage(imageWithObjects);
            for (int obj_index = 0; obj_index < objects.Count; obj_index++)
            {
                CellObject select_object = objects[obj_index];
                RectangleF rectf = new RectangleF(select_object.center_object.x_coord - 2,
                    select_object.center_object.y_coord - 2, 16, 16);
                graphic.SmoothingMode = SmoothingMode.AntiAlias;
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.DrawString((obj_index + 1).ToString(), new Font("Times New Roman", 6), Brushes.Black, rectf);
            }
            return imageWithObjects;
        }

        public Bitmap DrawObject(int objectIndex)
        {
            Image image = (Image)imageWithContours.Clone();
            Bitmap imageWithObjects = new Bitmap(image);
            CellObject select_object = objects[objectIndex];
            RectangleF rectf = new RectangleF(select_object.center_object.x_coord - 2,
                select_object.center_object.y_coord - 2, 16, 16);
            Graphics graphic = Graphics.FromImage(imageWithObjects);
            graphic.SmoothingMode = SmoothingMode.AntiAlias;
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.DrawString((objectIndex + 1).ToString(), new Font("Times New Roman", 6), Brushes.Black, rectf);
            return imageWithObjects;
        }
    }
}
