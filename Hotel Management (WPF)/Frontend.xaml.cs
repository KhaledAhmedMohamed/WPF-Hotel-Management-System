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
    /// Interaction logic for Frontend.xaml
    /// </summary>
    public partial class Frontend : MetroWindow
    {
        HotelDBContext context = new();

        public Frontend()
        {
            InitializeComponent();

            #region First Tab
            //item source section
            comboBoxDay.ItemsSource = new object[] {"01","02","03","04","05","06","07","08","09","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25","26","27","28","29","30","31"};
            comboBoxMonth.ItemsSource = new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"};
            comboBoxGender.ItemsSource = new object[] { "Male", "Female" };
            comboBoxState.ItemsSource = new object[] {
            "Alabama",
            "Alaska",
            "Arizona",
            "Arkansas",
            "California",
            "Colorado",
            "Connecticut",
            "Delaware",
            "Florida",
            "Georgia",
            "Hawaii",
            "Idaho",
            "Illinois Indiana",
            "Iowa",
            "Kansas",
            "Kentucky",
            "Louisiana",
            "Maine",
            "Maryland",
            "Massachusetts",
            "Michigan",
            "Minnesota",
            "Mississippi",
            "Missouri",
            "Montana Nebraska",
            "Nevada",
            "New Hampshire",
            "New Jersey",
            "New Mexico",
            "New York",
            "North Carolina",
            "North Dakota",
            "Ohio",
            "Oklahoma",
            "Oregon",
            "Pennsylvania Rhode Island",
            "South Carolina",
            "South Dakota",
            "Tennessee",
            "Texas",
            "Utah",
            "Vermont",
            "Virginia",
            "Washington",
            "West Virginia",
            "Wisconsin",
            "Wyoming"};
            comboBoxNumberOfGuests.ItemsSource = new string[] { "1", "2", "3", "4", "5", "6" };

            comboBoxRoomType.ItemsSource = new object[] {
            "Single",
            "Double",
            "Twin",
            "Duplex",
            "Suite"};

            comboBoxFloor.ItemsSource = new object[] { "1", "2", "3", "4", "5"};
            comboBoxRoomNumber.ItemsSource = new object[] {
            "101",
            "102",
            "103",
            "104",
            "105",
            "106",
            "107",
            "108",
            "109",
            "110",
            "201",
            "202",
            "203",
            "204",
            "205",
            "206",
            "207",
            "208",
            "209",
            "210",
            "301",
            "302",
            "303",
            "304",
            "305",
            "306",
            "307",
            "308",
            "309",
            "310",
            "401",
            "402",
            "403",
            "404",
            "405",
            "406",
            "407",
            "408",
            "409",
            "410",
            "501",
            "502",
            "503",
            "504",
            "505",
            "506",
            "507",
            "508",
            "509",
            "510"};
            DatePickerEntryDate.SelectedDate = DateTime.Now;
            DatePickerDepartureDate.SelectedDate = DateTime.Now.AddDays(1);
            DatePickerEntryDate.DisplayDateStart = DateTime.Now;
            DatePickerDepartureDate.DisplayDateStart = DateTime.Now;
            //Hide section
            btnSubmit.Visibility = Visibility.Hidden;
            btnDelete.Visibility = Visibility.Hidden;
            btnUpdate.Visibility = Visibility.Hidden;
            comboBoxReservationEdit.Visibility = Visibility.Hidden;

            #endregion

            FirstAndThirdAndForthTabsLoad();
        }

        #region Variable

        private int lunch = 0; private int breakfast = 0; private int dinner = 0;
        private string cleaning = "0"; private string towel = "0";
        private string surprise = "0";
        private string supplayStatus = "0";

        public int foodBill;
        public int TotalAmount;

        public string FPayment, FCnumber, FcardExpOne, FcardExpTwo, FCardCVC;
        private double finalizedTotalAmount = 0.0;
        private string paymentType;
        private string paymentCardNumber;
        private string MM_YY_Of_Card;
        private string CVC_Of_Card;
        private string CardType;

        string CheckedIn = "0", SMS = "0";
        #endregion

        private void FinalizeBill(object sender, RoutedEventArgs e)
        {
            if (breakfast == 0 && lunch == 0 && dinner == 0 && cleaning == "0" && towel == "0" && surprise == "0")
            {
                checkBoxFoodSupplyStatus.IsChecked = true;
                supplayStatus = "1";
            }
            FinalizePayment finalizePayment = new FinalizePayment();
            finalizePayment.totalAmountFromFrontend = TotalAmount;
            finalizePayment.foodBill = foodBill;
            finalizePayment.ShowDialog();

            finalizedTotalAmount = finalizePayment.FinalTotalFinalized;
            paymentType = finalizePayment.PaymentType;
            paymentCardNumber = finalizePayment.PaymentCardNumber;
            MM_YY_Of_Card = finalizePayment.MM_YY_Of_Card1;
            CVC_Of_Card = finalizePayment.CVC_Of_Card1;
            CardType = finalizePayment.CardType1;

            btnSubmit.Visibility = Visibility.Visible;
        }

        private void comboBoxRoomType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxRoomType.SelectedItem == null)
            {
                comboBoxFloor.SelectedIndex = -1;
            }
            else
            {
                if (comboBoxRoomType.SelectedItem.Equals("Single"))
                {
                    TotalAmount = 149;
                    comboBoxFloor.SelectedItem = "1";
                }
                else if (comboBoxRoomType.SelectedItem.Equals("Double"))
                {
                    TotalAmount = 299;
                    comboBoxFloor.SelectedItem = "2";
                }
                else if (comboBoxRoomType.SelectedItem.Equals("Twin"))
                {
                    TotalAmount = 349;
                    comboBoxFloor.SelectedItem = "3";
                }
                else if (comboBoxRoomType.SelectedItem.Equals("Duplex"))
                {
                    TotalAmount = 399;
                    comboBoxFloor.SelectedItem = "4";
                }
                else if (comboBoxRoomType.SelectedItem.Equals("Suite"))
                {
                    TotalAmount = 499;
                    comboBoxFloor.SelectedItem = "5";
                }

                int selectedTemp = 0;
                string selected;
                try
                {
                    selectedTemp = int.Parse((string)comboBoxNumberOfGuests.SelectedItem);

                    selected = comboBoxNumberOfGuests.SelectedItem.ToString();
                    selectedTemp = Convert.ToInt32(selected);
                    if (selectedTemp >= 3)
                    {
                        TotalAmount += (selectedTemp * 5);
                    }
                }
                catch
                {
                    this.ShowMessageAsync("", "Enter # of guests first");
                    comboBoxRoomType.SelectedIndex = -1;
                }
            }
        }

        //Food And Menu Button Action
        private void OpenFoodMenu(object sender, RoutedEventArgs e)
        {
            FoodMenu foodMenu = new();

            if (breakfast > 0)
            {
                foodMenu.checkBoxBreakFast.IsChecked = true;
                foodMenu.TboxBreakfastQuantity.Text = Convert.ToString(breakfast);
            }
            if (lunch > 0)
            {
                foodMenu.checkBoxLanch.IsChecked = true;
                foodMenu.TboxLunchQuantity.Text = Convert.ToString(lunch);
            }
            if (dinner > 0)
            {
                foodMenu.checkBoxDinner.IsChecked = true;
                foodMenu.TboxDinnerQuantity.Text = Convert.ToString(dinner);
            }
            if (cleaning == "1")
            {
                foodMenu.checkBoxCleaning.IsChecked = true;
            }
            if (towel == "1")
            {
                foodMenu.checkBoxTowels.IsChecked = true;
            }
            if (surprise == "1")
            {
                foodMenu.checkBoxSurprise.IsChecked = true;
            }

            foodMenu.ShowDialog();

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

        private void Update(object sender, RoutedEventArgs e)
        {
            var UbdatedReservation = context.Reservations.FirstOrDefault(r => r.ID == int.Parse(comboBoxReservationEdit.SelectedValue.ToString()));

            try
            {
                UbdatedReservation.FirstName = TboxFirstName.Text;
                UbdatedReservation.LastName = TboxLastName.Text;
                UbdatedReservation.Birthday = comboBoxMonth.SelectedItem + "-" + comboBoxDay.Text + "-" + TboxYear.Text;
                UbdatedReservation.Gender = comboBoxGender.SelectedItem.ToString();
                UbdatedReservation.PhoneNumber = TboxPhone.Text;
                UbdatedReservation.Email = TboxEmail.Text;
                UbdatedReservation.GusteNumber = Convert.ToInt32(comboBoxNumberOfGuests.SelectedItem.ToString());
                UbdatedReservation.StreetAddress = TboxAddress.Text;
                UbdatedReservation.Apt_Suite = TboxAptSuite.Text;
                UbdatedReservation.City = TboxCity.Text;
                UbdatedReservation.State = comboBoxState.SelectedItem.ToString();
                UbdatedReservation.ZipCode = TboxZipCode.Text;
                UbdatedReservation.RoomType = comboBoxRoomType.SelectedItem.ToString();
                UbdatedReservation.RoomFloor = comboBoxFloor.SelectedItem.ToString();
                UbdatedReservation.RoomNumber = comboBoxRoomNumber.SelectedItem.ToString();
                UbdatedReservation.TotalBill = (float)finalizedTotalAmount;
                UbdatedReservation.PaymentType = paymentType;
                UbdatedReservation.CardType = CardType;
                UbdatedReservation.CardNumber = paymentCardNumber;
                UbdatedReservation.CardExp = MM_YY_Of_Card;
                UbdatedReservation.CardCVV = CVC_Of_Card;
                UbdatedReservation.ArrivalDate = DateTime.Parse(DatePickerEntryDate.Text);
                UbdatedReservation.LeavingDate = DateTime.Parse(DatePickerDepartureDate.Text);
                UbdatedReservation.CheckIn = CheckedIn == "1" ? true : false;
                UbdatedReservation.BreakFast = breakfast;
                UbdatedReservation.Lunch = lunch;
                UbdatedReservation.Dinner = dinner;
                UbdatedReservation.Cleaning = cleaning == "1" ? true : false;
                UbdatedReservation.Towel = towel == "1" ? true : false;
                UbdatedReservation.SweetestSurprise = surprise == "1" ? true : false;
                UbdatedReservation.supplyStatus = supplayStatus == "1" ? true : false;
                UbdatedReservation.FoodBill = foodBill;

                context.SaveChanges();

                this.ShowMessageAsync("Success", $"Record {comboBoxReservationEdit.SelectedValue} has been edited");
            }
            catch
            {
                this.ShowMessageAsync("Error","Make Sure All Data Cells Are Filled");
            }

            FirstAndThirdAndForthTabsLoad();


        }

        private void Delete(object sender, RoutedEventArgs e)
        {

            this.ShowMessageAsync("", $"{comboBoxReservationEdit.SelectedValue} Is Deleted");

            var deletedReservation = context.Reservations.FirstOrDefault(r => r.ID == int.Parse(comboBoxReservationEdit.SelectedValue.ToString()));
            context.Remove(deletedReservation);

            context.SaveChanges();

            FirstAndThirdAndForthTabsLoad();
        }

        private void CheckedIn_Checked(object sender, RoutedEventArgs e)
        {
            CheckedIn = "1";
        }

        private void SMS_Checked(object sender, RoutedEventArgs e)
        {
            SMS = "1";
        }

        private void comboBoxReservationEdit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxReservationEdit.SelectedIndex != -1)
            {
                var selectedReservation = context.Reservations.FirstOrDefault(r => r.ID == int.Parse(comboBoxReservationEdit.SelectedValue.ToString()));

                TboxFirstName.Text = selectedReservation.FirstName;
                TboxLastName.Text = selectedReservation.LastName;
                var splitedBirthday = selectedReservation.Birthday.Trim().Split("-");
                comboBoxMonth.SelectedItem = splitedBirthday[0];
                comboBoxDay.SelectedItem = splitedBirthday[1];
                TboxYear.Text = splitedBirthday[2];
                comboBoxGender.SelectedItem = selectedReservation.Gender;
                TboxPhone.Text = selectedReservation.PhoneNumber;
                TboxEmail.Text = selectedReservation.Email;
                TboxAddress.Text = selectedReservation.StreetAddress;
                TboxAptSuite.Text = selectedReservation.Apt_Suite;
                TboxCity.Text = selectedReservation.City;
                comboBoxState.SelectedItem = selectedReservation.State;
                TboxZipCode.Text = selectedReservation.ZipCode;
                comboBoxNumberOfGuests.SelectedItem = selectedReservation.GusteNumber.ToString();
                comboBoxRoomType.SelectedItem = selectedReservation.RoomType;
                comboBoxFloor.SelectedItem = selectedReservation.RoomFloor;
                comboBoxRoomNumber.SelectedItem = selectedReservation.RoomNumber;
                finalizedTotalAmount = selectedReservation.TotalBill;
                paymentType = selectedReservation.PaymentType;
                CardType = selectedReservation.CardType;
                paymentCardNumber = selectedReservation.CardNumber;
                MM_YY_Of_Card = selectedReservation.CardExp;
                CVC_Of_Card = selectedReservation.CardCVV;
                DatePickerEntryDate.SelectedDate = selectedReservation.ArrivalDate;
                DatePickerDepartureDate.SelectedDate = selectedReservation.LeavingDate;
                checkBoxCheckedIn.IsChecked = selectedReservation.CheckIn;
                breakfast = selectedReservation.BreakFast;
                lunch = selectedReservation.Lunch;
                dinner = selectedReservation.Dinner;
                cleaning = selectedReservation.Cleaning ? "1" : "0";
                towel = selectedReservation.Towel ? "1" : "0";
                surprise = selectedReservation.SweetestSurprise ? "1" : "0";
                supplayStatus = selectedReservation.supplyStatus ? "1" : "0";
                checkBoxFoodSupplyStatus.IsChecked = selectedReservation.supplyStatus;
                foodBill = selectedReservation.FoodBill;
            }

        }

        private void UpdateExisting(object sender, RoutedEventArgs e)
        {
            btnDelete.Visibility = Visibility.Visible;
            btnUpdate.Visibility = Visibility.Visible;
            comboBoxReservationEdit.Visibility = Visibility.Visible; 
        }

        private void NewReservation(object sender, RoutedEventArgs e)
        {
            btnDelete.Visibility = Visibility.Hidden;
            btnUpdate.Visibility = Visibility.Hidden;
            btnSubmit.Visibility = Visibility.Hidden;
            comboBoxReservationEdit.Visibility = Visibility.Hidden;


            // Clear All Fileds
            //ClearAll(stackFirstColumn);
            //ClearAll(stackSecondColumn);

            ClearAll(FirstTabMainStack);

            lunch = 0; breakfast = 0; dinner = 0;
            cleaning = "0"; towel = "0";
            surprise = "0";
            supplayStatus = "0";

            foodBill = 0 ;
            TotalAmount = 0;

        
            finalizedTotalAmount = 0.0;
            paymentType = "";
            paymentCardNumber = "";
            MM_YY_Of_Card = "";
            CVC_Of_Card = "";
            CardType = "";

            CheckedIn = "0"; SMS = "0";


    }

        private void Submit(object sender, RoutedEventArgs e)
        {
            try
            {
                Reservation newReservation = new Reservation() {FirstName = TboxFirstName.Text,
                                                            LastName = TboxLastName.Text,
                                                            Birthday = comboBoxMonth.SelectedItem +"-"+comboBoxDay.Text+"-"+TboxYear.Text,
                                                            Gender = comboBoxGender.SelectedItem.ToString(),
                                                            PhoneNumber = TboxPhone.Text,
                                                            Email = TboxEmail.Text,
                                                            GusteNumber = Convert.ToInt32(comboBoxNumberOfGuests.SelectedItem.ToString()),
                                                            StreetAddress = TboxAddress.Text,
                                                            Apt_Suite = TboxAptSuite.Text,
                                                            City = TboxCity.Text,
                                                            State = comboBoxState.SelectedItem.ToString(),
                                                            ZipCode = TboxZipCode.Text,
                                                            RoomType = comboBoxRoomType.SelectedItem.ToString(),
                                                            RoomFloor = comboBoxFloor.SelectedItem.ToString(),
                                                            RoomNumber = comboBoxRoomNumber.SelectedItem.ToString(),
                                                            TotalBill = (float)finalizedTotalAmount,
                                                            PaymentType = paymentType,
                                                            CardType = CardType,
                                                            CardNumber = paymentCardNumber,
                                                            CardExp = MM_YY_Of_Card,
                                                            CardCVV = CVC_Of_Card,
                                                            ArrivalDate = DateTime.Parse(DatePickerEntryDate.Text),
                                                            LeavingDate = DateTime.Parse(DatePickerDepartureDate.Text),
                                                            CheckIn = CheckedIn == "1" ? true : false,
                                                            BreakFast = breakfast,
                                                            Lunch = lunch,
                                                            Dinner = dinner,
                                                            Cleaning = cleaning == "1" ? true : false,
                                                            Towel = towel == "1" ? true : false,
                                                            SweetestSurprise = surprise == "1" ? true : false,
                                                            supplyStatus =  supplayStatus == "1" ? true : false,
                                                            FoodBill = foodBill};
           
                context.Add(newReservation);
                context.SaveChanges();

                this.ShowMessageAsync("Success", "Reservation Has Been Added");
            }
            catch
            {
                this.ShowMessageAsync("Error", "Must Fill All Date Cells First");
            }

            FirstAndThirdAndForthTabsLoad();
        }

        //Universal Search Tab Function
        private void Search(object sender, RoutedEventArgs e)
        {
            var searchResault = context.Reservations.Where( r => r.ID.ToString().Contains(TboxUniversalSearch.Text) || 
                                                   r.FirstName.ToUpper().Contains(TboxUniversalSearch.Text.ToUpper()) ||
                                                   r.LastName.ToUpper().Contains(TboxUniversalSearch.Text.ToUpper()) ||
                                                   r.Gender.ToUpper().Contains(TboxUniversalSearch.Text.ToUpper()) ||
                                                   r.PhoneNumber.ToUpper().Contains(TboxUniversalSearch.Text.ToUpper()) ||
                                                   r.Email.ToUpper().Contains(TboxUniversalSearch.Text.ToUpper()) ||
                                                   r.City.ToUpper().Contains(TboxUniversalSearch.Text.ToUpper()) ||
                                                   r.State.ToUpper().Contains(TboxUniversalSearch.Text.ToUpper()) ||
                                                   r.RoomType.ToUpper().Contains(TboxUniversalSearch.Text.ToUpper()) ||
                                                   r.Apt_Suite.ToUpper().Contains(TboxUniversalSearch.Text.ToUpper())).ToList();

            gridUniversalSearch.ItemsSource = searchResault;
        }

        private void FirstAndThirdAndForthTabsLoad()
        {
            // Edit Reservation source 
            comboBoxReservationEdit.ItemsSource = context.Reservations
                .Select(r => new { r.ID, reservation = r.ID + " | " + r.FirstName + " " + r.LastName + " | " + r.PhoneNumber }).ToList();
            comboBoxReservationEdit.DisplayMemberPath = "reservation";
            comboBoxReservationEdit.SelectedValuePath = "ID";

            #region Third Tab

            context.Reservations.Load();
            gridReservationAdvView.ItemsSource = context.Reservations.Local.ToList();

            #endregion

            #region Fourth Tab

            lstRoomAvailabiltyOccupied.ItemsSource = context.Reservations.Where(r => r.CheckIn == true)
                .Select(r => new { reservation = "[" + r.RoomNumber + "]" + " | " + r.RoomType + " | " + r.ID + " | [" + r.FirstName + " " + r.LastName + "] | " + r.PhoneNumber }).ToList();
            lstRoomAvailabiltyOccupied.FontSize = 20;
            lstRoomAvailabiltyOccupied.DisplayMemberPath = "reservation";

            lstRoomAvailabiltyReserved.ItemsSource = context.Reservations.Where(r => r.CheckIn == false)
                .Select(r => new { reservation = "[" + r.RoomNumber + "]" + " | " + r.RoomType + " | " + r.ID + " | [" + r.FirstName + " " + r.LastName + "] | " + r.PhoneNumber + " | " + r.ArrivalDate + " | " + r.LeavingDate }).ToList();
            lstRoomAvailabiltyReserved.FontSize = 13;
            lstRoomAvailabiltyReserved.DisplayMemberPath = "reservation";
            #endregion
        }

        private void ClearAll(StackPanel mainStack)
        {
            foreach (var c in mainStack.Children)
            {
                if (c.GetType() == typeof(StackPanel))
                {
                    ClearAll((StackPanel)c);
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

        //private void ClearAll(StackPanel mainStack)
        //{
        //    foreach (var c in mainStack.Children)
        //    {
        //        if (c.GetType() == typeof(StackPanel))
        //        {
        //            foreach (Control c1 in ((StackPanel)c).Children)
        //            {
        //                if (c1.GetType() == typeof(TextBox))
        //                {
        //                    ((TextBox)c1).Text = "";
        //                }
        //                else if (c1.GetType() == typeof(CheckBox))
        //                {
        //                    ((CheckBox)c1).IsChecked = false;
        //                }
        //                else if (c1.GetType() == typeof(ComboBox))
        //                {
        //                    ((ComboBox)c1).SelectedIndex = -1;
        //                }
        //                else if (c1.GetType() == typeof(DatePicker))
        //                {
        //                    ((DatePicker)c1).SelectedDate = DateTime.Now;
        //                }
        //            }
        //        }
        //        else if (c.GetType() == typeof(TextBox))
        //        {
        //            ((TextBox)c).Text = "";
        //        }
        //        else if (c.GetType() == typeof(CheckBox))
        //        {
        //            ((CheckBox)c).IsChecked = false;
        //        }
        //        else if (c.GetType() == typeof(ComboBox))
        //        {
        //            ((ComboBox)c).SelectedIndex = -1;
        //        }
        //        else if (c.GetType() == typeof(DatePicker))
        //        {
        //            ((DatePicker)c).SelectedDate = DateTime.Now;
        //        }
        //    }
        //}

    }
}
