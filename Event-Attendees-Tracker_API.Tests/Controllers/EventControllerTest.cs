using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Event_Attendees_Tracker_API.Controllers;
using Event_Attendees_Tracker_BAL.User_Actions;
using Event_Attendees_Tracker_CustomResponseModel;
using Moq;
using System.Net.Http;
using System.Web.Http;

namespace Event_Attendees_Tracker_API.Tests.Controllers
{
    /// <summary>
    /// Summary description for EventControllerTest
    /// </summary>
    [TestClass]
    public class EventControllerTest
    {

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void PastEventAttendees_FakePastEventResponseModel_ReturnHttpStatusCodeOk()
        {
            //Arrange
            var pastEvent_BAL = new Mock<IFetchPastEvents>();
            pastEvent_BAL.Setup(m => m.fetchPastEventAttendeesData(It.IsAny<int>())).Returns(getPastEventResponseModelData());
            var controller = new EventController(pastEvent_BAL.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.PastEventAttendees(It.IsAny<int>());
            List<PastEventResponseModel> pastEventResponseModel;
            //Assert
            CollectionAssert.Equals(response.TryGetContentValue<List<PastEventResponseModel>>(out pastEventResponseModel), getPastEventResponseModelData());

        }
        [TestMethod]
        public void PastEventAttendees_PastEventResponseModel_ReturnHttpStatusCodeCreated()
        {
            //Arrange
            var pastEvent_BAL = new Mock<IFetchPastEvents>();
            List<PastEventResponseModel> pastEventResponses = null;
            pastEvent_BAL.Setup(m => m.fetchPastEventAttendeesData(It.IsAny<int>())).Returns(pastEventResponses);
            var controller = new EventController(pastEvent_BAL.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.PastEventAttendees(It.IsAny<int>());
            bool status;
            //Assert
            Assert.AreEqual(response.TryGetContentValue<bool>(out status),false);

        }
        [TestMethod]
        public void PastEventAttendees_NullException_ReturnHttpStatusCodeBadRequest()
        {
            //Arrange
            var pastEvent_BAL = new Mock<IFetchPastEvents>();
            List<PastEventResponseModel> pastEventResponses = null;
            pastEvent_BAL.Setup(m => m.fetchPastEventAttendeesData(It.IsAny<int>())).Returns(pastEventResponses);
            var controller = new EventController(pastEvent_BAL.Object);
            //Assert
            Assert.ThrowsException<ArgumentNullException>(()=> controller.PastEventAttendees(It.IsAny<int>()));

        }
        public List<PastEventResponseModel> getPastEventResponseModelData()
        {
            List<PastEventResponseModel> pastEventResponseModelList = new List<PastEventResponseModel>();
            PastEventResponseModel pastEventResponseModel = new PastEventResponseModel();
            pastEventResponseModel.EventID = 60;
            pastEventResponseModel.eventName = "hello";
            pastEventResponseModel.numberOfStudentsPresent = 1;
            pastEventResponseModel.numberOfStudentsRegistered = 11;
            pastEventResponseModelList.Add(pastEventResponseModel);
            return pastEventResponseModelList;

        }

    }
}
