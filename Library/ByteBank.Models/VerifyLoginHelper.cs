using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models {
  public class VerifyLoginHelper {
    public bool PasswordCompare(string password, string tryPassword) {
      return password == tryPassword;
    }
  }
}
