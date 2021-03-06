USE [master]
GO
/****** Object:  Database [MBaza]    Script Date: 13.06.2021 11:19:17 ******/
CREATE DATABASE [MBaza]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MBaza', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MBaza.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MBaza_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MBaza_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MBaza] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MBaza].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MBaza] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MBaza] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MBaza] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MBaza] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MBaza] SET ARITHABORT OFF 
GO
ALTER DATABASE [MBaza] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MBaza] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MBaza] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MBaza] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MBaza] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MBaza] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MBaza] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MBaza] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MBaza] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MBaza] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MBaza] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MBaza] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MBaza] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MBaza] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MBaza] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MBaza] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MBaza] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MBaza] SET RECOVERY FULL 
GO
ALTER DATABASE [MBaza] SET  MULTI_USER 
GO
ALTER DATABASE [MBaza] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MBaza] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MBaza] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MBaza] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MBaza] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MBaza] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MBaza', N'ON'
GO
ALTER DATABASE [MBaza] SET QUERY_STORE = OFF
GO
USE [MBaza]
GO
/****** Object:  Schema [dane]    Script Date: 13.06.2021 11:19:17 ******/
CREATE SCHEMA [dane]
GO
/****** Object:  Schema [danee]    Script Date: 13.06.2021 11:19:17 ******/
CREATE SCHEMA [danee]
GO
/****** Object:  Schema [Sprzedaz]    Script Date: 13.06.2021 11:19:17 ******/
CREATE SCHEMA [Sprzedaz]
GO
/****** Object:  Schema [SprzedazGO]    Script Date: 13.06.2021 11:19:17 ******/
CREATE SCHEMA [SprzedazGO]
GO
/****** Object:  Table [dane].[ObszarZagrozony]    Script Date: 13.06.2021 11:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[ObszarZagrozony](
	[Data] [date] NOT NULL,
	[Miasto] [varchar](20) NOT NULL,
	[SluzbaRatunkowa] [varchar](40) NOT NULL,
	[NazwaRzeki] [varchar](20) NOT NULL,
	[Miejscowosc] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Miejscowosc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[widok]    Script Date: 13.06.2021 11:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[widok] AS
SELECT * FROM dane.ObszarZagrozony;
GO
/****** Object:  Table [dane].[PomiarRzeki]    Script Date: 13.06.2021 11:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[PomiarRzeki](
	[PoziomWody] [float] NOT NULL,
	[DataPomiaru] [date] NOT NULL,
	[StandardowyPoziom] [float] NOT NULL,
	[NazwaRzeki] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NazwaRzeki] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[PomiarMiejscowosc]    Script Date: 13.06.2021 11:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[PomiarMiejscowosc] AS
SELECT Data,Ob.NazwaRzeki,Miasto,SluzbaRatunkowa,Miejscowosc,PoziomWody,DataPomiaru,StandardowyPoziom
FROM dane.ObszarZagrozony Ob INNER JOIN dane.PomiarRzeki  Pr ON Ob.NazwaRzeki = Pr.NazwaRzeki;
GO
/****** Object:  Table [dane].[IMGWOgolneDane]    Script Date: 13.06.2021 11:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[IMGWOgolneDane](
	[Data] [date] NOT NULL,
	[IloscOpadow] [float] NOT NULL,
	[PoziomWod] [float] NOT NULL,
	[Temperatura] [float] NOT NULL,
	[Miasto] [varchar](20) NOT NULL,
	[IMGWStanZagrozenia] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IMGWStanZagrozenia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dane].[ObszaryZalewowe]    Script Date: 13.06.2021 11:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[ObszaryZalewowe](
	[NazwaRzeki] [varchar](20) NOT NULL,
	[Miasto] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NazwaRzeki] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dane].[OstrzeganieInstytucji]    Script Date: 13.06.2021 11:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[OstrzeganieInstytucji](
	[SluzbaRatunkowa] [varchar](40) NOT NULL,
	[StanZagrozenia] [varchar](10) NOT NULL,
	[Data] [date] NOT NULL,
	[MiastoOrganizacji] [varchar](20) NOT NULL,
	[MiejscowoscOrganizacji] [varchar](20) NOT NULL,
	[MiejscowoscZagrozona] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MiejscowoscOrganizacji] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dane].[PowiadomienieSMS]    Script Date: 13.06.2021 11:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[PowiadomienieSMS](
	[NumerTelefonu] [varchar](15) NOT NULL,
	[StanZagrozenia] [varchar](10) NOT NULL,
	[Miasto] [varchar](20) NOT NULL,
	[Data] [date] NOT NULL,
	[Miejscowosc] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NumerTelefonu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dane].[PowodzieHistoryczne]    Script Date: 13.06.2021 11:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[PowodzieHistoryczne](
	[Miasto] [varchar](20) NOT NULL,
	[IloscDniDeszczowych] [int] NOT NULL,
	[DataPowodzi] [date] NOT NULL,
	[Miejscowosc] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Miejscowosc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dane].[PrognozaPogody]    Script Date: 13.06.2021 11:19:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dane].[PrognozaPogody](
	[Data] [date] NOT NULL,
	[IloscOpadow] [float] NOT NULL,
	[RodzajPogody] [varchar](10) NOT NULL,
	[Miasto] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
INSERT [dane].[ObszarZagrozony] ([Data], [Miasto], [SluzbaRatunkowa], [NazwaRzeki], [Miejscowosc]) VALUES (CAST(N'2021-09-05' AS Date), N'Zywiec', N'PolicjaStrazPozarnaSzpital', N'Koszarawa', N'Jelesnia')
INSERT [dane].[ObszarZagrozony] ([Data], [Miasto], [SluzbaRatunkowa], [NazwaRzeki], [Miejscowosc]) VALUES (CAST(N'2021-09-05' AS Date), N'Zywiec', N'PolicjaStrazPozarnaSzpital', N'Koszarawa', N'Przyborow')
INSERT [dane].[ObszarZagrozony] ([Data], [Miasto], [SluzbaRatunkowa], [NazwaRzeki], [Miejscowosc]) VALUES (CAST(N'2021-05-19' AS Date), N'Żywiec', N'PolicjaStrazPozarnaSzpital', N'Sopotnia Wielka', N'Sopotnia Wielka')
INSERT [dane].[ObszarZagrozony] ([Data], [Miasto], [SluzbaRatunkowa], [NazwaRzeki], [Miejscowosc]) VALUES (CAST(N'2021-05-21' AS Date), N'Warszawa', N'PolicjaStrazPozarnaSzpital', N'Wisla', N'Warszawa')
GO
INSERT [dane].[OstrzeganieInstytucji] ([SluzbaRatunkowa], [StanZagrozenia], [Data], [MiastoOrganizacji], [MiejscowoscOrganizacji], [MiejscowoscZagrozona]) VALUES (N'Policja,StrazPozarna', N'Powodziowe', CAST(N'2021-08-05' AS Date), N'Zywiec', N'Jelesnia', N'Jelesnia')
INSERT [dane].[OstrzeganieInstytucji] ([SluzbaRatunkowa], [StanZagrozenia], [Data], [MiastoOrganizacji], [MiejscowoscOrganizacji], [MiejscowoscZagrozona]) VALUES (N'Policja,StrazPozarna,Szpital', N'Powodziowe', CAST(N'2021-08-05' AS Date), N'Zywiec', N'Zywiec', N'Jelesnia')
GO
INSERT [dane].[PomiarRzeki] ([PoziomWody], [DataPomiaru], [StandardowyPoziom], [NazwaRzeki]) VALUES (3, CAST(N'2021-08-06' AS Date), 2, N'Jelesianka')
INSERT [dane].[PomiarRzeki] ([PoziomWody], [DataPomiaru], [StandardowyPoziom], [NazwaRzeki]) VALUES (2, CAST(N'2021-08-06' AS Date), 2, N'Koszarawa')
INSERT [dane].[PomiarRzeki] ([PoziomWody], [DataPomiaru], [StandardowyPoziom], [NazwaRzeki]) VALUES (2.5, CAST(N'2021-05-19' AS Date), 2, N'Sopotnia Wielka')
INSERT [dane].[PomiarRzeki] ([PoziomWody], [DataPomiaru], [StandardowyPoziom], [NazwaRzeki]) VALUES (5.5, CAST(N'2021-05-21' AS Date), 3, N'Wisla')
GO
INSERT [dane].[PowiadomienieSMS] ([NumerTelefonu], [StanZagrozenia], [Miasto], [Data], [Miejscowosc]) VALUES (N'512516223', N'Powodziowe', N'Zywiec', CAST(N'2021-08-05' AS Date), N'Jelesnia')
INSERT [dane].[PowiadomienieSMS] ([NumerTelefonu], [StanZagrozenia], [Miasto], [Data], [Miejscowosc]) VALUES (N'737586223', N'Powodziowe', N'Zywiec', CAST(N'2021-08-05' AS Date), N'Jelesnia')
GO
INSERT [dane].[PrognozaPogody] ([Data], [IloscOpadow], [RodzajPogody], [Miasto]) VALUES (CAST(N'2021-06-05' AS Date), 3, N'Deszcz', N'Bielsko')
INSERT [dane].[PrognozaPogody] ([Data], [IloscOpadow], [RodzajPogody], [Miasto]) VALUES (CAST(N'2021-06-05' AS Date), 3, N'Deszcz', N'Zywiec')
INSERT [dane].[PrognozaPogody] ([Data], [IloscOpadow], [RodzajPogody], [Miasto]) VALUES (CAST(N'2021-09-05' AS Date), 5, N'Deszcz', N'Zywiec')
GO
ALTER TABLE [dane].[ObszarZagrozony]  WITH CHECK ADD  CONSTRAINT [NazwaRzeki] FOREIGN KEY([NazwaRzeki])
REFERENCES [dane].[PomiarRzeki] ([NazwaRzeki])
GO
ALTER TABLE [dane].[ObszarZagrozony] CHECK CONSTRAINT [NazwaRzeki]
GO
ALTER TABLE [dane].[OstrzeganieInstytucji]  WITH CHECK ADD  CONSTRAINT [Miejscowosc] FOREIGN KEY([MiejscowoscZagrozona])
REFERENCES [dane].[ObszarZagrozony] ([Miejscowosc])
GO
ALTER TABLE [dane].[OstrzeganieInstytucji] CHECK CONSTRAINT [Miejscowosc]
GO
ALTER TABLE [dane].[PowiadomienieSMS]  WITH CHECK ADD  CONSTRAINT [Miejscowosc2] FOREIGN KEY([Miejscowosc])
REFERENCES [dane].[ObszarZagrozony] ([Miejscowosc])
GO
ALTER TABLE [dane].[PowiadomienieSMS] CHECK CONSTRAINT [Miejscowosc2]
GO
USE [master]
GO
ALTER DATABASE [MBaza] SET  READ_WRITE 
GO
