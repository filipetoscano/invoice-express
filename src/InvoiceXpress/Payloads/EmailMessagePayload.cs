using System.Text.Json.Serialization;

namespace InvoiceXpress.Payloads;

/// <summary />
public class EmailMessagePayload
{
    /// <summary />
    [JsonPropertyName( "message" )]
    public EmailMessageEx EmailMessage { get; set; } = default!;


    /// <summary />
    public static EmailMessagePayload From( EmailMessage message )
    {
        return new EmailMessagePayload()
        {
            EmailMessage = new EmailMessageEx()
            {
                Client = new EmailClient()
                {
                    Email = message.To,
                    SaveEmailAsDefault = message.SaveEmailAsDefault,
                },
                Subject = message.Subject,
                Body = message.Body,
                BCC = message.BCC,
                CC = message.CC,
                IncludeLogo = message.IncludeLogo,
            },
        };
    }
}
