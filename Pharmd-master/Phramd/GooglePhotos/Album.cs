using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Phramd.GooglePhotos
{
    public class Album
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")] //Title of album
        public string Title { get; set; }

        [JsonProperty(PropertyName = "productUrl")]//URL to Album
        public string ProductUrl { get; set; }

        [JsonProperty(PropertyName = "isWriteable")]
        public bool IsWriteable { get; set; }

        [JsonProperty(PropertyName = "shareInfo")]
        public ShareInfo ShareInfo { get; set; }

        [JsonProperty(PropertyName = "mediaItemsCount")]
        public string MediaItemsCount { get; set; }

        [JsonProperty(PropertyName = "coverPhotoBaseUrl")]
        public string CoverPhotoBaseUrl { get; set; }

        [JsonProperty(PropertyName = "coverPhotoMediaItemId")]
        public string CoverPhotoMediaItemId { get; set; }
    }
}

