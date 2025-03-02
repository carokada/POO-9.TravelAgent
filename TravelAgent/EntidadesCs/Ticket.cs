using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Ticket
   {
      private Persona persona; // asoc simple persona

      private decimal monto;

      public Ticket(Persona persona, decimal monto)
      {
         Persona = persona;
         Monto = monto;
      }

      public decimal Monto
      {
         get => monto;
         set => monto = value >= 0 ? value : throw new ArgumentException(" el monto no puede ser menor a cero.");
      }

      public Persona Persona
      {
         get => persona;
         set => persona = value ?? throw new ArgumentException(" la persona no puede ser nula.");
      }

      public override string ToString()
      {
         return $" ticket: {Persona} ({Monto})";
      }
   }
}
