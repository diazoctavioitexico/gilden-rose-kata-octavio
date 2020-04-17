namespace MyGildenRose
{
    using MyGildenRose.Data;

    public class Program
    {
        public static void Main(string[] args)
        {
            var items = RepositoryItems.GetItems();

            foreach (var item in items)
            {
                RepositoryItems.UpdateQuality(item);
            }
        }
    }
}


