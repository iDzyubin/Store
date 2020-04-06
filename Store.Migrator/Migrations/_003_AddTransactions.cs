using ThinkingHome.Migrator.Framework;

namespace Store.Migrator.Migrations
{
    [Migration(3)]
    public class _003_AddTransactions : Migration
    {
        #region ApplyScript

        private string ApplyScript => @"
            create table sd.transactions
            (
                id uuid not null primary key,
                status integer not null default 0,
                create_date_time timestamp without time zone,
                is_canceled boolean not null default false,
                canceled_date_time timestamp without time zone 
            );
            
            alter table sd.sale_items
            add column transaction_id uuid;
            
            alter table sd.sale_items
            add foreign key (transaction_id) references sd.transactions(id);
        ";

        #endregion


        public override void Apply() => Database.ExecuteNonQuery( ApplyScript );


        #region RevertScript

        private string RevertScript => @"
            drop table sd.transactions;
            
            alter table sd.sale_items
            drop column transaction_id;
        ";

        #endregion


        public override void Revert() => Database.ExecuteNonQuery( RevertScript );
    }
}