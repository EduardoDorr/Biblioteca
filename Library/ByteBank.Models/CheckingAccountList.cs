using ByteBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.AgencySystem {
  public class CheckingAccountList {
    private CheckingAccount[] _items;
    private int _nextPosition;

    public int Length {
      get {
        return _nextPosition;
      }
    }

    public CheckingAccountList(int initialCapacity = 5) {
      _items = new CheckingAccount[initialCapacity];
      _nextPosition = 0;
    }

    public void Append(CheckingAccount account) {
      VerifyCapacity(_nextPosition + 1);

      _items[_nextPosition] = account;
      _nextPosition++;
    }

    public void AppendMore(params CheckingAccount[] items) {
      foreach (CheckingAccount account in items) {
        Append(account);
      }
    }

    public void Remove(CheckingAccount item) {
      int itemIndex = -1;

      for (int i = 0; i < _nextPosition; i++) {
        CheckingAccount actualItem = _items[i];

        if (actualItem.Equals(item)) {
          itemIndex = i;
          break;
        }
      }

      for (int i = itemIndex; i < _nextPosition; i++) {
        _items[i] = _items[i + 1];
      }

      _nextPosition--;
      _items[_nextPosition] = null;
    }

    public CheckingAccount GetItem(int index) {
      if (index < 0 || index >= _nextPosition) {
        throw new ArgumentOutOfRangeException(nameof(index));
      }

      return _items[index];
    }

    public void VerifyCapacity(int lengthNeeded) {
      if (_items.Length >= lengthNeeded) {
        return;
      }

      int newLength = _items.Length * 2;

      if (newLength < lengthNeeded) {
        newLength = lengthNeeded;
      }

      CheckingAccount[] newArray = new CheckingAccount[newLength];

      for (int i = 0; i < _items.Length; i++) {
        newArray[i] = _items[i];
      }

      _items = newArray;
    }

    public CheckingAccount this[int index] {
      get {
        return GetItem(index);
      }
    }
  }
}
