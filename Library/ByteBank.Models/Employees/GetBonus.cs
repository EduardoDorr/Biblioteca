using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models.Employees {
  public class GetBonus {
    private double _bonusTotal;

    /// <summary>
    /// Teste de comentário de code-snipt
    /// </summary>
    /// <param name="employee"></param>
    public void Register(Employee employee) {
      _bonusTotal += employee.GetBonus();
    }

    public double GetBonusTotal() {
      return _bonusTotal;
    }
  }
}
