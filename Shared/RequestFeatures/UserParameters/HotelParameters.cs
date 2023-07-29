namespace Shared.RequestFeatures.UserParameters;

public class HotelParameters : RequestParameters
{
    public uint MinStars { get; set; } = 1;
    public uint MaxStars { get; set; } = 5;

    public bool ValidStarsRange => MaxStars > MinStars;
}