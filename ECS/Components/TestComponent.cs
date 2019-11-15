using Atlas.ECS.Components.Component;

namespace AtlasTesting.ECS.Components
{
	class TestComponent : AtlasComponent<ITestComponent>, ITestComponent
	{
		/*
		protected override void SetToStringProperties(Queue<KeyValuePair<string, string>> properties)
		{
			properties.Enqueue(new KeyValuePair<string, string>("X", "2"));
			base.SetToStringProperties(properties);
		}
		*/
	}
}
