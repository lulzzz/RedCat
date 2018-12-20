namespace Infrastructure.Database.Migrations.Migrator
{
    public interface IDatabaseMigrator
    {
		void Migrate (string connectionString, string location, bool isisDropAllowed);
    }
}
