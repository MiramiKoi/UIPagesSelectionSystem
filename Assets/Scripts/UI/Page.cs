using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public abstract class Page : MonoBehaviour
    {   
        [field: SerializeField] public string PageTitle { get; private set; }
    
        protected VisualElement PageRoot;
        protected bool IsActive;
    
        protected abstract void OnInitialize();
        protected abstract void OnActivate();
        protected abstract void OnDeactivate();

        public void Initialize(VisualElement pageRoot)
        {
            PageRoot = pageRoot;
            
            if (PageRoot == null) return;
            
            OnInitialize();
        }

        public void Activate()
        {
            if (PageRoot == null) return;
            
            IsActive = true;
            PageRoot.style.display = DisplayStyle.Flex;
            OnActivate();
        }

        public void Deactivate()
        {
            if (PageRoot == null) return;
            
            IsActive = false;
            PageRoot.style.display = DisplayStyle.None;
            OnDeactivate();
        }
    }
}