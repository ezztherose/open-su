using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;

//Klient kallar på facade, vilket skapar startup struktur för konferens -> bygg design.

namespace BusinessLayer_FrameWork.Models
{
    public class FacadeKonferens : IFacadeKonferens
    {
        public UnitOfWork UnitOfWork { get; set; }

        public FacadeKonferens(DatabaseContext context)
        {
            UnitOfWork = new UnitOfWork(context);
        }

        public List<Konferens> GetAllKonferens()
        {
            List<Konferens> konferensLista = new List<Konferens>();
            konferensLista.AddRange(UnitOfWork.KonferensRepository.GetAll());
            return konferensLista;
        }

        public void RemoveKonferensInfo(Konferens Konferens)
        {
            UnitOfWork.KonferensRepository.Remove(Konferens.KonferensID);
            UnitOfWork.Complete();
        }

        public void RemoveAllKonferens(List<Konferens> Konferens)
        {
            UnitOfWork.KonferensRepository.RemoveRange(Konferens);
            UnitOfWork.Complete();
        }

        public List<Konferens> SearchKonferens(string search)
        {
            List<Konferens> sökkonferens = new List<Konferens>();
            foreach (Konferens k in UnitOfWork.KonferensRepository.SearchKonferens(search.ToLower()))
                sökkonferens.Add(k);
            return sökkonferens;
        }
        public List<Konferens> KonferensPåBokningsID(Bokning bokning)
        {
           return UnitOfWork.KonferensRepository.KonferensPåBokningsID(bokning);
        }

        public double GetPrisKonferens(string konferensTyp, string tidTyp, int vecka)
        {
           KonferensPris temp = UnitOfWork.KonferensPrisRepository.GetPrisKonferens(konferensTyp, tidTyp, vecka);
            double konferensPris = temp.Pris;
            return konferensPris;
            
        }
        public List<Konferens>GetKonferensStor()
        {
            return UnitOfWork.KonferensRepository.GetKonferensStor();
        }
        public List<Konferens> GetKonferensLiten()
        {
            return UnitOfWork.KonferensRepository.GetKonferensLiten();
        }
    }
}
