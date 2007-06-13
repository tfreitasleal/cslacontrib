
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
	/// <summary>
	///	TerritoryInfoList Generated by MyGeneration using the CSLA Object Mapping template
	/// </summary>
	[Serializable()]
	[TypeConverter(typeof(TerritoryInfoListConverter))]
	public partial class TerritoryInfoList : ReadOnlyListBase<TerritoryInfoList, TerritoryInfo>, ICustomTypeDescriptor, IDisposable
	{
		#region Business Methods
		internal new IList<TerritoryInfo> Items
		{ get { return base.Items; } }
		public void AddEvents()
		{
			foreach (TerritoryInfo tmp in this)
			{
				tmp.Changed += new TerritoryInfoEvent(tmp_Changed);
			}
		}
		void tmp_Changed(object sender)
		{
			for (int i = 0; i < Count; i++)
			{
				if (base[i] == sender)
					this.OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, i));
			}
		}
		public void Dispose()
		{
			foreach (TerritoryInfo tmp in this)
			{
				tmp.Changed -= new TerritoryInfoEvent(tmp_Changed);
			}
		}
		#endregion
		#region Factory Methods
		/// <summary>
		/// Return a list of all projects.
		/// </summary>
		public static TerritoryInfoList Get()
		{
			try
			{
				TerritoryInfoList tmp = DataPortal.Fetch<TerritoryInfoList>();
				TerritoryInfo.AddList(tmp);
				tmp.AddEvents();
				return tmp;
			}
			catch (Exception ex)
			{
				throw new DbCslaException("Error on TerritoryInfoList.Get", ex);
			}
		}
		// TODO: Add alternative gets - 
		//public static TerritoryInfoList Get(<criteria>)
		//{
		//	try
		//	{
		//  	return DataPortal.Fetch<TerritoryInfoList>(new FilteredCriteria(<criteria>));
		//	}
		//	catch (Exception ex)
		//	{
		//		throw new DbCslaException("Error on TerritoryInfoList.Get", ex);
		//	}
		//}
		public static TerritoryInfoList GetByRegionID(int regionID)
		{
			try
			{
				TerritoryInfoList tmp = DataPortal.Fetch<TerritoryInfoList>(new RegionIDCriteria(regionID));
				TerritoryInfo.AddList(tmp);
				tmp.AddEvents();
				return tmp;
			}
			catch (Exception ex)
			{
				throw new DbCslaException("Error on TerritoryInfoList.GetByRegionID", ex);
			}
		}
		private TerritoryInfoList()
		{ /* require use of factory methods */ }
		#endregion
		#region Data Access Portal
		private void DataPortal_Fetch()
		{
			this.RaiseListChangedEvents = false;
			Database.LogInfo("TerritoryInfoList.DataPortal_Fetch", GetHashCode());
			try
			{
				using (SqlConnection cn = Database.Northwind_SqlConnection)
				{
					using (SqlCommand cm = cn.CreateCommand())
					{
						cm.CommandType = CommandType.StoredProcedure;
						cm.CommandText = "getTerritories";
						using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
						{
							IsReadOnly = false;
							while (dr.Read()) this.Add(new TerritoryInfo(dr));
							IsReadOnly = true;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Database.LogException("TerritoryInfoList.DataPortal_Fetch", ex);
				throw new DbCslaException("TerritoryInfoList.DataPortal_Fetch", ex);
			}
			this.RaiseListChangedEvents = true;
		}
		[Serializable()]
		private class RegionIDCriteria
		{
			public RegionIDCriteria(int regionID)
			{
				_RegionID = regionID;
			}
			private int _RegionID;
			public int RegionID
			{
				get { return _RegionID; }
				set { _RegionID = value; }
			}
		}
		private void DataPortal_Fetch(RegionIDCriteria criteria)
		{
			this.RaiseListChangedEvents = false;
			Database.LogInfo("TerritoryInfoList.DataPortal_FetchRegionID", GetHashCode());
			try
			{
				using (SqlConnection cn = Database.Northwind_SqlConnection)
				{
					using (SqlCommand cm = cn.CreateCommand())
					{
						cm.CommandType = CommandType.StoredProcedure;
						cm.CommandText = "getTerritoriesByRegionID";
						cm.Parameters.AddWithValue("@RegionID", criteria.RegionID);
						using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
						{
							IsReadOnly = false;
							while (dr.Read()) this.Add(new TerritoryInfo(dr));
							IsReadOnly = true;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Database.LogException("TerritoryInfoList.DataPortal_FetchRegionID", ex);
				throw new DbCslaException("TerritoryInfoList.DataPortal_Fetch", ex);
			}
			this.RaiseListChangedEvents = true;
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
				TerritoryInfoListPropertyDescriptor pd = new TerritoryInfoListPropertyDescriptor(this, i);
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
	public partial class TerritoryInfoListPropertyDescriptor : vlnListPropertyDescriptor
	{
		private TerritoryInfo Item { get { return (TerritoryInfo) _Item;} }
		public TerritoryInfoListPropertyDescriptor(TerritoryInfoList collection, int index):base(collection, index){;}
	}
	#endregion
	#region Converter
	internal class TerritoryInfoListConverter : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
		{
			if (destType == typeof(string) && value is TerritoryInfoList)
			{
				// Return department and department role separated by comma.
				return ((TerritoryInfoList) value).Items.Count.ToString() + " Territories";
			}
			return base.ConvertTo(context, culture, value, destType);
		}
	}
	#endregion
} // Namespace
