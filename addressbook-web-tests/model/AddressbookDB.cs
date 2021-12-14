using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace WebAddressbookTests
{
    //this class describes the connection with DB
    public class AddressbookDB : LinqToDB.Data.DataConnection
    {
        //call the base class cunstructor and pass on the DB name from app.config connectionStrings/name="AddressBook"
        public AddressbookDB() : base("AddressBook") { }
        //for each DB table implement methods/properties that returns DB tables (ITable<GroupData>)
        //we extract data from DB table based on the mapping described in GroupData class
        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } }
        public ITable<ContactData> Contacts { get { return GetTable<ContactData>(); } }
        public ITable<GroupContactRelation> GCR { get { return GetTable<GroupContactRelation>(); } }

    }
}
