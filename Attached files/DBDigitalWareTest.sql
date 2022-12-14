USE [DigitalWare]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 18/09/2022 12:57:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] NOT NULL,
	[FullName] [nvarchar](60) NOT NULL,
	[Address] [nvarchar](60) NULL,
	[Phone] [nvarchar](25) NULL,
	[City] [nvarchar](60) NULL,
	[Birthday] [datetime] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 18/09/2022 12:57:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Detail]    Script Date: 18/09/2022 12:57:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Detail](
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
 CONSTRAINT [PK_Order Details] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 18/09/2022 12:57:35 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[UnitsInStock] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (33465345, N'Pedro Afonso', N'Av. dos Lusíadas, 23', N'30415536', N'Sao Paulo', CAST(N'1994-04-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (55517133, N'Ann Devon', N'35 King George', N'21823540', N'London', CAST(N'1996-09-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (66308006, N'Laurence Lebihan', N'12, rue des Bouchers', N'34782965', N'Marseille', CAST(N'1996-08-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (87473250, N'Frédérique Citeaux', N'24, place Kléber', N'341133', N'Strasbourg', CAST(N'1996-08-08T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (91732227, N'Mario Pontes', N'Rua do Paço, 67', N'34031624', N'Rio de Janeiro', CAST(N'1996-08-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (104139398, N'Ana Trujillo', N'Avda. de la Constitución 2222', N'23977886', N'México D.F.', CAST(N'1996-08-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (283432135, N'Victoria Ashworth', N'Fauntleroy Circus', N'22905935', N'London', CAST(N'1996-08-14T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (306911997, N'José Pedro Freyre', N'C/ Romero, 33', N'4333288', N'Sevilla', CAST(N'1996-09-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (336403741, N'Manuel Pereira', N'5ª Ave. Los Palos Grandes', N'6496619', N'Caracas', CAST(N'1977-09-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (377912875, N'Aria Cruz', N'Rua Orós, 92', N'35125094', N'Sao Paulo', CAST(N'1996-08-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (398929610, N'Paolo Accorti', N'Via Monte Bianco 34', N'13002095', N'Torino', CAST(N'1996-09-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (408367203, N'Peter Franken', N'Berliner Platz 43', N'22831259', N'München', CAST(N'2000-08-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (413833364, N'Carlos Hernández', N'Carrera 22 con Ave. Carlos Soublette #8-35', N'7859829', N'San Cristóbal', CAST(N'1996-09-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (495442468, N'Diego Roel', N'C/ Moralzarzal, 86', N'21700225', N'Madrid', CAST(N'1996-08-14T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (506964264, N'André Fonseca', N'Av. Brasil, 442', N'9350919', N'Campinas', CAST(N'1996-09-09T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (516600855, N'Martine Rancé', N'184, chaussée de Tournai', N'24408559', N'Lille', CAST(N'1996-08-29T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (539554233, N'Francisco Chang', N'Sierras de Granada 9993', N'14370089', N'México D.F.', CAST(N'1999-05-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (566788028, N'Roland Mendel', N'Kirchgasse 6', N'8148763', N'Graz', CAST(N'1996-08-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (600814844, N'Elizabeth Lincoln', N'23 Tsawassen Blvd.', N'22097121', N'Tsawassen', CAST(N'1988-08-13T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (601762029, N'Lino Rodriguez', N'Jardim das rosas n. 32', N'30299540', N'Lisboa', CAST(N'1996-09-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (609119346, N'Antonio Moreno', N'Mataderos  2312', N'17623425', N'México D.F.', CAST(N'1996-08-05T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (634429104, N'Yang Wang', N'Hauptstr. 29', N'14685589', N'Bern', CAST(N'1996-08-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (650652848, N'Carine Schmitt', N'54, rue Royale', N'30941723', N'Nantes', CAST(N'1996-09-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (664726461, N'Elizabeth Brown', N'Berkeley Gardens 12  Brewery', N'28704239', N'London', CAST(N'1996-08-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (707488414, N'Hanna Moos', N'Forsterstr. 57', N'8314776', N'Mannheim', CAST(N'1996-07-24T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (802492371, N'Patricio Simpson', N'Cerrito 333', N'6676637', N'Buenos Aires', CAST(N'1999-08-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (872972548, N'Maria Larsson', N'Åkergatan 24', N'5824806', N'Bräcke', CAST(N'1996-08-29T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (875835042, N'Howard Snyder', N'2732 Baker Blvd.', N'24568616', N'Eugene', CAST(N'1996-09-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (882837427, N'Sven Ottlieb', N'Walserweg 21', N'26391932', N'Aachen', CAST(N'1996-08-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (898286541, N'Thomas Hardy', N'120 Hanover Sq.', N'9789051', N'London', CAST(N'1991-03-29T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (956642979, N'Eduardo Saavedra', N'Rambla de Cataluña, 23', N'27742379', N'Barcelona', CAST(N'1996-08-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (967910935, N'Janine Labrune', N'67, rue des Cinquante Otages', N'30699309', N'Nantes', CAST(N'1996-08-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (1041131005, N'Christina Berglund', N'Berguvsvägen  8', N'14049611', N'Luleå', CAST(N'1996-08-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (1074262835, N'Martín Sommer', N'C/ Araquil, 67', N'14204093', N'Madrid', CAST(N'1996-08-09T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([CustomerID], [FullName], [Address], [Phone], [City], [Birthday]) VALUES (1092523547, N'Maria Anders', N'Obere Str. 57', N'33369118', N'Berlin', CAST(N'1989-08-01T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [CustomerID], [OrderDate]) VALUES (1, 33465345, CAST(N'2000-01-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [CustomerID], [OrderDate]) VALUES (2, 55517133, CAST(N'2000-02-05T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [CustomerID], [OrderDate]) VALUES (3, 66308006, CAST(N'2000-02-08T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [CustomerID], [OrderDate]) VALUES (4, 87473250, CAST(N'2000-04-08T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [CustomerID], [OrderDate]) VALUES (5, 91732227, CAST(N'2000-05-09T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [CustomerID], [OrderDate]) VALUES (6, 104139398, CAST(N'2000-07-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Order] ([OrderID], [CustomerID], [OrderDate]) VALUES (7, 283432135, CAST(N'2001-07-11T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[Order_Detail] ([OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (1, 1, 4, 65400.0000)
INSERT [dbo].[Order_Detail] ([OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (1, 2, 25, 79700.0000)
INSERT [dbo].[Order_Detail] ([OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (2, 3, 15, 43000.0000)
INSERT [dbo].[Order_Detail] ([OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (2, 4, 2, 44600.0000)
INSERT [dbo].[Order_Detail] ([OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (2, 5, 4, 91805.0000)
INSERT [dbo].[Order_Detail] ([OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (3, 6, 38, 107500.0000)
INSERT [dbo].[Order_Detail] ([OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (4, 7, 5, 89000.0000)
INSERT [dbo].[Order_Detail] ([OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (4, 8, 7, 172000.0000)
INSERT [dbo].[Order_Detail] ([OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (5, 1, 1, 65400.0000)
INSERT [dbo].[Order_Detail] ([OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (5, 2, 71, 79700.0000)
INSERT [dbo].[Order_Detail] ([OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (5, 3, 2, 43000.0000)
INSERT [dbo].[Order_Detail] ([OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (5, 8, 4, 172000.0000)
INSERT [dbo].[Order_Detail] ([OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (5, 9, 2, 578100.0000)
INSERT [dbo].[Order_Detail] ([OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (6, 4, 2, 44600.0000)
INSERT [dbo].[Order_Detail] ([OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (6, 5, 42, 91805.0000)
INSERT [dbo].[Order_Detail] ([OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (6, 7, 4, 89000.0000)
INSERT [dbo].[Order_Detail] ([OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (7, 1, 7, 65400.0000)
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (1, N'Chai', 39, 77400.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (2, N'Chang', 17, 81700.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (3, N'Aniseed Syrup', 3, 43000.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (4, N'Chef Anton''s Cajun Seasoning', 53, 94600.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (5, N'Chef Anton''s Gumbo Mix', 0, 91805.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (6, N'Grandma''s Boysenberry Spread', 120, 107500.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (7, N'Uncle Bob''s Organic Dried Pears', 15, 129000.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (8, N'Northwoods Cranberry Sauce', 6, 172000.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (9, N'Mishi Kobe Niku', 29, 417100.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (10, N'Ikura', 2, 133300.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (11, N'Queso Cabrales', 22, 90300.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (12, N'Queso Manchego La Pastora', 86, 163400.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (13, N'Konbu', 24, 25800.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (14, N'Tofu', 35, 99975.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (15, N'Genen Shouyu', 39, 66650.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (16, N'Pavlova', 29, 75035.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (17, N'Alice Mutton', 0, 167700.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (18, N'Carnarvon Tigers', 5, 268750.0000, 1)
INSERT [dbo].[Product] ([ProductID], [ProductName], [UnitsInStock], [UnitPrice], [Status]) VALUES (19, N'Teatime Chocolate Biscuits', 25, 39560.0000, 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_Details_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[Order_Detail] CHECK CONSTRAINT [FK_Order_Details_Orders]
GO
ALTER TABLE [dbo].[Order_Detail]  WITH CHECK ADD  CONSTRAINT [FK_Order_Details_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Order_Detail] CHECK CONSTRAINT [FK_Order_Details_Products]
GO
