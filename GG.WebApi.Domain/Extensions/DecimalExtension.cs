namespace GG.CalculoCDB.Domain.Extensions
{
    public static class DecimalExtension
    {
        public static bool IsValorNuloOuZero(this double valor) => valor <= 0;
    }
}
