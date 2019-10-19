using Atlas.ECS.Systems;
using AtlasTesting.Testing.Components;
using AtlasTesting.Testing.Families;
using System.Diagnostics;

namespace AtlasTesting.Testing.Systems
{
	class TestSystem2 : AtlasFamilySystem<TestMember>, ITestSystem2
	{
		public TestSystem2()
		{
			Priority = 1000;
			DeltaIntervalTime = 5;
		}

		protected override void SystemUpdate(float deltaTime)
		{
			Debug.WriteLine(GetType().Name + " " + DeltaIntervalTime);
			base.SystemUpdate(deltaTime);
		}

		override protected void MemberUpdate(float deltaTime, TestMember member)
		{
			//Debug.WriteLine(member.Entity.GlobalName);
			if(member.Entity.GlobalName.Contains("-3"))
			{
				member.Entity.RemoveComponent<ITestComponent>();
			}
		}

	}
}
