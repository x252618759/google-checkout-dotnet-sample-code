/*************************************************
 * Copyright (C) 2006-2007 Google Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
*************************************************/

using System.Configuration;
using System.Web;
using System.Xml;

namespace GCheckout.Util {
  /// <summary>
  /// Google Checkout Config Section.
  /// </summary>
  /// <remarks>This will replace the AppSettings implementation.</remarks>
  public class GCheckoutConfigSection {
    private EnvironmentType _environment = EnvironmentType.Unknown;

    /// <summary>
    /// The Environment
    /// </summary>
    public virtual EnvironmentType Environment {
      get {
        return _environment;
      }
      set {
        _environment = value;
      }
    }

    private long _productionMerchantID;

    /// <summary>
    /// The Production Merchant ID
    /// </summary>
    public virtual long ProductionMerchantID {
      get {
        return _productionMerchantID;
      }
      set {
        if (value > 0)
          _productionMerchantID = value; 
      }
    }

    private string _productionMerchantKey;

    /// <summary>
    /// The Production Merchant Key
    /// </summary>
    public virtual string ProductionMerchantKey {
      get {
        return _productionMerchantKey;
      }
      set {
        if (value != null && value.Length > 0)
          _productionMerchantKey = value; 
      }
    }

    private long _sandboxMerchantID;

    /// <summary>
    /// The Sandbox Merchant ID
    /// </summary>
    public virtual long SandboxMerchantID {
      get {
        return _sandboxMerchantID;
      }
      set {
        if (value > 0)
          _sandboxMerchantID = value; 
      }
    }

    private string _sandboxMerchantKey;

    /// <summary>
    /// The Sandbox Merchant Key
    /// </summary>
    public virtual string SandboxMerchantKey {
      get {
        return _sandboxMerchantKey;
      }
      set {
        if (value != null && value.Length > 0)
          _sandboxMerchantKey = value; 
      }
    }

    /// <summary>
    /// The Current Merchant ID
    /// </summary>
    public virtual long MerchantID {
      get {
        if (Environment == EnvironmentType.Sandbox)
          return _sandboxMerchantID;
        else if (Environment == EnvironmentType.Production)
          return _productionMerchantID;
        else {
          throw new ConfigurationException("Environment Must be set.");   
        }
      }
    }

    /// <summary>
    /// The Current Merchant Key
    /// </summary>
    public virtual string MerchantKey {
      get {
        if (Environment == EnvironmentType.Sandbox)
          return _sandboxMerchantKey;
        else if (Environment == EnvironmentType.Production)
          return _productionMerchantKey;
        else {
          throw new ConfigurationException("Environment Must be set.");   
        }
      }
    }

    private long _platformID;

    /// <summary>
    /// The &lt;platform-id&gt; tag should only be used by eCommerce providers who 
    /// make API requests on behalf of a merchant. The tag's value contains 
    /// a Google Checkout merchant ID that identifies the eCommerce provider.
    /// </summary>
    /// <remarks>
    /// <seealso href="http://code.google.com/apis/checkout/developer/index.html#tag_platform-id"/>
    /// </remarks>
    public virtual long PlatformID {
      get {
        return _platformID;
      }
      set {
        if (value > 0)
          _platformID = value;
      }
    }

    private bool _logging = false;

    /// <summary>
    /// Enable Logging
    /// </summary>
    public virtual bool Logging {
      get {
        return _logging;
      }
      set {
        _logging = value; 
      }
    }

    private string _logDirectory;

    /// <summary>
    /// The Log Directory
    /// </summary>
    public virtual string LogDirectory {
      get {
        return _logDirectory;
      }
      set {
        if (value != null && value.Length > 0)
          _logDirectory = value; 
      }
    }

    private string _currency = string.Empty;

    /// <summary>
    /// The currency attribute identifies the unit of currency associated 
    /// with the tag's value. The value of the currency attribute 
    /// should be a three-letter ISO 4217 currency code.
    /// </summary>
    public virtual string Currency {
      get {
        return _currency;
      }
      set {
        if (value != null && value.Length > 0)
          _currency = value;
      }
    }

    /// <summary>
    /// Create a New Config Section
    /// </summary>
    public GCheckoutConfigSection() {

    }

  }
}