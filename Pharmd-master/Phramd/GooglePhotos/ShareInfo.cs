using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Phramd.GooglePhotos
{
    public class ShareInfo
    {
        [JsonProperty(PropertyName = "sharedAlbumOptions")]
        public SharedAlbumOptions SharedAlbumOptions { get; set; }

        [JsonProperty(PropertyName = "shareableUrl")]
        public string ShareableUrl { get; set; }

        [JsonProperty(PropertyName = "shareToken")]
        public string ShareToken { get; set; }

        [JsonProperty(PropertyName = "isJoined")]
        public bool IsJoined { get; set; }
    }
}
