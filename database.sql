USE [master]
GO
/****** Object:  Database [MeetingMinutes] ******/
CREATE DATABASE [MeetingMinutes]
GO
USE [MeetingMinutes]
GO
/****** Object:  Table [dbo].[Corporate_Customer_Tbl] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Corporate_Customer_Tbl](
	[CustomerId] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Corporate_Customer_Tbl] PRIMARY KEY CLUSTERED
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Individual_Customer_Tbl] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Individual_Customer_Tbl](
	[CustomerId] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Individual_Customer_Tbl] PRIMARY KEY CLUSTERED
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogEvents] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NOT NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
 CONSTRAINT [PK_LogEvents] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meeting_Minutes_Details_Tbl] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meeting_Minutes_Details_Tbl](
	[DetailsId] [bigint] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NULL,
	[Unit] [nvarchar](255) NULL,
	[ProductServiceId] [bigint] NULL,
	[MeetingMinutesId] [bigint] NULL,
 CONSTRAINT [PK_Meeting_Minutes_Details_Tbl] PRIMARY KEY CLUSTERED
(
	[DetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meeting_Minutes_Master_Tbl] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meeting_Minutes_Master_Tbl](
	[MeetingMinutesId] [bigint] IDENTITY(1,1) NOT NULL,
	[Place] [nvarchar](255) NOT NULL,
	[ClientSide] [nvarchar](max) NOT NULL,
	[HostSide] [nvarchar](max) NOT NULL,
	[Agenda] [nvarchar](max) NOT NULL,
	[Discussion] [nvarchar](max) NOT NULL,
	[Decision] [nvarchar](max) NOT NULL,
	[Datetime] [datetime] NULL,
	[CorporateCustomerId] [bigint] NULL,
	[IndividualCustomerId] [bigint] NULL,
 CONSTRAINT [PK_Meeting_Minutes_Master_Tbl] PRIMARY KEY CLUSTERED
(
	[MeetingMinutesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MigrationsHistory] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_MigrationsHistory] PRIMARY KEY CLUSTERED
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products_Service_Tbl] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products_Service_Tbl](
	[ProductServiceId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Type] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Products_Service_Tbl] PRIMARY KEY CLUSTERED
(
	[ProductServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Corporate_Customer_Tbl] ON
GO
INSERT [dbo].[Corporate_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (1, N'Tech Corp')
GO
INSERT [dbo].[Corporate_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (2, N'Finance Inc')
GO
INSERT [dbo].[Corporate_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (3, N'Healthcare LLC')
GO
INSERT [dbo].[Corporate_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (4, N'Education Group')
GO
INSERT [dbo].[Corporate_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (5, N'Retail Co')
GO
INSERT [dbo].[Corporate_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (6, N'Manufacturing Ltd')
GO
INSERT [dbo].[Corporate_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (7, N'Agriculture Farm')
GO
INSERT [dbo].[Corporate_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (8, N'Construction Co')
GO
INSERT [dbo].[Corporate_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (9, N'Real Estate LLC')
GO
INSERT [dbo].[Corporate_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (10, N'Media Group')
GO
SET IDENTITY_INSERT [dbo].[Corporate_Customer_Tbl] OFF
GO
SET IDENTITY_INSERT [dbo].[Individual_Customer_Tbl] ON
GO
INSERT [dbo].[Individual_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (1, N'John Doe')
GO
INSERT [dbo].[Individual_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (2, N'Jane Smith')
GO
INSERT [dbo].[Individual_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (3, N'Alice Johnson')
GO
INSERT [dbo].[Individual_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (4, N'Bob Brown')
GO
INSERT [dbo].[Individual_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (5, N'Charlie White')
GO
INSERT [dbo].[Individual_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (6, N'Diana Green')
GO
INSERT [dbo].[Individual_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (7, N'Ethan Black')
GO
INSERT [dbo].[Individual_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (8, N'Fiona Red')
GO
INSERT [dbo].[Individual_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (9, N'George Blue')
GO
INSERT [dbo].[Individual_Customer_Tbl] ([CustomerId], [CustomerName]) VALUES (10, N'Hannah Yellow')
GO
SET IDENTITY_INSERT [dbo].[Individual_Customer_Tbl] OFF
GO
INSERT [dbo].[MigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240528130002_Init', N'8.0.3')
GO
INSERT [dbo].[MigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240529105543_CreateAllTables', N'8.0.3')
GO
INSERT [dbo].[MigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240530094227_UpdateMeetingFKs', N'8.0.3')
GO
INSERT [dbo].[MigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240530143852_AddStoredProcedures', N'8.0.3')
GO
SET IDENTITY_INSERT [dbo].[Products_Service_Tbl] ON
GO
INSERT [dbo].[Products_Service_Tbl] ([ProductServiceId], [Name], [Type]) VALUES (1, N'Cloud-Based CRM Software', N'service')
GO
INSERT [dbo].[Products_Service_Tbl] ([ProductServiceId], [Name], [Type]) VALUES (2, N'AI-Powered Analytics Suite', N'service')
GO
INSERT [dbo].[Products_Service_Tbl] ([ProductServiceId], [Name], [Type]) VALUES (3, N'E-Commerce Platform', N'service')
GO
INSERT [dbo].[Products_Service_Tbl] ([ProductServiceId], [Name], [Type]) VALUES (4, N'Blockchain Technology Solutions', N'service')
GO
INSERT [dbo].[Products_Service_Tbl] ([ProductServiceId], [Name], [Type]) VALUES (5, N'Cybersecurity Services', N'service')
GO
INSERT [dbo].[Products_Service_Tbl] ([ProductServiceId], [Name], [Type]) VALUES (6, N'Wireless Earbuds', N'product')
GO
INSERT [dbo].[Products_Service_Tbl] ([ProductServiceId], [Name], [Type]) VALUES (7, N'Smart Home Hub', N'product')
GO
INSERT [dbo].[Products_Service_Tbl] ([ProductServiceId], [Name], [Type]) VALUES (8, N'Electric Scooter', N'product')
GO
INSERT [dbo].[Products_Service_Tbl] ([ProductServiceId], [Name], [Type]) VALUES (9, N'Solar Energy Panels', N'product')
GO
INSERT [dbo].[Products_Service_Tbl] ([ProductServiceId], [Name], [Type]) VALUES (10, N'Portable Power Bank', N'product')
GO
SET IDENTITY_INSERT [dbo].[Products_Service_Tbl] OFF
GO
/****** Object:  Index [IX_Meeting_Minutes_Details_Tbl_MeetingMinutesId]    Script Date: 30-May-2024 9:45:58 PM ******/
CREATE NONCLUSTERED INDEX [IX_Meeting_Minutes_Details_Tbl_MeetingMinutesId] ON [dbo].[Meeting_Minutes_Details_Tbl]
(
	[MeetingMinutesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Meeting_Minutes_Details_Tbl_ProductServiceId]    Script Date: 30-May-2024 9:45:58 PM ******/
CREATE NONCLUSTERED INDEX [IX_Meeting_Minutes_Details_Tbl_ProductServiceId] ON [dbo].[Meeting_Minutes_Details_Tbl]
(
	[ProductServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Meeting_Minutes_Master_Tbl_CorporateCustomerId]    Script Date: 30-May-2024 9:45:58 PM ******/
CREATE NONCLUSTERED INDEX [IX_Meeting_Minutes_Master_Tbl_CorporateCustomerId] ON [dbo].[Meeting_Minutes_Master_Tbl]
(
	[CorporateCustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Meeting_Minutes_Master_Tbl_IndividualCustomerId]    Script Date: 30-May-2024 9:45:58 PM ******/
CREATE NONCLUSTERED INDEX [IX_Meeting_Minutes_Master_Tbl_IndividualCustomerId] ON [dbo].[Meeting_Minutes_Master_Tbl]
(
	[IndividualCustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Meeting_Minutes_Details_Tbl]  WITH CHECK ADD  CONSTRAINT [FK_Meeting_Minutes_Details_Tbl_Meeting_Minutes_Master_Tbl_MeetingMinutesId] FOREIGN KEY([MeetingMinutesId])
REFERENCES [dbo].[Meeting_Minutes_Master_Tbl] ([MeetingMinutesId])
GO
ALTER TABLE [dbo].[Meeting_Minutes_Details_Tbl] CHECK CONSTRAINT [FK_Meeting_Minutes_Details_Tbl_Meeting_Minutes_Master_Tbl_MeetingMinutesId]
GO
ALTER TABLE [dbo].[Meeting_Minutes_Details_Tbl]  WITH CHECK ADD  CONSTRAINT [FK_Meeting_Minutes_Details_Tbl_Products_Service_Tbl_ProductServiceId] FOREIGN KEY([ProductServiceId])
REFERENCES [dbo].[Products_Service_Tbl] ([ProductServiceId])
GO
ALTER TABLE [dbo].[Meeting_Minutes_Details_Tbl] CHECK CONSTRAINT [FK_Meeting_Minutes_Details_Tbl_Products_Service_Tbl_ProductServiceId]
GO
ALTER TABLE [dbo].[Meeting_Minutes_Master_Tbl]  WITH CHECK ADD  CONSTRAINT [FK_Meeting_Minutes_Master_Tbl_Corporate_Customer_Tbl_CorporateCustomerId] FOREIGN KEY([CorporateCustomerId])
REFERENCES [dbo].[Corporate_Customer_Tbl] ([CustomerId])
GO
ALTER TABLE [dbo].[Meeting_Minutes_Master_Tbl] CHECK CONSTRAINT [FK_Meeting_Minutes_Master_Tbl_Corporate_Customer_Tbl_CorporateCustomerId]
GO
ALTER TABLE [dbo].[Meeting_Minutes_Master_Tbl]  WITH CHECK ADD  CONSTRAINT [FK_Meeting_Minutes_Master_Tbl_Individual_Customer_Tbl_IndividualCustomerId] FOREIGN KEY([IndividualCustomerId])
REFERENCES [dbo].[Individual_Customer_Tbl] ([CustomerId])
GO
ALTER TABLE [dbo].[Meeting_Minutes_Master_Tbl] CHECK CONSTRAINT [FK_Meeting_Minutes_Master_Tbl_Individual_Customer_Tbl_IndividualCustomerId]
GO
/****** Object:  StoredProcedure [dbo].[Meeting_Minutes_Details_Save_SP]    Script Date: 30-May-2024 9:45:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

                CREATE PROCEDURE [dbo].[Meeting_Minutes_Details_Save_SP]
                    @Quantity INT,
                    @Unit NVARCHAR(255),
                    @ProductServiceId BIGINT,
                    @MeetingMinutesId BIGINT
                AS
                BEGIN
                    INSERT INTO dbo.Meeting_Minutes_Details_Tbl (Quantity, Unit, ProductServiceId, MeetingMinutesId)
                    VALUES (@Quantity, @Unit, @ProductServiceId, @MeetingMinutesId);
                END;

GO
/****** Object:  StoredProcedure [dbo].[Meeting_Minutes_Master_Save_SP]    Script Date: 30-May-2024 9:45:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

                CREATE PROCEDURE [dbo].[Meeting_Minutes_Master_Save_SP]
                    @Place NVARCHAR(255),
                    @ClientSide NVARCHAR(MAX),
                    @HostSide NVARCHAR(MAX),
                    @Agenda NVARCHAR(MAX),
                    @Discussion NVARCHAR(MAX),
                    @Decision NVARCHAR(MAX),
                    @Datetime DATETIME = null,
                    @CorporateCustomerId BIGINT null,
                    @IndividualCustomerId BIGINT = null,
                    @InsertedId BIGINT OUTPUT
                AS
                BEGIN
                    INSERT INTO Meeting_Minutes_Master_Tbl (
                        Place, ClientSide, HostSide, Agenda, Discussion,
                        Decision, Datetime, CorporateCustomerId, IndividualCustomerId
                    )
                    VALUES (
                        @Place, @ClientSide, @HostSide, @Agenda, @Discussion,
                        @Decision, @Datetime, @CorporateCustomerId, @IndividualCustomerId
                    );

                    SET @InsertedId = SCOPE_IDENTITY();
                END;

GO
USE [master]
GO
ALTER DATABASE [MeetingMinutes] SET  READ_WRITE
GO
