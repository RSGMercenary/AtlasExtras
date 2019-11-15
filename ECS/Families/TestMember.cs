using Atlas.ECS.Families;
using AtlasTesting.ECS.Components;

namespace AtlasTesting.ECS.Families
{
	class TestMember : AtlasFamilyMember
	{
		public ITestComponent Test { get; }
	}
}
