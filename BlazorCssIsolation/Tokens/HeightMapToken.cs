namespace BlazorCssIsolation.Tokens;

public partial record HeightMapToken : TokenBase
{
    public HeightMapToken(double controlHeightSM, double controlHeightXS, double controlHeightLG)
    {
        ControlHeightSM = controlHeightSM;
        ControlHeightXS = controlHeightXS;
        ControlHeightLG = controlHeightLG;
    }

    internal double ControlHeightXS { get; }
    internal double ControlHeightLG { get; }
    internal double ControlHeightSM { get; }
}
