USE [master]
GO
/****** Object:  Database [BooksApp]    Script Date: 9/4/2020 12:39:53 PM ******/
CREATE DATABASE [BooksApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BooksApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BooksApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BooksApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BooksApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BooksApp] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BooksApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BooksApp] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BooksApp] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BooksApp] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BooksApp] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BooksApp] SET ARITHABORT OFF 
GO
ALTER DATABASE [BooksApp] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BooksApp] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BooksApp] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BooksApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BooksApp] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BooksApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BooksApp] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BooksApp] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BooksApp] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BooksApp] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BooksApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BooksApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BooksApp] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BooksApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BooksApp] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BooksApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BooksApp] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BooksApp] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BooksApp] SET  MULTI_USER 
GO
ALTER DATABASE [BooksApp] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BooksApp] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BooksApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BooksApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BooksApp] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BooksApp] SET QUERY_STORE = OFF
GO
USE [BooksApp]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/4/2020 12:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 9/4/2020 12:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorId] [int] IDENTITY(1,1) NOT NULL,
	[AuthorName] [nvarchar](max) NULL,
	[AuthorBio] [nvarchar](max) NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 9/4/2020 12:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[PublishDate] [datetime2](7) NOT NULL,
	[ReviewDate] [datetime2](7) NOT NULL,
	[Review] [nvarchar](max) NULL,
	[GenreId] [int] NOT NULL,
	[isFamous] [bit] NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BooksAuthors]    Script Date: 9/4/2020 12:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BooksAuthors](
	[BookAuthorid] [int] IDENTITY(1,1) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
 CONSTRAINT [PK_BooksAuthors] PRIMARY KEY CLUSTERED 
(
	[BookAuthorid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 9/4/2020 12:39:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[Genre] [nvarchar](max) NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200901061824_InitialCreate', N'3.1.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200901070124_UpdatedBooksFields', N'3.1.7')
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorBio]) VALUES (1, N'robin sharma', N'young boy')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorBio]) VALUES (2, N'gaurav bhatia', N'innocent boy')
INSERT [dbo].[Authors] ([AuthorId], [AuthorName], [AuthorBio]) VALUES (3, N'milad katebi', N'it professional')
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookId], [Title], [PublishDate], [ReviewDate], [Review], [GenreId], [isFamous]) VALUES (1, N'3 times', CAST(N'2007-07-08T02:22:00.0000000' AS DateTime2), CAST(N'2007-07-08T02:22:00.0000000' AS DateTime2), NULL, 2, 0)
INSERT [dbo].[Books] ([BookId], [Title], [PublishDate], [ReviewDate], [Review], [GenreId], [isFamous]) VALUES (2, N'last night', CAST(N'2005-08-12T05:55:00.0000000' AS DateTime2), CAST(N'2006-08-12T05:44:00.0000000' AS DateTime2), N'interstng', 1, 0)
INSERT [dbo].[Books] ([BookId], [Title], [PublishDate], [ReviewDate], [Review], [GenreId], [isFamous]) VALUES (3, N'2 states', CAST(N'2010-12-03T04:55:00.0000000' AS DateTime2), CAST(N'2010-12-03T04:55:00.0000000' AS DateTime2), N'nice', 3, 0)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[BooksAuthors] ON 

INSERT [dbo].[BooksAuthors] ([BookAuthorid], [AuthorId], [BookId]) VALUES (1, 1, 1)
INSERT [dbo].[BooksAuthors] ([BookAuthorid], [AuthorId], [BookId]) VALUES (2, 2, 2)
INSERT [dbo].[BooksAuthors] ([BookAuthorid], [AuthorId], [BookId]) VALUES (3, 3, 3)
SET IDENTITY_INSERT [dbo].[BooksAuthors] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([GenreId], [Genre]) VALUES (1, N'1')
INSERT [dbo].[Genres] ([GenreId], [Genre]) VALUES (2, N'2')
INSERT [dbo].[Genres] ([GenreId], [Genre]) VALUES (3, N'3')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
/****** Object:  Index [IX_Books_GenreId]    Script Date: 9/4/2020 12:39:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_Books_GenreId] ON [dbo].[Books]
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BooksAuthors_AuthorId]    Script Date: 9/4/2020 12:39:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_BooksAuthors_AuthorId] ON [dbo].[BooksAuthors]
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BooksAuthors_BookId]    Script Date: 9/4/2020 12:39:54 PM ******/
CREATE NONCLUSTERED INDEX [IX_BooksAuthors_BookId] ON [dbo].[BooksAuthors]
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Books] ADD  DEFAULT (CONVERT([bit],(0))) FOR [isFamous]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Genres_GenreId] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([GenreId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Genres_GenreId]
GO
ALTER TABLE [dbo].[BooksAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BooksAuthors_Authors_AuthorId] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([AuthorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BooksAuthors] CHECK CONSTRAINT [FK_BooksAuthors_Authors_AuthorId]
GO
ALTER TABLE [dbo].[BooksAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BooksAuthors_Books_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BooksAuthors] CHECK CONSTRAINT [FK_BooksAuthors_Books_BookId]
GO
USE [master]
GO
ALTER DATABASE [BooksApp] SET  READ_WRITE 
GO
