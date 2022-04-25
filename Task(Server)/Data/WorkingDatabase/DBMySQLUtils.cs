using Microsoft.EntityFrameworkCore;
using System;
using Task_Data_.Entities;

namespace Task_Server_.Data.WorkingDatabase
{
    class DBMySQLUtils : DbContext
    {
        public DbSet<tusers> tusers { get; set; }
        public DbSet<tfriends> tfriends { get; set; }
        public DbSet<tmessages> tmessages { get; set; }
        public DbSet<tauthorized> tauthorized { get; set; }
        public DbSet<tgroups> tgroups { get; set; }
        public DbSet<tgroups_thematics> tgroups_thematics { get; set; }
        public DbSet<tgroups_members> tgroups_members { get; set; }
        public DbSet<tgroups_members_status> tgroups_members_status { get; set; }
        public DbSet<tgroups_post> tgroups_post { get; set; }
        public DbSet<members_group> members_group { get; set; }
        public DbSet<tusers_group_chat> tusers_group_chat { get; set; }
        public DbSet<tmessages_group_chat> tmessages_group_chat { get; set; }
        public DbSet<tevent> tevent { get; set; }
        public DbSet<tfriends_status> tfriends_status { get; set; }
        public DbSet<tgroups_post_comments> tgroups_post_comments { get; set; }
        public DbSet<tusers_position> tusers_position { get; set; }

        public DBMySQLUtils()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
    "server=127.0.0.1;Port=3306;user=Andrey;password=2012;database=taskcoursework;",
    new MySqlServerVersion(new Version(8, 0, 24))
            );
        }
    }
}
