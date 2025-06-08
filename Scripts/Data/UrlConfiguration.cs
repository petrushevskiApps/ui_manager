using UnityEngine;

namespace TwoOneTwoGames.UIManager.Data
{
    [CreateAssetMenu(
        menuName = "Data/URLs Configuration",
        fileName = "UrlsConfigurationProvider")]
    public class UrlConfiguration : ScriptableObject, IUrlConfigurationProvider
    {
        [field: SerializeField]
        public string PrivacySettingsUrl { get; private set; }

        [field: SerializeField]
        public string PrivacyPolicyUrl { get; private set; }

        [field: SerializeField]
        public string TermsOfUseUrl { get; private set; }
    }
}