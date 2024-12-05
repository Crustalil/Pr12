using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace пр12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Таймер для обновления времени
        /// </summary>
        DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
        }

        /// <summary>
        /// Метод таймера для обновления даты и времени
        /// </summary>
        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        /// <summary>
        /// Обработчик события таймера
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            tbTime.Text = d.ToString("HH:mm:ss");
            tbData.Text = d.ToString("dd.MM.yyyy");
        }

        /// <summary>
        /// Кнопка вывода информации о программе
        /// </summary>
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Даны стороны прямоугольника a и b. \r\nНайти его площадь периметр. \r\n \r\nДано трехзначное число. \r\nВывести число, полученное при прочтении исходного числа справа налево.  \r\n \r\nКузнецовМ.Н., ИСП-31");
        }

        /// <summary>
        /// Кнопка закрытия программы
        /// </summary>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //Расчет Площади и Периметра Прямоугольника
        private void btnCalculateSandP_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(tbSideA.Text,out int a ) && int.TryParse(tbSideB.Text, out int b))
            {
                CalculateSandP(a, b, out int S, out int P);
                tbRezSquare.Text = S.ToString();
                tbRezPerimeter.Text = P.ToString();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные значения для сторон.");
                tbSideA.Clear();
                tbSideB.Clear();
                tbSideA.Focus();
            }
        }

        /// <summary>
        /// Метод расчета площади и периметра прямоугольника
        /// </summary>
        /// <param name="a">сторона А</param>
        /// <param name="b">сторона B</param>
        /// <param name="S">площадь</param>
        /// <param name="P">периметр</param>
        void CalculateSandP(int a, int b, out int S, out int P)
        {
            S = a * b;
            P= 2*a+2*b;
        }

        /// <summary>
        /// Получение нового трехзначного числа
        /// </summary>
        private void btnNewDigit_Click(object sender, RoutedEventArgs e)
        {
            
            string input = tbNumber.Text;

            if (input.Length == 3 && int.TryParse(input, out int number))
            {
               
                tbNewDigitResult.Text = NewDigit(number).ToString();
                tbNumber.Focus();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректное трехзначное число.");
                tbNumber.Clear();
                tbNumber.Focus();
            }
        }

        /// <summary>
        /// метод переворота числа
        /// </summary>
        /// <param name="number">входное число</param>
        /// <returns>перевернутое число</returns>
        int NewDigit(int number)
        {
            int reversedNumber;
            return reversedNumber = (number % 10) * 100 + ((number / 10) % 10) * 10 + (number / 100);
        }

        /// <summary>
        /// Очистка введенного значения диаметра
        /// </summary>
        private void btnClearSide_Click(object sender, RoutedEventArgs e)
        {
            tbSideA.Clear();
            tbSideB.Clear();
        }

        /// <summary>
        /// Очистка результата
        /// </summary>
        private void btnClearResult_Click(object sender, RoutedEventArgs e)
        {
            tbRezSquare.Clear();
            tbRezPerimeter.Clear();
        }

        /// <summary>
        /// Очистка введенного трехзначного числа
        /// </summary>
        private void btnDigitClear_Click(object sender, RoutedEventArgs e)
        {
            tbNumber.Clear();
        }

        /// <summary>
        /// Очистка результата
        /// </summary>>
        private void btnClearNewDigit_Click(object sender, RoutedEventArgs e)
        {
            tbNewDigitResult.Clear();
        }

        private void tc1(object sender, TextChangedEventArgs e)
        {
            tbRezSquare.Clear();
            tbRezPerimeter.Clear();
        }

        private void tc2(object sender, TextChangedEventArgs e)
        {
            tbNewDigitResult.Clear();
        }
    }
}