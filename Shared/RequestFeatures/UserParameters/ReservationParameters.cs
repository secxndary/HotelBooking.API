namespace Shared.RequestFeatures.UserParameters;

public class ReservationlParameters : RequestParameters
{
    public DateTime MinDateEntry { get; set; }
    public DateTime MaxDateEntry { get; set; }

    public DateTime MinDateExit { get; set; }
    public DateTime MaxDateExit{ get; set; }

    public bool ValidDateEntry => MaxDateEntry > MinDateEntry;
    public bool ValidDateExit => MaxDateExit > MinDateExit;
}