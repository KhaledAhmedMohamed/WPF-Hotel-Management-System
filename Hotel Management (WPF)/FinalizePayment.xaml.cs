using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hotel_Management__WPF_
{
    /// <summary>
    /// Interaction logic for FinalizePayment.xaml
    /// </summary>
    public partial class FinalizePayment : MetroWindow
    {
        public FinalizePayment()
        {
            InitializeComponent();

            comboBoxMM.ItemsSource = new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"};

            comboBoxYY.ItemsSource = new object[] {
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33"};

            comboBoxPaymentMethod.ItemsSource = new object[] {
            "Credit",
            "Debit"};
        }

        public int totalAmountFromFrontend = 0;
        public int foodBill = 0;
        private double finalTotalFinalized = 0.0;
        private string paymentType;


        public double FinalTotalFinalized
        {
            get { return finalTotalFinalized; }
            set { finalTotalFinalized = value; }
        }

        public string PaymentType
        {
            get { return paymentType; }
            set { paymentType = value; }
        }
        private string paymentCardNumber;

        public string PaymentCardNumber
        {
            get { return paymentCardNumber; }
            set { paymentCardNumber = value; }
        }
        private string MM_YY_Of_Card;

        public string MM_YY_Of_Card1
        {
            get { return MM_YY_Of_Card; }
            set { MM_YY_Of_Card = value; }
        }
        private string CVC_Of_Card;

        public string CVC_Of_Card1
        {
            get { return CVC_Of_Card; }
            set { CVC_Of_Card = value; }
        }
        private string CardType;

        public string CardType1
        {
            get { return CardType; }
            set { CardType = value; }
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            try
            {
                PaymentType = comboBoxPaymentMethod.Text;
                PaymentCardNumber = TboxCardNumber.Text;
                MM_YY_Of_Card1 = comboBoxMM.SelectedItem.ToString() + "/" + comboBoxYY.SelectedItem.ToString();
                CVC_Of_Card1 = TboxCVV.Text;
                CardType1 = lblCardType.Text;

                this.Close();
            }
            catch (Exception)
            {
                this.ShowMessageAsync("Error", "Fill All Payment Info");
            }

        }

        private string CardTypeDetector(string cardNumber)
        {
            long c;
            try
            {
                c = long.Parse(cardNumber);
            }
            catch
            {
                return "INVALID";
            }

            long i, j, k, l, m, n, o, p, sum1, sum2, sum3;

            if (c > 1000000000000000)
            {
                i = c % 100 / 10 * 2;
                j = c % 10000 / 1000 * 2;
                k = c % 1000000 / 100000 * 2;
                l = c % 100000000 / 10000000 * 2;
                m = c % 10000000000 / 1000000000 * 2;
                n = c % 1000000000000 / 100000000000 * 2;
                o = c % 100000000000000 / 10000000000000 * 2;
                p = c / 1000000000000000 * 2;

                sum1 = i % 100 / 10 + i % 10 + j % 100 / 10 + j % 10 + k % 100 / 10 + k % 10 + l % 100 / 10 + l % 10 + m % 100 / 10 + m % 10 + n % 100 / 10 + n % 10 + o % 100 / 10 + o % 10 + p % 100 / 10 + p % 10;
                sum2 = c / 100000000000000 % 10 + c / 1000000000000 % 10 + c / 10000000000 % 10 + c / 100000000 % 10 + c / 1000000 % 10 + c / 10000 % 10 + c / 100 % 10 + c % 10;
                sum3 = sum1 + sum2;

                if (sum3 % 10 == 0)
                {
                    if (c / 1000000000000000 == 4)
                    {
                        return "VISA";
                    }

                    else if (c / 100000000000000 == 51 || c / 100000000000000 == 52 || c / 100000000000000 == 53 || c / 100000000000000 == 54 || c / 100000000000000 == 55)
                    {
                        return "MASTERCARD";
                    }
                }
                else
                {
                    return "INVALID";
                }
            }
            else if (c < 1000000000000000 && c > 100000000000000)
            {
                i = c % 100 / 10 * 2;
                j = c % 10000 / 1000 * 2;
                k = c % 1000000 / 100000 * 2;
                l = c % 100000000 / 10000000 * 2;
                m = c % 10000000000 / 1000000000 * 2;
                n = c % 1000000000000 / 100000000000 * 2;
                o = c % 100000000000000 / 10000000000000 * 2;

                sum1 = i % 100 / 10 + i % 10 + j % 100 / 10 + j % 10 + k % 100 / 10 + k % 10 + l % 100 / 10 + l % 10 + m % 100 / 10 + m % 10 + n % 100 / 10 + n % 10 + o % 100 / 10 + o % 10;
                sum2 = c / 100000000000000 % 10 + c / 1000000000000 % 10 + c / 10000000000 % 10 + c / 100000000 % 10 + c / 1000000 % 10 + c / 10000 % 10 + c / 100 % 10 + c % 10;
                sum3 = sum1 + sum2;

                if (sum3 % 10 == 0)
                {
                    if (c / 10000000000000 == 34 || c / 10000000000000 == 37)
                    {
                        return "AmericanExpress";
                    }
                    else
                    {
                        return "INVALID";
                    }
                }
            }
            else
            {
                return "INVALID";
            }

            return "INVALID";
        }




        private void Load(object sender, RoutedEventArgs e)
        {
            double totalWithTax = Convert.ToDouble(totalAmountFromFrontend) * 0.07;
            double FinalTotal = Convert.ToDouble(totalAmountFromFrontend) + totalWithTax + foodBill;
            lblCurentBill.Text = "$" + string.Format("{0:0.00}", totalAmountFromFrontend) + " USD";
            lblFoodBill.Text = "$" + string.Format("{0:0.00}", foodBill) + " USD";
            lblTax.Text = "$" + string.Format("{0:0.00}", totalWithTax) + " USD";
            lblTotal.Text = "$" + string.Format("{0:0.00}", FinalTotal) + " USD";
            FinalTotalFinalized = FinalTotal;
        }

        private void TboxCardNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            lblCardType.Text = CardTypeDetector(TboxCardNumber.Text);

            long getcard = Convert.ToInt64(TboxCardNumber.Text);
            string formatString = String.Format("{0:0000-0000-0000-0000}", getcard);
            TboxCardNumber.Text = formatString;
        }
    }
}
