namespace applicationWpf
{
    public interface ConverterBase
    {
        string converterName { get; }

        string[] indexes { get; }

        string[] suffix { get; }

        double Convert(double a, int b, int c);
    }
}
