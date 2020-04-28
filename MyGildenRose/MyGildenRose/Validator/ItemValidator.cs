using System;
using MyGildenRose.Constants;
using MyGildenRose.ExtensionMethods;

namespace MyGildenRose.Validator
{
    public class ItemValidator
    {
        /// <summary>
        /// Validates the candidate.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="validator">The validator.</param>
        /// <returns></returns>
        public void ValidateIsCandidate(Item item, Action<ItemValidator> validator)
        {
            if (item.Quality >= Quality.LowerBound &&
                item.Quality <= Quality.UpperBound &&
                !item.Name.Contains(ItemNamesConstants.Sulfura))
            {
                validator?.Invoke(this);
            }

        }

        /// <summary>
        /// Determines whether [is aged brie then] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="updateQuality">The update quality.</param>
        /// <returns></returns>
        public ItemValidator ValidateAgedBrieThen(Item item, Action<Item> updateQuality)
        {
            if (item.Name.Contains(ItemNamesConstants.AgedBrie))
            {
                updateQuality?.Invoke(item);
            }

            return this;
        }

        /// <summary>
        /// Determines whether [is backstage then] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="updateQuality">The update quality.</param>
        /// <returns></returns>
        public ItemValidator ValidateBackstageThen(Item item, Action<Item> updateQuality)
        {
            if (item.Name.Contains(ItemNamesConstants.Backstage))
            {
                updateQuality?.Invoke(item);
            }

            return this;
        }

        /// <summary>
        /// Determines whether [is conjured then] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="updateQuality">The update quality.</param>
        /// <returns></returns>
        public ItemValidator ValidateConjuredThen(Item item, Action<Item> updateQuality)
        {
            if (item.Name.Contains(ItemNamesConstants.Conjured))
            {
                updateQuality?.Invoke(item);
            }

            return this;
        }

        /// <summary>
        /// Determines whether [is not constrained product then] [the specified item].
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="updateQuality">The update quality.</param>
        /// <returns></returns>
        public ItemValidator ValidateNotConstrainedThen(Item item, Action<Item> updateQuality)
        {
            if (!item.Name.In(ItemNamesConstants.AgedBrie,
                    ItemNamesConstants.Backstage,
                    ItemNamesConstants.Conjured))
            {
                updateQuality?.Invoke(item);
            }

            return this;
        }

    }
}
