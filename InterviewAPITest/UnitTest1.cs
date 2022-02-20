using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterviewAPI.Controllers;
using System;
using System.Net.Http;
using System.Web.Http;

namespace InterviewAPITest {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void DayBefore() {
            // Arrange
            var dateController = new DateController();
            dateController.Request = new HttpRequestMessage();
            dateController.Configuration = new HttpConfiguration();

            // Act
            var response = dateController.Get(DateTime.UtcNow.AddDays(-1).DayOfWeek.ToString());

            // Assert
            Assert.IsTrue(response.TryGetContentValue(out string returnDateAsString));
            Assert.IsTrue(DateTime.TryParse(returnDateAsString, out DateTime returnDate));
            Assert.AreEqual(DateTime.UtcNow.AddDays(6).ToString("dd-MMM-yyyy"), returnDate.ToString("dd-MMM-yyyy"));
        }

        [TestMethod]
        public void SameDay() {
            // Arrange
            var dateController = new DateController();
            dateController.Request = new HttpRequestMessage();
            dateController.Configuration = new HttpConfiguration();

            // Act
            var response = dateController.Get(DateTime.UtcNow.DayOfWeek.ToString());

            // Assert
            Assert.IsTrue(response.TryGetContentValue<string>(out string returnDateAsString));
            Assert.IsTrue(DateTime.TryParse(returnDateAsString, out DateTime returnDate));
            Assert.AreEqual(DateTime.UtcNow.AddDays(7).ToString("dd-MMM-yyyy"), returnDate.ToString("dd-MMM-yyyy"));
        }

        [TestMethod]
        public void DayAfter() {
            // Arrange
            var dateController = new DateController();
            dateController.Request = new HttpRequestMessage();
            dateController.Configuration = new HttpConfiguration();

            // Act
            var response = dateController.Get(DateTime.UtcNow.AddDays(1).DayOfWeek.ToString());

            // Assert
            Assert.IsTrue(response.TryGetContentValue(out string returnDateAsString));
            Assert.IsTrue(DateTime.TryParse(returnDateAsString, out DateTime returnDate));
            Assert.AreEqual(DateTime.UtcNow.AddDays(1).ToString("dd-MMM-yyyy"), returnDate.ToString("dd-MMM-yyyy"));
        }
    }
}
