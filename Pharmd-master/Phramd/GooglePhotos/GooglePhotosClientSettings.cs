using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Google.Apis.Auth.OAuth2;

namespace Phramd.GooglePhotos
{
    public class GooglePhotosClientSettings
    {
        public GooglePhotosClientSettings(HttpClient httpClient, UserCredential userCredential)
        {
            this.HttpClient = httpClient;
            this.UserCredential = userCredential;
        }

        public HttpClient HttpClient { get; }
        public UserCredential UserCredential { get; }
    }
}