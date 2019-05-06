using Atlas.ECS.Families;
using AtlasTesting.Testing.Components;

namespace AtlasTesting.Testing.Families
{
    class TestMember : AtlasFamilyMember
    {
        public ITestComponent Test { get; }
    }
}
