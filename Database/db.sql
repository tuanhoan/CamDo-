USE [master]
GO
/****** Object:  Database [CamDo]    Script Date: 5/9/2022 6:57:29 PM ******/
CREATE DATABASE [CamDo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CamDo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.DG\MSSQL\DATA\CamDo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CamDo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.DG\MSSQL\DATA\CamDo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CamDo] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CamDo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CamDo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CamDo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CamDo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CamDo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CamDo] SET ARITHABORT OFF 
GO
ALTER DATABASE [CamDo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CamDo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CamDo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CamDo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CamDo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CamDo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CamDo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CamDo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CamDo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CamDo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CamDo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CamDo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CamDo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CamDo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CamDo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CamDo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CamDo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CamDo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CamDo] SET  MULTI_USER 
GO
ALTER DATABASE [CamDo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CamDo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CamDo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CamDo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CamDo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CamDo] SET QUERY_STORE = OFF
GO
USE [CamDo]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [CamDo]
GO
/****** Object:  Table [dbo].[CauHinhHangHoa]    Script Date: 5/9/2022 6:57:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauHinhHangHoa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LinhVuc] [tinyint] NOT NULL,
	[MaTS] [nvarchar](128) NOT NULL,
	[Ten] [nvarchar](256) NOT NULL,
	[IsPublish] [bit] NOT NULL,
	[HinhThucLai] [tinyint] NOT NULL,
	[IsThuLaiTruoc] [bit] NOT NULL,
	[TongTien] [float] NULL,
	[LaiSuat] [float] NOT NULL,
	[KyLai] [int] NOT NULL,
	[TongThoiGianVay] [int] NOT NULL,
	[SoNgayQuaHan] [int] NOT NULL,
	[CuaHangId] [int] NULL,
	[ListThuocTinh] [nvarchar](max) NULL,
 CONSTRAINT [PK_CauHinhHangHoa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CuaHang]    Script Date: 5/9/2022 6:57:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CuaHang](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](256) NOT NULL,
	[SDT] [nvarchar](20) NOT NULL,
	[DiaChi] [nvarchar](256) NOT NULL,
	[TenNguoiDaiDien] [nvarchar](256) NULL,
	[VonDauTu] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedTime] [datetime] NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_CuaHang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HopDong]    Script Date: 5/9/2022 6:57:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HopDong](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KhachHangId] [int] NOT NULL,
	[HangHoaId] [int] NOT NULL,
	[HangHoa_Ten] [nvarchar](256) NOT NULL,
	[HD_Ma] [nvarchar](128) NOT NULL,
	[HD_TongTien] [float] NOT NULL,
	[HD_HinhThucLai] [tinyint] NOT NULL,
	[HD_IsThuLaiTruoc] [bit] NOT NULL,
	[HD_TongThoiGianVay] [int] NOT NULL,
	[HD_KyLai] [int] NOT NULL,
	[HD_LaiSuat] [float] NOT NULL,
	[HD_NgayVay] [datetime] NOT NULL,
	[HD_GhiChu] [nvarchar](max) NULL,
	[UserIdCreated] [nvarchar](128) NOT NULL,
	[UserIdAssigned] [nvarchar](128) NOT NULL,
	[HangHoa_ListThuocTinh] [nvarchar](max) NULL,
 CONSTRAINT [PK_HopDong] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 5/9/2022 6:57:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](256) NOT NULL,
	[NgaySinh] [datetime] NULL,
	[CMND] [nvarchar](20) NULL,
	[CMND_NgayCap] [datetime] NULL,
	[CMND_NoiCap] [nvarchar](256) NULL,
	[DiaChi] [nvarchar](256) NULL,
	[SDT] [nvarchar](20) NULL,
	[CuaHangId] [int] NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 5/9/2022 6:57:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[Id] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 5/9/2022 6:57:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [nvarchar](128) NOT NULL,
	[CustomId] [nvarchar](128) NOT NULL,
	[FullName] [nvarchar](256) NOT NULL,
	[JoinedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CauHinhHangHoa]  WITH CHECK ADD  CONSTRAINT [FK_CauHinhHangHoa_CuaHang] FOREIGN KEY([CuaHangId])
REFERENCES [dbo].[CuaHang] ([Id])
GO
ALTER TABLE [dbo].[CauHinhHangHoa] CHECK CONSTRAINT [FK_CauHinhHangHoa_CuaHang]
GO
ALTER TABLE [dbo].[CuaHang]  WITH CHECK ADD  CONSTRAINT [FK_CuaHang_UserProfile] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CuaHang] CHECK CONSTRAINT [FK_CuaHang_UserProfile]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_CuaHang] FOREIGN KEY([CuaHangId])
REFERENCES [dbo].[CuaHang] ([Id])
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK_KhachHang_CuaHang]
GO
USE [master]
GO
ALTER DATABASE [CamDo] SET  READ_WRITE 
GO
