using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace affine_transformation
{
    /// <summary>
    /// Класс фигуры
    /// </summary>
    public class Figure
    {
        public List<PointF> points = new List<PointF>();
        public bool selected = false;
    }

    public class Polygons
    {
        bool isSelectingPolygon = false;
        List<Figure> figures;
        Form1 form;
        List<Figure> polygons;
        int selectedPolygonInd = -1;

        public Polygons(ref List<Figure> figures, Form1 form)
        {
            this.figures = figures; this.form = form;
        }

        /// <summary>
        /// Начать процесс выбора полигона для дальнейших преобразований
        /// </summary>
        public void startSelectingPolygon()
        {
            polygons = figures.Where(figure => figure.points.Count > 2).ToList();
            if (polygons.Count == 0)
                MessageBox.Show("Вы не нарисовали ни одного полигона", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                isSelectingPolygon = true;
                MessageBox.Show("Выберите нужный полигон, переключаясь между ними с помощью клавиши пробела, " +
                "а затем нажмите Enter для выбора", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                selectFirstPolygon();
            }
            form.imageToDrawBox.Focus();
        }

        private void selectPolygon(int i)
        {
            if (polygons == null) return;
            polygons.ForEach(figure => figure.selected = false);
            if (!isSelectingPolygon) return;
            polygons[i].selected = true;
            selectedPolygonInd = i;
        }

        /// <summary>
        /// Выделить первый полигон
        /// </summary>
        public void selectFirstPolygon()
        {
            selectPolygon(0);
        }

        /// <summary>
        /// Выделить следующий полигон
        /// </summary>
        public void selectNextPolygon()
        {
            int nextInd = selectedPolygonInd + 1;
            if (nextInd == polygons.Count) nextInd = 0;
            selectPolygon(nextInd);
        }

        public bool isPolygonSelectEnabled => isSelectingPolygon;

        /// <summary>
        /// Прервать процесс выбора полигона
        /// </summary>
        public void stopSelectingPolygon()
        {
            polygons = figures.Where(figure => figure.points.Count > 2).ToList();
            isSelectingPolygon = false;
            polygons.ForEach(figure => figure.selected = false);
            selectedPolygonInd = -1;
        }

        /// <summary>
        /// Смещение выбранного полигона
        /// </summary>
        public void movePolygon()
        {
            if (polygons == null || selectedPolygonInd < 0) return;

            var dialogX = new InputBox("Введите смещение по X (целое число)");
            var dialogY = new InputBox("Введите смещение по Y (целое число)");
            int dx = 0, dy = 0;
            if (dialogX.ShowDialog() == DialogResult.Cancel) return;
            if (!int.TryParse(dialogX.ResultText, out dx)) return;
            if (dialogY.ShowDialog() == DialogResult.Cancel) return;
            if (!int.TryParse(dialogY.ResultText, out dy)) return;

            Matrix33 moveMatrix = new Matrix33(new double[3] { 1, 0, 0 }, new double[3] { 0, 1, 0 }, new double[3] { dx, dy, 1 });
            Figure selectedPolygon = polygons[selectedPolygonInd];
            for (int i = 0; i < selectedPolygon.points.Count; i++)
            {
                Matrix33 pointMatrix = Matrix33.getMatrixFromPoint(selectedPolygon.points[i]);
                Matrix33 resMatrix = pointMatrix * moveMatrix;
                selectedPolygon.points[i] = resMatrix.toPoint();
            }
        }

        /// <summary>
        /// Поворот выбранного полигона вокруг точки
        /// </summary>
        public void rotatePolygonAroundPoint(Point point)
        {
            if (polygons == null || selectedPolygonInd < 0) return;

            var dialog = new InputBox("Введите угол поворота (целое число градусов)");
            int deg = 0;
            if (dialog.ShowDialog() == DialogResult.Cancel) return;
            if (!int.TryParse(dialog.ResultText, out deg)) return;

            //найдем матрицу переноса до точки, вокруг которой делаем поворот
            int dx = point.X, dy = point.Y;
            Matrix33 moveMatrix = new Matrix33(new double[3] { 1, 0, 0 }, new double[3] { 0, 1, 0 }, new double[3] { -dx, -dy, 1 });
            Matrix33 moveMatrix2 = new Matrix33(new double[3] { 1, 0, 0 }, new double[3] { 0, 1, 0 }, new double[3] { dx, dy, 1 });

            double angle = deg * Math.PI / 180.0;
            double sin = Math.Sin(angle), cos = Math.Cos(angle);
            Matrix33 rotateMatrix = new Matrix33(new double[3] { cos, sin, 0 }, new double[3] { -sin, cos, 0 }, new double[3] { 0, 0, 1 });
            Figure selectedPolygon = polygons[selectedPolygonInd];
            for (int i = 0; i < selectedPolygon.points.Count; i++)
            {
                Matrix33 pointMatrix = Matrix33.getMatrixFromPoint(selectedPolygon.points[i]);
                Matrix33 resMatrix = pointMatrix * moveMatrix * rotateMatrix * moveMatrix2;
                selectedPolygon.points[i] = resMatrix.toPoint();
            }
        }

        /// <summary>
        /// Найти центр масс фигуры
        /// </summary>
        private Point getMassCenter(Figure figure)
        {
            int x = (int)figure.points.Select(point => point.X).Average();
            int y = (int)figure.points.Select(point => point.Y).Average();
            return new Point(x, y);
        }

        /// <summary>
        /// Поворот выбранного полигона вокруг центра
        /// </summary>
        public void rotatePolygonAroundCenter()
        {
            if (polygons == null || selectedPolygonInd < 0) return;
            Figure selectedPolygon = polygons[selectedPolygonInd];
            Point massCenter = getMassCenter(selectedPolygon);
            rotatePolygonAroundPoint(massCenter);
        }

        /// <summary>
        /// Масштабирование выбранного полигона вокруг точки
        /// </summary>
        public void scalePolygonAroundPoint(Point point)
        {
            if (polygons == null || selectedPolygonInd < 0) return;

            var dialogX = new InputBox("Введите kX (во сколько раз уменьшить, целое или дробное)");
            var dialogY = new InputBox("Введите kY (во сколько раз уменьшить, целое или дробное)");
            double kx = 0, ky = 0;
            if (dialogX.ShowDialog() == DialogResult.Cancel) return;
            if (!double.TryParse(dialogX.ResultText.Replace('.', ','), out kx)) return;
            if (dialogY.ShowDialog() == DialogResult.Cancel) return;
            if (!double.TryParse(dialogY.ResultText.Replace('.', ','), out ky)) return;

            //найдем матрицу переноса до точки, вокруг которой делаем поворот
            int dx = point.X, dy = point.Y;
            Matrix33 moveMatrix = new Matrix33(new double[3] { 1, 0, 0 }, new double[3] { 0, 1, 0 }, new double[3] { -dx, -dy, 1 });
            Matrix33 moveMatrix2 = new Matrix33(new double[3] { 1, 0, 0 }, new double[3] { 0, 1, 0 }, new double[3] { dx, dy, 1 });

            Matrix33 scaleMatrix = new Matrix33(new double[3] { 1 / kx, 0, 0 }, new double[3] { 0, 1 / ky, 0 }, new double[3] { 0, 0, 1 });
            Figure selectedPolygon = polygons[selectedPolygonInd];
            for (int i = 0; i < selectedPolygon.points.Count; i++)
            {
                Matrix33 pointMatrix = Matrix33.getMatrixFromPoint(selectedPolygon.points[i]);
                Matrix33 resMatrix = pointMatrix * moveMatrix * scaleMatrix * moveMatrix2;
                selectedPolygon.points[i] = resMatrix.toPoint();
            }
        }

        /// <summary>
        /// Масштабирование выбранного полигона вокруг центра
        /// </summary>
        public void scalePolygonAroundCenter()
        {
            if (polygons == null || selectedPolygonInd < 0) return;
            Figure selectedPolygon = polygons[selectedPolygonInd];
            Point massCenter = getMassCenter(selectedPolygon);
            scalePolygonAroundPoint(massCenter);
        }
    }
}
