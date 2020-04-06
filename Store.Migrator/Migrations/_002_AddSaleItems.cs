using ThinkingHome.Migrator.Framework;

namespace Store.Migrator.Migrations
{
    [Migration( 2 )]
    public class _002_AddSaleItems : Migration
    {
        #region ApplyScript

        private string ApplyScript => @"
            create table sd.sale_items
            (
                id         uuid    not null primary key,
                product_id uuid    not null,
                user_id    uuid    not null,
                count      integer not null default 0,
                status     integer not null default 0,
                foreign key (user_id)    references sd.users(id),
                foreign key (product_id) references sd.products(id)
            );
        ";

        #endregion


        public override void Apply() => Database.ExecuteNonQuery( ApplyScript );


        #region RevertScript

        private string RevertScript = @"
            drop table sd.sale_items;
        ";

        #endregion


        public override void Revert() => Database.ExecuteNonQuery( RevertScript );
    }
}