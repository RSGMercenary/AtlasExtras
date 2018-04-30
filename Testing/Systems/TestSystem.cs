﻿using Atlas.Engine.Entities;
using Atlas.Engine.Systems;
using AtlasTesting.Testing.Components;
using AtlasTesting.Testing.Families;
using System.Diagnostics;

namespace AtlasTesting.Testing.Systems
{
	class TestSystem : AtlasFamilySystem<TestFamily>, ITestSystem
	{
		private float updateCount = 0;

		public TestSystem()
		{
			UpdateMode = UpdatePhase.Update;
			Initialize(UpdateEntity);
		}

		protected override void Updating(double deltaTime)
		{
			updateCount = (float)deltaTime;
			Debug.WriteLine(GetType().Name + " Update " + (updateCount));
			base.Updating(deltaTime);
		}

		private void UpdateEntity(double deltaTime, IEntity entity)
		{
			Debug.WriteLine(entity.GlobalName);
			if(entity.GlobalName == "0-3-0")
			{
				entity.RemoveComponent<TestComponent>();
			}
		}
	}
}