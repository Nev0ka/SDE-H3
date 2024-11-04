namespace TDD_Table_booking
{
    public class TableBookingTests
    {
        [Fact]
        public void CanConfigureTables()
        {
            // Arrange
            var bookingSystem = new TableBookingSystem();

            // Act
            bookingSystem.ConfigureTables(5, 3);

            // Assert
            Assert.Equal(5, bookingSystem.TwoManTables);
            Assert.Equal(3, bookingSystem.FourManTables);
        }

        [Fact]
        public void CanHandleBookingTime()
        {
            // Arrange
            var bookingSystem = new TableBookingSystem();
            var bookingTime = new DateTime(2023, 10, 1, 19, 0, 0);
            bookingSystem.ConfigureTables(5, 3);

            // Act
            var result = bookingSystem.BookTable(bookingTime, 2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanBookTableForGuests()
        {
            // Arrange
            var bookingSystem = new TableBookingSystem();
            bookingSystem.ConfigureTables(5, 3);

            // Act
            var result = bookingSystem.BookTable(DateTime.Now, 2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CanCombineTablesForLargeGroup()
        {
            // Arrange
            var bookingSystem = new TableBookingSystem();
            bookingSystem.ConfigureTables(5, 3);

            // Act
            var result = bookingSystem.BookTable(DateTime.Now, 6);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CannotBookTableIfNotEnoughCapacity()
        {
            // Arrange
            var bookingSystem = new TableBookingSystem();
            bookingSystem.ConfigureTables(1, 1);

            // Act
            var result = bookingSystem.BookTable(DateTime.Now, 10);

            // Assert
            Assert.False(result);
        }
    }
}