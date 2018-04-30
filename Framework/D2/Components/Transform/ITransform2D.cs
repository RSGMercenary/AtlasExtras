﻿using Atlas.Engine.Components;
using Atlas.Engine.Interfaces;

namespace AtlasTesting.Framework.D2.Components.Transform
{
	interface ITransform2D:IComponent, IHierarchy<ITransform2D>
	{
		//bool OverrideEntityHierarchy { get; set; }
	}
}
