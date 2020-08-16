namespace DemoArchitecture.DL.MongoSetting
{
	public class MongoSettings : IDatabaseSetting
	{
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
	}
}
