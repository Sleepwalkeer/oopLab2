using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace oopLab2
{
    public partial class Form1 : Form
    {

        private GcdCalculator gcdCalculator;
        public Form1()
        {
            InitializeComponent();
            gcdCalculator = new GcdCalculator();
            MessageBox.Show("Прошу прощения за чарты, че-то в .net6.0 их не оказалось, начинать заново было лень))))");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Collect non-empty values from textboxes
            List<long> numbers = GetNonEmptyNumbers();

            if (numbers.Count >= 2)
            {
                long time;
                string formattedTime = string.Empty;
                // Choose the appropriate method based on the count of numbers
                long gcd;
                switch (numbers.Count)
                {
                    case 2:

                        gcd = gcdCalculator.CalculateGCD(numbers[0], numbers[1], out time);
                        TimeSpan timeSpan = TimeSpan.FromMilliseconds(time);

                        // Format TimeSpan
                        formattedTime = timeSpan.ToString(@"dd\.hh\:mm\:ss");
                        break;
                    case 3:
                        gcd = gcdCalculator.CalculateGCD(numbers[0], numbers[1], numbers[2]);
                        break;
                    case 4:
                        gcd = gcdCalculator.CalculateGCD(numbers[0], numbers[1], numbers[2], numbers[3]);
                        break;
                    case 5:
                        gcd = gcdCalculator.CalculateGCD(numbers[0], numbers[1], numbers[2], numbers[3], numbers[4]);
                        break;
                    default:
                        MessageBox.Show("Unsupported number of input values.", "Error");
                        return;
                }
                if (!string.IsNullOrWhiteSpace(formattedTime))
                {
                    ShowResult(gcd, formattedTime);
                }
                else
                {
                    ShowResult(gcd);
                }


            }
            else
            {
                MessageBox.Show("Insufficient input. Please enter at least two valid integers.", "Error");
            }
        }

        private void ShowResult(long result)
        {
            MessageBox.Show($"Greatest Common Divisor (GCD) is: {result}", "Result");
        }

        private void ShowResult(long result, string time)
        {
            MessageBox.Show($"Greatest Common Divisor (GCD) is: {result}. The time it took to compute = {time}", "Result");
        }

        private List<long> GetNonEmptyNumbers()
        {
            List<long> numbers = new List<long>();

            foreach (var textBox in GetAllTextBoxes())
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text) && long.TryParse(textBox.Text, out long number))
                {
                    numbers.Add(number);
                }
            }

            return numbers;
        }

        private IEnumerable<TextBox> GetAllTextBoxes()
        {
            // Collect all TextBox controls in the form
            return Controls.OfType<TextBox>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (long.TryParse(textBox6.Text, out long number1) && long.TryParse(textBox7.Text, out long number2))
            {
                long gcdStein = gcdCalculator.CalculateBinaryGCD(number1, number2, out long timeStein);
                TimeSpan timeSpan = TimeSpan.FromMilliseconds(timeStein);

                // Format TimeSpan
                string formattedTime = timeSpan.ToString(@"dd\.hh\:mm\:ss");
                ShowResult(gcdStein, formattedTime);
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter valid integers in both textboxes.", "Error");
            }
        }
    }
}