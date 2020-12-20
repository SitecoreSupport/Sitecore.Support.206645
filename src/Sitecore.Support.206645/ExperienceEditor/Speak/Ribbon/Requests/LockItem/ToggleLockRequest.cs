using Sitecore.ContentSearch;
using Sitecore.Data.Items;

namespace Sitecore.Support.ExperienceEditor.Speak.Ribbon.Requests.LockItem
{
    /// <summary>
    /// The toggle lock request.
    /// </summary>
    public class ToggleLockRequest : Sitecore.ExperienceEditor.Speak.Ribbon.Requests.LockItem.ToggleLockRequest
    {

        /// <summary>
        /// Refreshes the index.
        /// </summary>
        /// <param name="item">The item.</param>
        protected override void RefreshIndex(Item item)
        {
            using (IProviderSearchContext searchContext = ContentSearchManager.GetIndex(SearchDefaults.SitecoreIndex).CreateSearchContext())
            {
                // Sitecore.Support.206645 +++
                searchContext.Index.Update(new SitecoreIndexableItem(item).UniqueId);
                // Sitecore.Support.206645 ---
            }
        }
    }
}