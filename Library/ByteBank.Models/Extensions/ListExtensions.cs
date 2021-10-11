using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.AgencySystem.Extensions {
  public static class ListExtensions {
    public static void AddMore<T>(this List<T> list, params T[] items) {
      foreach (T item in items) {
        list.Add(item);
      }
    }
  }
}
