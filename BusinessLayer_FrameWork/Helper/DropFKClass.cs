using BusinessEntities_FrameWork.Models;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
* Hämtar definerade listor för elementen till varje fallande meny i GUI. 
* Uppdaterar databas vid knapptryck
 */

namespace BusinessLayer_FrameWork.Helper
{
    internal class DropFKClass
    {
        UnitOfWork UnitOfWork { get; set; }

        public DropFKClass(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
            
        }

        public void Run()
        {
            DropAllKeysInFaktura();
            DropAllKeysInBokning();
            DropAllKeysInDeltagare();
            DropAllKeysGruppskidlektion();
            DropAllKeysKonferens();
            DropAllKeysKonferensPris();
            DropAllKeysLogi();
            DropAllKeysPreBokning();
            DropAllKeysPrivatKund();
            DropAllKeysPrivatSkidlektion();
            DropAllKeysSkidlektion();
            DropAllKeysSysAdmin();
            DropAllKeysUthyrning();
            DropAllKeysUtrustning();
        }

        private void DropAllKeysInFaktura()
        {
            List<Faktura> FakturaLista = UnitOfWork.FakturaRepository.GetAll().ToList();
            for (int i = 0; i < FakturaLista.Count; i++)
            {
                FakturaLista[i].Bokning = null;
                FakturaLista[i].Företag = null;
                FakturaLista[i].Privat = null;
                FakturaLista[i].Uthyrning = null;
                UnitOfWork.FakturaRepository.Update(FakturaLista[i], FakturaLista[i].FakturaID);
            }
            UnitOfWork.Complete();
        }

        private void DropAllKeysInBokning()
        {
            List<Bokning> BokningarLista = UnitOfWork.BokningRepository.GetAll().ToList();
            for (int i = 0; i < BokningarLista.Count; i++)
            {
                BokningarLista[i].FöretagsKund = null;
                BokningarLista[i].PrivatKund = null;
                UnitOfWork.BokningRepository.Update(BokningarLista[i], BokningarLista[i].BokningsID);
            }
            UnitOfWork.Complete();
        }

        private void DropAllKeysInDeltagare()
        {
            List<Deltagare> DeltagarLista = UnitOfWork.DeltagareRepository.GetAll().ToList();
            for (int i = 0; i < DeltagarLista.Count; i++)
            {
                DeltagarLista[i].Gruppskidlektion = null;
                DeltagarLista[i].Privatskidlektion = null;
                UnitOfWork.DeltagareRepository.Update(DeltagarLista[i], DeltagarLista[i].DeltagarID);
            }
            UnitOfWork.Complete();
        }

        private void DropAllKeysGruppskidlektion()
        {
            List<Gruppskidlektion> GruppLista = UnitOfWork.GruppskidlektionRepository.GetAll().ToList();
            for (int i = 0; i < GruppLista.Count; i++)
            {
                GruppLista[i].SkidLektion = null;
                UnitOfWork.GruppskidlektionRepository.Update(GruppLista[i], GruppLista[i].GruppskidlektionsID);
            }
            UnitOfWork.Complete();
        }

        private void DropAllKeysKonferens()
        {
            List<Konferens> KonferensLista = UnitOfWork.KonferensRepository.GetAll().ToList();
            for (int i = 0; i < KonferensLista.Count; i++)
            {
                KonferensLista[i].Bokning = null;
                UnitOfWork.KonferensRepository.Update(KonferensLista[i], KonferensLista[i].KonferensID);
            }
            UnitOfWork.Complete();
        }

        private void DropAllKeysKonferensPris()
        {
            List<KonferensPris> KonferensPrisLista = UnitOfWork.KonferensPrisRepository.GetAll().ToList();
            for (int i = 0; i < KonferensPrisLista.Count; i++)
            {
                KonferensPrisLista[i].Konferens = null;
                UnitOfWork.KonferensPrisRepository.Update(KonferensPrisLista[i], KonferensPrisLista[i].KonferensPrisID);
            }
            UnitOfWork.Complete();
        }

        private void DropAllKeysLogi()
        {
            List<Logi> LogiLista = UnitOfWork.LogiRepository.GetAll().ToList();
            for (int i = 0; i < LogiLista.Count; i++)
            {
                LogiLista[i].Bokning = null;
                LogiLista[i].PreBokning = null;
                UnitOfWork.LogiRepository.Update(LogiLista[i], LogiLista[i].LogiID);
            }
            UnitOfWork.Complete();
        }

        private void DropAllKeysPreBokning()
        {
            List<PreBokning> PreBokningLista = UnitOfWork.PreBokningRepository.GetAll().ToList();
            for (int i = 0; i < PreBokningLista.Count; i++)
            {
                PreBokningLista[i].Bokning = null;
                PreBokningLista[i].PrivatKund = null;
                PreBokningLista[i].FöretagsKund = null;
                UnitOfWork.PreBokningRepository.Update(PreBokningLista[i], PreBokningLista[i].BokningsID);
            }
            UnitOfWork.Complete();
        }

        private void DropAllKeysPrivatKund()
        {
            List<PrivatKund> PrivatKundLista = UnitOfWork.PrivatKundRepository.GetAll().ToList();
            for (int i = 0; i < PrivatKundLista.Count; i++)
            {
                PrivatKundLista[i].Fakturor = null;
                PrivatKundLista[i].Uthyrningar = null;
                PrivatKundLista[i].PreBokningar = null;
                PrivatKundLista[i].Bokningar = null;
                UnitOfWork.PrivatKundRepository.Update(PrivatKundLista[i], PrivatKundLista[i].PrivatKundID);
            }
            UnitOfWork.Complete();
        }

        private void DropAllKeysPrivatSkidlektion()
        {
            List<Privatskidlektion> PrivatSkidlektionLista = UnitOfWork.PrivatLektionRepository.GetAll().ToList();
            for (int i = 0; i < PrivatSkidlektionLista.Count; i++)
            {
                PrivatSkidlektionLista[i].SkidLektion = null;
                UnitOfWork.PrivatLektionRepository.Update(PrivatSkidlektionLista[i], PrivatSkidlektionLista[i].PrivatskidlektionsID);
            }
            UnitOfWork.Complete();
        }

        private void DropAllKeysSkidlektion()
        {
            List<SkidLektion> SkidLektionLista = UnitOfWork.SkidLektionRepository.GetAll().ToList();
            for (int i = 0; i < SkidLektionLista.Count; i++)
            {
                SkidLektionLista[i].SkidLärare = null;
                SkidLektionLista[i].Antal = null;
                SkidLektionLista[i].Deltagarnamn = null;
                UnitOfWork.SkidLektionRepository.Update(SkidLektionLista[i], SkidLektionLista[i].SkidLektionsID);
            }
            UnitOfWork.Complete();
        }

        private void DropAllKeysSysAdmin()
        {
            List<SysAdmin> SysAdminLista = UnitOfWork.SysAdminRepository.GetAll().ToList();
            for (int i = 0; i < SysAdminLista.Count; i++)
            {
                SysAdminLista[i].Anställd = null;
                UnitOfWork.SysAdminRepository.Update(SysAdminLista[i], SysAdminLista[i].SysAdminID);
            }
            UnitOfWork.Complete();
        }

        private void DropAllKeysUthyrning()
        {
            List<Uthyrning> UthyrningLista = UnitOfWork.UthyrningRepository.GetAll().ToList();
            for (int i = 0; i < UthyrningLista.Count; i++)
            {
                UthyrningLista[i].Anställd = null;
                UthyrningLista[i].Faktura = null;
                UthyrningLista[i].FöretagsKund = null;
                UthyrningLista[i].PrivatKund = null;
                UthyrningLista[i].TempKund = null;
                UnitOfWork.UthyrningRepository.Update(UthyrningLista[i], UthyrningLista[i].UthyrningsID);
            }
            UnitOfWork.Complete();
        }

        private void DropAllKeysUtrustning()
        {
            List<Utrustning> UtrustningLista = UnitOfWork.UtrustningRepository.GetAll().ToList();
            for (int i = 0; i < UtrustningLista.Count; i++)
            {
                UtrustningLista[i].Uthyrning = null;
                UtrustningLista[i].Hyrpris = null;
                UnitOfWork.UtrustningRepository.Update(UtrustningLista[i], UtrustningLista[i].ArtikelID);
            }
            UnitOfWork.Complete();
        }
    }
}
