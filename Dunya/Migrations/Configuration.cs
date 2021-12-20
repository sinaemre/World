namespace Dunya.Migrations
{
    using Dunya.Data;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dunya.Data.DunyaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Dunya.Data.DunyaContext context)
        {
            if (!context.Yerler.Any())
            {
                context.Yerler.Add(new Yer("Dünya")
                {
                    Children = new List<Yer>()
                    {
                        new Yer("Türkiye")
                        {
                            Children = new List<Yer>()
                            {
                                new Yer("Kars"),
                                new Yer("Hakkari"),
                                new Yer("Ankara")
                                {
                                    Children = new List<Yer>()
                                    {
                                        new Yer("Polatlı"),
                                        new Yer("Gölbaşı"),
                                        new Yer("Çankaya")
                                        {
                                            Children = new List<Yer>()
                                            {
                                                new Yer("Bilkent"),
                                                new Yer("Çayyolu")
                                                {
                                                    Children = new List<Yer>()
                                                    {
                                                        new Yer("Yaşamkent mah."),
                                                        new Yer("Dodurga mah."),
                                                        new Yer("Koru mah.")
                                                    }
                                                },
                                                new Yer("Kızılay")

                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new Yer("The United States of America")
                        {
                            Children =new List<Yer>()
                            {
                                new Yer("California"),
                                new Yer("Texas"),
                                new Yer("Washington")
                            }
                        }
                    }
                });
            }
        }
    }
}
