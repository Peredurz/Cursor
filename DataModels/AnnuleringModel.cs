using System.Text.Json.Serialization;

/// <summary>
/// Dit is de <c>AnnuleringModel</c> class. Dit is een model klasse die de attributen van een annulering bevat.
/// </summary>
/// <remarks>
/// Dit is de <c>AnnuleringModel</c> class.
/// <example>
/// Hieronder staat een voorbeeld van een annulering model.
/// <code>
///    AnnuleringModel annulering = new AnnuleringModel("test@test", 1);
/// 
/// </code>
/// </example>
/// </remarks>
public class AnnuleringModel
{
    [JsonPropertyName("id")]
    public int ID { get; set; }

    [JsonPropertyName("emailAddress")]
    public string EmailAddress { get; set; }

    [JsonPropertyName("ReservationID")]
    public int ReservationID { get; set; }

    private static int _id = 0;
    public AnnuleringModel(string emailAddress, int reservationID)
    {
        ID = _id++;
        EmailAddress = emailAddress;
        ReservationID = reservationID;
    }
}