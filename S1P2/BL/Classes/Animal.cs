using System.ComponentModel.DataAnnotations;

namespace S1P2.BL.Classes
{
    public abstract class Animal : IComparable
    {
        [Key] public string RFID { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public Animal()
        {
            RFID = "The animal with no RFID";
            Name = "The animal with no name";
        }

        public Animal(string rfid, string name)
        {
            RFID = rfid;
            Name = name;
        }

        public string Feed()
        {
            return $"{Name}({RFID} has been fed.";
        }

        public override string ToString()
        {
            return $"{Name}, {Age} years old, RFID Tag: {RFID}";
        }

        public int CompareTo(object obj)
        {
            // 0 = equal
            // < 0 : 1st smaller than 2nd
            // > 0 : 1st bigger than 2nd
            int rc;
            if (obj is Animal)
            {
                rc = Age - ((Animal)obj).Age;
            } // end if
            else
            {
                throw new ArgumentException("Object to compare to is " +
                                            "not an Animal object.");
            } // end else
            return rc;
        }
    }
}