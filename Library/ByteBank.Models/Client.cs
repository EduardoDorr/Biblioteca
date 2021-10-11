using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models {
  public class Client {
    public string Name { get; set; }
    public string CPF { get; set; }
    public string Occupation { get; set; }

    public override bool Equals(object obj) {
      Client client = obj as Client;

      if (client == null) {
        return false;
      }

      return CPF == client.CPF;
    }
  }
}
