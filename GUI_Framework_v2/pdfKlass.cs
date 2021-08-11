
using BusinessEntities_FrameWork.Models;
using BusinessLayer_FrameWork;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Framework_v2
{
    internal class PdfKlass
    {
        public FacadeBusiness FacadeBusiness { get; set; }
        public PrivatKund PrivatKund { get; set; }
        public Faktura Faktura{ get; set; }
        int a = 480;
        


        public double pris;
        double moms = 1.12;
        double prisinklmoms;
        double prisexklmoms; 
        public PdfKlass()
        {
            FacadeBusiness = new FacadeBusiness();
        }

        // Metod som skriver ut faktura för privatkund 
        // Fakturan skrivs ut till en pdf 
        public void FakturaUtskriftPrivat(Faktura faktura, PrivatKund pk, Uthyrning uthyrning) 
        {
            if (pk != null)
            {
               List<bool> alpinpaketstatus = new List<bool>();
               List<bool> längdpaketstatus = new List<bool>();
               List<bool> snowboardpaketstatus = new List<bool>();
                double Hyrpris = 0;
            string tempSort = null;
            string tempTyp = null;
             double hyrpris = 0;
            int d = 500;
            int b = 380;
            int a = 480;

                string tempDagar = null;
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = ("\\Faktura " + faktura.Privat.PrivatFörnamn +" " + faktura.FakturaID);
            string endpoint = ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 40, 40);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(savePath + filename + endpoint, FileMode.Create, FileAccess.ReadWrite));
            doc.Open();
            PdfContentByte cb = wri.DirectContent;
            cb.BeginText();
            BaseFont font = BaseFont.CreateFont("c:\\windows\\fonts\\calibrib.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            Paragraph pgraph1 = new Paragraph("Ski-Center ");


            //VÄNSTER = KOLUMN Y, HÖGER = RAD X. (Y,X)

            cb.SetFontAndSize(font, 20);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Ski-Center", 120, 800, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Faktura", 120, 775, 0);
            cb.SetFontAndSize(font, 10);
            Paragraph pgraph2 = new Paragraph("Head");
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Skicentergatan 1", 120, 730, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "123 45 , Borås", 120, 710, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "(70) 712-3456", 120, 690, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, DateTime.Now.ToString(), 120, 670, 0);
            Paragraph pgraph3 = new Paragraph("Objekt");
            cb.SetFontAndSize(font, 15);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Faktura till", 120, 630, 0);
            cb.SetFontAndSize(font, 10);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, pk.PrivatFörnamn + " " + pk.PrivatEfternamn, 120, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, pk.PrivatGatuadress, 120, 580, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, pk.PrivatPostnummer + " " + pk.PrivatPostort , 120, 560, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, pk.PrivatTelefonnummer, 120, 540, 0);
            cb.SetFontAndSize(font, 15);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Information", 120, 500, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Belopp", 460, 500, 0);
            cb.SetFontAndSize(font, 10);
            if (faktura.Typ == "Uthyrning")
            {
                List<Utrustning> temp = FacadeBusiness.FacadeUtrustning.UtrustningPåUthyrningsID(faktura.Uthyrning);
                    for (int i = 0; i < temp.Count; i++)
                    {
                        if (temp[i].PaketStatus == false)
                        {
                            tempSort = temp[i].UtrustningSort;
                            tempTyp = temp[i].UtrustningsTyp;
                            tempDagar = uthyrning.AntalDagar.ToString();
                            if (temp[i].UtrustningSort == "Hjälm" || temp[i].UtrustningsTyp == "Hjälm") 
                            {
                                tempTyp = "Hjälm";
                                tempSort = "Hjälm";
                            }
                            hyrpris = FacadeBusiness.FacadeHyrpris.GetUtrustningsHyrpris(tempDagar, tempTyp, tempSort);
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, temp[i].UtrustningSort + " " + temp[i].UtrustningsTyp, 90, a, 0);
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, hyrpris.ToString(), 460, a, 0);

                            a -= 30;

                        }
                        //Hämta pris på utrustning
                        

                        if (temp[i].PaketStatus == true && temp[i].UtrustningSort == "Alpint")
                        {
                            alpinpaketstatus.Add(temp[i].PaketStatus);
                        }
                        if (temp[i].PaketStatus == true && temp[i].UtrustningSort == "Längd")
                        {
                            längdpaketstatus.Add(temp[i].PaketStatus);
                        }
                        if (temp[i].PaketStatus == true && temp[i].UtrustningSort == "Snowboard")
                        {
                            snowboardpaketstatus.Add(temp[i].PaketStatus);
                        }



                       
                    }
                    
                    tempDagar = uthyrning.AntalDagar.ToString();

                    int antalAlpPaket = 0;
                    antalAlpPaket = alpinpaketstatus.Count / 3;
                    int paketsiffra = 1;
                    int antalLängdPaket = 0;
                    antalLängdPaket = längdpaketstatus.Count / 3;
                    int antalSnowboardPaket = 0; 
                    antalSnowboardPaket = snowboardpaketstatus.Count / 2;
                    if (antalAlpPaket > 0)
                    {
                        hyrpris  = FacadeBusiness.FacadeHyrpris.GetUtrustningsHyrpris(tempDagar, "Paket", "Alpint");
                        for (int i = 0; i < antalAlpPaket; i++)
                        {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Paket " + paketsiffra + " Alpint", 90, a, 0);
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, hyrpris.ToString(), 460, a, 0);
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Alpint Skidor", 140, a - 15, 0);
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Alpint Stavar", 140, a - 30, 0);
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Alpint Pjäxor", 140, a - 45, 0);
                            a -= 60;
                            paketsiffra++;
                        }
                    }
                    if (antalLängdPaket > 0)
                    {
                        hyrpris = FacadeBusiness.FacadeHyrpris.GetUtrustningsHyrpris(tempDagar, "Paket", "Längd");
                        for (int i = 0; i < antalLängdPaket; i++)
                        {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Paket " + paketsiffra + " Längd", 90, a, 0);
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, hyrpris.ToString(), 460, a, 0);
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Längd Skidor", 140, a - 15, 0);
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Längd Stavar", 140, a - 30, 0);
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Längd Pjäxor", 140, a - 45, 0);
                            a -= 60;
                            paketsiffra++;
                        }
                    }
                    if (antalSnowboardPaket > 0)
                    {
                        hyrpris = FacadeBusiness.FacadeHyrpris.GetUtrustningsHyrpris(tempDagar, "Paket", "Snowboard");
                        for (int i = 0; i < antalSnowboardPaket; i++)
                        {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Paket " + paketsiffra +  " Snowboard" , 90, a, 0);
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, hyrpris.ToString(), 460, a, 0);
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Snowboard Snowboard", 140, a - 15, 0);
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Snowboard Skor", 140, a - 30, 0);
                            a -= 60;
                            paketsiffra++;
                        }
                    }
                    double uthyrningmoms = faktura.Pris / 1.12;
                    uthyrningmoms = faktura.Pris - uthyrningmoms;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Moms:", 330, a - 70, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, uthyrningmoms.ToString() + " (12%)", 460, a - 70, 0);

                    


            }

                cb.SetFontAndSize(font, 15);
                if (faktura.Typ == "Delfaktura")
                {
                     Faktura delfaktura = FacadeBusiness.FacadeFaktura.SkickaDelFaktura(faktura.Bokning);

                    //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Delfaktura", 120, d, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Belopp", 460, d, 0);
                    d = d - 30;
                    cb.SetFontAndSize(font, 10);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Delfaktura", 120, d, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Faktureringsdatum", 200, d, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Förfallodatum", 310, d, 0);
                  
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, faktura.FaktureringsDatum.ToString("yyyy-MM-dd"), 200, d - 30, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, faktura.FörfalloDatum.Date.ToString("yyyy-MM-dd"), 310, d - 30, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, faktura.Pris.ToString(), 460, d - 30, 0);
                }
                if (faktura.Typ == "Bokning")
            {
                List<Logi> temp = FacadeBusiness.FacadeLogi.LogiPåBokningsID(faktura.Bokning);
                    List<Konferens> konferensT = FacadeBusiness.FacadeKonferens.KonferensPåBokningsID(faktura.Bokning);
               
                    

                        //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Faktura", 120, d, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Belopp", 460, d, 0);
                        d = d - 30;
                        cb.SetFontAndSize(font, 10);

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Faktura del två", 120, d - 30, 0);

                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, faktura.Pris.ToString(), 460, d - 30, 0);
                    


                    if (temp != null)
                    {

                    for (int i = 0; i < temp.Count; i++)
                     {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ID: " + temp[i].LogiID, 90, a, 0);
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, temp[i].LogiTyp, 120, a, 0);
                         cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, temp[i].LogiPris.ToString(), 460, a, 0);
                         a = a - 30;
                      
                    


                    //StartDates.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);'
                        }
                    }
                    if (konferensT != null)
                    {
                        for (int i = 0; i < konferensT.Count; i++)
                        {
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ID: " + konferensT[i].KonferensID, 90, a, 0);
                            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, konferensT[i].KonferensTyp, 120, a, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, konferensT[i].Pris.ToString(), 460, a, 0);
                        a = a - 30;
                     
                        }

                    }
                    if (faktura.Typ == "Bokning" && faktura.Bokning.Avbeställningsskydd == true)
                    {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Avbeställningskydd:", 120, a, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "300Kr", 460, a, 0);
                        a = a - 30;
                    }

                    // skriver ut den faktura som är vald tex skidskolaPrivat
                }
            if (faktura.Typ == "SkidskolaPrivat")
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, faktura.Typ, 120, b, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, faktura.Pris.ToString(), 460, b, 0);
                prisexklmoms = faktura.Pris;


            }
            if (faktura.Typ == "Skidskola")
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, faktura.Typ, 120, b, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, faktura.Pris.ToString(), 460, b, 0);
                prisexklmoms = faktura.Pris;


            }

            if (faktura.Typ == "Konferens")
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, faktura.Typ, 120, b, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, faktura.Pris.ToString(), 460, b, 0);
                prisexklmoms = faktura.Pris;
            }
                prisexklmoms = faktura.Pris;
                prisexklmoms = prisexklmoms * 0.88;

                if (faktura.Typ == "Bokning")
                {
                    double rabattikr = faktura.Bokning.Rabatt;
                    double momsikr = faktura.Bokning.Moms;
                    rabattikr *= 0.8;
                    momsikr *= 0.8;


                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Momssats:", 330, a - 50, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, momsikr.ToString() + " (12%)", 460, a - 50, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rabatt :", 330, a - 70, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, rabattikr.ToString() + " (" + faktura.Privat.Rabatt.ToString() + "%)", 460, a - 70, 0);
                }
                if (faktura.Typ == "Delfaktura")
                {
                    double rabattikr = faktura.Bokning.Rabatt;
                    double momsikr = faktura.Bokning.Moms;
                    rabattikr *= 0.2;
                    momsikr *= 0.2;


                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Momssats:", 330, a-50, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, momsikr.ToString() + " (12%)", 460, a-50, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rabatt :", 330, a-70, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, rabattikr.ToString() + " (" + faktura.Privat.Rabatt.ToString() + "%)", 460, a-70, 0);
                }
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Summa:", 330, a - 90, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, faktura.Pris.ToString(), 460, a - 90, 0);
            cb.SetFontAndSize(font, 10);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Faktureringsdatum: " + faktura.FaktureringsDatum.ToString(), 100, a - 120, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Förfallodatum: " + faktura.FörfalloDatum.ToString(), 100, a - 140, 0);

            cb.SetFontAndSize(font, 10);
            Paragraph pgraph4 = new Paragraph("Footer");
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Kontakta Ski-Center om du har några frågor kring ditt köp", 100, a - 160, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Telefonnummer: 0123-456 789", 100, a - 190, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Hälsningar Ski-Center", 100, a - 200, 0);

            cb.EndText();
            doc.Close();
            }

        }
     
        

        // Metod som skapar bokningsbekräftelse för privatkund 
        public void skapaBokningsBekräftelsePrivat(Bokning Bokning)
        {
            if (Bokning.PrivatKund != null)
            {

            List<Logi> temp = FacadeBusiness.FacadeLogi.LogiPåBokningsID(Bokning);


            double mängdRabatt;
            double totalPris = Bokning.BokningsPris;
            
            
            int a = 120;
            int b = 570;
            int c = 510;
            int d = 570;
            double logibrutto;

            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = ("\\Bokningsbekräftelse" + Bokning.PrivatKund.PrivatFörnamn + " " + Bokning.BokningsID);
            string endpoint = ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 40, 40);

            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(savePath + filename + endpoint, FileMode.Create, FileAccess.ReadWrite));
            doc.Open();
            PdfContentByte cb = wri.DirectContent;
            cb.BeginText();
            BaseFont font = BaseFont.CreateFont("c:\\windows\\fonts\\calibrib.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            Paragraph pgraph1 = new Paragraph("Ski-Center ");
            cb.SetFontAndSize(font, 20);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Ski-Center", 300, 750, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Bokningsbekräftelse", 300, 700, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ID: " + Bokning.PrivatKund.PrivatKundID + " Namn: " + Bokning.PrivatKund.PrivatFörnamn + " " + Bokning.PrivatKund.PrivatEfternamn, 300, 650, 0);


            Paragraph pgraph2 = new Paragraph("Objekt");
            cb.SetFontAndSize(font, 10);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Id", 60, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Objekt", 120, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Ankomst", 250, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Avresa", 380, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Pris", 510, 600, 0);

            for (int i = 0; i < temp.Count; i++)
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, temp[i].LogiID.ToString(), 60, b, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, temp[i].LogiTyp, a, b, 0);
                b = b - 30;
            }

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Bokning.InCheckningsDatum.ToString(), 250, 570, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Bokning.UtCheckningsDatum.ToString(), 380, 570, 0);
            for (int i = 0; i < temp.Count; i++)
            {
                logibrutto = temp[i].LogiPris;
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, logibrutto.ToString(), c, d, 0);
                d = d - 30;
            }

            //if (rabattBool == true)
            //{
            //    mängdRabatt = (brutto * 0.08);
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Rabatt:", 120, d - 30, 0);
            //    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, mängdRabatt.ToString(), 510, d - 30, 0);
            //}
            //else if (rabattBool == false)
            //{
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Rabatt:", 120, d - 30, 0);
                if (Bokning.Rabatt == 0)
                {
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Ingen rabatt", 510, d - 30, 0);
                }
                else if (Bokning.Rabatt > 0)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Bokning.Rabatt.ToString(), 510, d - 30, 0);
                }
                if(Bokning.Avbeställningsskydd == true)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Avbeställningsskydd:", 120, d - 50, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "300kr", 510, d - 50, 0);
                }

                //}


                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Moms:", 120, d - 70, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Bokning.Moms.ToString(), 510, d - 70, 0);

            

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "TotalPris:", 120, d - 90, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Bokning.BokningsPris.ToString(), 510, d - 90, 0);

            Paragraph pgraph3 = new Paragraph("Footer");
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Kontakta Ski-Center om du har några frågor kring ditt köp", 100, d - 120, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Telefonnummer: 0123-456 789", 100, d - 140, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Hälsningar Ski-Center", 100, d - 160, 0);

            cb.EndText();
            doc.Close();

            }
        }
    

        // Metod som skapar bokningsbekräftelse för företagskund 
        public void skapaBokningsBekräftelseFöretag(Bokning Bokning)
        {
            List<Logi> temp = FacadeBusiness.FacadeLogi.LogiPåBokningsID(Bokning);
            List<Konferens> konferens = FacadeBusiness.FacadeKonferens.KonferensPåBokningsID(Bokning);

            int a = 120;
            int b = 570;
            int c = 510;
            int d = 570;

            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = ("\\Bokningsbekräftelse-Företag " + Bokning.FöretagsKund.Företagsnamn + " " + Bokning.BokningsID);
            string endpoint = ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 40, 40);

            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(savePath + filename + endpoint, FileMode.Create));
            doc.Open();
            PdfContentByte cb = wri.DirectContent;
            cb.BeginText();
            BaseFont font = BaseFont.CreateFont("c:\\windows\\fonts\\calibrib.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            Paragraph pgraph1 = new Paragraph("Ski-Center ");

            //VÄNSTER = KOLUMN Y, HÖGER = RAD X. (Y,X)

            cb.SetFontAndSize(font, 20);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Ski-Center", 300, 750, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "KundID: " + Bokning.FöretagsKund.FöretagKundID + " Företagsnamn: " + Bokning.FöretagsKund.Företagsnamn, 300, 700, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Bokningsbekräftelse ID: "+ Bokning.BokningsID, 300, 650, 0);

            Paragraph pgraph2 = new Paragraph("Objekt");
            cb.SetFontAndSize(font, 10);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Objekt", 120, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Ankomst", 250, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Avresa", 380, 600, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Pris", 510, 600, 0);

            if (temp != null)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, temp[i].LogiTyp, a, b, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, temp[i].LogiPris.ToString(), c, b, 0);
                    b = b - 30;
                
                }
            }
            if (konferens != null)
            {
                for (int i = 0; i < konferens.Count; i++)
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, konferens[i].KonferensTyp, a, b, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, konferens[i].Pris.ToString(), c, b, 0);
                    b = b - 30;
                }
            }

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Bokning.InCheckningsDatum.ToString(), 250, 570, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Bokning.UtCheckningsDatum.ToString(), 380, 570, 0);




            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Rabatt:", 120, b - 30, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Bokning.Rabatt.ToString() + " " + "(" + Bokning.FöretagsKund.FöretagRabatt.ToString() + "%)", 510, b - 30, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "Moms:", 120, b - 50, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Bokning.Moms.ToString(), 510, b - 50, 0);

            if (Bokning.Avbeställningsskydd == true)
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "AvbeställningSkydd:", 120, b - 70, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "300", 510, b - 70, 0);
            }

            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "TotalPris:", 120, b - 90, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, Bokning.BokningsPris.ToString(), 510, b - 90, 0);

            Paragraph pgraph3 = new Paragraph("Footer");
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Kontakta Ski-Center om du har några frågor kring ditt köp", 100, b - 120, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Telefonnummer: 0123-456 789", 100, b - 140, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Hälsningar Ski-Center", 100, b - 160, 0);

            cb.EndText();
            doc.Close();
        }

        // Metod som skriver ut pdf faktura för företagskunder 
        public void FakturaUtskriftFöretag(Faktura faktura, FöretagsKund fk)
        {
            int d = 500;
            double Hyrpris = 0;
            string tempSort;
            string tempTyp;
            int b = 340;
            string tempDagar;
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filename = "\\Faktura" + faktura.Företag.Företagsnamn + " " +faktura.FakturaID;
            string endpoint = ".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 40, 40);

            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(savePath + filename + endpoint, FileMode.Create));
            doc.Open();
            PdfContentByte cb = wri.DirectContent;
            cb.BeginText();
            BaseFont font = BaseFont.CreateFont("c:\\windows\\fonts\\calibrib.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            Paragraph pgraph1 = new Paragraph("Ski-Center ");


            //VÄNSTER = KOLUMN Y, HÖGER = RAD X. (Y,X)

            if (faktura.Typ == "Delfaktura") 
            {

            Faktura delfaktura = FacadeBusiness.FacadeFaktura.SkickaDelFaktura(faktura.Bokning);
                cb.SetFontAndSize(font, 15);
                //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Delfaktura", 120, b, 0);
                //cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Belopp", 460, b, 0);
                d = d - 30;

                double _rabattikr = faktura.Bokning.Rabatt;
                double _momsikr = faktura.Bokning.Moms;
                _rabattikr *= 0.2;
                _momsikr *= 0.2;

                cb.SetFontAndSize(font, 10);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Delfaktura", 120, b, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Faktureringsdatum", 200, b, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Förfallodatum", 310, b, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Momssats:", 330, 190, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _momsikr.ToString() + " (12%)", 460, 190, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rabatt :", 330, 210, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, _rabattikr.ToString() + " (" + faktura.Företag.FöretagRabatt.ToString() + "%)", 460,210, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, faktura.FaktureringsDatum.ToString("yyyy-MM-dd"), 200, b - 30, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, faktura.FörfalloDatum.Date.ToString("yyyy-MM-dd"), 310, b - 30, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, faktura.Pris.ToString(), 460, b - 30, 0);
                b = b - 50;
            }

         


            cb.SetFontAndSize(font, 20);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Ski-Center", 120, 700, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Faktura", 120, 675, 0);
            cb.SetFontAndSize(font, 10);
            Paragraph pgraph2 = new Paragraph("Head");
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Skicentergatan 1", 120, 630, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "123 45 , Borås", 120, 610, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "(70) 712-3456", 120, 590, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, DateTime.Now.ToString(), 120, 570, 0);
            Paragraph pgraph3 = new Paragraph("Objekt");
            cb.SetFontAndSize(font, 15);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Faktura till", 120, 530, 0);
            cb.SetFontAndSize(font, 10);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fk.Företagsnamn, 120, 500, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fk.FöretagFaktureringPostnummer, 120, 480, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fk.FöretagFaktureringPostnummer + " " + fk.FöretagFaktureringPostort, 120, 460, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, fk.FöretagTelefonNummer, 120, 440, 0);
            cb.SetFontAndSize(font, 15);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Information", 120, 400, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Belopp", 460, 400, 0);
            cb.SetFontAndSize(font, 10);
            
            // Skriver ut den typ av faktura som man vill ha utskriven "bokning" "konferens"
            if (faktura.Typ == "Bokning")
            {
                List<Logi> temp = FacadeBusiness.FacadeLogi.LogiPåBokningsID(faktura.Bokning);
                List<Konferens> konferensT = FacadeBusiness.FacadeKonferens.KonferensPåBokningsID(faktura.Bokning);
                if (temp != null)
                {

                for (int i = 0; i < temp.Count; i++)
                {
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ID:" + temp[i].LogiID.ToString(), 90, b, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, temp[i].LogiTyp, 120, b, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, temp[i].LogiPris.ToString(), 460, b, 0);
                    b = b - 30;
                    prisexklmoms = prisexklmoms + temp[i].LogiPris;
                }
                }
                
                if (konferensT != null)
                {
                    for (int i = 0; i < konferensT.Count; i++)
                    {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "ID:" + konferensT[i].KonferensID.ToString(), 90, b, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, konferensT[i].KonferensTyp, 120, b, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, konferensT[i].Pris.ToString(), 460, b, 0);
                    b = b - 30;
                    prisexklmoms = prisexklmoms + konferensT[i].Pris;
                    }
                }
            }


            if (faktura.Typ == "Konferens")
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, faktura.Typ, 120, b, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, faktura.Pris.ToString(), 460, b, 0);
                prisexklmoms = faktura.Pris;
                b = b - 30;
            }
            prisexklmoms = faktura.Pris * 0.88;
            prisinklmoms = prisexklmoms * moms;
            double momssats = faktura.Pris * 0.88;
            momssats = momssats*0.12;
            if (faktura.Bokning.Avbeställningsskydd == true)
            {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Avbeställningsskydd:", 120, b , 0);
                if (faktura.Typ == "Bokning")
                {
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Ja", 460, b , 0);
                }
                if (faktura.Typ == "Delfaktura")
                {
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Ja", 460, b, 0);
                }
                b = b - 30;
            }
            if (faktura.Typ == "Bokning")
            {
                double rabattikr = faktura.Bokning.Rabatt;
                double momsikr = faktura.Bokning.Moms;
                rabattikr *= 0.8;
                momsikr *= 0.8;


                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Momssats:", 330, b - 40, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, momsikr.ToString() + " (12%)", 460, b - 40, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Rabatt :", 330, b - 60, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, rabattikr.ToString() + " (" + faktura.Företag.FöretagRabatt.ToString() + "%)", 460, b - 60, 0);
            }
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Summa:", 330, b - 80, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, faktura.Pris.ToString(), 460, b - 80, 0);
            cb.SetFontAndSize(font, 10);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Faktureringsdatum: " + faktura.FaktureringsDatum.ToString(), 100, b - 100, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Förfallodatum: " + faktura.FörfalloDatum.ToString(), 100, b - 120, 0);

            cb.SetFontAndSize(font, 10);
            Paragraph pgraph4 = new Paragraph("Footer");
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Kontakta Ski-Center om du har några frågor kring ditt köp", 100, b - 150, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Telefonnummer: 0123-456 789", 100, b - 160, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "Hälsningar Ski-Center", 100, b - 170, 0);

            cb.EndText();
            doc.Close();

        }
    }

}
