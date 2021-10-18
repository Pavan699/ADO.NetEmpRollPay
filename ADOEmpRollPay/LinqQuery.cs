using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ADOEmpRollPay
{
    class LinqQuery
    {
        List<PersonDetails> perlist = new List<PersonDetails>()
        {
            new PersonDetails(){PersonID=1,FirstName="Sam",LastName="C",Address="Mumbai"},
            new PersonDetails(){PersonID=2,FirstName="Pavan",LastName="N",Address="Solapur"},
            new PersonDetails(){PersonID=3,FirstName="DD",LastName="Mane",Address="Angar"},
            new PersonDetails(){PersonID=4,FirstName="Rahul",LastName="Kanna",Address="Bengluru"},
            new PersonDetails(){PersonID=5,FirstName="Ajay",LastName="Mehta",Address="Goa"},
            new PersonDetails(){PersonID=5,FirstName="Mohan",LastName="Thakur",Address="MP"}
        };
        List<OrderDetails> orderList = new List<OrderDetails>()
        {
            new OrderDetails(){OrderID=1,FirstName="Sam",state="Maharashtra",Address="Mumbai"},
            new OrderDetails(){OrderID=2,FirstName="Pavan",state="Maharashtra",Address="Solapur"},
            new OrderDetails(){OrderID=3,FirstName="DD",state="UP",Address="Angar"},
            new OrderDetails(){OrderID=4,FirstName="Rahul",state="Karnatak",Address="Bengluru"},
            new OrderDetails(){OrderID=5,FirstName="Ajay",state="Goa",Address="Goa"}
        };
        
        public void LinqTest()
        {            
            var names = from per in perlist
                       where per.FirstName.Contains('m', StringComparison.OrdinalIgnoreCase)
                       select new { PersonName = per.FirstName, PersonAddress = per.Address };           

            var joinquery = from per in perlist
                            join ord in orderList on per.FirstName equals ord.FirstName
                            select new { Name = per.FirstName , Address = per.Address , State = ord.state , ID = ord.OrderID};
        }
    }
}
