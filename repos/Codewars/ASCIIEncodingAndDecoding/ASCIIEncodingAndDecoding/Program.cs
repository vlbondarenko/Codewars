using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIEncodingAndDecoding
{
    class Program
    {
       
        public static void Main(string[] args)
        {
            string str = @"<~9jqo^BlbD-BleB1DJ+*+F(f,q/0JhKF<GL>Cj@.4Gp$d7F!,L7@<6@)/0JDEF<G%<+EV:2F!,O<DJ+*.@<*K0@<6L(Df-\0Ec5e;DffZ(EZee.Bl.9pF""AGXBPCsi+DGm>@3BB/F*&OCAfu2/AKYi(DIb:@FD,*)+C]U=@3BN#EcYf8ATD3s@q?d$AftVqCh[NqF<G:8+EV:.+Cf>-FD5W8ARlolDIal(DId<j@<?3r@:F%a+D58'ATD4$Bl@l3De:,-DJs`8ARoFb/0JMK@qB4^F!,R<AKZ&-DfTqBG%G>uD.RTpAKYo'+CT/5+Cei#DII?(E,9)oF*2M7/c~>";
            string str1 = "Man is distinguished, not only by his reason, but by this singular passion from other animals, which is a lust of the mind, that by a perseverance of delight in the continued and indefatigable generation of knowledge, exceeds the short vehemence of any carnal pleasure.";


            //Простенький тест на правильную работу алгоритма. Строки взяты из статьи, посвященной кодированию ASCII85 на википедии.
            Console.WriteLine(str1.ToASCII85() + "\n");
            Console.WriteLine(str + "\n");
            Console.WriteLine(str1.Equals(str) + "\n");

            Console.WriteLine(str.FromASCII85() + "\n");
            Console.WriteLine(str1 + "\n");
            Console.WriteLine(str.Equals(str1.ToASCII85()) + "\n");

            Console.WriteLine();



            Console.ReadLine();
        }
    }
}

