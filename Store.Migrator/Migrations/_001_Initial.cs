using ThinkingHome.Migrator.Framework;

namespace Store.Migrator.Migrations
{
    [Migration(1)]
    public class _001_Initial : Migration
    {
        #region Script

        private string Script => @"
            create schema if not exists sd;

            create table sd.users
            (
                id         uuid              not null primary key,
                first_name character varying not null,
                last_name  character varying not null,
                email      character varying not null,
                password   character varying not null,
                is_admin   boolean           not null default false
            );

            create table sd.products
            (
                id          uuid              not null primary key,
                title       character varying not null,
                description character varying,
                price       decimal
            );
        ";

        #endregion
        
        public override void Apply() => Database.ExecuteNonQuery(Script);
    }
}