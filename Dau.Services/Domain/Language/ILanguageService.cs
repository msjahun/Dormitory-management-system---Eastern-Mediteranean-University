namespace Dau.Services.Languages
{
    public interface ILanguageService
    {
        long GetCurrentLanguageId();
        string GetCurrentCode();
    }
}