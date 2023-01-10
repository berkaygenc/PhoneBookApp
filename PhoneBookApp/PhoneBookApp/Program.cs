using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;

namespace PhoneBookApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Metotlar rehber = new Metotlar();

            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçin :" +
                              "\n****************************************" +
                              "\n(1) Yeni Numara Kaydetmek" +
                              "\n(2) Varolan Numarayı Silmek" +
                              "\n(3) Varolan Numarayı Güncelleme" +
                              "\n(4) Rehberi Listelemek" +
                              "\n(5) Rehberde Arama Yapmak﻿");


            int islem = Int32.Parse(Console.ReadLine());
            switch (islem)
            {
                case 1:
                    rehber.Kaydet();
                    break;
                case 2:
                    rehber.Sil();

                    break;
                case 3:
                    rehber.Guncelle();
                    break;
                case 4:
                    
                    rehber.Listele();
                    break;
                case 5:
                    rehber.Arama();
                    break;
            }
        }


    }
}
