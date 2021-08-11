using BusinessEntities_FrameWork.Models;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

/*
 * Denna klassen kopplar "koden"/klasserna DbSet till Databasen.
 * Dessa klasser representerar tabellerna
 */

namespace DataLayer_FrameWork.Context
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<SysAdmin> SysAdmin { get; set; }
        public virtual DbSet<SkidLektion> SkidLektion { get; set; }
        public virtual DbSet<Anställd> Anställd { get; set; }
        public virtual DbSet<Bokning> Bokning { get; set; }
        public virtual DbSet<Deltagare> Deltagare { get; set; }
        public virtual DbSet<Faktura> Faktura { get; set; }
        public virtual DbSet<FöretagsKund> FöretagsKund { get; set; }
        public virtual DbSet<Hyrpris> Hyrpris { get; set; }
        public virtual DbSet<Konferens> Konferens { get; set; }
        public virtual DbSet<Logi> Logi { get; set; }
        public virtual DbSet<MarknadsChef> MarknadsChef { get; set; }
        public virtual DbSet<PrivatKund> PrivatKund { get; set; }
        public virtual DbSet<TempKund> TempKund { get; set; }
        public virtual DbSet<Uthyrning> Uthyrning { get; set; }
        public virtual DbSet<Utrustning> Utrustning { get; set; }
        public virtual DbSet<LogiPris> LogiPris { get; set; }
        public virtual DbSet<PreBokning> PreBokning { get; set; }
        public virtual DbSet<Gruppskidlektion> Gruppskidlektion { get; set; }
        public virtual DbSet<KonferensPris> KonferensPris { get; set; }

        /*
         * Denna metoden ser till att rätt datumtyp används i databasen
         */
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Properties<DateTime>()
            .Configure(c => c.HasColumnType("datetime2"));
        }

        // Constructor
        public DatabaseContext() : base("name=Ski-Center")
        {

        }

        /// <summary>
        /// Droppar alla tabeller i databasen. sedan kallar den på seed-funktioner
        /// för de olika standardvärdena, samt testdata.
        /// </summary>
        public void Reset()
        {
            #region Remove Tables

            //string connectionString = Database.Connection.ConnectionString;
            string connectionString = "Data Source=sqlutb2-db.hb.se,56077; Database=suht2009; User ID=suht2009; Password=blax77; Initial Catalog=suht2009; Persist Security Info=True;";
            string commandText = "EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'; EXEC sp_msforeachtable 'DROP TABLE ?'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                conn.Open();
                for (int i = 0; i < 25; i++)
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Exception)
                    {
                        // throw;
                    }
                }

                conn.Close();
            }
            #endregion

            Database.Initialize(true);
            Seed();
            SeedLogipriser();
            SeedTest();
            SeedUtrustning();
            SeedLogi();
            SeedKonferensPris();
            SeedUthyrning();
            AddGroupLessons();
            AddCamping();
            SaveChanges();
        }

        private void AddCamping()
        {
            for (int i = 0; i < 125; i++)
            {
                Logi.Add(new Logi
                {
                    LogiTyp = "Camping",
                    Tillgänglighet = true
                });
            }
        }

        private void AddGroupLessons()
        {
            string[] color = { "Grön", "Blå", "Röd", "Svart" };
            int[] days = {3, 5};

            // Create lessons for 3 days
            for (int i = 0; i < color.Length; i++)
            {
                Gruppskidlektion.Add(new Gruppskidlektion()
                {
                    Färg = color[i],
                    AntalDagar = days[0],
                    Status = false
                });
            }

            // Create Lessons for 5 days
            for (int i = 0; i < color.Length; i++)
            {
                Gruppskidlektion.Add(new Gruppskidlektion()
                {
                    Färg = color[i],
                    AntalDagar = days[1],
                    Status = false
                });
            }
        }

        private void SeedTest()
        {
            Bokning.Add(new Bokning()
            {
                InCheckningsDatum = DateTime.Now,
                UtCheckningsDatum = DateTime.Today,
                BokningsTyp = "Test bokning",
                BokningsPris = 30000,
                Moms = 0.2,
                Bruttopris = 30000,
                Nettopris = 30000,
                Status = false

            });

            Faktura.Add(new Faktura()
            {
                Pris = 3000,
                FaktureringsDatum = DateTime.Now,
                FörfalloDatum = DateTime.Today,
                Typ = "Logi",
                Status = false,

            });

            PrivatKund.Add(new PrivatKund()
            {
                PrivatFörnamn = "Erik",
                PrivatEfternamn = "Rosvall",
                PrivatEpostadress = "coconut@chicken.com",
                PrivatGatuadress = "månen 33",
                PrivatPostnummer = "666",
                PrivatPostort = "Mars",
                PrivatTelefonnummer = "666-6666666",
                Rabatt = 8
            });

            MarknadsChef.Add(new MarknadsChef()
            {
                AnvändarNamn = "chef",
                Lösenord = "chef",
                AnställdFörnamn = "klara",
                AnställdEfternamn = "klara",
                AnställningsTyp = "Marknadschef",
                Behörighet = "Marknadschef"
            });
            //SaveChanges();
        }

        private void Seed()
        {
            Bokning.Add(new Bokning()
            {
                InCheckningsDatum = DateTime.Now,
                UtCheckningsDatum = DateTime.Today,
                BokningsTyp = "Test bokning",
                BokningsPris = 30000,
                Moms = 0.2,
                Bruttopris = 30000,
                Nettopris = 30000,
                Status = false


            });
            SkidLektion.Add(new SkidLektion()
            {
                TypAvLektion = "Privat",
                Pris = 375,
                Dagar = 1,
                Tid = 1,
            });
            SkidLektion.Add(new SkidLektion()
            {
                TypAvLektion = "Röd",
                Pris = 425,
                Dagar = 3,
            });
            SkidLektion.Add(new SkidLektion()
            {
                TypAvLektion = "Röd",
                Pris = 525,
                Dagar = 5,
            });
            SkidLektion.Add(new SkidLektion()
            {
                TypAvLektion = "Blå",
                Pris = 415,
                Dagar = 3,
            });
            SkidLektion.Add(new SkidLektion()
            {
                TypAvLektion = "Blå",
                Pris = 515,
                Dagar = 5,
            });
            SkidLektion.Add(new SkidLektion()
            {
                TypAvLektion = "Grön",
                Pris = 400,
                Dagar = 3,
            });
            SkidLektion.Add(new SkidLektion()
            {
                TypAvLektion = "Grön",
                Pris = 500,
                Dagar = 5,
            });
            SkidLektion.Add(new SkidLektion()
            {
                TypAvLektion = "Svart",
                Pris = 455,
                Dagar = 3,
            });
            SkidLektion.Add(new SkidLektion()
            {
                TypAvLektion = "Svart",
                Pris = 555,
                Dagar = 5,
            });

            PrivatKund.Add(new PrivatKund()
            {
                PrivatFörnamn = "Jonas",
                PrivatEfternamn = "Grensson",
                PrivatEpostadress = "coconut@chicken.com",
                PrivatGatuadress = "månen 33",
                PrivatPostnummer = "666",
                PrivatPostort = "Mars",
                PrivatTelefonnummer = "666-6666666",
                Rabatt = 8
            });

            SysAdmin.Add(new SysAdmin()
            {
                AnvändarNamn = "admin",
                Lösenord = "admin",
                SysAdminFörnamn = "snubbe",
                SysAdminEfternamn = "cool",
                AnställningsTyp = "Systemadmin",
                Behörighet = "Sysadmin"
            });



            Anställd.Add(new Anställd()
            {
                AnvändarNamn = "jacob",
                Lösenord = "jacob",
                AnställdFörnamn = "Jacob",
                AnställdEfternamn = "Andersson",
                AnställningsTyp = "Reception",
                Behörighet = "Reception"
            });
            Anställd.Add(new Anställd()
            {
                AnvändarNamn = "Tommy",
                Lösenord = "tommy",
                AnställdFörnamn = "Tommy",
                AnställdEfternamn = "Ph",
                AnställningsTyp = "Butik",
                Behörighet = "Butik"
            });

            Anställd.Add(new Anställd()
            {
                AnvändarNamn = "admin",
                Lösenord = "admin",
                AnställdFörnamn = "Fredrik",
                AnställdEfternamn = "Fredrik",
                AnställningsTyp = "Skidskola",
                Behörighet = "Skidskola"
            });

            FöretagsKund.Add(new FöretagsKund()
            {
                Företagsnamn = "Volvo",
                OrgNummer = "12345789",
                FöretagRabatt = 15,
                RefPerson = "Jonas",
                FöretagTelefonNummer = "0708443266",
                FöretagEpostadress = "mail@mail.com",
                Gatuadress = "volvogatan",
                FöretagPostnummer = "42342",
                FöretagPostort = "Göteborg",
                Faktureringsadress = "volvogatan 12",
                FöretagFaktureringPostnummer = "42342",
                FöretagFaktureringPostort = "Göteborg",
                Kreditgräns = 12000
            });

            Anställd.Add(new Anställd()
            {
                AnvändarNamn = "emmy",
                Lösenord = "emmy",
                AnställdFörnamn = "emmy",
                AnställdEfternamn = "emmy",
                AnställningsTyp = "Skidlärare",
                Behörighet = "Skidlärare"
            });



            Gruppskidlektion.Add(new Gruppskidlektion()
            {
                Färg = "Röd",
                Antaldeltagare = 6,
                Lärare = "Emmy",
            });

            SaveChanges();
        }

        private void SeedUthyrning()
        {
           

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Paket",
                AntalDagar = 1,
                Pris = 180,

            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Paket",
                AntalDagar = 2,
                Pris = 305,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Paket",
                AntalDagar = 3,
                Pris = 405,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Paket",
                AntalDagar = 4,
                Pris = 495,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Paket",
                AntalDagar = 5,
                Pris = 560,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Paket",
                AntalDagar = 6,
                Pris = 560,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Paket",
                AntalDagar = 7,
                Pris = 560,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Skidor",
                AntalDagar = 1,
                Pris = 130,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Skidor",
                AntalDagar = 2,
                Pris = 230,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Skidor",
                AntalDagar = 3,
                Pris = 330,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Skidor",
                AntalDagar = 4,
                Pris = 395,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Skidor",
                AntalDagar = 5,
                Pris = 445,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Skidor",
                AntalDagar = 6,
                Pris = 445,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Skidor",
                AntalDagar = 7,
                Pris = 445,
            });


            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Pjäxor",
                AntalDagar = 1,
                Pris = 115,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Pjäxor",
                AntalDagar = 2,
                Pris = 195,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Pjäxor",
                AntalDagar = 3,
                Pris = 255,
            });



            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Pjäxor",
                AntalDagar = 4,
                Pris = 315,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Pjäxor",
                AntalDagar = 5,
                Pris = 375,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Pjäxor",
                AntalDagar = 6,
                Pris = 375,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Pjäxor",
                AntalDagar = 7,
                Pris = 375,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Stavar",
                AntalDagar = 1,
                Pris = 40,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Stavar",
                AntalDagar = 2,
                Pris = 50,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Stavar",
                AntalDagar = 3,
                Pris = 60,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Stavar",
                AntalDagar = 4,
                Pris = 70,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Stavar",
                AntalDagar = 5,
                Pris = 80,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Stavar",
                AntalDagar = 6,
                Pris = 80,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Alpint",
                UtrustningsTyp = "Stavar",
                AntalDagar = 7,
                Pris = 80,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Paket",
                AntalDagar = 1,
                Pris = 130,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Paket",
                AntalDagar = 2,
                Pris = 230,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Paket",
                AntalDagar = 3,
                Pris = 320,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Paket",
                AntalDagar = 4,
                Pris = 390,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Paket",
                AntalDagar = 5,
                Pris = 440,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Paket",
                AntalDagar = 6,
                Pris = 440,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Paket",
                AntalDagar = 7,
                Pris = 440,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Skidor",
                AntalDagar = 1,
                Pris = 100,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Skidor",
                AntalDagar = 2,
                Pris = 170,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Skidor",
                AntalDagar = 3,
                Pris = 220,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Skidor",
                AntalDagar = 4,
                Pris = 270,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Skidor",
                AntalDagar = 5,
                Pris = 320,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Skidor",
                AntalDagar = 6,
                Pris = 320,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Skidor",
                AntalDagar = 7,
                Pris = 320,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Pjäxor",
                AntalDagar = 1,
                Pris = 80,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Pjäxor",
                AntalDagar = 2,
                Pris = 120,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Pjäxor",
                AntalDagar = 3,
                Pris = 150,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Pjäxor",
                AntalDagar = 4,
                Pris = 170,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Pjäxor",
                AntalDagar = 5,
                Pris = 200,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Pjäxor",
                AntalDagar = 6,
                Pris = 200,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Pjäxor",
                AntalDagar = 7,
                Pris = 200,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Stavar",
                AntalDagar = 1,
                Pris = 40,
            });

            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Stavar",
                AntalDagar = 2,
                Pris = 50,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Stavar",
                AntalDagar = 3,
                Pris = 60,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Stavar",
                AntalDagar = 4,
                Pris = 70,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Stavar",
                AntalDagar = 5,
                Pris = 80,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Stavar",
                AntalDagar = 6,
                Pris = 80
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Längd",
                UtrustningsTyp = "Stavar",
                AntalDagar = 7,
                Pris = 80
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Snowboard",
                UtrustningsTyp = "Paket",
                AntalDagar = 1,
                Pris = 250,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Snowboard",
                UtrustningsTyp = "Paket",
                AntalDagar = 2,
                Pris = 415,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Snowboard",
                UtrustningsTyp = "Paket",
                AntalDagar = 3,
                Pris = 540,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Snowboard",
                UtrustningsTyp = "Paket",
                AntalDagar = 4,
                Pris = 655,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Snowboard",
                UtrustningsTyp = "Paket",
                AntalDagar = 5,
                Pris = 750,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Snowboard",
                UtrustningsTyp = "Paket",
                AntalDagar = 6,
                Pris = 750,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Snowboard",
                UtrustningsTyp = "Paket",
                AntalDagar = 7,
                Pris = 750,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Snowboard",
                UtrustningsTyp = "Snowboard",
                AntalDagar = 1,
                Pris = 190,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Snowboard",
                UtrustningsTyp = "Snowboard",
                AntalDagar = 2,
                Pris = 335,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Snowboard",
                UtrustningsTyp = "Snowboard",
                AntalDagar = 3,
                Pris = 455,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Snowboard",
                UtrustningsTyp = "Snowboard",
                AntalDagar = 4,
                Pris = 555,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Snowboard",
                UtrustningsTyp = "Snowboard",
                AntalDagar = 5,
                Pris = 625,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Snowboard",
                UtrustningsTyp = "Snowboard",
                AntalDagar = 6,
                Pris = 625,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Snowboard",
                UtrustningsTyp = "Snowboard",
                AntalDagar = 7,
                Pris = 625,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Skor",
                UtrustningsTyp = "Skor",
                AntalDagar = 1,
                Pris = 115,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Skor",
                UtrustningsTyp = "Skor",
                AntalDagar = 2,
                Pris = 195,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Skor",
                UtrustningsTyp = "Skor",
                AntalDagar = 3,
                Pris = 275,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Skor",
                UtrustningsTyp = "Skor",
                AntalDagar = 4,
                Pris = 350,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Skor",
                UtrustningsTyp = "Skor",
                AntalDagar = 5,
                Pris = 395,
            }); Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Skor",
                UtrustningsTyp = "Skor",
                AntalDagar = 6,
                Pris = 395,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Skor",
                UtrustningsTyp = "Skor",
                AntalDagar = 7,
                Pris = 395,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Hjälm",
                UtrustningsTyp = "Hjälm",
                AntalDagar = 1,
                Pris = 40,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Hjälm",
                UtrustningsTyp = "Hjälm",
                AntalDagar = 2,
                Pris = 50,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Hjälm",
                UtrustningsTyp = "Hjälm",
                AntalDagar = 2,
                Pris = 60,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Hjälm",
                UtrustningsTyp = "Hjälm",
                AntalDagar = 3,
                Pris = 70,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Hjälm",
                UtrustningsTyp = "Hjälm",
                AntalDagar = 4,
                Pris = 80,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Hjälm",
                UtrustningsTyp = "Hjälm",
                AntalDagar = 5,
                Pris = 90,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Hjälm",
                UtrustningsTyp = "Hjälm",
                AntalDagar = 6,
                Pris = 90,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningSort = "Hjälm",
                UtrustningsTyp = "Hjälm",
                AntalDagar = 7,
                Pris = 90,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningsTyp = "Skoter",
                UtrustningSort = "Lynx 50",
                AntalDagar = 1,
                Pris = 1000,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningsTyp = "Skoter",
                UtrustningSort = "Lynx 50",
                AntalDagar = 3,
                Pris = 2750,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningsTyp = "Skoter",
                UtrustningSort = "Lynx 50",
                AntalDagar = 5,
                Pris = 5950,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningsTyp = "Skoter",
                UtrustningSort = "Lynx 50",
                AntalDagar = 6,
                Pris = 5950,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningsTyp = "Skoter",
                UtrustningSort = "Lynx 50",
                AntalDagar = 7,
                Pris = 5950,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningsTyp = "Skoter",
                UtrustningSort = "Yamaha Viking",
                AntalDagar = 1,
                Pris = 1300,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningsTyp = "Skoter",
                UtrustningSort = "Yamaha Viking",
                AntalDagar = 3,
                Pris = 3700,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningsTyp = "Skoter",
                UtrustningSort = "Yamaha Viking",
                AntalDagar = 5,
                Pris = 7250,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningsTyp = "Skoter",
                UtrustningSort = "Yamaha Viking",
                AntalDagar = 6,
                Pris = 7250,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningsTyp = "Skoter",
                UtrustningSort = "Yamaha Viking",
                AntalDagar = 7,
                Pris = 7250,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningsTyp = "Skoter",
                UtrustningSort = "Nilapulka",
                AntalDagar = 1,
                Pris = 240,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningsTyp = "Skoter",
                UtrustningSort = "Nilapulka",
                AntalDagar = 3,
                Pris = 640,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningsTyp = "Skoter",
                UtrustningSort = "Nilapulka",
                AntalDagar = 5,
                Pris = 1280,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningsTyp = "Skoter",
                UtrustningSort = "Nilapulka",
                AntalDagar = 6,
                Pris = 1280,
            });
            Hyrpris.Add(new Hyrpris()
            {
                UtrustningsTyp = "Skoter",
                UtrustningSort = "Nilapulka",
                AntalDagar = 7,
                Pris = 1280,
            });




            //SaveChanges();
        }
        private void SeedLogipriser()

        {
            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 51,

                Dagar = 7,

                Pris = 1695

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 52,

                Dagar = 7,

                Pris = 1695

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 1,

                Dagar = 7,

                Pris = 2895

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 2,

                Dagar = 7,

                Pris = 1695

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 3,

                Dagar = 7,

                Pris = 1695

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 4,

                Dagar = 7,

                Pris = 1695

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 5,

                Dagar = 7,

                Pris = 1895

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 6,

                Dagar = 7,

                Pris = 1895

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 7,

                Dagar = 7,

                Pris = 3895

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 8,

                Dagar = 7,

                Pris = 3895

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 9,

                Dagar = 7,

                Pris = 2895

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 10,

                Dagar = 7,

                Pris = 2095

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 11,

                Dagar = 7,

                Pris = 2095

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 12,

                Dagar = 7,

                Pris = 2095

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 13,

                Dagar = 7,

                Pris = 2895

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 14,

                Dagar = 7,

                Pris = 1695

            });
            for (int i = 15; i < 23; i++)
            {
                LogiPris.Add(new LogiPris()

                {

                    LogiTyp = "Liten",

                    Vecka = i,

                    Dagar = 7,

                    Pris = 1695

                });

            }

            for (int i = 23; i < 51; i++)
            {
                LogiPris.Add(new LogiPris()

                {

                    LogiTyp = "Liten",

                    Vecka = i,

                    Dagar = 7,

                    Pris = 1300

                });
            }
            


            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 51,

                Dagar = 5,

                Pris = 240

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 52,

                Dagar = 5,

                Pris = 240

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 1,

                Dagar = 5,

                Pris = 415

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 2,

                Dagar = 5,

                Pris = 240

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 3,

                Dagar = 5,

                Pris = 240

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 4,

                Dagar = 5,

                Pris = 240

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 5,

                Dagar = 5,

                Pris = 270

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 6,

                Dagar = 5,

                Pris = 270

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 6,

                Dagar = 5,

                Pris = 270

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 7,

                Dagar = 5,

                Pris = 270

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 9,

                Dagar = 5,

                Pris = 415

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 10,

                Dagar = 5,

                Pris = 300

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 11,

                Dagar = 5,

                Pris = 300

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 12,

                Dagar = 5,

                Pris = 300

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 13,

                Dagar = 5,

                Pris = 415

            });

            for (int i = 14; i < 23; i++)
            {
                LogiPris.Add(new LogiPris()

                {

                    LogiTyp = "Liten",

                    Vecka = i,

                    Dagar = 5,

                    Pris = 240

                });
            }

            // Vecka 14-22 pris = 200kr 
            for (int i = 23; i < 51; i++)
            {


                LogiPris.Add(new LogiPris()

                {

                    LogiTyp = "Liten",

                    Vecka = i,

                    Dagar = 5,

                    Pris = 200

                });
            }


            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 51,

                Dagar = 2,

                Pris = 370

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 52,

                Dagar = 2,

                Pris = 370

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 1,

                Dagar = 2,

                Pris = 725

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 2,

                Dagar = 2,

                Pris = 370

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 3,

                Dagar = 2,

                Pris = 370

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 4,

                Dagar = 2,

                Pris = 370

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 5,

                Dagar = 2,

                Pris = 410

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 6,

                Dagar = 2,

                Pris = 410

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 9,

                Dagar = 2,

                Pris = 725

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 10,

                Dagar = 2,

                Pris = 455

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 11,

                Dagar = 2,

                Pris = 455

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 12,

                Dagar = 2,

                Pris = 455

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Liten",

                Vecka = 13,

                Dagar = 2,

                Pris = 725

            });

            for (int i = 14; i < 23; i++)
            {
                LogiPris.Add(new LogiPris()

                {

                    LogiTyp = "Liten",

                    Vecka = i,

                    Dagar = 2,

                    Pris = 370

                });
            }



            for (int i = 23; i < 51; i++)
            {
                LogiPris.Add(new LogiPris()

                {

                    LogiTyp = "Liten",

                    Vecka = i,

                    Dagar = 2,

                    Pris = 200

                });
            }

            


            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 51,

                Dagar = 7,

                Pris = 2295

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 52,

                Dagar = 7,

                Pris = 2295

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 1,

                Dagar = 7,

                Pris = 3895

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 2,

                Dagar = 7,

                Pris = 2295

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 3,

                Dagar = 7,

                Pris = 2295

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 4,

                Dagar = 7,

                Pris = 2295

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 5,

                Dagar = 7,

                Pris = 2595

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 6,

                Dagar = 7,

                Pris = 2595

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 7,

                Dagar = 7,

                Pris = 4995

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 8,

                Dagar = 7,

                Pris = 3895

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 9,

                Dagar = 7,

                Pris = 2895

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 10,

                Dagar = 7,

                Pris = 2095

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 11,

                Dagar = 7,

                Pris = 2095

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 12,

                Dagar = 7,

                Pris = 2095

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 13,

                Dagar = 7,

                Pris = 2895

            });

            for (int i = 14; i < 23; i++)
            {
                LogiPris.Add(new LogiPris()

                {

                    LogiTyp = "Stor",

                    Vecka = i,

                    Dagar = 7,

                    Pris = 1695

                });
            }



            for (int i = 23; i < 50; i++)
            {
                LogiPris.Add(new LogiPris()

                {

                    LogiTyp = "Stor",

                    Vecka = 23,

                    Dagar = 7,

                    Pris = 1300

                });
            }

            // Vecka 23 - 50 pris = 1300 

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 51,

                Dagar = 5,

                Pris = 330

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 52,

                Dagar = 5,

                Pris = 330

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 1,

                Dagar = 5,

                Pris = 555

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 2,

                Dagar = 5,

                Pris = 330

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 3,

                Dagar = 5,

                Pris = 330

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 4,

                Dagar = 5,

                Pris = 330

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 5,

                Dagar = 5,

                Pris = 370

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 6,

                Dagar = 5,

                Pris = 370

            });

           

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 9,

                Dagar = 5,

                Pris = 415

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 10,

                Dagar = 5,

                Pris = 300

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 11,

                Dagar = 5,

                Pris = 300

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 12,

                Dagar = 5,

                Pris = 300

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 13,

                Dagar = 5,

                Pris = 415

            });
            for (int i = 14; i < 23; i++)
            {

                LogiPris.Add(new LogiPris()

                {

                    LogiTyp = "Stor",

                    Vecka = i,

                    Dagar = 5,

                    Pris = 240

                });
            }

            for (int i = 23; i < 51; i++)
            {
                LogiPris.Add(new LogiPris()

                {

                    LogiTyp = "Stor",

                    Vecka = i,

                    Dagar = 5,

                    Pris = 200

                });
            }

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 51,

                Dagar = 2,

                Pris = 495

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 52,

                Dagar = 2,

                Pris = 495

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 1,

                Dagar = 2,

                Pris = 975

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 2,

                Dagar = 2,

                Pris = 495

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 3,

                Dagar = 2,

                Pris = 495

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 4,

                Dagar = 2,

                Pris = 495

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 5,

                Dagar = 2,

                Pris = 565

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 6,

                Dagar = 2,

                Pris = 565

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 9,

                Dagar = 2,

                Pris = 975

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 10,

                Dagar = 2,

                Pris = 670

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 11,

                Dagar = 2,

                Pris = 670

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 12,

                Dagar = 2,

                Pris = 670

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Stor",

                Vecka = 13,

                Dagar = 2,

                Pris = 975

            });

            for (int i = 14; i < 23; i++)
            {
                LogiPris.Add(new LogiPris()

                {

                    LogiTyp = "Stor",

                    Vecka = i,

                    Dagar = 2,

                    Pris = 495

                });
            }

            //Vecka 14-22 pris = 370 

            for (int i = 23; i < 51; i++)
            {
                LogiPris.Add(new LogiPris()

                {

                    LogiTyp = "Stor",

                    Vecka = i,

                    Dagar = 2,

                    Pris = 230

                });
            }

            //Vecka 23-50 pris = 200 

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 51,

                Dagar = 7,

                Pris = 815

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 52,

                Dagar = 7,

                Pris = 815

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 1,

                Dagar = 7,

                Pris = 1120

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 2,

                Dagar = 7,

                Pris = 815

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 3,

                Dagar = 7,

                Pris = 815

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 4,

                Dagar = 7,

                Pris = 815

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 5,

                Dagar = 7,

                Pris = 970

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 6,

                Dagar = 7,

                Pris = 970

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 7,

                Dagar = 7,

                Pris = 1120

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 8,

                Dagar = 7,

                Pris = 1120

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 9,

                Dagar = 7,

                Pris = 815

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 10,

                Dagar = 7,

                Pris = 815

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 11,

                Dagar = 7,

                Pris = 815

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 12,

                Dagar = 7,

                Pris = 815

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 13,

                Dagar = 7,

                Pris = 815

            });

            for (int i = 14; i < 23; i++)
            {
                LogiPris.Add(new LogiPris()

                {

                    LogiTyp = "Camping",

                    Vecka = i,

                    Dagar = 7,

                    Pris = 815

                });
            }

            //Vecka 14-22 pris = 815 

            for (int i = 23; i < 51; i++)
            {
                LogiPris.Add(new LogiPris()

                {

                    LogiTyp = "Camping",

                    Vecka = i,

                    Dagar = 7,

                    Pris = 815

                });
            }

            //Vecka 23-50 pris = 815 

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 51,

                Dagar = 1,

                Pris = 130

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 52,

                Dagar = 1,

                Pris = 130

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 1,

                Dagar = 1,

                Pris = 170

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 2,

                Dagar = 1,

                Pris = 130

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 3,

                Dagar = 1,

                Pris = 130

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 4,

                Dagar = 1,

                Pris = 130

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 5,

                Dagar = 1,

                Pris = 150

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 6,

                Dagar = 1,

                Pris = 150

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 7,

                Dagar = 1,

                Pris = 150

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 7,

                Dagar = 1,

                Pris = 170

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 8,

                Dagar = 1,

                Pris = 170

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 9,

                Dagar = 1,

                Pris = 130

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 10,

                Dagar = 1,

                Pris = 130

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 11,

                Dagar = 1,

                Pris = 130

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 12,

                Dagar = 1,

                Pris = 130

            });

            LogiPris.Add(new LogiPris()

            {

                LogiTyp = "Camping",

                Vecka = 13,

                Dagar = 1,

                Pris = 130

            });

            for (int i = 14; i < 23; i++)
            {
                LogiPris.Add(new LogiPris()

                {

                    LogiTyp = "Camping",

                    Vecka = i,

                    Dagar = 1,

                    Pris = 130

                });
            }

            

            for (int i = 23; i < 51; i++)
            {
                LogiPris.Add(new LogiPris()

                {

                    LogiTyp = "Camping",

                    Vecka = i,

                    Dagar = 1,

                    Pris = 130

                });
            }

            //Vecka 23-50 pris = 130 



            SaveChanges();

        }




        private void SeedUtrustning()
        {
            for (int i = 0; i < 349; i++)
            {
                Utrustning.Add(new Utrustning()
                {
                    UtrustningsTyp = "Skidor",
                    UtrustningSort = "Alpint",
                    Tillgänglig = true,

                });
            }
            for (int i = 0; i < 200; i++) 
            {
                Utrustning.Add(new Utrustning()
                {
                    UtrustningsTyp = "Hjälm",
                    UtrustningSort = "Alpint",
                    Tillgänglig = true,
                }) ;
            }
            for (int i = 0; i < 149; i++)
            {
                Utrustning.Add(new Utrustning()
                {
                    UtrustningsTyp = "Skidor",
                    UtrustningSort = "Längd",
                    Tillgänglig = true,

                });
            }

            for (int i = 0; i < 499; i++)
            {
                Utrustning.Add(new Utrustning()
                {
                    UtrustningsTyp = "Pjäxor",
                    UtrustningSort = "Alpint",
                    Tillgänglig = true,

                });
            }
            for (int i = 0; i < 199; i++)
            {
                Utrustning.Add(new Utrustning()
                {
                    UtrustningsTyp = "Pjäxor",
                    UtrustningSort = "Längd",
                    Tillgänglig = true,

                });
            }

            for (int i = 0; i < 84; i++)
            {
                Utrustning.Add(new Utrustning()
                {
                    UtrustningsTyp = "Snowboard",
                    UtrustningSort = "Snowboard",
                    Tillgänglig = true,

                });
            }
            for (int i = 0; i < 90; i++)
            {
                Utrustning.Add(new Utrustning()
                {

                    UtrustningsTyp = "Skor",
                    UtrustningSort = "Skor",
                    Tillgänglig = true,

                });
            }
            for (int i = 0; i < 224; i++)
            {
                Utrustning.Add(new Utrustning()
                {

                    UtrustningsTyp = "Stavar",
                    UtrustningSort = "Alpint",
                    Tillgänglig = true,

                });
            }
            for (int i = 0; i < 220; i++)
            {
                Utrustning.Add(new Utrustning()
                {

                    UtrustningsTyp = "Stavar",
                    UtrustningSort = "Längd",
                    Tillgänglig = true,

                });
            }
            for (int i = 0; i < 4; i++)
            {
                Utrustning.Add(new Utrustning()
                {

                    UtrustningSort = "Lynx 50",
                    UtrustningsTyp = "Skoter",
                    Tillgänglig = true,

                });
            }
            for (int i = 0; i < 2; i++)
            {
                Utrustning.Add(new Utrustning()
                {

                    UtrustningSort = "Yamaha Viking",
                    UtrustningsTyp = "Skoter",
                    Tillgänglig = true,

                });
            }
            for (int i = 0; i < 6; i++)
            {
                Utrustning.Add(new Utrustning()
                {

                    UtrustningSort = "Nilapulka",
                    UtrustningsTyp = "Skoter",
                    Tillgänglig = true,

                });
            }

            //SaveChanges();

        }

        private void SeedLogi()
        {

            for (int i = 0; i < 35; i++)
            {
                Logi.Add(new Logi()
                {
                    LogiTyp = "Stor",
                    Tillgänglighet = true,

                });
            }
            for (int b = 0; b < 50; b++)
            {
                Logi.Add(new Logi()
                {
                    LogiTyp = "Liten",
                    Tillgänglighet = true,
                });
            }
            for (int b = 0; b < 3; b++)
            {
                Konferens.Add(new Konferens()
                {
                    KonferensTyp = "KonferensStor",
                    Tillgänglig = true,
                });
            }
            for (int b = 0; b < 5; b++)
            {
                Konferens.Add(new Konferens()
                {
                    KonferensTyp = "KonferensLiten",
                    Tillgänglig = true,
                });
            }


            SaveChanges();



        }




        private void SeedKonferensPris()
        {
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 51,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 52,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 1,
                TidTyp = "Vecka",
                Pris = 7500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 2,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 3,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 4,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 5,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 6,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 7,
                TidTyp = "Vecka",
                Pris = 7500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 8,
                TidTyp = "Vecka",
                Pris = 7500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 9,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 10,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 11,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 12,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 13,
                TidTyp = "Vecka",
                Pris = 7500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 14,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 15,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 16,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 17,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 18,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 19,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 20,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 21,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 22,
                TidTyp = "Vecka",
                Pris = 4500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 23,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 24,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 25,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 26,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 27,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 28,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 29,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 30,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 31,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 32,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 33,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 34,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 35,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 36,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 37,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 38,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 39,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 40,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 41,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 42,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 43,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 44,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 45,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 46,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 47,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 48,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 49,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 50,
                TidTyp = "Vecka",
                Pris = 3500,

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 51,
                TidTyp = "Dygn",
                Pris = 1200

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 52,
                TidTyp = "Dygn",
                Pris = 1200

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 1,
                TidTyp = "Dygn",
                Pris = 1500

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 2,
                TidTyp = "Dygn",
                Pris = 1200

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 3,
                TidTyp = "Dygn",
                Pris = 1200

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 4,
                TidTyp = "Dygn",
                Pris = 1200

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 5,
                TidTyp = "Dygn",
                Pris = 1200

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 6,
                TidTyp = "Dygn",
                Pris = 1200

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 7,
                TidTyp = "Dygn",
                Pris = 1500

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 8,
                TidTyp = "Dygn",
                Pris = 1500

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 9,
                TidTyp = "Dygn",
                Pris = 1200

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 10,
                TidTyp = "Dygn",
                Pris = 1200

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 11,
                TidTyp = "Dygn",
                Pris = 1200

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 12,
                TidTyp = "Dygn",
                Pris = 1200

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 13,
                TidTyp = "Dygn",
                Pris = 1500

            });

            for (int i = 14; i < 23; i++)
            {
                KonferensPris.Add(new KonferensPris()
                {
                    KonferensTyp = "KonferensStor",
                    Vecka = i,
                    TidTyp = "Dygn",
                    Pris = 1200

                });
            }
            for (int i = 23; i < 50; i++)
            {
                KonferensPris.Add(new KonferensPris()
                {
                    KonferensTyp = "KonferensStor",
                    Vecka = i,
                    TidTyp = "Dygn",
                    Pris = 800


                });

            }
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 51,
                TidTyp = "Tim",
                Pris = 250

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 52,
                TidTyp = "Tim",
                Pris = 250

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 1,
                TidTyp = "Tim",
                Pris = 300

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 2,
                TidTyp = "Tim",
                Pris = 250

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 3,
                TidTyp = "Tim",
                Pris = 250

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 4,
                TidTyp = "Tim",
                Pris = 250

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 5,
                TidTyp = "Tim",
                Pris = 250

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 6,
                TidTyp = "Tim",
                Pris = 250

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 7,
                TidTyp = "Tim",
                Pris = 300

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 8,
                TidTyp = "Tim",
                Pris = 300

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 9,
                TidTyp = "Tim",
                Pris = 250

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 10,
                TidTyp = "Tim",
                Pris = 250

            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 11,
                TidTyp = "Tim",
                Pris = 250,
            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 12,
                TidTyp = "Tim",
                Pris = 250,
            });
            KonferensPris.Add(new KonferensPris()
            {
                KonferensTyp = "KonferensStor",
                Vecka = 13,
                TidTyp = "Tim",
                Pris = 300,
            });
            for (int i = 14; i < 23; i++)
            {
                KonferensPris.Add(new KonferensPris()
                {
                    KonferensTyp = "KonferensStor",
                    Vecka = i,
                    TidTyp = "Tim",
                    Pris = 250

                });
            }
            for (int i = 23; i < 50; i++)
            {
                KonferensPris.Add(new KonferensPris()
                {
                    KonferensTyp = "KonferensStor",
                    Vecka = i,
                    TidTyp = "Tim",
                    Pris = 300

                });
            }

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 51,

                TidTyp = "Vecka",

                Pris = 3500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 52,

                TidTyp = "Vecka",

                Pris = 3500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 53,

                TidTyp = "Vecka",

                Pris = 3500



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 1,

                TidTyp = "Vecka",

                Pris = 6000



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 2,

                TidTyp = "Vecka",

                Pris = 3500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 3,

                TidTyp = "Vecka",

                Pris = 3500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 4,

                TidTyp = "Vecka",

                Pris = 3500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 5,

                TidTyp = "Vecka",

                Pris = 3500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 6,

                TidTyp = "Vecka",

                Pris = 3500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 7,

                TidTyp = "Vecka",

                Pris = 6000



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 8,

                TidTyp = "Vecka",

                Pris = 6000



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 9,

                TidTyp = "Vecka",

                Pris = 3500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 10,

                TidTyp = "Vecka",

                Pris = 3500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 11,

                TidTyp = "Vecka",

                Pris = 3500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 12,

                TidTyp = "Vecka",

                Pris = 3500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 13,

                TidTyp = "Vecka",

                Pris = 6000



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 14,

                TidTyp = "Vecka",

                Pris = 3500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 15,

                TidTyp = "Vecka",

                Pris = 3500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 16,

                TidTyp = "Vecka",

                Pris = 3500



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 17,

                TidTyp = "Vecka",

                Pris = 3500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 18,

                TidTyp = "Vecka",

                Pris = 3500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 19,

                TidTyp = "Vecka",

                Pris = 3500



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 20,

                TidTyp = "Vecka",

                Pris = 3500



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 21,

                TidTyp = "Vecka",

                Pris = 3500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 22,

                TidTyp = "Vecka",

                Pris = 3500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 23,

                TidTyp = "Vecka",

                Pris = 2500



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 24,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 25,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 26,

                TidTyp = "Vecka",

                Pris = 2500



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 27,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 28,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 29,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 30,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 31,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 32,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 33,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 34,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 35,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 36,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 37,

                TidTyp = "Vecka",

                Pris = 2500



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 38,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 39,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 40,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 41,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 42,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 43,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 44,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 45,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 46,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 47,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 48,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 49,

                TidTyp = "Vecka",

                Pris = 2500



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 50,

                TidTyp = "Vecka",

                Pris = 2500



            });



            KonferensPris.Add(new KonferensPris()

{

    KonferensTyp = "KonferensLiten",

    Vecka = 51,

    TidTyp = "Dygn",

    Pris = 850



});

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 52,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 53,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 1,

                TidTyp = "Dygn",

                Pris = 1150



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 2,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 3,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 4,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 5,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 6,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 7,

                TidTyp = "Dygn",

                Pris = 1150



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 7,

                TidTyp = "Dygn",

                Pris = 1150



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 8,

                TidTyp = "Dygn",

                Pris = 1150



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 9,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 10,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 11,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 12,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 13,

                TidTyp = "Dygn",

                Pris = 1150



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 14,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 15,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 16,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 17,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 18,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 19,

                TidTyp = "Dygn",

                Pris = 850



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 20,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 21,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 22,

                TidTyp = "Dygn",

                Pris = 850



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 23,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 24,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 25,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 26,

                TidTyp = "Dygn",

                Pris = 650



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 27,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 28,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 29,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 30,

                TidTyp = "Dygn",

                Pris = 650



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 31,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 32,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 33,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 34,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 35,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 36,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 37,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 38,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 39,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 40,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 41,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 42,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 43,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 44,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 45,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 46,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 47,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 48,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 49,

                TidTyp = "Dygn",

                Pris = 650



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 50,

                TidTyp = "Dygn",

                Pris = 650



            });



            KonferensPris.Add(new KonferensPris()

            {

            KonferensTyp = "KonferensLiten",

            Vecka = 51,

            TidTyp = "Tim",

            Pris = 155



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 52,

                TidTyp = "Tim",

                Pris = 155



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 53,

                TidTyp = "Tim",

                Pris = 155



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 1,

                TidTyp = "Tim",

                Pris = 200



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 2,

                TidTyp = "Tim",

                Pris = 155



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 3,

                TidTyp = "Tim",

                Pris = 155



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 4,

                TidTyp = "Tim",

                Pris = 155



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 5,

                TidTyp = "Tim",

                Pris = 155



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 6,

                TidTyp = "Tim",

                Pris = 155



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 7,

                TidTyp = "Tim",

                Pris = 200



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 8,

                TidTyp = "Tim",

                Pris = 200



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 9,

                TidTyp = "Tim",

                Pris = 155



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 10,

                TidTyp = "Tim",

                Pris = 155



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 11,

                TidTyp = "Tim",

                Pris = 155



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 12,

                TidTyp = "Tim",

                Pris = 155



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 13,

                TidTyp = "Tim",

                Pris = 200



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 14,

                TidTyp = "Tim",

                Pris = 155



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 15,

                TidTyp = "Tim",

                Pris = 155



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 16,

                TidTyp = "Tim",

                Pris = 155



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 17,

                TidTyp = "Tim",

                Pris = 155



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 18,

                TidTyp = "Tim",

                Pris = 155



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 19,

                TidTyp = "Tim",

                Pris = 155



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 20,

                TidTyp = "Tim",

                Pris = 155



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 21,

                TidTyp = "Tim",

                Pris = 155



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 22,

                TidTyp = "Tim",

                Pris = 155



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 23,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 24,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 25,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 26,

                TidTyp = "Tim",

                Pris = 115



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 27,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 28,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 29,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 30,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 31,

                TidTyp = "Tim",

                Pris = 115



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 32,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 33,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 34,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 35,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 36,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 37,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 38,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 39,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 40,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 41,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 42,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 43,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 44,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 45,

                TidTyp = "Tim",

                Pris = 115



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 46,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 47,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 48,

                TidTyp = "Tim",

                Pris = 115



            });



            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 49,

                TidTyp = "Tim",

                Pris = 115



            });

            KonferensPris.Add(new KonferensPris()

            {

                KonferensTyp = "KonferensLiten",

                Vecka = 50,

                TidTyp = "Tim",

                Pris = 115



            });





            SaveChanges();
        }

    }
}
