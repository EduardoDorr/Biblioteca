using ByteBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models {
  public class ComercialPartner : IVerifyLogin {
    private VerifyLoginHelper _verifyLoginHelper = new VerifyLoginHelper();
    public string Password { get; private set; }

    public void CreatePassword(string password) {
      Password = password;
    }

    public bool VerifyPassword(string password) {
      return _verifyLoginHelper.PasswordCompare(Password, password);
    }
  }
}
