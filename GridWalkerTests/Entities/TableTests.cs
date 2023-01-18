using Microsoft.VisualStudio.TestTools.UnitTesting;
using GridWalker.Geometry;

namespace GridWalker.Entities.Tests
{
    [TestClass()]
    public class TableTests
    {
        [TestMethod()]
        public void IsOnTableTest()
        {
            const int widthOfTable = 4;
            const int heightOfTable = 4;
            Table table = new(widthOfTable, heightOfTable);

            // Test table is on itself
            Assert.IsTrue(table.IsOnTable(table));

            // Test that an 1x1 entity is on every cell of the table
            {
                for (var x = 0; x < widthOfTable; x++)
                    for (var y = 0; y < heightOfTable; y++)
                    {
                        Point positionOfEntity = new(x, y);
                        IEntity entity = new Table(1, 1, positionOfEntity);

                        Assert.IsTrue(table.IsOnTable(entity));
                    }
            }

            // Test that an 1x1 entity at the edge of the table (and thus over it) is not on the table
            {
                Point positionOfEntity = new(0, widthOfTable);
                IEntity entity = new Table(1, 1, positionOfEntity);

                Assert.IsFalse(table.IsOnTable(entity));
            }
        }
    }
}