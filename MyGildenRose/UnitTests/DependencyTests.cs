namespace UnitTests
{
    using System.Linq;
    using System.Reflection;
    using MyGildenRose;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void CheckItemClassMovedStillWorks()
        {
            // note :  testing a movement of a file inside the same assembly does not really require a test unless you move item to another assembly
            var main = new Program();
            Assert.NotNull(main);
        }

        /// <summary>
        /// Checks the movement of file from a dependency assembly, so this indicates that that assembly needs an specific resource
        /// May not apply that much moving a Item to a Item.cs file but if this is moved to another project the test will fail
        /// </summary>
        [Fact]
        public void CheckMovementOfFileItemDependency()
        {
            // assembly where you need to get sure of having that resource
            var resourceName = "Item";
            var assemblyName = "MyGildenRose";

            var assembly = Assembly.
                GetExecutingAssembly().
                GetReferencedAssemblies().
                Select(Assembly.Load).
                ToList().
                Single(p => p.FullName.StartsWith(assemblyName));

            var types = assembly.GetTypes();

            var dependencyItemFound = false;

            foreach (var type in types)
            {
                if (type.Name.Equals(resourceName))
                {
                    dependencyItemFound = true;
                    break;
                }
            }

            Assert.True(dependencyItemFound);

        }
    }
}
