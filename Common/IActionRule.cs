namespace Common
{
    public interface IActionRule
    {
        void Ejecutar(string estadoActual, string estadoNuevo);
    }

}
