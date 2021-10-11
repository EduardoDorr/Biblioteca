using ByteBank.Models.Interfaces;
using System;

namespace ByteBank.Models.Systems {
  public class InternSystem {
    public bool Login(IVerifyLogin employee, string password) {
      bool logable = employee.VerifyPassword(password);

      if (logable) {
        Console.WriteLine("Welcome to ByteBank System!");
        return true;
      }

      Console.WriteLine("Password is incorrect!");
      return false;
    }
  }
}
