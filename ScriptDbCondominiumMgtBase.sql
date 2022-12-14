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
	[IdTypeTVA] [int] NULL,
	[MontantTotalTVA] [float] NULL,
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
	[MontantTotalTVACDocument] [float] NULL,
	[IdTypeTVA] [int] NULL,
	[MontantTVA] [float] NULL,
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
	[NumTVA] [nvarchar](50) NULL,
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
	[MontantTotalTVACLigne] [float] NULL,
	[IdTypeTVA] [int] NULL,
	[MontantTVALigne] [float] NULL,
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
/****** Object:  Table [dbo].[TypesTVA]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypesTVA](
	[IdTypeTVA] [int] IDENTITY(1,1) NOT NULL,
	[Denomination] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ActifO/N] [bit] NULL,
	[Remarque] [nvarchar](max) NULL,
 CONSTRAINT [PK_TypesTVA] PRIMARY KEY CLUSTERED 
(
	[IdTypeTVA] ASC
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
ALTER TABLE [dbo].[Decomptes]  WITH CHECK ADD  CONSTRAINT [FK_IdTypeTVA] FOREIGN KEY([IdTypeTVA])
REFERENCES [dbo].[TypesTVA] ([IdTypeTVA])
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
ALTER TABLE [dbo].[DocumentsFournisseurs]  WITH CHECK ADD  CONSTRAINT [FK_DocumentsFournisseurs-TypesTVA] FOREIGN KEY([IdTypeTVA])
REFERENCES [dbo].[TypesTVA] ([IdTypeTVA])
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
ALTER TABLE [dbo].[LignesDocumentsFournisseurs]  WITH CHECK ADD  CONSTRAINT [FK_LignesDocumentsFournisseurs-TypesTVA] FOREIGN KEY([IdTypeTVA])
REFERENCES [dbo].[TypesTVA] ([IdTypeTVA])
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
/****** Object:  StoredProcedure [dbo].[AddMessage]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddMessage]
	@IdExpediteur nvarchar,
	@DateExpedition datetime,
	@TitreMessage nvarchar,
	@ContenuMessage nvarchar,
	@IdTypeMessage int,
	@Validation bit


AS
BEGIN
	SET NOCOUNT ON;
		--declare @IdExpediteur nvarchar = 'st'

		execute [dbo].[CreerMessage] @IdExpediteur, @DateExpedition, @TitreMessage, @ContenuMessage, @IdTypeMessage, @Validation
END
GO
/****** Object:  StoredProcedure [dbo].[CreerMessage]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<MATHOT Stephane>
-- Create date: <15-08-2022>
-- Description:	<Ajoute ou mets à jour une entrée dans la table Messages>
-- =============================================
CREATE PROCEDURE [dbo].[CreerMessage]
	-- Add the parameters for the stored procedure here
	@IdExpediteur nvarchar, 
	@DateExpedition datetime,
	@TitreMessage nvarchar,
	@ContenuMessage nvarchar,
	@IdTypeMessage int,
	@Validation bit
	

        /*public Coproprietaires Expediteur { get; set; }
        public TypesMessage TypeMessage { get; set; }
        public ICollection<Annexes> Annexes { get; set; }
        public ICollection<Destinations> Destinations { get; set; }*/
AS
	BEGIN
	SET NOCOUNT ON;
		insert into Messages([IdExpediteur], [DateExpedition], [TitreMessage], [ContenuMessage], [IdTypeMessage], [Validation]) values (@IdExpediteur, @DateExpedition, @TitreMessage, @ContenuMessage, @IdTypeMessage, @Validation)
	END
GO
/****** Object:  StoredProcedure [dbo].[DeleteMessageById]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteMessageById]
		@IdMessage int
        AS
        BEGIN
           delete from Messages where IdMessage = @IdMessage
        END
GO
/****** Object:  StoredProcedure [dbo].[GetAllAnnexes]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllAnnexes]
        AS
        BEGIN
            SET NOCOUNT ON;
            select * from Annexes
        END
GO
/****** Object:  StoredProcedure [dbo].[GetAllAnnexesForMessage]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllAnnexesForMessage]
		@MessageId int
        AS
        BEGIN
            SET NOCOUNT ON;
            select * from Annexes where IdMessage = @MessageId
        END
GO
/****** Object:  StoredProcedure [dbo].[GetAllAnnexesForMessages]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllAnnexesForMessages]
		
AS

Begin

	Declare @IdMessage int
	Declare @IdAnnexe int

	Declare @TAllAnnexesForMessages table (IdMessage int, IdAnnexe int)

	Declare VMCursor Cursor

	For select a.IdMessage, a.IdAnnexe from Annexes as a

	Open VMCursor 

	Fetch VMCursor into @IdMessage, @IdAnnexe

while (@@FETCH_STATUS = 0)

Begin 
	Insert into @TAllAnnexesForMessages values (@IdMessage, @IdAnnexe)

	Fetch VMCursor into @IdMessage, @IdAnnexe

End

Close VMCursor

Deallocate VMCursor

select distinct IdMessage, IdAnnexe from @TAllAnnexesForMessages

End
GO
/****** Object:  StoredProcedure [dbo].[GetAllCodesLots]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllCodesLots]
        AS
        BEGIN
            SET NOCOUNT ON;
            select CodeLot from Lots
        END
GO
/****** Object:  StoredProcedure [dbo].[GetAllCoproprietaires]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllCoproprietaires]
        AS
        BEGIN
            SET NOCOUNT ON;
            select * from Coproprietaires
        END
GO
/****** Object:  StoredProcedure [dbo].[GetAnnexeById]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAnnexeById]
		@IdAnnexe int
        AS
        BEGIN
            SET NOCOUNT ON;
            select * from Annexes where IdAnnexe = @IdAnnexe
        END
GO
/****** Object:  StoredProcedure [dbo].[GetArrayAnnexesForIdMessage]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetArrayAnnexesForIdMessage]
@IdMessage int

As

Begin
		Declare @IdAnnexe int


Declare @TArrayAnnexesPush table (IdAnnexe int)

Declare VMCursor Cursor
	
For select  a.IdAnnexe from Annexes as a, Messages as m where a.IdMessage = m.IdMessage
	
Open VMCursor 

Fetch VMCursor into @IdAnnexe

while (@@FETCH_STATUS = 0)

Begin 
	Insert into @TArrayAnnexesPush values (@IdAnnexe)

	Fetch VMCursor into @IdAnnexe

End

Close VMCursor

Deallocate VMCursor

select IdAnnexe from @TArrayAnnexesPush

End
GO
/****** Object:  StoredProcedure [dbo].[GetCoproprietaireWithId]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCoproprietaireWithId]
		@CoproprietaireId int
        AS
        BEGIN
            SET NOCOUNT ON;
            select * from Coproprietaires where IdCoproprietaire = @CoproprietaireId
        END
GO
/****** Object:  StoredProcedure [dbo].[GetTVueMessages]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetTVueMessages]

As

Begin
	Declare @ContenuMessage nvarchar(max)
	Declare @DateExpedition date

	Declare @TVueMessages table (ContenuMessage nvarchar(max), DateExpedition date)

	Declare VMCursor Cursor

	For select m.ContenuMessage, m.DateExpedition from messages as m where m.IdTypeMessage = 5
	
	Open VMCursor 

	Fetch VMCursor into @ContenuMessage, @DateExpedition

while (@@FETCH_STATUS = 0)

Begin 
	Insert into @TVueMessages values (@ContenuMessage, @DateExpedition) 

	Fetch VMCursor into @ContenuMessage, @DateExpedition

End

Close VMCursor

Deallocate VMCursor

select distinct ContenuMessage, DateExpedition from @TVueMessages

End
GO
/****** Object:  StoredProcedure [dbo].[GetTVueMessagesComplete]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetTVueMessagesComplete]

As

Begin
	Declare @ContenuMessage nvarchar(max)
	Declare @DateExpedition date
	Declare @EMailExpediteur nvarchar(50)

	Declare @TVueMessages table (ContenuMessage nvarchar(max), DateExpedition date, EMail nvarchar(50))

	Declare VMCursor Cursor

	For select m.ContenuMessage, m.DateExpedition, c.Email from Messages as m, Coproprietaires as c where m.IdExpediteur = c.IdCoproprietaire and m.IdTypeMessage = 5
	
	Open VMCursor 

	Fetch VMCursor into @ContenuMessage, @DateExpedition, @EMailExpediteur

while (@@FETCH_STATUS = 0)

Begin 
	Insert into @TVueMessages values (@ContenuMessage, @DateExpedition, @EMailExpediteur)

	Fetch VMCursor into @ContenuMessage, @DateExpedition, @EMailExpediteur

End

Close VMCursor

Deallocate VMCursor

select distinct ContenuMessage, DateExpedition, EMail from @TVueMessages

End
GO
/****** Object:  StoredProcedure [dbo].[GetTVueMessagesGen]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetTVueMessagesGen]

As

Begin
	/*Declare @Expediteur nvarchar(50)*/
	/*Declare @Email nvarchar(50)*/
	Declare @DateExpedition date
	Declare @TitreMessage nvarchar(50)
	Declare @ContenuMessage nvarchar(max)
	Declare @TypeMessage nvarchar(50)
	/*Declare @Priorite nvarchar(50)*/
	Declare @IdMessage int

	Declare @TVueMessagesGen table (/*Expediteur nvarchar(50), Email nvarchar(50), */DateExpedition date, TitreMessage nvarchar(50), ContenuMessage nvarchar(max), TypeMessage nvarchar(50), /*Priorite nvarchar(50),*/ IdMessage int)

	Declare VMCursor Cursor

	For select  /*u.NomUtilisateur, u.EmailUtilisateur, */m.DateExpedition, m.TitreMessage, m.ContenuMessage, tm.Denomination,/* p.Denomination,*/ m.IdMessage from Messages as m,/* utilisateur as u, priorite as p, */TypesMessage as tm where/* m.IdUtilisateur = u.IdUtilisateur and m.IdPriorite = p.IdPriorite and */ m.IdTypeMessage = tm.IdTypeMessage
	
	Open VMCursor 

	Fetch VMCursor into /*@Expediteur, @Email, */@DateExpedition, @titreMessage, @ContenuMessage, @TypeMessage,/* @Priorite,*/ @IdMessage

while (@@FETCH_STATUS = 0)

Begin 
	Insert into @TVueMessagesGen values (/*@Expediteur, @Email,*/ @DateExpedition, @titreMessage, @ContenuMessage, @TypeMessage, /*@Priorite, */@IdMessage)

	Fetch VMCursor into /* @Expediteur, @Email,*/ @DateExpedition, @titreMessage, @ContenuMessage, @TypeMessage, /*@Priorite,*/ @IdMessage

End

Close VMCursor

Deallocate VMCursor

select /*Expediteur, Email,*/ DateExpedition, titreMessage, ContenuMessage, TypeMessage, /*Priorite,*/ IdMessage from @TVueMessagesGen

End
GO
/****** Object:  StoredProcedure [dbo].[GetTVueMessagesSemiComplexe]    Script Date: 19-08-22 14:27:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[GetTVueMessagesSemiComplexe]

As

Begin
	Declare @EMailExpediteur nvarchar(50)
	Declare @DateExpedition date
	Declare @TitreMessage nvarchar(max)
	Declare @ContenuMessage nvarchar(max)
	Declare @IdMessage int


	Declare @TVueMessagesSemiComplexe table (EMailExpediteur nvarchar(50), DateExpedition date, TitreMessage nvarchar(max), ContenuMessage nvarchar(max), IdMessage int)

	Declare VMCursor Cursor

	For select c.Email, m.DateExpedition, m.TitreMessage, m.ContenuMessage, m.IdMessage from Messages as m, Coproprietaires as c where m.IdExpediteur = c.IdCoproprietaire
	
	Open VMCursor 

	Fetch VMCursor into @EMailExpediteur, @DateExpedition, @TitreMessage, @ContenuMessage,  @IdMessage

while (@@FETCH_STATUS = 0)

Begin 
	Insert into @TVueMessagesSemiComplexe values (@EMailExpediteur, @DateExpedition,  @TitreMessage, @ContenuMessage, @IdMessage)

	Fetch VMCursor into @EMailExpediteur, @DateExpedition, @TitreMessage, @ContenuMessage, @IdMessage

End

Close VMCursor

Deallocate VMCursor

select distinct EMailExpediteur, DateExpedition, TitreMessage, ContenuMessage, IdMessage from @TVueMessagesSemiComplexe

End
GO
USE [master]
GO
ALTER DATABASE [CondominiumMgt] SET  READ_WRITE 
GO
