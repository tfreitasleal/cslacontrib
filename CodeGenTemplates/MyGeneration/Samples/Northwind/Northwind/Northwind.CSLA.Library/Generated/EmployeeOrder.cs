
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using System.Configuration;
using System.IO;
using System.ComponentModel;
using Csla.Validation;
namespace Northwind.CSLA.Library
{
	/// <summary>
	///	EmployeeOrder Generated by MyGeneration using the CSLA Object Mapping template
	/// </summary>
	[Serializable()]
	[TypeConverter(typeof(EmployeeOrderConverter))]
	public partial class EmployeeOrder : BusinessBase<EmployeeOrder>, IVEHasBrokenRules
	{
		#region Business Methods
		private string _ErrorMessage = string.Empty;
		public string ErrorMessage
		{
			get { return _ErrorMessage; }
		}
		private int _OrderID;
		[System.ComponentModel.DataObjectField(true, true)]
		public int OrderID
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				if (_MyOrder != null) _OrderID = _MyOrder.OrderID;
				return _OrderID;
			}
		}
		private Order _MyOrder;
		[System.ComponentModel.DataObjectField(true, true)]
		public Order MyOrder
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				if (_MyOrder == null && _OrderID != 0) _MyOrder = Order.Get(_OrderID);
				return _MyOrder;
			}
		}
		private string _CustomerID = string.Empty;
		public string CustomerID
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				if (_MyCustomer != null) _CustomerID = _MyCustomer.CustomerID;
				return _CustomerID;
			}
		}
		private Customer _MyCustomer;
		public Customer MyCustomer
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				if (_MyCustomer == null && _CustomerID != null) _MyCustomer = Customer.Get((string)_CustomerID);
				return _MyCustomer;
			}
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (_MyCustomer != value)
				{
					_MyCustomer = value;
					_CustomerID = (value == null ? null : (string) value.CustomerID);
					PropertyHasChanged();
				}
			}
		}
		private string _OrderDate = string.Empty;
		public string OrderDate
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _OrderDate;
			}
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (value == null) value = string.Empty;
				_OrderDate = value;
				try
				{
					SmartDate tmp = new SmartDate(value);
					if (_OrderDate != tmp.ToString())
					{
						_OrderDate = tmp.ToString();
						// TODO: Any Cross Property Validation
					}
				}
				catch
				{
				}
				PropertyHasChanged();
			}
		}
		private string _RequiredDate = string.Empty;
		public string RequiredDate
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _RequiredDate;
			}
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (value == null) value = string.Empty;
				_RequiredDate = value;
				try
				{
					SmartDate tmp = new SmartDate(value);
					if (_RequiredDate != tmp.ToString())
					{
						_RequiredDate = tmp.ToString();
						// TODO: Any Cross Property Validation
					}
				}
				catch
				{
				}
				PropertyHasChanged();
			}
		}
		private string _ShippedDate = string.Empty;
		public string ShippedDate
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _ShippedDate;
			}
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (value == null) value = string.Empty;
				_ShippedDate = value;
				try
				{
					SmartDate tmp = new SmartDate(value);
					if (_ShippedDate != tmp.ToString())
					{
						_ShippedDate = tmp.ToString();
						// TODO: Any Cross Property Validation
					}
				}
				catch
				{
				}
				PropertyHasChanged();
			}
		}
		private int? _ShipVia;
		public int? ShipVia
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				if (_MyShipper != null) _ShipVia = _MyShipper.ShipperID;
				return _ShipVia;
			}
		}
		private Shipper _MyShipper;
		public Shipper MyShipper
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				if (_MyShipper == null && _ShipVia != null) _MyShipper = Shipper.Get((int)_ShipVia);
				return _MyShipper;
			}
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (_MyShipper != value)
				{
					_MyShipper = value;
					_ShipVia = (value == null ? null : (int?) value.ShipperID);
					PropertyHasChanged();
				}
			}
		}
		private decimal? _Freight;
		public decimal? Freight
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _Freight;
			}
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (_Freight != value)
				{
					_Freight = value;
					PropertyHasChanged();
				}
			}
		}
		private string _ShipName = string.Empty;
		public string ShipName
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _ShipName;
			}
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (_ShipName != value)
				{
					_ShipName = value;
					PropertyHasChanged();
				}
			}
		}
		private string _ShipAddress = string.Empty;
		public string ShipAddress
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _ShipAddress;
			}
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (_ShipAddress != value)
				{
					_ShipAddress = value;
					PropertyHasChanged();
				}
			}
		}
		private string _ShipCity = string.Empty;
		public string ShipCity
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _ShipCity;
			}
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (_ShipCity != value)
				{
					_ShipCity = value;
					PropertyHasChanged();
				}
			}
		}
		private string _ShipRegion = string.Empty;
		public string ShipRegion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _ShipRegion;
			}
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (_ShipRegion != value)
				{
					_ShipRegion = value;
					PropertyHasChanged();
				}
			}
		}
		private string _ShipPostalCode = string.Empty;
		public string ShipPostalCode
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _ShipPostalCode;
			}
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (_ShipPostalCode != value)
				{
					_ShipPostalCode = value;
					PropertyHasChanged();
				}
			}
		}
		private string _ShipCountry = string.Empty;
		public string ShipCountry
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _ShipCountry;
			}
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (_ShipCountry != value)
				{
					_ShipCountry = value;
					PropertyHasChanged();
				}
			}
		}
		// TODO: Check EmployeeOrder.GetIdValue to assure that the ID returned is unique
		/// <summary>
		/// Overrides Base GetIdValue - Used internally by CSLA to determine equality
		/// </summary>
		/// <returns>A Unique ID for the current EmployeeOrder</returns>
		protected override object GetIdValue()
		{
			return _OrderID;
		}
		// TODO: Replace base EmployeeOrder.ToString function as necessary
		/// <summary>
		/// Overrides Base ToString
		/// </summary>
		/// <returns>A string representation of current EmployeeOrder</returns>
		//public override string ToString()
		//{
		//  return base.ToString();
		//}
		#endregion
		#region ValidationRules
		[NonSerialized]
		private bool _CheckingBrokenRules=false;
		public IVEHasBrokenRules HasBrokenRules
		{
			get
			{
				if(_CheckingBrokenRules)return null;
				if (BrokenRulesCollection.Count > 0) return this;
				try
				{
					_CheckingBrokenRules=true;
				 IVEHasBrokenRules hasBrokenRules = null;
				if (_MyCustomer != null && (hasBrokenRules = _MyCustomer.HasBrokenRules) != null) return hasBrokenRules;
				if (_MyShipper != null && (hasBrokenRules = _MyShipper.HasBrokenRules) != null) return hasBrokenRules;
				 return hasBrokenRules;
				}
				finally
				{
					_CheckingBrokenRules=false;
				}
			}
		}
		public BrokenRulesCollection BrokenRules
		{
			get
			{
				IVEHasBrokenRules hasBrokenRules = HasBrokenRules;
				if (this.Equals(hasBrokenRules)) return BrokenRulesCollection;
				return (hasBrokenRules != null ? hasBrokenRules.BrokenRules : null);
			}
		}
		protected override void AddBusinessRules()
		{
			ValidationRules.AddRule(
				Csla.Validation.CommonRules.StringMaxLength,
				new Csla.Validation.CommonRules.MaxLengthRuleArgs("CustomerID", 5));
			ValidationRules.AddRule<EmployeeOrder>(OrderDateValid, "OrderDate");
			ValidationRules.AddRule<EmployeeOrder>(RequiredDateValid, "RequiredDate");
			ValidationRules.AddRule<EmployeeOrder>(ShippedDateValid, "ShippedDate");
			ValidationRules.AddRule(
				Csla.Validation.CommonRules.StringMaxLength,
				new Csla.Validation.CommonRules.MaxLengthRuleArgs("ShipName", 40));
			ValidationRules.AddRule(
				Csla.Validation.CommonRules.StringMaxLength,
				new Csla.Validation.CommonRules.MaxLengthRuleArgs("ShipAddress", 60));
			ValidationRules.AddRule(
				Csla.Validation.CommonRules.StringMaxLength,
				new Csla.Validation.CommonRules.MaxLengthRuleArgs("ShipCity", 15));
			ValidationRules.AddRule(
				Csla.Validation.CommonRules.StringMaxLength,
				new Csla.Validation.CommonRules.MaxLengthRuleArgs("ShipRegion", 15));
			ValidationRules.AddRule(
				Csla.Validation.CommonRules.StringMaxLength,
				new Csla.Validation.CommonRules.MaxLengthRuleArgs("ShipPostalCode", 10));
			ValidationRules.AddRule(
				Csla.Validation.CommonRules.StringMaxLength,
				new Csla.Validation.CommonRules.MaxLengthRuleArgs("ShipCountry", 15));
			// TODO:  Add other validation rules
		}
		private static bool OrderDateValid(EmployeeOrder target, Csla.Validation.RuleArgs e)
		{
			try
			{
				DateTime tmp = SmartDate.StringToDate(target._OrderDate);
			}
			catch
			{
				e.Description = "Invalid Date";
				return false;
			}
			return true;
		}
		private static bool RequiredDateValid(EmployeeOrder target, Csla.Validation.RuleArgs e)
		{
			try
			{
				DateTime tmp = SmartDate.StringToDate(target._RequiredDate);
			}
			catch
			{
				e.Description = "Invalid Date";
				return false;
			}
			return true;
		}
		private static bool ShippedDateValid(EmployeeOrder target, Csla.Validation.RuleArgs e)
		{
			try
			{
				DateTime tmp = SmartDate.StringToDate(target._ShippedDate);
			}
			catch
			{
				e.Description = "Invalid Date";
				return false;
			}
			return true;
		}
		// Sample data comparison validation rule
		//private bool StartDateGTEndDate(object target, Csla.Validation.RuleArgs e)
		//{
		//	if (_started > _ended)
		//	{
		//		e.Description = "Start date can't be after end date";
		//		return false;
		//	}
		//	else
		//		return true;
		//}
		#endregion
		#region Authorization Rules
		protected override void AddAuthorizationRules()
		{
			//TODO: Who can read/write which fields
			//AuthorizationRules.AllowRead(OrderID, "<Role(s)>");
			//AuthorizationRules.AllowRead(CustomerID, "<Role(s)>");
			//AuthorizationRules.AllowWrite(CustomerID, "<Role(s)>");
			//AuthorizationRules.AllowRead(OrderDate, "<Role(s)>");
			//AuthorizationRules.AllowWrite(OrderDate, "<Role(s)>");
			//AuthorizationRules.AllowRead(RequiredDate, "<Role(s)>");
			//AuthorizationRules.AllowWrite(RequiredDate, "<Role(s)>");
			//AuthorizationRules.AllowRead(ShippedDate, "<Role(s)>");
			//AuthorizationRules.AllowWrite(ShippedDate, "<Role(s)>");
			//AuthorizationRules.AllowRead(ShipVia, "<Role(s)>");
			//AuthorizationRules.AllowWrite(ShipVia, "<Role(s)>");
			//AuthorizationRules.AllowRead(Freight, "<Role(s)>");
			//AuthorizationRules.AllowWrite(Freight, "<Role(s)>");
			//AuthorizationRules.AllowRead(ShipName, "<Role(s)>");
			//AuthorizationRules.AllowWrite(ShipName, "<Role(s)>");
			//AuthorizationRules.AllowRead(ShipAddress, "<Role(s)>");
			//AuthorizationRules.AllowWrite(ShipAddress, "<Role(s)>");
			//AuthorizationRules.AllowRead(ShipCity, "<Role(s)>");
			//AuthorizationRules.AllowWrite(ShipCity, "<Role(s)>");
			//AuthorizationRules.AllowRead(ShipRegion, "<Role(s)>");
			//AuthorizationRules.AllowWrite(ShipRegion, "<Role(s)>");
			//AuthorizationRules.AllowRead(ShipPostalCode, "<Role(s)>");
			//AuthorizationRules.AllowWrite(ShipPostalCode, "<Role(s)>");
			//AuthorizationRules.AllowRead(ShipCountry, "<Role(s)>");
			//AuthorizationRules.AllowWrite(ShipCountry, "<Role(s)>");
		}
		public static bool CanAddObject()
		{
			// TODO: Can Add Authorization
			//return Csla.ApplicationContext.User.IsInRole("ProjectManager");
			return true;
		}
		public static bool CanGetObject()
		{
			// TODO: CanGet Authorization
			return true;
		}
		public static bool CanDeleteObject()
		{
			// TODO: CanDelete Authorization
			//bool result = false;
			//if (Csla.ApplicationContext.User.IsInRole("ProjectManager"))result = true;
			//if (Csla.ApplicationContext.User.IsInRole("Administrator"))result = true;
			//return result;
			return true;
		}
		public static bool CanEditObject()
		{
			// TODO: CanEdit Authorization
			//return Csla.ApplicationContext.User.IsInRole("ProjectManager");
			return true;
		}
		#endregion
		#region Factory Methods
		public int CurrentEditLevel
		{ get { return EditLevel; } }
		internal static EmployeeOrder New()
		{
			return new EmployeeOrder();
		}
		internal static EmployeeOrder Get(SafeDataReader dr)
		{
			return new EmployeeOrder(dr);
		}
		public EmployeeOrder()
		{
			MarkAsChild();
			_OrderID = Order.NextOrderID;
			_Freight = _EmployeeOrderExtension.DefaultFreight;
			ValidationRules.CheckRules();
		}
		internal EmployeeOrder(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion
		#region Data Access Portal
		private void Fetch(SafeDataReader dr)
		{
			Database.LogInfo("EmployeeOrder.FetchDR", GetHashCode());
			try
			{
				_OrderID = dr.GetInt32("OrderID");
				_CustomerID = dr.GetString("CustomerID");
				_OrderDate = dr.GetSmartDate("OrderDate").Text;
				_RequiredDate = dr.GetSmartDate("RequiredDate").Text;
				_ShippedDate = dr.GetSmartDate("ShippedDate").Text;
				_ShipVia = (int?)dr.GetValue("ShipVia");
				_Freight = (decimal?)dr.GetValue("Freight");
				_ShipName = dr.GetString("ShipName");
				_ShipAddress = dr.GetString("ShipAddress");
				_ShipCity = dr.GetString("ShipCity");
				_ShipRegion = dr.GetString("ShipRegion");
				_ShipPostalCode = dr.GetString("ShipPostalCode");
				_ShipCountry = dr.GetString("ShipCountry");
			}
			catch (Exception ex) // FKItem Fetch
			{
				Database.LogException("EmployeeOrder.FetchDR", ex);
				throw new DbCslaException("EmployeeOrder.Fetch", ex);
			}
			MarkOld();
		}
		internal void Insert(Employee myEmployee)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			SqlConnection cn = (SqlConnection)ApplicationContext.LocalContext["cn"];
			Order.Add(cn, ref _OrderID, _MyCustomer, myEmployee, new SmartDate(_OrderDate), new SmartDate(_RequiredDate), new SmartDate(_ShippedDate), _MyShipper, _Freight, _ShipName, _ShipAddress, _ShipCity, _ShipRegion, _ShipPostalCode, _ShipCountry);
			MarkOld();
		}
		internal void Update(Employee myEmployee)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			SqlConnection cn = (SqlConnection)ApplicationContext.LocalContext["cn"];
			Order.Update(cn, ref _OrderID, _MyCustomer, myEmployee, new SmartDate(_OrderDate), new SmartDate(_RequiredDate), new SmartDate(_ShippedDate), _MyShipper, _Freight, _ShipName, _ShipAddress, _ShipCity, _ShipRegion, _ShipPostalCode, _ShipCountry);
			MarkOld();
		}
		internal void DeleteSelf(Employee myEmployee)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			// if we're new then don't update the database
			if (this.IsNew) return;
			SqlConnection cn = (SqlConnection)ApplicationContext.LocalContext["cn"];
			Order.Remove(cn, _OrderID);
			MarkNew();
		}
		#endregion
		// Standard Default Code
		#region extension
		EmployeeOrderExtension _EmployeeOrderExtension = new EmployeeOrderExtension();
		[Serializable()]
		partial class EmployeeOrderExtension : extensionBase
		{
		}
		[Serializable()]
		class extensionBase
		{
			// Default Values
			public virtual decimal? DefaultFreight
			{
				get { return 0; }
			}
			// Authorization Rules
			public virtual void AddAuthorizationRules(Csla.Security.AuthorizationRules rules)
			{
				// Needs to be overriden to add new authorization rules
			}
			// Instance Authorization Rules
			public virtual void AddInstanceAuthorizationRules(Csla.Security.AuthorizationRules rules)
			{
				// Needs to be overriden to add new authorization rules
			}
			// Validation Rules
			public virtual void AddValidationRules(Csla.Validation.ValidationRules rules)
			{
				// Needs to be overriden to add new validation rules
			}
			// InstanceValidation Rules
			public virtual void AddInstanceValidationRules(Csla.Validation.ValidationRules rules)
			{
				// Needs to be overriden to add new validation rules
			}
		}
		#endregion
	} // Class
	#region Converter
	internal class EmployeeOrderConverter : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
		{
			if (destType == typeof(string) && value is EmployeeOrder)
			{
				// Return the ToString value
				return ((EmployeeOrder)value).ToString();
			}
			return base.ConvertTo(context, culture, value, destType);
		}
	}
	#endregion
} // Namespace


//// The following is a sample Extension File.  You can use it to create EmployeeOrderExt.cs
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Csla;

//namespace Northwind.CSLA.Library
//{
//  public partial class EmployeeOrder
//  {
//    partial class EmployeeOrderExtension : extensionBase
//    {
//      // TODO: Override automatic defaults
//      public virtual decimal? DefaultFreight
//      {
//        get { return 0; }
//      }
//      public new void AddAuthorizationRules(Csla.Security.AuthorizationRules rules)
//      {
//        //rules.AllowRead(Dbid, "<Role(s)>");
//      }
//      public new void AddInstanceAuthorizationRules(Csla.Security.AuthorizationRules rules)
//      {
//        //rules.AllowInstanceRead(Dbid, "<Role(s)>");
//      }
//      public new void AddValidationRules(Csla.Validation.ValidationRules rules)
//      {
//        rules.AddRule(
//          Csla.Validation.CommonRules.StringMaxLength,
//          new Csla.Validation.CommonRules.MaxLengthRuleArgs("Name", 100));
//      }
//      public new void AddInstanceValidationRules(Csla.Validation.ValidationRules rules)
//      {
//        rules.AddInstanceRule(/* Instance Validation Rule */);
//      }
//    }
//  }
//}
