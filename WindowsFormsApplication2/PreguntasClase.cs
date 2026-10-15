using System;

public class PreguntasClase
{
    public string Pregunta { get; set; }
    public string Personaje { get; set; }
    public string RutaImagen { get; set; }

	public PreguntasClase(string pregunta, string personaje, string rutaImagen)
	{
        Pregunta = pregunta;
        Personaje = personaje;
        RutaImagen = rutaImagen;
	}
}
