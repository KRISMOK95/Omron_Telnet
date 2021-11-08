using System;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace Omron2
{
   
        class Program
        {

            static void Main(string[] args)
            {
            Console.WriteLine("Hello World!");
            telnet2 tel = new telnet2();
            tel.EstablishConnection("192.168.11.203", 7171);
            Console.WriteLine("Connected!");
            System.Threading.Thread.Sleep(1000);

            
            }
        }
    
}
