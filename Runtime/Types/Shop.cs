using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using AssetLayer.SDK.Basic;

#if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
    using UnityEngine.Scripting;
#endif

namespace AssetLayer.SDK.Shop 
{
    [DataContract]
    public class ShopItemSummary {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public ShopItemSummary() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string itemId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionName { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currencyId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currency { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public int price { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string appId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string paymentUserId { get; set; }
    }

    [DataContract]
    public class NewItemProps {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public NewItemProps() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public int price { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currencyId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currency { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string paymentUserId { get; set; }
    }

    [DataContract]
    public class BuyItemProps {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public BuyItemProps() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string itemId { get; set; }
    }

    [DataContract]
    public class RemoveItemProps {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public RemoveItemProps() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string itemId { get; set; }
    }


    [DataContract]
    public class NewItemResponse : BasicResponse<NewItemResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public NewItemResponse() : base() { }
    }

    [DataContract]
    public class NewItemResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public NewItemResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public NewItemResponseData newItem { get; set; } 
    }

    [DataContract]
    public class NewItemResponseData {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public NewItemResponseData() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string itemId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string collectionId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currencyId { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public string currency { get; set; }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public int price { get; set; }
    }


    [DataContract]
    public class BuyItemResponse : BasicSuccessResponse {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public BuyItemResponse() : base() { }
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public bool buy { get; set; }
    }

    [DataContract]
    public class ShopSummaryResponse : BasicResponse<ShopSummaryResponseBody> {
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public ShopSummaryResponse() : base() { }
    }

    [DataContract]
    public class ShopSummaryResponseBody { 
        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        public ShopSummaryResponseBody() { }

        #if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
            [Preserve]
        #endif
        [DataMember]
        public ShopItemSummary summary { get; set; } 
    }
    

    public class ShopRawDelegates {
        // public delegate Task<NewItemResponse> NewItem(NewItemProps props, Dictionary<string, string> headers = null);
        public delegate Task<BuyItemResponse> BuyItem(BuyItemProps props, Dictionary<string, string> headers = null);
        public delegate Task<ShopSummaryResponse> Summary(Dictionary<string, string> headers = null);
        // public delegate Task<BasicSuccessResponse> RemoveItem(RemoveItemProps props, Dictionary<string, string> headers = null);
    }

    public class ShopRawHandlers {
        // public ShopRawDelegates.NewItem NewItem;
        public ShopRawDelegates.BuyItem BuyItem;
        public ShopRawDelegates.Summary Summary;
        // public ShopRawDelegates.RemoveItem RemoveItem;
    }

    public class ShopSafeDelegates {
        // public delegate Task<BasicResult<NewItemResponseData>> NewItem(NewItemProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<bool>> BuyItem(BuyItemProps props, Dictionary<string, string> headers = null);
        public delegate Task<BasicResult<ShopItemSummary>> Summary(Dictionary<string, string> headers = null);
        // public delegate Task<BasicResult<bool>> RemoveItem(RemoveItemProps props, Dictionary<string, string> headers = null);
    }

    public class ShopSafeHandlers {
        // public ShopSafeDelegates.NewItem NewItem;
        public ShopSafeDelegates.BuyItem BuyItem;
        public ShopSafeDelegates.Summary Summary;
        // public ShopSafeDelegates.RemoveItem RemoveItem;
    }
}
