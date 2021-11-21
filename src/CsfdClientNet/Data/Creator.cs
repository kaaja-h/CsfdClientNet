namespace CsfdClientNet.Data
{

    /// <summary>
    /// Movie creator
    /// </summary>
    public class Creator
    {
        /// <summary>
        /// Creator contructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Creator(string id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Creator ID (csfd URL part)
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Creator name
        /// </summary>
        public string Name { get; }
    }
}