using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Xunit;

namespace Phramd.GooglePhotos
{
    public class GooglePhotosClientIntegrationTests
    {
        public string allGPhotos = Program.PhotoDetails.allGPhotos;
        private readonly GooglePhotosClient googlePhotosClient;
        public string userEmail = Program.UserDetails.GPhoto;
        public GooglePhotosClientIntegrationTests()
        {
            HttpClient httpClient = new HttpClient();
            UserCredential userCredential;
            using (var stream = new FileStream("credentialsPhoto.json", FileMode.Open, FileAccess.Read))
            {
                userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { "https://www.googleapis.com/auth/photoslibrary.readonly" },
                    userEmail,
                    CancellationToken.None).Result;
            }

            userCredential.RefreshTokenAsync(CancellationToken.None).Wait();
            GooglePhotosClientSettings clientSettings = new GooglePhotosClientSettings(httpClient, userCredential);
            this.googlePhotosClient = new GooglePhotosClient(clientSettings);
        }

        public void Test_ListAlbums_GetFirstAlbum()
        {
            ListAlbumsResponse listAlbumsResponse = this.googlePhotosClient.ListAlbums();

            foreach (Album album in listAlbumsResponse.Albums)
            {
                Album singleAlbum = this.googlePhotosClient.GetAlbum(album.Id); 
                break;
            } 
        }

        public void ListAlbumContent()
        {
            ListMediaItemResponse mediaItemResponse = this.googlePhotosClient.ListAlbumContents();

            foreach (MediaItems photo in mediaItemResponse.MediaItems)
            {
                MediaItems allPhotos = googlePhotosClient.GetAlbumContent(photo.Id);
                allGPhotos = photo.productUrl;
                break;
            }
        }
    }
}

