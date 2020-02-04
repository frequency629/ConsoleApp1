namespace ConsoleApp1.Mappers
{
    public interface Mapper<out TTo, in TFrom>
    {
        TTo Map(TFrom source);
    }
}
