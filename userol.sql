  
--组织机构
USE [WangYc]
GO
CREATE TABLE [dbo].[Organization](
	[Id]			int identity (1,1) not null primary key,
	[ParentId]		int					null,
	[Name]			varchar(64)		not null,
	[Description]	varchar(200)	not null,
	[Level]			int				not null,
	[CreateDate]	datetime		not null default getdate() 
) ON [PRIMARY]

GO

use WangYc
go
--drop table Users
CREATE TABLE [dbo].[Users](
	UserID			varchar(20) not null,
	UserName		varchar(20) null,
	UserPwd			varchar(20) null,
	LastSignTime	datetime	null,
	SignState		int			null,
	TickeID			varchar(20) null,
) 


use WangYc
go
drop table Rights
CREATE TABLE [dbo].[Rights](
	[Id]			int identity ( 1, 1 ) not null primary key,
	[ParentId]		[int] null,
	[Name]			[varchar](64) not null,
	[Url]			[varchar](200)  null,
	[Description]	[varchar](200) not null,
	[CreateDate]	[datetime]		not null default getdate() ,
	[Level]			[int] null,
	[CreateUserId]	[varchar](20) null,
) 
go

use WangYc
go
drop table Role
CREATE TABLE [dbo].[Role](
	Id			int identity ( 1, 1 ) not null primary key,
	Name		varchar	(20) null,
	Description	varchar	(200) not null,
	OrganizationId int not null,
	CreateDate	datetime not null default getdate(),--生成时间
) 
go

select * from wangyc.dbo.Role
insert into wangyc..role( name, Description,OrganizationId)
select 'Admin','admin',1

use WangYc
go
drop table RoleRights
CREATE TABLE [dbo].[RoleRights](
	ID			int identity ( 1, 1 ) not null primary key,
	RoleId		varchar	(20) null,
	RightsId	varchar	(200) not null,
	CreateDate	datetime not null default getdate(),--生成时间
) 
go


select * from wangyc.dbo.RoleRights
insert into wangyc.. RoleRights( RoleId, RightsId)
select 1,1

use WangYc
go
drop table UserRole
CREATE TABLE [dbo].[UserRole](
	ID				int identity ( 1, 1 ) not null primary key,
	UserID			varchar(20) not null,
	RoleID			varchar(20) not null,
	UserRoleNote	varchar(20) null,
	CreateDate		datetime    null default getdate(),--生成时间
) 
go

insert into wangyc.dbo.rights(  ParentId,Name,Descriptin,Level,URL)
select null,'采购系统','采购系统权限','1','Url.Action("GetRights", "Rights")' 

use WangYc
go
drop table [OrganizationUsers]
CREATE TABLE [dbo].[OrganizationUsers](
	ID				int identity ( 1, 1 ) not null primary key,
	UserID			varchar(20) not null,
	OrganizationID	int			not null,
	Note			varchar(20) null,
	CreateDate		datetime    null default getdate(),--生成时间
) 
go


use WangYc
go
/*库存表*/
drop table [InOutbound]
CREATE TABLE [dbo].[InOutbound](
	Id				int identity ( 1, 1 ) not null primary key,
	ProductId		int not null,
	Type			varchar(20) null,
	WarehouseId		int	not null,
	Qty				int	not null,
	Price			float not null,
	Currency		varchar(10), 
	Note			varchar(200) null,
	ParentId		int  null,
	CurrentQty		int	not null,
	CreateUserId	int not null,
	CreateDate		datetime null default getdate(),--生成时间
) 
go

use WangYc
go
/*库存表*/
drop table [InOutboundOfShelf]
CREATE TABLE [dbo].[InOutboundOfShelf](
	Id				int identity ( 1, 1 ) not null primary key,
	InOutBoundId	int not null,
	Type			varchar(20) null,
	WarehouseShelfId	int	not null,
	Qty				int	not null,
	CurrentQty		int	not null,
	Note			varchar(200) null,
	ParentId		int  null,
	CreateUserId	int not null,
	CreateDate		datetime null default getdate(),--生成时间
) 
go

select * from wangyc.dbo.InOutbound  
select * from WangYc.dbo.InOutboundOfShelf

delete from   wangyc.dbo.InOutbound 
delete from   wangyc.dbo.[InOutboundOfShelf] 

insert into wangyc.dbo.InOutbound(ProductId, Type, WarehouseId, qty, price, Currency, Note, createuserid, CurrentQty)
select 1,1,1,1,1,1,1,1,1

use WangYc
go
/*库存表*/
drop table [Product]
CREATE TABLE [dbo].[Product](
	Id				int identity ( 1, 1 ) not null primary key,
	ChineseName		nvarchar(200) null,
	EnglishName		nvarchar(200) null,
	Price			float not null,
	Currency		varchar(10), 
	Note			varchar(200) null,
	ProductTypeId	int			,
	CreateDate		datetime null default getdate(),--生成时间
) 
go

select * from wangyc.dbo.product

insert into wangyc.dbo.Product( chinesename, englishname, price, currency, note, producttypeid )
select 'OPPO R11','OPPO R11','3000','RMB','无打折','1'


use WangYc
go
/*库存表*/
drop table [Warehouse]
CREATE TABLE [dbo].[Warehouse](
	Id				int identity ( 1, 1 ) not null primary key,
	Name			nvarchar(200) null,
	Note			varchar(200) null,
	WarehouseTypeId	int			,
	State			int			,
	CreateDate		datetime null default getdate(),--生成时间
) 
go

select * from WangYc.dbo.Warehouse

insert into WangYc.dbo.Warehouse( Name, Note, WarehouseTypeId )
select '第一库房','第一库房','1'


use WangYc
go
/*库存表*/
drop table [WarehouseShelf]
CREATE TABLE [dbo].[WarehouseShelf](
	Id				int identity ( 1, 1 ) not null primary key,
	Name			nvarchar(200) null,
	Capacity		int, 
	Note			nvarchar(200) null,
	WarehouseId		int,
	CreateDate		datetime null default getdate(),--生成时间
) 
go

select * from WangYc.dbo.WarehouseShelf

insert into WangYc.dbo.[WarehouseShelf]( Name, Capacity, Note, WarehouseId )
select '货架一',100,'货架一','1'
insert into WangYc.dbo.[WarehouseShelf]( Name, Capacity, Note, WarehouseId )
select '货架二',100,'货架二','1'






select * from wangyc.dbo.InOutboundOfShelf
