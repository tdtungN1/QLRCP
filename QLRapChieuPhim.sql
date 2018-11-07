USE [master]
GO
/****** Object:  Database [QLRapChieuPhim]    Script Date: 11/7/2018 9:11:29 PM ******/
CREATE DATABASE [QLRapChieuPhim]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLRapChieuPhim', FILENAME = N'D:\SQL\QLRapChieuPhim.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLRapChieuPhim_log', FILENAME = N'D:\SQL\QLRapChieuPhim_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QLRapChieuPhim] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLRapChieuPhim].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLRapChieuPhim] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLRapChieuPhim] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLRapChieuPhim] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLRapChieuPhim] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLRapChieuPhim] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLRapChieuPhim] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLRapChieuPhim] SET  MULTI_USER 
GO
ALTER DATABASE [QLRapChieuPhim] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLRapChieuPhim] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLRapChieuPhim] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLRapChieuPhim] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLRapChieuPhim] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLRapChieuPhim] SET QUERY_STORE = OFF
GO
USE [QLRapChieuPhim]
GO
/****** Object:  Table [dbo].[Chair]    Script Date: 11/7/2018 9:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chair](
	[ChairID] [varchar](5) NOT NULL,
	[ChairName] [nvarchar](10) NOT NULL,
	[RoomID] [varchar](5) NOT NULL,
	[GenreChairID] [varchar](5) NOT NULL,
 CONSTRAINT [PK_Chair] PRIMARY KEY CLUSTERED 
(
	[ChairID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/7/2018 9:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [varchar](5) NOT NULL,
	[CustomerName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[Phone] [varchar](12) NULL,
	[Birthday] [date] NULL,
	[UserID] [varchar](5) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Film]    Script Date: 11/7/2018 9:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Film](
	[FilmID] [varchar](5) NOT NULL,
	[FilmName] [nvarchar](50) NOT NULL,
	[Author] [nvarchar](50) NULL,
	[Producer] [nvarchar](30) NULL,
	[ReleaseDate] [date] NULL,
	[Nation] [nvarchar](30) NULL,
	[Description] [text] NULL,
	[Rated] [float] NULL,
	[Actor] [nvarchar](200) NULL,
 CONSTRAINT [PK__Film__1D109F4D69A10D0B] PRIMARY KEY CLUSTERED 
(
	[FilmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Film_GenreFilm]    Script Date: 11/7/2018 9:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Film_GenreFilm](
	[ID] [varchar](5) NOT NULL,
	[FilmID] [varchar](5) NOT NULL,
	[GenreFilmID] [varchar](5) NOT NULL,
 CONSTRAINT [PK_Film_GenreFilm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre_chair]    Script Date: 11/7/2018 9:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre_chair](
	[GenreChairID] [varchar](5) NOT NULL,
	[GenreChairName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Genre_chair] PRIMARY KEY CLUSTERED 
(
	[GenreChairID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre_film]    Script Date: 11/7/2018 9:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre_film](
	[GenreFilmID] [varchar](5) NOT NULL,
	[GenreFilmName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK__Genre_fi__C8EE3E34592117DC] PRIMARY KEY CLUSTERED 
(
	[GenreFilmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre_room]    Script Date: 11/7/2018 9:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre_room](
	[GenreRoomID] [varchar](5) NOT NULL,
	[GenreRoomName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK__Genre_ro__C8EE3E347E7D5EFF] PRIMARY KEY CLUSTERED 
(
	[GenreRoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projection_room]    Script Date: 11/7/2018 9:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projection_room](
	[RoomID] [varchar](5) NOT NULL,
	[RoomName] [nvarchar](20) NOT NULL,
	[GenreRoomID] [varchar](5) NOT NULL,
	[StatusRoom] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK__Projecti__45DC5D2BE6AFCF6E] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 11/7/2018 9:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[TicketID] [varchar](5) NOT NULL,
	[ChairID] [varchar](5) NOT NULL,
	[FilmID] [varchar](5) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[Price] [bigint] NOT NULL,
	[UserID] [varchar](5) NOT NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[TicketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/7/2018 9:11:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [varchar](5) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](32) NOT NULL,
	[email] [varchar](100) NULL,
	[groups] [tinyint] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Chair]  WITH CHECK ADD  CONSTRAINT [FK_Chair_Genre_chair] FOREIGN KEY([GenreChairID])
REFERENCES [dbo].[Genre_chair] ([GenreChairID])
GO
ALTER TABLE [dbo].[Chair] CHECK CONSTRAINT [FK_Chair_Genre_chair]
GO
ALTER TABLE [dbo].[Chair]  WITH CHECK ADD  CONSTRAINT [FK_Chair_Projection_room] FOREIGN KEY([RoomID])
REFERENCES [dbo].[Projection_room] ([RoomID])
GO
ALTER TABLE [dbo].[Chair] CHECK CONSTRAINT [FK_Chair_Projection_room]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_Users]
GO
ALTER TABLE [dbo].[Film_GenreFilm]  WITH CHECK ADD  CONSTRAINT [FK_Film_GenreFilm_Film] FOREIGN KEY([FilmID])
REFERENCES [dbo].[Film] ([FilmID])
GO
ALTER TABLE [dbo].[Film_GenreFilm] CHECK CONSTRAINT [FK_Film_GenreFilm_Film]
GO
ALTER TABLE [dbo].[Film_GenreFilm]  WITH CHECK ADD  CONSTRAINT [FK_Film_GenreFilm_Genre_film] FOREIGN KEY([GenreFilmID])
REFERENCES [dbo].[Genre_film] ([GenreFilmID])
GO
ALTER TABLE [dbo].[Film_GenreFilm] CHECK CONSTRAINT [FK_Film_GenreFilm_Genre_film]
GO
ALTER TABLE [dbo].[Projection_room]  WITH CHECK ADD  CONSTRAINT [FK__Projectio__ID_ge__5070F446] FOREIGN KEY([GenreRoomID])
REFERENCES [dbo].[Genre_room] ([GenreRoomID])
GO
ALTER TABLE [dbo].[Projection_room] CHECK CONSTRAINT [FK__Projectio__ID_ge__5070F446]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Chair] FOREIGN KEY([ChairID])
REFERENCES [dbo].[Chair] ([ChairID])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Chair]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Film] FOREIGN KEY([FilmID])
REFERENCES [dbo].[Film] ([FilmID])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Film]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Users]
GO
USE [master]
GO
ALTER DATABASE [QLRapChieuPhim] SET  READ_WRITE 
GO
