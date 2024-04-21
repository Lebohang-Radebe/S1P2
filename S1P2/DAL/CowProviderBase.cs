using S1P2.BL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1P2.DAL
{
    public abstract class CowProviderBase
    {
        // Method Name : List<Cow> SelectAll()
        // Purpose : Retrieves all cow records from the data store
        // Re-use : none
        // Input Parameter : none
        // Output Type :
        // - List<Cow>
        //   - List of cow records retrieved from the data store
        public abstract List<Cow> SelectAll();

        // Method Name : int SelectCow(string RFID, ref Cow cow)
        // Purpose : Retrieves a single cow record from the data store
        // Re-use : none
        // Input Parameter :
        // - string RFID
        //   - The RFID of the cow to load from the data store
        // - ref Cow cow
        //   - The cow object loaded from the data store
        // Output Type :
        // - int
        //   - 0: Cow loaded from data store
        //   - -1: No cow was loaded from the data store (not found)
        public abstract int SelectCow(string RFID, Cow cow);

        // Method Name : int Insert(Cow newCow)
        // Purpose : Inserts a new cow record into the data store
        // Re-use : none
        // Input Parameter :
        // - Cow newCow
        //   - The cow object to be inserted into the data store
        // Output Type :
        // - int
        //   - 0: Cow successfully inserted into data store
        //   - -1: Error occurred during insertion
        public abstract int Insert(Cow newCow);

        // Method Name : int Update(Cow existingCow)
        // Purpose : Updates an existing cow record in the data store
        // Re-use : none
        // Input Parameter :
        // - Cow existingCow
        //   - The cow object with updated information to be updated in the data store
        // Output Type :
        // - int
        //   - 0: Cow successfully updated in data store
        //   - -1: Error occurred during update
        public abstract int Update(Cow existingCow);

        // Method Name : int Delete(string RFID)
        // Purpose : Deletes a cow record from the data store
        // Re-use : none
        // Input Parameter :
        // - string RFID
        //   - The RFID of the cow to be deleted from the data store
        // Output Type :
        // - int
        //   - 0: Cow successfully deleted from data store
        //   - -1: No cow was deleted from the data store (not found)
        public abstract int Delete(string RFID);
    }
}
