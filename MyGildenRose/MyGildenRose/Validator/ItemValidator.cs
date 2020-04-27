using System;
using MyGildenRose.Constants;
using MyGildenRose.ExtensionMethods;

namespace MyGildenRose.Validator
{
    public class ItemValidator
    {
        /// <summary>
        /// Determines whether the specified item is candidate.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   <c>true</c> if the specified item is candidate; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsCandidate(Item item)
        {
            return item.Quality >= Quality.LowerBound &&
                   item.Quality <= Quality.UpperBound &&
                   !item.Name.Contains(ItemNamesConstants.Sulfura);
        }

        /// <summary>
        /// Determines whether [is aged brie then] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="updateQuality">The update quality.</param>
        /// <returns></returns>
        public ItemValidator IsAgedBrieThen(Item item, Action<Item> updateQuality)
        {
            if (item.Name.Contains(ItemNamesConstants.AgedBrie))
            {
                updateQuality.Invoke(item);
            }

            return this;
        }

        /// <summary>
        /// Determines whether [is backstage then] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="updateQuality">The update quality.</param>
        /// <returns></returns>
        public ItemValidator IsBackstageThen(Item item, Action<Item> updateQuality)
        {
            if (item.Name.Contains(ItemNamesConstants.Backstage))
            {
                updateQuality.Invoke(item);
            }

            return this;
        }

        /// <summary>
        /// Determines whether [is conjured then] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="updateQuality">The update quality.</param>
        /// <returns></returns>
        public ItemValidator IsConjuredThen(Item item, Action<Item> updateQuality)
        {
            if (item.Name.Contains(ItemNamesConstants.Conjured))
            {
                updateQuality.Invoke(item);
            }

            return this;
        }

        /// <summary>
        /// Determines whether [is not constrained product then] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="updateQuality">The update quality.</param>
        /// <returns></returns>
        public ItemValidator IsNotConstrainedProductThen(Item item, Action<Item> updateQuality)
        {
            if (!item.Name.In(ItemNamesConstants.AgedBrie,
                    ItemNamesConstants.Backstage,
                    ItemNamesConstants.Conjured))
            {
                updateQuality.Invoke(item);
            }

            return this;
        }

    }
}
