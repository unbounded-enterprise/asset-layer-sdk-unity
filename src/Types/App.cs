using System;
using System.Threading.Tasks;

namespace AssetLayerSDK.Apps 
{
    public class App { public string appId; }
    public class AppInfoProps { public string appId; }
    public class AppInfoResponseBody { public App app; }
    public class AppInfoResponse { public AppInfoResponseBody body; }

    public class AppsRawHandlers
    {
        public Func<AppInfoProps, object, Task<AppInfoResponse>> info;
    }
}
