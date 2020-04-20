namespace MyGildenRose.Data
{
    using System.Collections.Generic;
    using MyGildenRose.Constants;
    using MyGildenRose.ExtensionMethods;


    /// <summary>
    /// Because of question of demo Ioc is not really necessary although it could be implemented
    /// </summary>
    public static class RepositoryItems
    {
        public static IList<Item> GetItems()
        {
            var itemsList = new List<Item>()
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
            };

            return itemsList;
        }

        public static void UpdateQuality(Item item)
        {
            if (item.Quality < Quality.LowerBound ||
                item.Quality > Quality.UpperBound ||
                item.Name.Contains(ItemNamesConstants.Sulfura))
                return;

            item.SellIn += Quality.Decrease;

            if (item.Name.Contains(ItemNamesConstants.AgedBrie))
                item.Quality += Quality.Increase;

            if (item.Name.Contains(ItemNamesConstants.Backstage))
            {
                // note : if validations rules increase more than 2, move to if/else

                item.Quality = (item.SellIn > SellIn.LowerBound && item.SellIn < SellIn.UpperBound)
                                ? item.Quality += Quality.IncreaseTwiceAsFast :
                                item.SellIn <= SellIn.LowerBound ?
                                item.Quality += Quality.IncreaseThreeTimesAsFast : item.Quality += Quality.Increase;
                return;
            }

            if (item.Name.Contains(ItemNamesConstants.Conjured))
            {
                item.Quality += Quality.DecreaseTwiceAsFast;
                return;
            }

            if (!item.Name.In(ItemNamesConstants.AgedBrie,
                ItemNamesConstants.Backstage,
                ItemNamesConstants.Conjured))
            {
                item.Quality = (item.SellIn == SellIn.Expired) ?
                    item.Quality += Quality.DecreaseTwiceAsFast :
                    item.Quality += Quality.Decrease;
            }
        }
    }
}
