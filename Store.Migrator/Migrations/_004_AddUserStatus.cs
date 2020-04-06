using ThinkingHome.Migrator.Framework;

namespace Store.Migrator.Migrations
{
    [Migration(4)]
    public class _004_AddUserStatus : Migration
    {
        #region ApplyScript

        private string ApplyScript => @"
            alter table sd.users
            add column status integer not null default 0;
        ";

        #endregion


        public override void Apply() => Database.ExecuteNonQuery( ApplyScript );


        #region RevertScript

        private string RevertScript => @"
            alter table sd.users
            drop column status;
        ";

        #endregion


        public override void Revert() => Database.ExecuteNonQuery( RevertScript );
    }
}