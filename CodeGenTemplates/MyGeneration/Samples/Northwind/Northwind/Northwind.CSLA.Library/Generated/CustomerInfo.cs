
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using System.Configuration;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
namespace Northwind.CSLA.Library
{
	public delegate void CustomerInfoEvent(object sender);
	/// <summary>
	///	CustomerInfo Generated by MyGeneration using the CSLA Object Mapping template
	/// </summary>
	[Serializable()]
	[TypeConverter(typeof(CustomerInfoConverter))]
	public partial class CustomerInfo : ReadOnlyBase<CustomerInfo>, IDisposable
	{
		public event CustomerInfoEvent Changed;
		private void OnChange()
		{
			if (Changed != null) Changed(this);
		}
		#region Collection
		protected static List<CustomerInfo> _AllList = new List<CustomerInfo>();
		private static Dictionary<string, CustomerInfo> _AllByPrimaryKey = new Dictionary<string, CustomerInfo>();
		private static void ConvertListToDictionary()
		{
			List<CustomerInfo> remove = new List<CustomerInfo>();
			foreach (CustomerInfo tmp in _AllList)
			{
				_AllByPrimaryKey[tmp.CustomerID.ToString()]=tmp; // Primary Key
				remove.Add(tmp);
			}
			foreach (CustomerInfo tmp in remove)
				_AllList.Remove(tmp);
		}
		internal static void AddList(CustomerInfoList lst)
		{
			foreach (CustomerInfo item in lst) _AllList.Add(item);
		}
		public static CustomerInfo GetExistingByPrimaryKey(string customerID)
		{
			ConvertListToDictionary();
			string key = customerID.ToString();
			if (_AllByPrimaryKey.ContainsKey(key)) return _AllByPrimaryKey[key]; 
			return null;
		}
		#endregion
		#region Business Methods
		private string _ErrorMessage = string.Empty;
		public string ErrorMessage
		{
			get { return _ErrorMessage; }
		}
		protected Customer _Editable;
		private IVEHasBrokenRules HasBrokenRules
		{
			get
			{
				IVEHasBrokenRules hasBrokenRules = null;
				if (_Editable != null)
					hasBrokenRules = _Editable.HasBrokenRules;
				return hasBrokenRules;
			}
		}
		private string _CustomerID = string.Empty;
		[System.ComponentModel.DataObjectField(true, true)]
		public string CustomerID
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _CustomerID;
			}
		}
		private string _CompanyName = string.Empty;
		public string CompanyName
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _CompanyName;
			}
		}
		private string _ContactName = string.Empty;
		public string ContactName
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _ContactName;
			}
		}
		private string _ContactTitle = string.Empty;
		public string ContactTitle
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _ContactTitle;
			}
		}
		private string _Address = string.Empty;
		public string Address
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _Address;
			}
		}
		private string _City = string.Empty;
		public string City
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _City;
			}
		}
		private string _Region = string.Empty;
		public string Region
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _Region;
			}
		}
		private string _PostalCode = string.Empty;
		public string PostalCode
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _PostalCode;
			}
		}
		private string _Country = string.Empty;
		public string Country
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _Country;
			}
		}
		private string _Phone = string.Empty;
		public string Phone
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _Phone;
			}
		}
		private string _Fax = string.Empty;
		public string Fax
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _Fax;
			}
		}
		private int _CustomerCustomerCustomerDemoCount = 0;
		/// <summary>
		/// Count of CustomerCustomerCustomerDemos for this Customer
		/// </summary>
		public int CustomerCustomerCustomerDemoCount
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _CustomerCustomerCustomerDemoCount;
			}
		}
		private CustomerCustomerDemoInfoList _CustomerCustomerCustomerDemos = null;
		[TypeConverter(typeof(CustomerCustomerDemoInfoListConverter))]
		public CustomerCustomerDemoInfoList CustomerCustomerCustomerDemos
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				if (_CustomerCustomerCustomerDemoCount > 0 && _CustomerCustomerCustomerDemos == null)
					_CustomerCustomerCustomerDemos = CustomerCustomerDemoInfoList.GetByCustomerID(_CustomerID);
				return _CustomerCustomerCustomerDemos;
			}
		}
		private int _CustomerOrderCount = 0;
		/// <summary>
		/// Count of CustomerOrders for this Customer
		/// </summary>
		public int CustomerOrderCount
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _CustomerOrderCount;
			}
		}
		private OrderInfoList _CustomerOrders = null;
		[TypeConverter(typeof(OrderInfoListConverter))]
		public OrderInfoList CustomerOrders
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				if (_CustomerOrderCount > 0 && _CustomerOrders == null)
					_CustomerOrders = OrderInfoList.GetByCustomerID(_CustomerID);
				return _CustomerOrders;
			}
		}
		// TODO: Replace base CustomerInfo.ToString function as necessary
		/// <summary>
		/// Overrides Base ToString
		/// </summary>
		/// <returns>A string representation of current CustomerInfo</returns>
		//public override string ToString()
		//{
		//  return base.ToString();
		//}
		// TODO: Check CustomerInfo.GetIdValue to assure that the ID returned is unique
		/// <summary>
		/// Overrides Base GetIdValue - Used internally by CSLA to determine equality
		/// </summary>
		/// <returns>A Unique ID for the current CustomerInfo</returns>
		protected override object GetIdValue()
		{
			return _CustomerID;
		}
		#endregion
		#region Factory Methods
		private CustomerInfo()
		{/* require use of factory methods */
			_AllList.Add(this);
		}
		public void Dispose()
		{
			_AllList.Remove(this);
			_AllByPrimaryKey.Remove(CustomerID.ToString());
		}
		public virtual Customer Get()
		{
			return _Editable = Customer.Get(_CustomerID);
		}
		public static void Refresh(Customer tmp)
		{
			CustomerInfo tmpInfo = GetExistingByPrimaryKey(tmp.CustomerID);
			if (tmpInfo == null) return;
			tmpInfo.RefreshFields(tmp);
		}
		private void RefreshFields(Customer tmp)
		{
			_CompanyName = tmp.CompanyName;
			_ContactName = tmp.ContactName;
			_ContactTitle = tmp.ContactTitle;
			_Address = tmp.Address;
			_City = tmp.City;
			_Region = tmp.Region;
			_PostalCode = tmp.PostalCode;
			_Country = tmp.Country;
			_Phone = tmp.Phone;
			_Fax = tmp.Fax;
			_CustomerInfoExtension.Refresh(this);
			OnChange();// raise an event
		}
		public static CustomerInfo Get(string customerID)
		{
			//if (!CanGetObject())
			//  throw new System.Security.SecurityException("User not authorized to view a Customer");
			try
			{
				CustomerInfo tmp = GetExistingByPrimaryKey(customerID);
				if (tmp == null)
				{
					tmp = DataPortal.Fetch<CustomerInfo>(new PKCriteria(customerID));
					_AllList.Add(tmp);
				}
				if (tmp.ErrorMessage == "No Record Found") tmp = null;
				return tmp;
			}
			catch (Exception ex)
			{
				throw new DbCslaException("Error on CustomerInfo.Get", ex);
			}
		}
		#endregion
		#region Data Access Portal
		internal CustomerInfo(SafeDataReader dr)
		{
			Database.LogInfo("CustomerInfo.Constructor", GetHashCode());
			try
			{
				ReadData(dr);
			}
			catch (Exception ex)
			{
				Database.LogException("CustomerInfo.Constructor", ex);
				throw new DbCslaException("CustomerInfo.Constructor", ex);
			}
		}
		[Serializable()]
		protected class PKCriteria
		{
			private string _CustomerID;
			public string CustomerID
			{ get { return _CustomerID; } }
			public PKCriteria(string customerID)
			{
				_CustomerID = customerID;
			}
		}
		private void ReadData(SafeDataReader dr)
		{
			Database.LogInfo("CustomerInfo.ReadData", GetHashCode());
			try
			{
				_CustomerID = dr.GetString("CustomerID");
				_CompanyName = dr.GetString("CompanyName");
				_ContactName = dr.GetString("ContactName");
				_ContactTitle = dr.GetString("ContactTitle");
				_Address = dr.GetString("Address");
				_City = dr.GetString("City");
				_Region = dr.GetString("Region");
				_PostalCode = dr.GetString("PostalCode");
				_Country = dr.GetString("Country");
				_Phone = dr.GetString("Phone");
				_Fax = dr.GetString("Fax");
				_CustomerCustomerCustomerDemoCount = dr.GetInt32("CustomerCustomerDemoCount");
				_CustomerOrderCount = dr.GetInt32("OrderCount");
			}
			catch (Exception ex)
			{
				Database.LogException("CustomerInfo.ReadData", ex);
				_ErrorMessage = ex.Message;
				throw new DbCslaException("CustomerInfo.ReadData", ex);
			}
		}
		private void DataPortal_Fetch(PKCriteria criteria)
		{
			Database.LogInfo("CustomerInfo.DataPortal_Fetch", GetHashCode());
			try
			{
				using (SqlConnection cn = Database.Northwind_SqlConnection)
				{
					ApplicationContext.LocalContext["cn"] = cn;
					using (SqlCommand cm = cn.CreateCommand())
					{
						cm.CommandType = CommandType.StoredProcedure;
						cm.CommandText = "getCustomer";
						cm.Parameters.AddWithValue("@CustomerID", criteria.CustomerID);
						using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
						{
							if (!dr.Read())
							{
								_ErrorMessage = "No Record Found";
								return;
							}
							ReadData(dr);
						}
					}
					// removing of item only needed for local data portal
					if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Client)
						ApplicationContext.LocalContext.Remove("cn");
				}
			}
			catch (Exception ex)
			{
				Database.LogException("CustomerInfo.DataPortal_Fetch", ex);
				_ErrorMessage = ex.Message;
				throw new DbCslaException("CustomerInfo.DataPortal_Fetch", ex);
			}
		}
		#endregion
		// Standard Refresh
		#region extension
		CustomerInfoExtension _CustomerInfoExtension = new CustomerInfoExtension();
		[Serializable()]
		partial class CustomerInfoExtension : extensionBase {}
		[Serializable()]
		class extensionBase
		{
			// Default Refresh
			public virtual void Refresh(CustomerInfo tmp) { }
		}
		#endregion
	} // Class
	#region Converter
	internal class CustomerInfoConverter : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
		{
			if (destType == typeof(string) && value is CustomerInfo)
			{
				// Return the ToString value
				return ((CustomerInfo)value).ToString();
			}
			return base.ConvertTo(context, culture, value, destType);
		}
	}
	#endregion
} // Namespace
