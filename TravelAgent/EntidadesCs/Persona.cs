using System;

namespace EntidadesCs
{
   public class Persona
   {
      private uint dni;
      private string nombre;

      public Persona (uint dni, string nombre)
      {
         Dni = dni;
         Nombre = nombre;
      }

      public uint Dni
      {
         get => dni;
         set => dni = (value > 1000000 && value < 99999999) ? value : throw new ArgumentException(" el valor del dni no es valido.");
      }

      public string Nombre
      {
         get => nombre;
         set => nombre = value.Length > 0 ? value : throw new ArgumentException(" el nombre no puede estar vacio.");
      }

      public override string ToString()
      {
         return $" persona: {Nombre} ({Dni})";
      }
   }
}
