using Atlas.ECS.Systems;
using AtlasTesting.Testing.Components;
using AtlasTesting.Testing.Families;
using System.Diagnostics;

namespace AtlasTesting.Testing.Systems
{
	class TestSystem1 : AtlasFamilySystem<TestMember>, ITestSystem1
	{
		public TestSystem1()
		{
			Priority = -1000;
			DeltaIntervalTime = 5;
		}

		protected override void FamilyUpdate(float deltaTime)
		{
			Debug.WriteLine($"{GetType().Name} Update");
			base.FamilyUpdate(deltaTime);
		}

		override protected void MemberUpdate(float deltaTime, TestMember member)
		{
			Debug.WriteLine(member.Entity.GlobalName);
			//member.Entity.Parent.RemoveSystem<ITestSystem1>();
			if(member.Entity.GlobalName.Contains("-3"))
			{
				member.Entity.RemoveComponent<ITestComponent>();
			}
		}
	}
}
