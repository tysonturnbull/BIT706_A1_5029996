using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT706_A1_5029996
{
    class Customer
    {
        protected int customerNumber;
        protected static int nextCustomerNumber = 1;
        protected string firstName;
        protected string lastName;
        protected int phoneNumber;
        protected string email;
        protected string address;
        protected Boolean staffMember;

        public Customer() //Default assigns a customer number to a new customer
        {
            customerNumber = nextCustomerNumber;
            nextCustomerNumber++; 
        }

        public Customer(string newFName, string newLName, int newPNumber, string newEmail, string newAddress, Boolean isStaff):this()    //Assumed all attributes are key information needed for opening an account
        {
            firstName = newFName;
            lastName = newLName;
            phoneNumber = newPNumber;
            email = newEmail;
            address = newAddress;
            staffMember = isStaff;
        }
    }
}
