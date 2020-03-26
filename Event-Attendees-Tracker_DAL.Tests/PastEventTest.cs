using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Event_Attendees_Tracker_DAL.Models;
using Event_Attendees_Tracker_DAL.DBQueries;
using Event_Attendees_Tracker_CustomResponseModel;
using System.Collections.Generic;
using System.Linq;

namespace Event_Attendees_Tracker_DAL.Tests
{


    [TestClass]
    public class PastEventTest
    {
        [TestMethod]
        public void fetchPastEventAttendeesData_FakeEventDetails_ReturnPastEventResponseModel()
        {
            //Arrange
            var pastEventmock = new Mock<PastEvent>();
            //Act
            pastEventmock.Setup(m => m.getPastEventDetails(It.IsAny<int>())).Returns(getEventDetails());
            pastEventmock.CallBase = true;
            List<PastEventResponseModel> actual = pastEventmock.Object.fetchPastEventAttendeesData(It.IsAny<int>());
            List<PastEventResponseModel> expected = getPastEventResponseModelData();
            //Assert
                    CollectionAssert.Equals(actual, expected);
                
        }
        [TestMethod]
        public void fetchPastEventAttendeesData_NoEventDetails_ReturnNullReferenceException()
        {
            //Arrange
            var pastEventmock = new Mock<PastEvent>();
            //Act
            List <EventDetails> eventDetails= null;
            pastEventmock.Setup(m => m.getPastEventDetails(It.IsAny<int>())).Returns(eventDetails);
            pastEventmock.CallBase = true;
            //Assert
            Assert.ThrowsException<NullReferenceException>(() => pastEventmock.Object.fetchPastEventAttendeesData(It.IsAny<int>()));
        }
        [TestMethod]
        public void fetchPastEventAttendeesData_FakeEventDetails_ReturnsNull()
        {
            //Arrange
            var pastEventmock = new Mock<PastEvent>();
            //Act
            pastEventmock.Setup(m => m.getPastEventDetails(It.IsAny<int>())).Returns(getEventDetails_NoResponseData());
            pastEventmock.CallBase = true;
            List<PastEventResponseModel> actual = pastEventmock.Object.fetchPastEventAttendeesData(It.IsAny<int>());
            List<PastEventResponseModel> expected = getPastEventResponseModelData();
            //Assert
            CollectionAssert.Equals(actual, expected);

        }

        public List<EventDetails> getEventDetails()
        {
            List<EventDetails> eventDetailsList = new List<EventDetails>();
            EventDetails eventDetails = new EventDetails();
            eventDetails.ID = 60;
            eventDetails.EventName = "hello";
            eventDetails.Description = "gh8ikjhuygtf";
            eventDetails.Venue = "hello again";
            eventDetails.StartTime = new TimeSpan(10,00,00,0000000);
            eventDetails.EndTime = new TimeSpan(04,00,00,0000000);
            eventDetails.isActive = false;
            eventDetails.CreatedAt = new DateTime(2020, 03, 16);
            eventDetails.CreatedBy = 20;
            eventDetails.UpdatedBy = null;
            eventDetails.CanRegister = false;
            eventDetails.EventDate = new DateTime(2020, 03, 16,00,00,0000);
            eventDetails.PosterImage = @"C: \Users\Nikita_Agarwala\Desktop\ProjectE @T\event-attendees-tracker\Event-Attendees-Tracker\PosterImage\132288384000475655profile.png";
            eventDetails.UpdatedAt = null;
            eventDetailsList.Add(eventDetails);
            return eventDetailsList;
        }
        public List<EventDetails> getEventDetails_NoResponseData()
        {
            List<EventDetails> eventDetailsList = new List<EventDetails>();
            EventDetails eventDetails = new EventDetails();
            eventDetails.ID = 61;
            eventDetails.EventName = "hello";
            eventDetails.Description = "gh8ikjhuygtf";
            eventDetails.Venue = "hello again";
            eventDetails.StartTime = new TimeSpan(10, 00, 00, 0000000);
            eventDetails.EndTime = new TimeSpan(04, 00, 00, 0000000);
            eventDetails.isActive = false;
            eventDetails.CreatedAt = new DateTime(2020, 03, 16);
            eventDetails.CreatedBy = 20;
            eventDetails.UpdatedBy = null;
            eventDetails.CanRegister = false;
            eventDetails.EventDate = new DateTime(2020, 03, 16, 00, 00, 0000);
            eventDetails.PosterImage = @"C: \Users\Nikita_Agarwala\Desktop\ProjectE @T\event-attendees-tracker\Event-Attendees-Tracker\PosterImage\132288384000475655profile.png";
            eventDetails.UpdatedAt = null;
            eventDetailsList.Add(eventDetails);
            return eventDetailsList;
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
