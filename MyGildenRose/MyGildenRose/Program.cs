using System.Linq;

namespace MyGildenRose
{
    using Data;

    public class Program
    {
        public static void Main(string[] args)
        {
            IRepositoryItems repositoryItems = new RepositoryItems();

            foreach (var item in repositoryItems.GetItems())
            {
                repositoryItems.UpdateQuality(item);
            }
        }
    }
}


