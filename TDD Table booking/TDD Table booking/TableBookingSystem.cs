using System;
using System.Collections.Generic;

namespace TDD_Table_booking
{
    public class TableBookingSystem
    {
        public int TwoManTables { get; private set; }
        public int FourManTables { get; private set; }
        private List<Booking> bookings = new List<Booking>();

        public void ConfigureTables(int twoManTables, int fourManTables)
        {
            TwoManTables = twoManTables;
            FourManTables = fourManTables;
        }

        public bool BookTable(DateTime time, int amountOfGuests)
        {
            if (time < DateTime.Now || amountOfGuests <= 0)
            {
                return false;
            }

            int reservedTwoManTables = 0;
            int reservedFourManTables = 0;

            if (amountOfGuests <= 2)
            {
                if (TwoManTables > 0)
                {
                    reservedTwoManTables = 1;
                }
                else if (FourManTables > 0)
                {
                    reservedFourManTables = 1;
                }
            }
            else if (amountOfGuests <= 4)
            {
                if (FourManTables > 0)
                {
                    reservedFourManTables = 1;
                }
                else if (TwoManTables >= 2)
                {
                    reservedTwoManTables = 2;
                }
            }
            else
            {
                reservedFourManTables = amountOfGuests / 4;
                amountOfGuests %= 4;
                if (amountOfGuests > 0)
                {
                    reservedTwoManTables = 1;
                }
            }

            if (reservedTwoManTables <= TwoManTables && reservedFourManTables <= FourManTables)
            {
                bookings.Add(new Booking { Time = time, Guests = amountOfGuests });
                TwoManTables -= reservedTwoManTables;
                FourManTables -= reservedFourManTables;
                return true;
            }

            return false;
        }

        private class Booking
        {
            public DateTime Time { get; set; }
            public int Guests { get; set; }
        }
    }
}
