namespace MyGildenRose
{
    using System.Collections.Generic;
    using ExtensionMethods;
    using MyGildenRose.Constants;
    using MyGildenRose.Data;

    public class Program
    {
        public static void Main(string[] args)
        {
            var items = RepositoryItems.GetItems();

            foreach (var item in items)
            {
                UpdateQuality(item);
            }
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


