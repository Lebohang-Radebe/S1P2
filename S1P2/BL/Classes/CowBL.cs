using S1P2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1P2.BL.Classes
{
    public class CowBL
    {
        private CowProviderBase providerBase;

        public CowBL(string provider)
        {
            // Method Name : CowBL
            // Purpose : Constructor for the CowBL class
            // Re-use : none
            // Input Parameter :
            // - string provider
            //   - The type of provider to use for accessing cow data

            this.providerBase = this.setupProviderBase(provider);
        }

        public List<Cow> SelectAll()
        {
            // Method Name : List<Cow> SelectAll()
            // Purpose : Retrieves all cow records from the datastore
            // Re-use : none
            // Input Parameter : none
            // Output Type :
            // - List<Cow>
            //   - List of cow records retrieved from the datastore

            return this.providerBase.SelectAll();
        }

        public int SelectCow(string RFID, Cow cow)
        {
            // Method Name : int SelectCow(string RFID, ref Cow cow)
            // Purpose : Retrieves a single cow record from the datastore
            // Re-use : none
            // Input Parameter :
            // - string RFID
            //   - The RFID of the cow to load from the datastore
            // - ref Cow cow
            //   - The cow object loaded from the datastore
            // Output Type :
            // - int
            //   - 0: Cow loaded from datastore
            //   - -1: No cow was loaded from the datastore (not found)

            return this.providerBase.SelectCow(RFID, cow);
        }

        public int Insert(Cow newCow)
        {
            // Method Name : int Insert(Cow newCow)
            // Purpose : Inserts a new cow record into the datastore
            // Re-use : none
            // Input Parameter :
            // - Cow newCow
            //   - The cow object to be inserted into the datastore
            // Output Type :
            // - int
            //   - 0: Cow successfully inserted into datastore
            //   - -1: Error occurred during insertion

            return this.providerBase.Insert(newCow);
        }

        public int Update(Cow existingCow)
        {
            // Method Name : int Update(Cow existingCow)
            // Purpose : Updates an existing cow record in the datastore
            // Re-use : none
            // Input Parameter :
            // - Cow existingCow
            //   - The cow object with updated information to be updated in the datastore
            // Output Type :
            // - int
            //   - 0: Cow successfully updated in datastore
            //   - -1: Error occurred during update

            return this.providerBase.Update(existingCow);
        }

        public int Delete(string RFID)
        {
            // Method Name : int Delete(string RFID)
            // Purpose : Deletes a cow record from the datastore
            // Re-use : none
            // Input Parameter :
            // - string RFID
            //   - The RFID of the cow to be deleted from the datastore
            // Output Type :
            // - int
            //   - 0: Cow successfully deleted from datastore
            //   - -1: No cow was deleted from the datastore (not found)

            return this.providerBase.Delete(RFID);
        }

        private CowProviderBase setupProviderBase(string provider)
        {
            // Logic to determine which provider to use based on the provider string
            // For example, if provider == "Database" then return new CowSQLiteProvider();
            throw new NotImplementedException("The method or operation is not implemented.");
        }
    }
}
