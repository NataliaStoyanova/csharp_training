using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        
        public GroupData(string group_name)
        {
            Group_name = group_name;
        }

        public GroupData(string group_name, string group_header, string group_footer)
        {
            Group_name = group_name;
            Group_header = group_header;
            Group_footer = group_footer;
        }

        public string Group_name { get; set; }
        public string Group_header { get; set; }
        public string Group_footer { get; set; }

        public string id { get; set; }


        //returns "1" - if this object is grt with our compare rule then the second object
        //returns "0" - if objects are equal
        //returns "-1" - if this object is less with our compare rule the second object
        public int CompareTo(GroupData other)
        {

            //if the second object  is null, then our object is greater
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return Group_name.CompareTo(other.Group_name);
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Group_name == other.Group_name;
        }

        public override int GetHashCode()
        {
            return Group_name.GetHashCode();
        }

        public override string ToString()
        {
            return "name= " + Group_name;
        }
    }
}
