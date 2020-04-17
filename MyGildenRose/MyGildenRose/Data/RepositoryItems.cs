namespace MyGildenRose.Data
{
    using System.Collections.Generic;
    using MyGildenRose.Constants;
    using MyGildenRose.ExtensionMethods;

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
            if (item.Quality < 0 || item.Quality > 50) return;

            if (item.Name.Contains(ItemNames.Sulfura)) return;

            item.SellIn -= 1;

            if (item.Name.Contains(ItemNames.AgedBrie)) item.Quality += 1;

            if (item.Name.Contains(ItemNames.Backstage))
            {
                item.Quality = (item.SellIn > 5 && item.SellIn < 11) ? item.Quality += 2 :
                               (item.SellIn <= 5) ? item.Quality += 3 : item.Quality += 1;
            }

            if (item.Name.Contains(ItemNames.Conjured))
            {
                item.Quality -= 2;
            }

            if (!item.Name.NotIn(new List<string>() { ItemNames.AgedBrie, ItemNames.Backstage, ItemNames.Conjured }))
            {
                item.Quality = (item.SellIn < 1) ? item.Quality -= 2 : item.Quality -= 1;
            }
        }
    }
}
