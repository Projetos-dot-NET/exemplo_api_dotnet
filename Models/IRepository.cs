using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exemplo_macoratti.Models
{
    public interface IRepository
    {
        IEnumerable<Reserva> Reservas { get; }
        Reserva this[int id] { get; }
        Reserva AddReserva(Reserva reserva);
        Reserva UpdateReserva(Reserva reserva);
        void DeleteReserva(int id);
    }
}
