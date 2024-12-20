using RestSharp;
using backend.Models;

namespace Event_Scheduler_Tests
{
    // TODO: validate that these tests are valid and that the assertions are encompassing
    public class Tests
    {
        private readonly string appUrl = "http://localhost:5117";

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Writing setup");
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("Running Test 1");
            Assert.Pass();
        }

        [Test]
        public void GetEvents_IsCallable()
        {
            // Arrange
            RestClient client = new RestClient(appUrl + "/events");
            RestRequest request = new RestRequest(appUrl + "/events", Method.Get);

            // Act
            RestResponse response = client.Execute(request);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Content, Is.Not.EqualTo(null));
            Assert.That(response.Content, Is.Not.Empty);
            Assert.That(response.IsSuccessStatusCode);
        }

        [Test]
        public void GetEvent_IsCallable()
        {
            // Arrange
            RestClient client = new RestClient(appUrl + "/events/1");
            RestRequest request = new RestRequest(appUrl + "/events/1", Method.Get);

            // Act
            RestResponse response = client.Execute(request);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Content, Is.Not.EqualTo(null));
            Assert.That(response.Content, Is.Not.Empty);
            Assert.That(response.IsSuccessStatusCode);
        }

        [Test]
        public void CreateEvent_IsCallable()
        {
            // Arrange
            RestClient client = new RestClient(appUrl + "/events/1");
            Event eventToCreate = new Event
            {
                id = 10,
                title = "Test Event 10",
                duration = 180,
                people =
                    [
                        new User { id = 1, firstName = "Caleb", lastName = "Ninal", nickName = "Caleb" },
                        new User { id = 2, firstName = "Karine", lastName = "Narvaez", nickName = "Banshee" },
                        new User { id = 3, firstName = "Tokyo", lastName = "Man", nickName = "Tokis" },
                        new User { id = 4, firstName = "Mandos", lastName = "Man", nickName = "The Mandos Man" },
                    ],
                timeStart = new DateTime()
            };
            RestRequest request = new RestRequest(appUrl + "/events", Method.Post);
            request.AddBody(eventToCreate, ContentType.Json);

            // Act
            RestResponse response = client.Execute(request);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Content, Is.Not.EqualTo(null));
            Assert.That(response.Content, Is.Not.Empty);
            Assert.That(response.IsSuccessStatusCode);
        }

        [Test]
        public void UpdateEvent_IsCallable()
        {
            // Arrange
            RestClient client = new RestClient(appUrl + "/events");
            int oldEventId = 1;
            Event eventToUpdateTo = new Event
            {
                id = 10,
                title = "Test Event 10",
                duration = 180,
                people =
                    [
                        new User { id = 1, firstName = "Caleb", lastName = "Ninal", nickName = "Caleb" },
                        new User { id = 2, firstName = "Karine", lastName = "Narvaez", nickName = "Banshee" },
                        new User { id = 3, firstName = "Tokyo", lastName = "Man", nickName = "Tokis" },
                        new User { id = 4, firstName = "Mandos", lastName = "Man", nickName = "The Mandos Man" },
                    ],
                timeStart = new DateTime()
            };
            RestRequest request = new RestRequest(appUrl + "/events/" + oldEventId, Method.Put);
            request.AddBody(eventToUpdateTo, ContentType.Json);

            // Act
            RestResponse response = client.Execute(request);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Content, Is.Not.EqualTo(null));
            Assert.That(response.Content, Is.Not.Empty);
            Assert.That(response.IsSuccessStatusCode);
        }

        [Test]
        public void RemoveEvent_IsCallable()
        {
            // Arrange
            RestClient client = new RestClient(appUrl + "/events");
            int eventIdToRemove = 1;
            RestRequest request = new RestRequest(appUrl + "/events/" + eventIdToRemove, Method.Delete);

            // Act
            RestResponse response = client.Execute(request);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Content, Is.Not.EqualTo(null));
            Assert.That(response.Content, Is.Not.Empty);
            Assert.That(response.IsSuccessStatusCode);
        }
    }
}