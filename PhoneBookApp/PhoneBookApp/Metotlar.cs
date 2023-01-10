using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class Metotlar : Rehber
    {
        public static List<Rehber> rehberList = new List<Rehber>()
            {
                new Rehber(){ Isim="Berkay",Soyisim="Genç",Telefon=1109008080},
                new Rehber(){ Isim="Saniye",Soyisim="Yılmaz",Telefon=1109008080},
                new Rehber(){ Isim="Zikriye",Soyisim="Güneç",Telefon=1109008080},
                new Rehber(){ Isim="Emre",Soyisim="Bahadır",Telefon=1109008080},
                new Rehber(){ Isim="Aslan",Soyisim="Murat",Telefon=3131313131},
             };
        public void SecimMenu()
        {
            Console.WriteLine(" * Ana menüye dönmek için : (1)\n" +
                               " * bitir      : (2)");
            int secim = int.Parse(Console.ReadLine());
            if (secim == 1)
                Program.Menu();
            else if (secim == 2)
                Environment.Exit(0);
        }

        public void Listele()
        {
            Console.WriteLine("\n********************** Telefon Rehberi **********************");
            foreach (Rehber item in rehberList)
            {
                Console.Write("\n"
                    + "İsim              : {" + item.Isim
                    + "}\nSoyisim           : {" + item.Soyisim
                    + "}\nTelefon Numarası  : {" + item.Telefon
                    + "}\n-\n");
            }
            SecimMenu();
        }
        public void Kaydet()
        {
            
            Console.Write("Lütfen isim giriniz            :");
            string isim = Console.ReadLine();
            Console.Write("Lütfen soyisim giriniz         :");
            string soyisim = Console.ReadLine();
            Console.Write("Lütfen telefon numarası giriniz:");
            long telefon = Int64.Parse(Console.ReadLine());
            
            rehberList.Add(new Rehber() { Isim = isim, Soyisim = soyisim, Telefon = telefon });
            Console.WriteLine("Kişi başarıyla kaydedildi!");
            Console.WriteLine(" * Ana menüye dönmek için : (1)\n" +
                               " * Yeni biri kaydetmek için      : (2)");
            int secim = int.Parse(Console.ReadLine());
            if (secim == 1)
                Program.Menu();
            else if (secim == 2)
                Kaydet();

        }

        public void Sil()
        {
            Console.Write("Lütfen silmek istediğiniz kişinin adını yada soyadını girin: ");
            var aranan = Console.ReadLine().ToLower();

            var bulunan = rehberList.Find(i => i.Isim.ToLower() == aranan || i.Soyisim.ToLower() == aranan);

            if (rehberList.Contains(bulunan))
            {
                Console.WriteLine(aranan + " isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(e/h)");
                string input = Console.ReadLine();
                if (input == "e" || input == "E")
                {
                    rehberList.Remove(bulunan);
                    SecimMenu();
                }
                else if (input == "h" || input == "H")
                {
                    Program.Menu();
                }
            }
            else
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine(" * Silmeyi sonlandırmak için : (1)\n" +
                                  " * Yeniden denemek için      : (2)");
                int secim = int.Parse(Console.ReadLine());
                if (secim == 1)
                    Program.Menu();
                else if (secim == 2)
                    Sil();
            }
        }
        public void Guncelle()
        {
            Console.Write("Lütfen güncellemek istediğiniz kişinin adını yada soyadını girin: ");
            var aranan = Console.ReadLine().ToLower();

            var bulunan = rehberList.Find(i => i.Isim.ToLower() == aranan || i.Soyisim.ToLower() == aranan);

            if (rehberList.Contains(bulunan))
            {
                Console.WriteLine(aranan + " isimli kişi rehberden güncellenmek üzere, onaylıyor musunuz ?(e/h)");
                string input = Console.ReadLine();
                if (input == "e" || input == "E")
                {
                    Console.WriteLine("İsim:");
                    bulunan.Isim = Console.ReadLine();
                    Console.WriteLine("Soyisim:");
                    bulunan.Soyisim = Console.ReadLine();
                    Console.WriteLine("Numara:");
                    bulunan.Telefon = long.Parse(Console.ReadLine());
                    SecimMenu();
                }
                else if (input == "h" || input == "H")
                {
                    Program.Menu();
                }
            }
            else
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine(" * Güncellemeyi sonlandırmak için : (1)\n" +
                                  " * Yeniden denemek için      : (2)");
                int secim = int.Parse(Console.ReadLine());
                if (secim == 1)
                    Program.Menu();
                else if (secim == 2)
                {
                    Guncelle();
                }

            }
        }

        public void Arama()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçin");
            Console.WriteLine(" * İsme ve soyisime göre arama için : (1)\n" +
                              " * Telefon numarasına arama için    : (2)");
            int secim = int.Parse(Console.ReadLine());
            if (secim == 1)
            {
                Console.Write("Arayacağınız ismi ya da soyisimi girin: ");
                var aranan = Console.ReadLine().ToLower();

                var bulunan = rehberList.Find(i => i.Isim.ToLower() == aranan || i.Soyisim.ToLower() == aranan);

                if (rehberList.Contains(bulunan))
                {
                    Console.Write("\n"
                    + "İsim              : {" + bulunan.Isim
                    + "}\nSoyisim           : {" + bulunan.Soyisim
                    + "}\nTelefon Numarası  : {" + bulunan.Telefon
                    + "}\n-\n");
                    SecimMenu();
                }
                else
                {
                    Console.WriteLine("Aradığınız kişi bulunamadı!");
                    SecimMenu();

                }
            }
                
            else if (secim == 2)
            {
                Console.Write("Arayacağınız telefonu girin: ");
                var aranan = long.Parse(Console.ReadLine());

                var bulunan = rehberList.Find(i => i.Telefon == aranan);

                if (rehberList.Contains(bulunan))
                {
                    Console.Write("\n"
                    + "İsim              : {" + bulunan.Isim
                    + "}\nSoyisim           : {" + bulunan.Soyisim
                    + "}\nTelefon Numarası  : {" + bulunan.Telefon
                    + "}\n-\n");
                    SecimMenu();
                }
                else
                {
                    Console.WriteLine("Aradığınız kişi bulunamadı!");
                    SecimMenu();
                }
            }
        }

    }
}

