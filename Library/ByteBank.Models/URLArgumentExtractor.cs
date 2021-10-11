using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.AgencySystem {
  public class URLArgumentExtractor {
    private readonly string _arguments;
    public string URL { get; }

    public URLArgumentExtractor(string url) {
      if (String.IsNullOrEmpty(url)) {
        throw new ArgumentException("The argument" + nameof(url) + "could not be null or empty", nameof(url));
      }

      URL = url;

      _arguments = url.Substring(url.IndexOf('?') + 1); 
    }

    public string GetValue(string argument) {
      string argumentUpperCase = _arguments.ToUpper();
      string result = _arguments.Substring(argumentUpperCase.IndexOf(argument.ToUpper() + "=")
                                            + (argument.ToUpper() + "=").Length);

      if (result.IndexOf('&') != -1) {
        return result.Remove(result.IndexOf('&'));
      }

      return result;
    }
  }
}
