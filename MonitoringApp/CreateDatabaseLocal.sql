USE [master]
GO

/****** Object:  Database [monitoringAppDb]    Script Date: 5/14/2016 11:32:34 PM ******/
DROP DATABASE [monitoringAppDb]
GO

/****** Object:  Database [monitoringAppDb]    Script Date: 5/14/2016 11:32:34 PM ******/
CREATE DATABASE [monitoringAppDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'monitoringAppDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\monitoringAppDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'monitoringAppDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\monitoringAppDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [monitoringAppDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [monitoringAppDb] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [monitoringAppDb] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [monitoringAppDb] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [monitoringAppDb] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [monitoringAppDb] SET ARITHABORT OFF 
GO

ALTER DATABASE [monitoringAppDb] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [monitoringAppDb] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [monitoringAppDb] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [monitoringAppDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [monitoringAppDb] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [monitoringAppDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [monitoringAppDb] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [monitoringAppDb] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [monitoringAppDb] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [monitoringAppDb] SET  DISABLE_BROKER 
GO

ALTER DATABASE [monitoringAppDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [monitoringAppDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [monitoringAppDb] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [monitoringAppDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [monitoringAppDb] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [monitoringAppDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [monitoringAppDb] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [monitoringAppDb] SET RECOVERY FULL 
GO

ALTER DATABASE [monitoringAppDb] SET  MULTI_USER 
GO

ALTER DATABASE [monitoringAppDb] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [monitoringAppDb] SET DB_CHAINING OFF 
GO

ALTER DATABASE [monitoringAppDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [monitoringAppDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [monitoringAppDb] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [monitoringAppDb] SET  READ_WRITE 
GO




USE [monitoringAppDb]
GO

/****** Object:  Table [dbo].[SystemData]    Script Date: 5/14/2016 11:30:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SystemData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PackageNumber] [int] NULL,
	[SystemSerialNumber] [int] NULL,
	[ProviderName] [nvarchar](15) NULL,
	[IsSystemWorking] [bit] NULL,
	[MeasurementDateTime] [datetime] NULL,
	[VoltageAKB] [real] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

USE [monitoringAppDb]
GO

/****** Object:  Table [dbo].[Coordinates]    Script Date: 5/14/2016 11:27:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Coordinates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Latitude] [float] NULL,
	[Longtitude] [float] NULL,
	[RecordId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

ALTER TABLE [dbo].[Coordinates]  WITH CHECK ADD FOREIGN KEY([RecordId])
REFERENCES [dbo].[SystemData] ([Id])
ON DELETE CASCADE
GO


USE [monitoringAppDb]
GO

/****** Object:  Table [dbo].[FuelConsumptions]    Script Date: 5/14/2016 11:30:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FuelConsumptions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Heater1FuelConsumption] [real] NULL,
	[Heater2FuelConsumption] [real] NULL,
	[AirHeaterFuelConsumption] [real] NULL,
	[RecordId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

ALTER TABLE [dbo].[FuelConsumptions]  WITH CHECK ADD FOREIGN KEY([RecordId])
REFERENCES [dbo].[SystemData] ([Id])
ON DELETE CASCADE
GO



USE [monitoringAppDb]
GO

/****** Object:  Table [dbo].[Flags]    Script Date: 5/14/2016 11:29:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Flags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Heater1Flags] [int] NULL,
	[Heater2Flags] [int] NULL,
	[AirHeaterFlags] [int] NULL,
	[SystemFlags] [tinyint] NULL,
	[RecordId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

ALTER TABLE [dbo].[Flags]  WITH CHECK ADD FOREIGN KEY([RecordId])
REFERENCES [dbo].[SystemData] ([Id])
ON DELETE CASCADE
GO


USE [monitoringAppDb]
GO

/****** Object:  Table [dbo].[Temperatures]    Script Date: 5/14/2016 11:30:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Temperatures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EnvironmentTemperature] [real] NULL,
	[Radiator1Temperature] [real] NULL,
	[Radiator2Temperature] [real] NULL,
	[FootstepTemperature] [real] NULL,
	[TurbineTemperature] [real] NULL,
	[OilTemperature] [real] NULL,
	[TransformatorTemperature] [real] NULL,
	[CabinTemperature] [real] NULL,
	[RecordId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

ALTER TABLE [dbo].[Temperatures]  WITH CHECK ADD FOREIGN KEY([RecordId])
REFERENCES [dbo].[SystemData] ([Id])
ON DELETE CASCADE
GO


USE [monitoringAppDb]
GO

/****** Object:  Table [dbo].[TrainData]    Script Date: 5/14/2016 11:34:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TrainData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PackageNumber] [int] NULL,
	[SystemSerialNumber] [int] NULL,
	[ProviderName] [nvarchar](15) NULL,
	[IsSystemWorking] [bit] NULL,
	[MeasurementDateTime] [datetime] NULL,
	[EnvironmentTemperature] [real] NULL,
	[Radiator1Temperature] [real] NULL,
	[Radiator2Temperature] [real] NULL,
	[FootstepTemperature] [real] NULL,
	[TurbineTemperature] [real] NULL,
	[OilTemperature] [real] NULL,
	[TransformatorTemperature] [real] NULL,
	[CabinTemperature] [real] NULL,
	[VoltageAKB] [real] NULL,
	[Heater1FuelConsumption] [real] NULL,
	[Heater2FuelConsumption] [real] NULL,
	[AirHeaterFuelConsumption] [real] NULL,
	[Heater1Flags] [int] NULL,
	[Heater2Flags] [int] NULL,
	[AirHeaterFlags] [int] NULL,
	[SystemFlags] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO


