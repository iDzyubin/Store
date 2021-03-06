﻿//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1591

using System;
using System.Collections.Generic;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

namespace Store.DataAccess.DataModels
{
	/// <summary>
	/// Database       : store_db
	/// Data Source    : tcp://localhost:5432
	/// Server Version : 11.5
	/// </summary>
	public partial class MainDb : LinqToDB.Data.DataConnection
	{
		public ITable<Product>     Products     { get { return this.GetTable<Product>(); } }
		public ITable<SaleItem>    SaleItems    { get { return this.GetTable<SaleItem>(); } }
		public ITable<Transaction> Transactions { get { return this.GetTable<Transaction>(); } }
		public ITable<User>        Users        { get { return this.GetTable<User>(); } }

		partial void InitMappingSchema()
		{
		}

		public MainDb()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public MainDb(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();
	}

	[Table(Schema="sd", Name="products")]
	public partial class Product
	{
		[Column("id"),          PrimaryKey,  NotNull] public Guid     Id          { get; set; } // uuid
		[Column("title"),                    NotNull] public string   Title       { get; set; } // character varying
		[Column("description"),    Nullable         ] public string   Description { get; set; } // character varying
		[Column("price"),          Nullable         ] public decimal? Price       { get; set; } // numeric

		#region Associations

		/// <summary>
		/// sale_items_product_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="ProductId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<SaleItem> Saleitemsproductidfkeys { get; set; }

		#endregion
	}

	[Table(Schema="sd", Name="sale_items")]
	public partial class SaleItem
	{
		[Column("id"),             PrimaryKey,  NotNull] public Guid           Id            { get; set; } // uuid
		[Column("product_id"),                  NotNull] public Guid           ProductId     { get; set; } // uuid
		[Column("user_id"),                     NotNull] public Guid           UserId        { get; set; } // uuid
		[Column("count"),                       NotNull] public int            Count         { get; set; } // integer
		[Column("status"),                      NotNull] public SaleItemStatus Status        { get; set; } // integer
		[Column("transaction_id"),    Nullable         ] public Guid?          TransactionId { get; set; } // uuid

		#region Associations

		/// <summary>
		/// sale_items_product_id_fkey
		/// </summary>
		[Association(ThisKey="ProductId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="sale_items_product_id_fkey", BackReferenceName="Saleitemsproductidfkeys")]
		public Product Product { get; set; }

		/// <summary>
		/// sale_items_transaction_id_fkey
		/// </summary>
		[Association(ThisKey="TransactionId", OtherKey="Id", CanBeNull=true, Relationship=Relationship.ManyToOne, KeyName="sale_items_transaction_id_fkey", BackReferenceName="Saleitemstransactionidfkeys")]
		public Transaction Transaction { get; set; }

		/// <summary>
		/// sale_items_user_id_fkey
		/// </summary>
		[Association(ThisKey="UserId", OtherKey="Id", CanBeNull=false, Relationship=Relationship.ManyToOne, KeyName="sale_items_user_id_fkey", BackReferenceName="Saleitemsuseridfkeys")]
		public User User { get; set; }

		#endregion
	}

	[Table(Schema="sd", Name="transactions")]
	public partial class Transaction
	{
		[Column("id"),                 PrimaryKey,  NotNull] public Guid              Id               { get; set; } // uuid
		[Column("status"),                          NotNull] public TransactionStatus Status           { get; set; } // integer
		[Column("create_date_time"),      Nullable         ] public DateTime?         CreateDateTime   { get; set; } // timestamp (6) without time zone
		[Column("is_canceled"),                     NotNull] public bool              IsCanceled       { get; set; } // boolean
		[Column("canceled_date_time"),    Nullable         ] public DateTime?         CanceledDateTime { get; set; } // timestamp (6) without time zone

		#region Associations

		/// <summary>
		/// sale_items_transaction_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="TransactionId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<SaleItem> Saleitemstransactionidfkeys { get; set; }

		#endregion
	}

	[Table(Schema="sd", Name="users")]
	public partial class User
	{
		[Column("id"),          PrimaryKey,  NotNull] public Guid       Id         { get; set; } // uuid
		[Column("first_name"),               NotNull] public string     FirstName  { get; set; } // character varying
		[Column("last_name"),                NotNull] public string     LastName   { get; set; } // character varying
		[Column("email"),                    NotNull] public string     Email      { get; set; } // character varying
		[Column("password"),                 NotNull] public string     Password   { get; set; } // character varying
		[Column("is_admin"),                 NotNull] public bool       IsAdmin    { get; set; } // boolean
		[Column("status"),                   NotNull] public UserStatus Status     { get; set; } // integer
		[Column("middle_name"),    Nullable         ] public string     MiddleName { get; set; } // character varying
		[Column("phone"),          Nullable         ] public string     Phone      { get; set; } // character varying
		[Column("address"),        Nullable         ] public string     Address    { get; set; } // character varying

		#region Associations

		/// <summary>
		/// sale_items_user_id_fkey_BackReference
		/// </summary>
		[Association(ThisKey="Id", OtherKey="UserId", CanBeNull=true, Relationship=Relationship.OneToMany, IsBackReference=true)]
		public IEnumerable<SaleItem> Saleitemsuseridfkeys { get; set; }

		#endregion
	}

	public static partial class TableExtensions
	{
		public static Product Find(this ITable<Product> table, Guid Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static SaleItem Find(this ITable<SaleItem> table, Guid Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static Transaction Find(this ITable<Transaction> table, Guid Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static User Find(this ITable<User> table, Guid Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}
	}
}

#pragma warning restore 1591
