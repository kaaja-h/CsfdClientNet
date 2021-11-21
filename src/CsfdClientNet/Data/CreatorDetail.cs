namespace CsfdClientNet.Data
{

    /// <summary>
    /// Creator detail
    /// </summary>
    public class CreatorDetail
    {
        internal CreatorDetail(Creator creator)
        {
            Creator = creator;
        }

        /// <summary>
        /// Creator biography
        /// </summary>
        public string? Biography { get; internal set; }

        
        /// <summary>
        /// Creator
        /// </summary>
        public Creator Creator { get; }
    }
}