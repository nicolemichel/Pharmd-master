using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Phramd.GooglePhotos
{
    public class SharedAlbumOptions
    {
        [JsonProperty(PropertyName = "isCollaborative")]
        public bool IsCollaborative { get; set; }

        [JsonProperty(PropertyName = "isCommentable")]
        public bool IsCommentable { get; set; }
    }
}
