using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;

namespace PasswordCrackerMaster
{
    class Master
    {
        List<string> passwords;
        public Master()
        {
              passwords = new List<string>();  
        }

        public void Listen(int port)
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, port);
            server.Start();
            Console.WriteLine("Server is started and listening on localhost 6789");

            TcpClient clientConnection = server.AcceptTcpClient();
            Console.WriteLine("Slave connected");

            // forbindelse mellem server og client
            Stream ns = clientConnection.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            sw.AutoFlush = true;

            //A request from the slave
            string request = sr.ReadLine();

            passwords = JsonSerializer.Deserialize<List<string>>(request);

            Console.WriteLine("client says >>>>>"+ request);
            Console.WriteLine(passwords[1]);
            
            //bliver ved med at lytte (while) continuos 
            while(request != "by")
            {
                request = sr.ReadLine();
                Console.WriteLine("Server");
            }

            Console.ReadKey();
        }
    }
}
