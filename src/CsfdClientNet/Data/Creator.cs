namespace CsfdClientNet.Data
{

    /// <summary>
    /// Movie creator
    /// </summary>
    public class Creator
    {
        internal Creator(string id, string name)
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