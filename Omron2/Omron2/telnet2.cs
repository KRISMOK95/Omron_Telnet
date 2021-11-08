using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace Omron2
{
    class telnet2
    {
        public TcpClient client;
        private NetworkStream stream;
        public telnet2()
        {
            Console.WriteLine("Oject created");
        }


        public void EstablishConnection(string ip_address, int port_number)
        {
            try
            {
                client = new TcpClient(ip_address, port_number); //thats a comment
                Console.WriteLine("Client created");
#if DEBUG

                Console.WriteLine("[Communication] : [EstablishConnection] : Success connecting to : {0}, port: {1}", ip_address, port_number);
#endif
                Console.WriteLine("Stream created");
                Console.Write("Enter the string to be transmitted : ");
                String str = Console.ReadLine();

                stream = client.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                Console.WriteLine("Transmitting.....");
                stream.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100];
                int k = stream.Read(bb, 0, 100);

                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(bb[i]));

                //client.Close();
            }
            catch
            {
                Console.WriteLine("[Communication] : [EstablishConnection] : Failed while connecting to : {0}, port: {1}", ip_address, port_number);
                System.Environment.Exit(1);
            }
        }

    }
}
