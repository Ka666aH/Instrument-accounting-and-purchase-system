USE [master]
GO
/****** Object:  Database [TOOLACCOUNTING]    Script Date: 16.06.2025 12:16:24 ******/
CREATE DATABASE [TOOLACCOUNTING]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TOOLACCOUNTING', FILENAME = N'I:\SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\TOOLACCOUNTING.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TOOLACCOUNTING_log', FILENAME = N'I:\SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\TOOLACCOUNTING_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TOOLACCOUNTING].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TOOLACCOUNTING] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET ARITHABORT OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TOOLACCOUNTING] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TOOLACCOUNTING] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TOOLACCOUNTING] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TOOLACCOUNTING] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TOOLACCOUNTING] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TOOLACCOUNTING] SET  MULTI_USER 
GO
ALTER DATABASE [TOOLACCOUNTING] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TOOLACCOUNTING] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TOOLACCOUNTING] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TOOLACCOUNTING] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [TOOLACCOUNTING]
GO
/****** Object:  Table [dbo].[AnalogTools]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnalogTools](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OriginalNomenclatureNumber] [char](9) NOT NULL,
	[AnalogNomenclatureNumber] [char](9) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Balances]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Balances](
	[BalanceID] [int] IDENTITY(1,1) NOT NULL,
	[NomenclatureNumber] [char](9) NOT NULL,
	[StorageID] [int] NOT NULL,
	[BalanceDate] [date] NOT NULL,
	[BatchNumber] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK__Balances__A760D59EAACE2E0D] PRIMARY KEY CLUSTERED 
(
	[BalanceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DefectiveLists]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DefectiveLists](
	[DefectiveListID] [int] IDENTITY(1,1) NOT NULL,
	[DefectiveListDate] [date] NOT NULL,
	[NomenclatureNumber] [char](9) NOT NULL,
	[WorkshopID] [int] NOT NULL,
	[BatchNumber] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NULL,
	[Quantity] [int] NOT NULL,
	[IsWriteOff] [bit] NOT NULL,
 CONSTRAINT [PK__Defectiv__93C6606D01029CFF] PRIMARY KEY CLUSTERED 
(
	[DefectiveListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryLists]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryLists](
	[DeliveryListID] [int] IDENTITY(1,1) NOT NULL,
	[DeliveryListDate] [date] NOT NULL,
	[SupplierINN] [nvarchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DeliveryListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeliveryListsContent]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryListsContent](
	[DeliveryContentID] [int] IDENTITY(1,1) NOT NULL,
	[DeliveryListID] [int] NOT NULL,
	[PurchaseContentID] [int] NOT NULL,
	[DeliveryContentDate] [date] NOT NULL,
	[ContractNumber] [nvarchar](100) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NULL,
	[Total]  AS ([Quantity]*[Price]) PERSISTED,
 CONSTRAINT [PK__Delivery__2BA2C054DCBFF3D2] PRIMARY KEY CLUSTERED 
(
	[DeliveryContentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[RangeStart] [char](4) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RangeStart] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceDate] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoicesContent]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoicesContent](
	[InvoiceContentID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[DeliveryContentID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceContentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovementTypes]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovementTypes](
	[MovementTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MovementTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nomenclature]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nomenclature](
	[NomenclatureNumber] [char](9) NOT NULL,
	[Designation] [nvarchar](100) NULL,
	[Unit] [nvarchar](10) NOT NULL,
	[Dimensions] [nvarchar](max) NULL,
	[CuttingMaterial] [nvarchar](100) NULL,
	[RegulatoryDoc] [nvarchar](100) NULL,
	[Producer] [nvarchar](100) NULL,
	[UsageFlag] [tinyint] NOT NULL,
	[MinStock] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NomenclatureNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NomenclatureLogs]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NomenclatureLogs](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[NomenclatureNumber] [char](9) NOT NULL,
	[FieldName] [nvarchar](255) NOT NULL,
	[OldValue] [nvarchar](max) NULL,
	[NewValue] [nvarchar](max) NULL,
	[ChangedDate] [datetime] NULL,
	[Executor] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseRequests]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseRequests](
	[PurchaseRequestID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseRequestDate] [date] NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PurchaseRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseRequestsContent]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseRequestsContent](
	[PurchaseContentID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseRequestID] [int] NOT NULL,
	[ReceivingContentID] [int] NOT NULL,
	[IsPurchase] [bit] NOT NULL,
	[DonorWorkshopID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PurchaseContentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceivingRequests]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceivingRequests](
	[ReceivingRequestID] [int] IDENTITY(1,1) NOT NULL,
	[ReceivingRequestDate] [date] NOT NULL,
	[WorkshopID] [int] NOT NULL,
	[PlannedDate] [date] NULL,
	[ReceivingRequestType] [nvarchar](50) NOT NULL,
	[Reason] [nvarchar](max) NULL,
	[Status] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReceivingRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceivingRequestsContent]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceivingRequestsContent](
	[ReceivingContentID] [int] IDENTITY(1,1) NOT NULL,
	[ReceivingRequestID] [int] NOT NULL,
	[NomenclatureNumber] [char](9) NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReceivingContentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReplacementFixation]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReplacementFixation](
	[ReplacementID] [int] IDENTITY(1,1) NOT NULL,
	[ReceivingContentID] [int] NOT NULL,
	[AnalogNomenclatureNumber] [char](9) NOT NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ReplacementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Storages]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storages](
	[StorageID] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[WorkshopID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StorageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[INN] [nvarchar](12) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[LegalAddress] [nvarchar](max) NOT NULL,
	[Contacts] [nvarchar](max) NOT NULL,
	[Notes] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[INN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ToolMovements]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToolMovements](
	[MovementID] [int] IDENTITY(1,1) NOT NULL,
	[MovementDate] [date] NOT NULL,
	[ToStorageID] [int] NOT NULL,
	[FromStorageID] [int] NULL,
	[MovementTypeID] [nvarchar](max) NULL,
	[NomenclatureNumber] [char](9) NOT NULL,
	[SourceDocumentType] [nvarchar](50) NULL,
	[SourceDocumentID] [int] NULL,
	[BatchNumber] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 2) NULL,
	[Quantity] [int] NOT NULL,
	[Total]  AS ([Quantity]*[Price]) PERSISTED,
	[InvoiceType] [nvarchar](50) NULL,
	[IsPosted] [bit] NOT NULL,
	[Executor] [nvarchar](255) NOT NULL,
	[LastUpdated] [datetime2](7) NULL,
 CONSTRAINT [PK__ToolMove__D1822466AC1C5F29] PRIMARY KEY CLUSTERED 
(
	[MovementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workshops]    Script Date: 16.06.2025 12:16:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workshops](
	[WorkshopID] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[WorkshopID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AnalogTools] ON 

INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (1, N'000100001', N'000100002')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (2, N'000100002', N'000100001')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (3, N'000100002', N'000100003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (4, N'000400002', N'000400003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (5, N'000500002', N'000500003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (6, N'000600002', N'000600003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (7, N'000700002', N'000700003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (8, N'000800002', N'000800003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (9, N'000900002', N'000900003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (12, N'001100002', N'001100003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (13, N'001200002', N'001200003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (14, N'001300002', N'001300003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (15, N'001400002', N'001400003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (16, N'001500002', N'001500003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (17, N'001600002', N'001600003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (18, N'001700002', N'001700003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (19, N'001800002', N'001800003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (20, N'001900002', N'001900003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (21, N'002000002', N'002000003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (22, N'002100002', N'002100003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (23, N'002200002', N'002200003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (24, N'002300002', N'002300003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (25, N'002400002', N'002400003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (26, N'002500002', N'002500003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (27, N'002600002', N'002600003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (28, N'002700002', N'002700003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (29, N'002800002', N'002800003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (31, N'003000002', N'003000003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (32, N'000100003', N'000400003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (33, N'000200003', N'000200004')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (37, N'002900004', N'002900003')
INSERT [dbo].[AnalogTools] ([ID], [OriginalNomenclatureNumber], [AnalogNomenclatureNumber]) VALUES (38, N'000100001', N'000500001')
SET IDENTITY_INSERT [dbo].[AnalogTools] OFF
GO
SET IDENTITY_INSERT [dbo].[Balances] ON 

INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (24, N'005600001', 1, CAST(N'2024-05-01' AS Date), N'20240501-001', CAST(150.75 AS Decimal(18, 2)), 15)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (25, N'007900001', 1, CAST(N'2024-05-01' AS Date), N'20240501-002', CAST(230.50 AS Decimal(18, 2)), 6)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (28, N'000100002', 4, CAST(N'2024-05-03' AS Date), N'20240503-004', CAST(75.20 AS Decimal(18, 2)), 16)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (29, N'000200002', 4, CAST(N'2024-05-03' AS Date), N'20240503-005', CAST(1200.00 AS Decimal(18, 2)), 6)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (30, N'000300001', 0, CAST(N'2024-05-04' AS Date), N'20240504-006', CAST(36434.00 AS Decimal(18, 2)), 4)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (31, N'000400002', 0, CAST(N'2024-05-04' AS Date), N'20240504-007', CAST(25.50 AS Decimal(18, 2)), 226)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (32, N'000500001', 0, CAST(N'2024-05-05' AS Date), N'20240505-008', CAST(3200.00 AS Decimal(18, 2)), 4)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (33, N'000600001', 3, CAST(N'2024-05-06' AS Date), N'20240506-009', CAST(450.00 AS Decimal(18, 2)), 25)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (34, N'001800001', 3, CAST(N'2024-05-07' AS Date), N'20240507-010', CAST(8000.00 AS Decimal(18, 2)), 7)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (35, N'001900001', 2, CAST(N'2024-05-08' AS Date), N'20240508-011', CAST(95.00 AS Decimal(18, 2)), 34)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (36, N'002000001', 5, CAST(N'2024-05-09' AS Date), N'20240509-012', CAST(300.00 AS Decimal(18, 2)), 6)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (37, N'002100001', 5, CAST(N'2024-05-10' AS Date), N'20240510-013', CAST(180.25 AS Decimal(18, 2)), 8)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (38, N'002200001', 7, CAST(N'2024-05-11' AS Date), N'20240511-014', CAST(75.00 AS Decimal(18, 2)), 9)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (39, N'002300001', 6, CAST(N'2024-05-12' AS Date), N'20240512-015', CAST(18384.00 AS Decimal(18, 2)), 8)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (40, N'002400001', 4, CAST(N'2024-05-13' AS Date), N'20240513-016', CAST(210.00 AS Decimal(18, 2)), 7)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (41, N'002500001', 9, CAST(N'2024-05-14' AS Date), N'20240514-017', CAST(6200.00 AS Decimal(18, 2)), 5)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (42, N'002600001', 7, CAST(N'2024-05-15' AS Date), N'20240515-018', CAST(80.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (43, N'002700001', 0, CAST(N'2024-05-16' AS Date), N'20240516-019', CAST(15.75 AS Decimal(18, 2)), 3)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (44, N'003500001', 0, CAST(N'2024-05-17' AS Date), N'20240517-020', CAST(1500.00 AS Decimal(18, 2)), 6)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (45, N'000100001', 0, CAST(N'2024-05-17' AS Date), N'20240517-020-1', CAST(1500.00 AS Decimal(18, 2)), 200)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (46, N'000100002', 0, CAST(N'2024-05-17' AS Date), N'20240517-020-2', CAST(4500.00 AS Decimal(18, 2)), 200)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (47, N'008000001', 1, CAST(N'2024-05-02' AS Date), N'20240502-003', CAST(5000.00 AS Decimal(18, 2)), 54)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (48, N'000100001', 0, CAST(N'2024-05-17' AS Date), N'20240517-020-1', CAST(1500.00 AS Decimal(18, 2)), 100)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (49, N'000100002', 0, CAST(N'2024-05-17' AS Date), N'20240517-020-2', CAST(4500.00 AS Decimal(18, 2)), 20)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (50, N'000100002', 2, CAST(N'2024-05-16' AS Date), N'20250642-02-5', CAST(3500.00 AS Decimal(18, 2)), 125)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (51, N'000100001', 0, CAST(N'2024-05-01' AS Date), N'20240501-002', CAST(230.50 AS Decimal(18, 2)), 6)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (52, N'000200001', 0, CAST(N'2024-05-02' AS Date), N'20240502-003', CAST(5000.00 AS Decimal(18, 2)), 54)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (53, N'002300001', 0, CAST(N'2024-05-28' AS Date), N'20240528-029', CAST(2750.40 AS Decimal(18, 2)), 9)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (54, N'002400001', 0, CAST(N'2024-05-29' AS Date), N'20240529-030', CAST(7200.35 AS Decimal(18, 2)), 17)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (55, N'002500001', 0, CAST(N'2024-05-30' AS Date), N'20240530-031', CAST(315.20 AS Decimal(18, 2)), 22)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (56, N'002600001', 0, CAST(N'2024-05-31' AS Date), N'20240531-032', CAST(4850.60 AS Decimal(18, 2)), 13)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (57, N'002700001', 0, CAST(N'2024-06-01' AS Date), N'20240601-033', CAST(8100.25 AS Decimal(18, 2)), 26)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (58, N'002800001', 0, CAST(N'2024-06-02' AS Date), N'20240602-034', CAST(125.90 AS Decimal(18, 2)), 39)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (59, N'002900001', 0, CAST(N'2024-06-03' AS Date), N'20240603-035', CAST(375.85 AS Decimal(18, 2)), 18)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (60, N'003000001', 0, CAST(N'2024-06-04' AS Date), N'20240604-036', CAST(9300.00 AS Decimal(18, 2)), 8)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (61, N'003100001', 0, CAST(N'2024-06-05' AS Date), N'20240605-037', CAST(295.45 AS Decimal(18, 2)), 31)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (62, N'003200001', 0, CAST(N'2024-06-06' AS Date), N'20240606-038', CAST(5250.75 AS Decimal(18, 2)), 4)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (63, N'003300001', 0, CAST(N'2024-06-07' AS Date), N'20240607-039', CAST(6800.50 AS Decimal(18, 2)), 21)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (64, N'003400001', 0, CAST(N'2024-06-08' AS Date), N'20240608-040', CAST(180.30 AS Decimal(18, 2)), 44)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (65, N'003500001', 0, CAST(N'2024-06-09' AS Date), N'20240609-041', CAST(2350.20 AS Decimal(18, 2)), 12)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (66, N'003600001', 0, CAST(N'2024-06-10' AS Date), N'20240610-042', CAST(8500.25 AS Decimal(18, 2)), 15)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (67, N'003700001', 0, CAST(N'2024-06-11' AS Date), N'20240611-043', CAST(340.60 AS Decimal(18, 2)), 27)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (68, N'003800001', 0, CAST(N'2024-06-12' AS Date), N'20240612-044', CAST(4950.80 AS Decimal(18, 2)), 6)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (69, N'003900001', 0, CAST(N'2024-06-13' AS Date), N'20240613-045', CAST(7700.00 AS Decimal(18, 2)), 24)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (70, N'004000001', 0, CAST(N'2024-06-14' AS Date), N'20240614-046', CAST(155.25 AS Decimal(18, 2)), 37)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (71, N'004100001', 0, CAST(N'2024-06-15' AS Date), N'20240615-047', CAST(315.90 AS Decimal(18, 2)), 19)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (72, N'004200001', 0, CAST(N'2024-06-16' AS Date), N'20240616-048', CAST(9200.75 AS Decimal(18, 2)), 10)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (73, N'004300001', 0, CAST(N'2024-06-17' AS Date), N'20240617-049', CAST(270.40 AS Decimal(18, 2)), 29)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (76, N'004400001', 0, CAST(N'2024-06-19' AS Date), N'20240619-051', CAST(6400.50 AS Decimal(18, 2)), 32)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (77, N'004600001', 0, CAST(N'2024-06-21' AS Date), N'20240621-053', CAST(575.25 AS Decimal(18, 2)), 25)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (78, N'004700001', 0, CAST(N'2024-06-22' AS Date), N'20240622-054', CAST(8800.00 AS Decimal(18, 2)), 7)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (79, N'004800001', 0, CAST(N'2024-06-23' AS Date), N'20240623-055', CAST(365.90 AS Decimal(18, 2)), 41)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (80, N'004900001', 0, CAST(N'2024-06-24' AS Date), N'20240624-056', CAST(3350.60 AS Decimal(18, 2)), 11)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (81, N'005000001', 0, CAST(N'2024-06-25' AS Date), N'20240625-057', CAST(7500.25 AS Decimal(18, 2)), 22)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (82, N'005100001', 0, CAST(N'2024-06-26' AS Date), N'20240626-058', CAST(145.50 AS Decimal(18, 2)), 36)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (83, N'005200001', 0, CAST(N'2024-06-27' AS Date), N'20240627-059', CAST(485.75 AS Decimal(18, 2)), 17)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (84, N'005300001', 0, CAST(N'2024-06-28' AS Date), N'20240628-060', CAST(9600.80 AS Decimal(18, 2)), 9)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (85, N'005400001', 0, CAST(N'2024-06-29' AS Date), N'20240629-061', CAST(320.25 AS Decimal(18, 2)), 28)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (86, N'005500001', 0, CAST(N'2024-06-30' AS Date), N'20240630-062', CAST(2750.40 AS Decimal(18, 2)), 13)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (87, N'005600002', 0, CAST(N'2024-07-01' AS Date), N'20240701-063', CAST(8200.00 AS Decimal(18, 2)), 19)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (88, N'005700001', 0, CAST(N'2024-07-02' AS Date), N'20240702-064', CAST(195.80 AS Decimal(18, 2)), 33)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (89, N'005800001', 0, CAST(N'2024-07-03' AS Date), N'20240703-065', CAST(415.90 AS Decimal(18, 2)), 21)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (90, N'005900001', 0, CAST(N'2024-07-04' AS Date), N'20240704-066', CAST(6900.75 AS Decimal(18, 2)), 14)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (91, N'006000001', 0, CAST(N'2024-07-05' AS Date), N'20240705-067', CAST(255.60 AS Decimal(18, 2)), 39)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (92, N'006100001', 0, CAST(N'2024-07-06' AS Date), N'20240706-068', CAST(5250.25 AS Decimal(18, 2)), 5)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (93, N'006200001', 0, CAST(N'2024-07-07' AS Date), N'20240707-069', CAST(9300.50 AS Decimal(18, 2)), 16)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (94, N'006300001', 0, CAST(N'2024-07-08' AS Date), N'20240708-070', CAST(175.40 AS Decimal(18, 2)), 42)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (95, N'006400001', 0, CAST(N'2024-07-09' AS Date), N'20240709-071', CAST(3750.80 AS Decimal(18, 2)), 10)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (96, N'006500001', 0, CAST(N'2024-07-10' AS Date), N'20240710-072', CAST(7800.00 AS Decimal(18, 2)), 23)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (97, N'006600001', 0, CAST(N'2024-07-11' AS Date), N'20240711-073', CAST(290.75 AS Decimal(18, 2)), 31)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (98, N'006700001', 0, CAST(N'2024-07-12' AS Date), N'20240712-074', CAST(635.45 AS Decimal(18, 2)), 26)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (99, N'006800001', 0, CAST(N'2024-07-13' AS Date), N'20240713-075', CAST(8500.25 AS Decimal(18, 2)), 12)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (100, N'006900001', 0, CAST(N'2024-07-14' AS Date), N'20240714-076', CAST(135.20 AS Decimal(18, 2)), 47)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (101, N'007000001', 0, CAST(N'2024-07-15' AS Date), N'20240715-077', CAST(2950.60 AS Decimal(18, 2)), 8)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (102, N'007100001', 0, CAST(N'2024-07-16' AS Date), N'20240716-078', CAST(7100.75 AS Decimal(18, 2)), 20)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (103, N'007200001', 0, CAST(N'2024-07-17' AS Date), N'20240717-079', CAST(375.30 AS Decimal(18, 2)), 24)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (104, N'007300001', 0, CAST(N'2024-07-18' AS Date), N'20240718-080', CAST(4550.90 AS Decimal(18, 2)), 15)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (105, N'007400001', 0, CAST(N'2024-07-19' AS Date), N'20240719-081', CAST(9900.00 AS Decimal(18, 2)), 6)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (106, N'007500001', 0, CAST(N'2024-07-20' AS Date), N'20240720-082', CAST(215.85 AS Decimal(18, 2)), 35)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (107, N'007600001', 0, CAST(N'2024-07-21' AS Date), N'20240721-083', CAST(585.75 AS Decimal(18, 2)), 19)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (108, N'000100003', 0, CAST(N'2024-07-22' AS Date), N'20240722-084', CAST(7300.25 AS Decimal(18, 2)), 27)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (109, N'000100004', 0, CAST(N'2024-07-23' AS Date), N'20240723-085', CAST(330.50 AS Decimal(18, 2)), 22)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (110, N'000200003', 0, CAST(N'2024-07-24' AS Date), N'20240724-086', CAST(3850.40 AS Decimal(18, 2)), 11)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (111, N'000200004', 0, CAST(N'2024-07-25' AS Date), N'20240725-087', CAST(8600.75 AS Decimal(18, 2)), 18)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (112, N'000300002', 0, CAST(N'2024-07-26' AS Date), N'20240726-088', CAST(185.90 AS Decimal(18, 2)), 40)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (113, N'000300003', 0, CAST(N'2024-07-27' AS Date), N'20240727-089', CAST(675.25 AS Decimal(18, 2)), 16)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (114, N'000400003', 0, CAST(N'2024-07-28' AS Date), N'20240728-090', CAST(9400.00 AS Decimal(18, 2)), 13)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (115, N'000500002', 0, CAST(N'2024-07-29' AS Date), N'20240729-091', CAST(245.60 AS Decimal(18, 2)), 29)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (116, N'000500003', 0, CAST(N'2024-07-30' AS Date), N'20240730-092', CAST(3250.75 AS Decimal(18, 2)), 7)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (117, N'000600002', 0, CAST(N'2024-07-31' AS Date), N'20240731-093', CAST(6700.50 AS Decimal(18, 2)), 25)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (118, N'000600003', 0, CAST(N'2024-08-01' AS Date), N'20240801-094', CAST(305.25 AS Decimal(18, 2)), 32)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (119, N'000700002', 0, CAST(N'2024-08-02' AS Date), N'20240802-095', CAST(495.80 AS Decimal(18, 2)), 21)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (120, N'000700003', 0, CAST(N'2024-08-03' AS Date), N'20240803-096', CAST(8900.35 AS Decimal(18, 2)), 10)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (121, N'000800002', 0, CAST(N'2024-08-04' AS Date), N'20240804-097', CAST(165.70 AS Decimal(18, 2)), 43)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (122, N'000800003', 0, CAST(N'2024-08-05' AS Date), N'20240805-098', CAST(2750.90 AS Decimal(18, 2)), 14)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (123, N'000900002', 0, CAST(N'2024-08-06' AS Date), N'20240806-099', CAST(7500.00 AS Decimal(18, 2)), 20)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (124, N'000900003', 0, CAST(N'2024-08-07' AS Date), N'20240807-100', CAST(355.40 AS Decimal(18, 2)), 26)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (125, N'001000003', 0, CAST(N'2024-08-08' AS Date), N'20240808-101', CAST(435.25 AS Decimal(18, 2)), 23)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (126, N'001100002', 0, CAST(N'2024-08-09' AS Date), N'20240809-102', CAST(9200.75 AS Decimal(18, 2)), 8)
GO
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (127, N'001100003', 0, CAST(N'2024-08-10' AS Date), N'20240810-103', CAST(195.30 AS Decimal(18, 2)), 44)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (130, N'001200002', 0, CAST(N'2024-08-12' AS Date), N'20240812-105', CAST(6800.25 AS Decimal(18, 2)), 28)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (131, N'001300002', 0, CAST(N'2024-08-14' AS Date), N'20240814-107', CAST(725.45 AS Decimal(18, 2)), 18)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (132, N'001300003', 0, CAST(N'2024-08-15' AS Date), N'20240815-108', CAST(8300.50 AS Decimal(18, 2)), 15)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (133, N'001400002', 0, CAST(N'2024-08-16' AS Date), N'20240816-109', CAST(145.80 AS Decimal(18, 2)), 49)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (134, N'001400003', 0, CAST(N'2024-08-17' AS Date), N'20240817-110', CAST(3650.25 AS Decimal(18, 2)), 12)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (135, N'001500002', 0, CAST(N'2024-08-18' AS Date), N'20240818-111', CAST(9700.00 AS Decimal(18, 2)), 7)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (136, N'001500003', 0, CAST(N'2024-08-19' AS Date), N'20240819-112', CAST(395.20 AS Decimal(18, 2)), 27)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (137, N'001600002', 0, CAST(N'2024-08-20' AS Date), N'20240820-113', CAST(545.75 AS Decimal(18, 2)), 20)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (138, N'001600003', 0, CAST(N'2024-08-21' AS Date), N'20240821-114', CAST(7100.80 AS Decimal(18, 2)), 21)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (139, N'001700002', 0, CAST(N'2024-08-22' AS Date), N'20240822-115', CAST(225.60 AS Decimal(18, 2)), 34)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (140, N'001700003', 0, CAST(N'2024-08-23' AS Date), N'20240823-116', CAST(2950.40 AS Decimal(18, 2)), 13)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (141, N'001800002', 0, CAST(N'2024-08-24' AS Date), N'20240824-117', CAST(8800.25 AS Decimal(18, 2)), 16)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (142, N'001800003', 0, CAST(N'2024-08-25' AS Date), N'20240825-118', CAST(315.90 AS Decimal(18, 2)), 31)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (143, N'001900002', 0, CAST(N'2024-08-26' AS Date), N'20240826-119', CAST(655.25 AS Decimal(18, 2)), 24)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (144, N'001900003', 0, CAST(N'2024-08-27' AS Date), N'20240827-120', CAST(9400.75 AS Decimal(18, 2)), 11)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (145, N'002000002', 0, CAST(N'2024-08-28' AS Date), N'20240828-121', CAST(175.45 AS Decimal(18, 2)), 42)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (146, N'002000003', 0, CAST(N'2024-08-29' AS Date), N'20240829-122', CAST(4250.80 AS Decimal(18, 2)), 10)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (147, N'002100002', 0, CAST(N'2024-08-30' AS Date), N'20240830-123', CAST(7900.00 AS Decimal(18, 2)), 19)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (148, N'002100003', 0, CAST(N'2024-08-31' AS Date), N'20240831-124', CAST(265.30 AS Decimal(18, 2)), 28)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (149, N'002200002', 0, CAST(N'2024-09-01' AS Date), N'20240901-125', CAST(585.90 AS Decimal(18, 2)), 17)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (150, N'002200003', 0, CAST(N'2024-09-02' AS Date), N'20240902-126', CAST(8500.50 AS Decimal(18, 2)), 22)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (151, N'002300002', 0, CAST(N'2024-09-03' AS Date), N'20240903-127', CAST(345.75 AS Decimal(18, 2)), 25)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (152, N'000100001', 5, CAST(N'2025-03-12' AS Date), N'20250312-001', CAST(315.80 AS Decimal(18, 2)), 42)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (153, N'001600002', 8, CAST(N'2025-05-07' AS Date), N'20250507-001', CAST(185.25 AS Decimal(18, 2)), 17)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (154, N'003700001', 2, CAST(N'2025-02-14' AS Date), N'20250214-001', CAST(420.90 AS Decimal(18, 2)), 73)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (155, N'004900001', 11, CAST(N'2025-01-29' AS Date), N'20250129-001', CAST(635.40 AS Decimal(18, 2)), 28)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (156, N'002500002', 3, CAST(N'2025-04-22' AS Date), N'20250422-001', CAST(290.75 AS Decimal(18, 2)), 55)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (157, N'007300001', 9, CAST(N'2025-03-17' AS Date), N'20250317-001', CAST(150.60 AS Decimal(18, 2)), 89)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (158, N'000800002', 6, CAST(N'2025-06-05' AS Date), N'20250605-001', CAST(725.30 AS Decimal(18, 2)), 14)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (161, N'001200003', 4, CAST(N'2025-05-19' AS Date), N'20250519-001', CAST(195.40 AS Decimal(18, 2)), 61)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (162, N'006100001', 1, CAST(N'2025-02-28' AS Date), N'20250228-001', CAST(560.80 AS Decimal(18, 2)), 22)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (163, N'000300003', 10, CAST(N'2025-05-25' AS Date), N'20250525-001', CAST(920.45 AS Decimal(18, 2)), 8)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (164, N'002900001', 5, CAST(N'2025-01-09' AS Date), N'20250109-001', CAST(245.90 AS Decimal(18, 2)), 76)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (165, N'005000001', 8, CAST(N'2025-03-30' AS Date), N'20250330-001', CAST(680.35 AS Decimal(18, 2)), 35)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (166, N'001100003', 2, CAST(N'2025-04-13' AS Date), N'20250413-001', CAST(175.60 AS Decimal(18, 2)), 84)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (167, N'007000001', 11, CAST(N'2025-02-07' AS Date), N'20250207-001', CAST(430.70 AS Decimal(18, 2)), 51)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (168, N'000600003', 3, CAST(N'2024-06-24' AS Date), N'20240624-001', CAST(795.20 AS Decimal(18, 2)), 19)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (169, N'003200001', 9, CAST(N'2025-05-18' AS Date), N'20250518-001', CAST(325.10 AS Decimal(18, 2)), 67)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (170, N'004500001', 6, CAST(N'2024-12-02' AS Date), N'20241202-001', CAST(540.85 AS Decimal(18, 2)), 45)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (173, N'006500001', 4, CAST(N'2025-01-27' AS Date), N'20250127-001', CAST(875.50 AS Decimal(18, 2)), 26)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (174, N'002300002', 1, CAST(N'2024-11-21' AS Date), N'20241121-001', CAST(610.30 AS Decimal(18, 2)), 31)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (175, N'005900001', 10, CAST(N'2025-05-06' AS Date), N'20250506-001', CAST(190.80 AS Decimal(18, 2)), 74)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (176, N'003900001', 5, CAST(N'2025-03-29' AS Date), N'20250329-001', CAST(480.65 AS Decimal(18, 2)), 12)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (177, N'001300003', 8, CAST(N'2025-05-14' AS Date), N'20250514-001', CAST(260.40 AS Decimal(18, 2)), 63)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (178, N'007600001', 2, CAST(N'2025-01-04' AS Date), N'20250104-001', CAST(705.15 AS Decimal(18, 2)), 37)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (179, N'000400002', 11, CAST(N'2025-02-23' AS Date), N'20250223-001', CAST(145.90 AS Decimal(18, 2)), 81)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (180, N'004100001', 3, CAST(N'2024-06-17' AS Date), N'20240617-001', CAST(590.75 AS Decimal(18, 2)), 24)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (181, N'002700001', 9, CAST(N'2024-10-10' AS Date), N'20241010-001', CAST(230.55 AS Decimal(18, 2)), 69)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (182, N'005300001', 6, CAST(N'2024-09-01' AS Date), N'20240901-001', CAST(670.20 AS Decimal(18, 2)), 41)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (185, N'006900001', 4, CAST(N'2025-03-19' AS Date), N'20250319-001', CAST(820.10 AS Decimal(18, 2)), 53)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (186, N'003500001', 1, CAST(N'2024-11-05' AS Date), N'20241105-001', CAST(450.30 AS Decimal(18, 2)), 29)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (187, N'004800001', 10, CAST(N'2025-02-28' AS Date), N'20250228-002', CAST(740.95 AS Decimal(18, 2)), 65)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (188, N'002100003', 5, CAST(N'2025-01-15' AS Date), N'20250115-001', CAST(275.40 AS Decimal(18, 2)), 78)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (189, N'007500001', 8, CAST(N'2025-04-09' AS Date), N'20250409-001', CAST(510.25 AS Decimal(18, 2)), 43)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (190, N'000100003', 2, CAST(N'2025-03-22' AS Date), N'20250322-001', CAST(895.70 AS Decimal(18, 2)), 21)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (191, N'005700001', 11, CAST(N'2024-06-13' AS Date), N'20240613-001', CAST(165.35 AS Decimal(18, 2)), 59)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (192, N'001000003', 3, CAST(N'2025-05-30' AS Date), N'20250530-001', CAST(380.80 AS Decimal(18, 2)), 35)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (193, N'004300001', 9, CAST(N'2025-04-24' AS Date), N'20250424-001', CAST(625.15 AS Decimal(18, 2)), 48)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (194, N'002800003', 6, CAST(N'2024-12-07' AS Date), N'20241207-001', CAST(210.90 AS Decimal(18, 2)), 82)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (197, N'000500002', 4, CAST(N'2025-02-18' AS Date), N'20250218-001', CAST(325.60 AS Decimal(18, 2)), 72)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (198, N'005200001', 1, CAST(N'2025-05-04' AS Date), N'20250504-001', CAST(145.75 AS Decimal(18, 2)), 64)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (199, N'007200001', 10, CAST(N'2025-04-27' AS Date), N'20250427-001', CAST(490.30 AS Decimal(18, 2)), 38)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (200, N'000900003', 5, CAST(N'2024-06-14' AS Date), N'20240614-001', CAST(835.85 AS Decimal(18, 2)), 52)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (201, N'004000001', 8, CAST(N'2024-09-09' AS Date), N'20240909-001', CAST(195.20 AS Decimal(18, 2)), 86)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (202, N'002400002', 2, CAST(N'2025-02-02' AS Date), N'20250202-001', CAST(540.65 AS Decimal(18, 2)), 23)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (203, N'006800001', 11, CAST(N'2025-03-25' AS Date), N'20250325-001', CAST(280.40 AS Decimal(18, 2)), 57)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (204, N'001700002', 3, CAST(N'2025-04-18' AS Date), N'20250418-001', CAST(610.95 AS Decimal(18, 2)), 44)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (205, N'003600001', 9, CAST(N'2025-05-11' AS Date), N'20250511-001', CAST(175.80 AS Decimal(18, 2)), 79)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (206, N'005800001', 6, CAST(N'2024-10-05' AS Date), N'20241005-001', CAST(420.25 AS Decimal(18, 2)), 31)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (209, N'004700001', 4, CAST(N'2025-05-21' AS Date), N'20250521-001', CAST(235.15 AS Decimal(18, 2)), 18)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (210, N'007100001', 1, CAST(N'2025-03-07' AS Date), N'20250307-001', CAST(320.65 AS Decimal(18, 2)), 87)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (211, N'000800003', 10, CAST(N'2025-04-30' AS Date), N'20250430-001', CAST(665.30 AS Decimal(18, 2)), 32)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (212, N'005400001', 5, CAST(N'2025-02-23' AS Date), N'20250223-002', CAST(190.75 AS Decimal(18, 2)), 71)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (215, N'001500003', 2, CAST(N'2024-06-09' AS Date), N'20240609-001', CAST(780.85 AS Decimal(18, 2)), 49)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (216, N'004600001', 3, CAST(N'2025-04-25' AS Date), N'20250425-001', CAST(520.55 AS Decimal(18, 2)), 36)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (217, N'002600001', 9, CAST(N'2025-03-18' AS Date), N'20250318-001', CAST(175.90 AS Decimal(18, 2)), 68)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (218, N'007400001', 6, CAST(N'2024-11-11' AS Date), N'20241111-001', CAST(410.45 AS Decimal(18, 2)), 15)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (221, N'005100001', 4, CAST(N'2025-05-27' AS Date), N'20250527-001', CAST(295.25 AS Decimal(18, 2)), 41)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (222, N'001800003', 1, CAST(N'2025-04-13' AS Date), N'20250413-002', CAST(185.35 AS Decimal(18, 2)), 26)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (223, N'006400001', 10, CAST(N'2024-12-06' AS Date), N'20241206-001', CAST(480.90 AS Decimal(18, 2)), 62)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (224, N'000700002', 5, CAST(N'2025-03-29' AS Date), N'20250329-002', CAST(825.45 AS Decimal(18, 2)), 17)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (225, N'004200001', 8, CAST(N'2025-05-22' AS Date), N'20250522-001', CAST(240.60 AS Decimal(18, 2)), 84)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (226, N'002900003', 2, CAST(N'2025-02-15' AS Date), N'20250215-001', CAST(575.15 AS Decimal(18, 2)), 39)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (227, N'007900001', 11, CAST(N'2025-04-08' AS Date), N'20250408-002', CAST(320.80 AS Decimal(18, 2)), 55)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (228, N'000400003', 3, CAST(N'2025-01-01' AS Date), N'20250101-001', CAST(670.25 AS Decimal(18, 2)), 91)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (229, N'005600001', 9, CAST(N'2024-06-24' AS Date), N'20240624-002', CAST(205.90 AS Decimal(18, 2)), 22)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (230, N'003300001', 6, CAST(N'2025-05-17' AS Date), N'20250517-001', CAST(440.55 AS Decimal(18, 2)), 47)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (233, N'006700001', 4, CAST(N'2024-08-03' AS Date), N'20240803-001', CAST(270.65 AS Decimal(18, 2)), 77)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (234, N'004900001', 1, CAST(N'2025-01-19' AS Date), N'20250119-001', CAST(180.85 AS Decimal(18, 2)), 63)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (235, N'002100002', 10, CAST(N'2025-05-12' AS Date), N'20250512-002', CAST(425.40 AS Decimal(18, 2)), 19)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (236, N'007300001', 5, CAST(N'2024-10-05' AS Date), N'20241005-002', CAST(760.95 AS Decimal(18, 2)), 53)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (237, N'000100004', 8, CAST(N'2025-02-28' AS Date), N'20250228-003', CAST(235.50 AS Decimal(18, 2)), 88)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (238, N'005000001', 2, CAST(N'2025-03-21' AS Date), N'20250321-001', CAST(580.25 AS Decimal(18, 2)), 44)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (239, N'003800001', 11, CAST(N'2025-04-14' AS Date), N'20250414-001', CAST(195.70 AS Decimal(18, 2)), 69)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (240, N'001200002', 3, CAST(N'2025-05-07' AS Date), N'20250507-002', CAST(530.15 AS Decimal(18, 2)), 36)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (241, N'006200001', 9, CAST(N'2025-05-30' AS Date), N'20250530-002', CAST(285.80 AS Decimal(18, 2)), 81)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (242, N'004000001', 6, CAST(N'2024-12-23' AS Date), N'20241223-001', CAST(620.45 AS Decimal(18, 2)), 24)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (245, N'008000001', 4, CAST(N'2025-03-09' AS Date), N'20250309-001', CAST(415.35 AS Decimal(18, 2)), 72)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (246, N'005900001', 1, CAST(N'2025-05-25' AS Date), N'20250525-002', CAST(290.25 AS Decimal(18, 2)), 46)
GO
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (247, N'003200001', 10, CAST(N'2024-06-18' AS Date), N'20240618-001', CAST(540.70 AS Decimal(18, 2)), 82)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (248, N'001300002', 5, CAST(N'2024-11-11' AS Date), N'20241111-002', CAST(185.15 AS Decimal(18, 2)), 13)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (249, N'007500001', 8, CAST(N'2025-02-04' AS Date), N'20250204-002', CAST(430.80 AS Decimal(18, 2)), 67)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (250, N'000300001', 2, CAST(N'2025-03-27' AS Date), N'20250327-001', CAST(775.25 AS Decimal(18, 2)), 38)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (251, N'004800001', 11, CAST(N'2025-04-20' AS Date), N'20250420-001', CAST(240.40 AS Decimal(18, 2)), 75)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (252, N'002000003', 3, CAST(N'2025-05-13' AS Date), N'20250513-001', CAST(585.95 AS Decimal(18, 2)), 21)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (253, N'006600001', 9, CAST(N'2024-12-06' AS Date), N'20241206-002', CAST(195.50 AS Decimal(18, 2)), 59)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (254, N'005200001', 6, CAST(N'2025-01-29' AS Date), N'20250129-002', CAST(520.05 AS Decimal(18, 2)), 42)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (257, N'003900001', 4, CAST(N'2025-03-15' AS Date), N'20250315-002', CAST(610.35 AS Decimal(18, 2)), 27)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (258, N'000900002', 1, CAST(N'2025-05-01' AS Date), N'20250501-001', CAST(425.45 AS Decimal(18, 2)), 48)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (259, N'005300001', 10, CAST(N'2025-05-24' AS Date), N'20250524-001', CAST(760.20 AS Decimal(18, 2)), 33)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (260, N'004100001', 5, CAST(N'2024-06-17' AS Date), N'20240617-002', CAST(210.65 AS Decimal(18, 2)), 78)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (261, N'002800002', 8, CAST(N'2024-10-10' AS Date), N'20241010-002', CAST(555.30 AS Decimal(18, 2)), 15)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (262, N'006100001', 2, CAST(N'2024-11-03' AS Date), N'20241103-001', CAST(190.95 AS Decimal(18, 2)), 61)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (263, N'000400001', 11, CAST(N'2025-04-26' AS Date), N'20250426-003', CAST(435.70 AS Decimal(18, 2)), 29)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (264, N'005700001', 3, CAST(N'2025-05-19' AS Date), N'20250519-002', CAST(780.25 AS Decimal(18, 2)), 54)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (265, N'003500001', 9, CAST(N'2024-12-12' AS Date), N'20241212-001', CAST(245.40 AS Decimal(18, 2)), 87)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (266, N'001000001', 6, CAST(N'2025-01-05' AS Date), N'20250105-001', CAST(590.85 AS Decimal(18, 2)), 23)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (269, N'000200003', 4, CAST(N'2025-03-21' AS Date), N'20250321-002', CAST(525.15 AS Decimal(18, 2)), 41)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (270, N'003600001', 1, CAST(N'2025-05-07' AS Date), N'20250507-003', CAST(610.25 AS Decimal(18, 2)), 19)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (271, N'006900001', 10, CAST(N'2025-05-30' AS Date), N'20250530-003', CAST(165.90 AS Decimal(18, 2)), 52)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (272, N'004500001', 5, CAST(N'2024-06-23' AS Date), N'20240623-001', CAST(440.35 AS Decimal(18, 2)), 83)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (273, N'002600002', 8, CAST(N'2024-09-16' AS Date), N'20240916-001', CAST(785.80 AS Decimal(18, 2)), 37)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (274, N'007600001', 2, CAST(N'2025-02-09' AS Date), N'20250209-001', CAST(230.45 AS Decimal(18, 2)), 71)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (275, N'000500003', 11, CAST(N'2025-03-02' AS Date), N'20250302-001', CAST(575.10 AS Decimal(18, 2)), 26)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (276, N'005400001', 3, CAST(N'2025-04-25' AS Date), N'20250425-002', CAST(195.65 AS Decimal(18, 2)), 58)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (277, N'001900003', 9, CAST(N'2025-05-18' AS Date), N'20250518-002', CAST(420.30 AS Decimal(18, 2)), 44)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (278, N'003000002', 6, CAST(N'2024-06-11' AS Date), N'20240611-001', CAST(765.95 AS Decimal(18, 2)), 89)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (281, N'004700001', 4, CAST(N'2025-01-27' AS Date), N'20250127-002', CAST(505.55 AS Decimal(18, 2)), 66)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (282, N'007000001', 1, CAST(N'2025-04-13' AS Date), N'20250413-003', CAST(435.25 AS Decimal(18, 2)), 79)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (283, N'000800001', 10, CAST(N'2025-05-06' AS Date), N'20250506-002', CAST(680.90 AS Decimal(18, 2)), 35)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (284, N'005500001', 5, CAST(N'2025-05-29' AS Date), N'20250529-001', CAST(225.35 AS Decimal(18, 2)), 62)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (285, N'003100001', 8, CAST(N'2024-12-22' AS Date), N'20241222-001', CAST(560.70 AS Decimal(18, 2)), 47)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (286, N'001600001', 2, CAST(N'2025-01-15' AS Date), N'20250115-002', CAST(195.15 AS Decimal(18, 2)), 81)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (287, N'006500001', 11, CAST(N'2025-03-08' AS Date), N'20250308-001', CAST(430.40 AS Decimal(18, 2)), 28)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (288, N'004300001', 3, CAST(N'2025-04-01' AS Date), N'20250401-001', CAST(775.85 AS Decimal(18, 2)), 53)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (289, N'002900002', 9, CAST(N'2025-05-24' AS Date), N'20250524-002', CAST(240.50 AS Decimal(18, 2)), 38)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (290, N'007400001', 6, CAST(N'2024-06-17' AS Date), N'20240617-003', CAST(585.05 AS Decimal(18, 2)), 72)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (293, N'005600002', 4, CAST(N'2024-11-03' AS Date), N'20241103-002', CAST(425.75 AS Decimal(18, 2)), 59)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (294, N'001500002', 1, CAST(N'2025-05-19' AS Date), N'20250519-003', CAST(210.85 AS Decimal(18, 2)), 77)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (295, N'006800001', 10, CAST(N'2024-06-12' AS Date), N'20240612-001', CAST(545.40 AS Decimal(18, 2)), 24)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (298, N'002700003', 8, CAST(N'2025-02-28' AS Date), N'20250228-005', CAST(530.65 AS Decimal(18, 2)), 32)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (299, N'000600001', 11, CAST(N'2025-04-14' AS Date), N'20250414-003', CAST(420.75 AS Decimal(18, 2)), 39)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (300, N'005100001', 3, CAST(N'2025-05-07' AS Date), N'20250507-004', CAST(665.50 AS Decimal(18, 2)), 54)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (301, N'003300001', 9, CAST(N'2025-05-30' AS Date), N'20250530-004', CAST(230.25 AS Decimal(18, 2)), 21)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (302, N'001800002', 6, CAST(N'2024-12-23' AS Date), N'20241223-002', CAST(575.80 AS Decimal(18, 2)), 64)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (305, N'004600001', 4, CAST(N'2025-03-09' AS Date), N'20250309-002', CAST(440.90 AS Decimal(18, 2)), 74)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (306, N'007100001', 1, CAST(N'2025-05-25' AS Date), N'20250525-003', CAST(250.60 AS Decimal(18, 2)), 82)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (307, N'000700001', 10, CAST(N'2024-06-18' AS Date), N'20240618-002', CAST(505.15 AS Decimal(18, 2)), 36)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (308, N'005200001', 5, CAST(N'2024-09-11' AS Date), N'20240911-001', CAST(170.70 AS Decimal(18, 2)), 61)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (309, N'003800001', 8, CAST(N'2024-10-04' AS Date), N'20241004-001', CAST(415.25 AS Decimal(18, 2)), 46)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (310, N'001400001', 2, CAST(N'2025-04-27' AS Date), N'20250427-002', CAST(750.80 AS Decimal(18, 2)), 31)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (311, N'006000001', 11, CAST(N'2025-05-20' AS Date), N'20250520-001', CAST(285.35 AS Decimal(18, 2)), 67)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (312, N'004200001', 3, CAST(N'2024-06-13' AS Date), N'20240613-002', CAST(520.40 AS Decimal(18, 2)), 52)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (313, N'002400001', 9, CAST(N'2025-01-06' AS Date), N'20250106-001', CAST(185.95 AS Decimal(18, 2)), 87)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (314, N'007500001', 6, CAST(N'2025-03-29' AS Date), N'20250329-003', CAST(430.50 AS Decimal(18, 2)), 23)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (317, N'005300001', 4, CAST(N'2025-05-15' AS Date), N'20250515-001', CAST(220.60 AS Decimal(18, 2)), 42)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (318, N'001300001', 1, CAST(N'2024-07-01' AS Date), N'20240701-001', CAST(195.80 AS Decimal(18, 2)), 11)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (319, N'006700001', 10, CAST(N'2025-02-24' AS Date), N'20250224-001', CAST(420.45 AS Decimal(18, 2)), 63)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (320, N'004100001', 5, CAST(N'2025-03-17' AS Date), N'20250317-002', CAST(755.90 AS Decimal(18, 2)), 28)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (321, N'002500001', 8, CAST(N'2025-04-10' AS Date), N'20250410-001', CAST(240.25 AS Decimal(18, 2)), 73)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (322, N'007200001', 2, CAST(N'2025-05-03' AS Date), N'20250503-001', CAST(585.70 AS Decimal(18, 2)), 34)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (323, N'000500003', 11, CAST(N'2025-05-26' AS Date), N'20250526-001', CAST(170.35 AS Decimal(18, 2)), 79)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (324, N'005400001', 3, CAST(N'2024-06-19' AS Date), N'20240619-001', CAST(435.80 AS Decimal(18, 2)), 47)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (325, N'003600001', 9, CAST(N'2024-10-12' AS Date), N'20241012-001', CAST(780.25 AS Decimal(18, 2)), 22)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (326, N'001900001', 6, CAST(N'2024-11-05' AS Date), N'20241105-002', CAST(225.90 AS Decimal(18, 2)), 65)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (329, N'004000001', 4, CAST(N'2025-05-21' AS Date), N'20250521-002', CAST(195.40 AS Decimal(18, 2)), 84)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (330, N'007300001', 1, CAST(N'2025-01-07' AS Date), N'20250107-001', CAST(675.60 AS Decimal(18, 2)), 53)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (331, N'000800001', 10, CAST(N'2025-03-30' AS Date), N'20250330-002', CAST(210.05 AS Decimal(18, 2)), 68)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (332, N'005900001', 5, CAST(N'2025-04-23' AS Date), N'20250423-001', CAST(545.70 AS Decimal(18, 2)), 43)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (333, N'003700001', 8, CAST(N'2025-05-16' AS Date), N'20250516-002', CAST(180.25 AS Decimal(18, 2)), 88)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (334, N'001000001', 2, CAST(N'2024-06-09' AS Date), N'20240609-002', CAST(415.80 AS Decimal(18, 2)), 27)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (335, N'006500001', 11, CAST(N'2024-07-02' AS Date), N'20240702-001', CAST(760.35 AS Decimal(18, 2)), 72)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (336, N'004800001', 3, CAST(N'2025-01-25' AS Date), N'20250125-001', CAST(235.50 AS Decimal(18, 2)), 14)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (337, N'002100001', 9, CAST(N'2025-03-18' AS Date), N'20250318-002', CAST(580.15 AS Decimal(18, 2)), 59)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (338, N'007400001', 6, CAST(N'2025-04-11' AS Date), N'20250411-001', CAST(195.65 AS Decimal(18, 2)), 34)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (341, N'005000001', 4, CAST(N'2025-05-27' AS Date), N'20250527-002', CAST(670.85 AS Decimal(18, 2)), 29)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (342, N'001600001', 1, CAST(N'2024-09-13' AS Date), N'20240913-001', CAST(565.95 AS Decimal(18, 2)), 49)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (343, N'006900001', 10, CAST(N'2025-02-06' AS Date), N'20250206-001', CAST(180.70 AS Decimal(18, 2)), 83)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (344, N'004900001', 5, CAST(N'2025-04-29' AS Date), N'20250429-001', CAST(430.25 AS Decimal(18, 2)), 38)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (345, N'002900002', 0, CAST(N'2025-06-16' AS Date), N'20250616-001', CAST(0.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (346, N'001200003', 0, CAST(N'2025-06-16' AS Date), N'20250616-002', CAST(0.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (347, N'001200003', 2, CAST(N'2025-06-16' AS Date), N'20250616-002', CAST(0.00 AS Decimal(18, 2)), 8)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (348, N'005000001', 12, CAST(N'2025-06-16' AS Date), N'20250330-001', CAST(680.35 AS Decimal(18, 2)), 4)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (349, N'002600001', 12, CAST(N'2025-06-16' AS Date), N'20240515-018', CAST(80.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Balances] ([BalanceID], [NomenclatureNumber], [StorageID], [BalanceDate], [BatchNumber], [Price], [Quantity]) VALUES (350, N'000500001', 12, CAST(N'2025-06-16' AS Date), N'20240505-008', CAST(3200.00 AS Decimal(18, 2)), 3)
SET IDENTITY_INSERT [dbo].[Balances] OFF
GO
SET IDENTITY_INSERT [dbo].[DefectiveLists] ON 

INSERT [dbo].[DefectiveLists] ([DefectiveListID], [DefectiveListDate], [NomenclatureNumber], [WorkshopID], [BatchNumber], [Price], [Quantity], [IsWriteOff]) VALUES (2, CAST(N'2025-06-13' AS Date), N'000500001', 0, N'20240505-008', CAST(3200.00 AS Decimal(18, 2)), 3, 0)
INSERT [dbo].[DefectiveLists] ([DefectiveListID], [DefectiveListDate], [NomenclatureNumber], [WorkshopID], [BatchNumber], [Price], [Quantity], [IsWriteOff]) VALUES (3, CAST(N'2025-06-16' AS Date), N'001800001', 3, N'20240507-010', CAST(8000.00 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[DefectiveLists] ([DefectiveListID], [DefectiveListDate], [NomenclatureNumber], [WorkshopID], [BatchNumber], [Price], [Quantity], [IsWriteOff]) VALUES (4, CAST(N'2025-06-16' AS Date), N'004300001', 3, N'20250401-001', CAST(775.85 AS Decimal(18, 2)), 2, 0)
INSERT [dbo].[DefectiveLists] ([DefectiveListID], [DefectiveListDate], [NomenclatureNumber], [WorkshopID], [BatchNumber], [Price], [Quantity], [IsWriteOff]) VALUES (5, CAST(N'2025-06-16' AS Date), N'005100001', 3, N'20250507-004', CAST(665.50 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[DefectiveLists] ([DefectiveListID], [DefectiveListDate], [NomenclatureNumber], [WorkshopID], [BatchNumber], [Price], [Quantity], [IsWriteOff]) VALUES (6, CAST(N'2025-06-16' AS Date), N'005800001', 6, N'20241005-001', CAST(420.25 AS Decimal(18, 2)), 5, 0)
INSERT [dbo].[DefectiveLists] ([DefectiveListID], [DefectiveListDate], [NomenclatureNumber], [WorkshopID], [BatchNumber], [Price], [Quantity], [IsWriteOff]) VALUES (7, CAST(N'2025-06-16' AS Date), N'001200003', 5, N'20250519-001', CAST(195.40 AS Decimal(18, 2)), 1, 1)
INSERT [dbo].[DefectiveLists] ([DefectiveListID], [DefectiveListDate], [NomenclatureNumber], [WorkshopID], [BatchNumber], [Price], [Quantity], [IsWriteOff]) VALUES (8, CAST(N'2025-06-16' AS Date), N'000700002', 7, N'20250329-002', CAST(825.45 AS Decimal(18, 2)), 1, 0)
INSERT [dbo].[DefectiveLists] ([DefectiveListID], [DefectiveListDate], [NomenclatureNumber], [WorkshopID], [BatchNumber], [Price], [Quantity], [IsWriteOff]) VALUES (9, CAST(N'2025-06-16' AS Date), N'002200002', 0, N'20240901-125', CAST(585.90 AS Decimal(18, 2)), 1, 0)
INSERT [dbo].[DefectiveLists] ([DefectiveListID], [DefectiveListDate], [NomenclatureNumber], [WorkshopID], [BatchNumber], [Price], [Quantity], [IsWriteOff]) VALUES (10, CAST(N'2025-06-16' AS Date), N'002600001', 8, N'20240515-018', CAST(80.00 AS Decimal(18, 2)), 1, 0)
INSERT [dbo].[DefectiveLists] ([DefectiveListID], [DefectiveListDate], [NomenclatureNumber], [WorkshopID], [BatchNumber], [Price], [Quantity], [IsWriteOff]) VALUES (11, CAST(N'2025-06-16' AS Date), N'002300002', 1, N'20241121-001', CAST(610.30 AS Decimal(18, 2)), 2, 1)
INSERT [dbo].[DefectiveLists] ([DefectiveListID], [DefectiveListDate], [NomenclatureNumber], [WorkshopID], [BatchNumber], [Price], [Quantity], [IsWriteOff]) VALUES (12, CAST(N'2025-06-16' AS Date), N'004700001', 5, N'20250521-001', CAST(235.15 AS Decimal(18, 2)), 5, 1)
INSERT [dbo].[DefectiveLists] ([DefectiveListID], [DefectiveListDate], [NomenclatureNumber], [WorkshopID], [BatchNumber], [Price], [Quantity], [IsWriteOff]) VALUES (13, CAST(N'2025-06-16' AS Date), N'005000001', 9, N'20250330-001', CAST(680.35 AS Decimal(18, 2)), 4, 1)
INSERT [dbo].[DefectiveLists] ([DefectiveListID], [DefectiveListDate], [NomenclatureNumber], [WorkshopID], [BatchNumber], [Price], [Quantity], [IsWriteOff]) VALUES (14, CAST(N'2025-06-16' AS Date), N'003300001', 10, N'20250530-004', CAST(230.25 AS Decimal(18, 2)), 2, 0)
INSERT [dbo].[DefectiveLists] ([DefectiveListID], [DefectiveListDate], [NomenclatureNumber], [WorkshopID], [BatchNumber], [Price], [Quantity], [IsWriteOff]) VALUES (15, CAST(N'2025-06-16' AS Date), N'002800003', 6, N'20241207-001', CAST(210.90 AS Decimal(18, 2)), 1, 1)
SET IDENTITY_INSERT [dbo].[DefectiveLists] OFF
GO
SET IDENTITY_INSERT [dbo].[DeliveryLists] ON 

INSERT [dbo].[DeliveryLists] ([DeliveryListID], [DeliveryListDate], [SupplierINN]) VALUES (44, CAST(N'2025-06-13' AS Date), N'7799012345')
INSERT [dbo].[DeliveryLists] ([DeliveryListID], [DeliveryListDate], [SupplierINN]) VALUES (54, CAST(N'2025-06-14' AS Date), N'7755678901')
INSERT [dbo].[DeliveryLists] ([DeliveryListID], [DeliveryListDate], [SupplierINN]) VALUES (55, CAST(N'2025-06-14' AS Date), N'7733456789')
INSERT [dbo].[DeliveryLists] ([DeliveryListID], [DeliveryListDate], [SupplierINN]) VALUES (56, CAST(N'2025-06-14' AS Date), N'7733456789')
INSERT [dbo].[DeliveryLists] ([DeliveryListID], [DeliveryListDate], [SupplierINN]) VALUES (61, CAST(N'2025-06-14' AS Date), N'7811234567')
INSERT [dbo].[DeliveryLists] ([DeliveryListID], [DeliveryListDate], [SupplierINN]) VALUES (67, CAST(N'2025-06-14' AS Date), N'7800123456')
INSERT [dbo].[DeliveryLists] ([DeliveryListID], [DeliveryListDate], [SupplierINN]) VALUES (68, CAST(N'2025-06-16' AS Date), N'7844567890')
SET IDENTITY_INSERT [dbo].[DeliveryLists] OFF
GO
SET IDENTITY_INSERT [dbo].[DeliveryListsContent] ON 

INSERT [dbo].[DeliveryListsContent] ([DeliveryContentID], [DeliveryListID], [PurchaseContentID], [DeliveryContentDate], [ContractNumber], [Quantity], [Price]) VALUES (71, 44, 30, CAST(N'2025-09-01' AS Date), N'0', 9, NULL)
INSERT [dbo].[DeliveryListsContent] ([DeliveryContentID], [DeliveryListID], [PurchaseContentID], [DeliveryContentDate], [ContractNumber], [Quantity], [Price]) VALUES (72, 44, 31, CAST(N'2025-09-01' AS Date), N'0', 3, NULL)
INSERT [dbo].[DeliveryListsContent] ([DeliveryContentID], [DeliveryListID], [PurchaseContentID], [DeliveryContentDate], [ContractNumber], [Quantity], [Price]) VALUES (77, 54, 35, CAST(N'2025-09-01' AS Date), N'0', 22, NULL)
INSERT [dbo].[DeliveryListsContent] ([DeliveryContentID], [DeliveryListID], [PurchaseContentID], [DeliveryContentDate], [ContractNumber], [Quantity], [Price]) VALUES (78, 54, 36, CAST(N'2025-09-01' AS Date), N'0', 11, NULL)
INSERT [dbo].[DeliveryListsContent] ([DeliveryContentID], [DeliveryListID], [PurchaseContentID], [DeliveryContentDate], [ContractNumber], [Quantity], [Price]) VALUES (79, 54, 37, CAST(N'2025-09-01' AS Date), N'0', 4, NULL)
INSERT [dbo].[DeliveryListsContent] ([DeliveryContentID], [DeliveryListID], [PurchaseContentID], [DeliveryContentDate], [ContractNumber], [Quantity], [Price]) VALUES (80, 54, 38, CAST(N'2025-09-01' AS Date), N'0', 3, NULL)
INSERT [dbo].[DeliveryListsContent] ([DeliveryContentID], [DeliveryListID], [PurchaseContentID], [DeliveryContentDate], [ContractNumber], [Quantity], [Price]) VALUES (82, 55, 39, CAST(N'2025-09-01' AS Date), N'0', 11, NULL)
INSERT [dbo].[DeliveryListsContent] ([DeliveryContentID], [DeliveryListID], [PurchaseContentID], [DeliveryContentDate], [ContractNumber], [Quantity], [Price]) VALUES (83, 56, 40, CAST(N'2025-09-01' AS Date), N'0', 2, NULL)
INSERT [dbo].[DeliveryListsContent] ([DeliveryContentID], [DeliveryListID], [PurchaseContentID], [DeliveryContentDate], [ContractNumber], [Quantity], [Price]) VALUES (84, 56, 41, CAST(N'2025-09-01' AS Date), N'0', 8, NULL)
INSERT [dbo].[DeliveryListsContent] ([DeliveryContentID], [DeliveryListID], [PurchaseContentID], [DeliveryContentDate], [ContractNumber], [Quantity], [Price]) VALUES (85, 56, 42, CAST(N'2025-09-01' AS Date), N'0', 2, NULL)
INSERT [dbo].[DeliveryListsContent] ([DeliveryContentID], [DeliveryListID], [PurchaseContentID], [DeliveryContentDate], [ContractNumber], [Quantity], [Price]) VALUES (91, 67, 46, CAST(N'2025-09-01' AS Date), N'0', 6, NULL)
INSERT [dbo].[DeliveryListsContent] ([DeliveryContentID], [DeliveryListID], [PurchaseContentID], [DeliveryContentDate], [ContractNumber], [Quantity], [Price]) VALUES (92, 68, 47, CAST(N'2025-09-01' AS Date), N'0', 5, NULL)
INSERT [dbo].[DeliveryListsContent] ([DeliveryContentID], [DeliveryListID], [PurchaseContentID], [DeliveryContentDate], [ContractNumber], [Quantity], [Price]) VALUES (93, 68, 48, CAST(N'2025-09-01' AS Date), N'0', 2, NULL)
INSERT [dbo].[DeliveryListsContent] ([DeliveryContentID], [DeliveryListID], [PurchaseContentID], [DeliveryContentDate], [ContractNumber], [Quantity], [Price]) VALUES (94, 68, 49, CAST(N'2025-09-01' AS Date), N'0', 10, NULL)
SET IDENTITY_INSERT [dbo].[DeliveryListsContent] OFF
GO
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0001', N'Фреза')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0002', N'Сверло')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0003', N'Резец')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0004', N'Пластина')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0005', N'Калибр')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0006', N'Абразивный круг')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0007', N'Микрометр')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0008', N'Штангенциркуль')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0009', N'Гаечный ключ')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0010', N'Отвёртка')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0011', N'Динамометрический ключ')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0012', N'Щётка')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0013', N'Шприц для смазки')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0014', N'Эндоскоп')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0015', N'Дефектоскоп')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0016', N'Тестер')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0017', N'Инструмент для маркировки')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0018', N'Инструмент для термической обработки')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0019', N'Наждачная бумага')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0020', N'Шлифовальная машинка')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0021', N'Набор для ремонта')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0022', N'Ключ разводной')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0023', N'Клещи')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0024', N'Кувалда')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0025', N'Молоток')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0026', N'Тиски')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0027', N'Напильник')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0028', N'Лобзик')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0029', N'Пассатижи')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0030', N'Шуруповёрт')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0031', N'Дрель')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0032', N'Ударная дрель')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0033', N'Перфоратор')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0034', N'Болгарка')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0035', N'Лазерный уровень')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0036', N'Рулетка')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0037', N'Маркер')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0038', N'Линейка')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0039', N'Токарный станок')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0040', N'Фрезерный станок')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0041', N'Сверлильный станок')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0042', N'Шлифовальный станок')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0043', N'Пресс')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0044', N'Гидравлический домкрат')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0045', N'Пневматический инструмент')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0046', N'Съёмник')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0047', N'Вороток')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0048', N'Направитель для сверления')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0049', N'Трещотка')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0050', N'Головка торцевая')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0051', N'Удлинитель для инструментов')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0052', N'Индикатор часового типа')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0053', N'Центровочные указатели')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0054', N'Развёртка')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0055', N'Зенковка')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0056', N'Метчик')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0057', N'Плашка')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0058', N'Кернер')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0059', N'Чертилка')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0060', N'Штатив')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0061', N'Магнит подъёмный')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0062', N'Клещи для снятия изоляции')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0063', N'Ножницы по металлу')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0064', N'Устройство для резки кабеля')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0065', N'Мультиметр')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0066', N'Прибор для проверки изоляции')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0067', N'Тепловизор')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0068', N'Ультразвуковой дефектоскоп')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0069', N'Спектрометр')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0070', N'Микроскоп')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0071', N'Энкодер')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0072', N'Датчик давления')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0073', N'Датчик температуры')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0074', N'Тестер аккумуляторов')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0075', N'Набор щупов')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0076', N'Устройство для проверки герметичности')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0077', N'Виброанализатор')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0078', N'Прибор для измерения уровня шума')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0079', N'Шкурка шлифовальная тканевая (н/п)')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0080', N'Пробка')
INSERT [dbo].[Groups] ([RangeStart], [Name]) VALUES (N'0081', N'Плоскогубцы')
GO
SET IDENTITY_INSERT [dbo].[Invoices] ON 

INSERT [dbo].[Invoices] ([InvoiceID], [InvoiceDate]) VALUES (19, CAST(N'2025-06-13' AS Date))
INSERT [dbo].[Invoices] ([InvoiceID], [InvoiceDate]) VALUES (20, CAST(N'2025-06-13' AS Date))
INSERT [dbo].[Invoices] ([InvoiceID], [InvoiceDate]) VALUES (21, CAST(N'2025-06-14' AS Date))
INSERT [dbo].[Invoices] ([InvoiceID], [InvoiceDate]) VALUES (22, CAST(N'2025-06-14' AS Date))
INSERT [dbo].[Invoices] ([InvoiceID], [InvoiceDate]) VALUES (29, CAST(N'2025-06-14' AS Date))
INSERT [dbo].[Invoices] ([InvoiceID], [InvoiceDate]) VALUES (30, CAST(N'2025-06-16' AS Date))
SET IDENTITY_INSERT [dbo].[Invoices] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoicesContent] ON 

INSERT [dbo].[InvoicesContent] ([InvoiceContentID], [InvoiceID], [DeliveryContentID], [Quantity]) VALUES (5, 19, 71, 5)
INSERT [dbo].[InvoicesContent] ([InvoiceContentID], [InvoiceID], [DeliveryContentID], [Quantity]) VALUES (6, 19, 72, 3)
INSERT [dbo].[InvoicesContent] ([InvoiceContentID], [InvoiceID], [DeliveryContentID], [Quantity]) VALUES (7, 20, 71, 4)
INSERT [dbo].[InvoicesContent] ([InvoiceContentID], [InvoiceID], [DeliveryContentID], [Quantity]) VALUES (8, 21, 82, 6)
INSERT [dbo].[InvoicesContent] ([InvoiceContentID], [InvoiceID], [DeliveryContentID], [Quantity]) VALUES (9, 21, 82, 5)
INSERT [dbo].[InvoicesContent] ([InvoiceContentID], [InvoiceID], [DeliveryContentID], [Quantity]) VALUES (10, 22, 84, 3)
INSERT [dbo].[InvoicesContent] ([InvoiceContentID], [InvoiceID], [DeliveryContentID], [Quantity]) VALUES (11, 22, 84, 5)
INSERT [dbo].[InvoicesContent] ([InvoiceContentID], [InvoiceID], [DeliveryContentID], [Quantity]) VALUES (12, 22, 85, 2)
INSERT [dbo].[InvoicesContent] ([InvoiceContentID], [InvoiceID], [DeliveryContentID], [Quantity]) VALUES (13, 29, 91, 6)
INSERT [dbo].[InvoicesContent] ([InvoiceContentID], [InvoiceID], [DeliveryContentID], [Quantity]) VALUES (14, 30, 92, 5)
INSERT [dbo].[InvoicesContent] ([InvoiceContentID], [InvoiceID], [DeliveryContentID], [Quantity]) VALUES (15, 30, 93, 2)
INSERT [dbo].[InvoicesContent] ([InvoiceContentID], [InvoiceID], [DeliveryContentID], [Quantity]) VALUES (16, 30, 94, 10)
SET IDENTITY_INSERT [dbo].[InvoicesContent] OFF
GO
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000100001', N'R216.34-16050-AK32H 1620', N'Шт', NULL, NULL, NULL, N'SANDVIK                                          ', 2, 0)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000100002', N'R216.34-16050-AK33H 1621', N'Шт', NULL, N'BK8', N'ГОСТ 25414-90', N'SANDVIK', 0, 67)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000100003', N'Червячная модульная m1.5', N'Шт', N'm1.5x30', N'Р6М5', N'ГОСТ 9324-80', N'ISCAR', 2, 91)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000100004', N'Торцевая 50мм с ТВП', N'Шт', N'Ø50x22', N'Т5К10', N'ГОСТ 26527-85', N'KORLOY', 0, 28)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000100005', N'4225', N'Шт', N'R45 56', NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000200001', N'2300-0195', N'Шт', N'8', N'Р6М5К5        ', N'ГОСТ 10902-77                          ', NULL, 2, 78)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000200002', N'2300-0196', N'Шт', N'10', N'Р6М5К5', N'ГОСТ 10902-77', N'ISCAR', 1, 22)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000200003', N'Коническое 1-10мм', N'Шт', N'1-10мм', N'HSS-Co', N'DIN 338', N'METABO', 2, 47)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000200004', N'Ступенчатое 4-12мм', N'Шт', N'4-12x35', N'HSS-E', N'ISO 3292', N'BOSCH', 0, 55)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000300001', N'CNMG 120408-PM', N'Шт', NULL, N'T15K6', N'ГОСТ 25393-82', N'KENNAMETAL', 2, 9)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000300002', N'Проходной 16x16', N'Шт', N'16x16x100', N'Т15К6', N'ГОСТ 18877-73', N'KENNAMETAL', 1, 36)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000300003', N'Отрезной 3мм', N'Шт', N'3x16x80', N'ВК8', N'ГОСТ 25414-90', N'SECO', 2, 84)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000400001', N'36110', N'Шт', NULL, N'BK8   ', N'ГОСТ 25414-90                          ', NULL, 0, 45)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000400002', N'36111', N'Шт', NULL, N'BK6', N'ГОСТ 25414-90', N'SECO', 0, 34)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000400003', N'CCGT09T302', N'Шт', N'CCGT09T302', N'ВК8', N'DIN 4984', N'ISCAR', 1, 75)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000500001', N'ГОСТ 20175-74', N'Шт', N'1.6-25H9', N'Сталь 9ХС', N'ГОСТ 20175-74', N'МЕХАНОБР', 1, 76)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000500002', N'Пробка 10Н7', N'Шт', N'Ø10Н7', N'Сталь ХВГ', N'ГОСТ 20175-74', N'МЕХАНОБР', 2, 53)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000500003', N'Калибр-скоба 25h9', N'Шт', N'25h9', N'Сталь У8', N'ГОСТ 2216-84', N'МИЗ', 0, 5)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000600001', N'25A 60-JV', N'Шт', NULL, N'Электрокорунд', N'ГОСТ 3647-80', N'NORTON', 2, 43)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000600002', N'125х6х22', N'Шт', N'125x6x22', N'25А', N'ГОСТ 3647-80', N'NORTON', 1, 31)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000600003', N'Алмазный 150х3х32', N'Шт', N'150x3x32', N'АС6 100/80', N'ГОСТ 9206-80', N'АЛМИК', 2, 82)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000700001', N'МК 0-25', N'Шт', N'0.01 мм', NULL, N'ГОСТ 6507-90', N'MITUTOYO', 0, 59)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000700002', N'МК25 0-25мм', N'Шт', N'0-25', N'Сталь Х12М', N'ГОСТ 6507-90', N'MITUTOYO', 0, 65)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000700003', N'Электронный 50-75мм', N'Шт', N'50-75', N'Нерж. сталь', N'ГОСТ 6507-90', N'MAHR', 1, 41)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000800001', N'ШЦ-I-125', N'Шт', N'0-125 мм', NULL, N'ГОСТ 166-89', N'ЧИЗ', 1, 11)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000800002', N'ШЦЦ-I-150', N'Шт', N'0-150', N'Карбид', N'ГОСТ 166-89', N'MITUTOYO', 2, 75)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000800003', N'Глубиномер 300мм', N'Шт', N'0-300', N'Инвар', N'ГОСТ 162-90', N'TESA', 0, 16)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000900001', N'SW13', N'Шт', N'13 мм', NULL, N'DIN 3110', N'STANLEY', 2, 88)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000900002', N'Рожковый 17мм', N'Шт', N'17', N'Хромованадий', N'ГОСТ 2838-80', N'JONNESWAY', 1, 8)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'000900003', N'Накидной 19мм', N'Шт', N'19', N'Хромомолибден', N'DIN 3113', N'STAHWILLE', 2, 57)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001000001', N'PH2x100', N'Шт', NULL, N'CrV', N'ISO 8763-1', N'WERA', 0, 27)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001000002', NULL, N'Шт', NULL, NULL, NULL, NULL, 0, 10)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001000003', N'Шлицевая 6мм', N'Шт', N'6x150', N'CrV', N'DIN 5260', N'WERA', 1, 28)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001000004', N'ОТ01', N'Шт', N'0-5мм', N'Инвар', N'ГОСТ 11401-80', N'Отвёрточник', 0, 40)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001100001', N'TD-10', N'Н·м', N'10-100', NULL, N'DIN 3122', N'NORBAR', 1, 63)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001100002', N'Динам. 3/8" 10-50Нм', N'Н·м', N'18537', N'Хромованадий', N'DIN 3122', N'NORBAR', 2, 8)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001100003', N'Моментный 1/2" 100Нм', N'Н·м', N'100-200', N'Сплав 42CrMo4', N'ISO 6789', N'PROXXON', 0, 6)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001200001', N'Щ-К-150', N'Шт', NULL, N'Сталь 65Г', N'ТУ 34-27-107', N'ЗУБР', 2, 95)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001200002', N'Дисковая 150мм', N'Шт', N'Ø150', N'Сталь 65Г', N'ТУ 34-27-107', N'METABO', 1, 45)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001200003', N'Чашечная 75мм', N'Шт', N'Ø75', N'Нерж. проволока', N'DIN 8553', N'FEIN', 2, 69)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001300001', N'Литол-24', N'Шт', N'400 мл', NULL, N'ГОСТ 21150-87', N'ЛУКОЙЛ', 0, 51)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001300002', N'Смазочный 400мл', N'Шт', N'400мл', NULL, N'ГОСТ 21150-87', N'LIQUI MOLY', 0, 22)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001300003', N'ПС001', N'Шт', N'1/8" NPT', NULL, N'SAE J1237', N'LINCOLN', 1, 74)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001400001', N'Е-8', N'Шт', N'Ø8x1м', NULL, N'ТУ 4271-015', N'SONY', 1, 39)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001400002', N'Гибкий 8мм', N'Шт', N'Ø8x1м', NULL, N'ТУ 4271-015', N'OLYMPUS', 2, 54)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001400003', N'Жёсткий 6мм', N'Шт', N'Ø6x500', NULL, N'EN 13018', N'GE', 0, 56)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001500001', N'ДИН-3', N'Шт', NULL, N'Ультразвук', N'ГОСТ 26266-90', N'GE', 2, 72)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001500002', N'Ультр. ДУ-10', N'Шт', N'2-20мм', NULL, N'ГОСТ 26266-90', N'SONOTRON', 1, 34)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001500003', N'Покрытий 0-5мм', N'Шт', N'0-5мм', NULL, N'ISO 2178', N'ELCOMETER', 2, 89)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001600001', N'МТ-87', N'Шт', N'0-1000В', NULL, N'ТУ 25-1897', N'UNI-T', 0, 18)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001600002', N'ТИ1000В', N'Шт', N'0-1000МОм', NULL, N'ТУ 25-1897', N'MEGGER', 0, 29)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001600003', N'Мультиметр цифровой', N'Шт', N'AC/DC 600В', NULL, N'IEC 61010', N'FLUKE', 1, 72)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001600004', N'Т1000', N'Шт', NULL, NULL, N'ГОСТ 1465-80', N'SPECTRO', 0, 0)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001700001', N'МК-01', N'Шт', NULL, N'Алмаз', N'ТУ 2221-035', N'GRAVER', 1, 84)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001700002', N'Маркер керновый', N'Шт', N'Ø3мм', NULL, N'ГОСТ 7213-89', N'RENNSTEIG', 2, 48)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001700003', N'Чертилка алмазная', N'Шт', N'0.3кар', NULL, N'ТУ 2221-035', N'DIATOOL', 0, 53)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001800001', N'ТП-40', N'Шт', N'400-1200°C', NULL, N'ГОСТ 3042-84', N'THERMOLAB', 2, 6)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001800002', N'Горелка газовая 2000°C', N'Шт', N'MAPP-газ', NULL, N'ГОСТ 3042-84', N'ROTHENBERGER', 1, 32)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001800003', N'Пирометр 800°C', N'Шт', N'-50..+800', NULL, N'IEC 60825-1', N'TESTО', 2, 94)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001900001', N'Р80', N'м²', NULL, N'Карбид кремния', N'ISO 6344', N'3M', 0, 48)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001900002', N'Шкурка водостойкая Р80', N'м²', N'225х280', N'Карбид кремния', N'ISO 6344', N'3M', 0, 64)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001900003', N'Лента абразивная 100х610', N'м', N'100x610', N'Оксид алюминия', N'ГОСТ 13344-79', N'KLINGSPOR', 1, 43)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'001900004', NULL, N'м²', NULL, NULL, NULL, NULL, 0, 50)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002000001', N'УШМ-125', N'Шт', N'125 мм', NULL, N'ГОСТ Р МЭК 60745-2-23', N'MAKITA', 1, 29)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002000002', N'Шлифмашинка ленточная', N'Шт', N'75x533мм', N'Алюминий', N'ГОСТ Р МЭК 60745-2-23', N'MAKITA', 2, 71)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002000003', N'Эксцентриковая шл.машина', N'Шт', N'125мм', N'Пластик', N'EN 60745', N'FESTOOL', 0, 25)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002100001', N'РК-12', N'Компл', N'12 предм.', NULL, N'ТУ 4276-005', N'JONNESWAY', 2, 77)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002100002', N'Набор инструмента 64пр.', N'Компл', N'64предм.', N'Хромованадий', N'ТУ 4276-005', N'STANLEY', 1, 77)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002100003', N'Набор головок 1/2" 32шт', N'Компл', N'6-32мм', N'Cr-Mo', N'ISO 6789', N'KING TONY', 2, 51)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002100004', NULL, N'Компл', NULL, NULL, NULL, NULL, 0, 20)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002200001', N'KRA-24', N'Шт', N'24 мм', NULL, N'DIN 3113', N'KING TONY', 0, 66)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002200002', N'Ключ разводной 24"', N'Шт', N'24"', N'Хромованадий', N'DIN 3113', N'BAHCO', 0, 47)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002200003', N'Ключ трубный 36"', N'Шт', N'36"', N'Кованая сталь', N'ГОСТ 18981-73', N'RIDGID', 1, 26)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002300001', N'КГ-180', N'Шт', N'180 мм', NULL, N'ГОСТ 5547-93', N'GROSS', 1, 53)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002300002', N'Клещи комбинированные 200мм', N'Шт', N'200мм', N'Хромованадий', N'DIN ISO 5746', N'KNIPEX', 2, 76)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002300003', N'Клещи торцевые 180мм', N'Шт', N'180мм', N'Хромомолибден', N'ISO 5743', N'NWS', 0, 14)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002400001', N'КД-5', N'Шт', N'5 кг', NULL, N'ТУ 36-17-22-93', N'MATRIX', 2, 81)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002400002', N'Кувалда 8кг', N'Шт', N'8кг', N'Углерод.сталь', N'ГОСТ 11401-80', N'FIT', 1, 81)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002400003', N'Молоток слесарный 0.5кг', N'Шт', N'0.5кг', N'Сталь 50', N'ГОСТ 2310-77', N'STANLEY', 2, 61)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002500001', N'МС-400', N'Шт', N'400 г', NULL, N'ГОСТ 2310-77', N'FIT', 0, 23)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002500002', N'Тиски слесарные 150мм', N'Шт', N'150мм', N'Чугун', N'ГОСТ 14904-80', N'WILTON', 0, 42)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002500003', N'Тиски станочные 200мм', N'Шт', N'200мм', N'Сталь 40Х', N'ГОСТ 16518-87', N'YOST', 1, 24)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002600001', N'ТС-150', N'Шт', N'150 мм', NULL, N'ГОСТ 14904-80', N'WILTON', 1, 7)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002600002', N'Напильник плоский 250мм', N'Шт', N'250мм', N'Сталь У13', N'ГОСТ 1465-80', N'GROSS', 2, 96)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002600003', N'Надфиль алмазный 3мм', N'Шт', N'Ø3x100', N'Алмазное напыление', N'ТУ 2221-035', N'DIAMOND', 0, 37)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002700001', N'НП-250', N'Шт', N'250 мм', NULL, N'ГОСТ 1465-80', N'BAHCO', 2, 49)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002700002', N'Лобзик электрический 600Вт', N'Шт', N'T-образ.хвост.', N'Алюминий', N'ГОСТ Р МЭК 60745-2-11', N'BOSCH', 1, 69)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002700003', N'Полотно по металлу 24T', N'Шт', N'130мм', N'Bi-Metal', N'ISO 23470', N'MAKITA', 2, 62)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002800001', N'ЛБ-100', N'Шт', N'100 Вт', NULL, N'ТУ 27-45-051', N'BOSCH', 0, 57)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002800002', N'Пассатижи 200мм', N'Шт', N'200мм', N'Хромованадий', N'DIN ISO 5746', N'KNIPEX', 0, 11)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002800003', N'Пассатижи узкие 160мм', N'Шт', N'160мм', N'Хромомолибден', N'ISO 5743', N'NWS', 1, 78)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002900001', N'ПК-20', N'Шт', N'200 мм', NULL, N'DIN 525', N'KNIPEX', 1, 35)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002900002', N'Шуруповёрт 18В Li-Ion', N'Шт', N'0-3500об/мин', N'Li-Ion', N'ТУ 48-3456-005', N'MAKITA', 2, 65)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002900003', N'Аккумулятор 5.0Ач', N'Шт', N'18В 5.0Ач', N'Li-Ion', N'IEC 61960', N'DEWALT', 2, 65)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'002900004', NULL, N'Шт', NULL, NULL, NULL, NULL, 2, 0)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'003000001', N'ШД-18В', N'Шт', NULL, N'Li-Ion', N'ТУ 48-3456-005', N'DEWALT', 2, 92)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'003000002', N'Дрель ударная 650Вт', N'Шт', N'Ø13мм', N'Редуктор.сталь', N'ГОСТ Р МЭК 60745-2-1', N'METABO', 0, 65)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'003000003', N'Сверло SDS-plus 10мм', N'Шт', N'Ø10x260', N'Твердосплав.наконечник', N'ISO 5468', N'BOSCH', 2, 65)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'003100001', N'ДУ-10', N'Шт', N'10 мм', NULL, N'ГОСТ 8874-80', N'HILTI', 0, 31)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'003200001', N'SDS-MAX', N'Шт', N'Ø30 мм', NULL, N'ISO 1180', N'MAKITA', 1, 68)
GO
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'003300001', N'ПР-24', N'Шт', N'24 Дж', NULL, N'ГОСТ Р 52108-2003', N'HILTI', 2, 56)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'003300002', N'ПРФРТР№1', N'Шт', NULL, NULL, NULL, NULL, 2, 0)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'003400001', N'УШМ-230', N'Шт', N'230 мм', NULL, N'ГОСТ Р МЭК 60745-2-23', N'BOSCH', 0, 41)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'003500001', N'LL-3G', N'Шт', N'±0.3 мм/м', NULL, N'ISO 9001', N'LEICA', 1, 25)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'003600001', N'РМ-5', N'Шт', N'5 м', NULL, N'ГОСТ 7502-89', N'STAYER', 2, 83)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'003700001', N'МП-2', N'Шт', NULL, N'Спирт', N'ТУ 6-09-3811', N'EDDING', 0, 62)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'003800001', N'ЛС-300', N'Шт', N'300 мм', NULL, N'ГОСТ 427-75', N'MITUTOYO', 1, 47)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'003900001', N'16К20', N'Шт', N'Ø200x500', NULL, N'ГОСТ 18097-93', N'КЗТС', 2, 74)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'004000001', N'НГФ-110', N'Шт', N'110х600', NULL, N'ГОСТ 26527-85', N'JET', 0, 19)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'004100001', N'2С132', N'Шт', N'Ø16 мм', NULL, N'ГОСТ 23738-85', N'СЗПО', 1, 79)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'004200001', N'3Л722', N'Шт', N'200х600', NULL, N'ТУ 26-01-462-87', N'КРАСТЯЖМАШ', 2, 58)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'004300001', N'П-6328', N'Шт', N'10т', NULL, N'ГОСТ 7343-85', N'АРСЕНАЛ', 0, 52)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'004300002', NULL, N'Шт', NULL, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'004400001', N'ГД-5т', N'Шт', N'5 тонн', NULL, N'ГОСТ 11096-90', N'JET', 1, 33)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'004500001', N'ПВ-150', N'Шт', N'6 бар', NULL, N'ISO 2787', N'FUBAG', 2, 86)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'004600001', N'СЦ-40', N'Шт', N'Ø40-120 мм', NULL, N'ТУ 3132-006-00221724', N'JTC', 0, 69)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'004700001', N'ВТ-10', N'Шт', N'10 мм', NULL, N'ГОСТ 28442-90', N'KRAFTTOOL', 1, 42)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'004800001', N'НС-8', N'Шт', N'Ø8-32 мм', NULL, N'DIN 3402', N'BOSCH', 2, 64)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'004900001', N'ТР-24', N'Шт', N'24 зуб.', NULL, N'ISO 6789', N'FORCE', 0, 26)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'005000001', N'ГТ-14', N'Шт', N'14 мм', NULL, N'DIN 3129', N'STANLEY', 1, 71)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'005100001', N'УД-300', N'Шт', N'300 мм', NULL, N'ТУ 36-17-051', N'JONNESWAY', 2, 5)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'005200001', N'ИЧ-10', N'Шт', N'0.01 мм', NULL, N'ГОСТ 577-68', N'MITUTOYO', 0, 54)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'005300001', N'ЦУ-3', N'Шт', N'Ø3 мм', NULL, N'ГОСТ 25706-83', N'NAREX', 1, 38)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'005400001', N'РЗ-15', N'Шт', N'Ø15H7', NULL, N'ГОСТ 11134-81', N'DORMER', 2, 87)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'005500001', N'ЗК-90', N'Шт', N'90°', NULL, N'ГОСТ 14953-80', N'SANDVIK', 0, 21)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'005600001', N'МАШИННО-РУЧНОЙ 2620-1063-1061 3Х0,5                                                             ', N'Компл', N'3-0,5                                            ', N'Р6М5', NULL, NULL, 0, 15)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'005600002', N'МАШИННО-РУЧНОЙ 2620-1063-1062 4Х0,7', N'Компл', N'4-0.7', N'Р6М5', N'ГОСТ 19265-73', N'ISCAR', 1, 65)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'005700001', N'ПР-3', N'Шт', N'М3', NULL, N'ГОСТ 3266-81', N'GEWISS', 2, 93)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'005700002', NULL, N'Шт', NULL, NULL, NULL, NULL, 0, 40)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'005700003', NULL, N'Компл', NULL, NULL, NULL, NULL, 0, 10)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'005800001', N'ПЛ-1/2', N'Шт', N'1/2"', NULL, N'ГОСТ 9741-80', N'REMER', 0, 44)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'005900001', N'ЧШ-200', N'Шт', N'200 мм', NULL, N'ГОСТ 7213-89', N'ЗУБР', 1, 13)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'006000001', N'ШТ-М', N'Шт', NULL, N'Неодим', N'ТУ 36-17-051', N'MAGNETO', 2, 79)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'006100001', N'КСИ-150', N'Шт', N'150 мм', NULL, N'ТУ 27-45-051', N'KNIpex', 0, 61)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'006200001', N'НМ-2,5', N'Шт', N'2.5 мм²', NULL, N'ГОСТ 15845-80', N'JOKARI', 1, 46)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'006300001', N'УРК-300', N'Шт', N'300 мм', NULL, N'ТУ 36-17-051', N'JET', 2, 68)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'006400001', N'МТ-87А', N'Шт', N'0-1000МОм', NULL, N'ТУ 25-1897', N'UNI-T', 0, 17)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'006500001', N'ТИ-400', N'Шт', N'-40...+400°C', NULL, N'ГОСТ 3042-84', N'FLUKE', 1, 82)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'006600001', N'МИД-10', N'Шт', N'10 кВ', NULL, N'ГОСТ 7237-82', N'MEGGER', 2, 59)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'006700001', N'ЭК-4', N'Шт', N'4 мм', NULL, N'ТУ 4271-015', N'SONY', 0, 49)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'006700002', NULL, N'Шт', NULL, NULL, NULL, NULL, 0, 5)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'006800001', N'УЗД-20', N'Шт', N'2-20 мм', NULL, N'ГОСТ 26266-90', N'GE', 1, 37)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'006900001', N'СП-М1', N'Шт', N'0.1-1.2%Ni', NULL, N'ТУ 1791-002', N'SPECTRO', 2, 85)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'007000001', N'МБС-10', N'Шт', N'10x', NULL, N'ГОСТ 4.188-85', N'BIOMED', 0, 63)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'007100001', N'ЭН-5', N'Шт', N'5000 имп/об', NULL, N'ТУ 25-1897-003', N'SIEMENS', 1, 44)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'007200001', N'ДД-10', N'Шт', N'0-10 бар', NULL, N'ГОСТ 2405-88', N'WIKA', 2, 17)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'007300001', N'ДТ-500', N'Шт', N'-50...+500°C', NULL, N'ГОСТ 6651-2009', N'OMEGA', 0, 12)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'007400001', N'ТА-12В', N'Шт', N'12В', NULL, N'ТУ 48-3456-005', N'CTEK', 1, 73)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'007500001', N'ЩП-0,05', N'Компл', N'0.05-1 мм', NULL, N'ГОСТ 882-75', N'MITUTOYO', 2, 52)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'007600001', N'ГТ-200', N'Шт', N'200 мБар', NULL, N'ГОСТ 356-80', N'TESTO', 0, 58)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'007900001', N'20Н  ', N'м', N'20', NULL, N'ГОСТ', NULL, 1, 89)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'008000001', N'П81', N'Шт', N'80x10', NULL, NULL, NULL, 0, 0)
INSERT [dbo].[Nomenclature] ([NomenclatureNumber], [Designation], [Unit], [Dimensions], [CuttingMaterial], [RegulatoryDoc], [Producer], [UsageFlag], [MinStock]) VALUES (N'008100002', N'ПП', N'Шт', NULL, NULL, NULL, NULL, 2, 0)
GO
SET IDENTITY_INSERT [dbo].[NomenclatureLogs] ON 

INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (8, N'008000001', N'Типоразмеры', N'Ф13,835 +0,375', N'Ф13,835 +0,37', CAST(N'2025-06-03T14:37:17.133' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (9, N'008000002', N'Обозначение', NULL, N'1.8133-0689', CAST(N'2025-06-03T14:41:29.603' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (10, N'008000002', N'Единицы измерения', NULL, N'Шт', CAST(N'2025-06-03T14:41:29.603' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (11, N'008000002', N'Типоразмеры', NULL, N'Ф13,835 +0,37', CAST(N'2025-06-03T14:41:29.603' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (12, N'008000002', N'Нормативная документация', NULL, N'ОСТ 1.52175-76                         ', CAST(N'2025-06-03T14:41:29.603' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (13, N'008000002', N'Признак использования', NULL, N'2', CAST(N'2025-06-03T14:41:29.603' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (14, N'008000002', N'Неснижаемый остаток', NULL, N'55', CAST(N'2025-06-03T14:41:29.603' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (15, N'008000002', N'Обозначение', N'1.8133-0689', NULL, CAST(N'2025-06-03T14:41:39.403' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (16, N'008000002', N'Единицы измерения', N'Шт', NULL, CAST(N'2025-06-03T14:41:39.403' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (17, N'008000002', N'Типоразмеры', N'Ф13,835 +0,37', NULL, CAST(N'2025-06-03T14:41:39.407' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (18, N'008000002', N'Нормативная документация', N'ОСТ 1.52175-76                         ', NULL, CAST(N'2025-06-03T14:41:39.407' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (19, N'008000002', N'Признак использования', N'2', NULL, CAST(N'2025-06-03T14:41:39.407' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (20, N'008000002', N'Неснижаемый остаток', N'55', NULL, CAST(N'2025-06-03T14:41:39.407' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (21, N'000100005', N'Признак использования', N'1', N'1', CAST(N'2025-06-03T23:06:43.903' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (22, N'000100005', N'Неснижаемый остаток', N'30', N'30', CAST(N'2025-06-03T23:06:43.903' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (23, N'000100005', N'Признак использования', N'1', N'1', CAST(N'2025-06-03T23:07:33.830' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (24, N'000100005', N'Неснижаемый остаток', N'30', N'30', CAST(N'2025-06-03T23:07:33.830' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (25, N'000100005', N'Признак использования', N'1', N'1', CAST(N'2025-06-03T23:11:09.380' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (26, N'000100005', N'Неснижаемый остаток', N'22', N'22', CAST(N'2025-06-03T23:11:09.380' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (27, N'000100005', N'Признак использования', N'1', N'1', CAST(N'2025-06-03T23:13:28.683' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (28, N'000100005', N'Неснижаемый остаток', N'22', N'22', CAST(N'2025-06-03T23:13:28.683' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (29, N'000100005', N'Обозначение', N'Червячная модульная m1.5', N'Червячная модульная m1.5', CAST(N'2025-06-03T23:36:42.953' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (30, N'000100005', N'Единицы измерения', N'Шт', N'Шт', CAST(N'2025-06-03T23:36:42.957' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (31, N'000100005', N'Типоразмеры', N'm1.5x30', N'm1.5x30', CAST(N'2025-06-03T23:36:42.957' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (32, N'000100005', N'Материал режущей части', N'Р6М5', N'Р6М5', CAST(N'2025-06-03T23:36:42.957' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (33, N'000100005', N'Нормативная документация', N'ГОСТ 9324-80', N'ГОСТ 9324-80', CAST(N'2025-06-03T23:36:42.957' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (34, N'000100005', N'Производитель', N'ISCAR', N'ISCAR', CAST(N'2025-06-03T23:36:42.957' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (35, N'000100005', N'Признак использования', N'2', N'2', CAST(N'2025-06-03T23:36:42.957' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (36, N'000100005', N'Неснижаемый остаток', N'91', N'100', CAST(N'2025-06-03T23:36:42.957' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (37, N'001900004', N'Единицы измерения', NULL, N'м²', CAST(N'2025-06-04T07:31:07.763' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (38, N'001900004', N'Признак использования', NULL, N'0', CAST(N'2025-06-04T07:31:29.660' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (39, N'001900004', N'Неснижаемый остаток', NULL, N'50', CAST(N'2025-06-04T07:31:39.780' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (40, N'000100001', N'Неснижаемый остаток', N'32', N'33', CAST(N'2025-06-04T07:49:18.040' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (41, N'000100005', N'Неснижаемый остаток', N'33', N'34', CAST(N'2025-06-04T07:51:55.147' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (42, N'000100001', N'Неснижаемый остаток', N'33', N'43', CAST(N'2025-06-04T07:58:07.110' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (43, N'000100001', N'Признак использования', N'1', N'2', CAST(N'2025-06-04T08:04:09.303' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (44, N'000100001', N'Неснижаемый остаток', N'43', N'0', CAST(N'2025-06-04T08:04:09.303' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (45, N'008100001', N'Обозначение', NULL, N'ПГ1', CAST(N'2025-06-04T13:55:21.160' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (46, N'008100001', N'Единицы измерения', NULL, N'Шт', CAST(N'2025-06-04T13:55:21.160' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (47, N'008100001', N'Нормативная документация', NULL, N'ГОСТ 1465-80', CAST(N'2025-06-04T13:55:21.160' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (48, N'008100001', N'Признак использования', NULL, N'0', CAST(N'2025-06-04T13:55:21.160' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (49, N'008100001', N'Неснижаемый остаток', NULL, N'20', CAST(N'2025-06-04T13:55:21.163' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (50, N'008100002', N'Обозначение', NULL, N'ПЛГ1', CAST(N'2025-06-04T14:07:00.333' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (51, N'008100002', N'Единицы измерения', NULL, N'Шт', CAST(N'2025-06-04T14:07:00.333' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (52, N'008100002', N'Материал режущей части', NULL, N'Инвар', CAST(N'2025-06-04T14:07:00.333' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (53, N'008100002', N'Нормативная документация', NULL, N'ГОСТ 162-90', CAST(N'2025-06-04T14:07:00.333' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (54, N'008100002', N'Производитель', NULL, N'ПлоскогубцыКорпорейшен', CAST(N'2025-06-04T14:07:00.333' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (55, N'008100002', N'Признак использования', NULL, N'0', CAST(N'2025-06-04T14:07:00.333' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (56, N'008100002', N'Неснижаемый остаток', NULL, N'40', CAST(N'2025-06-04T14:07:00.333' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (57, N'003300002', N'Обозначение', NULL, N'ПРФРТР№1', CAST(N'2025-06-07T12:15:50.613' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (58, N'003300002', N'Единицы измерения', NULL, N'Шт', CAST(N'2025-06-07T12:15:50.613' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (59, N'003300002', N'Признак использования', NULL, N'2', CAST(N'2025-06-07T12:15:50.613' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (60, N'003300002', N'Неснижаемый остаток', NULL, N'0', CAST(N'2025-06-07T12:15:50.613' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (61, N'004300002', N'Единицы измерения', NULL, N'Шт', CAST(N'2025-06-07T12:17:45.097' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (62, N'004300002', N'Признак использования', NULL, N'1', CAST(N'2025-06-07T12:17:45.097' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (63, N'004300002', N'Неснижаемый остаток', NULL, N'0', CAST(N'2025-06-07T12:17:45.097' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (64, N'008100002', N'Типоразмеры', NULL, N'2-20 мм', CAST(N'2025-06-07T21:45:00.127' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (65, N'008100002', N'Обозначение', N'ПЛГ1', NULL, CAST(N'2025-06-08T14:30:53.660' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (66, N'008100002', N'Единицы измерения', N'Шт', NULL, CAST(N'2025-06-08T14:30:53.663' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (67, N'008100002', N'Типоразмеры', N'2-20 мм', NULL, CAST(N'2025-06-08T14:30:53.663' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (68, N'008100002', N'Материал режущей части', N'Инвар', NULL, CAST(N'2025-06-08T14:30:53.663' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (69, N'008100002', N'Нормативная документация', N'ГОСТ 162-90', NULL, CAST(N'2025-06-08T14:30:53.663' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (70, N'008100002', N'Производитель', N'ПлоскогубцыКорпорейшен', NULL, CAST(N'2025-06-08T14:30:53.663' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (71, N'008100002', N'Признак использования', N'0', NULL, CAST(N'2025-06-08T14:30:53.663' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (72, N'008100002', N'Неснижаемый остаток', N'40', NULL, CAST(N'2025-06-08T14:30:53.663' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (73, N'008000001', N'Обозначение', N'1.8133-0689', NULL, CAST(N'2025-06-08T14:31:36.060' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (74, N'008000001', N'Единицы измерения', N'Шт', NULL, CAST(N'2025-06-08T14:31:36.060' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (75, N'008000001', N'Типоразмеры', N'Ф13,835 +0,37', NULL, CAST(N'2025-06-08T14:31:36.060' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (76, N'008000001', N'Нормативная документация', N'ОСТ 1.52175-76                         ', NULL, CAST(N'2025-06-08T14:31:36.060' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (77, N'008000001', N'Признак использования', N'2', NULL, CAST(N'2025-06-08T14:31:36.060' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (78, N'008000001', N'Неснижаемый остаток', N'55', NULL, CAST(N'2025-06-08T14:31:36.060' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (79, N'008100002', N'Обозначение', NULL, N'ПП', CAST(N'2025-06-08T14:40:35.037' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (80, N'008100002', N'Единицы измерения', NULL, N'Шт', CAST(N'2025-06-08T14:40:35.037' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (81, N'008100002', N'Признак использования', NULL, N'2', CAST(N'2025-06-08T14:40:35.037' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (82, N'008100002', N'Неснижаемый остаток', NULL, N'0', CAST(N'2025-06-08T14:40:35.037' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (83, N'008100002', N'Обозначение', N'ПП', NULL, CAST(N'2025-06-08T14:40:42.193' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (84, N'008100002', N'Единицы измерения', N'Шт', NULL, CAST(N'2025-06-08T14:40:42.193' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (85, N'008100002', N'Признак использования', N'2', NULL, CAST(N'2025-06-08T14:40:42.197' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (86, N'008100002', N'Неснижаемый остаток', N'0', NULL, CAST(N'2025-06-08T14:40:42.197' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (87, N'008100002', N'Обозначение', NULL, N'ПП', CAST(N'2025-06-08T14:41:06.660' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (88, N'008100002', N'Единицы измерения', NULL, N'Шт', CAST(N'2025-06-08T14:41:06.663' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (89, N'008100002', N'Признак использования', NULL, N'2', CAST(N'2025-06-08T14:41:06.663' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (90, N'008100002', N'Неснижаемый остаток', NULL, N'0', CAST(N'2025-06-08T14:41:06.663' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (91, N'008100001', N'Обозначение', N'ПГ1', NULL, CAST(N'2025-06-08T14:41:13.927' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (92, N'008100001', N'Единицы измерения', N'Шт', NULL, CAST(N'2025-06-08T14:41:13.927' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (93, N'008100001', N'Нормативная документация', N'ГОСТ 1465-80', NULL, CAST(N'2025-06-08T14:41:13.927' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (94, N'008100001', N'Признак использования', N'0', NULL, CAST(N'2025-06-08T14:41:13.930' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (95, N'008100001', N'Неснижаемый остаток', N'20', NULL, CAST(N'2025-06-08T14:41:13.930' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (96, N'001000004', N'Обозначение', NULL, N'ОТ01', CAST(N'2025-06-08T19:14:26.130' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (97, N'001000004', N'Единицы измерения', NULL, N'Шт', CAST(N'2025-06-08T19:14:26.130' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (98, N'001000004', N'Типоразмеры', NULL, N'0-5мм', CAST(N'2025-06-08T19:14:26.130' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (99, N'001000004', N'Материал режущей части', NULL, N'Инвар', CAST(N'2025-06-08T19:14:26.130' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (100, N'001000004', N'Нормативная документация', NULL, N'ГОСТ 11401-80', CAST(N'2025-06-08T19:14:26.130' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (101, N'001000004', N'Производитель', NULL, N'Отвёрточник', CAST(N'2025-06-08T19:14:26.130' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (102, N'001000004', N'Признак использования', NULL, N'0', CAST(N'2025-06-08T19:14:26.130' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (103, N'001000004', N'Неснижаемый остаток', NULL, N'40', CAST(N'2025-06-08T19:14:26.130' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (118, N'001600004', N'Обозначение', NULL, N'Т1000', CAST(N'2025-06-14T13:24:37.807' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (119, N'001600004', N'Единицы измерения', NULL, N'Шт', CAST(N'2025-06-14T13:24:41.000' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (120, N'001600004', N'Нормативная документация', NULL, N'ГОСТ 1465-80', CAST(N'2025-06-14T13:24:44.240' AS DateTime), N'dmitr')
GO
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (121, N'001600004', N'Производитель', NULL, N'SPECTRO', CAST(N'2025-06-14T13:24:46.630' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (122, N'001600004', N'Признак использования', NULL, N'0', CAST(N'2025-06-14T13:24:49.433' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (123, N'001600004', N'Неснижаемый остаток', NULL, N'0', CAST(N'2025-06-14T13:24:53.270' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (124, N'008000001', N'Обозначение', NULL, N'П81', CAST(N'2025-06-15T20:51:32.470' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (125, N'008000001', N'Единицы измерения', NULL, N'Шт', CAST(N'2025-06-15T20:51:32.470' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (126, N'008000001', N'Типоразмеры', NULL, N'80x10', CAST(N'2025-06-15T20:51:32.470' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (127, N'008000001', N'Признак использования', NULL, N'0', CAST(N'2025-06-15T20:51:32.470' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (128, N'008000001', N'Неснижаемый остаток', NULL, N'0', CAST(N'2025-06-15T20:51:32.473' AS DateTime), N'dmitr')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (129, N'000100005', N'Обозначение', NULL, N'4225', CAST(N'2025-06-16T11:54:29.510' AS DateTime), N'MIXMIX')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (130, N'000100005', N'Единицы измерения', NULL, N'Шт', CAST(N'2025-06-16T11:54:29.510' AS DateTime), N'MIXMIX')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (131, N'000100005', N'Типоразмеры', NULL, N'R45 56', CAST(N'2025-06-16T11:54:29.510' AS DateTime), N'MIXMIX')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (132, N'000100005', N'Признак использования', NULL, N'0', CAST(N'2025-06-16T11:54:29.510' AS DateTime), N'MIXMIX')
INSERT [dbo].[NomenclatureLogs] ([LogID], [NomenclatureNumber], [FieldName], [OldValue], [NewValue], [ChangedDate], [Executor]) VALUES (133, N'000100005', N'Неснижаемый остаток', NULL, N'0', CAST(N'2025-06-16T11:54:29.510' AS DateTime), N'MIXMIX')
SET IDENTITY_INSERT [dbo].[NomenclatureLogs] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseRequests] ON 

INSERT [dbo].[PurchaseRequests] ([PurchaseRequestID], [PurchaseRequestDate], [Status]) VALUES (1, CAST(N'0001-01-01' AS Date), N'Исполнена полностью')
INSERT [dbo].[PurchaseRequests] ([PurchaseRequestID], [PurchaseRequestDate], [Status]) VALUES (30, CAST(N'2025-06-13' AS Date), N'Не обработана')
INSERT [dbo].[PurchaseRequests] ([PurchaseRequestID], [PurchaseRequestDate], [Status]) VALUES (37, CAST(N'2025-06-14' AS Date), N'В работе')
INSERT [dbo].[PurchaseRequests] ([PurchaseRequestID], [PurchaseRequestDate], [Status]) VALUES (38, CAST(N'2025-06-14' AS Date), N'В работе')
INSERT [dbo].[PurchaseRequests] ([PurchaseRequestID], [PurchaseRequestDate], [Status]) VALUES (39, CAST(N'2025-06-14' AS Date), N'В работе')
INSERT [dbo].[PurchaseRequests] ([PurchaseRequestID], [PurchaseRequestDate], [Status]) VALUES (41, CAST(N'2025-06-14' AS Date), N'Исполнена полностью')
INSERT [dbo].[PurchaseRequests] ([PurchaseRequestID], [PurchaseRequestDate], [Status]) VALUES (46, CAST(N'2025-06-14' AS Date), N'Не обработана')
INSERT [dbo].[PurchaseRequests] ([PurchaseRequestID], [PurchaseRequestDate], [Status]) VALUES (48, CAST(N'2025-06-14' AS Date), N'Исполнена полностью')
INSERT [dbo].[PurchaseRequests] ([PurchaseRequestID], [PurchaseRequestDate], [Status]) VALUES (49, CAST(N'2025-06-16' AS Date), N'Исполнена полностью')
SET IDENTITY_INSERT [dbo].[PurchaseRequests] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseRequestsContent] ON 

INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (28, 1, 27, 0, 0)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (29, 30, 28, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (30, 30, 29, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (31, 30, 30, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (32, 1, 31, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (33, 1, 32, 0, 0)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (34, 1, 33, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (35, 37, 36, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (36, 37, 37, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (37, 37, 38, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (38, 37, 39, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (39, 38, 40, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (40, 39, 41, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (41, 41, 42, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (42, 41, 43, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (43, 1, 47, 0, 0)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (44, 46, 45, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (45, 46, 46, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (46, 48, 44, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (47, 49, 55, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (48, 49, 56, 1, NULL)
INSERT [dbo].[PurchaseRequestsContent] ([PurchaseContentID], [PurchaseRequestID], [ReceivingContentID], [IsPurchase], [DonorWorkshopID]) VALUES (49, 49, 57, 1, NULL)
SET IDENTITY_INSERT [dbo].[PurchaseRequestsContent] OFF
GO
SET IDENTITY_INSERT [dbo].[ReceivingRequests] ON 

INSERT [dbo].[ReceivingRequests] ([ReceivingRequestID], [ReceivingRequestDate], [WorkshopID], [PlannedDate], [ReceivingRequestType], [Reason], [Status]) VALUES (1, CAST(N'2025-06-13' AS Date), 2, CAST(N'2025-09-01' AS Date), N'Плановая', N'Годовой план производства', N'Обработана')
INSERT [dbo].[ReceivingRequests] ([ReceivingRequestID], [ReceivingRequestDate], [WorkshopID], [PlannedDate], [ReceivingRequestType], [Reason], [Status]) VALUES (2, CAST(N'2025-06-13' AS Date), 4, CAST(N'2025-09-01' AS Date), N'Внеплановая', N'Ввод нового оборудования', N'В работе')
INSERT [dbo].[ReceivingRequests] ([ReceivingRequestID], [ReceivingRequestDate], [WorkshopID], [PlannedDate], [ReceivingRequestType], [Reason], [Status]) VALUES (7, CAST(N'2025-06-13' AS Date), 3, CAST(N'2025-10-23' AS Date), N'Плановая', N'Годовой план производства', N'Не обработана')
INSERT [dbo].[ReceivingRequests] ([ReceivingRequestID], [ReceivingRequestDate], [WorkshopID], [PlannedDate], [ReceivingRequestType], [Reason], [Status]) VALUES (8, CAST(N'2025-06-14' AS Date), 4, CAST(N'2025-09-01' AS Date), N'Внеплановая', N'Ввод нового оборудования', N'В работе')
INSERT [dbo].[ReceivingRequests] ([ReceivingRequestID], [ReceivingRequestDate], [WorkshopID], [PlannedDate], [ReceivingRequestType], [Reason], [Status]) VALUES (9, CAST(N'2025-06-14' AS Date), 3, CAST(N'2025-09-01' AS Date), N'Плановая', N'Годовой план производства', N'Исполнена полностью')
INSERT [dbo].[ReceivingRequests] ([ReceivingRequestID], [ReceivingRequestDate], [WorkshopID], [PlannedDate], [ReceivingRequestType], [Reason], [Status]) VALUES (10, CAST(N'2025-06-14' AS Date), 6, CAST(N'2025-09-01' AS Date), N'Внеплановая', N'Увеличение объемов производства', N'В работе')
INSERT [dbo].[ReceivingRequests] ([ReceivingRequestID], [ReceivingRequestDate], [WorkshopID], [PlannedDate], [ReceivingRequestType], [Reason], [Status]) VALUES (11, CAST(N'2025-06-14' AS Date), 2, CAST(N'2025-09-01' AS Date), N'Внеплановая', N'Увеличение объемов производства', N'Исполнена полностью')
INSERT [dbo].[ReceivingRequests] ([ReceivingRequestID], [ReceivingRequestDate], [WorkshopID], [PlannedDate], [ReceivingRequestType], [Reason], [Status]) VALUES (12, CAST(N'2025-06-14' AS Date), 7, CAST(N'2025-09-01' AS Date), N'Внеплановая', N'Увеличение объемов производства', N'Исполнена полностью')
INSERT [dbo].[ReceivingRequests] ([ReceivingRequestID], [ReceivingRequestDate], [WorkshopID], [PlannedDate], [ReceivingRequestType], [Reason], [Status]) VALUES (13, CAST(N'2025-06-14' AS Date), 1, CAST(N'2025-09-01' AS Date), N'Плановая', N'Годовой план производства', N'В работе')
INSERT [dbo].[ReceivingRequests] ([ReceivingRequestID], [ReceivingRequestDate], [WorkshopID], [PlannedDate], [ReceivingRequestType], [Reason], [Status]) VALUES (14, CAST(N'2025-06-14' AS Date), 5, CAST(N'2025-09-01' AS Date), N'Плановая', N'Годовой план производства', N'Не обработана')
INSERT [dbo].[ReceivingRequests] ([ReceivingRequestID], [ReceivingRequestDate], [WorkshopID], [PlannedDate], [ReceivingRequestType], [Reason], [Status]) VALUES (15, CAST(N'2025-06-16' AS Date), 6, CAST(N'2025-09-01' AS Date), N'Внеплановая', N'Преждевременный выход инструмента из строя', N'Не обработана')
INSERT [dbo].[ReceivingRequests] ([ReceivingRequestID], [ReceivingRequestDate], [WorkshopID], [PlannedDate], [ReceivingRequestType], [Reason], [Status]) VALUES (16, CAST(N'2025-06-16' AS Date), 2, CAST(N'2025-09-01' AS Date), N'Плановая', N'Годовой план производства', N'Исполнена полностью')
SET IDENTITY_INSERT [dbo].[ReceivingRequests] OFF
GO
SET IDENTITY_INSERT [dbo].[ReceivingRequestsContent] ON 

INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (27, 1, N'000100001', N'Фреза R216.34-16050-AK32H 1620 ', 13)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (28, 2, N'000200001', N'Сверло 2300-0195 8 Р6М5К5         ГОСТ 10902-77                          ', 21)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (29, 2, N'000800002', N'Штангенциркуль ШЦЦ-I-150 0-150 Карбид ГОСТ 166-89', 9)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (30, 2, N'000900002', N'Гаечный ключ Рожковый 17мм 17 Хромованадий ГОСТ 2838-80', 3)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (31, 2, N'001500001', N'Дефектоскоп ДИН-3 Ультразвук ГОСТ 26266-90', 6)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (32, 2, N'000400002', N'Пластина 36111 BK6 ГОСТ 25414-90', 23)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (33, 2, N'000200004', N'Сверло Ступенчатое 4-12мм 4-12x35 HSS-E ISO 3292', 8)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (34, 7, N'001500001', N'Дефектоскоп ДИН-3 Ультразвук ГОСТ 26266-90', 3)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (35, 7, N'000200001', N'Сверло 2300-0195 8 Р6М5К5         ГОСТ 10902-77                          ', 12)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (36, 8, N'000500002', N'Калибр Пробка 10Н7 Ø10Н7 Сталь ХВГ ГОСТ 20175-74', 22)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (37, 8, N'001400001', N'Эндоскоп Е-8 Ø8x1м ТУ 4271-015', 11)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (38, 8, N'001100003', N'Динамометрический ключ Моментный 1/2" 100Нм 100-200 Сплав 42CrMo4 ISO 6789', 4)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (39, 8, N'002400001', N'Кувалда КД-5 5 кг ТУ 36-17-22-93', 3)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (40, 9, N'000400001', N'Пластина 36110 BK8    ГОСТ 25414-90                          ', 11)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (41, 10, N'002100003', N'Набор для ремонта Набор головок 1/2" 32шт 6-32мм Cr-Mo ISO 6789', 2)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (42, 11, N'001200003', N'Щётка Чашечная 75мм Ø75 Нерж. проволока DIN 8553', 8)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (43, 11, N'002900002', N'Пассатижи Шуруповёрт 18В Li-Ion 0-3500об/мин Li-Ion ТУ 48-3456-005', 2)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (44, 12, N'001600004', N'Тестер Т1000', 6)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (45, 13, N'000500003', N'Калибр Калибр-скоба 25h9 25h9 Сталь У8 ГОСТ 2216-84', 14)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (46, 13, N'000300001', N'Резец CNMG 120408-PM T15K6 ГОСТ 25393-82', 17)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (47, 13, N'000100001', N'Фреза R216.34-16050-AK32H 1620 ', 15)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (48, 14, N'001000004', N'Отвёртка ОТ01 0-5мм Инвар ГОСТ 11401-80', 15)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (49, 14, N'001500002', N'Дефектоскоп Ультр. ДУ-10 2-20мм ГОСТ 26266-90', 2)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (50, 14, N'001300002', N'Шприц для смазки Смазочный 400мл 400мл ГОСТ 21150-87', 31)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (51, 14, N'000900001', N'Гаечный ключ SW13 13 мм DIN 3110', 8)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (52, 15, N'004000001', N'Фрезерный станок НГФ-110 110х600 ГОСТ 26527-85', 3)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (53, 15, N'002100002', N'Набор для ремонта Набор инструмента 64пр. 64предм. Хромованадий ТУ 4276-005', 1)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (54, 15, N'001200003', N'Щётка Чашечная 75мм Ø75 Нерж. проволока DIN 8553', 2)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (55, 16, N'000100005', N'Фреза 4225 R45 56', 5)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (56, 16, N'000200003', N'Сверло Коническое 1-10мм 1-10мм HSS-Co DIN 338', 2)
INSERT [dbo].[ReceivingRequestsContent] ([ReceivingContentID], [ReceivingRequestID], [NomenclatureNumber], [FullName], [Quantity]) VALUES (57, 16, N'001000004', N'Отвёртка ОТ01 0-5мм Инвар ГОСТ 11401-80', 10)
SET IDENTITY_INSERT [dbo].[ReceivingRequestsContent] OFF
GO
SET IDENTITY_INSERT [dbo].[ReplacementFixation] ON 

INSERT [dbo].[ReplacementFixation] ([ReplacementID], [ReceivingContentID], [AnalogNomenclatureNumber], [Quantity]) VALUES (6, 27, N'000100002', 13)
INSERT [dbo].[ReplacementFixation] ([ReplacementID], [ReceivingContentID], [AnalogNomenclatureNumber], [Quantity]) VALUES (7, 47, N'000100002', 15)
SET IDENTITY_INSERT [dbo].[ReplacementFixation] OFF
GO
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (0, N'Центральный инструментальный склад', 0)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (1, N'Склад материалов ЦМО', 1)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (2, N'Склад готовой продукции ЦСМ', 2)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (3, N'Склад сырья ЦКМ', 3)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (4, N'Склад оснастки ЦИП', 5)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (5, N'Склад готовой продукции ЦТК', 7)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (6, N'Склад лакокрасочных материалов ЦПА', 6)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (7, N'Склад испытательного оборудования ЦИ', 8)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (8, N'Склад литья', 9)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (9, N'Склад запчастей РМЦ', 10)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (10, N'Склад ЦМО 2', 1)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (11, N'Склад инструментов ЦСМ', 2)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (12, N'Склад списанного инструмента', 0)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (13, N'Склад инструмента подлежащего ремонту ', 11)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (14, N'Склад металлопроката ЦМО', 1)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (15, N'Склад алюминиевых заготовок ЦМО', 1)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (16, N'Склад крепежа и комплектующих ЦСМ', 2)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (17, N'Склад электронных компонентов ЦСМ', 2)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (18, N'Склад полимерных материалов ЦКМ', 3)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (19, N'Склад углеродного волокна ЦКМ', 3)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (20, N'Склад термообработанных деталей ЦТО', 4)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (21, N'Склад закалочных сред ЦТО', 4)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (22, N'Склад пресс-форм ЦИП', 5)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (23, N'Склад мерительного инструмента ЦИП', 5)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (24, N'Склад грунтов и растворителей ЦПА', 6)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (25, N'Склад антикоррозийных покрытий ЦПА', 6)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (26, N'Склад эталонных образцов ЦКК', 7)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (27, N'Склад бракованной продукции ЦКК', 7)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (28, N'Склад испытательных стендов ЦИ', 8)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (29, N'Склад датчиков и измерителей ЦИ', 8)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (30, N'Склад литейных форм ЦЛП', 9)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (31, N'Склад шихтовых материалов ЦЛП', 9)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (32, N'Склад подшипников и редукторов РМЦ', 10)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (33, N'Склад гидравлики и пневматики РМЦ', 10)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (34, N'Склад расходных материалов ЦГП', 11)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (35, N'Склад химических реактивов ЦГП', 11)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (36, N'Склад плазменных горелок ЦПР', 12)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (37, N'Склад расходных электродов ЦПР', 12)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (38, N'Склад оптики для лазеров ЦЛО', 13)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (39, N'Склад защитных стекол ЦЛО', 13)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (40, N'Склад металлических порошков ЦПМ', 14)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (41, N'Склад связующих веществ ЦПМ', 14)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (42, N'Склад абразивных материалов ЦГР', 15)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (43, N'Склад водяных фильтров ЦГР', 15)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (44, N'Склад вакуумных мембран ЦВФ', 16)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (45, N'Склад полимерных листов ЦВФ', 16)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (46, N'Склад ультразвуковых излучателей ЦУС', 17)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (47, N'Склад сварочных наконечников ЦУС', 17)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (48, N'Склад роботизированных манипуляторов ЦРС', 18)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (49, N'Склад сервоприводов ЦРС', 18)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (50, N'Склад металлических порошков для 3D-печати Ц3Д', 19)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (51, N'Склад поддержек и субстратов Ц3Д', 19)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (52, N'Склад абразивных паст ЦФД', 20)
INSERT [dbo].[Storages] ([StorageID], [Name], [WorkshopID]) VALUES (53, N'Склад полировальных кругов ЦФД', 20)
GO
INSERT [dbo].[Suppliers] ([INN], [Name], [LegalAddress], [Contacts], [Notes]) VALUES (N'000000000000', N'1', N'1', N'1', NULL)
INSERT [dbo].[Suppliers] ([INN], [Name], [LegalAddress], [Contacts], [Notes]) VALUES (N'7701123456', N'ООО "ИнструментСнаб"', N'г. Москва, ул. Промышленная, 15', N'+7(495)123-45-67 info@tools.ru', N'Официальный дилер SANDVIK, ISCAR')
INSERT [dbo].[Suppliers] ([INN], [Name], [LegalAddress], [Contacts], [Notes]) VALUES (N'7711987654', N'ЗАО "ТехноМеталл"', N'г. Санкт-Петербург, пр. Энергетиков, 22', N'+7(812)555-01-02 sales@tmetall.com', N'Поставки металлорежущего инструмента')
INSERT [dbo].[Suppliers] ([INN], [Name], [LegalAddress], [Contacts], [Notes]) VALUES (N'7722345678', N'АО "ПромАбразив"', N'г. Екатеринбург, ул. Машиностроителей, 7', N'+7(343)222-33-44 abrasiv@yandex.ru', N'Абразивные материалы и круги')
INSERT [dbo].[Suppliers] ([INN], [Name], [LegalAddress], [Contacts], [Notes]) VALUES (N'7733456789', N'ООО "Калибр-Сервис"', N'г. Казань, ул. Измерительная, 5', N'+7(843)444-55-66 info@kalibr.org', N'Калибры и контрольно-измерительные приборы')
INSERT [dbo].[Suppliers] ([INN], [Name], [LegalAddress], [Contacts], [Notes]) VALUES (N'7744567890', N'ГК "ЭнергоИнструмент"', N'г. Новосибирск, пр. Академический, 120', N'+7(383)777-88-99 energo@mail.ru', N'Электроинструмент и оснастка')
INSERT [dbo].[Suppliers] ([INN], [Name], [LegalAddress], [Contacts], [Notes]) VALUES (N'7755678901', N'ООО "СтанкоПрофи"', N'г. Самара, ул. Станкостроительная, 17', N'+7(846)321-09-87 stankoprofi@list.ru', N'Станочная оснастка и фрезерный инструмент')
INSERT [dbo].[Suppliers] ([INN], [Name], [LegalAddress], [Contacts], [Notes]) VALUES (N'7766789012', N'ИП Смирнов А.В.', N'г. Нижний Новгород, ул. Кузнечная, 34', N'+7(831)234-56-78 smirnov-tools@mail.ru', N'Ручной слесарный инструмент')
INSERT [dbo].[Suppliers] ([INN], [Name], [LegalAddress], [Contacts], [Notes]) VALUES (N'7777890123', N'ООО "ЭлПрибор"', N'г. Ростов-на-Дону, ул. Электронная, 12', N'+7(863)345-67-89 elpribor@inbox.ru', N'Электроизмерительные приборы')
INSERT [dbo].[Suppliers] ([INN], [Name], [LegalAddress], [Contacts], [Notes]) VALUES (N'7788901234', N'АО "СпецСталь"', N'г. Челябинск, пр. Победы, 88', N'+7(351)456-78-90 specstal74@mail.com', N'Твердосплавные пластины и резцы')
INSERT [dbo].[Suppliers] ([INN], [Name], [LegalAddress], [Contacts], [Notes]) VALUES (N'7799012345', N'ООО "ГидроСила"', N'г. Уфа, ул. Гидравлическая, 3', N'+7(347)567-89-01 gidro@bash.ru', N'Гидравлический инструмент и пресс-формы')
INSERT [dbo].[Suppliers] ([INN], [Name], [LegalAddress], [Contacts], [Notes]) VALUES (N'7800123456', N'ЗАО "ПневмоТехника"', N'г. Воронеж, ул. Компрессорная, 9', N'+7(473)678-90-12 pnevmotekh@rambler.ru', N'Пневматический инструмент')
INSERT [dbo].[Suppliers] ([INN], [Name], [LegalAddress], [Contacts], [Notes]) VALUES (N'7811234567', N'ООО "АлмазИнструмент"', N'г. Краснодар, ул. Алмазная, 25', N'+7(861)789-01-23 almaz@kuban.ru', N'Алмазный инструмент для обработки')
INSERT [dbo].[Suppliers] ([INN], [Name], [LegalAddress], [Contacts], [Notes]) VALUES (N'7822345678', N'ИП Козлов С.И.', N'г. Пермь, ул. Шлифовальная, 11', N'+7(342)890-12-34 kozlov-abraziv@mail.ru', N'Абразивные материалы и шлифовка')
INSERT [dbo].[Suppliers] ([INN], [Name], [LegalAddress], [Contacts], [Notes]) VALUES (N'7833456789', N'ООО "МетКонтроль"', N'г. Волгоград, ул. Контрольная, 7', N'+7(844)901-23-45 metcontrol@volga.ru', N'Контрольно-измерительные системы')
INSERT [dbo].[Suppliers] ([INN], [Name], [LegalAddress], [Contacts], [Notes]) VALUES (N'7844567890', N'АО "ЭнергоПривод"', N'г. Тюмень, ул. Приводная, 18', N'+7(345)012-34-56 privod@tmr.ru', N'Электродвигатели и приводная техника')
INSERT [dbo].[Suppliers] ([INN], [Name], [LegalAddress], [Contacts], [Notes]) VALUES (N'9999999999', N'1', N'1', N'1', NULL)
GO
SET IDENTITY_INSERT [dbo].[ToolMovements] ON 

INSERT [dbo].[ToolMovements] ([MovementID], [MovementDate], [ToStorageID], [FromStorageID], [MovementTypeID], [NomenclatureNumber], [SourceDocumentType], [SourceDocumentID], [BatchNumber], [Price], [Quantity], [InvoiceType], [IsPosted], [Executor], [LastUpdated]) VALUES (1, CAST(N'2025-06-16' AS Date), 0, NULL, N'Приход', N'000800002', N'Товарная накладная', 19, N'20250616-001', CAST(0.00 AS Decimal(18, 2)), 5, NULL, 1, N'MIXMIX', CAST(N'2025-06-16T11:43:25.7621632' AS DateTime2))
INSERT [dbo].[ToolMovements] ([MovementID], [MovementDate], [ToStorageID], [FromStorageID], [MovementTypeID], [NomenclatureNumber], [SourceDocumentType], [SourceDocumentID], [BatchNumber], [Price], [Quantity], [InvoiceType], [IsPosted], [Executor], [LastUpdated]) VALUES (2, CAST(N'2025-06-16' AS Date), 0, NULL, N'Приход', N'000900002', N'Товарная накладная', 19, N'20250616-001', CAST(0.00 AS Decimal(18, 2)), 3, NULL, 1, N'MIXMIX', CAST(N'2025-06-16T11:43:36.7827421' AS DateTime2))
INSERT [dbo].[ToolMovements] ([MovementID], [MovementDate], [ToStorageID], [FromStorageID], [MovementTypeID], [NomenclatureNumber], [SourceDocumentType], [SourceDocumentID], [BatchNumber], [Price], [Quantity], [InvoiceType], [IsPosted], [Executor], [LastUpdated]) VALUES (3, CAST(N'2025-06-16' AS Date), 0, NULL, N'Приход', N'002900002', N'Товарная накладная', 22, N'20250616-001', CAST(0.00 AS Decimal(18, 2)), 2, NULL, 1, N'MIXMIX', CAST(N'2025-06-16T11:43:46.0802120' AS DateTime2))
INSERT [dbo].[ToolMovements] ([MovementID], [MovementDate], [ToStorageID], [FromStorageID], [MovementTypeID], [NomenclatureNumber], [SourceDocumentType], [SourceDocumentID], [BatchNumber], [Price], [Quantity], [InvoiceType], [IsPosted], [Executor], [LastUpdated]) VALUES (4, CAST(N'2025-06-16' AS Date), 12, 4, N'Списание', N'001200003', N'Дефектная ведомость', 7, N'20250519-001', CAST(195.40 AS Decimal(18, 2)), 1, NULL, 0, N'MIXMIX', CAST(N'2025-06-16T11:43:55.8347300' AS DateTime2))
INSERT [dbo].[ToolMovements] ([MovementID], [MovementDate], [ToStorageID], [FromStorageID], [MovementTypeID], [NomenclatureNumber], [SourceDocumentType], [SourceDocumentID], [BatchNumber], [Price], [Quantity], [InvoiceType], [IsPosted], [Executor], [LastUpdated]) VALUES (5, CAST(N'2025-06-16' AS Date), 0, NULL, N'Приход', N'001200003', N'Товарная накладная', 22, N'20250616-002', CAST(0.00 AS Decimal(18, 2)), 8, NULL, 1, N'MIXMIX', CAST(N'2025-06-16T11:44:26.2587212' AS DateTime2))
INSERT [dbo].[ToolMovements] ([MovementID], [MovementDate], [ToStorageID], [FromStorageID], [MovementTypeID], [NomenclatureNumber], [SourceDocumentType], [SourceDocumentID], [BatchNumber], [Price], [Quantity], [InvoiceType], [IsPosted], [Executor], [LastUpdated]) VALUES (6, CAST(N'2025-06-16' AS Date), 2, 0, N'Перемещение', N'001200003', N'Заявка на получение', 11, N'20250616-002', CAST(0.00 AS Decimal(18, 2)), 8, NULL, 1, N'MIXMIX', CAST(N'2025-06-16T11:44:41.2329107' AS DateTime2))
INSERT [dbo].[ToolMovements] ([MovementID], [MovementDate], [ToStorageID], [FromStorageID], [MovementTypeID], [NomenclatureNumber], [SourceDocumentType], [SourceDocumentID], [BatchNumber], [Price], [Quantity], [InvoiceType], [IsPosted], [Executor], [LastUpdated]) VALUES (7, CAST(N'2025-06-16' AS Date), 2, 0, N'Перемещение', N'002900002', N'Заявка на получение', 11, N'20250616-003', CAST(0.00 AS Decimal(18, 2)), 2, NULL, 0, N'MIXMIX', CAST(N'2025-06-16T11:44:56.7967891' AS DateTime2))
INSERT [dbo].[ToolMovements] ([MovementID], [MovementDate], [ToStorageID], [FromStorageID], [MovementTypeID], [NomenclatureNumber], [SourceDocumentType], [SourceDocumentID], [BatchNumber], [Price], [Quantity], [InvoiceType], [IsPosted], [Executor], [LastUpdated]) VALUES (8, CAST(N'2025-06-16' AS Date), 12, 8, N'Списание', N'005000001', N'Дефектная ведомость', 13, N'20250330-001', CAST(680.35 AS Decimal(18, 2)), 4, NULL, 1, N'MIXMIX', CAST(N'2025-06-16T11:45:10.1146816' AS DateTime2))
INSERT [dbo].[ToolMovements] ([MovementID], [MovementDate], [ToStorageID], [FromStorageID], [MovementTypeID], [NomenclatureNumber], [SourceDocumentType], [SourceDocumentID], [BatchNumber], [Price], [Quantity], [InvoiceType], [IsPosted], [Executor], [LastUpdated]) VALUES (9, CAST(N'2025-06-16' AS Date), 12, 7, N'Списание', N'002600001', N'Дефектная ведомость', 10, N'20240515-018', CAST(80.00 AS Decimal(18, 2)), 1, NULL, 1, N'MIXMIX', CAST(N'2025-06-16T11:45:41.3186171' AS DateTime2))
INSERT [dbo].[ToolMovements] ([MovementID], [MovementDate], [ToStorageID], [FromStorageID], [MovementTypeID], [NomenclatureNumber], [SourceDocumentType], [SourceDocumentID], [BatchNumber], [Price], [Quantity], [InvoiceType], [IsPosted], [Executor], [LastUpdated]) VALUES (10, CAST(N'2025-06-16' AS Date), 12, 0, N'Списание', N'000500001', N'Дефектная ведомость', 2, N'20240505-008', CAST(3200.00 AS Decimal(18, 2)), 3, NULL, 1, N'MIXMIX', CAST(N'2025-06-16T11:46:52.4765911' AS DateTime2))
INSERT [dbo].[ToolMovements] ([MovementID], [MovementDate], [ToStorageID], [FromStorageID], [MovementTypeID], [NomenclatureNumber], [SourceDocumentType], [SourceDocumentID], [BatchNumber], [Price], [Quantity], [InvoiceType], [IsPosted], [Executor], [LastUpdated]) VALUES (11, CAST(N'2025-06-16' AS Date), 0, NULL, N'Приход', N'000400001', N'Товарная накладная', 21, N'20250616-003', CAST(0.00 AS Decimal(18, 2)), 11, NULL, 0, N'MIXMIX', CAST(N'2025-06-16T11:47:10.4757836' AS DateTime2))
INSERT [dbo].[ToolMovements] ([MovementID], [MovementDate], [ToStorageID], [FromStorageID], [MovementTypeID], [NomenclatureNumber], [SourceDocumentType], [SourceDocumentID], [BatchNumber], [Price], [Quantity], [InvoiceType], [IsPosted], [Executor], [LastUpdated]) VALUES (12, CAST(N'2025-06-16' AS Date), 3, 0, N'Перемещение', N'000400001', N'Заявка на получение', 9, N'20250616-003', CAST(0.00 AS Decimal(18, 2)), 11, NULL, 0, N'MIXMIX', CAST(N'2025-06-16T11:47:21.0426884' AS DateTime2))
INSERT [dbo].[ToolMovements] ([MovementID], [MovementDate], [ToStorageID], [FromStorageID], [MovementTypeID], [NomenclatureNumber], [SourceDocumentType], [SourceDocumentID], [BatchNumber], [Price], [Quantity], [InvoiceType], [IsPosted], [Executor], [LastUpdated]) VALUES (13, CAST(N'2025-06-16' AS Date), 12, 6, N'Списание', N'005800001', N'Дефектная ведомость', 6, N'20241005-001', CAST(420.25 AS Decimal(18, 2)), 5, NULL, 0, N'MIXMIX', CAST(N'2025-06-16T11:47:29.9936010' AS DateTime2))
INSERT [dbo].[ToolMovements] ([MovementID], [MovementDate], [ToStorageID], [FromStorageID], [MovementTypeID], [NomenclatureNumber], [SourceDocumentType], [SourceDocumentID], [BatchNumber], [Price], [Quantity], [InvoiceType], [IsPosted], [Executor], [LastUpdated]) VALUES (14, CAST(N'2025-06-16' AS Date), 12, 9, N'Списание', N'003300001', N'Дефектная ведомость', 14, N'20250530-004', CAST(230.25 AS Decimal(18, 2)), 2, NULL, 0, N'MIXMIX', CAST(N'2025-06-16T11:47:38.1785464' AS DateTime2))
INSERT [dbo].[ToolMovements] ([MovementID], [MovementDate], [ToStorageID], [FromStorageID], [MovementTypeID], [NomenclatureNumber], [SourceDocumentType], [SourceDocumentID], [BatchNumber], [Price], [Quantity], [InvoiceType], [IsPosted], [Executor], [LastUpdated]) VALUES (15, CAST(N'2025-06-16' AS Date), 12, 3, N'Списание', N'001800001', N'Дефектная ведомость', 3, N'20240507-010', CAST(8000.00 AS Decimal(18, 2)), 1, NULL, 0, N'MIXMIX', CAST(N'2025-06-16T11:47:42.1485430' AS DateTime2))
SET IDENTITY_INSERT [dbo].[ToolMovements] OFF
GO
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (0, N'Центральный инструментальный цех')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (1, N'Цех механической обработки')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (2, N'Цех сборки и монтажа')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (3, N'Цех композитных материалов')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (4, N'Цех термической обработки')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (5, N'Цех инструментального производства')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (6, N'Цех покраски и антикоррозии')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (7, N'Цех контроля качества')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (8, N'Цех испытаний')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (9, N'Цех литейного производства')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (10, N'Ремонтно-механический цех')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (11, N'Цех гальванических покрытий')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (12, N'Цех плазменной резки')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (13, N'Цех лазерной обработки')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (14, N'Цех порошковой металлургии')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (15, N'Цех гидроабразивной резки')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (16, N'Цех вакуумной формовки')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (17, N'Цех ультразвуковой сварки')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (18, N'Цех роботизированной сборки')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (19, N'Цех 3D-печати металлом')
INSERT [dbo].[Workshops] ([WorkshopID], [Name]) VALUES (20, N'Цех финишной доводки')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Movement__A25C5AA7A0F65451]    Script Date: 16.06.2025 12:16:24 ******/
ALTER TABLE [dbo].[MovementTypes] ADD UNIQUE NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Nomenclature] ADD  DEFAULT ((0)) FOR [MinStock]
GO
ALTER TABLE [dbo].[ToolMovements] ADD  CONSTRAINT [DF__ToolMovem__IsPos__5DCAEF64]  DEFAULT ((0)) FOR [IsPosted]
GO
ALTER TABLE [dbo].[AnalogTools]  WITH CHECK ADD FOREIGN KEY([AnalogNomenclatureNumber])
REFERENCES [dbo].[Nomenclature] ([NomenclatureNumber])
GO
ALTER TABLE [dbo].[AnalogTools]  WITH CHECK ADD FOREIGN KEY([OriginalNomenclatureNumber])
REFERENCES [dbo].[Nomenclature] ([NomenclatureNumber])
GO
ALTER TABLE [dbo].[Balances]  WITH CHECK ADD  CONSTRAINT [FK__Balances__Nomenc__60A75C0F] FOREIGN KEY([NomenclatureNumber])
REFERENCES [dbo].[Nomenclature] ([NomenclatureNumber])
GO
ALTER TABLE [dbo].[Balances] CHECK CONSTRAINT [FK__Balances__Nomenc__60A75C0F]
GO
ALTER TABLE [dbo].[Balances]  WITH CHECK ADD  CONSTRAINT [FK__Balances__Storag__619B8048] FOREIGN KEY([StorageID])
REFERENCES [dbo].[Storages] ([StorageID])
GO
ALTER TABLE [dbo].[Balances] CHECK CONSTRAINT [FK__Balances__Storag__619B8048]
GO
ALTER TABLE [dbo].[DefectiveLists]  WITH CHECK ADD  CONSTRAINT [FK__Defective__Nomen__628FA481] FOREIGN KEY([NomenclatureNumber])
REFERENCES [dbo].[Nomenclature] ([NomenclatureNumber])
GO
ALTER TABLE [dbo].[DefectiveLists] CHECK CONSTRAINT [FK__Defective__Nomen__628FA481]
GO
ALTER TABLE [dbo].[DefectiveLists]  WITH CHECK ADD  CONSTRAINT [FK__Defective__Works__6383C8BA] FOREIGN KEY([WorkshopID])
REFERENCES [dbo].[Workshops] ([WorkshopID])
GO
ALTER TABLE [dbo].[DefectiveLists] CHECK CONSTRAINT [FK__Defective__Works__6383C8BA]
GO
ALTER TABLE [dbo].[DeliveryLists]  WITH CHECK ADD FOREIGN KEY([SupplierINN])
REFERENCES [dbo].[Suppliers] ([INN])
GO
ALTER TABLE [dbo].[DeliveryListsContent]  WITH CHECK ADD  CONSTRAINT [FK__DeliveryL__Deliv__656C112C] FOREIGN KEY([DeliveryListID])
REFERENCES [dbo].[DeliveryLists] ([DeliveryListID])
GO
ALTER TABLE [dbo].[DeliveryListsContent] CHECK CONSTRAINT [FK__DeliveryL__Deliv__656C112C]
GO
ALTER TABLE [dbo].[DeliveryListsContent]  WITH CHECK ADD  CONSTRAINT [FK__DeliveryL__Purch__66603565] FOREIGN KEY([PurchaseContentID])
REFERENCES [dbo].[PurchaseRequestsContent] ([PurchaseContentID])
GO
ALTER TABLE [dbo].[DeliveryListsContent] CHECK CONSTRAINT [FK__DeliveryL__Purch__66603565]
GO
ALTER TABLE [dbo].[InvoicesContent]  WITH CHECK ADD  CONSTRAINT [FK__InvoicesC__Deliv__68487DD7] FOREIGN KEY([DeliveryContentID])
REFERENCES [dbo].[DeliveryListsContent] ([DeliveryContentID])
GO
ALTER TABLE [dbo].[InvoicesContent] CHECK CONSTRAINT [FK__InvoicesC__Deliv__68487DD7]
GO
ALTER TABLE [dbo].[InvoicesContent]  WITH CHECK ADD FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[Invoices] ([InvoiceID])
GO
ALTER TABLE [dbo].[PurchaseRequestsContent]  WITH CHECK ADD FOREIGN KEY([DonorWorkshopID])
REFERENCES [dbo].[Workshops] ([WorkshopID])
GO
ALTER TABLE [dbo].[PurchaseRequestsContent]  WITH CHECK ADD FOREIGN KEY([PurchaseRequestID])
REFERENCES [dbo].[PurchaseRequests] ([PurchaseRequestID])
GO
ALTER TABLE [dbo].[PurchaseRequestsContent]  WITH CHECK ADD FOREIGN KEY([ReceivingContentID])
REFERENCES [dbo].[ReceivingRequestsContent] ([ReceivingContentID])
GO
ALTER TABLE [dbo].[ReceivingRequests]  WITH CHECK ADD FOREIGN KEY([WorkshopID])
REFERENCES [dbo].[Workshops] ([WorkshopID])
GO
ALTER TABLE [dbo].[ReceivingRequestsContent]  WITH CHECK ADD FOREIGN KEY([NomenclatureNumber])
REFERENCES [dbo].[Nomenclature] ([NomenclatureNumber])
GO
ALTER TABLE [dbo].[ReceivingRequestsContent]  WITH CHECK ADD FOREIGN KEY([ReceivingRequestID])
REFERENCES [dbo].[ReceivingRequests] ([ReceivingRequestID])
GO
ALTER TABLE [dbo].[ReplacementFixation]  WITH CHECK ADD FOREIGN KEY([AnalogNomenclatureNumber])
REFERENCES [dbo].[Nomenclature] ([NomenclatureNumber])
GO
ALTER TABLE [dbo].[ReplacementFixation]  WITH CHECK ADD  CONSTRAINT [FK__Replaceme__Recei__71D1E811] FOREIGN KEY([ReceivingContentID])
REFERENCES [dbo].[ReceivingRequestsContent] ([ReceivingContentID])
GO
ALTER TABLE [dbo].[ReplacementFixation] CHECK CONSTRAINT [FK__Replaceme__Recei__71D1E811]
GO
ALTER TABLE [dbo].[Storages]  WITH CHECK ADD FOREIGN KEY([WorkshopID])
REFERENCES [dbo].[Workshops] ([WorkshopID])
GO
ALTER TABLE [dbo].[ToolMovements]  WITH CHECK ADD  CONSTRAINT [FK__ToolMovem__FromS__73BA3083] FOREIGN KEY([FromStorageID])
REFERENCES [dbo].[Storages] ([StorageID])
GO
ALTER TABLE [dbo].[ToolMovements] CHECK CONSTRAINT [FK__ToolMovem__FromS__73BA3083]
GO
ALTER TABLE [dbo].[ToolMovements]  WITH CHECK ADD  CONSTRAINT [FK__ToolMovem__Nomen__75A278F5] FOREIGN KEY([NomenclatureNumber])
REFERENCES [dbo].[Nomenclature] ([NomenclatureNumber])
GO
ALTER TABLE [dbo].[ToolMovements] CHECK CONSTRAINT [FK__ToolMovem__Nomen__75A278F5]
GO
ALTER TABLE [dbo].[ToolMovements]  WITH CHECK ADD  CONSTRAINT [FK__ToolMovem__ToSto__76969D2E] FOREIGN KEY([ToStorageID])
REFERENCES [dbo].[Storages] ([StorageID])
GO
ALTER TABLE [dbo].[ToolMovements] CHECK CONSTRAINT [FK__ToolMovem__ToSto__76969D2E]
GO
ALTER TABLE [dbo].[AnalogTools]  WITH CHECK ADD CHECK  (([OriginalNomenclatureNumber]<>[AnalogNomenclatureNumber]))
GO
ALTER TABLE [dbo].[DefectiveLists]  WITH CHECK ADD  CONSTRAINT [CK__Defective__Quant__787EE5A0] CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[DefectiveLists] CHECK CONSTRAINT [CK__Defective__Quant__787EE5A0]
GO
ALTER TABLE [dbo].[DeliveryListsContent]  WITH CHECK ADD  CONSTRAINT [CK__DeliveryL__Quant__797309D9] CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[DeliveryListsContent] CHECK CONSTRAINT [CK__DeliveryL__Quant__797309D9]
GO
ALTER TABLE [dbo].[InvoicesContent]  WITH CHECK ADD CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[Nomenclature]  WITH CHECK ADD  CONSTRAINT [CHK_MinStock] CHECK  (([MinStock]>=(0)))
GO
ALTER TABLE [dbo].[Nomenclature] CHECK CONSTRAINT [CHK_MinStock]
GO
ALTER TABLE [dbo].[Nomenclature]  WITH CHECK ADD CHECK  (([UsageFlag]=(2) OR [UsageFlag]=(1) OR [UsageFlag]=(0)))
GO
ALTER TABLE [dbo].[PurchaseRequests]  WITH CHECK ADD CHECK  (([Status]='Исполнена полностью' OR [Status]='Исполнена частично' OR [Status]='В работе' OR [Status]='Не обработана'))
GO
ALTER TABLE [dbo].[ReceivingRequests]  WITH CHECK ADD CHECK  (([ReceivingRequestType]='Внеплановая' OR [ReceivingRequestType]='Плановая'))
GO
ALTER TABLE [dbo].[ReceivingRequests]  WITH CHECK ADD  CONSTRAINT [CK__Receiving__Statu__7F2BE32F] CHECK  (([Status]='Исполнена полностью' OR [Status]='Исполнена частично' OR [Status]='В работе' OR [Status]='Обработана' OR [Status]='Не обработана'))
GO
ALTER TABLE [dbo].[ReceivingRequests] CHECK CONSTRAINT [CK__Receiving__Statu__7F2BE32F]
GO
ALTER TABLE [dbo].[ReceivingRequestsContent]  WITH CHECK ADD CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[ReplacementFixation]  WITH CHECK ADD CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[ToolMovements]  WITH CHECK ADD  CONSTRAINT [CK__ToolMovem__Quant__02084FDA] CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[ToolMovements] CHECK CONSTRAINT [CK__ToolMovem__Quant__02084FDA]
GO
USE [master]
GO
ALTER DATABASE [TOOLACCOUNTING] SET  READ_WRITE 
GO
