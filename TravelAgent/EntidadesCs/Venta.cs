using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Venta
   {
      private List<Paquete> paquetes;
      private Cliente cliente;

      private DateTime fecha;

      public Venta (Cliente cliente, DateTime fecha)
      {
         paquetes = new List<Paquete>();

         Cliente = cliente;
         Fecha = fecha;
      }

      public DateTime Fecha
      {
         get => fecha;
         set => fecha = value >= DateTime.Today ? value : throw new ArgumentException(" la fecha no puede ser menor a la del sistema.");
      }

      public Cliente Cliente
      {
         get => cliente;
         set => cliente = value ?? throw new ArgumentException(" el cliente no puede ser nulo.");
      }

      public void AddPaquete(Paquete paquete)
      {
         if (paquete == null)
            throw new ArgumentException(" el paquete no puede ser nulo.");
         if (paquetes.Contains(paquete))
            throw new ArgumentException(" el paquete ya se encuentra en el paquete.");
         paquetes.Add(paquete);
      }

      public void RemovePaquete(Paquete paquete)
      {
         if (paquete == null)
            throw new ArgumentException(" el paquete no puede ser nulo.");
         if (!paquetes.Contains(paquete))
            throw new ArgumentException(" el paquete no se encuentra en el paquete.");
         paquetes.Remove(paquete);
      }

      public List<Paquete> GetPaquetes()
      {
         return paquetes;
      }

      public decimal MontoTotal()
      {
         decimal montoTotal = 0;
         foreach (var paquete in paquetes)
            montoTotal += paquete.MontoTotal();
         return montoTotal;
      }

      public bool IsClientePasajero()
      {
         foreach (var paquete in paquetes)
         {
            foreach (var ticket in paquete.GetTickets())
            {
               if (ticket.Persona.Dni == Cliente.Dni)
                  return true;
            }
         }
         return false;
      }

      public override string ToString()
      {
         return $" venta -> [{Fecha.ToString("dd/MM/yy")}] {Cliente.Nombre} ";
      }
   }
}
