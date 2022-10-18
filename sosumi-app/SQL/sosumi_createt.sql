USE [master]
GO
/****** Object:  Database [SoSuMiDatabase]    Script Date: 10/17/2022 4:41:40 PM ******/
CREATE DATABASE [SoSuMiDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SoSuMiDatabase', FILENAME = N'C:\Users\Chris\SoSuMiDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SoSuMiDatabase_log', FILENAME = N'C:\Users\Chris\SoSuMiDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SoSuMiDatabase] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SoSuMiDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SoSuMiDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SoSuMiDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SoSuMiDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SoSuMiDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SoSuMiDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SoSuMiDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [SoSuMiDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SoSuMiDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SoSuMiDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SoSuMiDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SoSuMiDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SoSuMiDatabase] SET QUERY_STORE = OFF
GO
USE [SoSuMiDatabase]
GO
/****** Object:  Table [dbo].[favorite]    Script Date: 10/17/2022 4:41:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[favorite](
	[userId] [int] NULL,
	[foodId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[item]    Script Date: 10/17/2022 4:41:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[item](
	[id] [int] NOT NULL,
	[name] [varchar](50) NULL,
	[price] [float] NULL,
	[special] [bit] NULL,
	[type] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 10/17/2022 4:41:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[orderId] [int] NOT NULL,
	[userId] [int] NULL,
	[lineItems] [int] NULL,
	[date] [datetime] NULL,
	[dineIn] [bit] NULL,
	[paid] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orderItem]    Script Date: 10/17/2022 4:41:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orderItem](
	[orderId] [int] NULL,
	[itemId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sosumi-datasheet]    Script Date: 10/17/2022 4:41:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sosumi-datasheet](
	[id] [tinyint] NOT NULL,
	[name] [nvarchar](50) NULL,
	[price] [float] NULL,
	[special] [bit] NULL,
	[type] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 10/17/2022 4:41:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] NOT NULL,
	[firstName] [varchar](30) NULL,
	[lastName] [varchar](30) NULL,
	[email] [varchar](30) NULL,
	[password] [varchar](30) NULL,
	[firstTime] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[favorite]  WITH CHECK ADD FOREIGN KEY([foodId])
REFERENCES [dbo].[item] ([id])
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[orderItem]  WITH CHECK ADD FOREIGN KEY([itemId])
REFERENCES [dbo].[item] ([id])
GO
ALTER TABLE [dbo].[orderItem]  WITH CHECK ADD FOREIGN KEY([orderId])
REFERENCES [dbo].[order] ([orderId])
GO
USE [master]
GO
ALTER DATABASE [SoSuMiDatabase] SET  READ_WRITE 
GO
