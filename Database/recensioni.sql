CREATE DATABASE Recensioni;
GO
USE [Recensioni]
GO
/****** Object:  Table [dbo].[Annunci]    Script Date: 13/05/2024 22:21:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Annunci](
	[Venditore] [nvarchar](900) NOT NULL,
	[Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pagamenti]    Script Date: 13/05/2024 22:21:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pagamenti](
	[Annuncio] [int] NOT NULL,
	[Compratore] [nvarchar](900) NOT NULL,
	[Id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recensione]    Script Date: 13/05/2024 22:21:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recensione](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Testo] [varchar](999) NOT NULL,
	[Voto] [int] NOT NULL,
	[Pagamento] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utente]    Script Date: 13/05/2024 22:21:44 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utente](
	[Id] [nvarchar](900) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Annunci] ([Venditore], [Id]) VALUES (N'e91caddc-2b94-441b-a862-c51b1098b327', 15)
INSERT [dbo].[Annunci] ([Venditore], [Id]) VALUES (N'e91caddc-2b94-441b-a862-c51b1098b327', 16)
INSERT [dbo].[Annunci] ([Venditore], [Id]) VALUES (N'e91caddc-2b94-441b-a862-c51b1098b327', 17)
INSERT [dbo].[Annunci] ([Venditore], [Id]) VALUES (N'70d989f5-4f75-4365-94e5-3dd1f21e215d', 18)
INSERT [dbo].[Annunci] ([Venditore], [Id]) VALUES (N'70d989f5-4f75-4365-94e5-3dd1f21e215d', 19)
INSERT [dbo].[Annunci] ([Venditore], [Id]) VALUES (N'70d989f5-4f75-4365-94e5-3dd1f21e215d', 20)
INSERT [dbo].[Annunci] ([Venditore], [Id]) VALUES (N'c6ecd2e3-1a89-404a-9f74-aa9e2929d837', 21)
INSERT [dbo].[Annunci] ([Venditore], [Id]) VALUES (N'c6ecd2e3-1a89-404a-9f74-aa9e2929d837', 22)
INSERT [dbo].[Annunci] ([Venditore], [Id]) VALUES (N'c6ecd2e3-1a89-404a-9f74-aa9e2929d837', 23)
GO
INSERT [dbo].[Pagamenti] ([Annuncio], [Compratore], [Id]) VALUES (15, N'a368c388-f792-41f9-a5a3-8558c074238f', 14)
INSERT [dbo].[Pagamenti] ([Annuncio], [Compratore], [Id]) VALUES (16, N'a368c388-f792-41f9-a5a3-8558c074238f', 15)
INSERT [dbo].[Pagamenti] ([Annuncio], [Compratore], [Id]) VALUES (17, N'a368c388-f792-41f9-a5a3-8558c074238f', 16)
INSERT [dbo].[Pagamenti] ([Annuncio], [Compratore], [Id]) VALUES (18, N'e91caddc-2b94-441b-a862-c51b1098b327', 17)
INSERT [dbo].[Pagamenti] ([Annuncio], [Compratore], [Id]) VALUES (19, N'e91caddc-2b94-441b-a862-c51b1098b327', 18)
INSERT [dbo].[Pagamenti] ([Annuncio], [Compratore], [Id]) VALUES (20, N'e91caddc-2b94-441b-a862-c51b1098b327', 19)
INSERT [dbo].[Pagamenti] ([Annuncio], [Compratore], [Id]) VALUES (21, N'70d989f5-4f75-4365-94e5-3dd1f21e215d', 20)
INSERT [dbo].[Pagamenti] ([Annuncio], [Compratore], [Id]) VALUES (22, N'70d989f5-4f75-4365-94e5-3dd1f21e215d', 21)
INSERT [dbo].[Pagamenti] ([Annuncio], [Compratore], [Id]) VALUES (23, N'70d989f5-4f75-4365-94e5-3dd1f21e215d', 22)
GO
SET IDENTITY_INSERT [dbo].[Recensione] ON 

INSERT [dbo].[Recensione] ([Id], [Testo], [Voto], [Pagamento]) VALUES (18, N'molto bene', 5, 14)
INSERT [dbo].[Recensione] ([Id], [Testo], [Voto], [Pagamento]) VALUES (19, N'molto bene', 3, 15)
INSERT [dbo].[Recensione] ([Id], [Testo], [Voto], [Pagamento]) VALUES (20, N'benino', 5, 22)
INSERT [dbo].[Recensione] ([Id], [Testo], [Voto], [Pagamento]) VALUES (21, N'malissimo', 1, 16)
SET IDENTITY_INSERT [dbo].[Recensione] OFF
GO
INSERT [dbo].[Utente] ([Id]) VALUES (N'70d989f5-4f75-4365-94e5-3dd1f21e215d')
INSERT [dbo].[Utente] ([Id]) VALUES (N'a368c388-f792-41f9-a5a3-8558c074238f')
INSERT [dbo].[Utente] ([Id]) VALUES (N'c6ecd2e3-1a89-404a-9f74-aa9e2929d837')
INSERT [dbo].[Utente] ([Id]) VALUES (N'e91caddc-2b94-441b-a862-c51b1098b327')
GO
ALTER TABLE [dbo].[Annunci]  WITH CHECK ADD FOREIGN KEY([Venditore])
REFERENCES [dbo].[Utente] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Pagamenti]  WITH CHECK ADD FOREIGN KEY([Annuncio])
REFERENCES [dbo].[Annunci] ([Id])
GO
ALTER TABLE [dbo].[Pagamenti]  WITH CHECK ADD FOREIGN KEY([Compratore])
REFERENCES [dbo].[Utente] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Recensione]  WITH CHECK ADD FOREIGN KEY([Pagamento])
REFERENCES [dbo].[Pagamenti] ([Id])
GO
