using System.Data;

namespace MyGildenRose.Data
{
    using System.Collections.Generic;
    using Constants;
    using ExtensionMethods;

    public interface IRepositoryItems
    {
        IList<Item> GetItems();
        void UpdateQuality(Item item);
    }

    /// <summary>
    /// Because of question of demo Ioc is not really necessary although it could be implemented
    /// </summary>
    public class RepositoryItems : IRepositoryItems
    {
        public IList<Item> GetItems()
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

        /// <summary>
        /// Updates the quality of a product by validating some specific constraints.
        /// </summary>
        /// <param name="item">The item.</param>
        public void UpdateQuality(Item item)
        {
            if (!IsValidCandidate(item)) return;

            item.SellIn -= SellIn.Decrease;

            if (IsItemAgedBrie(item)) return;

            if (IsBackstage(item)) return;

            if (IsConjured(item)) return;

            UpdateNormalProduct(item);

        }

        /// <summary>
        /// Determines whether [is valid candidate] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   <c>true</c> if [is valid candidate] [the specified item]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsValidCandidate(Item item)
        {
            return item.Quality >= Quality.LowerBound &&
                   item.Quality <= Quality.UpperBound &&
                   !item.Name.Contains(ItemNamesConstants.Sulfura);
        }

        /// <summary>
        /// Determines whether [is item aged brie] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   <c>true</c> if [is item aged brie] [the specified item]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsItemAgedBrie(Item item)
        {
            if (item.Name.Contains(ItemNamesConstants.AgedBrie)) return true;
            item.Quality += Quality.Increase;
            return false;

        }

        /// <summary>
        /// Determines whether the specified item is backstage.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   <c>true</c> if the specified item is backstage; otherwise, <c>false</c>.
        /// </returns>
        private bool IsBackstage(Item item)
        {
            if (!item.Name.Contains(ItemNamesConstants.Backstage)) return false;

            // note : if validations rules increase more than 2, move to if/else

            item.Quality = (item.SellIn > SellIn.LowerBound && item.SellIn < SellIn.UpperBound)
                ? item.Quality += Quality.IncreaseTwiceAsFast
                : item.SellIn <= SellIn.LowerBound
                    ? item.Quality += Quality.IncreaseThreeTimesAsFast
                    : item.Quality += Quality.Increase;
            return true;

        }

        /// <summary>
        /// Determines whether the specified item is conjured.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   <c>true</c> if the specified item is conjured; otherwise, <c>false</c>.
        /// </returns>
        private bool IsConjured(Item item)
        {
            if (!item.Name.Contains(ItemNamesConstants.Conjured)) return false;

            item.Quality += Quality.DecreaseTwiceAsFast;
            return true;
        }

        /// <summary>
        /// Updates the normal product.
        /// </summary>
        /// <param name="item">The item.</param>
        private void UpdateNormalProduct(Item item)
        {
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
