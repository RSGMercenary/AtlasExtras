using Atlas.ECS.Components;
using Atlas.ECS.Entities;
using Atlas.ECS.Objects;
using AtlasTesting.Testing.Components;
using AtlasTesting.Testing.Systems;
using System.Diagnostics;

namespace AtlasTesting
{
	static public class Program
	{
		static void Main(string[] args)
		{
			var root = new AtlasEntity(true);
			var engine = root.AddComponent<IEngine, JsonEngine>(new JsonEngine());
			EngineUpdater updater = new EngineUpdater(engine.Update);

			for(int index1 = 1; index1 <= 5; ++index1)
			{
				string name = index1.ToString();
				var depth1 = root.AddChild(name, name);
				depth1.AddComponent<ISystemManager>(new SystemManager(typeof(ITestSystem1)));
				for(int index2 = 1; index2 <= 5; ++index2)
				{
					name = index1 + "-" + index2;
					var depth2 = depth1.AddChild(name, name);
					depth2.AddComponent<ITestComponent, TestComponent>();

				}
			}

			//AddChildren(root, 5, 5);
			Debug.WriteLine(root.DescendantsToString(-1, false));

			// var entity = engine.GetEntity("Root-4-0-0");
			// entity.Message<IMessage<IEntity>>(new Message<IEntity>(entity),
			// MessageFlow.Root | MessageFlow.Child);

			//updater.IsRunning = true;
		}

		public static void AddChildren(IEntity parent, int children, int depth)
		{
			if(0 == depth--)
				return;
			for(var i = 0; i < children; ++i)
				AddChildren(parent.AddChild(parent.GlobalName + "-" + i), children, depth);
		}
	}
}