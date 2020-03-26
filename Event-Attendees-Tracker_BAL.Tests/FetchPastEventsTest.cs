using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Event_Attendees_Tracker_BAL.User_Actions;
using Event_Attendees_Tracker_CustomResponseModel;
using Moq;
using Event_Attendees_Tracker_DAL.DBQueries;
using System.Collections.Generic;

namespace Event_Attendees_Tracker_BAL.Tests
{
    [TestClass]
    public class FetchPastEventsTest
    {
        [TestMethod]
        public void FetchPastEvents_FakePastEventResponseModel_ReturnsPastEventResponseModel()
        {
            //Arrange
            var pastEvent_Db = new Mock<IPastEvent>();
            pastEvent_Db.Setup(m => m.fetchPastEventAttendeesData(It.IsAny<int>())).Returns(getPastEventResponseModelData());
            var pastEvent_BAL = new FetchPastEvents(pastEvent_Db.Object);
            //Act
            var actual = pastEvent_BAL.fetchPastEventAttendeesData(It.IsAny<int>());
            var expected = getPastEventResponseModelData();
            //Assert
            CollectionAssert.Equals(actual, expected);
        }

        [TestMethod]
        public void FetchPastEvents_PastEventResponseModel_ReturnsNull()
        {
            //Arrange
            var pastEvent_Db = new Mock<IPastEvent>();
            List<PastEventResponseModel> pastEventResponseModelList = null;
            pastEvent_Db.Setup(m => m.fetchPastEventAttendeesData(It.IsAny<int>())).Returns(pastEventResponseModelList);
            var pastEvent_BAL = new FetchPastEvents(pastEvent_Db.Object);
            //Act
            var actual = pastEvent_BAL.fetchPastEventAttendeesData(It.IsAny<int>());
            List<PastEventResponseModel> expected = null;
            //Assert
            CollectionAssert.Equals(actual, expected);
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
