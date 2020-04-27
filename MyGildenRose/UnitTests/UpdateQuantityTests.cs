using MyGildenRose;
using MyGildenRose.Data;
using MyGildenRose.Validator;
using Xunit;

namespace UnitTests
{

    public class UpdateQuantityTests
    {
        //assuming the Update Quantity output  is correct before the refactor
        // question .. how do I perform a unit test if I have changed the business rule?
        [Fact]
        public void TestUpdateQualityAgedBries()
        {
            var repositoryItems = new RepositoryItems();
            var itemValidator = new ItemValidator();
            var item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 };

            itemValidator.IsAgedBrieThen(item, repositoryItems.UpdateQuality);

            Assert.True(item.Quality == 1);
            Assert.True(item.SellIn == 1);

        }

        [Fact]
        public void TestUpdateQualityBackStage()
        {
            var repositoryItems = new RepositoryItems();
            var itemValidator = new ItemValidator();
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };

            itemValidator.IsBackstageThen(item, repositoryItems.UpdateQuality);

            Assert.True(item.Quality == 21);
            Assert.True(item.SellIn == 14);

        }

        [Fact]
        public void TestIsProductCandidate()
        {
            var repositoryItems = new RepositoryItems();
            var item = new Item { Name = "Sulfuras passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };

            if (ItemValidator.IsCandidate(item))
            {
                repositoryItems.UpdateQuality(item);
            }

            Assert.True(item.Quality == 20);
            Assert.True(item.SellIn == 15);
        }


        [Fact]
        public void TestUpdateQualityConjured()
        {
            var repositoryItems = new RepositoryItems();
            var itemValidator = new ItemValidator();
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 };

            itemValidator.IsConjuredThen(item, repositoryItems.UpdateQuality);

            Assert.True(item.Quality == 5);
            Assert.True(item.SellIn == 2);

        }

        [Fact]
        public void TestUpdateQualityNormalProduct()
        {
            var repositoryItems = new RepositoryItems();
            var itemValidator = new ItemValidator();
            var item = new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 };

            itemValidator.IsNotConstrainedProductThen(item, repositoryItems.UpdateQuality);

            Assert.True(item.Quality == 6);
            Assert.True(item.SellIn == 4);

        }

        [Fact]
        public void TestUpdateQualityAfterNIterations()
        {

        }
    }
}
