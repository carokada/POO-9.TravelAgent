using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCs;

namespace DemoCs
{
   class Program
   {
      static void Main(string[] args)
      {
         string divisor = "----------------------------------------------------------";

         Console.WriteLine(divisor);
         Console.WriteLine(" creando personas...");
         Persona persona1 = new Persona(23456985, "mario juarez");
         Persona persona2 = new Persona(33156255, "brenda martinez");
         try
         {
            Persona persona3 = new Persona(15, "rafael bernal");
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         try
         {
            Persona persona3 = new Persona(34226512, "");
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         Console.WriteLine("\n mostrando personas cargadas:");
         Console.WriteLine(persona1);
         Console.WriteLine(persona2);

         Console.WriteLine($"\n {divisor}");
         Console.WriteLine(" creando tickets...");
         Ticket ticket1 = new Ticket(persona1, 500);
         Ticket ticket2 = new Ticket(persona1, 700);
         Ticket ticket3 = new Ticket(persona2, 600);
         try
         {
            Ticket ticket4 = new Ticket(null, 350);
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         try
         {
            Ticket ticket4 = new Ticket(persona2, -350);
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         Console.WriteLine("\n mostrando tickets cargados:");
         Console.WriteLine(ticket1);
         Console.WriteLine(ticket2);
         Console.WriteLine(ticket3);

         Console.WriteLine($"\n {divisor}");
         Console.WriteLine(" creando paquetes...");
         Paquete paquete1 = new Paquete("posadas-buenos aires", new DateTime(2025, 3, 15), new DateTime(2025, 3, 20));
         Paquete paquete2 = new Paquete("posadas-cordoba", new DateTime(2025, 3, 16), new DateTime(2025, 3, 18));
         try
         {
            Paquete paquete3 = new Paquete("", new DateTime(2025, 3, 15), new DateTime(2025, 3, 18));
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         try
         {
            Paquete paquete3 = new Paquete("posadas-corrientes", new DateTime(2025, 2, 15), new DateTime(2025, 3, 18));
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         try
         {
            Paquete paquete3 = new Paquete("posadas-corrientes", new DateTime(2025, 3, 15), new DateTime(2025, 2, 18));
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         Console.WriteLine("\n mostrando paquetes cargados:");
         Console.WriteLine(paquete1);
         Console.WriteLine(paquete2);

         Console.WriteLine($"\n {divisor}");
         Console.WriteLine(" cargando tickets en paquetes...");
         paquete1.AddTicket(ticket1);
         paquete1.AddTicket(ticket2);
         paquete2.AddTicket(ticket3);
         Console.WriteLine("\n mostrando tickets por paquete: \n");
         MostrarTicketsPorPaquete(paquete1);
         MostrarTicketsPorPaquete(paquete2);

         Console.WriteLine(divisor);
         Console.WriteLine(" creando clientes...");
         Cliente cliente1 = new Cliente(23456985, "mario juarez", "26-23456985-6");
         try
         {
            Cliente cliente2 = new Cliente(33156255, "brenda martinez", "");
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error: {e.Message}");
         }
         Console.WriteLine("\n mostrando cliente cargado:");
         Console.WriteLine(cliente1);

         Console.WriteLine($"\n {divisor}");
         Console.WriteLine(" creando venta...");
         Venta venta1 = new Venta(cliente1, DateTime.Now);
         Console.WriteLine(" cargando paquetes en venta...");
         venta1.AddPaquete(paquete1);
         venta1.AddPaquete(paquete2);
         Console.WriteLine("\n mostrando paquetes en venta: \n");
         MostrarPaquetesPorVenta(venta1);
         Console.WriteLine(" ejecutando RemovePaquete en venta: \n");
         venta1.RemovePaquete(paquete1);
         MostrarPaquetesPorVenta(venta1);

         //Console.WriteLine($"\n {divisor}");
         //Console.WriteLine("");
         //Console.WriteLine();
         Console.WriteLine(divisor);
         Console.WriteLine("\n presione una tecla para salir ");
         Console.ReadKey();
      }

      private static void MostrarTicketsPorPaquete(Paquete paquete)
      {
         Console.WriteLine($" tickets de paquete {paquete.Descripcion}");
         foreach (var ticket in paquete.GetTickets())
            Console.WriteLine($"\t ~ {ticket}");
         Console.WriteLine($"    -> dias: {paquete.NumeroDias}");
         Console.WriteLine($"    -> cantidad de tickets: {paquete.NumeroTickets}");
         Console.WriteLine($"    -> monto total: ${paquete.MontoTotal()}");
         Console.WriteLine();
      }

      private static void MostrarPaquetesPorVenta(Venta venta)
      {
         Console.WriteLine($" paquetes de {venta}");
         foreach (var paquete in venta.GetPaquetes())
            Console.WriteLine($"\t ~ {paquete}");
         Console.WriteLine($"    -> monto total: ${venta.MontoTotal()}");
         Console.WriteLine($"    -> el cliente es pasajero: {venta.IsClientePasajero()}");
         Console.WriteLine();
      }
   }
}
