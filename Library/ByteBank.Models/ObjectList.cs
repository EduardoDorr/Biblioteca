using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.AgencySystem {
  public class ObjectList {
    private Object[] _items;
    private int _nextPosition;

    public int Length {
      get {
        return _nextPosition;
      }
    }

    public ObjectList(int initialCapacity = 5) {
      _items = new Object[initialCapacity];
      _nextPosition = 0;
    }

    public void Append(Object item) {
      VerifyCapacity(_nextPosition + 1);

      _items[_nextPosition] = item;
      _nextPosition++;
    }

    public void AppendMore(params Object[] items) {
      foreach (Object item in items) {
        Append(item);
      }
    }

    public void Remove(Object item) {
      int itemIndex = -1;

      for (int i = 0; i < _nextPosition; i++) {
        Object actualItem = _items[i];

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

    public Object GetItem(int index) {
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

      Object[] newArray = new Object[newLength];

      for (int i = 0; i < _items.Length; i++) {
        newArray[i] = _items[i];
      }

      _items = newArray;
    }

    public Object this[int index] {
      get {
        return GetItem(index);
      }
    }
  }
}
