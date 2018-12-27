using System.Collections.Generic;

namespace Dau.Services.Domain.HomeService
{
    public interface IHomeService
    {
        List<GetSearchSuggestionsViewModel> GetSearchSuggestions(string searchTerm);
    }
}