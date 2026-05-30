using TrailStore.Domain.Countries.Enums;
using TrailStore.Domain.Countries.Models;

namespace TrailStore.Domain.Countries.Data;

public static class CountryRegistry
{
    private static readonly Dictionary<string, Country> Countries = new(StringComparer.OrdinalIgnoreCase)
    {
        // North America
        ["US"] = new Country
        {
            Code = "US", Name = "United States", PostalCode = PostalCodeRequirement.Required,
            HasRegion = true, PostalCodeLabel = "ZIP Code", RegionLabel = "State", PhoneCode = "+1"
        },
        ["CA"] = new Country
        {
            Code = "CA", Name = "Canada", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "Province", PhoneCode = "+1"
        },
        ["MX"] = new Country
        {
            Code = "MX", Name = "Mexico", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "State", PhoneCode = "+52"
        },

        // Europe - Western
        ["GB"] = new Country
        {
            Code = "GB", Name = "United Kingdom", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postcode", PhoneCode = "+44"
        },
        ["DE"] = new Country
        {
            Code = "DE", Name = "Germany", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+49"
        },
        ["FR"] = new Country
        {
            Code = "FR", Name = "France", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+33"
        },
        ["IT"] = new Country
        {
            Code = "IT", Name = "Italy", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+39"
        },
        ["ES"] = new Country
        {
            Code = "ES", Name = "Spain", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+34"
        },
        ["NL"] = new Country
        {
            Code = "NL", Name = "Netherlands", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+31"
        },
        ["BE"] = new Country
        {
            Code = "BE", Name = "Belgium", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+32"
        },
        ["CH"] = new Country
        {
            Code = "CH", Name = "Switzerland", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+41"
        },
        ["AT"] = new Country
        {
            Code = "AT", Name = "Austria", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+43"
        },
        ["PT"] = new Country
        {
            Code = "PT", Name = "Portugal", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+351"
        },
        ["IE"] = new Country
        {
            Code = "IE", Name = "Ireland", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Eircode", PhoneCode = "+353"
        },
        ["SE"] = new Country
        {
            Code = "SE", Name = "Sweden", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+46"
        },
        ["NO"] = new Country
        {
            Code = "NO", Name = "Norway", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+47"
        },
        ["DK"] = new Country
        {
            Code = "DK", Name = "Denmark", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+45"
        },
        ["FI"] = new Country
        {
            Code = "FI", Name = "Finland", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+358"
        },
        ["LU"] = new Country
        {
            Code = "LU", Name = "Luxembourg", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+352"
        },
        ["IS"] = new Country
        {
            Code = "IS", Name = "Iceland", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+354"
        },
        ["MT"] = new Country
        {
            Code = "MT", Name = "Malta", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+356"
        },
        ["CY"] = new Country
        {
            Code = "CY", Name = "Cyprus", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+357"
        },
        ["GR"] = new Country
        {
            Code = "GR", Name = "Greece", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+30"
        },
        ["MC"] = new Country
        {
            Code = "MC", Name = "Monaco", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+377"
        },
        ["LI"] = new Country
        {
            Code = "LI", Name = "Liechtenstein", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+423"
        },
        ["AD"] = new Country
        {
            Code = "AD", Name = "Andorra", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+376"
        },

        // Europe - Eastern
        ["PL"] = new Country
        {
            Code = "PL", Name = "Poland", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+48"
        },
        ["CZ"] = new Country
        {
            Code = "CZ", Name = "Czech Republic", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+420"
        },
        ["SK"] = new Country
        {
            Code = "SK", Name = "Slovakia", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+421"
        },
        ["HU"] = new Country
        {
            Code = "HU", Name = "Hungary", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+36"
        },
        ["RO"] = new Country
        {
            Code = "RO", Name = "Romania", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+40"
        },
        ["BG"] = new Country
        {
            Code = "BG", Name = "Bulgaria", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+359"
        },
        ["HR"] = new Country
        {
            Code = "HR", Name = "Croatia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+385"
        },
        ["SI"] = new Country
        {
            Code = "SI", Name = "Slovenia", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+386"
        },
        ["EE"] = new Country
        {
            Code = "EE", Name = "Estonia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+372"
        },
        ["LV"] = new Country
        {
            Code = "LV", Name = "Latvia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+371"
        },
        ["LT"] = new Country
        {
            Code = "LT", Name = "Lithuania", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+370"
        },
        ["RS"] = new Country
        {
            Code = "RS", Name = "Serbia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+381"
        },
        ["BA"] = new Country
        {
            Code = "BA", Name = "Bosnia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+387"
        },
        ["ME"] = new Country
        {
            Code = "ME", Name = "Montenegro", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+382"
        },
        ["MK"] = new Country
        {
            Code = "MK", Name = "North Macedonia", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+389"
        },
        ["AL"] = new Country
        {
            Code = "AL", Name = "Albania", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+355"
        },
        ["UA"] = new Country
        {
            Code = "UA", Name = "Ukraine", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+380"
        },
        ["MD"] = new Country
        {
            Code = "MD", Name = "Moldova", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+373"
        },
        ["BY"] = new Country
        {
            Code = "BY", Name = "Belarus", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+375"
        },

        // Asia - Pacific
        ["CN"] = new Country
        {
            Code = "CN", Name = "China", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "Province", PhoneCode = "+86"
        },
        ["JP"] = new Country
        {
            Code = "JP", Name = "Japan", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "Prefecture", PhoneCode = "+81"
        },
        ["KR"] = new Country
        {
            Code = "KR", Name = "South Korea", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+82"
        },
        ["AU"] = new Country
        {
            Code = "AU", Name = "Australia", PostalCode = PostalCodeRequirement.Required,
            HasRegion = true, PostalCodeLabel = "Postcode", RegionLabel = "State", PhoneCode = "+61"
        },
        ["NZ"] = new Country
        {
            Code = "NZ", Name = "New Zealand", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postcode", PhoneCode = "+64"
        },
        ["SG"] = new Country
        {
            Code = "SG", Name = "Singapore", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+65"
        },
        ["HK"] = new Country
        {
            Code = "HK", Name = "Hong Kong", PostalCode = PostalCodeRequirement.None, HasRegion = false,
            PhoneCode = "+852"
        },
        ["TW"] = new Country
        {
            Code = "TW", Name = "Taiwan", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+886"
        },
        ["IN"] = new Country
        {
            Code = "IN", Name = "India", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "PIN Code", RegionLabel = "State", PhoneCode = "+91"
        },
        ["ID"] = new Country
        {
            Code = "ID", Name = "Indonesia", PostalCode = PostalCodeRequirement.Required,
            HasRegion = true, PostalCodeLabel = "Postal Code", RegionLabel = "Province", PhoneCode = "+62"
        },
        ["TH"] = new Country
        {
            Code = "TH", Name = "Thailand", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+66"
        },
        ["MY"] = new Country
        {
            Code = "MY", Name = "Malaysia", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "State", PhoneCode = "+60"
        },
        ["PH"] = new Country
        {
            Code = "PH", Name = "Philippines", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "ZIP Code", PhoneCode = "+63"
        },
        ["VN"] = new Country
        {
            Code = "VN", Name = "Vietnam", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+84"
        },
        ["PK"] = new Country
        {
            Code = "PK", Name = "Pakistan", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "Province", PhoneCode = "+92"
        },
        ["BD"] = new Country
        {
            Code = "BD", Name = "Bangladesh", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+880"
        },
        ["LK"] = new Country
        {
            Code = "LK", Name = "Sri Lanka", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+94"
        },
        ["NP"] = new Country
        {
            Code = "NP", Name = "Nepal", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+977"
        },
        ["MN"] = new Country
        {
            Code = "MN", Name = "Mongolia", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+976"
        },
        ["KH"] = new Country
        {
            Code = "KH", Name = "Cambodia", PostalCode = PostalCodeRequirement.Optional,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+855"
        },
        ["MM"] = new Country
        {
            Code = "MM", Name = "Myanmar", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+95"
        },
        ["MO"] = new Country
        {
            Code = "MO", Name = "Macau", PostalCode = PostalCodeRequirement.None, HasRegion = false,
            PhoneCode = "+853"
        },

        // Middle East
        ["AE"] = new Country
        {
            Code = "AE", Name = "United Arab Emirates", PostalCode = PostalCodeRequirement.None,
            HasRegion = true, RegionLabel = "Emirate", PhoneCode = "+971"
        },
        ["SA"] = new Country
        {
            Code = "SA", Name = "Saudi Arabia", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+966"
        },
        ["IL"] = new Country
        {
            Code = "IL", Name = "Israel", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+972"
        },
        ["QA"] = new Country
        {
            Code = "QA", Name = "Qatar", PostalCode = PostalCodeRequirement.None, HasRegion = false,
            PhoneCode = "+974"
        },
        ["KW"] = new Country
        {
            Code = "KW", Name = "Kuwait", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+965"
        },
        ["BH"] = new Country
        {
            Code = "BH", Name = "Bahrain", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+973"
        },
        ["OM"] = new Country
        {
            Code = "OM", Name = "Oman", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+968"
        },
        ["JO"] = new Country
        {
            Code = "JO", Name = "Jordan", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+962"
        },
        ["LB"] = new Country
        {
            Code = "LB", Name = "Lebanon", PostalCode = PostalCodeRequirement.Optional, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+961"
        },
        ["IQ"] = new Country
        {
            Code = "IQ", Name = "Iraq", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+964"
        },
        ["TR"] = new Country
        {
            Code = "TR", Name = "Turkey", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+90"
        },
        ["IR"] = new Country
        {
            Code = "IR", Name = "Iran", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+98"
        },

        // South America
        ["BR"] = new Country
        {
            Code = "BR", Name = "Brazil", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "CEP", RegionLabel = "State", PhoneCode = "+55"
        },
        ["AR"] = new Country
        {
            Code = "AR", Name = "Argentina", PostalCode = PostalCodeRequirement.Required,
            HasRegion = true, PostalCodeLabel = "Postal Code", RegionLabel = "Province", PhoneCode = "+54"
        },
        ["CL"] = new Country
        {
            Code = "CL", Name = "Chile", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+56"
        },
        ["CO"] = new Country
        {
            Code = "CO", Name = "Colombia", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "Department", PhoneCode = "+57"
        },
        ["PE"] = new Country
        {
            Code = "PE", Name = "Peru", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+51"
        },
        ["VE"] = new Country
        {
            Code = "VE", Name = "Venezuela", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+58"
        },
        ["EC"] = new Country
        {
            Code = "EC", Name = "Ecuador", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+593"
        },
        ["BO"] = new Country
        {
            Code = "BO", Name = "Bolivia", PostalCode = PostalCodeRequirement.Optional, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+591"
        },
        ["PY"] = new Country
        {
            Code = "PY", Name = "Paraguay", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+595"
        },
        ["UY"] = new Country
        {
            Code = "UY", Name = "Uruguay", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+598"
        },

        // Africa
        ["ZA"] = new Country
        {
            Code = "ZA", Name = "South Africa", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+27"
        },
        ["NG"] = new Country
        {
            Code = "NG", Name = "Nigeria", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "State", PhoneCode = "+234"
        },
        ["EG"] = new Country
        {
            Code = "EG", Name = "Egypt", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+20"
        },
        ["KE"] = new Country
        {
            Code = "KE", Name = "Kenya", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+254"
        },
        ["GH"] = new Country
        {
            Code = "GH", Name = "Ghana", PostalCode = PostalCodeRequirement.Optional, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+233"
        },
        ["ET"] = new Country
        {
            Code = "ET", Name = "Ethiopia", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+251"
        },
        ["TZ"] = new Country
        {
            Code = "TZ", Name = "Tanzania", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+255"
        },
        ["UG"] = new Country
        {
            Code = "UG", Name = "Uganda", PostalCode = PostalCodeRequirement.None, HasRegion = false,
            PhoneCode = "+256"
        },
        ["MA"] = new Country
        {
            Code = "MA", Name = "Morocco", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+212"
        },
        ["DZ"] = new Country
        {
            Code = "DZ", Name = "Algeria", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+213"
        },
        ["TN"] = new Country
        {
            Code = "TN", Name = "Tunisia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+216"
        },
        ["SN"] = new Country
        {
            Code = "SN", Name = "Senegal", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+221"
        },
        ["CI"] = new Country
        {
            Code = "CI", Name = "Ivory Coast", PostalCode = PostalCodeRequirement.None, HasRegion = false,
            PhoneCode = "+225"
        },
        ["CM"] = new Country
        {
            Code = "CM", Name = "Cameroon", PostalCode = PostalCodeRequirement.None, HasRegion = false,
            PhoneCode = "+237"
        },
        ["AO"] = new Country
        {
            Code = "AO", Name = "Angola", PostalCode = PostalCodeRequirement.Optional, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+244"
        },
        ["MZ"] = new Country
        {
            Code = "MZ", Name = "Mozambique", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+258"
        },
        ["ZM"] = new Country
        {
            Code = "ZM", Name = "Zambia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+260"
        },
        ["ZW"] = new Country
        {
            Code = "ZW", Name = "Zimbabwe", PostalCode = PostalCodeRequirement.None, HasRegion = false,
            PhoneCode = "+263"
        },

        // Central America & Caribbean
        ["GT"] = new Country
        {
            Code = "GT", Name = "Guatemala", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+502"
        },
        ["CR"] = new Country
        {
            Code = "CR", Name = "Costa Rica", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+506"
        },
        ["PA"] = new Country
        {
            Code = "PA", Name = "Panama", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+507"
        },
        ["DO"] = new Country
        {
            Code = "DO", Name = "Dominican Republic", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+1-809"
        },
        ["JM"] = new Country
        {
            Code = "JM", Name = "Jamaica", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+1-876"
        },
        ["TT"] = new Country
        {
            Code = "TT", Name = "Trinidad and Tobago", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+1-868"
        },
        ["CU"] = new Country
        {
            Code = "CU", Name = "Cuba", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+53"
        },

        // Oceania
        ["FJ"] = new Country
        {
            Code = "FJ", Name = "Fiji", PostalCode = PostalCodeRequirement.None, HasRegion = false,
            PhoneCode = "+679"
        },
        ["PG"] = new Country
        {
            Code = "PG", Name = "Papua New Guinea", PostalCode = PostalCodeRequirement.Required,
            HasRegion = false, PostalCodeLabel = "Postal Code", PhoneCode = "+675"
        },
    };

    public static IEnumerable<Country> All => Countries.Values;
    public static IEnumerable<string> SupportedCountryCodes => Countries.Keys;

    public static Country? For(string countryCode)
        => Countries.GetValueOrDefault(countryCode);

    public static bool IsSupported(string countryCode)
        => Countries.ContainsKey(countryCode);
}