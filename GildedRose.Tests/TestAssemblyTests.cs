using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        private GildedRose.Console.Program _program;

        public TestAssemblyTests()
        {
            _program = new GildedRose.Console.Program();
        }

        [Theory]
        [InlineData(0, 100, -90, 0)]
        [InlineData(0, 0, 10, 20)]
        [InlineData(0, 1, 9, 19)]
        [InlineData(0, 12, -2, 6)]
        [InlineData(2, 100, -95, 0)]
        [InlineData(2, 0, 5, 7)]
        [InlineData(2, 1, 4, 6)]
        [InlineData(2, 5, 0, 2)]
        [InlineData(2, 6, -1, 0)]
        public void Generic_item_aging_progresses_correctly(int itemIndex, int iterations, int expectedSellIn,
            int expectedQuality)
        {
            //Act
            for (int i = 0; i < iterations; i++)
            {
                _program.UpdateQuality();
            }

            //Assert
            Assert.Equal(expectedSellIn, _program.Items[itemIndex].SellIn);
            Assert.Equal(expectedQuality, _program.Items[itemIndex].Quality);
        }

        [Theory]
        [InlineData(0, 2, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(55, -53, 50)]
        public void Brie_aging_progresess_correctly(int iterations, int expectedSellIn, int expectedQuality)
        {
            //Act
            for (int i = 0; i < iterations; i++)
            {
                _program.UpdateQuality();
            }

            //Assert
            Assert.Equal(expectedSellIn, _program.Items[1].SellIn);
            Assert.Equal(expectedQuality, _program.Items[1].Quality);
        }


        [Theory]
        [InlineData(0, 0, 80)]
        [InlineData(1, 0, 80)]
        [InlineData(100, 0, 80)]
        [InlineData(1000, 0, 80)]
        public void Sulfuras_should_not_age_nor_decrease_in_quality(int iterations, int expectedSellIn,
            int expectedQuality)
        {
            //Act
            for (int i = 0; i < iterations; i++)
            {
                _program.UpdateQuality();
            }

            //Assert
            Assert.Equal(expectedSellIn, _program.Items[3].SellIn);
            Assert.Equal(expectedQuality, _program.Items[3].Quality);
        }

        [Theory]
        [InlineData(0, 15, 20)] //Original item
        [InlineData(1, 14, 21)] //Quality increases
        [InlineData(6, 9, 27)] //"Quality increases by 2 when there are 10 days or less
        [InlineData(11, 4, 38)] //"Quality increases by 3 when there are 5 days or less
        public void Backstage_passes_quality_updates_correctly(int iterations, int expectedSellIn, int expectedQUality)
        {
            //Act
            for (int i = 0; i < iterations; i++)
            {
                _program.UpdateQuality();
            }

            //Assert
            Assert.Equal(expectedSellIn, _program.Items[4].SellIn);
            Assert.Equal(expectedQUality, _program.Items[4].Quality);
        }
        
        
        [Theory]
        [InlineData(5, 0, 3, 6)]
        [InlineData(5, 1, 2, 4)]
        [InlineData(5, 2, 1, 2)]
        [InlineData(5, 3, 0, 0)]
        [InlineData(5, 100, -97, 0)]
        public void Conjured(int itemIndex, int iterations, int expectedSellIn,
            int expectedQuality)
        {
            //Act
            for (int i = 0; i < iterations; i++)
            {
                _program.UpdateQuality();
            }

            //Assert
            Assert.Equal(expectedSellIn, _program.Items[itemIndex].SellIn);
            Assert.Equal(expectedQuality, _program.Items[itemIndex].Quality);
        }
    }
}