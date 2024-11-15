CREATE DATABASE Annunci;
GO
USE [Annunci]
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carte](
	[Id] [varchar](8) NOT NULL,
	[Nome] [varchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inserzioni](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Venditore] [nvarchar](900) NOT NULL,
	[Carta] [varchar](8) NOT NULL,
	[Quantita] [int] NOT NULL,
	[Prezzo] [decimal](10, 2) NOT NULL,
	[Rarita] [varchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rarita](
	[Rarita] [varchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Rarita] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionalOutboxList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tabella] [varchar](256) NOT NULL,
	[Messaggio] [varchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[Username] [varchar](256) NOT NULL,
	[Id] [nvarchar](900) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Carte] ([Id], [Nome]) VALUES (N'1', N'drago')
INSERT [dbo].[Carte] ([Id], [Nome]) VALUES (N'2', N'magia')
INSERT [dbo].[Carte] ([Id], [Nome]) VALUES (N'3', N'mago')
GO
SET IDENTITY_INSERT [dbo].[Inserzioni] ON 

INSERT [dbo].[Inserzioni] ([Id], [Venditore], [Carta], [Quantita], [Prezzo], [Rarita]) VALUES (15, N'e91caddc-2b94-441b-a862-c51b1098b327', N'1', 10, CAST(10.00 AS Decimal(10, 2)), N'comune')
INSERT [dbo].[Inserzioni] ([Id], [Venditore], [Carta], [Quantita], [Prezzo], [Rarita]) VALUES (16, N'e91caddc-2b94-441b-a862-c51b1098b327', N'2', 10, CAST(10.00 AS Decimal(10, 2)), N'comune')
INSERT [dbo].[Inserzioni] ([Id], [Venditore], [Carta], [Quantita], [Prezzo], [Rarita]) VALUES (17, N'e91caddc-2b94-441b-a862-c51b1098b327', N'3', 10, CAST(10.00 AS Decimal(10, 2)), N'comune')
INSERT [dbo].[Inserzioni] ([Id], [Venditore], [Carta], [Quantita], [Prezzo], [Rarita]) VALUES (18, N'70d989f5-4f75-4365-94e5-3dd1f21e215d', N'1', 10, CAST(10.00 AS Decimal(10, 2)), N'rara')
INSERT [dbo].[Inserzioni] ([Id], [Venditore], [Carta], [Quantita], [Prezzo], [Rarita]) VALUES (19, N'70d989f5-4f75-4365-94e5-3dd1f21e215d', N'2', 10, CAST(10.00 AS Decimal(10, 2)), N'rara')
INSERT [dbo].[Inserzioni] ([Id], [Venditore], [Carta], [Quantita], [Prezzo], [Rarita]) VALUES (20, N'70d989f5-4f75-4365-94e5-3dd1f21e215d', N'3', 10, CAST(10.00 AS Decimal(10, 2)), N'rara')
INSERT [dbo].[Inserzioni] ([Id], [Venditore], [Carta], [Quantita], [Prezzo], [Rarita]) VALUES (21, N'c6ecd2e3-1a89-404a-9f74-aa9e2929d837', N'1', 10, CAST(10.00 AS Decimal(10, 2)), N'super')
INSERT [dbo].[Inserzioni] ([Id], [Venditore], [Carta], [Quantita], [Prezzo], [Rarita]) VALUES (22, N'c6ecd2e3-1a89-404a-9f74-aa9e2929d837', N'2', 10, CAST(10.00 AS Decimal(10, 2)), N'super')
INSERT [dbo].[Inserzioni] ([Id], [Venditore], [Carta], [Quantita], [Prezzo], [Rarita]) VALUES (23, N'c6ecd2e3-1a89-404a-9f74-aa9e2929d837', N'3', 10, CAST(10.00 AS Decimal(10, 2)), N'super')
SET IDENTITY_INSERT [dbo].[Inserzioni] OFF
GO
INSERT [dbo].[Rarita] ([Rarita]) VALUES (N'comune')
INSERT [dbo].[Rarita] ([Rarita]) VALUES (N'rara')
INSERT [dbo].[Rarita] ([Rarita]) VALUES (N'super')
GO
INSERT [dbo].[Utenti] ([Username], [Id]) VALUES (N'utente2@gmail.com', N'70d989f5-4f75-4365-94e5-3dd1f21e215d')
INSERT [dbo].[Utenti] ([Username], [Id]) VALUES (N'admin@gmail.com', N'a368c388-f792-41f9-a5a3-8558c074238f')
INSERT [dbo].[Utenti] ([Username], [Id]) VALUES (N'utente3@gmail.com', N'c6ecd2e3-1a89-404a-9f74-aa9e2929d837')
INSERT [dbo].[Utenti] ([Username], [Id]) VALUES (N'utente1@gmail.com', N'e91caddc-2b94-441b-a862-c51b1098b327')
GO
ALTER TABLE [dbo].[Inserzioni]  WITH CHECK ADD FOREIGN KEY([Carta])
REFERENCES [dbo].[Carte] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inserzioni]  WITH CHECK ADD FOREIGN KEY([Rarita])
REFERENCES [dbo].[Rarita] ([Rarita])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Inserzioni]  WITH CHECK ADD FOREIGN KEY([Venditore])
REFERENCES [dbo].[Utenti] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
