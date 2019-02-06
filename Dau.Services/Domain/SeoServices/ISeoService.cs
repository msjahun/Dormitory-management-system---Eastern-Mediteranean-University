using System.Collections.Generic;

namespace Dau.Services.Domain.SeoServices
{
    public interface ISeoService
    {
        int CheckForSeoFriendlyNameDuplicates(string SeoFriendlyName);
        string ConcatenateDuplicateIndexToSeoFriendlyName(string SeoFriendlyName, int Count);
        string RemoveSpecialCharacters(string str);
        string ResolveSpecialCharactersAndSeoNameDuplication(string SeoFriendlyName);
        List<SEOFriendlyPageNamesTable> GetSEOFriendlyPageNamesTable();
    }
}