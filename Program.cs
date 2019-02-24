using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int y = 0;
            int konumX = 0;
            int baslangicX = 0;
            int konumY = 0;
            int baslangicY = 0;
            string baslangicYon=string.Empty;
            string AracınYonu=string.Empty;
            string IzleyecegiYol=string.Empty;
            bool DogruDegerGirdimi = false;

            do
            {
                Console.Clear();
                try
                {
                    Console.WriteLine("Harita Boyutunu Giriniz:");
                    Console.Write("x değerini girin:");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("y değerini girin:");
                    y = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Konum Giriniz:");
                    Console.Write("x değerini girin:");
                    konumX = Convert.ToInt32(Console.ReadLine());
                    baslangicX = konumX;
                    Console.Write("y değerini girin:");
                    konumY = Convert.ToInt32(Console.ReadLine());
                    baslangicY = konumY;

                    Console.WriteLine("Doğu için 'D' Batı için 'B' Kuzey için'K' Güney için'G'");
                    Console.Write("Aracın mevcut yönünü girin:");
                    baslangicYon = Console.ReadLine().ToUpper();
                    AracınYonu = baslangicYon;
                    if (AracınYonu == "D" || AracınYonu == "B" || AracınYonu == "K" || AracınYonu == "G")
                        DogruDegerGirdimi = true;
                    else
                        DogruDegerGirdimi = false;

                    Console.WriteLine("Düz Gitmesi için 'W' Sağ için 'D' Sol için 'A' Geri için 'S' (WASD) Tuşlarını kullanın");
                    Console.Write("Aracın Takip edeceği yolu girin:");
                    IzleyecegiYol = Console.ReadLine().ToUpper();
                    foreach (var YonKontrol in IzleyecegiYol)
                    {

                        if (YonKontrol == 'W' || YonKontrol == 'D' || YonKontrol == 'A' || YonKontrol == 'S')
                            DogruDegerGirdimi = true;
                        else
                        {
                            DogruDegerGirdimi = false;
                            Console.WriteLine("Hatalı Giriş Yaptınız Tekrar Girmek için Bir tuşa bas");
                            Console.ReadKey();
                            break;
                        }
                    }
                    
                }
                catch
                {
                    Console.WriteLine("Hatalı Giriş Yaptınız Tekrar Girmek için Bir tuşa bas");
                    Console.ReadKey();
                    DogruDegerGirdimi = false;
                }
            }while (DogruDegerGirdimi==false);

            /*
             * Eğer X artıyorsa  Yeni Yön Kuzey (K)
             * Eğer X azalıyorsa Yeni Yön Güney (G)
             * Eğer Y artıyorsa  Yeni Yön Doğu  (D)
             * Eğer Y azalıyorsa yeni yön Batı  (B)
             */
            foreach (var Rota in IzleyecegiYol)
            {
                if (AracınYonu == "D")
                {
                    if (Rota == 'W')
                        ++konumY;
                    else if (Rota == 'S')
                    {
                        --konumY;
                        AracınYonu = "B";
                    }
                    else if (Rota == 'D')
                    {
                        ++konumX;
                        AracınYonu = "K";
                    }
                    else
                    {
                        --konumX;
                        AracınYonu = "G";
                    }

                    if (konumX > x || konumX < 0 || konumY > y || konumY < 0)
                    {
                        Console.WriteLine("Haritanın dışına çıktınız");
                        break;
                    }
                }
                else if (AracınYonu == "B")
                {
                    if (Rota == 'W')
                        --konumY;
                    else if (Rota == 'S')
                    {
                        ++konumY;
                        AracınYonu = "D";
                    }
                    else if (Rota == 'D')
                    {
                        --konumX;
                        AracınYonu = "G";
                    }
                    else
                    {
                        ++konumX;
                        AracınYonu = "K";
                    }
                    if (konumX > x || konumX < 0 || konumY > y || konumY < 0)
                    {
                        Console.WriteLine("Haritanın dışına çıktınız");
                        break;
                    }
                }
                else if (AracınYonu == "K")
                {
                    if (Rota == 'W')
                        ++konumX;
                    else if (Rota == 'S')
                    {
                        --konumX;
                        AracınYonu = "G";
                    }
                    else if (Rota == 'D')
                    {
                        --konumY;
                        AracınYonu = "B";
                    }
                    else
                    {
                        ++konumY;
                        AracınYonu = "D";
                    }
                    if (konumX > x || konumX < 0 || konumY > y || konumY < 0)
                    {
                        Console.WriteLine("Haritanın dışına çıktınız");
                        break;
                    }
                }
                else if (AracınYonu == "G")
                {
                    if (Rota == 'W')
                        --konumX;
                    else if (Rota == 'S')
                    {
                        ++konumX;
                        AracınYonu = "K";
                    }
                    else if (Rota == 'D')
                    {
                        ++konumY;
                        AracınYonu = "D";
                    }
                    else
                    {
                        --konumY;
                        AracınYonu = "B";
                    }
                    if (konumX > x || konumX < 0 || konumY > y || konumY < 0)
                    {
                        Console.WriteLine("Haritanın dışına çıktınız");
                        break;
                    }
                }
                
            }
            Console.WriteLine("Eski x,y: {0} , {1} || Yön: {2} ", baslangicX, baslangicY, baslangicYon);
            Console.WriteLine("Yeni x,y: {0} , {1} || Yön: {2}", konumX, konumY, AracınYonu);
            Console.ReadKey();
        }
    }
}
