using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Задание_2_5_
{
    public partial class Form1 : Form
    {

        public Form1()//Создание экземпляра формы
        {
            InitializeComponent();//Инициализация формы

            

        }

        //private void Form1_Load(object sender, EventArgs e)
        //{


        //}


        


        public void btnFileName_Click(object sender, EventArgs e)//Кнопка создания файла с именем, которое задает пользователь
        {
            String Filename = textBox1.Text;

            TextWriter sw = new StreamWriter(@"D:\" + Filename + ".txt");//создание файла на рабочем столе


            try
            {
                //Цикл записи данных в файл из таблицы 1
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {                      
                        sw.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + (" "));
                    }
                    sw.WriteLine();
                }
            }
            catch (Exception ex)//исключение, если запись не прошла
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();//закрытие файла после записи
            }

            label9.Text = "Запись прошла успешно";
        }




        private void btnVvodData_Click(object sender, EventArgs e) //Кнопка завершения ввода данных
        {
            dataGridView1.AllowUserToAddRows = false; //Запрет на редактирование таблицы 1
           
            int n, m;

            n = dataGridView1.Columns.Count; // показывает итоговое количество столбцов в таблице 1
            label6.Text = n.ToString();

            m = dataGridView1.Rows.Count;// показывает итоговое количество строк в таблице 1
            label8.Text = m.ToString();


        }

        private void btnClose_Click(object sender, EventArgs e)//кнопка закрытия
        {
            Close(); //закрывает форму
        }

        public void btnOpenData_Click(object sender, EventArgs e) //Кнопка открытия файла и перенос данных в таблицу 2 и текстбокс 2 
        {

            bool btn = true;
            if (btn == true) //Если кнопка нажата
            {
                

                String Filename = textBox1.Text; //Имя файла, заданное пользователем из текстбокса 1

                DataTable table = new DataTable(); //Создание новой таблицы в DataGridView2


                StreamReader rd = new StreamReader(@"D:\" + Filename + ".txt"); //Открытие файла с данными
                string[] str;
                int num = 0;

                try //Цикл записи данных в таблицу 2 и текстбокс 2
                {
                    string[] str1 = rd.ReadToEnd().Split('\n'); //Прочтение всего файла построчно
                    num = str1.Count();
                  

                    dataGridView2.RowCount = num;

                    for (int i = 0; i < num; i++)
                    {
                        
                            str = str1[i].Split(' ');
                        
                        
                        
                        for (int j = 0; j < dataGridView2.ColumnCount; j++)
                        {
                            try
                            {

                                dataGridView2.Rows[i].Cells[j].Value = str[j];
                            }

                            catch { }
                        }
                    }
                }
                catch (Exception ex) //Исключение, если запись не удалась
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    rd.Close();//закрытие файла
                }

                dataGridView2.AllowUserToAddRows = false; //Запрет на редактирование Таблицы 2
            }


            textBox2_TextChanged(); //Вызов метода
        }

        public void textBox2_TextChanged() //Метод чтение текста из файла и перенос его в текст бокс 2
        {
            String Filename = textBox1.Text;
            string m = File.ReadAllText(@"D:\" + Filename + ".txt"); //Чтение файла
            
            textBox2.Text = "№"+ " Name" + " Age" + Environment.NewLine + m; //Заполнение текстбокс 2

        }


        

    }
}
