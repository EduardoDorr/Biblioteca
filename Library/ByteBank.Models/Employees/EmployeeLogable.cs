using ByteBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Employees {
  public abstract class EmployeeLogable : Employee, IVerifyLogin {
    private VerifyLoginHelper _verifyLoginHelper = new VerifyLoginHelper();
    public string Password { get; protected set; }

    public EmployeeLogable(double salary, string cpf) : base(salary, cpf) {

    }

    public void CreatePassword(string password) {
      Password = password;
    }

    public bool VerifyPassword(string password) {
      return _verifyLoginHelper.PasswordCompare(Password, password);
    }
  }
}
