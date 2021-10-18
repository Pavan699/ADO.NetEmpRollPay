using System;
using System.Collections.Generic;
using System.Text;

namespace ADOEmpRollPay
{
    class PersonDetails
    { 
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }

    class OrderDetails
    {
        public int OrderID { get; set; }
        public string FirstName { get; set; }
        public string state { get; set; }
        public string Address { get; set; }
    }

    class Names
    {
        public string PersonName { get; set; }
        public string PersonAddress { get; set; }
    }
}
