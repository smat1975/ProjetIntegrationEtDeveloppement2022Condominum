USE [master]
GO
/****** Object:  Database [CondominiumMgt]    Script Date: 19-08-22 14:27:47 ******/
CREATE DATABASE [CondominiumMgt]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CondominiumMgt', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CondominiumMgt.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CondominiumMgt_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CondominiumMgt_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CondominiumMgt] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CondominiumMgt].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CondominiumMgt] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CondominiumMgt] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CondominiumMgt] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CondominiumMgt] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CondominiumMgt] SET ARITHABORT OFF 
GO
ALTER DATABASE [CondominiumMgt] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CondominiumMgt] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CondominiumMgt] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CondominiumMgt] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CondominiumMgt] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CondominiumMgt] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CondominiumMgt] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CondominiumMgt] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CondominiumMgt] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CondominiumMgt] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CondominiumMgt] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CondominiumMgt] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CondominiumMgt] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CondominiumMgt] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CondominiumMgt] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CondominiumMgt] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CondominiumMgt] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CondominiumMgt] SET RECOVERY FULL 
GO
ALTER DATABASE [CondominiumMgt] SET  MULTI_USER 
GO
ALTER DATABASE [CondominiumMgt] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CondominiumMgt] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CondominiumMgt] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CondominiumMgt] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CondominiumMgt] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CondominiumMgt', N'ON'
GO
ALTER DATABASE [CondominiumMgt] SET QUERY_STORE = OFF
GO
USE [CondominiumMgt]
GO
/****** Object:  Table [dbo].[Annexes]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Annexes](
	[IdAnnexe] [int] IDENTITY(1,1) NOT NULL,
	[IdMessage] [int] NOT NULL,
	[Remarque] [nvarchar](50) NULL,
 CONSTRAINT [PK_Annexes] PRIMARY KEY CLUSTERED 
(
	[IdAnnexe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Civilites]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Civilites](
	[IdCivilite] [int] IDENTITY(1,1) NOT NULL,
	[Denomination] [nvarchar](50) NOT NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_Civilites] PRIMARY KEY CLUSTERED 
(
	[IdCivilite] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CodesPCMN]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CodesPCMN](
	[IdCodePCMN] [int] IDENTITY(1,1) NOT NULL,
	[CodePCMN] [int] NOT NULL,
	[Libelle] [nvarchar](50) NOT NULL,
	[CodeDecompte] [int] NOT NULL,
	[Denomination] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CodesPCMN] PRIMARY KEY CLUSTERED 
(
	[IdCodePCMN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComptesBque]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComptesBque](
	[IdCompteBque] [int] IDENTITY(1,1) NOT NULL,
	[NomBque] [nvarchar](50) NOT NULL,
	[NumCompteBque] [nvarchar](50) NOT NULL,
	[IdCoproprietaire] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ActifO/N] [bit] NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_ComptesBque] PRIMARY KEY CLUSTERED 
(
	[IdCompteBque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coproprietaires]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coproprietaires](
	[IdCoproprietaire] [nvarchar](50) NOT NULL,
	[Nom] [nvarchar](max) NOT NULL,
	[Prenoms] [nvarchar](max) NULL,
	[DateNaissance] [date] NULL,
	[NumNISS] [nvarchar](50) NULL,
	[Sexe] [int] NOT NULL,
	[Email] [nvarchar](max) NULL,
	[NumTel] [nvarchar](max) NULL,
	[NumGsm] [nvarchar](max) NULL,
	[Adresse] [nvarchar](max) NOT NULL,
	[IdCivilite] [int] NOT NULL,
	[DateCreation] [date] NOT NULL,
	[DateCloture] [date] NULL,
	[IdRaisonCloture] [int] NOT NULL,
	[ContactAdresse] [nvarchar](max) NULL,
	[ContactNom] [nvarchar](max) NULL,
	[ContactTel] [nvarchar](max) NULL,
	[ContactEmail] [nvarchar](max) NULL,
	[ContactRelation] [nvarchar](max) NULL,
	[AdresseFacturation] [nvarchar](max) NULL,
	[AdresseEnvoiFacture] [nvarchar](max) NULL,
	[EmailEnvoiFacture] [nvarchar](max) NULL,
	[NumTelEnvoiFacture] [nvarchar](max) NULL,
	[Remarques] [nvarchar](max) NULL,
 CONSTRAINT [PK_Coproprietaires] PRIMARY KEY CLUSTERED 
(
	[IdCoproprietaire] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Coproprietes]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coproprietes](
	[IdCopropriete] [int] IDENTITY(1,1) NOT NULL,
	[IdCoproprietaire] [nvarchar](50) NOT NULL,
	[IdLot] [int] NOT NULL,
	[NumContrat] [nvarchar](50) NULL,
	[DateDebut] [date] NOT NULL,
	[DateFin] [date] NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_Coproprietes] PRIMARY KEY CLUSTERED 
(
	[IdCopropriete] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Decomptes]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Decomptes](
	[IdDecompte] [int] IDENTITY(1,1) NOT NULL,
	[IdCoproprietaire] [nvarchar](50) NOT NULL,
	[IdGroupement] [int] NOT NULL,
	[IdPeriode] [int] NOT NULL,
	[DateCreation] [date] NOT NULL,
	[DateDebutDecompte] [date] NOT NULL,
	[DateFinDecompte] [date] NOT NULL,
	[MontantTotalDecompte] [float] NULL,
	[DateEcheance] [date] NULL,
	[ReferencePaiement] [nvarchar](max) NULL,
	[Commentaire] [nvarchar](max) NULL,
	[SoldeO/N] [bit] NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_Decomptes] PRIMARY KEY CLUSTERED 
(
	[IdDecompte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Destinations]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Destinations](
	[IdDestination] [int] IDENTITY(1,1) NOT NULL,
	[IdMessage] [int] NOT NULL,
	[IdDestinataire] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Destinations] PRIMARY KEY CLUSTERED 
(
	[IdDestination] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentsFournisseurs]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentsFournisseurs](
	[IdDocumentFournisseur] [int] IDENTITY(1,1) NOT NULL,
	[IdTypeDocumentFournisseur] [int] NOT NULL,
	[IdFournisseur] [int] NOT NULL,
	[IdPeriode] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[DateEnregistrement] [date] NOT NULL,
	[DateDocument] [date] NOT NULL,
	[DateEcheance] [date] NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_DocumentsFournisseurs] PRIMARY KEY CLUSTERED 
(
	[IdDocumentFournisseur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fournisseurs]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fournisseurs](
	[IdFournisseur] [int] IDENTITY(1,1) NOT NULL,
	[Denomination] [nvarchar](50) NOT NULL,
	[NomContact] [nvarchar](50) NOT NULL,
	[Adresse] [nvarchar](max) NULL,
	[Email] [nvarchar](50) NULL,
	[NumTel] [nvarchar](50) NULL,
	[NumRegistre] [nvarchar](50) NULL,
	[Activite] [nvarchar](50) NOT NULL,
	[NumAgregation] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[DateDebut] [date] NOT NULL,
	[DateFin] [date] NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_Fournisseurs] PRIMARY KEY CLUSTERED 
(
	[IdFournisseur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groupements]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groupements](
	[IdGroupement] [int] IDENTITY(1,1) NOT NULL,
	[IdGroupe] [int] NOT NULL,
	[IdLot] [int] NOT NULL,
	[DateDebutGroupement] [date] NULL,
	[DateFinGroupement] [date] NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_Groupements] PRIMARY KEY CLUSTERED 
(
	[IdGroupement] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groupes]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groupes](
	[IdGroupe] [int] IDENTITY(1,1) NOT NULL,
	[Denomination] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_Groupes] PRIMARY KEY CLUSTERED 
(
	[IdGroupe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LignesDecomptes]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LignesDecomptes](
	[IdLigneDecompte] [int] IDENTITY(1,1) NOT NULL,
	[IdDecompte] [int] NOT NULL,
	[IdCodePCMN] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[IdLigneDocumentFournisseur] [int] NOT NULL,
	[IdQuotite] [int] NULL,
	[DateDebutLigne] [date] NULL,
	[DateFinLigne] [date] NULL,
	[NbreJoursLigne] [int] NULL,
	[MontantTotalTVACLigne] [float] NULL,
	[MontantTVALigne] [float] NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_LignesDecomptes] PRIMARY KEY CLUSTERED 
(
	[IdLigneDecompte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LignesDocumentsFournisseurs]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LignesDocumentsFournisseurs](
	[IdLigneDocumentFournisseur] [int] IDENTITY(1,1) NOT NULL,
	[IdDocumentFournisseur] [int] NOT NULL,
	[IdCodePCMN] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[DateDebutLigne] [date] NULL,
	[DateFinLigne] [date] NULL,
	[NbreJoursLigne] [int] NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_LignesDocumentsFournisseurs] PRIMARY KEY CLUSTERED 
(
	[IdLigneDocumentFournisseur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localisations]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localisations](
	[IdLocalisation] [int] IDENTITY(1,1) NOT NULL,
	[Adresse] [nvarchar](max) NOT NULL,
	[CodeLocalisation] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[DateDebut] [date] NOT NULL,
	[DateFin] [date] NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_Localisations] PRIMARY KEY CLUSTERED 
(
	[IdLocalisation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lots]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lots](
	[IdLot] [int] IDENTITY(1,1) NOT NULL,
	[IdTypeLot] [int] NOT NULL,
	[CodeLot] [nvarchar](50) NOT NULL,
	[DateDebut] [date] NOT NULL,
	[DateFin] [date] NULL,
	[IdLocalisation] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[NombreM2] [int] NOT NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_Lots] PRIMARY KEY CLUSTERED 
(
	[IdLot] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MatchingsPaiements]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatchingsPaiements](
	[IdMatchingPaiement] [int] IDENTITY(1,1) NOT NULL,
	[IdDecompte] [int] NOT NULL,
	[IdPaiement] [int] NOT NULL,
	[Montant] [float] NOT NULL,
	[DateEnregistrement] [date] NOT NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_MatchingsPaiements] PRIMARY KEY CLUSTERED 
(
	[IdMatchingPaiement] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[IdMessage] [int] IDENTITY(1,1) NOT NULL,
	[IdExpediteur] [nvarchar](50) NOT NULL,
	[DateExpedition] [date] NOT NULL,
	[TitreMessage] [nvarchar](50) NOT NULL,
	[ContenuMessage] [nvarchar](250) NULL,
	[IdTypeMessage] [int] NOT NULL,
	[Validation] [bit] NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[IdMessage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paiements]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paiements](
	[IdPaiement] [int] IDENTITY(1,1) NOT NULL,
	[IdCompteBquePayeur] [int] NOT NULL,
	[NomPayeurAutre] [nvarchar](50) NULL,
	[Communication] [nvarchar](max) NULL,
	[Montant] [float] NOT NULL,
	[DateEnregistrement] [date] NOT NULL,
	[DateDocument] [date] NOT NULL,
	[NumDocument] [nvarchar](50) NOT NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_Paiements] PRIMARY KEY CLUSTERED 
(
	[IdPaiement] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Periodes]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Periodes](
	[IdPeriode] [int] IDENTITY(1,1) NOT NULL,
	[Denomination] [nvarchar](50) NOT NULL,
	[Annee] [int] NOT NULL,
	[DateDebut] [date] NOT NULL,
	[DateFin] [date] NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_Periodes] PRIMARY KEY CLUSTERED 
(
	[IdPeriode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Photos]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photos](
	[IdPhoto] [int] IDENTITY(1,1) NOT NULL,
	[IdAnnexe] [int] NOT NULL,
	[Ressource] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED 
(
	[IdPhoto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quotites]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quotites](
	[IdQuotite] [int] IDENTITY(1,1) NOT NULL,
	[IdLot] [int] NOT NULL,
	[IdLocalisation] [int] NOT NULL,
	[ValeurLot] [int] NOT NULL,
	[ValeurLocalisation] [int] NOT NULL,
	[DateDebut] [date] NOT NULL,
	[DateFin] [date] NULL,
	[ActifO/N] [bit] NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_Quotites] PRIMARY KEY CLUSTERED 
(
	[IdQuotite] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RaisonsCloture]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RaisonsCloture](
	[IdRaisonCloture] [int] IDENTITY(1,1) NOT NULL,
	[Denomination] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_RaisonsCloture] PRIMARY KEY CLUSTERED 
(
	[IdRaisonCloture] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sexes]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sexes](
	[IdSexe] [int] IDENTITY(1,1) NOT NULL,
	[Denomination] [nvarchar](50) NOT NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_Sexes] PRIMARY KEY CLUSTERED 
(
	[IdSexe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypesDocumentFournisseur]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypesDocumentFournisseur](
	[IdTypeDocumentFournisseur] [int] IDENTITY(1,1) NOT NULL,
	[Denomination] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_TypesDocumentFournisseur] PRIMARY KEY CLUSTERED 
(
	[IdTypeDocumentFournisseur] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypesLot]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypesLot](
	[IdTypeLot] [int] IDENTITY(1,1) NOT NULL,
	[Denomination] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_TypesLot] PRIMARY KEY CLUSTERED 
(
	[IdTypeLot] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypesMessage]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypesMessage](
	[IdTypeMessage] [int] IDENTITY(1,1) NOT NULL,
	[Denomination] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_TypesMessage] PRIMARY KEY CLUSTERED 
(
	[IdTypeMessage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Annexes]  WITH CHECK ADD  CONSTRAINT [FK_Annexes-Messages] FOREIGN KEY([IdMessage])
REFERENCES [dbo].[Messages] ([IdMessage])
GO
ALTER TABLE [dbo].[Annexes] CHECK CONSTRAINT [FK_Annexes-Messages]
GO
ALTER TABLE [dbo].[ComptesBque]  WITH CHECK ADD  CONSTRAINT [FK_ComptesBque-Coproprietaires] FOREIGN KEY([IdCoproprietaire])
REFERENCES [dbo].[Coproprietaires] ([IdCoproprietaire])
GO
ALTER TABLE [dbo].[ComptesBque] CHECK CONSTRAINT [FK_ComptesBque-Coproprietaires]
GO
ALTER TABLE [dbo].[Coproprietaires]  WITH CHECK ADD  CONSTRAINT [FK_IdCivilite] FOREIGN KEY([IdCivilite])
REFERENCES [dbo].[Civilites] ([IdCivilite])
GO
ALTER TABLE [dbo].[Coproprietaires] CHECK CONSTRAINT [FK_IdCivilite]
GO
ALTER TABLE [dbo].[Coproprietaires]  WITH CHECK ADD  CONSTRAINT [FK_IdRaisonCloture] FOREIGN KEY([IdRaisonCloture])
REFERENCES [dbo].[RaisonsCloture] ([IdRaisonCloture])
GO
ALTER TABLE [dbo].[Coproprietaires] CHECK CONSTRAINT [FK_IdRaisonCloture]
GO
ALTER TABLE [dbo].[Coproprietes]  WITH CHECK ADD  CONSTRAINT [FK_IdCoproprietaire] FOREIGN KEY([IdCoproprietaire])
REFERENCES [dbo].[Coproprietaires] ([IdCoproprietaire])
GO
ALTER TABLE [dbo].[Coproprietes] CHECK CONSTRAINT [FK_IdCoproprietaire]
GO
ALTER TABLE [dbo].[Coproprietes]  WITH CHECK ADD  CONSTRAINT [FK_IdLot] FOREIGN KEY([IdLot])
REFERENCES [dbo].[Lots] ([IdLot])
GO
ALTER TABLE [dbo].[Coproprietes] CHECK CONSTRAINT [FK_IdLot]
GO
ALTER TABLE [dbo].[Decomptes]  WITH CHECK ADD  CONSTRAINT [FK_Coproprietaires-Decomptes] FOREIGN KEY([IdCoproprietaire])
REFERENCES [dbo].[Coproprietaires] ([IdCoproprietaire])
GO
ALTER TABLE [dbo].[Decomptes] CHECK CONSTRAINT [FK_Coproprietaires-Decomptes]
GO
ALTER TABLE [dbo].[Decomptes]  WITH CHECK ADD  CONSTRAINT [FK_Decomptes-Periodes] FOREIGN KEY([IdPeriode])
REFERENCES [dbo].[Periodes] ([IdPeriode])
GO
ALTER TABLE [dbo].[Decomptes] CHECK CONSTRAINT [FK_Decomptes-Periodes]
GO
ALTER TABLE [dbo].[Decomptes]  WITH CHECK ADD  CONSTRAINT [FK_IdGroupement] FOREIGN KEY([IdGroupement])
REFERENCES [dbo].[Groupements] ([IdGroupement])
GO
ALTER TABLE [dbo].[Decomptes] CHECK CONSTRAINT [FK_IdGroupement]
GO
ALTER TABLE [dbo].[Decomptes] CHECK CONSTRAINT [FK_IdTypeTVA]
GO
ALTER TABLE [dbo].[Destinations]  WITH CHECK ADD  CONSTRAINT [FK_IdDestinataire] FOREIGN KEY([IdDestinataire])
REFERENCES [dbo].[Coproprietaires] ([IdCoproprietaire])
GO
ALTER TABLE [dbo].[Destinations] CHECK CONSTRAINT [FK_IdDestinataire]
GO
ALTER TABLE [dbo].[Destinations]  WITH CHECK ADD  CONSTRAINT [FK_IdMessage] FOREIGN KEY([IdMessage])
REFERENCES [dbo].[Messages] ([IdMessage])
GO
ALTER TABLE [dbo].[Destinations] CHECK CONSTRAINT [FK_IdMessage]
GO
ALTER TABLE [dbo].[DocumentsFournisseurs]  WITH CHECK ADD  CONSTRAINT [FK_DocumentsFournisseurs-Periodes] FOREIGN KEY([IdPeriode])
REFERENCES [dbo].[Periodes] ([IdPeriode])
GO
ALTER TABLE [dbo].[DocumentsFournisseurs] CHECK CONSTRAINT [FK_DocumentsFournisseurs-Periodes]
GO
ALTER TABLE [dbo].[DocumentsFournisseurs] CHECK CONSTRAINT [FK_DocumentsFournisseurs-TypesTVA]
GO
ALTER TABLE [dbo].[DocumentsFournisseurs]  WITH CHECK ADD  CONSTRAINT [FK_IdFournisseur] FOREIGN KEY([IdFournisseur])
REFERENCES [dbo].[Fournisseurs] ([IdFournisseur])
GO
ALTER TABLE [dbo].[DocumentsFournisseurs] CHECK CONSTRAINT [FK_IdFournisseur]
GO
ALTER TABLE [dbo].[DocumentsFournisseurs]  WITH CHECK ADD  CONSTRAINT [FK_IdTypeDocumentFournisseur] FOREIGN KEY([IdTypeDocumentFournisseur])
REFERENCES [dbo].[TypesDocumentFournisseur] ([IdTypeDocumentFournisseur])
GO
ALTER TABLE [dbo].[DocumentsFournisseurs] CHECK CONSTRAINT [FK_IdTypeDocumentFournisseur]
GO
ALTER TABLE [dbo].[Groupements]  WITH CHECK ADD  CONSTRAINT [FK_Groupements-Lots] FOREIGN KEY([IdLot])
REFERENCES [dbo].[Lots] ([IdLot])
GO
ALTER TABLE [dbo].[Groupements] CHECK CONSTRAINT [FK_Groupements-Lots]
GO
ALTER TABLE [dbo].[Groupements]  WITH CHECK ADD  CONSTRAINT [FK_IdGroupe] FOREIGN KEY([IdGroupe])
REFERENCES [dbo].[Groupes] ([IdGroupe])
GO
ALTER TABLE [dbo].[Groupements] CHECK CONSTRAINT [FK_IdGroupe]
GO
ALTER TABLE [dbo].[LignesDecomptes]  WITH CHECK ADD  CONSTRAINT [FK_IdLigneDocumentFournisseur] FOREIGN KEY([IdLigneDocumentFournisseur])
REFERENCES [dbo].[LignesDocumentsFournisseurs] ([IdLigneDocumentFournisseur])
GO
ALTER TABLE [dbo].[LignesDecomptes] CHECK CONSTRAINT [FK_IdLigneDocumentFournisseur]
GO
ALTER TABLE [dbo].[LignesDecomptes]  WITH CHECK ADD  CONSTRAINT [FK_IdQuotite] FOREIGN KEY([IdQuotite])
REFERENCES [dbo].[Quotites] ([IdQuotite])
GO
ALTER TABLE [dbo].[LignesDecomptes] CHECK CONSTRAINT [FK_IdQuotite]
GO
ALTER TABLE [dbo].[LignesDecomptes]  WITH CHECK ADD  CONSTRAINT [FK_LignesDecomptes-CodesPCMN] FOREIGN KEY([IdCodePCMN])
REFERENCES [dbo].[CodesPCMN] ([IdCodePCMN])
GO
ALTER TABLE [dbo].[LignesDecomptes] CHECK CONSTRAINT [FK_LignesDecomptes-CodesPCMN]
GO
ALTER TABLE [dbo].[LignesDecomptes]  WITH CHECK ADD  CONSTRAINT [FK_LignesDecomptes-Decomptes] FOREIGN KEY([IdDecompte])
REFERENCES [dbo].[Decomptes] ([IdDecompte])
GO
ALTER TABLE [dbo].[LignesDecomptes] CHECK CONSTRAINT [FK_LignesDecomptes-Decomptes]
GO
ALTER TABLE [dbo].[LignesDocumentsFournisseurs]  WITH CHECK ADD  CONSTRAINT [FK_IdDocumentFournisseur] FOREIGN KEY([IdDocumentFournisseur])
REFERENCES [dbo].[DocumentsFournisseurs] ([IdDocumentFournisseur])
GO
ALTER TABLE [dbo].[LignesDocumentsFournisseurs] CHECK CONSTRAINT [FK_IdDocumentFournisseur]
GO
ALTER TABLE [dbo].[LignesDocumentsFournisseurs]  WITH CHECK ADD  CONSTRAINT [FK_LignesDocumentsFournisseurs-CodesPCMN] FOREIGN KEY([IdCodePCMN])
REFERENCES [dbo].[CodesPCMN] ([IdCodePCMN])
GO
ALTER TABLE [dbo].[LignesDocumentsFournisseurs] CHECK CONSTRAINT [FK_LignesDocumentsFournisseurs-CodesPCMN]
GO
ALTER TABLE [dbo].[LignesDocumentsFournisseurs] CHECK CONSTRAINT [FK_LignesDocumentsFournisseurs-TypesTVA]
GO
ALTER TABLE [dbo].[Lots]  WITH CHECK ADD  CONSTRAINT [FK_IdLocalisation] FOREIGN KEY([IdLocalisation])
REFERENCES [dbo].[Localisations] ([IdLocalisation])
GO
ALTER TABLE [dbo].[Lots] CHECK CONSTRAINT [FK_IdLocalisation]
GO
ALTER TABLE [dbo].[Lots]  WITH CHECK ADD  CONSTRAINT [FK_IdTypeLot] FOREIGN KEY([IdTypeLot])
REFERENCES [dbo].[TypesLot] ([IdTypeLot])
GO
ALTER TABLE [dbo].[Lots] CHECK CONSTRAINT [FK_IdTypeLot]
GO
ALTER TABLE [dbo].[MatchingsPaiements]  WITH CHECK ADD  CONSTRAINT [FK_IdPaiement] FOREIGN KEY([IdPaiement])
REFERENCES [dbo].[Paiements] ([IdPaiement])
GO
ALTER TABLE [dbo].[MatchingsPaiements] CHECK CONSTRAINT [FK_IdPaiement]
GO
ALTER TABLE [dbo].[MatchingsPaiements]  WITH CHECK ADD  CONSTRAINT [FK_MatchingPaiements-Decomptes] FOREIGN KEY([IdDecompte])
REFERENCES [dbo].[Decomptes] ([IdDecompte])
GO
ALTER TABLE [dbo].[MatchingsPaiements] CHECK CONSTRAINT [FK_MatchingPaiements-Decomptes]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_IdExpediteur] FOREIGN KEY([IdExpediteur])
REFERENCES [dbo].[Coproprietaires] ([IdCoproprietaire])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_IdExpediteur]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_IdTypeMessage] FOREIGN KEY([IdTypeMessage])
REFERENCES [dbo].[TypesMessage] ([IdTypeMessage])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_IdTypeMessage]
GO
ALTER TABLE [dbo].[Paiements]  WITH CHECK ADD  CONSTRAINT [FK_IdCompteBquePayeur] FOREIGN KEY([IdCompteBquePayeur])
REFERENCES [dbo].[ComptesBque] ([IdCompteBque])
GO
ALTER TABLE [dbo].[Paiements] CHECK CONSTRAINT [FK_IdCompteBquePayeur]
GO
ALTER TABLE [dbo].[Photos]  WITH CHECK ADD  CONSTRAINT [FK_IdAnnexe] FOREIGN KEY([IdAnnexe])
REFERENCES [dbo].[Annexes] ([IdAnnexe])
GO
ALTER TABLE [dbo].[Photos] CHECK CONSTRAINT [FK_IdAnnexe]
GO
ALTER TABLE [dbo].[Quotites]  WITH CHECK ADD  CONSTRAINT [FK_Quotites-Localisations] FOREIGN KEY([IdLocalisation])
REFERENCES [dbo].[Localisations] ([IdLocalisation])
GO
ALTER TABLE [dbo].[Quotites] CHECK CONSTRAINT [FK_Quotites-Localisations]
GO
ALTER TABLE [dbo].[Quotites]  WITH CHECK ADD  CONSTRAINT [FK_Quotites-Lots] FOREIGN KEY([IdLot])
REFERENCES [dbo].[Lots] ([IdLot])
GO
ALTER TABLE [dbo].[Quotites] CHECK CONSTRAINT [FK_Quotites-Lots]
GO

USE [master]
GO
ALTER DATABASE [CondominiumMgt] SET  READ_WRITE 
GO
