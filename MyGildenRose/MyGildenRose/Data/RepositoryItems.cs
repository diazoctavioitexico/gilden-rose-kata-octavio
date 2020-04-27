namespace MyGildenRose.Data
{
    using System.Collections.Generic;
    using Constants;
    using Validator;

    public interface IRepositoryItems
    {
        IList<Item> GetItems();
        void UpdateQuality(Item item);
    }

    /// <summary>
    /// Because of question of demo Ioc is not really necessary although it could be implemented
    /// refactoring / code smells
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
            if (!ItemValidator.IsCandidate(item)) return;

            item.SellIn -= SellIn.Decrease;

            new ItemValidator()
                .IsAgedBrieThen(item, this.UpdateQualityAgedBrie)
                .IsBackstageThen(item, this.UpdateQualityBackStage)
                .IsConjuredThen(item, this.UpdateQualityConjured)
                .IsNotConstrainedProductThen(item, this.UpdateQualityNormalProduct);

        }


        /// <summary>
        /// Updates the quality aged brie.
        /// </summary>
        /// <param name="item">The item.</param>
        private void UpdateQualityAgedBrie(Item item)
        {
            item.Quality += Quality.Increase;
        }

        /// <summary>
        /// Determines whether the specified item is backstage.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   <c>true</c> if the specified item is backstage; otherwise, <c>false</c>.
        /// </returns>
        private void UpdateQualityBackStage(Item item)
        {
            // note : if validations rules increase more than 2, move to if/else

            item.Quality = (item.SellIn > SellIn.LowerBound && item.SellIn < SellIn.UpperBound)
                ? item.Quality += Quality.IncreaseTwiceAsFast
                : item.SellIn <= SellIn.LowerBound
                ? item.Quality += Quality.IncreaseThreeTimesAsFast
                : item.Quality += Quality.Increase;
        }

        /// <summary>
        /// Determines whether the specified item is conjured.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   <c>true</c> if the specified item is conjured; otherwise, <c>false</c>.
        /// </returns>
        private void UpdateQualityConjured(Item item)
        {
            item.Quality += Quality.DecreaseTwiceAsFast;
        }

        /// <summary>
        /// Updates the normal product.
        /// </summary>
        /// <param name="item">The item.</param>
        private void UpdateQualityNormalProduct(Item item)
        {
            item.Quality = (item.SellIn == SellIn.Expired) ?
                item.Quality += Quality.DecreaseTwiceAsFast :
                item.Quality += Quality.Decrease;
        }
    }
}
