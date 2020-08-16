namespace DemoArchitecture.DL.MongoSetting
{
	public interface IDatabaseSetting
	{
		string ConnectionString { get; set; }
		string DatabaseName { get; set; }
	}
}
