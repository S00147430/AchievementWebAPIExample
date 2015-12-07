namespace AchievevementWebAPIExample.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<AchievevementWebAPIExample.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "cgMonoGameServer2015.Models.ApplicationDbContext";
        }
        int _usercounter = 0;
        public int Counter { get { return _usercounter++; } }

        int _emailCounter = 0;
        public int EmailCounter { get { return _emailCounter++; } }

        protected override void Seed(AchievevementWebAPIExample.Models.ApplicationDbContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Games.AddOrUpdate(g => g.GameName,
                new Game { GameName = "Battle Call" },
                new Game { GameName = "Pong" });

            context.SaveChanges();

            Random r = new Random();
            PasswordHasher hasher = new PasswordHasher();
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    XP = r.Next(400),
                    UserName = "User " + Counter.ToString() + "@itsligo.ie",
                    Email = "User " + EmailCounter.ToString() + "@itsligo.ie",
                    EmailConfirmed = true,
                    GamerTag = "GamerTag" + _usercounter.ToString(), 
                    PasswordHash = hasher.HashPassword("GamerTag" + _usercounter.ToString()),
                    
                },
                new ApplicationUser
                {
                    XP = r.Next(400),
                    UserName = "User " + Counter.ToString() + "@itsligo.ie",
                    Email = "User " + EmailCounter.ToString() + "@itsligo.ie",
                    EmailConfirmed = true,
                    GamerTag = "GamerTag" + _usercounter.ToString(),
                    PasswordHash = hasher.HashPassword("GamerTag" + _usercounter.ToString()),
                },
                new ApplicationUser
                {
                    XP = r.Next(400),
                    UserName = "User " + Counter.ToString() + "@itsligo.ie",
                    Email = "User " + EmailCounter.ToString() + "@itsligo.ie",
                    EmailConfirmed = true,
                    GamerTag = "GamerTag" + _usercounter.ToString(),
                    PasswordHash = hasher.HashPassword("GamerTag" + _usercounter.ToString()),
                },
                new ApplicationUser
                {
                    XP = r.Next(400),
                    UserName = "User " + Counter.ToString() + "@itsligo.ie",
                    Email = "User " + EmailCounter.ToString() + "@itsligo.ie",
                    EmailConfirmed = true,
                    GamerTag = "GamerTag" + _usercounter.ToString(),
                    PasswordHash = hasher.HashPassword("GamerTag" + _usercounter.ToString()),
                },
                new ApplicationUser {
                XP = r.Next(400),
                    UserName = "User " + Counter.ToString() + "@itsligo.ie",
                    Email = "User " + EmailCounter.ToString() + "@itsligo.ie",
                    EmailConfirmed = true,
                    GamerTag = "GamerTag" + _usercounter.ToString(),
                    PasswordHash = hasher.HashPassword("GamerTag" + _usercounter.ToString()),
                },
                new ApplicationUser
                {
                    XP = r.Next(400),
                    UserName = "User " + Counter.ToString() + "@itsligo.ie",
                    Email = "User " + EmailCounter.ToString() + "@itsligo.ie",
                    EmailConfirmed = true,
                    GamerTag = "GamerTag" + _usercounter.ToString(),
                    PasswordHash = hasher.HashPassword("GamerTag" + _usercounter.ToString()),
                },
                new ApplicationUser
                {
                    XP = r.Next(400),
                    UserName = "User " + Counter.ToString() + "@itsligo.ie",
                    Email = "User " + EmailCounter.ToString() + "@itsligo.ie",
                    EmailConfirmed = true,
                    GamerTag = "GamerTag" + _usercounter.ToString(),
                    PasswordHash = hasher.HashPassword("GamerTag" + _usercounter.ToString()),
                },
                new ApplicationUser
                {
                    XP = r.Next(400),
                    UserName = "User " + Counter.ToString() + "@itsligo.ie",
                    Email = "User " + EmailCounter.ToString() + "@itsligo.ie",
                    EmailConfirmed = true,
                    GamerTag = "GamerTag" + _usercounter.ToString(),
                    PasswordHash = hasher.HashPassword("GamerTag" + _usercounter.ToString()),
                }
                );
            context.SaveChanges();

            List<GameScore> scores = new List<GameScore>();
            Game bg = context.Games.FirstOrDefault(battle => battle.GameName == "Battle Call");
            if (bg != null)
            {
                foreach(ApplicationUser player in context.Users)
                {
                    //context.GameScores.AddOrUpdate(score => score.PlayerID,
                       scores.Add(new GameScore
                       { PlayerID = player.Id,
                           score = r.Next(1200),
                           GameID = bg.GameID }
                       );
                }
                context.GameScores.AddOrUpdate(score => score.PlayerID,
                    scores.ToArray());

                context.SaveChanges();


                Achievement[] achievements = new Achievement[14];
                for(int i = 0; i < 14; i++)
                {
                    achievements[i] = new Achievement { Name = "Badges_" + i.ToString() };
                }

                context.Achievements.AddOrUpdate(a => a.Name, achievements);

                context.SaveChanges();

                List<PlayerAchievement> _playerAchievments = new List<PlayerAchievement>();
                foreach (ApplicationUser player in context.Users)
                {
                    var acs = (from ps in context.Achievements
                               select new
                               {
                                   ps.ID,
                                   localid = Guid.NewGuid()
                               }).OrderBy(q => q.localid).ToList();

                    var topFiveAchievements = acs.Select(ac => ac.ID).Take(5);

                    foreach(var achievementID in topFiveAchievements)
                    {
                        _playerAchievments.Add(new PlayerAchievement { PlayerID = player.Id, AchievementID = achievementID });
                        //context.PlayerAchievements.AddOrUpdate(
                        //    new PlayerAchievement { PlayerID = player.Id, AchievementID = achievementID });
                    }
                }

                context.PlayerAchievements.AddOrUpdate(
                    rep => new { rep.PlayerID, rep.AchievementID },
                    _playerAchievments.ToArray());
                foreach(ApplicationUser player in context.Users)
                {                    

                }
            }

        }
    }
}
