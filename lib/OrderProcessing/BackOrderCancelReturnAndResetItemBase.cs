/*************************************************
 * Copyright (C) 2007 Google Inc.
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
using System;
using System.Collections;
using GCheckout.Util;

namespace GCheckout.OrderProcessing
{
	/// <summary>
	/// backorders, returns, cancel items and reset
	/// all use the same format, the only real difference
	/// is the root message is different.
	/// Because of this, we are creating a base
	/// </summary>
	public abstract class BackOrderCancelReturnAndResetItemBase : GCheckoutRequest
	{
    /// <summary>
    /// The Google Order Number
    /// </summary>
    protected string _googleOrderNumber = null;
    /// <summary>
    /// Send an Email when the request is received by Google
    /// </summary>
    protected bool _sendEmail = false;
    /// <summary>
    /// Was the Email Flag set by the user.
    /// </summary>
    protected bool _sendEmailSpecified = false;

    /// <summary>
    /// The items that are added to the request
    /// </summary>
    protected ArrayList _items = new ArrayList();

    /// <summary>
    /// The Items that were added to the request
    /// </summary>
    protected AutoGen.ItemId[] Items {
      get {
        AutoGen.ItemId[] retVal = new AutoGen.ItemId[_items.Count];
        _items.CopyTo(retVal, 0);
        return retVal;
      }
    }

    /// <summary>
    /// The Google Order Number
    /// </summary>
    public string GoogleOrderNumber {
      get {
        return _googleOrderNumber;
      }
    }

    /// <summary>
    /// The &lt;send-email&gt; tag indicates whether Google Checkout 
    /// should email the buyer 
    /// </summary>
    public bool SendEmail {
      get {
        return _sendEmail;
      }
      set {
        _sendEmail = value;
        _sendEmailSpecified = true;
      }
    }

    /// <summary>
    /// Create a new &lt;reset-items-shipping-information&gt;
    /// API request message using the Configuration Settings
    /// </summary>
    /// <param name="GoogleOrderNumber">The Google Order Number</param>
    public BackOrderCancelReturnAndResetItemBase(string GoogleOrderNumber) {
      _MerchantID = GCheckoutConfigurationHelper.MerchantID.ToString();
      _MerchantKey = GCheckoutConfigurationHelper.MerchantKey;
      _Environment = GCheckoutConfigurationHelper.Environment;
      _googleOrderNumber = GoogleOrderNumber;
    }

    /// <summary>
    /// Create a new &lt;reset-items-shipping-information&gt;
    /// API request message
    /// </summary>
    /// <param name="merchantID">Google Checkout Merchant ID</param>
    /// <param name="merchantKey">Google Checkout Merchant Key</param>
    /// <param name="env">A String representation of 
    /// <see cref="EnvironmentType"/></param>
    /// <param name="GoogleOrderNumber">The Google Order Number</param>
    public BackOrderCancelReturnAndResetItemBase(string merchantID, 
      string merchantKey, string env, string GoogleOrderNumber) {
      _MerchantID = merchantID;
      _MerchantKey = merchantKey;
      _Environment = StringToEnvironment(env);
      _googleOrderNumber = GoogleOrderNumber;
    }

    /// <summary>
    /// Add a new item based on a MerchantItemID
    /// </summary>
    /// <param name="merchantItemID">
    /// The &lt;merchant-item-id&gt; tag contains a value,
    /// such as a stock keeping unit (SKU), 
    /// that you use to uniquely identify an item.
    /// </param>
    public void AddMerchantItemId(string merchantItemID) {
      AutoGen.ItemId item = new GCheckout.AutoGen.ItemId();
      item.merchantitemid = merchantItemID;
      _items.Add(item);
    }

  }
}
