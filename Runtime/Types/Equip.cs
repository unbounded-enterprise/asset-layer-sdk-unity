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
    }

    [DataContract]
    public class GetEquipsResponse : BasicResponse<GetEquipsResponseBody> { public GetEquipsResponse() { } }
    [DataContract]
    public class GetEquipsResponseBody { 
        public GetEquipsResponseBody() { }

        #if UNITY_WEBGL
            [Preserve]
        #endif
        [DataMember]
        public List<Equip> equip { get; set; } 
    }

    public class EquipsRawHandlers
    {
        public Func<GetEquipsProps, Dictionary<string, string>, Task<GetEquipsResponse>> GetEquips;
        public Func<SetEquipProps, Dictionary<string, string>, Task<SetEquipResponse>> SetEquip;
        public Func<RemoveEquipProps, Dictionary<string, string>, Task<BasicSuccessResponse>> RemoveEquip;
    }

    public class EquipsSafeHandlers
    {
        public Func<GetEquipsProps, object, Task<BasicResult<List<Equip>>>> GetEquips;
        public Func<SetEquipProps, object, Task<BasicResult<string>>> SetEquip;
        public Func<RemoveEquipProps, object, Task<BasicResult<bool>>> RemoveEquip;
    }
}
