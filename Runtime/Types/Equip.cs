using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;
#if UNITY_WEBGL
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Equips 
{
    [DataContract]
    public class Equip {
        public Equip() { }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string equipId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetIdParent { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetIdChild { get; set; }
    }

    [DataContract]
    public class GetEquipsProps { 
        public GetEquipsProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetId { get; set; }
    }
    [DataContract]
    public class SetEquipResponse : BasicResponse<SetEquipResponseBody> { public SetEquipResponse() { } }
    [DataContract]
    public class SetEquipResponseBody { 
        public SetEquipResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string equipId { get; set; } 
    }

    [DataContract]
    public class SetEquipProps {
        public SetEquipProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string slotId { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetIdParent { get; set; }
        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string assetIdChild { get; set; }
    }

    [DataContract]
    public class RemoveEquipProps { 
        public RemoveEquipProps() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public string equipId { get; set; } 
    };

    public class EquipsRawHandlers
    {
        
    }

    public class EquipsSafeHandlers
    {
        
    }
}
