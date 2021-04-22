﻿using System.Collections.Generic;

namespace ApiControllers.Models
{
    public class MemoryRepository : IRepository
    {
        readonly Dictionary<int, Reservation> items;

        public MemoryRepository()
        {
            items = new Dictionary<int, Reservation>();
            new List<Reservation> {
                new Reservation { ClientName = "Элис", Location = "Зал заседаний" },
                new Reservation { ClientName = "Боб", Location = "Конференц-зал" },
                new Reservation { ClientName = "Джо", Location = "Зал переговоров 1" }
            }.ForEach(r => AddReservation(r));
        }

        public Reservation this[int id] => items.ContainsKey(id) ? items[id] : null;

        public IEnumerable<Reservation> Reservations => items.Values;

        public Reservation AddReservation(Reservation reservation)
        {
            if (reservation.ReservationId == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
                reservation.ReservationId = key;
            }
            items[reservation.ReservationId] = reservation;
            return reservation;
        }

        public void DeleteReservation(int id) => items.Remove(id);

        public Reservation UpdateReservation(Reservation reservation) => AddReservation(reservation);
    }
}
