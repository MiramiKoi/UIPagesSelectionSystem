using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class PageSelector : MonoBehaviour
    {
        [SerializeField] private Page currentPage;
        [SerializeField] private List<Page> pages;
        
        private UIDocument _uiDocument;
        private VisualElement _root;
        
        private Button _previousPageButton;
        private Button _nextPageButton;
        
        private void Awake()
        {
            _uiDocument = GetComponent<UIDocument>();
            _root = _uiDocument.rootVisualElement;

            InitializePages();
            InitializeButtons();
            
            SelectPage(pages[0]);
        }

        private void InitializeButtons()
        {
            _nextPageButton = _root.Q<Button>("NextPageButton");
            _previousPageButton = _root.Q<Button>("PreviousPageButton");
            
            _nextPageButton.RegisterCallback<ClickEvent>(OnNextPageButtonClicked);
            _previousPageButton.RegisterCallback<ClickEvent>(OnPreviousPageButtonClicked);
        }
        
        private void OnNextPageButtonClicked(ClickEvent click)
        {
            SwitchPage(1);
            _nextPageButton.Blur();
        }

        private void OnPreviousPageButtonClicked(ClickEvent click)
        {
            SwitchPage(-1);
            _previousPageButton.Blur();
        }
        
        private void InitializePages()
        {
            foreach (var page in pages)
            {
                var pageElement = _root.Q(page.GetType().Name);

                if (pageElement == null)
                {
                    Debug.LogWarning($"Элемент для страницы {page.GetType().Name} в {_uiDocument} не найден");
                    continue;
                }
                
                page.Initialize(pageElement);
            }
        }

        private void SwitchPage(int pageIndex)
        {
            var newPageIndex = (pages.IndexOf(currentPage) + pageIndex + pages.Count) % pages.Count; 
            
            SelectPage(pages[newPageIndex]);
        }

        private void SelectPage(Page page)
        {
            ClearPages();
        
            currentPage = page;

            UpdateHeader();
            
            currentPage.Activate();
        }

        private void UpdateHeader()
        {
            _root.Q<Label>("Title").text = currentPage.PageTitle;
        }

        private void ClearPages()
        {
            foreach (var page in pages)
            {
                page.Deactivate();
            }
        }
    }
}
