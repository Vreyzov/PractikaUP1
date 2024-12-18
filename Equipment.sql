USE [EquipmentRent]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 03.12.2024 2:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](15) NULL,
	[Email] [nvarchar](100) NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 03.12.2024 2:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[EquipmentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[PricePerDay] [decimal](10, 2) NOT NULL,
	[LessorID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EquipmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lessor]    Script Date: 03.12.2024 2:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lessor](
	[LessorID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](15) NULL,
	[Email] [nvarchar](100) NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LessorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 03.12.2024 2:30:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NULL,
	[ClientID] [int] NOT NULL,
	[LessorID] [int] NOT NULL,
	[EquipmentID] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[TotalCost] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ClientID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (1, N'Иван', N'Иванов', N'89001112233', N'ivanov@mail.ru', N'ivanov', N'pass123')
INSERT [dbo].[Client] ([ClientID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (2, N'Мария', N'Петрова', N'89004445566', N'petrova@mail.ru', N'petrova', N'qwerty')
INSERT [dbo].[Client] ([ClientID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (3, N'Алексей', N'Смирнов', N'89007778899', N'smirnov@mail.ru', N'smirnov', N'12345678')
INSERT [dbo].[Client] ([ClientID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (4, N'Андрей', N'Сергеев', N'89009991111', N'andrey@mail.ru', N'andrey', N'andrpass')
INSERT [dbo].[Client] ([ClientID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (5, N'Ольга', N'Новикова', N'89001231234', N'novikova@mail.ru', N'novikova', N'olga2024')
INSERT [dbo].[Client] ([ClientID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (6, N'Николай', N'Федоров', N'89003455678', N'fedorov@mail.ru', N'fedorov', N'passfed')
INSERT [dbo].[Client] ([ClientID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (7, N'Володя', N'Соловушкин', NULL, NULL, N'SOLOVUSHKIN', N'ыщдщ123')
INSERT [dbo].[Client] ([ClientID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (8, N'Артём', N'Козлов', N'89157834521', N'kozlov@mail.ru', N'kozlov_art', N'pass789')
INSERT [dbo].[Client] ([ClientID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (9, N'Евгения', N'Соколова', N'89263457812', N'sokolova@mail.ru', N'sok_eva', N'eva2024')
INSERT [dbo].[Client] ([ClientID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (10, N'Максим', N'Волков', N'89091234567', N'volkov@mail.ru', N'volkov_max', N'max123')
INSERT [dbo].[Client] ([ClientID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (11, N'София', N'Лебедева', N'89165438790', N'lebedeva@mail.ru', N'sofia_leb', N'sof456')
INSERT [dbo].[Client] ([ClientID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (12, N'Кирилл', N'Морозов', N'89257894561', N'morozov_k@mail.ru', N'kirill_m', N'kir789')
INSERT [dbo].[Client] ([ClientID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (13, N'Дарья', N'Васильева', N'89164563278', N'vasileva@mail.ru', N'daria_vas', N'dar234')
INSERT [dbo].[Client] ([ClientID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (14, N'Глеб', N'Никитин', N'89263456789', N'nikitin@mail.ru', N'gleb_nik', N'gleb567')
INSERT [dbo].[Client] ([ClientID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (15, N'Полина', N'Зайцева', N'89165437890', N'zaiceva@mail.ru', N'polina_z', N'pol890')
INSERT [dbo].[Client] ([ClientID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (16, N'Тимур', N'Григорьев', N'89257893456', N'grigorev@mail.ru', N'timur_g', N'tim123')
INSERT [dbo].[Client] ([ClientID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (17, N'Алиса', N'Кузьмина', N'89091237890', N'kuzmina@mail.ru', N'alisa_k', N'ali456')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Equipment] ON 

INSERT [dbo].[Equipment] ([EquipmentID], [Name], [PricePerDay], [LessorID]) VALUES (1, N'Ноутбук Dell XPS 15', CAST(1500.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Equipment] ([EquipmentID], [Name], [PricePerDay], [LessorID]) VALUES (2, N'Фотоаппарат Canon EOS R', CAST(2000.00 AS Decimal(10, 2)), 2)
INSERT [dbo].[Equipment] ([EquipmentID], [Name], [PricePerDay], [LessorID]) VALUES (3, N'Проектор Epson EB-U50', CAST(1000.00 AS Decimal(10, 2)), 3)
INSERT [dbo].[Equipment] ([EquipmentID], [Name], [PricePerDay], [LessorID]) VALUES (4, N'Электрогитара Fender Stratocaster', CAST(2500.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[Equipment] ([EquipmentID], [Name], [PricePerDay], [LessorID]) VALUES (5, N'Штатив Manfrotto Compact', CAST(300.00 AS Decimal(10, 2)), 2)
INSERT [dbo].[Equipment] ([EquipmentID], [Name], [PricePerDay], [LessorID]) VALUES (7, N'Видеокамера Sony FX3', CAST(3000.00 AS Decimal(10, 2)), 7)
INSERT [dbo].[Equipment] ([EquipmentID], [Name], [PricePerDay], [LessorID]) VALUES (8, N'Квадрокоптер DJI Mavic 3', CAST(2500.00 AS Decimal(10, 2)), 8)
INSERT [dbo].[Equipment] ([EquipmentID], [Name], [PricePerDay], [LessorID]) VALUES (9, N'Микрофон Shure SM7B', CAST(800.00 AS Decimal(10, 2)), 9)
INSERT [dbo].[Equipment] ([EquipmentID], [Name], [PricePerDay], [LessorID]) VALUES (10, N'Световой прибор Aputure 600d', CAST(1800.00 AS Decimal(10, 2)), 10)
INSERT [dbo].[Equipment] ([EquipmentID], [Name], [PricePerDay], [LessorID]) VALUES (11, N'Синтезатор Roland Jupiter-X', CAST(2200.00 AS Decimal(10, 2)), 7)
INSERT [dbo].[Equipment] ([EquipmentID], [Name], [PricePerDay], [LessorID]) VALUES (12, N'3D-принтер Prusa i3 MK3S+', CAST(1500.00 AS Decimal(10, 2)), 8)
INSERT [dbo].[Equipment] ([EquipmentID], [Name], [PricePerDay], [LessorID]) VALUES (13, N'Аудиоинтерфейс Universal Audio Apollo', CAST(1200.00 AS Decimal(10, 2)), 9)
INSERT [dbo].[Equipment] ([EquipmentID], [Name], [PricePerDay], [LessorID]) VALUES (14, N'Барабанная установка Pearl Masters', CAST(2800.00 AS Decimal(10, 2)), 10)
INSERT [dbo].[Equipment] ([EquipmentID], [Name], [PricePerDay], [LessorID]) VALUES (15, N'Телескоп Celestron EdgeHD', CAST(3500.00 AS Decimal(10, 2)), 7)
INSERT [dbo].[Equipment] ([EquipmentID], [Name], [PricePerDay], [LessorID]) VALUES (16, N'Игровая приставка PS5', CAST(1000.00 AS Decimal(10, 2)), 8)
SET IDENTITY_INSERT [dbo].[Equipment] OFF
GO
SET IDENTITY_INSERT [dbo].[Lessor] ON 

INSERT [dbo].[Lessor] ([LessorID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (1, N'Сергей', N'Морозов', N'89001234567', N'morozov@mail.ru', N'morozov', N'lessor123')
INSERT [dbo].[Lessor] ([LessorID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (2, N'Елена', N'Кузнецова', N'89009876543', N'kuznecova@mail.ru', N'kuznecova', N'rent456')
INSERT [dbo].[Lessor] ([LessorID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (3, N'Дмитрий', N'Васильев', N'89004567890', N'vasiliev@mail.ru', N'vasiliev', N'dmipass')
INSERT [dbo].[Lessor] ([LessorID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (4, N'Анна', N'Фролова', N'89007654321', N'frolova@mail.ru', N'frolova', N'annapass')
INSERT [dbo].[Lessor] ([LessorID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (5, N'Олег', N'Рябов', N'89006743210', N'ryabov@mail.ru', N'ryabov', N'ryabpass')
INSERT [dbo].[Lessor] ([LessorID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (6, N'Монстер', N'Монстров', N'89687415266', N'vladimirsolovev817@gmail.com', N'monster', N'monster123')
INSERT [dbo].[Lessor] ([LessorID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (7, N'Роман', N'Белов', N'89267894563', N'belov@mail.ru', N'roman_b', N'rom789')
INSERT [dbo].[Lessor] ([LessorID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (8, N'Марина', N'Комарова', N'89165432189', N'komarova@mail.ru', N'marina_k', N'mar234')
INSERT [dbo].[Lessor] ([LessorID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (9, N'Степан', N'Орлов', N'89257891234', N'orlov@mail.ru', N'stepan_o', N'step567')
INSERT [dbo].[Lessor] ([LessorID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (10, N'Вера', N'Миронова', N'89091234567', N'mironova@mail.ru', N'vera_m', N'ver890')
INSERT [dbo].[Lessor] ([LessorID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (11, N'Антон', N'Карпов', N'89165437889', N'karpov@mail.ru', N'anton_k', N'ant123')
INSERT [dbo].[Lessor] ([LessorID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (12, N'Юлия', N'Медведева', N'89267893456', N'medvedeva@mail.ru', N'yulia_m', N'yul456')
INSERT [dbo].[Lessor] ([LessorID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (13, N'Богдан', N'Соловьев', N'89257894567', N'solovev@mail.ru', N'bogdan_s', N'bog789')
INSERT [dbo].[Lessor] ([LessorID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (14, N'Ирина', N'Котова', N'89165432178', N'kotova@mail.ru', N'irina_k', N'ir234')
INSERT [dbo].[Lessor] ([LessorID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (15, N'Павел', N'Жуков', N'89091237856', N'zhukov@mail.ru', N'pavel_zh', N'pav567')
INSERT [dbo].[Lessor] ([LessorID], [FirstName], [LastName], [Phone], [Email], [Login], [Password]) VALUES (16, N'Алёна', N'Щербакова', N'89267891234', N'scherbakova@mail.ru', N'alena_sch', N'al890')
SET IDENTITY_INSERT [dbo].[Lessor] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [OrderDate], [ClientID], [LessorID], [EquipmentID], [StartDate], [EndDate], [TotalCost]) VALUES (1, CAST(N'2024-11-26T08:53:43.607' AS DateTime), 1, 1, 1, CAST(N'2024-01-12T00:00:00.000' AS DateTime), CAST(N'2024-05-12T00:00:00.000' AS DateTime), CAST(7500.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([OrderID], [OrderDate], [ClientID], [LessorID], [EquipmentID], [StartDate], [EndDate], [TotalCost]) VALUES (2, CAST(N'2024-11-26T08:53:43.607' AS DateTime), 2, 2, 2, CAST(N'2024-02-12T00:00:00.000' AS DateTime), CAST(N'2024-07-12T00:00:00.000' AS DateTime), CAST(12000.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([OrderID], [OrderDate], [ClientID], [LessorID], [EquipmentID], [StartDate], [EndDate], [TotalCost]) VALUES (3, CAST(N'2024-11-26T08:53:43.607' AS DateTime), 3, 3, 3, CAST(N'2024-03-12T00:00:00.000' AS DateTime), CAST(N'2024-06-12T00:00:00.000' AS DateTime), CAST(3000.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([OrderID], [OrderDate], [ClientID], [LessorID], [EquipmentID], [StartDate], [EndDate], [TotalCost]) VALUES (4, CAST(N'2024-11-26T08:53:43.607' AS DateTime), 4, 1, 4, CAST(N'2024-04-12T00:00:00.000' AS DateTime), CAST(N'2024-08-12T00:00:00.000' AS DateTime), CAST(10000.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([OrderID], [OrderDate], [ClientID], [LessorID], [EquipmentID], [StartDate], [EndDate], [TotalCost]) VALUES (5, CAST(N'2024-11-26T08:53:43.607' AS DateTime), 5, 2, 5, CAST(N'2024-05-12T00:00:00.000' AS DateTime), CAST(N'2024-09-12T00:00:00.000' AS DateTime), CAST(1200.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([OrderID], [OrderDate], [ClientID], [LessorID], [EquipmentID], [StartDate], [EndDate], [TotalCost]) VALUES (17, CAST(N'2024-12-03T02:28:51.943' AS DateTime), 8, 7, 7, CAST(N'2024-01-15T00:00:00.000' AS DateTime), CAST(N'2024-01-20T00:00:00.000' AS DateTime), CAST(7500.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([OrderID], [OrderDate], [ClientID], [LessorID], [EquipmentID], [StartDate], [EndDate], [TotalCost]) VALUES (18, CAST(N'2024-12-03T02:28:51.943' AS DateTime), 9, 8, 7, CAST(N'2024-02-01T00:00:00.000' AS DateTime), CAST(N'2024-02-05T00:00:00.000' AS DateTime), CAST(4800.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([OrderID], [OrderDate], [ClientID], [LessorID], [EquipmentID], [StartDate], [EndDate], [TotalCost]) VALUES (19, CAST(N'2024-12-03T02:28:51.943' AS DateTime), 10, 9, 8, CAST(N'2024-02-10T00:00:00.000' AS DateTime), CAST(N'2024-02-15T00:00:00.000' AS DateTime), CAST(14000.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([OrderID], [OrderDate], [ClientID], [LessorID], [EquipmentID], [StartDate], [EndDate], [TotalCost]) VALUES (20, CAST(N'2024-12-03T02:28:51.943' AS DateTime), 8, 10, 9, CAST(N'2024-03-01T00:00:00.000' AS DateTime), CAST(N'2024-03-07T00:00:00.000' AS DateTime), CAST(24500.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([OrderID], [OrderDate], [ClientID], [LessorID], [EquipmentID], [StartDate], [EndDate], [TotalCost]) VALUES (21, CAST(N'2024-12-03T02:28:51.943' AS DateTime), 9, 7, 10, CAST(N'2024-03-15T00:00:00.000' AS DateTime), CAST(N'2024-03-20T00:00:00.000' AS DateTime), CAST(5000.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([OrderID], [OrderDate], [ClientID], [LessorID], [EquipmentID], [StartDate], [EndDate], [TotalCost]) VALUES (22, CAST(N'2024-12-03T02:28:51.943' AS DateTime), 10, 8, 7, CAST(N'2024-04-01T00:00:00.000' AS DateTime), CAST(N'2024-04-05T00:00:00.000' AS DateTime), CAST(7500.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([OrderID], [OrderDate], [ClientID], [LessorID], [EquipmentID], [StartDate], [EndDate], [TotalCost]) VALUES (23, CAST(N'2024-12-03T02:28:51.943' AS DateTime), 8, 9, 7, CAST(N'2024-04-15T00:00:00.000' AS DateTime), CAST(N'2024-04-20T00:00:00.000' AS DateTime), CAST(6000.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([OrderID], [OrderDate], [ClientID], [LessorID], [EquipmentID], [StartDate], [EndDate], [TotalCost]) VALUES (24, CAST(N'2024-12-03T02:28:51.943' AS DateTime), 9, 10, 8, CAST(N'2024-05-01T00:00:00.000' AS DateTime), CAST(N'2024-05-07T00:00:00.000' AS DateTime), CAST(19600.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([OrderID], [OrderDate], [ClientID], [LessorID], [EquipmentID], [StartDate], [EndDate], [TotalCost]) VALUES (25, CAST(N'2024-12-03T02:28:51.943' AS DateTime), 10, 7, 9, CAST(N'2024-05-15T00:00:00.000' AS DateTime), CAST(N'2024-05-20T00:00:00.000' AS DateTime), CAST(17500.00 AS Decimal(10, 2)))
INSERT [dbo].[Order] ([OrderID], [OrderDate], [ClientID], [LessorID], [EquipmentID], [StartDate], [EndDate], [TotalCost]) VALUES (26, CAST(N'2024-12-03T02:28:51.943' AS DateTime), 8, 8, 10, CAST(N'2024-06-01T00:00:00.000' AS DateTime), CAST(N'2024-06-05T00:00:00.000' AS DateTime), CAST(4000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Client__5E55825B94D86418]    Script Date: 03.12.2024 2:30:32 ******/
ALTER TABLE [dbo].[Client] ADD UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Lessor__5E55825B2BDBBB9E]    Script Date: 03.12.2024 2:30:32 ******/
ALTER TABLE [dbo].[Lessor] ADD UNIQUE NONCLUSTERED 
(
	[Login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD FOREIGN KEY([LessorID])
REFERENCES [dbo].[Lessor] ([LessorID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([EquipmentID])
REFERENCES [dbo].[Equipment] ([EquipmentID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([LessorID])
REFERENCES [dbo].[Lessor] ([LessorID])
GO
