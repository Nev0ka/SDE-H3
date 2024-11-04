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

        public bool BookTable(DateTime time, int guests)
        {
            int requiredTwoManTables = 0;
            int requiredFourManTables = 0;

            if (guests <= 2)
            {
                requiredTwoManTables = 1;
            }
            else if (guests <= 4)
            {
                requiredFourManTables = 1;
            }
            else
            {
                requiredFourManTables = guests / 4;
                guests %= 4;
                if (guests > 0)
                {
                    requiredTwoManTables = 1;
                }
            }

            if (requiredTwoManTables <= TwoManTables && requiredFourManTables <= FourManTables)
            {
                bookings.Add(new Booking { Time = time, Guests = guests });
                TwoManTables -= requiredTwoManTables;
                FourManTables -= requiredFourManTables;
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
