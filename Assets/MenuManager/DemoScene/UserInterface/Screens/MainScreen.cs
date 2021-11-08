using PetrushevskiApps.UIManager;
using UnityEngine;
using UnityEngine.Events;

namespace slowBulletGames.MemoryValley
{
    public class MainScreen : UIScreen
    {
        public static UnityEvent<bool> OnMainScreenToggle = new UnityEvent<bool>();

        [Header("Buttons")]
        [SerializeField] private UIButton settingsButton;
        [SerializeField] private UIButton leftArrowButton;
        [SerializeField] private UIButton rightArrowButton;
        [SerializeField] private UIButton levelsMapButton;
        [SerializeField] private UIButton nextLevelButton;

        [Header("World Info")]
        [SerializeField] private GameObject worldLock;


        private new void Awake()
        {
            base.Awake();

            leftArrowButton.onClick.AddListener(OnLeftArrowClicked);
            rightArrowButton.onClick.AddListener(OnRightArrowClicked);
            settingsButton.onClick.AddListener(OnSettingsClicked);
            levelsMapButton.onClick.AddListener(OnLevelsMapClicked);
            nextLevelButton.onClick.AddListener(OnStartLevelClicked);
        }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
            OnMainScreenToggle.Invoke(false);
        }


        private void SetButtons()
        {
            
        }

        private void OnLeftArrowClicked()
        {
            
        }

        private void OnRightArrowClicked()
        {
            
        }

        private void OnSettingsClicked()
        {
            UIManager.Instance.OpenPopup<SettingsPopup>();
        }
        private void OnStartLevelClicked()
        {
           
        }
        private void OnLevelsMapClicked()
        {
            UIManager.Instance.OpenScreen<LevelsScreen>();
        }
    }

}