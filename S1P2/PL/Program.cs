using S1P2.BL.Classes;
using static System.Console;

namespace S1P2.PL
{
    internal class Program
    {
        public static List<Cow> cowList;

        static void Initialise()
        {
            //
            //Method Name     : void Initialise() 
            //Purpose         : Initialise and instantiate global variables
            //Re-use          : none
            //Input Parameter : none
            //Output Type     : none
            //
            cowList = new List<Cow>();
        } // end method

        //--------------------------------------------------------------------------------
        //
        // Display menus
        //
        //--------------------------------------------------------------------------------

        public static void ShowMainMenu()
        {
            //
            //Method Name     : void ShowMainMenu() 
            //Purpose         : Display the main menu
            //Re-use          : none
            //Input Parameter : none
            //Output Type     : none
            //
            WriteLine();
            WriteLine("Please select an option:");
            WriteLine("========================");
            WriteLine("1. Cow Maintenance");
            WriteLine("X. Exit");
            WriteLine();
        } // end method ShowMainMenu()

        public static void ShowCowMaint()
        {
            //
            //Method Name     : void ShowCowMaint() 
            //Purpose         : Display the Cow Maintenance menu
            //Re-use          : none
            //Input Parameter : none
            //Output Type     : none
            //
            WriteLine();
            WriteLine("Cow Maintenance - Please select an option:");
            WriteLine("==========================================");
            WriteLine("1. List Cow");
            WriteLine("2. Add Cow");
            WriteLine("3. Remove Cow");
            WriteLine("4. Update Cow");
            WriteLine("R. Return");
            WriteLine();
        } // end method ShowCowMaint()

        //--------------------------------------------------------------------------------
        //
        // Process menus
        //
        //--------------------------------------------------------------------------------
        public static void ProcessCowMenu()
        {
            //
            //Method Name     : void ProcessCowMenu() 
            //Purpose         : Invoke appropriate method to handle user menu selection
            //Re-use          : ShowCowMaint();CowList();CowAdd();CowRemove();
            //                  CowUpdate()
            //Input Parameter : none
            //Output Type     : none
            //
            char choice = '0';
            ConsoleKeyInfo cki;

            WriteLine();
            ShowCowMaint();

            cki = ReadKey();
            WriteLine();
            choice = cki.KeyChar;

            while (choice != 'r' && choice != 'R')
            {
                switch (choice)
                {
                    case '1':
                        CowList();
                        break;
                    case '2':
                        CowAdd();
                        break;
                    case '3':
                        CowRemove();
                        break;
                    case '4':
                        CowUpdate();
                        break;
                    case 'R':
                    case 'r':
                        break;
                    default:
                        WriteLine("Invalid input");
                        break;
                } // end switch
                WriteLine();
                ShowCowMaint();

                cki = ReadKey();
                WriteLine();
                choice = cki.KeyChar;
            } // end while
        } // end method


        //--------------------------------------------------------------------------------
        //
        // Cow related methods
        //
        //--------------------------------------------------------------------------------

        public static void CowUpdate()
        {
            //
            //Method Name     : void CowUpdate() 
            //Purpose         : Update existing cow info
            //Re-use          : none
            //Input Parameter : none
            //Output Type     : none
            //
            string RFID = "";
            string age = "";
            string name = "";
            string breedType = "";
            string milkProduction = "";
            int rc = 0;
            bool change = false;
            Cow cowFoundRef = null;

            Write("Please enter the cow RFID: ");
            RFID = ReadLine().ToUpper();
            cowFoundRef = FindCow(RFID);
            if (cowFoundRef != null)
            {
                cowFoundRef.RFID = RFID;
                WriteLine(cowFoundRef);
                Write("New age or press enter not to change: ");
                age = ReadLine();
                if (age.Length != 0)
                {
                    cowFoundRef.Age = Convert.ToInt32(age);
                    change = true;
                } // end if

                Write("New name or press enter not to change: ");
                name = ReadLine();
                if (name.Length != 0)
                {
                    cowFoundRef.Name = name;
                    change = true;
                } // end if

                Write("New breed type or press enter not to change: ");
                breedType = ReadLine();
                if (breedType.Length != 0)
                {
                    cowFoundRef.BreedType = breedType;
                    change = true;
                } // end if

                Write("New milk production or press enter not to change: ");
                milkProduction = ReadLine();
                if (milkProduction.Length != 0)
                {
                    cowFoundRef.MilkProductionLitre = Convert.ToDecimal(milkProduction);
                    change = true;
                } // end if

                if (change)
                {
                    WriteLine(RFID + " updated");
                } // end if
                else
                {
                    WriteLine("Nothing selected to update");
                } // end else

            } // end if
            else
            {
                WriteLine(RFID + " NOT found");
            } // end else
        } // end method

        public static void CowAdd()
        {
            //
            //Method Name     : void CowAdd() 
            //Purpose         : Get new Cow info and try to add it to the list
            //Re-use          : none
            //Input Parameter : none
            //Output Type     : none
            //
            string RFID = "";
            string name = "";
            string breedType = "";
            string milkProduction = "";
            int age = 0;
            int rc = 0;
            Cow cow = null;
            Cow cowFoundRef = null;

            WriteLine("Please supply the following cow info:");
            Write("RFID: ");
            RFID = ReadLine().ToUpper();
            cowFoundRef = FindCow(RFID);
            if (cowFoundRef != null)
            {
                WriteLine(RFID + " NOT added since it is already in the list");
            } // end if
            else
            {
                Write("Age: ");
                age = Convert.ToInt32(ReadLine());
                Write("Name: ");
                name = ReadLine();
                Write("Breed Type: ");
                breedType = ReadLine();
                Write("Milk Production: ");
                milkProduction = ReadLine();

                cow = new Cow(RFID, name);
                cow.BreedType = breedType;
                cow.MilkProductionLitre = Convert.ToDecimal(milkProduction);
                cow.Age = age;
                cowList.Add(cow);

                WriteLine(RFID + " added");
            } // end else


        } // end method

        public static void CowRemove()
        {
            //
            //Method Name     : void CowRemove() 
            //Purpose         : Try to remove a Cow record from the list
            //Re-use          : none
            //Input Parameter : none
            //Output Type     : none
            //
            string rfid = "";
            int rc = 0;
            Cow cowRef = null;

            if (cowList.Count > 0)
            {
                Write("Please enter the cow RFID: ");
                rfid = ReadLine().ToUpper();
                cowRef = FindCow(rfid);
                if (cowRef != null)
                {
                    cowList.Remove(cowRef);
                    WriteLine(rfid + " removed from list");
                } // end if
                else
                {
                    WriteLine(rfid + " NOT removed since it is not in the list");
                } // end else
            } // end if
            else
            {
                WriteLine("No cow record to remove from the list");
            } // end else
        } // end method

        public static void CowList()
        {
            //
            //Method Name     : void CowList() 
            //Purpose         : Display the Cow records in the list
            //Re-use          : none
            //Input Parameter : none
            //Output Type     : none
            //
            if (cowList.Count == 0)
            {
                WriteLine("No Cow records found");
            } // end if
            else
            {
                foreach (Cow cowRef in cowList)
                {
                    WriteLine(cowRef);
                } // end foreach
            } // end if
        } // end method


        //--------------------------------------------------------------------------------
        //
        // Private helper methods
        //
        //--------------------------------------------------------------------------------
        private static Cow FindCow(string rfid)
        {
            //
            //Method Name     : Employee FindCow(string rfid)
            //Purpose         : Search for a Cow object in the generic collection
            //Re-use          : none
            //Input Parameter : string rfid
            //Output Type     : Cow
            //                  - if the Cow object was found it is returned, otherwise null
            //
            bool found = false;
            int lc = 0;
            Cow cowRef = null;
            while (found == false && lc < cowList.Count)
            {
                if (cowList[lc].RFID == rfid)
                {
                    found = true;
                    cowRef = cowList[lc];
                } // end if

                lc++;
            } // end while

            return cowRef;
        } // end method


        //--------------------------------------------------------------------------------
        //
        // Main
        //
        //--------------------------------------------------------------------------------
        public static void Main(string[] args)
        {
            //
            //Method Name     : void Main(string[] args)
            //Purpose         : Main entry into program
            //Re-use          : ShowMainMenu(); ProcessCowMenu()
            //Input Parameter : string[] args
            //                  - command line args - not used
            //Output Type     : none
            //

            char choice = '0';
            ConsoleKeyInfo cki;

            try
            {
                Initialise();

                WriteLine();
                ShowMainMenu();

                cki = ReadKey();
                WriteLine();
                choice = cki.KeyChar;

                while (choice != 'x' && choice != 'X')
                {
                    switch (choice)
                    {
                        case '1':
                            ProcessCowMenu();
                            break;
                        case 'x':
                        case 'X':
                            break;
                        default:
                            WriteLine("Invalid input");
                            break;
                    } // end switch

                    WriteLine();
                    ShowMainMenu();

                    cki = ReadKey();
                    WriteLine();
                    choice = cki.KeyChar;
                } // end while
            } // end try 
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            } // end catch
        } // end method Main()        
    } // end class
} // end namespace