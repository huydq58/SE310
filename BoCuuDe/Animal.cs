using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoCuuDe
{
    internal class Animal
    {
        public int SoLuong { get; set; }
        public Animal(int soluong) {
        SoLuong = soluong;
        }
        public virtual String Keu()
        {
            return "";
        }
        public virtual int ChoSua()
        {
            return 0; 
        }
        public virtual int SinhSan()
        {
            return 0;
        }
    }
    class Bo: Animal
    {

        public Bo(int soluong ):base (soluong) { }

        public override String Keu() { return "\nToi la bo"; }
        public override int ChoSua() {
            Random rd = new Random();
            rd.Next(0,20);
            return rd.Next();
        }

        public override int SinhSan()
        {
            return SoLuong/2;
        }
    }
    class Cuu: Animal
    {
        public Cuu(int soluong ):base (soluong) { }

        public override String Keu() { return "\nToi la cuu"; }

        public override int ChoSua()
        {
            Random rd = new Random();
            rd.Next(0,5);
            return rd.Next();
        }
        public override int SinhSan()
        {
            return SoLuong / 2;
        }
    }
    class De:Animal
    {
        public De(int soluong):base (soluong) { }

        public override String Keu() { return "\nToi la de"; }

        public override int ChoSua()
        {
            Random rd = new Random();
            rd.Next(0,10);
            return rd.Next();
        }
        public override int SinhSan()
        {
            return SoLuong / 2;
        }
    }
}
