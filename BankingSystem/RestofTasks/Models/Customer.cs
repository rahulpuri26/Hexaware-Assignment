using System;
namespace RestofTasks.Models
{
    public class Customer
    {
        
        private int customerID;
        private string firstName;
        private string lastName;
        private string emailAddress;
        private string phoneNumber;
        private string address;
        private string customerName;
        private string email;

        public Customer(string? firstName)
        {
            
            customerID = 0;
            firstName = "Unknown";
            lastName = "Unknown";
            emailAddress = "Unknown";
            phoneNumber = "Unknown";
            address = "Unknown";
        }

        public Customer(string customerName, string email, string phoneNumber, string address)
        {
            this.customerName = customerName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }

        public Customer(int customerID, string firstName, string lastName, string emailAddress, string phoneNumber, string address)
        {
            this.customerID = customerID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }

       
        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public object Name { get; internal set; }
    }
}

