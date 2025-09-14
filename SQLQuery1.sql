USE master
GO

DROP DATABASE IF EXISTS PRN222CarManagementDB
GO

CREATE DATABASE PRN222CarManagementDB
GO

USE PRN222CarManagementDB
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [UserAccount](
	[UserAccountID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[EmployeeCode] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[RequestCode] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ApplicationCode] [nvarchar](50) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[UserAccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [UserAccount] ON 
GO
INSERT [UserAccount] ([UserAccountID], [UserName], [Password], [FullName], [Email], [Phone], [EmployeeCode], [RoleId], [RequestCode], [CreatedDate], [ApplicationCode], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, N'acc', N'@a', N'Accountant', N'Accountant@', N'0913652742', N'000001', 2, NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [UserAccount] ([UserAccountID], [UserName], [Password], [FullName], [Email], [Phone], [EmployeeCode], [RoleId], [RequestCode], [CreatedDate], [ApplicationCode], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2, N'auditor', N'@a', N'Internal Auditor', N'InternalAuditor@', N'0972224568', N'000002', 3, NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [UserAccount] ([UserAccountID], [UserName], [Password], [FullName], [Email], [Phone], [EmployeeCode], [RoleId], [RequestCode], [CreatedDate], [ApplicationCode], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3, N'chiefacc', N'@a', N'Chief Accountant', N'ChiefAccountant@', N'0902927373', N'000003', 1, NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [UserAccount] OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE OrderVienTLN (
	[OrderVienTLNID] [BIGINT] PRIMARY KEY,
	[DealerID] [BIGINT] NOT NULL,
	[CustomerID] [BIGINT] NULL,
	[VehicleID] [BIGINT] NOT NULL,
	[Quantity] [INT] NOT NULL DEFAULT 1,
	[QuoteID] [BIGINT] NULL,
	[SalesContractID] [BIGINT] NULL,
	[OrderType] [VARCHAR](20) NOT NULL,
	[Status] [VARCHAR](20) NOT NULL,
	[DeliveryDate] [DATETIME] NULL,
	[UnitPrice] DECIMAL(18,2) NOT NULL,
	[TotalAmount] DECIMAL(18,2) NOT NULL,
	[DiscountPrice] DECIMAL(18,2) DEFAULT 0,
	[CreatedAt] [DATETIME] DEFAULT CURRENT_TIMESTAMP,
	[UpdatedAt] [DATETIME] DEFAULT CURRENT_TIMESTAMP,
	[IsRefunded] [BIT] DEFAULT 0
);
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE PaymentVienTLN (
	[PaymentVienTLNID] [BIGINT] PRIMARY KEY,
	[OrderID] [BIGINT] NOT NULL FOREIGN KEY REFERENCES OrderVienTLN(OrderVienTLNID),
	[PaymentDate] [DATETIME] DEFAULT CURRENT_TIMESTAMP,
	[AmountPaid] DECIMAL(18,2) NOT NULL,
	[PaymentMethod] [VARCHAR](20) NOT NULL,
	[TransactionRef] [VARCHAR](100) NULL,
	[Note] [NVARCHAR](255) NULL,
	[PaymentStatus] [VARCHAR](20) NOT NULL,
	[IsFinalPayment] [BIT] DEFAULT 0,
	[ConfirmDate] [DATETIME] NULL,
	[BankCode] [VARCHAR](20) NULL,
);


