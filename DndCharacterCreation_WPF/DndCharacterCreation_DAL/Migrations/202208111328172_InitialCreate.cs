namespace DndCharacterCreation_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbilityScoreBonus",
                c => new
                    {
                        AbilityScoreBonusID = c.Int(nullable: false, identity: true),
                        strength = c.Int(nullable: false),
                        dexterity = c.Int(nullable: false),
                        constitution = c.Int(nullable: false),
                        inteligence = c.Int(nullable: false),
                        wisdom = c.Int(nullable: false),
                        charisma = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AbilityScoreBonusID);
            
            CreateTable(
                "dbo.LanguageRaces",
                c => new
                    {
                        LanguageRaceID = c.Int(nullable: false, identity: true),
                        LanguageID = c.Int(nullable: false),
                        RaceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LanguageRaceID)
                .ForeignKey("dbo.Languages", t => t.LanguageID, cascadeDelete: true)
                .ForeignKey("dbo.Races", t => t.RaceID, cascadeDelete: true)
                .Index(t => new { t.LanguageID, t.RaceID }, unique: true, name: "IX_LanguageIDRaceID");
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.LanguageID);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        RaceID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AbilityScoreBonusID = c.Int(nullable: false),
                        Size = c.String(),
                        SpeedWalk = c.Int(nullable: false),
                        SpeedSwim = c.Int(nullable: false),
                        SpeedFly = c.Int(nullable: false),
                        SpeedClimb = c.Int(nullable: false),
                        CreatureType = c.String(),
                        BaseRace = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RaceID)
                .ForeignKey("dbo.AbilityScoreBonus", t => t.AbilityScoreBonusID, cascadeDelete: true)
                .Index(t => t.AbilityScoreBonusID);
            
            CreateTable(
                "dbo.RaceTraits",
                c => new
                    {
                        RaceTraitID = c.Int(nullable: false, identity: true),
                        RaceID = c.Int(nullable: false),
                        TraitID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RaceTraitID)
                .ForeignKey("dbo.Races", t => t.RaceID, cascadeDelete: true)
                .ForeignKey("dbo.Traits", t => t.TraitID, cascadeDelete: true)
                .Index(t => new { t.RaceID, t.TraitID }, unique: true, name: "IX_RaceIDTraitID");
            
            CreateTable(
                "dbo.Traits",
                c => new
                    {
                        TraitID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TraitID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RaceTraits", "TraitID", "dbo.Traits");
            DropForeignKey("dbo.RaceTraits", "RaceID", "dbo.Races");
            DropForeignKey("dbo.LanguageRaces", "RaceID", "dbo.Races");
            DropForeignKey("dbo.Races", "AbilityScoreBonusID", "dbo.AbilityScoreBonus");
            DropForeignKey("dbo.LanguageRaces", "LanguageID", "dbo.Languages");
            DropIndex("dbo.RaceTraits", "IX_RaceIDTraitID");
            DropIndex("dbo.Races", new[] { "AbilityScoreBonusID" });
            DropIndex("dbo.LanguageRaces", "IX_LanguageIDRaceID");
            DropTable("dbo.Traits");
            DropTable("dbo.RaceTraits");
            DropTable("dbo.Races");
            DropTable("dbo.Languages");
            DropTable("dbo.LanguageRaces");
            DropTable("dbo.AbilityScoreBonus");
        }
    }
}
