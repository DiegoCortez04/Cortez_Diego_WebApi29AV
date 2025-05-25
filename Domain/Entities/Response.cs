using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    // Esta clase sirve para enviar respuestas estándar desde la API, sin importar el tipo de dato que se devuelve.
    public class Response<T>
    {
        // Constructor vacío (por si se necesita crear la respuesta sin datos aún)
        public Response() { }

        // Constructor para respuestas exitosas, con datos y mensaje opcional
        public Response(T data, string message = null)
        {
            Succeded = true;    // Indica que la operación fue exitosa
            Message = message;  // Mensaje adicional (opcional)
            Result = data;      // Resultado o datos devueltos
        }

        // Constructor para respuestas fallidas, solo con mensaje
        public Response(string message)
        {
            Succeded = false;   // Indica que la operación falló
            Message = message;  // Mensaje de error
        }

        // Indica si la operación fue exitosa o no
        public bool Succeded { get; set; }

        // Mensaje que acompaña la respuesta (puede ser de éxito o error)
        public string Message { get; set; }

        // Resultado de la operación (puede ser cualquier tipo de dato)
        public T Result { get; set; }
    }
}
