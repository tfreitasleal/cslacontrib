
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
	///	CustomerDemographicCustomerCustomerDemos Generated by MyGeneration using the CSLA Object Mapping template
	/// </summary>
	[Serializable()]
	[TypeConverter(typeof(CustomerDemographicCustomerCustomerDemosConverter))]
	public partial class CustomerDemographicCustomerCustomerDemos : BusinessListBase<CustomerDemographicCustomerCustomerDemos, CustomerDemographicCustomerCustomerDemo>, ICustomTypeDescriptor, IVEHasBrokenRules
	{
		#region Business Methods
		private string _ErrorMessage = string.Empty;
		public string ErrorMessage
		{
			get { return _ErrorMessage; }
		}
		// Many To Many
		public CustomerDemographicCustomerCustomerDemo this[Customer myCustomer]
		{
			get
			{
				foreach (CustomerDemographicCustomerCustomerDemo customerCustomerDemo in this)
					if (customerCustomerDemo.CustomerID == myCustomer.CustomerID)
						return customerCustomerDemo;
				return null;
			}
		}
		public new System.Collections.Generic.IList<CustomerDemographicCustomerCustomerDemo> Items
		{
			get { return base.Items; }
		}
		public CustomerDemographicCustomerCustomerDemo GetItem(Customer myCustomer)
		{
			foreach (CustomerDemographicCustomerCustomerDemo customerCustomerDemo in this)
				if (customerCustomerDemo.CustomerID == myCustomer.CustomerID)
					return customerCustomerDemo;
			return null;
		}
		public CustomerDemographicCustomerCustomerDemo Add(Customer myCustomer)// Many to Many with required fields
		{
			if (!Contains(myCustomer))
			{
				CustomerDemographicCustomerCustomerDemo customerCustomerDemo =	CustomerDemographicCustomerCustomerDemo.New(myCustomer);
				this.Add(customerCustomerDemo);
				return customerCustomerDemo;
			}
			else
				throw new InvalidOperationException("customerCustomerDemo already exists");
		}
		public void Remove(Customer myCustomer)
		{
			foreach (CustomerDemographicCustomerCustomerDemo customerCustomerDemo in this)
			{
				if (customerCustomerDemo.CustomerID == myCustomer.CustomerID)
				{
					Remove(customerCustomerDemo);
					break;
				}
			}
		}
		public bool Contains(Customer myCustomer)
		{
			foreach (CustomerDemographicCustomerCustomerDemo customerCustomerDemo in this)
				if (customerCustomerDemo.CustomerID == myCustomer.CustomerID)
					return true;
			return false;
		}
		public bool ContainsDeleted(Customer myCustomer)
		{
			foreach (CustomerDemographicCustomerCustomerDemo customerCustomerDemo in DeletedList)
				if (customerCustomerDemo.CustomerID == myCustomer.CustomerID)
					return true;
			return false;
		}
		#endregion
		#region ValidationRules
		public IVEHasBrokenRules HasBrokenRules
		{
			get
			{
				IVEHasBrokenRules hasBrokenRules=null;
				foreach(CustomerDemographicCustomerCustomerDemo customerDemographicCustomerCustomerDemo in this)
					if ((hasBrokenRules = customerDemographicCustomerCustomerDemo.HasBrokenRules) != null) return hasBrokenRules;
				return hasBrokenRules;
			}
		}
		public BrokenRulesCollection BrokenRules
		{
			get
			{
			IVEHasBrokenRules hasBrokenRules = HasBrokenRules;
			return (hasBrokenRules != null ? hasBrokenRules.BrokenRules : null);
			}
		}
		#endregion
		#region Factory Methods
		internal static CustomerDemographicCustomerCustomerDemos New()
		{
			return new CustomerDemographicCustomerCustomerDemos();
		}
		internal static CustomerDemographicCustomerCustomerDemos Get(SafeDataReader dr)
		{
			return new CustomerDemographicCustomerCustomerDemos(dr);
		}
		public static CustomerDemographicCustomerCustomerDemos GetByCustomerTypeID(string customerTypeID)
		{
			try
			{
				return DataPortal.Fetch<CustomerDemographicCustomerCustomerDemos>(new CustomerTypeIDCriteria(customerTypeID));
			}
			catch (Exception ex)
			{
				throw new DbCslaException("Error on CustomerDemographicCustomerCustomerDemos.GetByCustomerTypeID", ex);
			}
		}
		private CustomerDemographicCustomerCustomerDemos()
		{
			MarkAsChild();
		}
		internal CustomerDemographicCustomerCustomerDemos(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion
		#region Data Access Portal
		// called to load data from the database
		private void Fetch(SafeDataReader dr)
		{
			this.RaiseListChangedEvents = false;
			while (dr.Read())
				this.Add(CustomerDemographicCustomerCustomerDemo.Get(dr));
			this.RaiseListChangedEvents = true;
		}
		[Serializable()]
		private class CustomerTypeIDCriteria
		{
			public CustomerTypeIDCriteria(string customerTypeID)
			{
				_CustomerTypeID = customerTypeID;
			}
			private string _CustomerTypeID;
			public string CustomerTypeID
			{
				get { return _CustomerTypeID; }
				set { _CustomerTypeID = value; }
			}
		}
		private void DataPortal_Fetch(CustomerTypeIDCriteria criteria)
		{
			this.RaiseListChangedEvents = false;
			Database.LogInfo("CustomerDemographicCustomerCustomerDemos.DataPortal_FetchCustomerTypeID", GetHashCode());
			try
			{
				using (SqlConnection cn = Database.Northwind_SqlConnection)
				{
					using (SqlCommand cm = cn.CreateCommand())
					{
						cm.CommandType = CommandType.StoredProcedure;
						cm.CommandText = "getCustomerCustomerDemosByCustomerTypeID";
						cm.Parameters.AddWithValue("@CustomerTypeID", criteria.CustomerTypeID);
						using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
						{
							while (dr.Read()) this.Add(new CustomerDemographicCustomerCustomerDemo(dr));
						}
					}
				}
			}
			catch (Exception ex)
			{
				Database.LogException("CustomerDemographicCustomerCustomerDemos.DataPortal_FetchCustomerTypeID", ex);
				throw new DbCslaException("CustomerDemographicCustomerCustomerDemos.DataPortal_Fetch", ex);
			}
			this.RaiseListChangedEvents = true;
		}
		internal void Update(CustomerDemographic customerDemographic)
		{
			this.RaiseListChangedEvents = false;
			try
			{
				// update (thus deleting) any deleted child objects
				foreach (CustomerDemographicCustomerCustomerDemo obj in DeletedList)
					obj.Delete();// TODO: Should this be SQLDelete
				// now that they are deleted, remove them from memory too
				DeletedList.Clear();
				// add/update any current child objects
				foreach (CustomerDemographicCustomerCustomerDemo obj in this)
				{
					if (obj.IsNew)
						obj.Insert(customerDemographic);
					else
						obj.Update(customerDemographic);
				}
			}
			finally
			{
				this.RaiseListChangedEvents = true;
			}
		}
		#endregion
		#region ICustomTypeDescriptor impl
		public String GetClassName()
		{ return TypeDescriptor.GetClassName(this, true); }
		public AttributeCollection GetAttributes()
		{ return TypeDescriptor.GetAttributes(this, true); }
		public String GetComponentName()
		{ return TypeDescriptor.GetComponentName(this, true); }
		public TypeConverter GetConverter()
		{ return TypeDescriptor.GetConverter(this, true); }
		public EventDescriptor GetDefaultEvent()
		{ return TypeDescriptor.GetDefaultEvent(this, true); }
		public PropertyDescriptor GetDefaultProperty()
		{ return TypeDescriptor.GetDefaultProperty(this, true); }
		public object GetEditor(Type editorBaseType)
		{ return TypeDescriptor.GetEditor(this, editorBaseType, true); }
		public EventDescriptorCollection GetEvents(Attribute[] attributes)
		{ return TypeDescriptor.GetEvents(this, attributes, true); }
		public EventDescriptorCollection GetEvents()
		{ return TypeDescriptor.GetEvents(this, true); }
		public object GetPropertyOwner(PropertyDescriptor pd)
		{ return this; }
		/// <summary>
		/// Called to get the properties of this type. Returns properties with certain
		/// attributes. this restriction is not implemented here.
		/// </summary>
		/// <param name="attributes"></param>
		/// <returns></returns>
		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{ return GetProperties(); }
		/// <summary>
		/// Called to get the properties of this type.
		/// </summary>
		/// <returns></returns>
		public PropertyDescriptorCollection GetProperties()
		{
			// Create a collection object to hold property descriptors
			PropertyDescriptorCollection pds = new PropertyDescriptorCollection(null);
			// Iterate the list 
			for (int i = 0; i < this.Items.Count; i++)
			{
				// Create a property descriptor for the item and add to the property descriptor collection
				CustomerDemographicCustomerCustomerDemosPropertyDescriptor pd = new CustomerDemographicCustomerCustomerDemosPropertyDescriptor(this, i);
				pds.Add(pd);
			}
			// return the property descriptor collection
			return pds;
		}
		#endregion
	} // Class
	#region Property Descriptor
	/// <summary>
	/// Summary description for CollectionPropertyDescriptor.
	/// </summary>
	public partial class CustomerDemographicCustomerCustomerDemosPropertyDescriptor : vlnListPropertyDescriptor
	{
		private CustomerDemographicCustomerCustomerDemo Item { get { return (CustomerDemographicCustomerCustomerDemo) _Item;} }
		public CustomerDemographicCustomerCustomerDemosPropertyDescriptor(CustomerDemographicCustomerCustomerDemos collection, int index):base(collection, index){;}
	}
	#endregion
	#region Converter
	internal class CustomerDemographicCustomerCustomerDemosConverter : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
		{
			if (destType == typeof(string) && value is CustomerDemographicCustomerCustomerDemos)
			{
				// Return department and department role separated by comma.
				return ((CustomerDemographicCustomerCustomerDemos) value).Items.Count.ToString() + " CustomerCustomerDemos";
			}
			return base.ConvertTo(context, culture, value, destType);
		}
	}
	#endregion
} // Namespace
