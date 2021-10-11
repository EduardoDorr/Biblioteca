using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Comparers {
  public class CheckingAccountSortbyAgency : IComparer<CheckingAccount> {
    public int Compare(CheckingAccount x, CheckingAccount y) {
      if (x == y) {
        return 0;
      }

      if (x == null) {
        return 1;
      }

      if (y == null) {
        return -1;
      }

      return x.Agency.CompareTo(y.Agency);

      /*if (x.Agency < y.Agency) {
        return -1;
      }

      if (x.Agency == y.Agency) {
        return 0;
      }

      return 1;*/
    }
  }
}
