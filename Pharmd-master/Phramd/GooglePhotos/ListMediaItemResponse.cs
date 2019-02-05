using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Phramd.GooglePhotos
{
    public class ListMediaItemResponse
    {
        [JsonProperty(PropertyName = "mediaItems")]
        public IEnumerable<MediaItems> MediaItems { get; set; }

        [JsonProperty(PropertyName = "nextPageToken")]
        public string NextPageToken { get; set; }
    }
}
