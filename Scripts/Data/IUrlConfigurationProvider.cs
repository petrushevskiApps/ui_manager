public interface IUrlConfigurationProvider
{
    string PrivacySettingsUrl { get; }
    string PrivacyPolicyUrl { get; }
    string TermsOfUseUrl { get; }
}