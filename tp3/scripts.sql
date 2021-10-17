USE [master]
GO

/****** Object:  Database [ecommerce-plataforma]    Script Date: 17/10/2021 12:35:14 ******/
CREATE DATABASE [ecommerce-plataforma]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ecommerce-plataforma', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ecommerce-plataforma.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ecommerce-plataforma_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ecommerce-plataforma_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ecommerce-plataforma].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [ecommerce-plataforma] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET ARITHABORT OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [ecommerce-plataforma] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [ecommerce-plataforma] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET  DISABLE_BROKER 
GO

ALTER DATABASE [ecommerce-plataforma] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [ecommerce-plataforma] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [ecommerce-plataforma] SET  MULTI_USER 
GO

ALTER DATABASE [ecommerce-plataforma] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [ecommerce-plataforma] SET DB_CHAINING OFF 
GO

ALTER DATABASE [ecommerce-plataforma] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [ecommerce-plataforma] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [ecommerce-plataforma] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [ecommerce-plataforma] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [ecommerce-plataforma] SET QUERY_STORE = OFF
GO

ALTER DATABASE [ecommerce-plataforma] SET  READ_WRITE 
GO


