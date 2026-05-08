using System;
using System.Collections.Generic;

namespace SistemProdukToko
{
    // 2a. Kelas Produk
    public class Produk
    {
        public string Nama { get; set; }
        public double Harga { get; set; }

        public virtual void InfoProduk()
        {
            Console.WriteLine($"Nama: {Nama}, Harga: {Harga}");
        }

        // 3b & 4. Method Kategori (Virtual agar bisa di-override)
        public virtual string Kategori()
        {
            return "Produk Umum";
        }
    }

    // 2b. Kelas Elektronik
    public class Elektronik : Produk
    {
        public int Garansi { get; set; }

        public void CekGaransi()
        {
            Console.WriteLine($"Garansi elektronik ini berlaku selama {Garansi} tahun.");
        }

        public override string Kategori()
        {
            return "Elektronik";
        }
    }

    // 2c. Kelas Makanan
    public class Makanan : Produk
    {
        public DateTime TanggalKadaluarsa { get; set; }

        public void CekKadaluarsa()
        {
            Console.WriteLine($"Produk ini kadaluarsa pada: {TanggalKadaluarsa.ToShortDateString()}");
        }

        public override string Kategori()
        {
            return "Makanan";
        }
    }

    // 2d. Kelas Laptop dan HP
    public class Laptop : Elektronik
    {
        public void InstallSoftware()
        {
            Console.WriteLine("Sedang menginstal software di laptop...");
        }

        public override string Kategori()
        {
            return "Elektronik - Laptop";
        }
    }

    public class HP : Elektronik
    {
        public void Telepon()
        {
            Console.WriteLine("Melakukan panggilan telepon dari HP...");
        }

        public override string Kategori()
        {
            return "Elektronik - HP";
        }
    }

    // 2e. Kelas Snack dan Minuman
    public class Snack : Makanan
    {
        public void Makan()
        {
            Console.WriteLine("Snack sedang dimakan.");
        }

        public override string Kategori()
        {
            return "Makanan - Snack";
        }
    }

    public class Minuman : Makanan
    {
        public void Dinginkan()
        {
            Console.WriteLine("Minuman sedang didinginkan di kulkas.");
        }

        public override string Kategori()
        {
            return "Makanan - Minuman";
        }
    }

    // 2f & 5. Kelas Toko
    public class Toko
    {
        private List<Produk> daftarProduk = new List<Produk>();

        public void TambahProduk(Produk produk)
        {
            daftarProduk.Add(produk);
        }

        public void DaftarProduk()
        {
            Console.WriteLine("=== Daftar Produk di Toko ===");
            foreach (var p in daftarProduk)
            {
                p.InfoProduk();
                Console.WriteLine($"Kategori: {p.Kategori()}");
                Console.WriteLine("-------------------------");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 6a. Buat objek toko
            Toko tokoSaya = new Toko();

            // 6b. Buat beberapa objek produk
            Laptop laptop1 = new Laptop { Nama = "Asus ROG", Harga = 15000000, Garansi = 2 };
            HP hp1 = new HP { Nama = "iPhone 15", Harga = 18000000, Garansi = 1 };
            Snack snack1 = new Snack { Nama = "Chitato", Harga = 10000, TanggalKadaluarsa = new DateTime(2025, 12, 31) };
            Minuman minum1 = new Minuman { Nama = "Coca-cola", Harga = 5000, TanggalKadaluarsa = new DateTime(2024, 06, 01) };

            // 6c. Tambahkan ke toko
            tokoSaya.TambahProduk(laptop1);
            tokoSaya.TambahProduk(hp1);
            tokoSaya.TambahProduk(snack1);
            tokoSaya.TambahProduk(minum1);

            // 6d. Tampilkan semua data
            tokoSaya.DaftarProduk();

            // 6e & 6f. Demonstrasi Polymorphism dan Method Khusus
            Console.WriteLine("\n=== Demonstrasi Method Khusus ===");
            laptop1.InstallSoftware();
            hp1.Telepon();
            snack1.Makan();
            minum1.Dinginkan();

            // Menjawab Pertanyaan 5 (Variabel bertipe Produk isi HP)
            Produk produkHP = new HP { Nama = "Samsung S24", Harga = 14000000 };
            Console.WriteLine($"\nTes Soal 5: {produkHP.Kategori()}");
        }
    }
}