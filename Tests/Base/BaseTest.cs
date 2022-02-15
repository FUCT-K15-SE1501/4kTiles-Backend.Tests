using System;
using System.Collections.Generic;

using _4kTiles_Backend.Context;
using _4kTiles_Backend.Entities;
using _4kTiles_Backend.Helpers;

using Microsoft.EntityFrameworkCore;

namespace _4kTiles_Backend.Tests.Tests.Base
{
    public static class BaseTest
    {
        public static ApplicationDbContext Context { get; private set; }

        public static List<Account> Accounts { get; set; }
        public static List<Role> Roles { get; set; }
        public static List<Song> Songs { get; set; }
        public static List<Tag> Tags { get; set; }
        public static List<Genre> Genres { get; set; }
        public static List<AccountSong> AccountSongs { get; set; }
        public static List<AccountRole> AccountRoles { get; set; }
        public static List<SongReport> SongReports { get; set; }
        public static List<SongTag> SongTags { get; set; }
        public static List<SongGenre> SongGenres { get; set; }

        private static readonly object Locker = new object();


        static BaseTest()
        {
            lock (Locker)
            {
                if (Context != null) return;
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccountId = 1,
                        UserName = "TestUser1",
                        Email = "email1@email.com",
                        HashedPassword = "hashedPassword1".Hash(),
                    },
                    new Account()
                    {
                        AccountId = 2,
                        UserName = "TestUser2",
                        Email = "email2",
                        HashedPassword = "hashedPassword2".Hash(),
                    },
                    new Account()
                    {
                        AccountId = 3,
                        UserName = "TestUser3",
                        Email = "email3",
                        HashedPassword = "hashedPassword3".Hash(),
                    },
                    new Account()
                    {
                        AccountId = 4,
                        UserName = "TestUser4",
                        Email = "email4",
                        HashedPassword = "hashedPassword4".Hash(),
                    },
                };

                Roles = new List<Role>()
                {
                    new Role() {RoleId = 1, RoleName = "Admin",}, new Role() {RoleId = 2, RoleName = "User",},
                };

                AccountRoles = new List<AccountRole>()
                {
                    new AccountRole() {ArId = 1, AccountId = 1, RoleId = 1,},
                    new AccountRole() {ArId = 2, AccountId = 2, RoleId = 2,},
                    new AccountRole() {ArId = 3, AccountId = 3, RoleId = 2,},
                    new AccountRole() {ArId = 4, AccountId = 4, RoleId = 1,},
                };

                Songs = new List<Song>()
                {
                    new Song()
                    {
                        SongId = 1,
                        SongName = "Song1",
                        Author = "Author1",
                        Bpm = 120,
                        Notes = "Notes1",
                        ReleaseDate = DateTime.Now,
                        IsPublic = true,
                        IsDeleted = false,
                        DeletedReason = null,
                    },
                    new Song()
                    {
                        SongId = 2,
                        SongName = "Song2",
                        Author = "Author2",
                        Bpm = 120,
                        Notes = "Notes2",
                        ReleaseDate = DateTime.Now,
                        IsPublic = true,
                        IsDeleted = false,
                        DeletedReason = null,
                    },
                    new Song()
                    {
                        SongId = 3,
                        SongName = "Song3",
                        Author = "Author3",
                        Bpm = 120,
                        Notes = "Notes3",
                        ReleaseDate = DateTime.Now,
                        IsPublic = true,
                        IsDeleted = false,
                        DeletedReason = null,
                    },
                    new Song()
                    {
                        SongId = 4,
                        SongName = "Song4",
                        Author = "Author4",
                        Bpm = 120,
                        Notes = "Notes4",
                        ReleaseDate = DateTime.Now,
                        IsPublic = true,
                        IsDeleted = false,
                        DeletedReason = null,
                    },
                    new Song()
                    {
                        SongId = 5,
                        SongName = "Song5",
                        Author = "Author5",
                        Bpm = 120,
                        Notes = "Notes5",
                        ReleaseDate = DateTime.Now,
                        IsPublic = true,
                        IsDeleted = false,
                        DeletedReason = null,
                    }
                };

                Genres = new List<Genre>()
                {
                    new Genre() {GenreId = 1, GenreName = "Genre1",},
                    new Genre() {GenreId = 2, GenreName = "Genre2",},
                    new Genre() {GenreId = 3, GenreName = "Genre3",},
                    new Genre() {GenreId = 4, GenreName = "Genre4",},
                    new Genre() {GenreId = 5, GenreName = "Genre5",},
                };

                Tags = new List<Tag>()
                {
                    new Tag() {TagId = 1, TagName = "Tag1",},
                    new Tag() {TagId = 2, TagName = "Tag2",},
                    new Tag() {TagId = 3, TagName = "Tag3",},
                    new Tag() {TagId = 4, TagName = "Tag4",},
                    new Tag() {TagId = 5, TagName = "Tag5",},
                };

                SongTags = new List<SongTag>()
                {
                    new SongTag() {StId = 1, SongId = 1, TagId = 1,},
                    new SongTag() {StId = 2, SongId = 2, TagId = 2,},
                    new SongTag() {StId = 3, SongId = 3, TagId = 3,},
                    new SongTag() {StId = 4, SongId = 4, TagId = 4,},
                    new SongTag() {StId = 5, SongId = 5, TagId = 5,},
                };

                SongGenres = new List<SongGenre>()
                {
                    new SongGenre() {SgId = 1, SongId = 1, GenreId = 1,},
                    new SongGenre() {SgId = 2, SongId = 2, GenreId = 2,},
                    new SongGenre() {SgId = 3, SongId = 3, GenreId = 3,},
                    new SongGenre() {SgId = 4, SongId = 4, GenreId = 4,},
                    new SongGenre() {SgId = 5, SongId = 5, GenreId = 5,},
                };

                AccountSongs = new List<AccountSong>()
                {
                    new AccountSong()
                    {
                        AsId = 1, AccountId = 1, SongId = 1, BestScore = 100,

                    },
                    new AccountSong()
                    {
                        AsId = 2, AccountId = 2, SongId = 1, BestScore = 100,
                    },
                    new AccountSong()
                    {
                        AsId = 3, AccountId = 3, SongId = 3, BestScore = 100,
                    },
                    new AccountSong()
                    {
                        AsId = 4, AccountId = 4, SongId = 4, BestScore = 100,
                    },
                    new AccountSong()
                    {
                        AsId = 5, AccountId = 5, SongId = 5, BestScore = 100,
                    },
                };

                SongReports = new List<SongReport>()
                {
                    new SongReport()
                    {
                        ReportId = 1,
                        SongId = 1,
                        AccountId = 1,
                        ReportTitle = "Report1",
                        ReportReason = "ReportReason1",
                        ReportDate = DateTime.Now,
                        ReportStatus = false,
                    },
                    new SongReport()
                    {
                        ReportId = 2,
                        SongId = 2,
                        AccountId = 2,
                        ReportTitle = "Report2",
                        ReportReason = "ReportReason2",
                        ReportDate = DateTime.Now,
                        ReportStatus = false,
                    },
                    new SongReport()
                    {
                        ReportId = 3,
                        SongId = 3,
                        AccountId = 3,
                        ReportTitle = "Report3",
                        ReportReason = "ReportReason3",
                        ReportDate = DateTime.Now,
                        ReportStatus = false,
                    },
                    new SongReport()
                    {
                        ReportId = 4,
                        SongId = 4,
                        AccountId = 4,
                        ReportTitle = "Report4",
                        ReportReason = "ReportReason4",
                        ReportDate = DateTime.Now,
                        ReportStatus = true,
                    },
                    new SongReport()
                    {
                        ReportId = 5,
                        SongId = 5,
                        AccountId = 5,
                        ReportTitle = "Report5",
                        ReportReason = "ReportReason5",
                        ReportDate = DateTime.Now,
                        ReportStatus = true,
                    },
                };

                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "4kTiles_Backend_TestDb")
                    .Options;

                var context = new ApplicationDbContext(options);
                Context = context;

                // add account data
                context.Accounts.AddRange(Accounts);

                // add role data
                context.Roles.AddRange(Roles);

                // add account role data
                context.AccountRoles.AddRange(AccountRoles);

                // add song data
                context.Songs.AddRange(Songs);

                // add genre data
                context.Genres.AddRange(Genres);

                // add tag data
                context.Tags.AddRange(Tags);

                // add song tag data
                context.SongTags.AddRange(SongTags);

                // add song genre data
                context.SongGenres.AddRange(SongGenres);

                // add account song data
                context.AccountSongs.AddRange(AccountSongs);

                // add song report data
                context.SongReports.AddRange(SongReports);

                context.SaveChanges();
            }
        }
    }
}