using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Phramd.GooglePhotos
{
    public class MediaItems
    {
        //[JsonProperty(PropertyName = "mediaItems")]
        //public List<string> mediaItems { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "productUrl")]
        public string productUrl { get; set; }
    }
}
