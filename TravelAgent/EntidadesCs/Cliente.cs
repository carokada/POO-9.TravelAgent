using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Cliente : Persona
   {
      private string cuit_cuil;

      public Cliente (uint dni, string nombre, string cuit_cuil) : base(dni, nombre)
      {
         Cuit_cuil = cuit_cuil;
      }

      public string Cuit_cuil
      {
         get => cuit_cuil;
         set => cuit_cuil = value.Length > 0 ? value : throw new ArgumentException(" el cuit/cuil no puede estar vacio.");
      }

      public override string ToString()
      {
         return $"{Nombre} ({Cuit_cuil})";
      }
   }
}
