namespace Shared.RequestFeatures;

public class RoomParameters : RequestParameters 
{
    public uint MinSleepingPlaces { get; set; } = 1;
    public uint MaxSleepingPlaces { get; set; } = 16;

    public bool ValidSleepingPlacesRange => MaxSleepingPlaces > MinSleepingPlaces;
}