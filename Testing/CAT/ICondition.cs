namespace AtlasTesting.Testing.CAT
{
	interface ICondition
	{
		bool Not { get; set; }

		bool IsTrue { get; }
	}
}
