using Atlas.Core.Objects.Update;
using Atlas.ECS.Components.Engine;
using Atlas.ECS.Components.SystemManager;
using Atlas.ECS.Entities;
using AtlasTesting.Testing.Components;
using AtlasTesting.Testing.Systems;
using System;
using System.Diagnostics;

namespace AtlasTesting
{
	static public class Program
	{
		private static IEntity root;

		[STAThread]
		static void Main()
		{
			//LineCounter.FileLines();
			//LineCounter.FolderLines(70, 4, true);

			root = new AtlasEntity(true);

			var engine = root.AddComponent<IEngine, JsonEngine>();

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

			Debug.WriteLine(engine.Entities);

			new Updater(engine).IsRunning = true;
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