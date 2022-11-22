namespace BlazorCssIsolation.Themes;

public interface IPresetColors
{
    IColor Blue { get; }
    IColor Cyan { get; }
    IColor Geekblue { get; }
    IColor Gold { get; }
    IColor Green { get; }
    IColor Grey { get; }
    IColor Lime { get; }
    IColor Magenta { get; }
    IColor Orange { get; }
    IColor Pink { get; }
    IColor Purple { get; }
    IColor Red { get; }
    IColor Volcano { get; }
    IColor Yellow { get; }
}

public class PresetColors : IPresetColors
{
    public IColor Blue => new HEX("#1890FF");

    public IColor Cyan => new HEX("#13C2C2");

    public IColor Geekblue => new HEX("#2F54EB");

    public IColor Gold => new HEX("#FAAD14");

    public IColor Green => new HEX("#52C41A");

    public IColor Grey => new HEX("#666666");

    public IColor Lime => new HEX("#A0D911");

    public IColor Magenta => new HEX("#EB2F96");

    public IColor Orange => new HEX("#FA8C16");

    public IColor Pink => new HEX("#EB2F96");

    public IColor Purple => new HEX("#722ED1");

    public IColor Red => new HEX("#F5222D");

    public IColor Volcano => new HEX("#FA541C");

    public IColor Yellow => new HEX("#FADB14");
}
