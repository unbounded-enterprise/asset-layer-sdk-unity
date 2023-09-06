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


    public class EquipsRawDelegates {
        public delegate Task<GetEquipsResponse> GetEquips(GetEquipsProps props, Dictionary<string, string> headers = null);
        public delegate Task<SetEquipResponse> SetEquip(SetEquipProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicSuccessResponse> RemoveEquip(RemoveEquipProps props, Dictionary<string, string> headers = null);
    }

    public class EquipsRawHandlers {
        public EquipsRawDelegates.GetEquips GetEquips;
        public EquipsRawDelegates.SetEquip SetEquip;
        public EquipsRawDelegates.RemoveEquip RemoveEquip;
    }

    public class EquipsSafeDelegates {
        public delegate Task<BasicResult<List<Equip>>> GetEquips(GetEquipsProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<string>> SetEquip(SetEquipProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<bool>> RemoveEquip(RemoveEquipProps props, Dictionary<string, string> headers = null);
    }
    
    public class EquipsSafeHandlers {
        public EquipsSafeDelegates.GetEquips GetEquips;
        public EquipsSafeDelegates.SetEquip SetEquip;
        public EquipsSafeDelegates.RemoveEquip RemoveEquip;
    }
}
