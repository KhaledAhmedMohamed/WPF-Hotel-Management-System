using MahApps.Metro.Controls;
using System;
using System.Windows;

namespace Hotel_Management__WPF_
{
    /// <summary>
    /// Interaction logic for FoodMenu.xaml
    /// </summary>
    public partial class FoodMenu : MetroWindow
    {
        public FoodMenu()
        {
            InitializeComponent();
        }

        #region Properties

        private int lunchQ = 0;
        public int LunchQ
        {
            get { return lunchQ; }
            set { lunchQ = value; }
        }

        private int breakfastQ = 0;
        public int BreakfastQ
        {
            get { return breakfastQ; }
            set { breakfastQ = value; }
        }

        private int dinnerQ = 0;
        public int DinnerQ
        {
            get { return dinnerQ; }
            set { dinnerQ = value; }
        }

        private string cleaning = "0";
        public string Cleaning
        {
            get { return cleaning; }
            set { cleaning = value; }
        }

        private string towel = "0";
        public string Towel
        {
            get { return towel; }
            set { towel = value; }
        }

        private string surprise = "0";
        public string Surprise
        {
            get { return surprise; }
            set { surprise = value; }
        }

        #endregion

        private void Next(object sender, RoutedEventArgs e)
        {
            if (checkBoxBreakFast.IsChecked == true)
            {
                BreakfastQ = Convert.ToInt32(TboxBreakfastQuantity.Text);
            }
            if (checkBoxLanch.IsChecked == true)
            {
                LunchQ = Convert.ToInt32(TboxLunchQuantity.Text);
            }
            if (checkBoxDinner.IsChecked == true)
            {
                DinnerQ = Convert.ToInt32(TboxDinnerQuantity.Text);
            }
            if (checkBoxCleaning.IsChecked == true)
            {
                Cleaning = "1";
            }
            if (checkBoxTowels.IsChecked == true)
            {
                Towel = "1";
            }
            if (checkBoxSurprise.IsChecked == true)
            {
                Surprise = "1";
            }

            this.Close();
        }

        private void breakfastCheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (checkBoxBreakFast.IsChecked == true)
                TboxBreakfastQuantity.IsEnabled = true;
            else
            {
                TboxBreakfastQuantity.IsEnabled = false;
                TboxBreakfastQuantity.Text = string.Empty;
            }
        }

        private void lunchCheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (checkBoxLanch.IsChecked == true)
                TboxLunchQuantity.IsEnabled = true;
            else
            {
                TboxLunchQuantity.IsEnabled = false;
                TboxLunchQuantity.Text = string.Empty;
            }
        }

        private void dinnerCheckBox_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (checkBoxDinner.IsChecked == true)
                TboxDinnerQuantity.IsEnabled = true;
            else
            {
                TboxDinnerQuantity.IsEnabled = false;
                TboxDinnerQuantity.Text = string.Empty;
            }
        }
    }
}
