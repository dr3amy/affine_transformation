using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace affine_transformation
{
    public class Lines
    {
        List<Figure> figures;
        public List<Figure> lines;
        Form1 form;
        bool isSelectingLine = false;
        public int selectingLineNumber = -1;

        public Lines(ref List<Figure> figures, Form1 form)
        {
            this.figures = figures; this.form = form;
        }

        /// <summary>
        /// Начать процесс выбора линии для дальнейших преобразований
        /// </summary>
        public void startSelectingLine()
        {
            lines = figures.Where(figure => figure.points.Count == 2).ToList();
            if (lines.Count == 0)
                MessageBox.Show("Вы не нарисовали ни одну линию", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                isSelectingLine = true;
                MessageBox.Show("Выберите нужную линию, переключаясь между ними с помощью клавиши пробела, " +
                "а затем нажмите Enter для выбора", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Всегда выбираем первую доступную линию
                selectFirstLine();
            }
            form.imageToDrawBox.Focus();
        }

        /// <summary>
        /// Выделить i-ю линию 
        /// </summary>
        /// <param name="i"></param>
        private void selectLine(int i)
        {
            if (lines == null) return;
            lines.ForEach(figure => figure.selected = false);
            if (!isSelectingLine) return;
            lines[i].selected = true;
            selectingLineNumber = i;
        }

        /// <summary>
        /// Выделить первую линию
        /// </summary>
        public void selectFirstLine() => selectLine(0);

        /// <summary>
        /// Выделить следующую линию
        /// </summary>
        public void selectNextLine() => selectLine((selectingLineNumber + 1) % lines.Count);

        public bool isLineSelectEnabled => isSelectingLine;

        /// <summary>
        /// Прервать процесс выбора линии
        /// </summary>
        public void stopSelectingLines()
        {
            lines = figures.Where(figure => figure.points.Count == 2).ToList();
            isSelectingLine = false;
            lines.ForEach(figure => figure.selected = false);
            selectingLineNumber = -1;
        }

        /// <summary>
        /// Поворот линии на 90 градусов
        /// </summary>
        public void rotateLine()
        {
            if (lines == null || selectingLineNumber < 0) return;

            Figure selectedLine = lines[selectingLineNumber];

            //Точка центра
            int dx = (int)(Math.Round(selectedLine.points[0].X + selectedLine.points[1].X)) / 2;
            int dy = (int)(Math.Round(selectedLine.points[0].Y + selectedLine.points[1].Y)) / 2;

            //найдем матрицу переноса до точки, вокруг которой делаем поворот
            Matrix33 moveMatrix = new Matrix33(new double[3] { 1, 0, 0 }, new double[3] { 0, 1, 0 }, new double[3] { -dx, -dy, 1 });
            Matrix33 moveMatrix2 = new Matrix33(new double[3] { 1, 0, 0 }, new double[3] { 0, 1, 0 }, new double[3] { dx, dy, 1 });

            Matrix33 rotateMatrix = new Matrix33(new double[3] { 0, 1, 0 }, new double[3] { -1, 0, 0 }, new double[3] { 0, 0, 1 });
            
            for (int i = 0; i < 2; i++)
            {
                Matrix33 pointMatrix = Matrix33.getMatrixFromPoint(selectedLine.points[i]);
                Matrix33 resMatrix = pointMatrix * moveMatrix * rotateMatrix * moveMatrix2;
                selectedLine.points[i] = resMatrix.toPoint();
            }
        }

        /// <summary>
        /// Поиск пересечения выбранной линии и заданной динамически, чьи координаты передаются
        /// </summary>
        public void findIntersectionTwoLines(Point from, Point to)
        {
            if (lines == null || selectingLineNumber < 0) return;
            Figure selectedLine = lines[selectingLineNumber];
            PointF a = selectedLine.points[0];
            PointF b = selectedLine.points[1];

            if (a.X > b.X) //упорядочиваем a, b по Х по возрастанию
            {
                PointF temp = a;
                a = b;
                b = temp;
            }

            PointF c = to;
            PointF d = from;
            if (from.X < to.X) //упорядочиваем c, d по Х по возрастанию
            {
                c = from;
                d = to;
            }
            else if (from == to) //нарисовали точку
            {
                MessageBox.Show("Это точка, а не линия!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PointF res;
            if (d.X - c.X - b.X + a.X == 0 || d.Y - c.Y - b.Y + a.Y == 0)
                MessageBox.Show("Эти линии параллельны => не пересекаются!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                double y, x;
                double a1,a2, b1,b2;
                if (b.Y == a.Y)
                {
                    y = a.Y;
                    a2 = (c.Y - d.Y) / (c.X - d.X);
                    b2 = d.Y - a2 * d.X;
                    x = (y - b2) / a2;
                }
                else if (c.Y == d.Y)
                {
                    y = a.Y;
                    a1 = (a.Y - b.Y) / (a.X - b.X);
                    b1 = b.Y - a1 * b.X;
                    x = (y - b1) / a1;
                }
                else
                {
                    a2 = (c.Y - d.Y) / (c.X - d.X);
                    b2 = d.Y - a2 * d.X;
                    a1 = (a.Y - b.Y) / (a.X - b.X);
                    b1 = b.Y - a1 * b.X;
                    x = (b2 - b1) / (a1 - a2);
                    y = a1 * x + b1;
                }
                
                if (x < 0 && x > form.imageToDrawBox.Width || y < 0 && y > form.imageToDrawBox.Height)
                {
                    MessageBox.Show("Out of bounds", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    res = new PointF((float)x, (float)y);
                    Figure figure = new Figure { points = new List<PointF> { res } };
                    figures.Add(figure);
                }
            }
        }
    }
}
