using FlareApiTest.Support;
using FlareApiTest.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;


namespace FlareApiTest.StepDefinitions
{
    [Binding]
    public class FavouritesSteps
    {
        public RestResponse? requestResponse;

        [When(@"I send '([^']*)' request with imageId '([^']*)' subId '([^']*)'")]
        public void WhenISendRequestWithImageIdSubId(string method, string imageId, string subId)
        {
            var imageDetails = new FavouritesPostModel
            {
                image_id = imageId,
                sub_id = subId
            };
            var postResponse = HttpRestClient.CreateOrUpdateRequest(method, imageDetails);
            requestResponse = postResponse;
        }

        [Then(@"I See the response is '([^']*)'")]
        public void ThenISeeTheResponseIs(int reponseCode)
        {
            var responseCode = requestResponse;
            var favouriteResponseStatuseCode = Convert.ToInt32(responseCode.StatusCode);
            favouriteResponseStatuseCode.Should().Equals(reponseCode);
        }


        [Then(@"I see the '([^']*)' in message")]
        public void ThenISeeTheInMessage(string message)
        {
            var reponse = requestResponse;
            FavouritePostResponseModel favouriteResponse = JsonConvert.DeserializeObject<FavouritePostResponseModel>(reponse.Content);
            favouriteResponse.message.Should().Be(message);

        }


        [Then(@"I see the response contains more than '([^']*)' response block")]
        public void ThenISeeTheResponseContainsMoreThanResponseBlock(int numberOfResponseBlock)
        {
            var reponse = requestResponse;
            List<FavouriteGetResponseModel> getResponse = JsonConvert.DeserializeObject<List<FavouriteGetResponseModel>>(reponse.Content);
            var numberOfResponsesInBlock = getResponse.Count();
            Assert.True(numberOfResponsesInBlock > numberOfResponseBlock);
            
        }


        [Then(@"I see the response imageId contains '([^']*)'")]
        public void ThenISeeTheResponseImageIdContains(string imageName)
        {
            var reponse = requestResponse;
            FavouriteGetResponseModel getResponse = JsonConvert.DeserializeObject<FavouriteGetResponseModel>(reponse.Content);
            getResponse.image_id.Should().Contain(imageName);


        }
        [Then(@"I send '([^']*)' request with favouriteId '([^']*)'")]
        [When(@"I send '([^']*)' request with favouriteId '([^']*)'")]
        public void WhenISendRequestWithFavouriteId(string method, string favouriteId)
        {
            var request = HttpRestClient.GetOrDeleteRequest(method, $"/{favouriteId}");
            requestResponse = request;
        }

        [Then(@"I see the response message contains '([^']*)'")]
        public void ThenISeeTheResponseMessageContains(string responseBodyMessage)
        {
            var reponse = requestResponse;
            FavouriteDeleteResponseModel deleteResponse = JsonConvert.DeserializeObject<FavouriteDeleteResponseModel>(reponse.Content);
            Assert.AreEqual(deleteResponse.message, responseBodyMessage);
        }

        [Then(@"I see the response contains '([^']*)'")]
        public void ThenISeeTheResponseContains(string imageName)
        {
            var reponse = requestResponse;
            List<FavouriteGetResponseModel> getResponse = JsonConvert.DeserializeObject<List<FavouriteGetResponseModel>>(reponse.Content);
            var imageIdVerification = getResponse.Any(x => x.image_id.Equals(imageName));
            imageIdVerification.Should().BeTrue();
        }

        [Then(@"I see the response does not contain id '([^']*)'")]
        public void ThenISeeTheResponseDoesNotContainId(int id)
        {
            var reponse = requestResponse;
            List<FavouriteGetResponseModel> getResponse = JsonConvert.DeserializeObject<List<FavouriteGetResponseModel>>(reponse.Content);
            var imageIdVerification = getResponse.Any(x => x.id.Equals(id));
            imageIdVerification.Should().BeFalse();
        }


    }
}
