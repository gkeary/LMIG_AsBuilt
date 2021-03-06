﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mon1.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Spectrum")]
	public partial class NodeDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public NodeDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SpectrumConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public NodeDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NodeDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NodeDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NodeDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Node> Nodes
		{
			get
			{
				return this.GetTable<Node>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.spec")]
	public partial class Node
	{
		
		private string _composite;
		
		private int _id;
		
		private string _mname;
		
		private string _ip;
		
		private string _mhandle;
		
		private string _manu;
		
		private string _devicetype;
		
		private string _macaddress;
		
		private string _notes;
		
		private string _landscape;
		
		private string _hashvalue;
		
		public Node()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_composite", DbType="VarChar(304)")]
		public string composite
		{
			get
			{
				return this._composite;
			}
			set
			{
				if ((this._composite != value))
				{
					this._composite = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this._id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mname", DbType="VarChar(50)")]
		public string mname
		{
			get
			{
				return this._mname;
			}
			set
			{
				if ((this._mname != value))
				{
					this._mname = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ip", DbType="VarChar(50)")]
		public string ip
		{
			get
			{
				return this._ip;
			}
			set
			{
				if ((this._ip != value))
				{
					this._ip = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mhandle", DbType="VarChar(50)")]
		public string mhandle
		{
			get
			{
				return this._mhandle;
			}
			set
			{
				if ((this._mhandle != value))
				{
					this._mhandle = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_manu", DbType="VarChar(50)")]
		public string manu
		{
			get
			{
				return this._manu;
			}
			set
			{
				if ((this._manu != value))
				{
					this._manu = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_devicetype", DbType="VarChar(50)")]
		public string devicetype
		{
			get
			{
				return this._devicetype;
			}
			set
			{
				if ((this._devicetype != value))
				{
					this._devicetype = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_macaddress", DbType="VarChar(50)")]
		public string macaddress
		{
			get
			{
				return this._macaddress;
			}
			set
			{
				if ((this._macaddress != value))
				{
					this._macaddress = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_notes", DbType="VarChar(4000)")]
		public string notes
		{
			get
			{
				return this._notes;
			}
			set
			{
				if ((this._notes != value))
				{
					this._notes = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_landscape", DbType="VarChar(50)")]
		public string landscape
		{
			get
			{
				return this._landscape;
			}
			set
			{
				if ((this._landscape != value))
				{
					this._landscape = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_hashvalue", DbType="NVarChar(35)")]
		public string hashvalue
		{
			get
			{
				return this._hashvalue;
			}
			set
			{
				if ((this._hashvalue != value))
				{
					this._hashvalue = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
