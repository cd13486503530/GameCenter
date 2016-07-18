using GameCenter.Entity.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenter.Data
{
    public class PortalContext : DbContext
    {
        static PortalContext()
        { 
            //在很多时候，我们希望即使在Entity Framework Code First与数据库不匹配时，宁可Entity Framework Code First报出数据库连接错误，而不希望对数据库进行任何的删除创建操作。Entity Framework Code First提供关闭数据库初始化操作：
            Database.SetInitializer<PortalContext>(null);
            //Database.SetInitializer(new CreateDatabaseIfNotExists<PortalContext>()); //数据库的默认方式，用于当数据库不存在时，自动创建数据库。由于该方式是默认方式，所以可以不需要任何代码进行指定，当然也可以使用代码来明确的指定。
            //Database.SetInitializer(new DropCreateDatabaseAlways<PortalContext>());//用于当数据模型发生改变时，先删除原数据库，后创建新的数据库。
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PortalContext>());//用于每次均先删除原数据库再创建新的数据库，不管数据模型是否发生改变。
        }

        public PortalContext()
            : base("name=GameDBConnection")
        {
            // 禁用延迟加载
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<GameImages> GameImages { get; set; }

        public virtual DbSet<GameInfo> GameInfos { get; set; }

        public virtual DbSet<Menu> Menus { get; set; }

        public virtual DbSet<MenuInformation> MenuInformations { get; set; }

        public virtual DbSet<News> News { get; set; }

        public virtual DbSet<NewsType> NewsTypes { get; set; }

        public virtual DbSet<Partner> Partners { get; set; }

        public virtual DbSet<AdminUser> AdminUsers { get; set; }

        public virtual DbSet<PrivatePage> PrivatePages { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 禁用一对多级联删除
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // 禁用多对多级联删除
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // 禁用默认表名复数形式
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
