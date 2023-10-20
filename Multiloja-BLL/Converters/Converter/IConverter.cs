namespace Multiloja_BLL.Converters.Converter
{
    public interface IConverter<O, D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
