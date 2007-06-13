
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using System.Configuration;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using Csla.Validation;
namespace Northwind.CSLA.Library
{
	/// <summary>
	///	Region Generated by MyGeneration using the CSLA Object Mapping template
	/// </summary>
	[Serializable()]
	[TypeConverter(typeof(RegionConverter))]
	public partial class Region : BusinessBase<Region>, IDisposable, IVEHasBrokenRules
	{
		#region Refresh
		private List<Region> _RefreshRegions = new List<Region>();
		private List<RegionTerritory> _RefreshRegionTerritories = new List<RegionTerritory>();
		private void AddToRefreshList(List<Region> refreshRegions, List<RegionTerritory> refreshRegionTerritories)
		{
			if (IsDirty)
				refreshRegions.Add(this);
			if (_RegionTerritories != null && _RegionTerritories.IsDirty)
			{
				foreach (RegionTerritory tmp in _RegionTerritories)
				{
					if(tmp.IsDirty)refreshRegionTerritories.Add(tmp);
				}
			}
		}
		private void BuildRefreshList()
		{
			_RefreshRegions = new List<Region>();
			_RefreshRegionTerritories = new List<RegionTerritory>();
			AddToRefreshList(_RefreshRegions, _RefreshRegionTerritories);
		}
		private void ProcessRefreshList()
		{
			foreach (Region tmp in _RefreshRegions)
			{
				RegionInfo.Refresh(tmp);
			}
			foreach (RegionTerritory tmp in _RefreshRegionTerritories)
			{
				TerritoryInfo.Refresh(tmp);
			}
		}
		#endregion
		#region Collection
		protected static List<Region> _AllList = new List<Region>();
		private static Dictionary<string, Region> _AllByPrimaryKey = new Dictionary<string, Region>();
		private static void ConvertListToDictionary()
		{
			List<Region> remove = new List<Region>();
			foreach (Region tmp in _AllList)
			{
				_AllByPrimaryKey[tmp.RegionID.ToString()]=tmp; // Primary Key
				remove.Add(tmp);
			}
			foreach (Region tmp in remove)
				_AllList.Remove(tmp);
		}
		public static Region GetExistingByPrimaryKey(int regionID)
		{
			ConvertListToDictionary();
			string key = regionID.ToString();
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
		private int _RegionID;
		[System.ComponentModel.DataObjectField(true, true)]
		public int RegionID
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _RegionID;
			}
		}
		private string _RegionDescription = string.Empty;
		public string RegionDescription
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _RegionDescription;
			}
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				if (value == null) value = string.Empty;
				if (_RegionDescription != value)
				{
					_RegionDescription = value;
					PropertyHasChanged();
				}
			}
		}
		private int _RegionTerritoryCount = 0;
		/// <summary>
		/// Count of RegionTerritories for this Region
		/// </summary>
		public int RegionTerritoryCount
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _RegionTerritoryCount;
			}
		}
		private RegionTerritories _RegionTerritories = null;
		/// <summary>
		/// Related Field
		/// </summary>
		[TypeConverter(typeof(RegionTerritoriesConverter))]
		public RegionTerritories RegionTerritories
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				if(_RegionTerritoryCount > 0 && _RegionTerritories == null)
					_RegionTerritories = RegionTerritories.GetByRegionID(RegionID);
				else if(_RegionTerritories == null)
					_RegionTerritories = RegionTerritories.New();
				return _RegionTerritories;
			}
		}
		public override bool IsDirty
		{
			get { return base.IsDirty || (_RegionTerritories == null? false : _RegionTerritories.IsDirty); }
		}
		public override bool IsValid
		{
			get { return (IsNew && !IsDirty ? true : base.IsValid) && (_RegionTerritories == null? true : _RegionTerritories.IsValid); }
		}
		// TODO: Replace base Region.ToString function as necessary
		/// <summary>
		/// Overrides Base ToString
		/// </summary>
		/// <returns>A string representation of current Region</returns>
		//public override string ToString()
		//{
		//  return base.ToString();
		//}
		// TODO: Check Region.GetIdValue to assure that the ID returned is unique
		/// <summary>
		/// Overrides Base GetIdValue - Used internally by CSLA to determine equality
		/// </summary>
		/// <returns>A Unique ID for the current Region</returns>
		protected override object GetIdValue()
		{
			return _RegionID;
		}
		#endregion
		#region ValidationRules
		[NonSerialized]
		private bool _CheckingBrokenRules=false;
		public IVEHasBrokenRules HasBrokenRules
		{
			get {
				if(_CheckingBrokenRules)return null;
				if ((IsDirty || !IsNew) && BrokenRulesCollection.Count > 0) return this;
				try
				{
					_CheckingBrokenRules=true;
					IVEHasBrokenRules hasBrokenRules = null;
				if (_RegionTerritories != null && (hasBrokenRules = _RegionTerritories.HasBrokenRules) != null) return hasBrokenRules;
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
				Csla.Validation.CommonRules.StringRequired, "RegionDescription");
			ValidationRules.AddRule(
				Csla.Validation.CommonRules.StringMaxLength,
				new Csla.Validation.CommonRules.MaxLengthRuleArgs("RegionDescription", 50));
			//ValidationRules.AddDependantProperty("x", "y");
			_RegionExtension.AddValidationRules(ValidationRules);
			// TODO:  Add other validation rules
		}
		protected override void AddInstanceBusinessRules()
		{
			_RegionExtension.AddInstanceValidationRules(ValidationRules);
			// TODO:  Add other validation rules
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
			//AuthorizationRules.AllowRead(RegionID, "<Role(s)>");
			//AuthorizationRules.AllowRead(RegionDescription, "<Role(s)>");
			//AuthorizationRules.AllowWrite(RegionDescription, "<Role(s)>");
			_RegionExtension.AddAuthorizationRules(AuthorizationRules);
		}
		protected override void AddInstanceAuthorizationRules()
		{
			//TODO: Who can read/write which fields
			_RegionExtension.AddInstanceAuthorizationRules(AuthorizationRules);
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
		protected Region()
		{/* require use of factory methods */
			_AllList.Add(this);
		}
		public void Dispose()
		{
			_AllList.Remove(this);
			_AllByPrimaryKey.Remove(RegionID.ToString());
		}
		public static Region New()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a Region");
			try
			{
				return DataPortal.Create<Region>();
			}
			catch (Exception ex)
			{
				throw new DbCslaException("Error on Region.New", ex);
			}
		}
		public static Region New(int regionID, string regionDescription)
		{
			Region tmp = Region.New();
			tmp._RegionID = regionID;
			tmp.RegionDescription = regionDescription;
			return tmp;
		}
		public static Region MakeRegion(int regionID, string regionDescription)
		{
			Region tmp = Region.New(regionID, regionDescription);
			if (tmp.IsSavable)
				tmp = tmp.Save();
			else
			{
				Csla.Validation.BrokenRulesCollection brc = tmp.ValidationRules.GetBrokenRules();
				tmp._ErrorMessage = "Failed Validation:";
				foreach (Csla.Validation.BrokenRule br in brc)
				{
					tmp._ErrorMessage += "\r\n\tFailure: " + br.RuleName;
				}
			}
			return tmp;
		}
		public static Region Get(int regionID)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a Region");
			try
			{
				Region tmp = GetExistingByPrimaryKey(regionID);
				if (tmp == null)
				{
					tmp = DataPortal.Fetch<Region>(new PKCriteria(regionID));
					_AllList.Add(tmp);
				}
				if (tmp.ErrorMessage == "No Record Found") tmp = null;
				return tmp;
			}
			catch (Exception ex)
			{
				throw new DbCslaException("Error on Region.Get", ex);
			}
		}
		public static Region Get(SafeDataReader dr)
		{
			if (dr.Read()) return new Region(dr);
			return null;
		}
		internal Region(SafeDataReader dr)
		{
			ReadData(dr);
		}
		public static void Delete(int regionID)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a Region");
			try
			{
				DataPortal.Delete(new PKCriteria(regionID));
			}
			catch (Exception ex)
			{
				throw new DbCslaException("Error on Region.Delete", ex);
			}
		}
		public override Region Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a Region");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a Region");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a Region");
			try
			{
				BuildRefreshList();
				Region region = base.Save();
				_AllList.Add(region);//Refresh the item in AllList
				ProcessRefreshList();
				return region;
			}
			catch (Exception ex)
			{
				throw new DbCslaException("Error on CSLA Save", ex);
			}
		}
		#endregion
		#region Data Access Portal
		[Serializable()]
		protected class PKCriteria
		{
			private int _RegionID;
			public int RegionID
			{ get { return _RegionID; } }
			public PKCriteria(int regionID)
			{
				_RegionID = regionID;
			}
		}
		// TODO: If Create needs to access DB - It should not be marked RunLocal
		[RunLocal()]
		private new void DataPortal_Create()
		{

			// Database Defaults

			// TODO: Add any defaults that are necessary
			ValidationRules.CheckRules();
		}
		private void ReadData(SafeDataReader dr)
		{
			Database.LogInfo("Region.ReadData", GetHashCode());
			try
			{
				_RegionID = dr.GetInt32("RegionID");
				_RegionDescription = dr.GetString("RegionDescription");
				_RegionTerritoryCount = dr.GetInt32("TerritoryCount");
				MarkOld();
			}
			catch (Exception ex)
			{
				Database.LogException("Region.ReadData", ex);
				_ErrorMessage = ex.Message;
				throw new DbCslaException("Region.ReadData", ex);
			}
		}
		private void DataPortal_Fetch(PKCriteria criteria)
		{
			Database.LogInfo("Region.DataPortal_Fetch", GetHashCode());
			try
			{
				using (SqlConnection cn = Database.Northwind_SqlConnection)
				{
					ApplicationContext.LocalContext["cn"] = cn;
					using (SqlCommand cm = cn.CreateCommand())
					{
						cm.CommandType = CommandType.StoredProcedure;
						cm.CommandText = "getRegion";
						cm.Parameters.AddWithValue("@RegionID", criteria.RegionID);
						using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
						{
							if (!dr.Read())
							{
								_ErrorMessage = "No Record Found";
								return;
							}
							ReadData(dr);
							// load child objects
							dr.NextResult();
							_RegionTerritories = RegionTerritories.Get(dr);
						}
					}
					// removing of item only needed for local data portal
					if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Client)
						ApplicationContext.LocalContext.Remove("cn");
				}
			}
			catch (Exception ex)
			{
				Database.LogException("Region.DataPortal_Fetch", ex);
				_ErrorMessage = ex.Message;
				throw new DbCslaException("Region.DataPortal_Fetch", ex);
			}
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		protected override void DataPortal_Insert()
		{
			try
			{
				using (SqlConnection cn = Database.Northwind_SqlConnection)
				{
					ApplicationContext.LocalContext["cn"] = cn;
					SQLInsert();
					// removing of item only needed for local data portal
					if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Client)
						ApplicationContext.LocalContext.Remove("cn");
				}
			}
			catch (Exception ex)
			{
				Database.LogException("Region.DataPortal_Insert", ex);
				_ErrorMessage = ex.Message;
				throw new DbCslaException("Region.DataPortal_Insert", ex);
			}
			finally
			{
				Database.LogInfo("Region.DataPortal_Insert", GetHashCode());
			}
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		internal void SQLInsert()
		{
			if (!this.IsDirty) return;
			try
			{
				SqlConnection cn = (SqlConnection)ApplicationContext.LocalContext["cn"];
				using (SqlCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
					cm.CommandText = "addRegion";
					// Input All Fields - Except Calculated Columns
					cm.Parameters.AddWithValue("@RegionID", _RegionID);
					cm.Parameters.AddWithValue("@RegionDescription", _RegionDescription);
					// Output Calculated Columns
					// TODO: Define any additional output parameters
					cm.ExecuteNonQuery();
					// Save all values being returned from the Procedure
				}
				MarkOld();
				// update child objects
				if (_RegionTerritories != null) _RegionTerritories.Update(this);
				Database.LogInfo("Region.SQLInsert", GetHashCode());
			}
			catch (Exception ex)
			{
				Database.LogException("Region.SQLInsert", ex);
				_ErrorMessage = ex.Message;
				throw new DbCslaException("Region.SQLInsert", ex);
			}
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		public static void Add(SqlConnection cn, int regionID, string regionDescription)
		{
			Database.LogInfo("Region.Add", 0);
			try
			{
				using (SqlCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
					cm.CommandText = "addRegion";
					// Input All Fields - Except Calculated Columns
					cm.Parameters.AddWithValue("@RegionID", regionID);
					cm.Parameters.AddWithValue("@RegionDescription", regionDescription);
					// Output Calculated Columns
					// TODO: Define any additional output parameters
					cm.ExecuteNonQuery();
					// Save all values being returned from the Procedure
			// No Timestamp value to return
				}
			}
			catch (Exception ex)
			{
				Database.LogException("Region.Add", ex);
				throw new DbCslaException("Region.Add", ex);
			}
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		protected override void DataPortal_Update()
		{
			if (!IsDirty) return;	// If not dirty - nothing to do
			Database.LogInfo("Region.DataPortal_Update", GetHashCode());
			try
			{
				using (SqlConnection cn = Database.Northwind_SqlConnection)
				{
					ApplicationContext.LocalContext["cn"] = cn;
					SQLUpdate();
					// removing of item only needed for local data portal
					if (ApplicationContext.ExecutionLocation == ApplicationContext.ExecutionLocations.Client)
						ApplicationContext.LocalContext.Remove("cn");
				}
			}
			catch (Exception ex)
			{
				Database.LogException("Region.DataPortal_Update", ex);
				_ErrorMessage = ex.Message;
				if (!ex.Message.EndsWith("has been edited by another user.")) throw ex;
			}
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		internal void SQLUpdate()
		{
			if (!IsDirty) return;	// If not dirty - nothing to do
			Database.LogInfo("Region.SQLUpdate", GetHashCode());
			try
			{
				SqlConnection cn = (SqlConnection)ApplicationContext.LocalContext["cn"];
				if (base.IsDirty)
				{
					using (SqlCommand cm = cn.CreateCommand())
					{
						cm.CommandType = CommandType.StoredProcedure;
						cm.CommandText = "updateRegion";
						// All Fields including Calculated Fields
						cm.Parameters.AddWithValue("@RegionID", _RegionID);
						cm.Parameters.AddWithValue("@RegionDescription", _RegionDescription);
						// Output Calculated Columns
						// TODO: Define any additional output parameters
						cm.ExecuteNonQuery();
						// Save all values being returned from the Procedure
					}
				}
				MarkOld();
				// use the open connection to update child objects
				if (_RegionTerritories != null) _RegionTerritories.Update(this);
			}
			catch (Exception ex)
			{
				Database.LogException("Region.SQLUpdate", ex);
				_ErrorMessage = ex.Message;
				if (!ex.Message.EndsWith("has been edited by another user.")) throw ex;
			}
		}
		internal void Update()
		{
			if (!this.IsDirty) return;
			if (base.IsDirty)
			{
				SqlConnection cn = (SqlConnection)ApplicationContext.LocalContext["cn"];
				if (IsNew)
					Region.Add(cn, _RegionID, _RegionDescription);
				else
					Region.Update(cn, _RegionID, _RegionDescription);
				MarkOld();
			}
			if (_RegionTerritories != null) _RegionTerritories.Update(this);
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		public static void Update(SqlConnection cn, int regionID, string regionDescription)
		{
			Database.LogInfo("Region.Update", 0);
			try
			{
				using (SqlCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
					cm.CommandText = "updateRegion";
					// Input All Fields - Except Calculated Columns
					cm.Parameters.AddWithValue("@RegionID", regionID);
					cm.Parameters.AddWithValue("@RegionDescription", regionDescription);
					// Output Calculated Columns
					// TODO: Define any additional output parameters
					cm.ExecuteNonQuery();
					// Save all values being returned from the Procedure
				// No Timestamp value to return
				}
			}
			catch (Exception ex)
			{
				Database.LogException("Region.Update", ex);
				throw new DbCslaException("Region.Update", ex);
			}
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new PKCriteria(_RegionID));
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		private void DataPortal_Delete(PKCriteria criteria)
		{
			Database.LogInfo("Region.DataPortal_Delete", GetHashCode());
			try
			{
				using (SqlConnection cn = Database.Northwind_SqlConnection)
				{
					using (SqlCommand cm = cn.CreateCommand())
					{
						cm.CommandType = CommandType.StoredProcedure;
						cm.CommandText = "deleteRegion";
						cm.Parameters.AddWithValue("@RegionID", criteria.RegionID);
						cm.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex)
			{
				Database.LogException("Region.DataPortal_Delete", ex);
				_ErrorMessage = ex.Message;
				throw new DbCslaException("Region.DataPortal_Delete", ex);
			}
		}
		[Transactional(TransactionalTypes.TransactionScope)]
		public static void Remove(SqlConnection cn, int regionID)
		{
			Database.LogInfo("Region.Remove", 0);
			try
			{
				using (SqlCommand cm = cn.CreateCommand())
				{
					cm.CommandType = CommandType.StoredProcedure;
					cm.CommandText = "deleteRegion";
					// Input PK Fields
					cm.Parameters.AddWithValue("@RegionID", regionID);
					// TODO: Define any additional output parameters
					cm.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				Database.LogException("Region.Remove", ex);
				throw new DbCslaException("Region.Remove", ex);
			}
		}
		#endregion
		#region Exists
		public static bool Exists(int regionID)
		{
			ExistsCommand result;
			try
			{
				result = DataPortal.Execute<ExistsCommand>(new ExistsCommand(regionID));
				return result.Exists;
			}
			catch (Exception ex)
			{
				throw new DbCslaException("Error on Region.Exists", ex);
			}
		}
		[Serializable()]
		private class ExistsCommand : CommandBase
		{
			private int _RegionID;
			private bool _exists;
			public bool Exists
			{
				get { return _exists; }
			}
			public ExistsCommand(int regionID)
			{
				_RegionID = regionID;
			}
			protected override void DataPortal_Execute()
			{
				Database.LogInfo("Region.DataPortal_Execute", GetHashCode());
				try
				{
					using (SqlConnection cn = Database.Northwind_SqlConnection)
					{
						cn.Open();
						using (SqlCommand cm = cn.CreateCommand())
						{
							cm.CommandType = CommandType.StoredProcedure;
							cm.CommandText = "existsRegion";
							cm.Parameters.AddWithValue("@RegionID", _RegionID);
							int count = (int)cm.ExecuteScalar();
							_exists = (count > 0);
						}
					}
				}
				catch (Exception ex)
				{
					Database.LogException("Region.DataPortal_Execute", ex);
					throw new DbCslaException("Region.DataPortal_Execute", ex);
				}
			}
		}
		#endregion
		// Standard Default Code
		#region extension
		RegionExtension _RegionExtension = new RegionExtension();
		[Serializable()]
		partial class RegionExtension : extensionBase
		{
		}
		[Serializable()]
		class extensionBase
		{
			// Default Values
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
	internal class RegionConverter : ExpandableObjectConverter
	{
		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
		{
			if (destType == typeof(string) && value is Region)
			{
				// Return the ToString value
				return ((Region)value).ToString();
			}
			return base.ConvertTo(context, culture, value, destType);
		}
	}
	#endregion
} // Namespace


//// The following is a sample Extension File.  You can use it to create RegionExt.cs
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Csla;

//namespace Northwind.CSLA.Library
//{
//  public partial class Region
//  {
//    partial class RegionExtension : extensionBase
//    {
//      // TODO: Override automatic defaults
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
