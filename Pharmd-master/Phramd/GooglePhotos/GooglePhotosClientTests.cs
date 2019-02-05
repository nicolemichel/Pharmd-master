using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Google.Apis.Auth.OAuth2;
using Moq;
using Xunit;

namespace Phramd.GooglePhotos
{
    public class GooglePhotosClientTests
    {
        private readonly GooglePhotosClient googlePhotosClient;

        private readonly Mock<HttpClient> httpClient;
        private readonly Mock<UserCredential> userCredential;

        public GooglePhotosClientTests()
        {
            this.httpClient = new Mock<HttpClient>();
            this.userCredential = new Mock<UserCredential>();
            GooglePhotosClientSettings clientSettings = new GooglePhotosClientSettings(
                this.httpClient.Object,
                this.userCredential.Object);
            this.googlePhotosClient = new GooglePhotosClient(clientSettings);
        }

        [Fact]
        public void Test_ListAlbums_Succeeds()
        {
            this.googlePhotosClient.ListAlbums();
        }
    }
}
