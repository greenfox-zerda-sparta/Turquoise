using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace SmartHomeUI {
  public class Communication {
    static UdpClient listener = new UdpClient(45454);
    static IPEndPoint groupEP;

    IPEndPoint ep;
    TcpClient client;
    NetworkStream stream;
    byte[] recieve_msg;

    public void connectToBroadcast() {
      groupEP = new IPEndPoint(IPAddress.Any, 45454);
      listener.Receive(ref groupEP);
      ep = new IPEndPoint(IPAddress.Parse(groupEP.Address.ToString()), 1234);
      client = new TcpClient();
      client.Connect(ep);
      stream = client.GetStream();
    }

    public void send(string message) {
      string request = message + "\n";
      stream.Write(Encoding.ASCII.GetBytes(request), 0, request.Length);
    }

    public string recieve() {
      recieve_msg = new byte[1024];
      stream.Read(recieve_msg, 0, recieve_msg.Length);
      string recieved_string = System.Text.Encoding.Default.GetString(recieve_msg);
      Regex rgx = new Regex("[^a-zA-Z0-9!-/ -]");
      recieved_string = rgx.Replace(recieved_string, "");
      return recieved_string;
    }
  }
}
