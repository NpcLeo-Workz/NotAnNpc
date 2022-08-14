USE [NotAnNpcDB]
GO

/****** Object:  Table [dbo].[AbilityScoreBonus]    Script Date: 8/14/2022 6:30:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AbilityScoreBonus](
	[AbilityScoreBonusID] [int] IDENTITY(1,1) NOT NULL,
	[strength] [int] NOT NULL,
	[dexterity] [int] NOT NULL,
	[constitution] [int] NOT NULL,
	[inteligence] [int] NOT NULL,
	[wisdom] [int] NOT NULL,
	[charisma] [int] NOT NULL,
 CONSTRAINT [PK_dbo.AbilityScoreBonus] PRIMARY KEY CLUSTERED 
(
	[AbilityScoreBonusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [NotAnNpcDB]
GO

/****** Object:  Table [dbo].[LanguageRaces]    Script Date: 8/14/2022 6:31:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LanguageRaces](
	[LanguageRaceID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageID] [int] NOT NULL,
	[RaceID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.LanguageRaces] PRIMARY KEY CLUSTERED 
(
	[LanguageRaceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LanguageRaces]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LanguageRaces_dbo.Languages_LanguageID] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[LanguageRaces] CHECK CONSTRAINT [FK_dbo.LanguageRaces_dbo.Languages_LanguageID]
GO

ALTER TABLE [dbo].[LanguageRaces]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LanguageRaces_dbo.Races_RaceID] FOREIGN KEY([RaceID])
REFERENCES [dbo].[Races] ([RaceID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[LanguageRaces] CHECK CONSTRAINT [FK_dbo.LanguageRaces_dbo.Races_RaceID]
GO

USE [NotAnNpcDB]
GO

/****** Object:  Table [dbo].[Languages]    Script Date: 8/14/2022 6:31:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Languages](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Languages] PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

USE [NotAnNpcDB]
GO

/****** Object:  Table [dbo].[Races]    Script Date: 8/14/2022 6:31:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Races](
	[RaceID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[AbilityScoreBonusID] [int] NOT NULL,
	[Size] [nvarchar](max) NULL,
	[SpeedWalk] [int] NOT NULL,
	[SpeedSwim] [int] NOT NULL,
	[SpeedFly] [int] NOT NULL,
	[SpeedClimb] [int] NOT NULL,
	[CreatureType] [nvarchar](max) NULL,
	[BaseRace] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Races] PRIMARY KEY CLUSTERED 
(
	[RaceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Races]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Races_dbo.AbilityScoreBonus_AbilityScoreBonusID] FOREIGN KEY([AbilityScoreBonusID])
REFERENCES [dbo].[AbilityScoreBonus] ([AbilityScoreBonusID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Races] CHECK CONSTRAINT [FK_dbo.Races_dbo.AbilityScoreBonus_AbilityScoreBonusID]
GO

USE [NotAnNpcDB]
GO

/****** Object:  Table [dbo].[RaceTraits]    Script Date: 8/14/2022 6:31:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RaceTraits](
	[RaceTraitID] [int] IDENTITY(1,1) NOT NULL,
	[RaceID] [int] NOT NULL,
	[TraitID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.RaceTraits] PRIMARY KEY CLUSTERED 
(
	[RaceTraitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[RaceTraits]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RaceTraits_dbo.Races_RaceID] FOREIGN KEY([RaceID])
REFERENCES [dbo].[Races] ([RaceID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[RaceTraits] CHECK CONSTRAINT [FK_dbo.RaceTraits_dbo.Races_RaceID]
GO

ALTER TABLE [dbo].[RaceTraits]  WITH CHECK ADD  CONSTRAINT [FK_dbo.RaceTraits_dbo.Traits_TraitID] FOREIGN KEY([TraitID])
REFERENCES [dbo].[Traits] ([TraitID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[RaceTraits] CHECK CONSTRAINT [FK_dbo.RaceTraits_dbo.Traits_TraitID]
GO

USE [NotAnNpcDB]
GO

/****** Object:  Table [dbo].[Traits]    Script Date: 8/14/2022 6:32:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Traits](
	[TraitID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Traits] PRIMARY KEY CLUSTERED 
(
	[TraitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


