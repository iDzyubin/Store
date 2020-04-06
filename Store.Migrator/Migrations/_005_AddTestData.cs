using ThinkingHome.Migrator.Framework;

namespace Store.Migrator.Migrations
{
    [Migration( 5 )]
    public class _005_AddTestData : Migration
    {
        #region ApplyScript

        private string ApplyScript => @"
            insert into sd.users
            values ('18f8b625-a734-42f1-ae14-e34d6f325cb6', 'Админ', 'Админ', 'admin@admin.com', '6apSvuZX9hh2GgguiSe0gs1LPrKLNRI2xX/ms8O7o5TvOwnh', true, 1);
            
            insert into sd.users
            values ('14e9c0c3-35ae-4397-8ff7-e604e2d8472c', 'Бетмен', 'Джокеров', 'batman@batsy.com', '0S/WyG+5Uw0e0K4R2mJ0Gf88FnrJ0UfdDontJNyevRIxe4lx', false, 1);
            
            insert into sd.products
            values ('a602f04c-cdc0-4c58-ba29-4ce848a97b67', 'Масочки', 'Масочки бомбические. Против любой короны и вируса.', 20);
            
            insert into sd.products
            values ('0c959192-7f6a-45f8-90a4-b4a7b4ca2ed1', 'Нашатырчик', 'Если где-то поплохело, личико все побелело, в глазах краски порябели, занюхните нашатырчик.', 15);
            
            insert into sd.products
            values ('658001fb-1034-4947-96e6-af0150ab8193', 'Боярышник', 'Для настоящих бояр и барыней.', 30);
            
            insert into sd.products
            values ('28e4d3f0-6c52-4f93-94ba-fdc8c39a1c4c', 'ФерроГематоген', 'Тот самый гематоген. С ежиком.', 20);
        ";

        #endregion

        public override void Apply() => Database.ExecuteNonQuery( ApplyScript );

        
        #region RevertScript

        private string RevertScript => @"
            delete from sd.users;
            
            delete from sd.products;
        ";

        #endregion

        public override void Revert() => Database.ExecuteNonQuery( RevertScript );
    }
}