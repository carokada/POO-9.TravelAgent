using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Paquete
   {
      private List<Ticket> tickets;

      private string descripcion;
      private DateTime fechaInicial;
      private DateTime fechaFinal;
      public ushort NumeroDias { get => CalcularNumeroDias(); }
      public byte NumeroTickets { get; private set; } = 0;

      public Paquete (string descripcion, DateTime fechaInicial, DateTime fechaFinal)
      {
         tickets = new List<Ticket>();

         Descripcion = descripcion;
         FechaInicial = fechaInicial;
         FechaFinal = fechaFinal;
      }

      public string Descripcion
      {
         get => descripcion;
         set => descripcion = value.Length > 0 ? value : throw new ArgumentException(" la descripcion no puede estar vacia.");
      }

      public DateTime FechaInicial
      {
         get => fechaInicial;
         set => fechaInicial = value >= DateTime.Now ? value : throw new ArgumentException(" la fecha no puede ser menor a la del sistema.");
      }

      public DateTime FechaFinal
      {
         get => fechaFinal;
         set => fechaFinal = value >= FechaInicial ? value : throw new ArgumentException(" la fecha no puede ser menor a la fecha inicial.");
      }

      public ushort CalcularNumeroDias()
      {
         TimeSpan diferencia = FechaFinal - FechaInicial;
         return (ushort)diferencia.Days;
      }

      public void AddTicket(Ticket ticket)
      {
         if (ticket == null)
            throw new ArgumentException(" el ticket no puede ser nulo.");
         if (tickets.Contains(ticket))
            throw new ArgumentException(" el ticket ya se encuentra en el paquete.");
         tickets.Add(ticket);
         NumeroTickets++;
      }

      public void RemoveTicket(Ticket ticket)
      {
         if (ticket == null)
            throw new ArgumentException(" el ticket no puede ser nulo.");
         if (!tickets.Contains(ticket))
            throw new ArgumentException(" el ticket no se encuentra en el paquete.");
         tickets.Remove(ticket);
         NumeroTickets--;
      }

      public List<Ticket> GetTickets()
      {
         return tickets;
      }

      public decimal MontoTotal()
      {
         decimal montoTotal = 0;
         foreach (var ticket in tickets)
            montoTotal += ticket.Monto;
         return montoTotal;
      }

      public override string ToString()
      {
         return $" paquete: {Descripcion} \n\t fecha inicio: {FechaInicial.ToString("dd/MM/yy")} \t fecha final: {FechaFinal.ToString("dd/MM/yy")} \t monto total: ${MontoTotal()}";
      }
   }
}
