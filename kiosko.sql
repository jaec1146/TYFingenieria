USE [master]
GO

/****** Object:  Database [kiosko]    Script Date: 19/07/2019 12:57:48 p. m. ******/
CREATE DATABASE [kiosko]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'kiosko', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\kiosko.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB ),
( NAME = N'id', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\id.ndf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'kiosko_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\kiosko_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [kiosko].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [kiosko] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [kiosko] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [kiosko] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [kiosko] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [kiosko] SET ARITHABORT OFF 
GO

ALTER DATABASE [kiosko] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [kiosko] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [kiosko] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [kiosko] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [kiosko] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [kiosko] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [kiosko] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [kiosko] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [kiosko] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [kiosko] SET  DISABLE_BROKER 
GO

ALTER DATABASE [kiosko] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [kiosko] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [kiosko] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [kiosko] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [kiosko] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [kiosko] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [kiosko] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [kiosko] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [kiosko] SET  MULTI_USER 
GO

ALTER DATABASE [kiosko] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [kiosko] SET DB_CHAINING OFF 
GO

ALTER DATABASE [kiosko] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [kiosko] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [kiosko] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [kiosko] SET QUERY_STORE = OFF
GO

ALTER DATABASE [kiosko] SET  READ_WRITE 
GO
