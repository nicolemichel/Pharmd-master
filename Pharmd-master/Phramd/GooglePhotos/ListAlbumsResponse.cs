using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Phramd.GooglePhotos
{
    public class ListAlbumsResponse
    {
        [JsonProperty(PropertyName = "albums")]
        public IEnumerable<Album> Albums { get; set; }

        [JsonProperty(PropertyName = "nextPageToken")]
        public string NextPageToken { get; set; }
    }
}

