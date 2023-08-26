using System;
using System.Threading.Tasks;

namespace AssetLayerSDK.Apps 
{
    public class App {
        public string appId { get; set; }
    }
    public class AppInfoProps
    {
        public string appId { get; set; }
    }
    public class AppInfoResponseBody {
        public App app { get; set; }
    }
    public class AppInfoResponse {
        public AppInfoResponseBody body { get; set; }

    }

    public class AppsRawHandlers
    {
        public Func<AppInfoProps, object, Task<AppInfoResponse>> info;
    }
}
