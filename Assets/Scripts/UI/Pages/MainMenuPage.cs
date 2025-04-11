using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Pages
{
    public class MainMenuPage : Page
    {
        private Button _startGameButton;
        private Button _loadGameButton;
        private Button _settingsButton;
        private Button _exitGameButton;
        
        protected override void OnInitialize()
        {
            _startGameButton = PageRoot.Q<Button>("NewGameButton");
            _loadGameButton = PageRoot.Q<Button>("LoadGameButton");
            _settingsButton = PageRoot.Q<Button>("SettingsButton");
            _exitGameButton = PageRoot.Q<Button>("ExitButton");
        }
        
        protected override void OnActivate()
        {
            _startGameButton.RegisterCallback<ClickEvent>(OnStartGameClicked);
            _loadGameButton.RegisterCallback<ClickEvent>(OnLoadGameClicked);
            _settingsButton.RegisterCallback<ClickEvent>(OnSettingsClicked);
            _exitGameButton.RegisterCallback<ClickEvent>(OnExitGameClicked);
        }

        protected override void OnDeactivate()
        {
            Debug.Log("Главное меню закрыто");
        }
        
        private void OnStartGameClicked(ClickEvent clickEvent)
        {
            Debug.Log("StartGame Clicked");
        }

        private void OnLoadGameClicked(ClickEvent clickEvent)
        {
            Debug.Log("LoadGame Clicked");
        }

        private void OnSettingsClicked(ClickEvent clickEvent)
        {
            var uiDocument = GetComponent<UIDocument>();
            
            uiDocument.visualTreeAsset = Resources.Load<VisualTreeAsset>("UI/Settings");
        }

        private void OnExitGameClicked(ClickEvent clickEvent)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}