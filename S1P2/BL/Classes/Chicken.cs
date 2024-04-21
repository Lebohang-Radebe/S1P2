using System.ComponentModel.DataAnnotations;

namespace S1P2.BL.Classes
{
    public class Chicken : Animal
    {
        public string FeatherColor { get; set; } // Color of feathers
        public int EggsLaidPerDay { get; set; } // Average eggs laid per d


        public string LayEgg()
        {
            return $"{Name} has laid an egg.";
        }

        public Chicken(string rfid, string name) : base(rfid, name) { }

        public Chicken()
        {

        }
    }
}