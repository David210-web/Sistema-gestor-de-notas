USE [master]
GO
/****** Object:  Database [UniversidadNovusVita]    Script Date: 10/06/2024 08:16:04 p. m. ******/
CREATE DATABASE [UniversidadNovusVita]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversidadNovusVita', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\UniversidadNovusVita.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UniversidadNovusVita_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\UniversidadNovusVita_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [UniversidadNovusVita] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversidadNovusVita].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversidadNovusVita] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [UniversidadNovusVita] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversidadNovusVita] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversidadNovusVita] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET  ENABLE_BROKER 
GO
ALTER DATABASE [UniversidadNovusVita] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversidadNovusVita] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversidadNovusVita] SET  MULTI_USER 
GO
ALTER DATABASE [UniversidadNovusVita] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversidadNovusVita] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversidadNovusVita] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversidadNovusVita] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UniversidadNovusVita] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UniversidadNovusVita] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [UniversidadNovusVita] SET QUERY_STORE = ON
GO
ALTER DATABASE [UniversidadNovusVita] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [UniversidadNovusVita]
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 10/06/2024 08:16:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[carnet] [varchar](12) NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[genero] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[carnet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 10/06/2024 08:16:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[codigocurso] [varchar](5) NOT NULL,
	[carnetdocente] [varchar](12) NOT NULL,
	[materia] [varchar](5) NOT NULL,
	[seccion] [int] NOT NULL,
	[hora] [varchar](20) NOT NULL,
	[cantidadestudiante] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[codigocurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 10/06/2024 08:16:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[codigomateria] [varchar](5) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[codigomateria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matricula]    Script Date: 10/06/2024 08:16:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matricula](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[alumno] [varchar](12) NOT NULL,
	[curso] [varchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notas]    Script Date: 10/06/2024 08:16:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[alumno] [varchar](12) NOT NULL,
	[materia] [varchar](5) NOT NULL,
	[notaN1] [decimal](10, 2) NOT NULL,
	[notaN2] [decimal](10, 2) NOT NULL,
	[notaN3] [decimal](10, 2) NOT NULL,
	[notapromeido]  AS ((([notaN1]+[notaN2])+[notaN3])/(3.0)) PERSISTED,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesores]    Script Date: 10/06/2024 08:16:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesores](
	[carnet] [varchar](12) NOT NULL,
	[nombres] [varchar](50) NOT NULL,
	[apellidos] [varchar](50) NOT NULL,
	[tipodocente] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[carnet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/06/2024 08:16:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[carnet] [varchar](12) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[rol] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[carnet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD FOREIGN KEY([carnetdocente])
REFERENCES [dbo].[Profesores] ([carnet])
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD FOREIGN KEY([materia])
REFERENCES [dbo].[Materia] ([codigomateria])
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD FOREIGN KEY([alumno])
REFERENCES [dbo].[Alumnos] ([carnet])
GO
ALTER TABLE [dbo].[Matricula]  WITH CHECK ADD FOREIGN KEY([curso])
REFERENCES [dbo].[Curso] ([codigocurso])
GO
ALTER TABLE [dbo].[Notas]  WITH CHECK ADD FOREIGN KEY([alumno])
REFERENCES [dbo].[Alumnos] ([carnet])
GO
ALTER TABLE [dbo].[Notas]  WITH CHECK ADD FOREIGN KEY([materia])
REFERENCES [dbo].[Materia] ([codigomateria])
GO
ALTER TABLE [dbo].[Alumnos]  WITH CHECK ADD  CONSTRAINT [CHK_Genero] CHECK  (([genero]='Femenino' OR [genero]='Masculino'))
GO
ALTER TABLE [dbo].[Alumnos] CHECK CONSTRAINT [CHK_Genero]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRol]    Script Date: 10/06/2024 08:16:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetRol]
	@carnet varchar(12)
AS
BEGIN
	IF(EXISTS (SELECT * FROM Usuarios where carnet = @carnet ))
		SELECT rol FROM Usuarios where carnet= @carnet
	ELSE
		SELECT '0'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_verificarCuenta]    Script Date: 10/06/2024 08:16:04 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_verificarCuenta]
@carnet varchar(50),
@pass varchar(50)
AS
BEGIN
	IF(EXISTS(SELECT * from Usuarios where carnet = @carnet and password = @pass))
		SELECT '1'
	ELSE
		SELECT '0'
END
GO
USE [master]
GO
ALTER DATABASE [UniversidadNovusVita] SET  READ_WRITE 
GO
