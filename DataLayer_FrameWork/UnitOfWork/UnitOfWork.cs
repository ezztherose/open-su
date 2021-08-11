using BusinessEntities_FrameWork.Interfaces;
using BusinessEntities_FrameWork.Models;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/*
 * UnitOfWork
 * ----------
 * Uppsamlingsklass som samlar upp alla repository klasser för att lättare kunna 
 * komma åt datalagret från businesslagret.
 * 
 * I denna klass är alla properties varje repositorys Interface och de instansier sin
 * klass i konstruktorn.
 * 
 */

namespace DataLayer_FrameWork.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        // Properties
        public DatabaseContext DBContext { get; set; }

        public IAnställdRepository AnställdRepository { get; set; }
        public IBokningRepository BokningRepository { get; set; }
        public IBokningSkidLektionRepository BokningSkidLektionRepository { get; set; }
        public IDeltagareRepository DeltagareRepository { get; set; }
        public IFakturaRepository FakturaRepository { get; set; }
        public IFöretagsKundRepository FöretagsKundRepository { get; set; }
        public IPrivatKundRepository PrivatKundRepository { get; set; }
        public ITempKundRepository TempKundRepository { get; set; }
        public IUthyrningRepository UthyrningRepository { get; set; }
        public IUtrustningRepository UtrustningRepository { get; set; }
        public ISysAdminRepository SysAdminRepository { get; set; }
        public IMarknadsChefRepository MarknadsChefRepository { get; set; }
        public ILogiPrisRepository LogiPrisRepository { get; set; }
        public IPreBokningRepository PreBokningRepository { get; set; }
        public ILogiRepository LogiRepository { get; set; }
        public IHyrPrisRepository HyrPrisRepository { get; set; }
        public IBokningsregisterRepository BokningsregisterRepository { get; set; }
        public IButiksregisterRepository ButiksregisterRepository { get; set; }
        public IKonferensPrisRepository KonferensPrisRepository { get; set; }
        public IGruppskidlektionRepository GruppskidlektionRepository {get; set;}
        public IPrivatLektionRepository PrivatLektionRepository { get; set; }
        public ISkidLektionRepository SkidLektionRepository { get; set; }
        public IKonferensRepository KonferensRepository { get; set; }
        

        /* 
         * Constructor 
         * Instansier istansiering av alla repositories
         */
        public UnitOfWork(DatabaseContext context)
        {
            DBContext = context;

            AnställdRepository = new AnställdRepository(DBContext);
            BokningRepository = new BokningRepository(DBContext);
            BokningSkidLektionRepository = new BokningSkidLektionRepository(DBContext);
            SysAdminRepository = new SysAdminRepository(DBContext); 
            DeltagareRepository = new DeltagareRepository(DBContext);
            FakturaRepository = new FakturaRepository(DBContext);
            FöretagsKundRepository = new FöretagsKundRepository(DBContext);
            PrivatKundRepository = new PrivatKundRepository(DBContext);
            TempKundRepository = new TempKundRepository(DBContext);
            UthyrningRepository = new UthyrningRepository(DBContext);
            UtrustningRepository = new UtrustningRepository(DBContext);
            MarknadsChefRepository = new MarknadsChefRepository(DBContext);
            PreBokningRepository = new PreBokningRepository(DBContext);
            LogiRepository = new LogiRepository(DBContext);
            HyrPrisRepository = new HyrPrisRepository(DBContext);
            BokningsregisterRepository = new BokningsregisterRepository(DBContext);
            BokningRepository = new BokningRepository(DBContext);
            ButiksregisterRepository = new ButiksregisterRepository(DBContext);
            KonferensPrisRepository = new KonferensPrisRepository(DBContext);
            GruppskidlektionRepository = new GruppskidlektionRepository(DBContext);
            PrivatLektionRepository = new PrivatLektionRepository(DBContext);
            LogiPrisRepository = new LogiPrisRepository(DBContext);
            SkidLektionRepository = new SkidLektionRepository(DBContext);
            KonferensRepository = new KonferensRepository(DBContext);
           
        }

        // Methods       

        /// <summary>
        /// Complete();
        /// Innehåller SvaveChanges som sparar ändringar till databasen.
        /// </summary>
        /// <returns></returns>
        public int Complete()
        {  
            return DBContext.SaveChanges();
        }


        public void Dispose()
        {
            DBContext.Dispose();
        }

        /// <summary>
        /// ResetDB()
        /// Innehåller metoden till att droppa alla tabeller i databasen och
        /// återskapa dem samt köra nya seed metoder.
        /// </summary>
        public void ResetDB()
        {
            DBContext.Reset();
        }
    }
}
