namespace tx.Data;

public class SizeEntity
{
    public uint Width { get; set; }
    public uint Depth { get; set; }
    public uint Height { get; set; }

    public static implicit operator Size(SizeEntity e)
    {
        return new Size
        {
            Width = e.Width,
            Depth = e.Depth,
            Height = e.Height
        };
    }
}