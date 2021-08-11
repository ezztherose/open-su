using BusinessEntities_FrameWork.Interfaces;
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork.Interfaces;
using BusinessLayer_FrameWork.Models;
using DataLayer_FrameWork.Context;
using DataLayer_FrameWork.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/*
 * Implementation av Facade-Pattern för att lättare anropa de olika 
 * klasserna från GUI, samt dölja sötter del av koden.
 */

namespace BusinessLayer_FrameWork
{
    public class FacadeBusiness
    {
        // Properties
        public DatabaseContext Context { get; set; }
        public IFacadeBokning FacadeBokning { get; set; }
        public IFacadeSysAdmin FacadeSysAdmin { get; set; }
        public IFacadeBokningSkidlektion FacadeBokningSkidlektion { get; set; }
        public IFacadeDeltagare FacadeDeltagare { get; set; }
        public IFacadeFaktura FacadeFaktura { get; set; }
        public IFacadeFöretagsKund FacadeFöretagsKund { get; set; }
        public IFacadeHyrpris FacadeHyrpris { get; set; }
        public IFacadeKonferens FacadeKonferens { get; set; }
        public IFacadeKonferensPris FacadeKonferensPris { get; set; }
        public IFacadeLogi FacadeLogi { get; set; }
        public IFacadeLogiBokning FacadeLogiBokning { get; set; }
        public IFacadeMarknadsChef FacadeMarknadsChef { get; set; }
        public IFacadeTempKund FacadeTempKund { get; set; }
        public IFacadeUthyrning FacadeUthyrning { get; set; }
        public IFacadeUtrustning FacadeUtrustning { get; set; }
        public IFacadePrivatKund FacadePrivatKund { get; set; }
        public IFacadeSkidlektion FacadeSkidlektion { get; set; }
        public IFacadeAnställd FacadeAnställd { get; set; }
        public IFacadePreBokning FacadePreBokning { get; set; }
        public IFacadeLogiPris FacadeLogiPris { get; set; }
        public IFacadeBokningsregister FacadeBokningsregister { get; set; }
        public IFacadeButiksregister FacadeButiksregister { get; set; }
        public IFacadeFakturaregister FacadeFakturaregister { get; set; }
        public IFacadeKundregister FacadeKundregister { get; set; }
        public IFacadeUthyrningsregister FacadeUthyrningsregister { get; set; }
        public IFacadePrivatLektion FacadePrivatLektion { get; set; }
        public IFacadeGruppskidlektion FacadeGruppskidlektion { get; set; }
        public static object FacadeFakturaFörKöp { get; set; }


        // Constructor
        public FacadeBusiness()
        {
            Context = new DatabaseContext();
            FacadeBokning = new FacadeBokning(Context);
            FacadeSysAdmin = new FacadeSysAdmin(Context);
            FacadeBokningSkidlektion = new FacadeBokningSkidlektion(Context);
            FacadeBokning = new FacadeBokning(Context);
            FacadeDeltagare = new FacadeDeltagare(Context);
            FacadeFaktura = new FacadeFaktura(Context);
            FacadeFöretagsKund = new FacadeFöretagsKund(Context);
            FacadeHyrpris = new FacadeHyrpris(Context);
            FacadeKonferens = new FacadeKonferens(Context);
            FacadeKonferensPris = new FacadeKonferensPris(Context);
            FacadeLogi = new FacadeLogi(Context);
            FacadeLogiBokning = new FacadeLogiBokning(Context);
            FacadeTempKund = new FacadeTempKund(Context);
            FacadeUthyrning = new FacadeUthyrning(Context);
            FacadeUtrustning = new FacadeUtrustning(Context);
            FacadePrivatKund = new FacadePrivatKund(Context);
            FacadeSkidlektion = new FacadeSkidlektion(Context);
            FacadeMarknadsChef = new FacadeMarknadsChef(Context);
            FacadeAnställd = new FacadeAnställd(Context);
            FacadePreBokning = new FacadePreBokning(Context);
            FacadeLogiPris = new FacadeLogiPris(Context);
            FacadeBokningsregister = new FacadeBokningsregister(Context);
            FacadeButiksregister = new FacadeButiksregister(Context);
            FacadeFakturaregister = new FacadeFakturaregister(Context);
            FacadeKundregister = new FacadeKundregister(Context);
            FacadeUthyrningsregister = new FacadeUthyrningsregister(Context);
            FacadePrivatLektion = new FacadePrivatLektion(Context);
            FacadeGruppskidlektion = new FacadeGruppskidlektion(Context);
        }
    }
}
