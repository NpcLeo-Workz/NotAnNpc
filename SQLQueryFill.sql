SET IDENTITY_INSERT [dbo].[AbilityScoreBonus] ON
INSERT INTO [dbo].[AbilityScoreBonus] ([AbilityScoreBonusID], [strength], [dexterity], [constitution], [inteligence], [wisdom], [charisma]) VALUES (6, 1, 1, 0, 0, 0, 2)
INSERT INTO [dbo].[AbilityScoreBonus] ([AbilityScoreBonusID], [strength], [dexterity], [constitution], [inteligence], [wisdom], [charisma]) VALUES (1002, 0, 0, 0, 1, 0, 1)
INSERT INTO [dbo].[AbilityScoreBonus] ([AbilityScoreBonusID], [strength], [dexterity], [constitution], [inteligence], [wisdom], [charisma]) VALUES (1003, 1, 0, 0, 0, 0, 2)
INSERT INTO [dbo].[AbilityScoreBonus] ([AbilityScoreBonusID], [strength], [dexterity], [constitution], [inteligence], [wisdom], [charisma]) VALUES (1004, 1, 1, 0, 0, 0, 4)
INSERT INTO [dbo].[AbilityScoreBonus] ([AbilityScoreBonusID], [strength], [dexterity], [constitution], [inteligence], [wisdom], [charisma]) VALUES (2002, 1, 0, 3, 0, 0, 2)
INSERT INTO [dbo].[AbilityScoreBonus] ([AbilityScoreBonusID], [strength], [dexterity], [constitution], [inteligence], [wisdom], [charisma]) VALUES (3002, 1, 1, 1, 1, 1, 1)
INSERT INTO [dbo].[AbilityScoreBonus] ([AbilityScoreBonusID], [strength], [dexterity], [constitution], [inteligence], [wisdom], [charisma]) VALUES (4002, 0, 0, 0, 0, 0, 2)
INSERT INTO [dbo].[AbilityScoreBonus] ([AbilityScoreBonusID], [strength], [dexterity], [constitution], [inteligence], [wisdom], [charisma]) VALUES (5002, 0, 0, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[AbilityScoreBonus] OFF

SET IDENTITY_INSERT [dbo].[LanguageRaces] ON
INSERT INTO [dbo].[LanguageRaces] ([LanguageRaceID], [LanguageID], [RaceID]) VALUES (4002, 1, 4002)
INSERT INTO [dbo].[LanguageRaces] ([LanguageRaceID], [LanguageID], [RaceID]) VALUES (5002, 1, 5003)
INSERT INTO [dbo].[LanguageRaces] ([LanguageRaceID], [LanguageID], [RaceID]) VALUES (6005, 1, 6003)
INSERT INTO [dbo].[LanguageRaces] ([LanguageRaceID], [LanguageID], [RaceID]) VALUES (4003, 2, 4002)
INSERT INTO [dbo].[LanguageRaces] ([LanguageRaceID], [LanguageID], [RaceID]) VALUES (6006, 2, 6003)
INSERT INTO [dbo].[LanguageRaces] ([LanguageRaceID], [LanguageID], [RaceID]) VALUES (4004, 3, 4002)
INSERT INTO [dbo].[LanguageRaces] ([LanguageRaceID], [LanguageID], [RaceID]) VALUES (5003, 2003, 5003)
INSERT INTO [dbo].[LanguageRaces] ([LanguageRaceID], [LanguageID], [RaceID]) VALUES (5004, 2004, 5003)
INSERT INTO [dbo].[LanguageRaces] ([LanguageRaceID], [LanguageID], [RaceID]) VALUES (6007, 2004, 6003)
SET IDENTITY_INSERT [dbo].[LanguageRaces] OFF

SET IDENTITY_INSERT [dbo].[Languages] ON
INSERT INTO [dbo].[Languages] ([LanguageID], [Name], [Description]) VALUES (1, N'Common', N'Standard Language')
INSERT INTO [dbo].[Languages] ([LanguageID], [Name], [Description]) VALUES (2, N'Elvish', N'Standard Language')
INSERT INTO [dbo].[Languages] ([LanguageID], [Name], [Description]) VALUES (3, N'Dwarvish', N'Standard Language')
INSERT INTO [dbo].[Languages] ([LanguageID], [Name], [Description]) VALUES (2002, N'Abyssal', N'Exotic Language')
INSERT INTO [dbo].[Languages] ([LanguageID], [Name], [Description]) VALUES (2003, N'Celestial', N'Exotic Language')
INSERT INTO [dbo].[Languages] ([LanguageID], [Name], [Description]) VALUES (2004, N'None', N'No More Languages For You')
SET IDENTITY_INSERT [dbo].[Languages] OFF

SET IDENTITY_INSERT [dbo].[Races] ON
INSERT INTO [dbo].[Races] ([RaceID], [Name], [AbilityScoreBonusID], [Size], [SpeedWalk], [SpeedSwim], [SpeedFly], [SpeedClimb], [CreatureType], [BaseRace]) VALUES (4002, N'test', 1003, N'Small', 30, 30, 30, 30, N'Humanoid', 0)
INSERT INTO [dbo].[Races] ([RaceID], [Name], [AbilityScoreBonusID], [Size], [SpeedWalk], [SpeedSwim], [SpeedFly], [SpeedClimb], [CreatureType], [BaseRace]) VALUES (5003, N'Aasimar', 4002, N'Medium', 30, 30, 30, 30, N'Humanoid', 0)
INSERT INTO [dbo].[Races] ([RaceID], [Name], [AbilityScoreBonusID], [Size], [SpeedWalk], [SpeedSwim], [SpeedFly], [SpeedClimb], [CreatureType], [BaseRace]) VALUES (6003, N'test2', 5002, N'small', 30, 30, 30, 30, N'humanoid', 0)
SET IDENTITY_INSERT [dbo].[Races] OFF

SET IDENTITY_INSERT [dbo].[RaceTraits] ON
INSERT INTO [dbo].[RaceTraits] ([RaceTraitID], [RaceID], [TraitID]) VALUES (2, 6003, 2)
SET IDENTITY_INSERT [dbo].[RaceTraits] OFF

SET IDENTITY_INSERT [dbo].[Traits] ON
INSERT INTO [dbo].[Traits] ([TraitID], [Name], [Description]) VALUES (2, N'Celestial Resistance', N'Blessed with a radiant soul, your vision can easily cut through darkness. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can''t discern color in darkness, only shades of gray.')
INSERT INTO [dbo].[Traits] ([TraitID], [Name], [Description]) VALUES (3, N'Darkvision', N'Blessed with a radiant soul, your vision can easily cut through darkness. You can see in dim light within 60 feet of you as if it were bright light, and in darkness as if it were dim light. You can''t discern color in darkness, only shades of gray.')
SET IDENTITY_INSERT [dbo].[Traits] OFF
