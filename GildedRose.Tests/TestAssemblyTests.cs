using System.Collections.Generic;
using GildedRose.Console;
using Microsoft.VisualStudio.TestPlatform.TestHost;
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
        [Fact]
        public void Brie_going_from_2_to_1_days_left_should_increase_quality_by_two()
        {
            // Arrange
            GildedRose.Console.Program p = new GildedRose.Console.Program();

            // Act
            p.UpdateQuality();

            // Assert
            Assert.Equal(1, p.Items[1].Quality);
            Assert.Equal(1, p.Items[1].SellIn);
        }
        
        [Theory]
        [InlineData(0, 100, -90, )]
        [InlineData(0, 0, , )]
        [InlineData(0, 1, , )]
        [InlineData(2, 100, -95, 0)]
        [InlineData(2, 0, 5, 7)]
        [InlineData(2, 1, 4, 6)]
        public void Generic_item_aging_progresses_correctly(int itemIndex, int iterations, int expectedSellIn, int expectedQuality)
        {
            //Act
            for (int i = 0; i < iterations; i++)
            {
                _program.UpdateQuality();
            }
            
            //Assert
            Assert.Equal(expectedSellIn, _program.Items[itemIndex].SellIn);
            Assert.Equal(expectedSellIn, _program.Items[itemIndex].Quality);
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
        public void Sulfuras_should_not_age_nor_decrease_in_quality(int iterations, int expectedSellIn, int expectedQuality)
        {
            //Act
            for (int i = 0; i < iterations; i++)
            {
                _program.UpdateQuality();
            }
                
            //Assert
            Assert.Equal(expectedSellIn, _program.Items[5].SellIn);
            Assert.Equal(expectedQuality, _program.Items[5].Quality);
        }
        
        
        
        
        
        [Theory]
        [InlineData(0, 15, 20] //Original item
        [InlineData(0, 15, 20] //"Quality increases by 2 when there are 10 days or less
        public void Backstage_passes_quality_updates_correctly(int iterations, int expectedSellIn, int expectedQUality){
            //Act
            for (int i = 0; i < iterations; i++)
                    {
                        _program.UpdateQuality();
                     }
                
            //Assert
            Assert.Equal(expectedSellIn, _program.Items[5].SellIn);
            Assert.Equal(expectedQUality, _program.Items[5].Quality);
        
        
        }
        

    }
}