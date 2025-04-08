using UnityEngine;

namespace UI.Pages
{
    public class ShopPage : Page
    {
        protected override void OnInitialize()
        {
            Debug.Log($"On Initialize page {PageTitle}");
        }
    
        protected override void OnActivate()
        {
            Debug.Log($"On Activate page {PageTitle}");
        }

        protected override void OnDeactivate()
        {
            Debug.Log($"On Deactivate page {PageTitle}");
        }
    }
}