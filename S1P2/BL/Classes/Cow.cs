using System.ComponentModel.DataAnnotations;

namespace S1P2.BL.Classes
{
    public class Cow : Animal
    {
        public decimal MilkProductionLitre { get; set; } // Daily milk production in litres
        public string BreedType { get; set; } // Holstein, Jersey, etc.

        public string Milk()
        {
            return $"{Name} has been milked.";
        }

        public Cow(string rfid, string name) : base(rfid, name)
        { }

        public Cow()
        {

        }
    }
}