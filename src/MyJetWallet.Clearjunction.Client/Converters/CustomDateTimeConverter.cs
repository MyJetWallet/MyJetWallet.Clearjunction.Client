using Newtonsoft.Json.Converters;

namespace MyJetWallet.ClearJunction.Converters;

class CustomDateTimeConverter : IsoDateTimeConverter
{
    public CustomDateTimeConverter()
    {
        base.DateTimeFormat = "yyyy-MM-dd";
    }
}