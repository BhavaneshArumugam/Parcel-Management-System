
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Project
{
    static ArrayList users = new ArrayList();
    static ArrayList bookings = new ArrayList();
    static ArrayList officerBookings = new ArrayList();
  
    public class Customer
    {
        public string Name;
        public string Email;
        public string CountryCode;
        public string Mobile;
        public string Address;
        public string UserID;
        public string Password;
        public string Preferences;
        public string Role="Customer";
    }
    
    public class Officer
    {
        public string OfficerName;
        public string OfficerEmail;
        public string OfficerCountryCode;
        public string OfficerMobile;
        public string OfficerAddress;
        public string OfficerUserID;
        public string OfficerPassword;
        public string OfficerPreferences;
        public string Role="Officer";
    }
    public class Booking
    {
        public int BookingID;
        public string SenderUserID;
        public string SenderName;
        public string SenderAddress;
        public string RecName;
        public string RecAddress;
        public string RecPin;
        public string RecMobile;
        public double ParWeightGram;
        public string ParContentsDescription;
        public string ParDeliveryType;
        public string ParPackingPreference;
        public DateTime ParPickupTime;
        public DateTime ParDropoffTime;
        public double ParServiceCost;
        public DateTime ParPaymentTime;
        public string ParStatus;
    }
//Customer Booking Id Generator Class
    class CustomerBookingIdGenerater{
        public static int  CustBookingid=0;
        public static int idgenerator(){
            CustBookingid+=1;
             return CustBookingid;
        }    
    }
    
    //Officer Booking Id Generator Class
    class OfficerBookingIdGenerater{
        public static int  OffBookingid=0;
        public static int idgenerator(){
            OffBookingid+=1;
             return OffBookingid;
        }    
    }
//main function for everything
static void Main(string[] args)
{
    // Project project =new Project(2);
    while (true)
    {
        Console.WriteLine("====== Welcome to team Spartans(8), Password Management System ======");
        Console.WriteLine("What feature you want to use.....");
        Console.WriteLine("1. Customer");
        Console.WriteLine("2. Officer");
        Console.WriteLine("3. Exit");
        Console.Write("Select an option (1-3): ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                CustomerOptions();
                break;
            case "2":
                OfficerOptions();
                break;
            case "3":
                Console.WriteLine("Exiting... Goodbye!");
                return;
            default:
                Console.WriteLine("Invalid choice! Please select 1, 2, or 3.");
                break;
        }

        Console.WriteLine();
    }
}

//customer (Main funtion)
static void CustomerOptions(){
     while (true)
    {
        Console.WriteLine("====== Welcome to team Spartans(8), Password Management System ======");
        Console.WriteLine("1. Customer Register");
        Console.WriteLine("2. Customer Login");
        Console.WriteLine("3. Exit");
        Console.Write("Select an option (1-3): ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                RegisterUser();
                break;
            case "2":
                LoginUser();
                break;
            case "3":
                Console.WriteLine("Exiting... Goodbye!");
                return;
            default:
                Console.WriteLine("Invalid choice! Please select 1, 2, or 3.");
                break;
        }

        Console.WriteLine();
    }
}

//officer (Main funtion)
static void OfficerOptions(){
     while (true)
    {
        Console.WriteLine("====== Welcome to team Spartans(8), Password Management System ======");
        Console.WriteLine("1. Officer Register");
        Console.WriteLine("2. Officer Login");
        Console.WriteLine("3. Exit");
        Console.Write("Select an option (1-3): ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                OfiicerRegisterUser();
                break;
            case "2":
                OfficerLoginUser();
                break;
            case "3":
                Console.WriteLine("Exiting... Goodbye!");
                return;
            default:
                Console.WriteLine("Invalid choice! Please select 1, 2, or 3.");
                break;
        }

        Console.WriteLine();
    }
}

// Register a new user (Customer Register)
static void RegisterUser()
{
    Console.WriteLine("=== Customer Registration ===");

    string name = ReadLimitedInput("Enter Customer Name (max 50 characters): ", 50);
    string email = ReadInput("Enter Email: ");
    string countryCode = SelectCountryCode();
    string mobileNumber=ReadMobileNumber("Press Enter to register Mobile number");//mobile number
    string address = ReadInput("Enter Mailing Address (include ZIP and Parcel Code): ");
    string userID = ReadLengthValidatedInput("Enter User ID (5–20 characters): ", 5, 20);
    string password = ReadLengthValidatedInput("Enter Password (max 30 characters): ", 1, 30);
    string confirmPassword ;
    while(true){
        confirmPassword= ReadLengthValidatedInput("Confirm Password (max 30 characters): ", 1, 30);
        if (password != confirmPassword)
        {
            Console.WriteLine("Error: Passwords do not match.");
        }else{
            break;
        }
    }

    Console.Write("Enter Preferences (Mail delivery, notifications, etc): ");
    string preferences = Console.ReadLine();

    Customer customer = new Customer
    {
        Name = name,
        Email = email,
        CountryCode = countryCode,
        Mobile = mobileNumber,
        Address = address,
        UserID = userID,
        Password = password,
        Preferences = preferences
    };

    users.Add(customer);
    Console.WriteLine(" Registration successful!");
}

//Main function
// Register a new user (Officer register)
static void OfiicerRegisterUser()
{
    Console.WriteLine("=== Officer Registration ===");

    string name = ReadLimitedInput("Enter Officer Name (max 50 characters): ", 50);
    string email = ReadInput("Enter Email: ");
    string countryCode = SelectCountryCode();
    string mobileNumber=ReadMobileNumber("Press Enter to register Mobile number");//mobile number
    string address = ReadInput("Enter Mailing Address (include ZIP and Parcel Code): ");
    string userID = ReadLengthValidatedInput("Enter User ID (5–20 characters): ", 5, 20);
    string password = ReadLengthValidatedInput("Enter Password (max 30 characters): ", 1, 30);
    string confirmPassword ;
    while(true){
        confirmPassword= ReadLengthValidatedInput("Confirm Password (max 30 characters): ", 1, 30);
        if (password != confirmPassword)
        {
            Console.WriteLine("Error: Passwords do not match.");
        }else{
            break;
        }
    }

    Console.Write("Enter Preferences (Mail delivery, notifications, etc): ");
    string preferences = Console.ReadLine();

    Officer officer =new Officer
    {
        OfficerName = name,
        OfficerEmail = email,
        OfficerCountryCode = countryCode,
        OfficerMobile = mobileNumber,
        OfficerAddress = address,
        OfficerUserID = userID,
        OfficerPassword = password,
        OfficerPreferences = preferences
    };

    officerBookings.Add(officer);
    Console.WriteLine(" Registration successful!");
}
// Helper function for reading input with a maximum length (name validation)
static string ReadLimitedInput(string prompt, int maxLength)
{
    string input;
    do
    {
        Console.Write(prompt);
        input = Console.ReadLine();
        if (input.Length > maxLength)
            Console.WriteLine($"Input too long! Max {maxLength} characters.");
    } while (input.Length > maxLength);
    return input;
}
 
 //function for (email)(and address)
 static string ReadInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
    
    //(country code for number)
    static string SelectCountryCode()
    {
        string[] codes = { "+91", "+1", "+44", "+81" };
        Console.WriteLine("Select Country Code:");
        for (int i = 0; i < codes.Length; i++)
            Console.WriteLine($"{i + 1}. {codes[i]}");

        int choice;
        do
        {
            Console.Write("Choice (1–4): ");
        } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > codes.Length);

        return codes[choice - 1];
    }
    
//helper funciton
 static string ReadMobileNumber(string prompt)
    {
        string mobile;
        do
        {
            Console.Write("Enter 10-digit Mobile Number: ");
            mobile = Console.ReadLine();
            if (mobile.Length != 10 || !long.TryParse(mobile, out _))
            Console.WriteLine("Invalid,Mobile number must be 10 digits,Please Enter again.");
        } while (mobile.Length != 10 || !long.TryParse(mobile, out _));
        return mobile;
    }


//function forlength validation(for user id and password and confirmPassword)
static string ReadLengthValidatedInput(string prompt, int minLength, int maxLength)
{
    string input;
    do
    {
        Console.Write(prompt);
        input = Console.ReadLine();
        if (input.Length < minLength || input.Length > maxLength)
            Console.WriteLine($"Input must be between {minLength} and {maxLength} characters.");
    } while (input.Length < minLength || input.Length > maxLength);
    return input;
}

//Main function
// Log in an existing user(Customer Login)
static void LoginUser()
{
    Console.WriteLine("=== Customer Login ===");

    string userID = ReadLengthValidatedInput("Enter User ID (5–20 characters): ", 5, 20);
    string password = ReadPasswordInput("Enter Password: ");

    foreach (Customer customer in users)
    {
        if (customer.UserID == userID && customer.Password == password)
        {
            Console.WriteLine("Login successful!");
            ShowCustomerDashboard(customer.Role, customer);
            return;
        }
    }

    Console.WriteLine("Error: Invalid username or password.");
}

//Main function
// Log in an existing user(Officer User)
static void OfficerLoginUser()
{
    Console.WriteLine("=== Officer Login ===");

    string userID = ReadLengthValidatedInput("Enter User ID (5–20 characters): ", 5, 20);
    string password = ReadPasswordInput("Enter Password: ");

    foreach (Officer officer in officerBookings)
    {
        if (officer.OfficerUserID == userID && officer.OfficerPassword == password)
        {
            Console.WriteLine("Login successful!");
            ShowOfficerDashboard(officer.Role, officer);
            return;
        }
    }

    Console.WriteLine("Error: Invalid username or password.");
}

    //password for loginUser function
  static string ReadPasswordInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

// Displays the dashboard based on user role(Customer)
static void ShowCustomerDashboard(string role, Customer customer)
{
    if (customer.Role.ToLower()== "customer")
    {
        ShowCustomerMenu(customer);
    }
    else if (customer.Role.ToLower() == "officer")
    {
        ShowOfficerMenu();
    }
    else
    {
        Console.WriteLine("Access denied: Role not recognized.");
    }
}

// Displays the dashboard based on user role(Officer)
static void ShowOfficerDashboard(string role, Officer officer)
{
    if (officer.Role.ToLower()== "officer")
    {
        ShowOfficerMenu();
    }
    else
    {
        Console.WriteLine("Access denied: Role not recognized.");
    }
}

// Customer menu options
static void ShowCustomerMenu(Customer loggedInCustomer)
{
    while (true)
    {
        Console.WriteLine("\n=== Customer Menu ===");
        Console.WriteLine("1. Home");
        Console.WriteLine("2. Booking Service");
        Console.WriteLine("3. Tracking");
        Console.WriteLine("4. Previous Booking");
        Console.WriteLine("5. Contact Support");
        Console.WriteLine("6. Logout");
        Console.Write("Choose an option (1-6): ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.WriteLine("Navigating to Home page...");
                break;
            case "2":
                ProceedToBooking(loggedInCustomer);
                break;
            case "3":
                TrackPackageStatus(loggedInCustomer.UserID);
                break;
            case "4":
                ViewCustomerBookingHistory(loggedInCustomer.UserID);
                break;
            case "5":
                RedirectToSupportPage();
                break;
            case "6":
                Console.WriteLine("Logging out...");
                return;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }
}

//main funtion 1
// Customer booking service
static void ProceedToBooking(Customer loggedInCustomer)
{
    Console.WriteLine("=== Booking Service ===");
    int count=1;
    Booking booking = new Booking
    {
        // BookingID=ReadBookingID(Count),
        BookingID=CustomerBookingIdGenerater.idgenerator(),
        SenderUserID = loggedInCustomer.UserID,
        SenderName = loggedInCustomer.Name,
        SenderAddress = loggedInCustomer.Address,
        RecName = ReadInput("Enter Recipient Name: "),
        RecAddress = ReadInput("Enter Recipient Address: "),
        RecPin = ReadPin("Enter Recipient PIN (6 digits): "),
        RecMobile = ReadMobileNumber("Enter Recipient Mobile (10 digits): "),
        ParWeightGram = ReadWeight("Enter Parcel Weight (grams): "),
        ParContentsDescription = ReadInput("Enter Parcel Contents Description: "),
        ParDeliveryType = ReadInput("Enter Delivery Type (Standard/Express): "),
        ParPackingPreference = ReadInput("Enter Packing Preference (Fragile/Basic): "),
        ParPickupTime = ReadDateTime("Enter Pickup Time (yyyy-MM-dd HH:mm): "),
        ParDropoffTime = ReadDateTime("Enter Drop-off Time (yyyy-MM-dd HH:mm): "),
       
        ParPaymentTime = DateTime.Now,
        ParStatus = "Booked"
    };
    booking.ParServiceCost = CalculateServiceCost(booking.ParWeightGram,booking.ParDeliveryType);
    bookings.Add(booking);
    Console.WriteLine("Booking successful!");
    Console.WriteLine("Your BookindID is:" + booking.BookingID);
    Console.WriteLine($"Service Cost: ₹{booking.ParServiceCost:F2}");
    Console.WriteLine($"Payment Time: {booking.ParPaymentTime}");
}
//helper function 
//function for reading valid PIN (6 digits)(helps to read the pin)
static string ReadPin(string prompt)
{
    string pin;
    do
    {
        Console.Write(prompt);
        pin = Console.ReadLine();
        if (pin.Length != 6 || !long.TryParse(pin, out _))
            Console.WriteLine(" PIN must be exactly 6 digits.");
    } while (pin.Length != 6 || !long.TryParse(pin, out _));
    return pin;
}

//helper function 
// Customer function for reading parcel weight(weight Gram)
static double ReadWeight(string prompt)
{
    double weight;  
    do
    {
        Console.Write(prompt);
        if (!double.TryParse(Console.ReadLine(), out weight) || weight <= 0)
            Console.WriteLine(" Enter a valid weight in grams.");
    } while (weight <= 0);
    return weight;
}

//helper function
// Customer function for reading valid date-time input(Data and Time)
  static DateTime ReadDateTime(string prompt)
    {
        DateTime dt;
        do
        {
            Console.Write(prompt);
             if(!DateTime.TryParse(Console.ReadLine(), out dt)){
                 Console.Write("Invalid Time Format");
             }
        } while (!DateTime.TryParse(Console.ReadLine(), out dt));
        return dt;
    }

// Calculate Service Cost based on delivery type and weight (weight and delivery type)
static double CalculateServiceCost(double weightInGrams, string deliveryType)
{
    double baseRate = deliveryType.ToLower() == "express" ? 10.0 : 5.0;
    return baseRate * (weightInGrams / 100);
}

//Main function 2
// Customer tracking package status (customer)
static void TrackPackageStatus(string currentUserID)
{
    Console.Write("Enter Booking ID to track: ");
    if (!int.TryParse(Console.ReadLine(), out int bookingID))
    {
        Console.WriteLine("Invalid Booking ID format.");
        return;
    }

    foreach (Booking b in bookings)
    {
        if (b.BookingID == bookingID && b.SenderUserID == currentUserID)
        {
            Console.WriteLine("\n=====  Tracking Status =====");
            Console.WriteLine($"Booking ID       : {b.BookingID}");
            Console.WriteLine($"Full Name        : {b.SenderName}");
            Console.WriteLine($"Address          : {b.SenderAddress}");
            Console.WriteLine($"Recipient Name   : {b.RecName}");
            Console.WriteLine($"Recipient Address: {b.RecAddress}");
            Console.WriteLine($"Date of Booking  : {b.ParPaymentTime}");
            Console.WriteLine($"Parcel Status    : {b.ParStatus}");
            return;     
        }
    }

    Console.WriteLine(" No matching booking found for this user.");
}

//Main funciton 3
// View customer booking history(Show the customer history)
static void ViewCustomerBookingHistory(string currentUserID)
{
    Console.WriteLine("===  Your Previous Bookings ===");

    ArrayList customerBookings = new ArrayList();

    // Filter bookings for the current customer
    foreach (Booking b in bookings)
    {
        if (b.SenderUserID == currentUserID)
        {
            customerBookings.Add(b);
        }
    }

    if (customerBookings.Count == 0)
    {
        Console.WriteLine(" No bookings found for your user ID.");
        return;
    }

    // Sort bookings by ParPaymentTime descending
    customerBookings.Sort(new BookingDateComparer());

    Console.WriteLine("\nCustomer ID | Booking ID | Booking Date       | Receiver Name | Delivered Address     | Amount  | Status");
    Console.WriteLine("-----------------------------------------------------------------------------------------------");

    foreach (Booking b in customerBookings)
    {
        Console.WriteLine($"{currentUserID,-11} | {b.BookingID,-10} | {b.ParPaymentTime,-18:g} | {b.RecName,-13} | {b.RecAddress,-20} | ₹{b.ParServiceCost,6:F2} | {b.ParStatus}");
    }
}

//main function 4
//customer contact support function
static void RedirectToSupportPage()
{
    Console.WriteLine("Redirecting to Support Page...");
    Console.WriteLine("Welcome to Auroville Support");
    Console.WriteLine("Contact: Don LEE, Location: Pondicherry");
    Console.WriteLine("contact Number: 7639700890");
}

// Officer menu options
static void ShowOfficerMenu()
{
    while (true)
    {
        Console.WriteLine("\n=== Officer Menu ===");
        Console.WriteLine("0. Home");
        Console.WriteLine("1. booking");
        Console.WriteLine("2. Tracking");
        Console.WriteLine("3. Delivery Status");
        Console.WriteLine("4. Pickup Scheduling");
        Console.WriteLine("5. Previous Booking");
        Console.WriteLine("6. Logout");
        Console.Write("Choose an option (1-6): ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "0":
                Console.WriteLine("Navigating to Home page...");
                break;
            case "1":
                OfficerBookingService();
                break;
            case "2":
                OfficerTrackPackageStatus();
                break;
            case "3":
                UpdateDeliveryStatus();
                break;
            case "4":
                UpdatePickupAndDropTime();
                break;
            case "5":
                ViewOfficerBookingHistory();
                break;
            case "6":
                Console.WriteLine("Logging out...");
                return;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }
}

// Officer booking service
static void OfficerBookingService()
{
    Console.WriteLine("=== Officer: Book a Service ===");

    Booking booking = new Booking
    {
        BookingID=CustomerBookingIdGenerater.idgenerator(),
        RecName = ReadInput("Enter Recipient Name: "),
        RecAddress = ReadInput("Enter Recipient Address: "),
        RecPin = ReadPin("Enter Recipient PIN (6 digits): "),
        RecMobile = ReadMobileNumber("Enter Recipient Mobile (10 digits): "),
        ParWeightGram = ReadWeight("Enter Parcel Weight (grams): "),
        ParContentsDescription = ReadInput("Enter Parcel Contents Description: "),
        ParDeliveryType = ReadInput("Enter Delivery Type (Standard/Express): "),
        ParPackingPreference = ReadInput("Enter Packing Preference (Fragile/Basic): "),
        ParPickupTime = ReadDateTime("Enter Pickup Time (yyyy-MM-dd HH:mm): "),
        ParDropoffTime = ReadDateTime("Enter Drop-off Time (yyyy-MM-dd HH:mm): "),
       
        ParPaymentTime = DateTime.Now,
        ParStatus = "Booked"
    };
    booking.ParServiceCost = CalculateServiceCost(booking.ParWeightGram, booking.ParDeliveryType);
    bookings.Add(booking);
    Console.WriteLine("\nBooking successfully created!");
    Console.WriteLine($"your Booking id is: {booking.BookingID}");
    Console.WriteLine($"Service Cost: ₹{booking.ParServiceCost:F2}");
    Console.WriteLine($"Payment Timestamp: {booking.ParPaymentTime}");
}


// Officer tracking package status
static void OfficerTrackPackageStatus()
{
    Console.Write("Enter Booking ID to track: ");
    if (!int.TryParse(Console.ReadLine(), out int bookingID))
    {
        Console.WriteLine("Invalid Booking ID format.");
        return;
    }

    foreach (Booking b in bookings)
    {
        if (b.BookingID == bookingID)
        {
            Console.WriteLine("\n===== Officer Tracking View =====");
            Console.WriteLine($"Booking ID        : {b.BookingID}");
            Console.WriteLine($"Sender Full Name  : {b.SenderName}");
            Console.WriteLine($"Sender Address    : {b.SenderAddress}");
            Console.WriteLine($"Recipient Name    : {b.RecName}");
            Console.WriteLine($"Recipient Address : {b.RecAddress}");
            Console.WriteLine($"Date of Booking   : {b.ParPaymentTime}");
            Console.WriteLine($"Parcel Status     : {b.ParStatus}");
            return;
        }
    }

    Console.WriteLine("No booking found with the specified ID.");
}

//Main function
// Update delivery status(officer)
static void UpdateDeliveryStatus()
{
    Console.Write("Enter Booking ID to update status: ");
    if (!int.TryParse(Console.ReadLine(), out int bookingID))
    {
        Console.WriteLine("Invalid format. Please enter a numeric Booking ID.");
        return;
    }

    foreach (Booking b in bookings)
    {
        if (b.BookingID == bookingID)
        {
            Console.WriteLine("\n===== Booking Summary =====");
            Console.WriteLine($"Booking ID       : {b.BookingID}");
            Console.WriteLine($"Sender Name      : {b.SenderName}");
            Console.WriteLine($"Sender Address   : {b.SenderAddress}");
            Console.WriteLine($"Recipient Name   : {b.RecName}");
            Console.WriteLine($"Recipient Address: {b.RecAddress}");
            Console.WriteLine($"Booking Date     : {b.ParPaymentTime}");
            Console.WriteLine($"Current Status   : {b.ParStatus}");

            Console.WriteLine("\nSelect new status:");
            Console.WriteLine("1. Booked");
            Console.WriteLine("2. In Transit");
            Console.WriteLine("3. Delivered");
            Console.WriteLine("4. Returned");
            Console.Write("Enter choice (1–4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    b.ParStatus = "Booked";
                    break;
                case "2":
                    b.ParStatus = "In Transit";
                    break;
                case "3":
                    b.ParStatus = "Delivered";
                    break;
                case "4":
                    b.ParStatus = "Returned";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Status not updated.");
                    return;
            }

            Console.WriteLine($"Parcel status updated to: {b.ParStatus}");
            return;
        }
    }

    Console.WriteLine(" Booking ID not found.");
}

//Main Function
// Update pickup and drop-off time
static void UpdatePickupAndDropTime()
{
    Console.Write("Enter Booking ID to update pickup/drop schedule: ");
    if (!int.TryParse(Console.ReadLine(), out int bookingID))
    {
        Console.WriteLine("Invalid Booking ID format.");
        return;
    }

    foreach (Booking b in bookings)
    {
        if (b.BookingID == bookingID)
        {
            Console.WriteLine("\n===== Current Booking Info =====");
            Console.WriteLine($"Booking ID         : {b.BookingID}");
            Console.WriteLine($"Sender Full Name   : {b.SenderName}");
            Console.WriteLine($"Sender Address     : {b.SenderAddress}");
            Console.WriteLine($"Recipient Name     : {b.RecName}");
            Console.WriteLine($"Recipient Address  : {b.RecAddress}");
            Console.WriteLine($"Date of Booking    : {b.ParPaymentTime}");
            Console.WriteLine($"Parcel Status      : {b.ParStatus}");
            Console.WriteLine($"Current Pickup     : {b.ParPickupTime}");
            Console.WriteLine($"Current Drop-off   : {b.ParDropoffTime}");

            Console.Write("\nEnter NEW Pickup Time (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime newPickup))
            {
                Console.WriteLine(" Invalid date format. Update cancelled.");
                return;
            }

            Console.Write("Enter NEW Drop-off Time (yyyy-MM-dd HH:mm): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime newDrop))
            {
                Console.WriteLine(" Invalid date format. Update cancelled.");
                return;
            }

            b.ParPickupTime = newPickup;
            b.ParDropoffTime = newDrop;

            Console.WriteLine("\n Pickup and Drop-off times successfully updated.");
            return;
        }
    }

    Console.WriteLine(" No booking found with the provided ID.");
}

//Main Function
// View officer booking history
static void ViewOfficerBookingHistory()
{
    Console.Write("Enter Customer User ID to search: ");
    string customerID = Console.ReadLine();

    Console.Write("Enter Start Date (yyyy-MM-dd): ");
    if (!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
    {
        Console.WriteLine("Invalid Start Date.");
        return;
    }

    Console.Write("Enter End Date (yyyy-MM-dd): ");
    if (!DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
    {
        Console.WriteLine("Invalid End Date.");
        return;
    }

    ArrayList filtered = new ArrayList();

    foreach (Booking b in bookings)
    {
        if (b.SenderUserID == customerID &&
            b.ParPaymentTime.Date >= startDate.Date &&
            b.ParPaymentTime.Date <= endDate.Date)
        {
            filtered.Add(b);
        }
    }

    if (filtered.Count == 0)
    {
        Console.WriteLine(" No bookings found for the given User ID and date range.");
        return;
    }

    filtered.Sort(new BookingDateComparer());

    Console.WriteLine("\nCustomer ID | Booking ID | Booking Date       | Receiver Name | Delivered Address     | Amount  | Status");
    Console.WriteLine("-----------------------------------------------------------------------------------------------");

    foreach (Booking b in filtered)
    {
        Console.WriteLine($"{b.SenderUserID,-11} | {b.BookingID,-10} | {b.ParPaymentTime,-18:g} | {b.RecName,-13} | {b.RecAddress,-20} | ₹{b.ParServiceCost,6:F2} | {b.ParStatus}");
    }
}


// Generate an invoice for a specific booking
static void GenerateInvoice()
{
    Console.Write("Enter Booking ID (index number): ");
    if (!int.TryParse(Console.ReadLine(), out int bookingID))
    {
        Console.WriteLine("Invalid Booking ID format.");
        return;
    }

    if (bookingID < 0 || bookingID >= bookings.Count)
    {
        Console.WriteLine("No booking found with that ID.");
        return;
    }
    Booking b = (Booking)bookings[bookingID];

    Console.WriteLine("\n===== Parcel Invoice =====");
    Console.WriteLine($"Booking ID              : {bookingID}");
    Console.WriteLine($"Receiver Name           : {b.RecName}");
    Console.WriteLine($"Receiver Address        : {b.RecAddress}");
    Console.WriteLine($"Receiver PIN            : {b.RecPin}");
    Console.WriteLine($"Receiver Mobile         : {b.RecMobile}");
    Console.WriteLine($"Parcel Weight (grams)   : {b.ParWeightGram}");
    Console.WriteLine($"Contents Description    : {b.ParContentsDescription}");
    Console.WriteLine($"Delivery Type           : {b.ParDeliveryType}");
    Console.WriteLine($"Packing Preference      : {b.ParPackingPreference}");
    Console.WriteLine($"Pickup Time             : {b.ParPickupTime}");
    Console.WriteLine($"Drop-off Time           : {b.ParDropoffTime}");
    Console.WriteLine($"Service Cost (₹)        : {b.ParServiceCost:F2}");
    Console.WriteLine($"Payment Time            : {b.ParPaymentTime}");
    Console.WriteLine("=============================");
}

// Sorting mechanism for booking history based on payment date (Descending)
public class BookingDateComparer : IComparer
{
    public int Compare(object x, object y)
    {
        return ((Booking)y).ParPaymentTime.CompareTo(((Booking)x).ParPaymentTime);
    }
}
}



