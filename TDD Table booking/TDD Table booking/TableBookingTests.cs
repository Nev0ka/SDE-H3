namespace TDD_Table_booking
{
    public class TableBookingTests
    {
        [Fact]
        public void CanCombineTablesForLargeGroup()
        {
            // Arrange
            var bookingSystem = new TableBookingSystem();
            var bookingTime = new DateTime(2025, 10, 1, 19, 0, 0);
            bookingSystem.ConfigureTables(5, 3);

            // Act
            var result = bookingSystem.BookTable(bookingTime, 6);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CannotBookTableIfNotEnoughCapacity()
        {
            // Arrange
            var bookingSystem = new TableBookingSystem();
            var bookingTime = new DateTime(2025, 10, 5, 19, 0, 0);
            bookingSystem.ConfigureTables(1, 1);

            // Act
            var result = bookingSystem.BookTable(bookingTime, 10);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void SensableSeatArrangements()
        {
            // Arrange
            var bookingSystem = new TableBookingSystem();
            var bookingTimeForPartyOfOne = new DateTime(2025, 12, 3, 16, 0, 0);
            var bookingTimeForPartyOfFour = new DateTime(2025, 4, 3, 19, 0, 0);
            bookingSystem.ConfigureTables(1, 1);

            // Act
            var partyOfOne = bookingSystem.BookTable(bookingTimeForPartyOfOne, 1);
            var partyOfFour = bookingSystem.BookTable(bookingTimeForPartyOfFour, 4);

            // Assert
            Assert.True(partyOfOne);
            Assert.True(partyOfFour);
        }

        [Fact]
        public void CannotBookTableInPast()
        {
            // Arrange
            var bookingSystem = new TableBookingSystem();
            bookingSystem.ConfigureTables(5, 3);
            var pastTime = DateTime.Now.AddHours(-1);

            // Act
            var result = bookingSystem.BookTable(pastTime, 2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CannotBookTableForZeroPeople()
        {
            // Arrange
            var bookingSystem = new TableBookingSystem();
            bookingSystem.ConfigureTables(5, 3);

            // Act
            var result = bookingSystem.BookTable(DateTime.Now, 0);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void CannotBookTableForNegativePeople()
        {
            // Arrange
            var bookingSystem = new TableBookingSystem();
            var bookingTime = new DateTime(2025, 10, 1, 19, 0, 0);
            bookingSystem.ConfigureTables(5, 3);

            // Act
            var result = bookingSystem.BookTable(bookingTime, -1);

            // Assert
            Assert.False(result);
        }
    }
}