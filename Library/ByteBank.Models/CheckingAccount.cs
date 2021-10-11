using ByteBank.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models {
  /// <summary>
  /// A ByteBank account class.
  /// </summary>
  public class CheckingAccount : IComparable {
    private double _balance = 100;

    public Client Owner { get; set; }
    public static double OperationTax { get; private set; }
    public static int Qtd { get; private set; }
    public int Agency { get; }
    public int Number { get; }
    public double Balance {
      get {
        return _balance;
      }
      set {
        if (value < 0) {
          return;
        }

        _balance = value;
      }
    }
    public int WithdrawNotAllowed { get; private set; }
    public int TransferNotAllowed { get; private set; }

    /// <summary>
    /// Create a checking account instance with <see cref="Agency"/> and <see cref="Number"/>.
    /// </summary>
    /// <param name="agency">The <paramref name="agency"/> number of the checking account must be greater than zero.</param>
    /// <param name="number">The <paramref name="number"/> of the checking account must be greater than zero.</param>
    /// <exception cref="ArgumentException">The <see cref="Agency"/> and <see cref="Number"/> parameters must be greater than zero.</exception>
    public CheckingAccount(int agency, int number) {
      if (agency <= 0) {
        throw new ArgumentException("Agency and Number must be greater than 0", nameof(agency));
      }

      if (number <= 0) {
        throw new ArgumentException("Agency and Number must be greater than 0", nameof(number));
      }

      Agency = agency;
      Number = number;

      Qtd++;
      OperationTax = 30 / Qtd;
    }

    /// <summary>
    /// A method to withdraw a value from the checking account.
    /// </summary>
    /// <param name="value">The value of money wanted to withdraw. The <paramref name="value"/> must be greater than zero.</param>
    /// <exception cref="ArgumentException">The <paramref name="value"/> must be greater than zero."/></exception>
    /// <exception cref="InsufficientFundsException">The <see cref="Balance"/> must be greater than <paramref name="value"/>.</exception>
    public void Withdraw(double value) {
      if (value < 0) {
        throw new ArgumentException("The withdraw value is invalid!", nameof(value));
      }
      if (_balance < value) {
        WithdrawNotAllowed++;
        throw new InsufficientFundsException(_balance, value);
      }
      _balance -= value;
    }

    public void Deposit(double value) {
      _balance += value;
    }

    public void Transfer(double value, CheckingAccount destAccount) {
      if (value < 0) {
        throw new ArgumentException("The transfer value is invalid!", nameof(value));
      }
      try {
        Withdraw(value);
      }
      catch (InsufficientFundsException ex) {
        throw new FinancialOperationException("The operation couldn't be performed", ex);
      }
      destAccount.Deposit(value);
    }

    public override string ToString() {
      return $"Agency {this.Agency}, Number {this.Number}, Balance {this.Balance}";
    }

    public int CompareTo(object obj) {
      // Retorna negativo quando a instância precede o obj
      // Retorna zero quando nossa instância e obj forem equivalentes
      // Retorna positivo quando o obj precede a instância

      var anotherAccount = obj as CheckingAccount;

      if (anotherAccount == null) {
        return -1;
      }

      return Number.CompareTo(anotherAccount.Number);

      /*if (Number < anotherAccount.Number) {
        return -1;
      }

      if (Number == anotherAccount.Number) {
        return 0;
      }

      return 1;*/
    }
  }
}