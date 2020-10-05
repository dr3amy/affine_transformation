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
        /// Начать процесс выбора полигона для дальнейших преобразований
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
                selectFirstLine();
            }
            form.imageToDrawBox.Focus();
        }

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
        public void selectFirstLine()
        {
            selectLine(0);
        }

        /// <summary>
        /// Выделить следующую линию
        /// </summary>
        public void selectNextLine()
        {
            int nextInd = selectingLineNumber + 1;
            if (nextInd == lines.Count) nextInd = 0;
            selectLine(nextInd);
        }

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
            if (selectedLine.points[0].X > selectedLine.points[1].X) //упорядочивание по Х
            {
                var temp = selectedLine.points[0];
                selectedLine.points[0] = selectedLine.points[1];
                selectedLine.points[1] = temp;
            }

            // построение новой прямой
            if (selectedLine.points[0].X != selectedLine.points[1].X)
            {
                if (selectedLine.points[0].Y != selectedLine.points[1].Y) //восходящая и нисходящая прямая
                {
                    float centerX = (selectedLine.points[0].X + selectedLine.points[1].X) / 2;
                    float lengthX = Math.Abs(selectedLine.points[0].X - selectedLine.points[1].X) / 2;
                    float centerY = (selectedLine.points[0].Y + selectedLine.points[1].Y) / 2;
                    float lengthY = Math.Abs(selectedLine.points[0].Y - selectedLine.points[1].Y) / 2;

                    if (selectedLine.points[0].Y > selectedLine.points[1].Y)
                    {
                        selectedLine.points[0] = new PointF(centerX + lengthY, centerY + lengthX);
                        selectedLine.points[1] = new PointF(centerX - lengthY, centerY - lengthX);
                    }
                    else if (selectedLine.points[0].Y < selectedLine.points[1].Y)
                    {
                        selectedLine.points[0] = new PointF(centerX + lengthY, centerY - lengthX);
                        selectedLine.points[1] = new PointF(centerX - lengthY, centerY + lengthX);
                    }
                }
                else if (selectedLine.points[0].Y == selectedLine.points[1].Y) //горизонтальная прямая
                {
                    float centerX = (selectedLine.points[0].X + selectedLine.points[1].X) / 2;
                    float lengthX = Math.Abs(selectedLine.points[0].X - selectedLine.points[1].X) / 2;
                    float y = selectedLine.points[0].Y;
                    selectedLine.points[0] = new PointF(y, centerX + lengthX);
                    selectedLine.points[1] = new PointF(y, centerX - lengthX);
                }
            }
            else if (selectedLine.points[0].X == selectedLine.points[1].X)
            {
                float centerY = (selectedLine.points[0].Y + selectedLine.points[1].Y) / 2;
                float lengthY = Math.Abs(selectedLine.points[0].Y - selectedLine.points[1].Y) / 2;
                float x = selectedLine.points[0].X;
                selectedLine.points[0] = new PointF(centerY + lengthY, x);
                selectedLine.points[1] = new PointF(centerY - lengthY, x);
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
                MessageBox.Show("Это точка, а не линия!!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PointF res;
            if (d.X - c.X - b.X + a.X == 0 || d.Y - c.Y - b.Y + a.Y == 0)
                MessageBox.Show("Эти линии параллельны => не пересекаются!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                double k = (b.Y - a.Y) * (d.Y - c.Y) * (a.X - c.X);
                double l = (b.X - a.X) * (d.Y - c.Y);
                double m = (d.X - c.X) * (b.Y - a.Y);
                double y, x;
                if (l == m)
                    y = 0;
                else
                    y = (l * a.Y - m * c.Y - k) / (l - m);
                if (b.Y == a.Y)
                    x = a.X;
                else
                    x = ((b.X - a.X) * (y - a.Y) / (b.Y - a.Y)) + a.X;
                if (x < 0 && x > form.imageToDrawBox.Width || y < 0 && y > form.imageToDrawBox.Height)
                {
                    MessageBox.Show("Упс, точка за пределами окна...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
