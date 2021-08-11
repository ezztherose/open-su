using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Klient kallar på facade, vilket skapar startup struktur för gruppskidlektion -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeGruppskidlektion : IFacadeGruppskidlektion
    {
        public UnitOfWork UnitOfWork { get; set; }
        public Deltagare Deltagare {get;set;}
        public Gruppskidlektion Gruppskidlektion { get; set; }

        public FacadeGruppskidlektion(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        /// <summary>
        /// public List<Gruppskidlektion> GetAllGrupplektioner()
        /// ----------------------------------------------------
        /// Get a list of 'Skidlektion' and checks if the list contains 'Grupskidlektion'.
        /// If it contains 'Grupskidlektion', it will add it to a new list.
        /// </summary>
        /// <returns>
        /// It returns an list: GruppSkidlektion
        /// </returns>
        public List<Gruppskidlektion> GetAllGrupplektioner()
        {
            List<SkidLektion> tempgrupplektion = UnitOfWork.SkidLektionRepository.GetAll().ToList();
            List<Gruppskidlektion> gl = new List<Gruppskidlektion>();

            for (int i = 0; i < tempgrupplektion.Count; i++)
            {
                if (tempgrupplektion[i].GruppSkidlektioner == null) continue;
                gl.AddRange(tempgrupplektion[i].GruppSkidlektioner);
            }
            return ControllStatusLesson(gl);
        }

        /// <summary>
        /// private List<Gruppskidlektion> ControllStatusLesson(List<Gruppskidlektion> gList)
        /// ---------------------------------------------------------------------------------
        /// Takes an list of 'GruppSkidlektion' and sorts by status.
        /// If status = true, then it will be removed from the list.
        /// </summary>
        /// <param name="gList"></param>
        /// <returns>
        /// It returns an list: GruppSkidlektion
        /// </returns>
        private List<Gruppskidlektion> ControllStatusLesson(List<Gruppskidlektion> gList)
        {
            for (int i = 0; i < gList.Count; i++)
            {
                if (gList[i].Status == true)
                    gList.Remove(gList[i]);
            }
            return gList;
        }


        /// <summary>
        /// public List<Gruppskidlektion> GetAll()
        /// --------------------------------------
        /// Gets all grouplessons and returns it as a list.
        /// </summary>
        /// <returns></returns>
        public List<Gruppskidlektion> GetAll()
        {
            List<Gruppskidlektion> tempgrupplektion = UnitOfWork.GruppskidlektionRepository.GetAll().ToList();
            return tempgrupplektion;
        }

        /// <summary>
        /// public List<Gruppskidlektion> SearchGruppskidlektion(string search, int Dagar)
        /// ------------------------------------------------------------------------------
        /// Searching for a specified grouplesson with a search-term and number of days.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="Dagar"></param>
        /// <returns></returns>
        public List<Gruppskidlektion> SearchGruppskidlektion(string search, int Dagar)
        {
            List<Gruppskidlektion> gruppskidlektions = new List<Gruppskidlektion>();
            foreach (Gruppskidlektion gruppskidlektion in UnitOfWork.GruppskidlektionRepository.SearchGruppskidlektion(search.ToLower(), Dagar)) 
                if (gruppskidlektion.Status == false) gruppskidlektions.Add(gruppskidlektion);
            return gruppskidlektions;
        }

        /// <summary>
        /// public List<Deltagare> GetDeltagare(int id)
        /// -------------------------------------------
        /// Get participand by id from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Deltagare> GetDeltagare(int id)
        {
            List<Deltagare> deltagarlista = UnitOfWork.GruppskidlektionRepository.GetDeltagare(id);
            return deltagarlista;
        }

        /// <summary>
        /// public string RegisterToLesson(List<Deltagare> u, string color, int days)
        /// Takes in a list of participants, color, and days.
        /// -------------------------------------------------------------------------
        /// The method checks if the lesson can take all of the new participants. 
        /// If it can , it adds them to the lesson. Otehrwise it returns an
        /// error message to the user, and alos the amount it overreached.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="color"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public string RegisterToLesson(List<Deltagare> u, string color, int days)
        {
            int checksum = u.Count;
            List<Gruppskidlektion> temp = new List<Gruppskidlektion>();
            temp = UnitOfWork.GruppskidlektionRepository.GetAll().ToList();
            int count = 0;
            count += u.Count;

            for (int i = 0; i < temp.Count; i++)
                if (temp[i].Status == false)

                    if (temp[i].AntalDagar == days && temp[i].Färg.ToLower() == color.ToLower())
                    {
                        // kolla om det finns plats i lektionen
                        count += temp[i].Antaldeltagare;
                        if (count > 15)
                            return $"Det är fullt på lektionen. Det går inte att lägga till fler. Det finns inte plats för {checksum} person/personer";
                        else
                        {
                            for (int j = 0; j < u.Count; j++)
                            {
                                temp[i].GruppDeltagare.Add(u[j]);
                                temp[i].Antaldeltagare++;
                                UnitOfWork.Complete();
                            }
                            return $"Registrering genomförd.";
                        }
                    }
            return $"Saknad input. Color: {color} | eller Days: {days} | är inte ifyllda";
        }

        /// <summary>
        /// public double GetParticipandPrice(int _sendDays, string _sendColor)
        /// sends in two params, day & color to get the specific price of a lesson.
        /// </summary>
        /// <param name="_sendDays"></param>
        /// <param name="_sendColor"></param>
        /// <returns></returns>
        public double GetParticipandPrice(int _sendDays, string _sendColor)
        {
            double price = UnitOfWork.SkidLektionRepository.GetPriceForSpecificGroupLesson(_sendDays, _sendColor);
            return price;
        }

        /// <summary>
        /// public List<PrivatKund> SearchCustomer(string searchName)
        /// Search for a private customer by full name. If it finds any match
        /// it returns a list with all results.
        /// </summary>
        /// <param name="searchName"></param>
        /// <returns></returns>
        public List<PrivatKund> SearchCustomer(string searchName)
        {
            List<PrivatKund> ListToSort = UnitOfWork.PrivatKundRepository.GetAll().ToList();
            List<PrivatKund> SortedList = new List<PrivatKund>();

            for (int i = 0; i < ListToSort.Count; i++)
            {
                // Concatninate Firstname and Lastname to a singel string 
                string fullName = $"{ListToSort[i].PrivatFörnamn} {ListToSort[i].PrivatEfternamn}";
                // Compare search string (full name search) to nthe full name of an customer
                if (fullName.ToLower().StartsWith(searchName.ToLower()))
                    if (SortedList.Count != SortedList.Distinct().Count())
                        continue;
                    else
                        SortedList.Add(ListToSort[i]);
            }
            return SortedList;
        }

        /// <summary>
        /// public string GenerateInvoice(PrivatKund p, FöretagsKund f, double price)
        /// Takes a private customer, corperate customer and price. The methos uses the 
        /// in params to populate fielsd in a newly created invoice.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="f"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public string GenerateInvoice(PrivatKund p, FöretagsKund f, double price)
        {
            // Generating new ivoice and populate it with data
            Faktura newInvoice = new Faktura();
            newInvoice.FaktureringsDatum = DateTime.Now;
            newInvoice.FörfalloDatum = DateTime.Now.AddMonths(1);
            newInvoice.Typ = "Skidskola";
            newInvoice.Pris = price;
            newInvoice.Privat = p;
            newInvoice.Företag = f;

            // save invoice to database
            UnitOfWork.FakturaRepository.Add(newInvoice);
            UnitOfWork.Complete();
            return "Fakturan är genererad";
        }

        /// <summary>
        /// public void CreateLessonsForNewWeek()
        /// ---------------------------------------
        /// Status: If it's false its okej to use, if its 'true' then not okej to use 
        /// Thismethod creates a set of new lessons, bouded to a buttonclick
        /// </summary>
        public void CreateLessonsForNewWeek()
        {
            SetGroupLessonStatus();
            GenerateGroupLessons();
        }

        /// <summary>
        /// private void SetGroupLessonStatus()
        /// -----------------------------------
        /// change the status of existing lessons.
        /// </summary>
        private void SetGroupLessonStatus()
        {
            List<Gruppskidlektion> toChange = UnitOfWork.GruppskidlektionRepository.GetAll().ToList();
            for (int i = 0; i < toChange.Count; i++)
                if (toChange[i].Status == false) toChange[i].Status = true;
            UnitOfWork.Complete();
        }

        /// <summary>
        /// private void GenerateGroupLessons()
        /// -----------------------------------
        /// Cretre new lessons for each group.
        /// </summary>
        private void GenerateGroupLessons()
        {
            string[] color = { "Grön", "Blå", "Röd", "Svart", "Grön", "Blå", "Röd", "Svart" };
            int count = 3;
            for (int i = 0; i < 8; i++)
            {
                if (i == 4) count = 5;
                UnitOfWork.GruppskidlektionRepository.Add(new Gruppskidlektion()
                {
                    Färg = color[i],
                    AntalDagar = count,
                    Status = false
                });
                UnitOfWork.Complete();
            }
        }
    }
}
