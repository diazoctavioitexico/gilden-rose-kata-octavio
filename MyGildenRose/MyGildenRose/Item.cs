namespace MyGildenRose
{
    /// <summary>
    /// This class describes a single product of the store
    /// Has to be public, other domains 
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets the name of a product.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the sell in attribute of the product which means how many days remains before expiration
        /// this property decreases normally after each day and series of rules applies as well.
        /// </summary>
        /// <value>
        /// The sell in.
        /// </value>
        public int SellIn { get; set; }

        /// <summary>
        /// Gets or sets the quality of the product, which denotes how good is a product. This attribute decreases
        /// after each day normally although there are a series of rules that apply depending of the product.
        /// </summary>
        /// <value>
        /// The quality.
        /// </value>
        public int Quality { get; set; }
    }
}
