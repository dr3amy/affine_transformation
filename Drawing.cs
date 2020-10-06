using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace affine_transformation
{
    public partial class Form1 : Form
    {
        Graphics g;
        PointF from, to, start;
        bool drawPolygon = false;
        List<PointF> border;
        Pen drawingPen = new Pen(Color.Black);
        Pen defaultPen = new Pen(Color.Black);
        Pen selectedPen = new Pen(Color.Red);
        List<Figure> polygonList; // выпуклые многоугольники

        /// <summary>
        /// Инициализировать площадь для рисования
        /// </summary>
        private void initDrawing()
        {
            imageToDrawBox.Image = new Bitmap(imageToDrawBox.Width, imageToDrawBox.Height);
            g = Graphics.FromImage(imageToDrawBox.Image);
            g.Clear(Color.White);
            border = new List<PointF>();
            polygonList = new List<Figure>();
        }

        /// <summary>
        /// Очистить поле для рисования
        /// </summary>
        private void clearDrawing()
        {
            imageToDrawBox.Image = new Bitmap(imageToDrawBox.Width, imageToDrawBox.Height);
            g = Graphics.FromImage(imageToDrawBox.Image);
            g.Clear(Color.White);
            imageToDrawBox.Refresh();
            figures.Clear();
            polygonList.Clear();
            startDrawingPolygon();
            imageToDrawBox.Focus();
        }

        /// <summary>
        /// Добавить текущую рисуемую фигуру в список объектов
        /// </summary>
        private void addCurrentBorderToList()
        {
            if (border.Count != 0)
            {
                Figure figure = new Figure() { points = border.ToList() };
                figures.Add(figure);
                polygonList.Add(figure);
            }
            border.Clear();
        }

        /// <summary>
        /// Добавить новую линию к полигону
        /// </summary>
        private void addPointToCurrentPolygon(PointF point)
        {
            border.Add(point);
            if (drawPolygon)
            {
                from = point;
                start = from;
                drawPolygon = false;
            }
            else
            {
                to = point;
                g.DrawLine(drawingPen, from, to);
                imageToDrawBox.Refresh();
                from = point;
            }
        }

        /// <summary>
        /// Завершить рисование полигона (при нажатии на Enter)
        /// </summary>
        private void finishDrawingPolygon()
        {
            if (!drawPolygon)
            {
                g.DrawLine(drawingPen, start, to);
                imageToDrawBox.Refresh();
                addCurrentBorderToList();
                startDrawingPolygon();
            }
        }

        /// <summary>
        /// Ожидать начало рисования нового полигона
        /// </summary>
        private void startDrawingPolygon()
        {
            drawPolygon = true;
        }

        /// <summary>
        /// Начать рисование линии
        /// </summary>
        private void setStartPointOfLine(Point point)
        {
            from = point;
            border.Add(from);
        }

        /// <summary>
        /// Завершить рисование линии
        /// </summary>
        private void setFinishPointOfLine(Point point)
        {
            to = point;
            border.Add(to);
            g.DrawLine(drawingPen, from, to);
            imageToDrawBox.Refresh();
            addCurrentBorderToList();
        }

        /// <summary>
        /// Нарисовать точку
        /// </summary>
        private void drawPoint(PointF point)
        {
            from = point;
            Figure figure = new Figure { points = new List<PointF> { from } };
            figures.Add(figure);
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle((int)from.X, (int)from.Y, 3, 3));
            imageToDrawBox.Refresh();
        }

        /// <summary>
        /// Нарисовать все фигуры
        /// </summary>
        private void drawFigures()
        {
            imageToDrawBox.Image = new Bitmap(imageToDrawBox.Width, imageToDrawBox.Height);
            g = Graphics.FromImage(imageToDrawBox.Image);
            g.Clear(Color.White);

            foreach (var figure in figures)
            {
                drawingPen = figure.selected ? selectedPen : defaultPen;
                var points = figure.points;
                if (points.Count == 1) g.FillRectangle(new SolidBrush(Color.Black), new Rectangle((int)points[0].X, (int)points[0].Y, 3, 3));
                else if (points.Count == 2) g.DrawLine(drawingPen, points[0], points[1]);
                else
                {
                    for (int i = 1; i < points.Count; i++)
                        g.DrawLine(drawingPen, points[i - 1], points[i]);
                    g.DrawLine(drawingPen, points[0], points[points.Count - 1]);
                }
            }
            drawingPen = defaultPen;

            imageToDrawBox.Refresh();
        }
    }
}
