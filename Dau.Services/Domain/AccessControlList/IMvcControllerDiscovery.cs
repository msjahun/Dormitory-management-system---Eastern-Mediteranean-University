using System.Collections.Generic;
using Dau.Core.Configuration.AccessControlList;

namespace Dau.Services.AccessControlList
{
    public interface IMvcControllerDiscovery
    {
        IEnumerable<MvcControllerInfo> GetControllers();
    }
}