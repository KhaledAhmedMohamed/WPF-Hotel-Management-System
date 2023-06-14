using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for Kitchen.xaml
    /// </summary>
    public partial class Kitchen : MetroWindow
    {
        HotelDBContext context = new();
        public Kitchen()
        {
            InitializeComponent();

            Load();
        }

        #region Variables
        
        private int lunch = 0; private int breakfast = 0; private int dinner = 0;
        private string cleaning = "0"; private string towel = "0";
        private string surprise = "0";
        private string supplayStatus = "0";

        public int foodBill;

        #endregion

        private void UpdateChanges(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedReservation = context.Reservations.FirstOrDefault(r => r.ID == int.Parse(lstOnTheLine.SelectedValue.ToString()));

                selectedReservation.BreakFast = breakfast;
                selectedReservation.Lunch = lunch; 
                selectedReservation.Dinner = dinner;

                if (checkBoxCleaning.IsChecked == true)
                    selectedReservation.Cleaning = true;
                else
                    selectedReservation.Cleaning = false;

                if (checkBoxTowels.IsChecked == true)
                    selectedReservation.Towel = true;
                else
                    selectedReservation.Towel = false;

                if (checkBoxSweettestSurprise.IsChecked == true)
                    selectedReservation.SweetestSurprise = true;
                else
                    selectedReservation.SweetestSurprise = false;

                if (checkBoxFoodSupplyStatus.IsChecked == true)
                    selectedReservation.supplyStatus = true;
                else
                    selectedReservation.supplyStatus = false;

                selectedReservation.TotalBill += selectedReservation.FoodBill - foodBill;

                selectedReservation.FoodBill = foodBill;

                 

                context.SaveChanges();
                Load();

                this.ShowMessageAsync("Success", $"{lstOnTheLine.SelectedValue} Is Updated");
            }
            catch
            {
                this.ShowMessageAsync("Error", "Make Sure All Data In The Right Format");
            }
        }

        private void ChangeFoodSelection(object sender, RoutedEventArgs e)
        {

            // handel formate error
            FoodMenu foodMenu = new FoodMenu();

            if(breakfast > 0)
            {
                foodMenu.TboxBreakfastQuantity.Text = breakfast.ToString();
                foodMenu.checkBoxBreakFast.IsChecked = true;
            }
            if (lunch > 0)
            {
                foodMenu.TboxLunchQuantity.Text = lunch.ToString();
                foodMenu.checkBoxLanch.IsChecked = true;
            }
            if (dinner > 0)
            {
                foodMenu.TboxDinnerQuantity.Text = dinner.ToString();
                foodMenu.checkBoxDinner.IsChecked = true;
            }

            foodMenu.checkBoxCleaning.IsChecked = checkBoxCleaning.IsChecked;
            foodMenu.checkBoxTowels.IsChecked = checkBoxTowels.IsChecked;
            foodMenu.checkBoxSurprise.IsChecked = checkBoxSweettestSurprise.IsChecked;

            foodMenu.ShowDialog();

            checkBoxCleaning.IsChecked = foodMenu.checkBoxCleaning.IsChecked;
            checkBoxTowels.IsChecked = foodMenu.checkBoxTowels.IsChecked;
            checkBoxSweettestSurprise.IsChecked = foodMenu.checkBoxSurprise.IsChecked;

            TboxBreakfastQTY.Text = foodMenu.TboxBreakfastQuantity.Text;

            TboxLunchQTY.Text = foodMenu.TboxLunchQuantity.Text;

            TboxDinnerQTY.Text = foodMenu.TboxDinnerQuantity.Text;

            breakfast = foodMenu.BreakfastQ;
            lunch = foodMenu.LunchQ;
            dinner = foodMenu.DinnerQ;
            cleaning = foodMenu.Cleaning;
            towel = foodMenu.Towel;
            surprise = foodMenu.Surprise;

            if (breakfast > 0 || lunch > 0 || dinner > 0)
            {
                int bfast = 7 * breakfast;
                int Lnch = 15 * lunch;
                int di_ner = 15 * dinner;
                foodBill = bfast + Lnch + di_ner;
            }

        }

        private void lstOnTheLine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedReservation = context.Reservations.FirstOrDefault(r => r.ID == int.Parse(lstOnTheLine.SelectedValue.ToString()));

            TboxFirstName.Text = selectedReservation.FirstName;
            TboxLastName.Text = selectedReservation.LastName;
            TboxPhoneNumber.Text = selectedReservation.PhoneNumber;
            TboxRoomType.Text = selectedReservation.RoomType;
            TboxFloor.Text = selectedReservation.RoomFloor;
            TboxRoom.Text = selectedReservation.RoomNumber;
            TboxBreakfastQTY.Text = selectedReservation.BreakFast.ToString();
            breakfast = selectedReservation.BreakFast;
            TboxLunchQTY.Text = selectedReservation.Lunch.ToString();
            lunch = selectedReservation.Lunch;
            TboxDinnerQTY.Text = selectedReservation.Dinner.ToString();
            dinner = selectedReservation.Dinner;
            checkBoxCleaning.IsChecked = selectedReservation.Cleaning;
            checkBoxTowels.IsChecked = selectedReservation.Towel;
            checkBoxSweettestSurprise.IsChecked = selectedReservation.SweetestSurprise;


        }

        private void ClearAll(StackPanel mainStack)
        {
            foreach (var c in mainStack.Children)
            {
                if (c.GetType() == typeof(StackPanel))
                {
                    ClearAll((StackPanel) c);
                }
                else if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)c).Text = "";
                }
                else if (c.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)c).IsChecked = false;
                }
                else if (c.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)c).SelectedIndex = -1;
                }
                else if (c.GetType() == typeof(DatePicker))
                {
                    ((DatePicker)c).SelectedDate = DateTime.Now;
                }
            }
        }

        private void checkBoxFoodSupplyStatus_Checked(object sender, RoutedEventArgs e)
        {
            checkBoxCleaning.IsChecked = false;
            checkBoxTowels.IsChecked = false;
            checkBoxSweettestSurprise.IsChecked = false;
        }

        public void Load()
        {
            #region First Tab

            lstOnTheLine.ItemsSource = context.Reservations.Where(r => r.CheckIn == true && r.supplyStatus == false)
                                                           .Select(r => new { r.ID, reservation = r.ID + " | " + r.FirstName + " " + r.LastName + " | " + r.PhoneNumber }).ToList();
            lstOnTheLine.DisplayMemberPath = "reservation";
            lstOnTheLine.SelectedValuePath = "ID";

            #endregion

            #region Second Tab

            context.Reservations.Load();
            gridOverView.ItemsSource = context.Reservations.Local.ToList();

            #endregion

        }
    }
}
