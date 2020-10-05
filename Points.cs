using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace affine_transformation
{
    class Points
    {
        List<Figure> rightPolygon;
        List<Figure> wrongPolygon;
        List<Figure> points;
        Form1 form;
        bool isSelectingPoint = false;
        int selectingPointNumber = -1;

        public Points(ref List<Figure> rightPolygon, ref List<Figure> wrongPolygon, Form1 form)
        {
            this.rightPolygon = rightPolygon;
            this.wrongPolygon = wrongPolygon;
            this.form = form;
        }

        /// <summary>
        /// Начать процесс выбора полигона для дальнейших преобразований.
        /// -1 работа с невыпуклыми, 1 с выпуклыми, 0 - положение точки относительно ребра
        /// </summary>
        public void startSelectingRightPolygon(int mode)
        {
            if (mode == -1)
                points = wrongPolygon;
            else if (mode == 1)
                points = rightPolygon;
            else if (mode == 0)
            {
                points = wrongPolygon;
                points.AddRange(rightPolygon);
            }

            if (points.Count == 0)
                MessageBox.Show("Нет ни одного многоугольника!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                isSelectingPoint = true;
                MessageBox.Show("Выберите нужный многоугольник, переключаясь между ними с помощью клавиши пробела, " +
                "а затем нажмите Enter для выбора", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                selectFirstPoint();
            }
            form.imageToDrawBox.Focus();
        }

        private void selectPoint(int i)
        {
            if (points == null) return;
            points.ForEach(figure => figure.selected = false);
            if (!isSelectingPoint) return;
            points[i].selected = true;
            selectingPointNumber = i;
        }

        /// <summary>
        /// Выделить первую линию
        /// </summary>
        public void selectFirstPoint()
        {
            selectPoint(0);
        }

        /// <summary>
        /// Выделить следующую линию
        /// </summary>
        public void selectNextPoint()
        {
            int nextInd = selectingPointNumber + 1;
            if (nextInd == points.Count) nextInd = 0;
            selectPoint(nextInd);
        }

        public bool isPointSelectEnabled => isSelectingPoint;

        /// <summary>
        /// Прервать процесс выбора линии
        /// </summary>
        public void stopSelectingPoints()
        {
            if (points == null) return;
            isSelectingPoint = false;
            points.ForEach(figure => figure.selected = false);
            selectingPointNumber = -1;
        }

        /// <summary>
        /// Определить положение точки относительно ребра
        /// </summary>
        public void pointAndEdge(Point point, Point edge)
        {
            PointF from = point;
            PointF to = point;
            var polygon = points[selectingPointNumber].points;
            for (int i = 1; i < polygon.Count; i++)
            {
                if (polygon[i - 1].X <= edge.X && polygon[i - 1].Y <= edge.Y
                    && polygon[i].X >= edge.X && polygon[i].Y >= edge.Y)
                {
                    from = polygon[i - 1];
                    to = polygon[i];
                    break;
                }
                if (polygon[i].X <= edge.X && polygon[i].Y >= edge.Y
                    && polygon[i - 1].X >= edge.X && polygon[i - 1].Y <= edge.Y)
                {
                    from = polygon[i];
                    to = polygon[i - 1];
                    break;
                }
            }
            if (polygon[0].X <= edge.X && polygon[0].Y <= edge.Y
                    && polygon[polygon.Count - 1].X >= edge.X && polygon[polygon.Count - 1].Y >= edge.Y)
            {
                from = polygon[0];
                to = polygon[polygon.Count - 1];
            }
            else if (polygon[polygon.Count - 1].X <= edge.X && polygon[polygon.Count - 1].Y <= edge.Y
                    && polygon[0].X >= edge.X && polygon[0].Y >= edge.Y)
            {
                from = polygon[polygon.Count - 1];
                to = polygon[0];
            }

            float x0 = from.X;
            float y0 = from.Y;
            float xB = to.X - x0;
            float yB = to.Y - y0;
            if (yB * (point.X - x0) - xB * (point.Y - y0) > 0)
                MessageBox.Show("Точка слева от выбранного ребра", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (yB * (point.X - x0) - xB * (point.Y - y0) < 0)
                MessageBox.Show("Точка справа от выбранного ребра", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Определить положение точки относительно выпуклого полигона
        /// </summary>
        public void pointInRightPolygon(Point point)
        {
            var polygon = points[selectingPointNumber].points;

            float x0 = polygon[0].X;
            float y0 = polygon[0].Y;
            float xB = polygon[1].X - x0;
            float yB = polygon[1].Y - y0;

            int sign = Math.Sign(yB * (point.X - x0) - xB * (point.Y - y0));
            for (int i = 2; i < polygon.Count; i++)
            {
                x0 = polygon[i - 1].X;
                y0 = polygon[i - 1].Y;
                xB = polygon[i].X - x0;
                yB = polygon[i].Y - y0;

                if (sign * (yB * (point.X - x0) - xB * (point.Y - y0)) < 0)
                {
                    MessageBox.Show("Точка не принадлежит выпуклому многоугольнику", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            x0 = polygon[polygon.Count - 1].X;
            y0 = polygon[polygon.Count - 1].Y;
            xB = polygon[0].X - x0;
            yB = polygon[0].Y - y0;

            if (sign * (yB * (point.X - x0) - xB * (point.Y - y0)) < 0)
            {
                MessageBox.Show("Точка не принадлежит выпуклому многоугольнику", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Точка принадлежит выпуклому многоугольнику", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Определить положение точки относительно невыпуклого полигона
        /// </summary>
        public void pointInWrongPolygon(Point point)
        {
            bool res = false;
            var polygon = points[selectingPointNumber].points;

            float x0 = polygon[0].X;
            float y0 = polygon[0].Y;
            float xB = polygon[1].X - x0;
            float yB = polygon[1].Y - y0;

            int sign = Math.Sign(yB * (point.X - x0) - xB * (point.Y - y0));
            for (int i = 2; i < polygon.Count; i++)
            {
                x0 = polygon[i - 1].X;
                y0 = polygon[i - 1].Y;
                xB = polygon[i].X - x0;
                yB = polygon[i].Y - y0;

                if (sign * (yB * (point.X - x0) - xB * (point.Y - y0)) < 0)
                {
                    res = !res;
                }
            }
            x0 = polygon[polygon.Count - 1].X;
            y0 = polygon[polygon.Count - 1].Y;
            xB = polygon[0].X - x0;
            yB = polygon[0].Y - y0;

            if (sign * (yB * (point.X - x0) - xB * (point.Y - y0)) < 0)
            {
                res = !res;
            }

            if (res)
                MessageBox.Show("Точка не принадлежит невыпуклому многоугольнику", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Точка принадлежит невыпуклому многоугольнику", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}