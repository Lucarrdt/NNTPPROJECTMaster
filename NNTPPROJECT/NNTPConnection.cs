
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;

namespace NNTPPROJECT
{

    public class NNTPConnection
    {
        private TcpClient? TcpClient;
        private NetworkStream? NetworkStream;
        /*The constructor below asks for the host server and the port which has to be 119 always.*/
        public NNTPConnection(string host, int port)
        {
            TcpClient = new TcpClient(host, 119);
            NetworkStream = TcpClient.GetStream();
            /* Checking if the connection is established by writing the host name and the default port. */
            switch (TcpClient.Connected)
            {
                case true:
                    Debug.WriteLine("Established connection to " + host + " on port " + port);
                    break;
                default:
                    Debug.WriteLine("Failed to connect to " + host + " on port " + port);
                    break;
            }
            /* Checking if the connection is established by getting the 200 command which appears first when connection is successful. */
            StreamReader reader = new StreamReader(NetworkStream);
            while (!NetworkStream.DataAvailable) ;
            string response = reader.ReadLine();
            Debug.WriteLine(response.StartsWith("200") ? "Connection established" : "Connection failed");
            Authenticate(username: "alva1035@easv365.dk", password: "e2b664");
        }
        /* The method below is used to authenticate the user. */
        private void Authenticate(string username, string password)
        {
            StreamWriter writer = new StreamWriter(NetworkStream);
            StreamReader reader = new StreamReader(NetworkStream);
            writer.WriteLine("authinfo user " + username);
            writer.Flush();
            while (!NetworkStream.DataAvailable) ;
            string response = reader.ReadLine();
            
            Debug.WriteLine(response.StartsWith("381") ? "Username accepted" : "Username rejected");
            
            writer.WriteLine("authinfo pass " + password);
            writer.Flush();
            while (!NetworkStream.DataAvailable) ;
            response = reader.ReadLine();
            
            Debug.WriteLine(response.StartsWith("281") ? "Password accepted" : "Password rejected");

        }
        public List<string> GetGroups()
        {
            StreamWriter writer = new StreamWriter(NetworkStream);
            StreamReader reader = new StreamReader(NetworkStream);
            writer.WriteLine("list");
            writer.Flush();
            while (!NetworkStream.DataAvailable) ;
            string response = reader.ReadLine();
            List<string> groups = new List<string>();
            while (response != "." && response != "215")
            {
                groups.Add(response);
                response = reader.ReadLine();
            }
            return groups;
        }
    }
    }
