USE [master]
GO

/****** Object:  Database [monitoringAppDb]    Script Date: 5/14/2016 11:32:34 PM ******/
DROP DATABASE [trainsmonitorDb]
GO

/****** Object:  Database [monitoringAppDb]    Script Date: 5/14/2016 11:32:34 PM ******/
CREATE DATABASE [trainsmonitorDb]

USE [trainsmonitorDb]
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
	[Latitude] [float] NULL,
	[Longtitude] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO


