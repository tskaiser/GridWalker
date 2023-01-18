using GridWalker.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GridWalker.Entities.Tests
{
    [TestClass()]
    public class WalkerTests
    {
        [TestMethod()]
        public void MoveForwardTest()
        {
            Point startPosition = new(4, 4);

            // Test that a walker with a given heading will move one cell in that direction
            foreach (Compass heading in Enum.GetValues(typeof(Compass)))
            {
                Walker walker = new(startPosition, heading);

                Assert.IsTrue(walker.Position.Equals(startPosition));
                walker.MoveForward();
                Assert.IsTrue(walker.Position.Equals(startPosition + heading.UnitDirection()));
            }
        }

        [TestMethod()]
        public void MoveBackwardTest()
        {
            Point startPosition = new(4, 4);

            // Test that a walker with a given heading will move one cell in the opposite direction
            foreach (Compass heading in Enum.GetValues(typeof(Compass)))
            {
                Walker walker = new(startPosition, heading);

                Assert.IsTrue(walker.Position.Equals(startPosition));
                walker.MoveBackward();
                Assert.IsTrue(walker.Position.Equals(startPosition - heading.UnitDirection()));
            }
        }

        [TestMethod()]
        public void TurnRightTest()
        {
            Point startPosition = new(4, 4);

            // Test that turning a walker right will make its new heading the next clockwise heading
            foreach (Compass heading in Enum.GetValues(typeof(Compass)))
            {
                Walker walker = new(startPosition, heading);

                Assert.IsTrue(walker.Heading == heading);
                walker.TurnRight();
                Assert.IsTrue(walker.Heading == heading.Clockwise());
            }
        }

        [TestMethod()]
        public void TurnLeftTest()
        {
            Point startPosition = new(4, 4);

            // Test that turning a walker left will make its new heading the next counterclockwise heading
            foreach (Compass heading in Enum.GetValues(typeof(Compass)))
            {
                Walker walker = new(startPosition, heading);

                Assert.IsTrue(walker.Heading == heading);
                walker.TurnLeft();
                Assert.IsTrue(walker.Heading == heading.Counterclockwise());
            }
        }
    }
}