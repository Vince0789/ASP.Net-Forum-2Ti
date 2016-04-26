﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="database2ti")]
public partial class DataClassesDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertForum(Forum instance);
  partial void UpdateForum(Forum instance);
  partial void DeleteForum(Forum instance);
  partial void InsertTopic(Topic instance);
  partial void UpdateTopic(Topic instance);
  partial void DeleteTopic(Topic instance);
  partial void InsertPost(Post instance);
  partial void UpdatePost(Post instance);
  partial void DeletePost(Post instance);
  partial void InsertUser(User instance);
  partial void UpdateUser(User instance);
  partial void DeleteUser(User instance);
  partial void InsertForumModerator(ForumModerator instance);
  partial void UpdateForumModerator(ForumModerator instance);
  partial void DeleteForumModerator(ForumModerator instance);
  #endregion
	
	public DataClassesDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["database2tiConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<Forum> Forums
	{
		get
		{
			return this.GetTable<Forum>();
		}
	}
	
	public System.Data.Linq.Table<Topic> Topics
	{
		get
		{
			return this.GetTable<Topic>();
		}
	}
	
	public System.Data.Linq.Table<Post> Posts
	{
		get
		{
			return this.GetTable<Post>();
		}
	}
	
	public System.Data.Linq.Table<User> Users
	{
		get
		{
			return this.GetTable<User>();
		}
	}
	
	public System.Data.Linq.Table<ForumModerator> ForumModerators
	{
		get
		{
			return this.GetTable<ForumModerator>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Forum")]
public partial class Forum : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _Id;
	
	private string _Name;
	
	private string _Description;
	
	private System.Nullable<int> _ParentForumId;
	
	private bool _IsCategory;
	
	private EntitySet<Forum> _Forums;
	
	private EntitySet<Topic> _Topics;
	
	private EntitySet<ForumModerator> _ForumModerators;
	
	private EntityRef<Forum> _Forum1;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnParentForumIdChanging(System.Nullable<int> value);
    partial void OnParentForumIdChanged();
    partial void OnIsCategoryChanging(bool value);
    partial void OnIsCategoryChanged();
    #endregion
	
	public Forum()
	{
		this._Forums = new EntitySet<Forum>(new Action<Forum>(this.attach_Forums), new Action<Forum>(this.detach_Forums));
		this._Topics = new EntitySet<Topic>(new Action<Topic>(this.attach_Topics), new Action<Topic>(this.detach_Topics));
		this._ForumModerators = new EntitySet<ForumModerator>(new Action<ForumModerator>(this.attach_ForumModerators), new Action<ForumModerator>(this.detach_ForumModerators));
		this._Forum1 = default(EntityRef<Forum>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int Id
	{
		get
		{
			return this._Id;
		}
		set
		{
			if ((this._Id != value))
			{
				this.OnIdChanging(value);
				this.SendPropertyChanging();
				this._Id = value;
				this.SendPropertyChanged("Id");
				this.OnIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
	public string Name
	{
		get
		{
			return this._Name;
		}
		set
		{
			if ((this._Name != value))
			{
				this.OnNameChanging(value);
				this.SendPropertyChanging();
				this._Name = value;
				this.SendPropertyChanged("Name");
				this.OnNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
	public string Description
	{
		get
		{
			return this._Description;
		}
		set
		{
			if ((this._Description != value))
			{
				this.OnDescriptionChanging(value);
				this.SendPropertyChanging();
				this._Description = value;
				this.SendPropertyChanged("Description");
				this.OnDescriptionChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParentForumId", DbType="Int")]
	public System.Nullable<int> ParentForumId
	{
		get
		{
			return this._ParentForumId;
		}
		set
		{
			if ((this._ParentForumId != value))
			{
				if (this._Forum1.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnParentForumIdChanging(value);
				this.SendPropertyChanging();
				this._ParentForumId = value;
				this.SendPropertyChanged("ParentForumId");
				this.OnParentForumIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsCategory", DbType="Bit NOT NULL")]
	public bool IsCategory
	{
		get
		{
			return this._IsCategory;
		}
		set
		{
			if ((this._IsCategory != value))
			{
				this.OnIsCategoryChanging(value);
				this.SendPropertyChanging();
				this._IsCategory = value;
				this.SendPropertyChanged("IsCategory");
				this.OnIsCategoryChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Forum_Forum", Storage="_Forums", ThisKey="Id", OtherKey="ParentForumId")]
	public EntitySet<Forum> Forums
	{
		get
		{
			return this._Forums;
		}
		set
		{
			this._Forums.Assign(value);
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Forum_Topic", Storage="_Topics", ThisKey="Id", OtherKey="ForumId")]
	public EntitySet<Topic> Topics
	{
		get
		{
			return this._Topics;
		}
		set
		{
			this._Topics.Assign(value);
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Forum_ForumModerator", Storage="_ForumModerators", ThisKey="Id", OtherKey="ForumId")]
	public EntitySet<ForumModerator> ForumModerators
	{
		get
		{
			return this._ForumModerators;
		}
		set
		{
			this._ForumModerators.Assign(value);
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Forum_Forum", Storage="_Forum1", ThisKey="ParentForumId", OtherKey="Id", IsForeignKey=true)]
	public Forum Forum1
	{
		get
		{
			return this._Forum1.Entity;
		}
		set
		{
			Forum previousValue = this._Forum1.Entity;
			if (((previousValue != value) 
						|| (this._Forum1.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Forum1.Entity = null;
					previousValue.Forums.Remove(this);
				}
				this._Forum1.Entity = value;
				if ((value != null))
				{
					value.Forums.Add(this);
					this._ParentForumId = value.Id;
				}
				else
				{
					this._ParentForumId = default(Nullable<int>);
				}
				this.SendPropertyChanged("Forum1");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_Forums(Forum entity)
	{
		this.SendPropertyChanging();
		entity.Forum1 = this;
	}
	
	private void detach_Forums(Forum entity)
	{
		this.SendPropertyChanging();
		entity.Forum1 = null;
	}
	
	private void attach_Topics(Topic entity)
	{
		this.SendPropertyChanging();
		entity.Forum = this;
	}
	
	private void detach_Topics(Topic entity)
	{
		this.SendPropertyChanging();
		entity.Forum = null;
	}
	
	private void attach_ForumModerators(ForumModerator entity)
	{
		this.SendPropertyChanging();
		entity.Forum = this;
	}
	
	private void detach_ForumModerators(ForumModerator entity)
	{
		this.SendPropertyChanging();
		entity.Forum = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Topic")]
public partial class Topic : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _Id;
	
	private string _Title;
	
	private int _ForumId;
	
	private bool _IsLocked;
	
	private bool _IsPinned;
	
	private EntitySet<Post> _Posts;
	
	private EntityRef<Forum> _Forum;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnForumIdChanging(int value);
    partial void OnForumIdChanged();
    partial void OnIsLockedChanging(bool value);
    partial void OnIsLockedChanged();
    partial void OnIsPinnedChanging(bool value);
    partial void OnIsPinnedChanged();
    #endregion
	
	public Topic()
	{
		this._Posts = new EntitySet<Post>(new Action<Post>(this.attach_Posts), new Action<Post>(this.detach_Posts));
		this._Forum = default(EntityRef<Forum>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int Id
	{
		get
		{
			return this._Id;
		}
		set
		{
			if ((this._Id != value))
			{
				this.OnIdChanging(value);
				this.SendPropertyChanging();
				this._Id = value;
				this.SendPropertyChanged("Id");
				this.OnIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
	public string Title
	{
		get
		{
			return this._Title;
		}
		set
		{
			if ((this._Title != value))
			{
				this.OnTitleChanging(value);
				this.SendPropertyChanging();
				this._Title = value;
				this.SendPropertyChanged("Title");
				this.OnTitleChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ForumId", DbType="Int NOT NULL")]
	public int ForumId
	{
		get
		{
			return this._ForumId;
		}
		set
		{
			if ((this._ForumId != value))
			{
				if (this._Forum.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnForumIdChanging(value);
				this.SendPropertyChanging();
				this._ForumId = value;
				this.SendPropertyChanged("ForumId");
				this.OnForumIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsLocked", DbType="Bit NOT NULL")]
	public bool IsLocked
	{
		get
		{
			return this._IsLocked;
		}
		set
		{
			if ((this._IsLocked != value))
			{
				this.OnIsLockedChanging(value);
				this.SendPropertyChanging();
				this._IsLocked = value;
				this.SendPropertyChanged("IsLocked");
				this.OnIsLockedChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsPinned", DbType="Bit NOT NULL")]
	public bool IsPinned
	{
		get
		{
			return this._IsPinned;
		}
		set
		{
			if ((this._IsPinned != value))
			{
				this.OnIsPinnedChanging(value);
				this.SendPropertyChanging();
				this._IsPinned = value;
				this.SendPropertyChanged("IsPinned");
				this.OnIsPinnedChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Topic_Post", Storage="_Posts", ThisKey="Id", OtherKey="TopicId")]
	public EntitySet<Post> Posts
	{
		get
		{
			return this._Posts;
		}
		set
		{
			this._Posts.Assign(value);
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Forum_Topic", Storage="_Forum", ThisKey="ForumId", OtherKey="Id", IsForeignKey=true)]
	public Forum Forum
	{
		get
		{
			return this._Forum.Entity;
		}
		set
		{
			Forum previousValue = this._Forum.Entity;
			if (((previousValue != value) 
						|| (this._Forum.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Forum.Entity = null;
					previousValue.Topics.Remove(this);
				}
				this._Forum.Entity = value;
				if ((value != null))
				{
					value.Topics.Add(this);
					this._ForumId = value.Id;
				}
				else
				{
					this._ForumId = default(int);
				}
				this.SendPropertyChanged("Forum");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_Posts(Post entity)
	{
		this.SendPropertyChanging();
		entity.Topic = this;
	}
	
	private void detach_Posts(Post entity)
	{
		this.SendPropertyChanging();
		entity.Topic = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Post")]
public partial class Post : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _Id;
	
	private int _TopicId;
	
	private int _UserId;
	
	private string _Content;
	
	private System.DateTime _CreatedDate;
	
	private EntityRef<Topic> _Topic;
	
	private EntityRef<User> _User;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnTopicIdChanging(int value);
    partial void OnTopicIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnContentChanging(string value);
    partial void OnContentChanged();
    partial void OnCreatedDateChanging(System.DateTime value);
    partial void OnCreatedDateChanged();
    #endregion
	
	public Post()
	{
		this._Topic = default(EntityRef<Topic>);
		this._User = default(EntityRef<User>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int Id
	{
		get
		{
			return this._Id;
		}
		set
		{
			if ((this._Id != value))
			{
				this.OnIdChanging(value);
				this.SendPropertyChanging();
				this._Id = value;
				this.SendPropertyChanged("Id");
				this.OnIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TopicId", DbType="Int NOT NULL")]
	public int TopicId
	{
		get
		{
			return this._TopicId;
		}
		set
		{
			if ((this._TopicId != value))
			{
				if (this._Topic.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnTopicIdChanging(value);
				this.SendPropertyChanging();
				this._TopicId = value;
				this.SendPropertyChanged("TopicId");
				this.OnTopicIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
	public int UserId
	{
		get
		{
			return this._UserId;
		}
		set
		{
			if ((this._UserId != value))
			{
				if (this._User.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnUserIdChanging(value);
				this.SendPropertyChanging();
				this._UserId = value;
				this.SendPropertyChanged("UserId");
				this.OnUserIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Content", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
	public string Content
	{
		get
		{
			return this._Content;
		}
		set
		{
			if ((this._Content != value))
			{
				this.OnContentChanging(value);
				this.SendPropertyChanging();
				this._Content = value;
				this.SendPropertyChanged("Content");
				this.OnContentChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedDate", DbType="DateTime NOT NULL")]
	public System.DateTime CreatedDate
	{
		get
		{
			return this._CreatedDate;
		}
		set
		{
			if ((this._CreatedDate != value))
			{
				this.OnCreatedDateChanging(value);
				this.SendPropertyChanging();
				this._CreatedDate = value;
				this.SendPropertyChanged("CreatedDate");
				this.OnCreatedDateChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Topic_Post", Storage="_Topic", ThisKey="TopicId", OtherKey="Id", IsForeignKey=true)]
	public Topic Topic
	{
		get
		{
			return this._Topic.Entity;
		}
		set
		{
			Topic previousValue = this._Topic.Entity;
			if (((previousValue != value) 
						|| (this._Topic.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Topic.Entity = null;
					previousValue.Posts.Remove(this);
				}
				this._Topic.Entity = value;
				if ((value != null))
				{
					value.Posts.Add(this);
					this._TopicId = value.Id;
				}
				else
				{
					this._TopicId = default(int);
				}
				this.SendPropertyChanged("Topic");
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Post", Storage="_User", ThisKey="UserId", OtherKey="Id", IsForeignKey=true)]
	public User User
	{
		get
		{
			return this._User.Entity;
		}
		set
		{
			User previousValue = this._User.Entity;
			if (((previousValue != value) 
						|| (this._User.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._User.Entity = null;
					previousValue.Posts.Remove(this);
				}
				this._User.Entity = value;
				if ((value != null))
				{
					value.Posts.Add(this);
					this._UserId = value.Id;
				}
				else
				{
					this._UserId = default(int);
				}
				this.SendPropertyChanged("User");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _Id;
	
	private string _Name;
	
	private string _Password;
	
	private System.DateTime _RegistrationDate;
	
	private EntitySet<Post> _Posts;
	
	private EntitySet<ForumModerator> _ForumModerators;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnRegistrationDateChanging(System.DateTime value);
    partial void OnRegistrationDateChanged();
    #endregion
	
	public User()
	{
		this._Posts = new EntitySet<Post>(new Action<Post>(this.attach_Posts), new Action<Post>(this.detach_Posts));
		this._ForumModerators = new EntitySet<ForumModerator>(new Action<ForumModerator>(this.attach_ForumModerators), new Action<ForumModerator>(this.detach_ForumModerators));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int Id
	{
		get
		{
			return this._Id;
		}
		set
		{
			if ((this._Id != value))
			{
				this.OnIdChanging(value);
				this.SendPropertyChanging();
				this._Id = value;
				this.SendPropertyChanged("Id");
				this.OnIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
	public string Name
	{
		get
		{
			return this._Name;
		}
		set
		{
			if ((this._Name != value))
			{
				this.OnNameChanging(value);
				this.SendPropertyChanging();
				this._Name = value;
				this.SendPropertyChanged("Name");
				this.OnNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="Char(40) NOT NULL", CanBeNull=false)]
	public string Password
	{
		get
		{
			return this._Password;
		}
		set
		{
			if ((this._Password != value))
			{
				this.OnPasswordChanging(value);
				this.SendPropertyChanging();
				this._Password = value;
				this.SendPropertyChanged("Password");
				this.OnPasswordChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RegistrationDate", DbType="DateTime NOT NULL")]
	public System.DateTime RegistrationDate
	{
		get
		{
			return this._RegistrationDate;
		}
		set
		{
			if ((this._RegistrationDate != value))
			{
				this.OnRegistrationDateChanging(value);
				this.SendPropertyChanging();
				this._RegistrationDate = value;
				this.SendPropertyChanged("RegistrationDate");
				this.OnRegistrationDateChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Post", Storage="_Posts", ThisKey="Id", OtherKey="UserId")]
	public EntitySet<Post> Posts
	{
		get
		{
			return this._Posts;
		}
		set
		{
			this._Posts.Assign(value);
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_ForumModerator", Storage="_ForumModerators", ThisKey="Id", OtherKey="UserId")]
	public EntitySet<ForumModerator> ForumModerators
	{
		get
		{
			return this._ForumModerators;
		}
		set
		{
			this._ForumModerators.Assign(value);
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_Posts(Post entity)
	{
		this.SendPropertyChanging();
		entity.User = this;
	}
	
	private void detach_Posts(Post entity)
	{
		this.SendPropertyChanging();
		entity.User = null;
	}
	
	private void attach_ForumModerators(ForumModerator entity)
	{
		this.SendPropertyChanging();
		entity.User = this;
	}
	
	private void detach_ForumModerators(ForumModerator entity)
	{
		this.SendPropertyChanging();
		entity.User = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ForumModerator")]
public partial class ForumModerator : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _ForumId;
	
	private int _UserId;
	
	private EntityRef<Forum> _Forum;
	
	private EntityRef<User> _User;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnForumIdChanging(int value);
    partial void OnForumIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    #endregion
	
	public ForumModerator()
	{
		this._Forum = default(EntityRef<Forum>);
		this._User = default(EntityRef<User>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ForumId", DbType="Int NOT NULL", IsPrimaryKey=true)]
	public int ForumId
	{
		get
		{
			return this._ForumId;
		}
		set
		{
			if ((this._ForumId != value))
			{
				if (this._Forum.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnForumIdChanging(value);
				this.SendPropertyChanging();
				this._ForumId = value;
				this.SendPropertyChanged("ForumId");
				this.OnForumIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL", IsPrimaryKey=true)]
	public int UserId
	{
		get
		{
			return this._UserId;
		}
		set
		{
			if ((this._UserId != value))
			{
				if (this._User.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnUserIdChanging(value);
				this.SendPropertyChanging();
				this._UserId = value;
				this.SendPropertyChanged("UserId");
				this.OnUserIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Forum_ForumModerator", Storage="_Forum", ThisKey="ForumId", OtherKey="Id", IsForeignKey=true)]
	public Forum Forum
	{
		get
		{
			return this._Forum.Entity;
		}
		set
		{
			Forum previousValue = this._Forum.Entity;
			if (((previousValue != value) 
						|| (this._Forum.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Forum.Entity = null;
					previousValue.ForumModerators.Remove(this);
				}
				this._Forum.Entity = value;
				if ((value != null))
				{
					value.ForumModerators.Add(this);
					this._ForumId = value.Id;
				}
				else
				{
					this._ForumId = default(int);
				}
				this.SendPropertyChanged("Forum");
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_ForumModerator", Storage="_User", ThisKey="UserId", OtherKey="Id", IsForeignKey=true)]
	public User User
	{
		get
		{
			return this._User.Entity;
		}
		set
		{
			User previousValue = this._User.Entity;
			if (((previousValue != value) 
						|| (this._User.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._User.Entity = null;
					previousValue.ForumModerators.Remove(this);
				}
				this._User.Entity = value;
				if ((value != null))
				{
					value.ForumModerators.Add(this);
					this._UserId = value.Id;
				}
				else
				{
					this._UserId = default(int);
				}
				this.SendPropertyChanged("User");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
#pragma warning restore 1591
