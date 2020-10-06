using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace affine_transformation
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Список нарисованных фигур
        /// </summary>
        List<Figure> figures = new List<Figure>();

        Polygons polygons; //класс для преобразований полигонов
        Lines lines; // класс для преобразований отрезков
        //Points rightWrongPolygon; // класс для классификации точек относительно полигонов

        /// <summary>
        /// Значение true, если пользователю нужно выбрать точку с помощью мышки как параметр преобразования 
        /// </summary>
        bool isPointSelecting = false;

        /// <summary>
        /// Значение true, если пользователю нужно нарисовать линию с помощью мышки как параметр преобразования 
        /// </summary>
        bool isLineSelectingStart = false;
        bool isLineSelectingFinish = false;

        /// <summary>
        /// Начальная точка задаваемой динамически линии
        /// </summary>
        Point lineFrom;

        public Form1()
        {
            InitializeComponent();
            initDrawing();
            polygons = new Polygons(ref figures, this);
            lines = new Lines(ref figures, this);
            //rightWrongPolygon = new Points(ref polygonList, this);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyPreview = true;
        }

        private void changeRadioButtons(RadioButton currentModeButton)
        {
            if (currentModeButton.Checked) //если выбран один режим, необходимо отключить все другие
            {
                foreach (var possibleGroupBox in Controls)
                {
                    if (possibleGroupBox is GroupBox)
                    {
                        foreach (var control in (possibleGroupBox as GroupBox).Controls)
                            if (control is RadioButton && control != currentModeButton)
                                (control as RadioButton).Checked = false;
                    }
                }
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton currentModeButton = (RadioButton)sender;
            changeRadioButtons(currentModeButton); //служебная функция, вызывается в начале обработки переключения

            //при любом переключении завершаем текущее рисование и добавляем фигуру
            addCurrentBorderToList();

            //при переходе в другой режим отменяется запрос точки у пользователя
            isPointSelecting = false;
            isLineSelectingStart = false;

            //если выбрано рисование полигона, начинаем его рисовать
            if (PolygonRadioButton.Checked) startDrawingPolygon();


            //если выбрана любая операция с рисованием
            if (currentModeButton.Parent == drawingGroupBox && currentModeButton.Checked)
            {
                polygons.stopSelectingPolygon(); //отменяем выделение полигонов
                lines.stopSelectingLines(); //отменяем выделение отрезков
                drawFigures();
            }

            //если выбрана любая операция с преобразованием полигона
            else if (currentModeButton.Parent == polygonGroupBox && currentModeButton.Checked)
            {
                lines.stopSelectingLines(); //отменяем выделение отрезков
                polygons.startSelectingPolygon(); //начинаем процесс выделения полигона
                drawFigures();
            }

            //если выбрана любая операция с отрезками
            else if (currentModeButton.Parent == lineGroupBox && currentModeButton.Checked)
            {
                polygons.stopSelectingPolygon(); //отменяем выделение полигонов
                lines.startSelectingLine();
                drawFigures();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && PolygonRadioButton.Checked) finishDrawingPolygon();

            else if (e.KeyData == Keys.Space && polygons.isPolygonSelectEnabled)
            {
                polygons.selectNextPolygon();
                drawFigures();
            }
            else if (e.KeyData == Keys.Space && lines.isLineSelectEnabled)
            {
                lines.selectNextLine();
                drawFigures();
            }

            else if (e.KeyData == Keys.Enter && polygons.isPolygonSelectEnabled)
            {
                //обработка полигона
                if (movePolygonRadioButton.Checked) polygons.movePolygon();
                else if (rotatePolygonAroundPointRadioButton.Checked)
                {
                    MessageBox.Show("Выберите произвольную точку с помощью ЛКМ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isPointSelecting = true;
                }
                else if (rotatePolygonAroundCenterRadioButton.Checked) polygons.rotatePolygonAroundCenter();
                else if (scalePolygonAroundPointRadioButton.Checked)
                {
                    MessageBox.Show("Выберите произвольную точку с помощью ЛКМ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isPointSelecting = true;
                }
                else if (scalePolygonAroundCenterRadioButton.Checked) polygons.scalePolygonAroundCenter();

                drawFigures(); //отображаем изменения
            }
            else if (e.KeyData == Keys.Enter && lines.isLineSelectEnabled)
            {
                // обработка линий
                if (rotateLineRadioButton.Checked) lines.rotateLine();
                else if (findCrossRadioButton.Checked)
                {
                    MessageBox.Show("Нарисуйте вторую линию с помощью мыши.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isLineSelectingStart = true;
                }
                drawFigures();
            }
        }


        private void imageToDrawBox_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (isPointSelecting) //если сейчас нужно выбрать точку как параметр преобразования
            {
                isPointSelecting = false;
                if (rotatePolygonAroundPointRadioButton.Checked)
                {
                    polygons.rotatePolygonAroundPoint(e.Location);
                    drawFigures(); //отображаем изменения
                }
                else if (scalePolygonAroundPointRadioButton.Checked)
                {
                    polygons.scalePolygonAroundPoint(e.Location);
                    drawFigures(); //отображаем изменения
                }
            }
            else if (isLineSelectingStart) // если нужно дорисовать прямую
            {
                isLineSelectingStart = false;
                isLineSelectingFinish = true;
                lineFrom = e.Location;
                setStartPointOfLine(lineFrom);
            }
            else //если нет, то сейчас можно рисовать
            {
                if (LineRadioButton.Checked) setStartPointOfLine(e.Location);

                else if (PolygonRadioButton.Checked) addPointToCurrentPolygon(e.Location);

                else if (DotRadioButton.Checked) drawPoint(e.Location);
            }
        }
        private void ClearListButton_Click_1(object sender, EventArgs e)
        {
            clearDrawing();
            polygons.stopSelectingPolygon();
        }

        private void imageToDrawBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (LineRadioButton.Checked) setFinishPointOfLine(e.Location);
            else if (isLineSelectingFinish)
            {
                isLineSelectingFinish = false;
                setFinishPointOfLine(e.Location);
                lines.findIntersectionTwoLines(lineFrom, e.Location);
                drawFigures();
            }
        }

       
    }
}
