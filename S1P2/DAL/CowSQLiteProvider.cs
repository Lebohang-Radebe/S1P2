using S1P2.BL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1P2.DAL
{
    public class CowSQLiteProvider : CowProviderBase
    {

        public override int Delete(string RFID)
        {
            // Method Name : int Delete(string RFID)
            // Purpose : Deletes a cow record from the SQLite datastore
            // Re-use : none
            // Input Parameter :
            // - string RFID
            //   - The RFID of the cow to be deleted from the SQLite datastore
            // Output Type :
            // - int
            //   - 0: Cow successfully deleted from SQLite datastore
            //   - -1: No cow was deleted from the SQLite datastore (not found)

            int rc = 0;
            Cow cow;
            try
            {
                using (AnimalContext db = new AnimalContext())
                {
                    cow = db.Cows.FirstOrDefault(c => c.RFID.Equals(RFID));
                    if (cow == null) // not found
                    {
                        rc = -1;
                    }
                    else
                    {
                        db.Cows.Remove(cow);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rc;
        }

        public override int Insert(Cow newCow)
        {
            // Method Name : int Insert(Cow newCow)
            // Purpose : Inserts a new cow record into the SQLite datastore
            // Re-use : none
            // Input Parameter :
            // - Cow newCow
            //   - The cow object to be inserted into the SQLite datastore
            // Output Type :
            // - int
            //   - 0: Cow successfully inserted into SQLite datastore
            //   - -1: Error occurred during insertion

            int rc = 0;
            Cow cow;
            try
            {
                using (AnimalContext db = new AnimalContext())
                {
                    cow = db.Cows.FirstOrDefault(c => c.RFID.Equals(newCow.RFID));
                    if (cow == null) // not found
                    {
                        db.Cows.Add(newCow);
                        db.SaveChanges();
                    }
                    else
                    {
                        rc = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rc;
        }

        public override List<Cow> SelectAll()
        {
            // Method Name : List<Cow> SelectAll()
            // Purpose : Retrieves all cow records from the SQLite datastore
            // Re-use : none
            // Input Parameter : none
            // Output Type :
            // - List<Cow>
            //   - List of cow records retrieved from the SQLite datastore

            List<Cow> cows = new List<Cow>();

            try
            {
                using (AnimalContext db = new AnimalContext())
                {
                    cows = db.Cows.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cows;
        }

        public override int SelectCow(string RFID, Cow cow)
        {
            // Method Name : int SelectCow(string RFID, ref Cow cow)
            // Purpose : Retrieves a single cow record from the SQLite datastore
            // Re-use : none
            // Input Parameter :
            // - string RFID
            //   - The RFID of the cow to load from the SQLite datastore
            // - ref Cow cow
            //   - The cow object loaded from the SQLite datastore
            // Output Type :
            // - int
            //   - 0: Cow loaded from SQLite datastore
            //   - -1: No cow was loaded from the SQLite datastore (not found)

            int rc = 0;

            try
            {
                using (AnimalContext db = new AnimalContext())
                {
                    cow = db.Cows.FirstOrDefault(c => c.RFID.Equals(RFID));
                    if (cow == null) // not found
                    {
                        rc = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rc;
        }

        public override int Update(Cow existingCow)
        {
            // Method Name: int Update(Cow existingCow)
            // Purpose : Updates an existing cow record in the SQLite datastore
            // Re-use : none
            // Input Parameter :
            // - Cow existingCow
            //   - The cow object with updated information to be updated in the SQLite datastore
            // Output Type :
            // - int
            //   - 0: Cow successfully updated in SQLite datastore
            //   - -1: Error occurred during update

            int rc = 0;
            Cow cow;
            try
            {
                using (AnimalContext db = new AnimalContext())
                {
                    cow = db.Cows.FirstOrDefault(c => c.RFID.Equals(existingCow.RFID));
                    if (cow == null) // not found
                    {
                        rc = -1;
                    }
                    else
                    {
                        cow.Name = existingCow.Name;
                        cow.Age = existingCow.Age;
                        // Assuming other properties like BreedType and MilkProductionLitre are present in Cow class
                        cow.BreedType = existingCow.BreedType;
                        cow.MilkProductionLitre = existingCow.MilkProductionLitre;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rc;
        }
    }

}
