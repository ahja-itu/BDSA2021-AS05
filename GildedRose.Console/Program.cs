using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;

        public Program()
        {
            Items = new List<Item>
            {
                new NormalItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Brie {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new NormalItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new LegendaryItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new BackstagePasses
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new ConjuredItem {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program();

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.UpdateQuality();
            }
        }
        
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }


        // goblin pls no be mad
        public virtual void UpdateQuality()
        {
            // Do nothing, such that in the case of the future Sufuras class
            // is covered
        }
    }


    public class NormalItem : Item
        {
            public override void UpdateQuality()
            {
                SellIn--;

                if (SellIn < 0)
                {
                    Quality -= 2;
                }
                else
                {
                    Quality--;
                }

                if (Quality < 0)
                {
                    Quality = 0;
                }
            }
        }

        public class Brie : Item
        {
            public override void UpdateQuality()
            {
                SellIn--;
                if (Quality < 50)
                {
                    Quality++;
                }
            }
        }

        public class BackstagePasses : Item
        {
            public override void UpdateQuality()
            {
                if (SellIn < 0)
                {
                    Quality = 0;
                }
                else if (SellIn < 6)
                {
                    Quality += 3;
                }
                else if (SellIn < 11)
                {
                    Quality += 2;
                }
                else
                {
                    Quality++;
                }

                SellIn--;

                if (Quality > 50)
                {
                    Quality = 50;
                }
            }
        }


        public class LegendaryItem : Item { }

        public class ConjuredItem : Item
        {
            public override void UpdateQuality()
            {
                SellIn--;
                if (SellIn < 0)
                {
                    Quality -= 4;
                }
                else
                {
                    Quality -= 2;
                }

                if (Quality < 0)
                {
                    Quality = 0;
                }
            }
        }
    }
