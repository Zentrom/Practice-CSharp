using System;
using System.Threading.Tasks;
using System.Windows;

//UI and Async
namespace PrimeOrNot
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Async function that returns an int
        private async Task<int> CountOfDivisorsAsync(int number)
        {
            int divisors = await Task<int>.Run(() =>
            {
                int divisorCount = 1;
                for (int i = 2; i <= number; i++)
                {
                    if (number % i == 0)
                    {
                        divisorCount++;
                    }
                }
                return divisorCount;
            });
            return divisors;
        }
        //Button handler that generates random number
        private void randomNumberGenerator_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int number = random.Next(1, 1000000000);
            numberTextBox.Text = number.ToString();
        }
        //Async function running on separate thread
        private async Task ShowCalculationResultsAsync(int number)
        {
            await Task.Run(async() =>
            {
                int divisors = await CountOfDivisorsAsync(number);
                MessageBox.Show(String.Format("{0} has {1} divisor", number, divisors));
            });
        }
        //Button handler running async function
        private async void checkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int number = int.Parse(numberTextBox.Text);
                await ShowCalculationResultsAsync(number);
            }
            catch (FormatException formatException)
            {
                MessageBox.Show(formatException.Message,
                    "The input number is not in the correct format.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "There was an unexpected error.");
            }
        }
    }
}
