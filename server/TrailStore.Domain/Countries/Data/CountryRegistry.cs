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
            Code = "US", Name = "United States", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "ZIP Code", RegionLabel = "State", PhoneCode = "+1", TaxRate = 0m
        },
        ["CA"] = new Country
        {
            Code = "CA", Name = "Canada", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "Province", PhoneCode = "+1", TaxRate = 0m
        },
        ["MX"] = new Country
        {
            Code = "MX", Name = "Mexico", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "State", PhoneCode = "+52", TaxRate = 0.16m
        },

        // Europe - Western
        ["GB"] = new Country
        {
            Code = "GB", Name = "United Kingdom", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postcode", PhoneCode = "+44", TaxRate = 0.20m
        },
        ["DE"] = new Country
        {
            Code = "DE", Name = "Germany", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+49", TaxRate = 0.19m
        },
        ["FR"] = new Country
        {
            Code = "FR", Name = "France", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+33", TaxRate = 0.20m
        },
        ["IT"] = new Country
        {
            Code = "IT", Name = "Italy", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+39", TaxRate = 0.22m
        },
        ["ES"] = new Country
        {
            Code = "ES", Name = "Spain", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+34", TaxRate = 0.21m
        },
        ["NL"] = new Country
        {
            Code = "NL", Name = "Netherlands", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+31", TaxRate = 0.21m
        },
        ["BE"] = new Country
        {
            Code = "BE", Name = "Belgium", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+32", TaxRate = 0.21m
        },
        ["CH"] = new Country
        {
            Code = "CH", Name = "Switzerland", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+41", TaxRate = 0.077m
        },
        ["AT"] = new Country
        {
            Code = "AT", Name = "Austria", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+43", TaxRate = 0.20m
        },
        ["PT"] = new Country
        {
            Code = "PT", Name = "Portugal", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+351", TaxRate = 0.23m
        },
        ["IE"] = new Country
        {
            Code = "IE", Name = "Ireland", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Eircode", PhoneCode = "+353", TaxRate = 0.23m
        },
        ["SE"] = new Country
        {
            Code = "SE", Name = "Sweden", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+46", TaxRate = 0.25m
        },
        ["NO"] = new Country
        {
            Code = "NO", Name = "Norway", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+47", TaxRate = 0.25m
        },
        ["DK"] = new Country
        {
            Code = "DK", Name = "Denmark", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+45", TaxRate = 0.25m
        },
        ["FI"] = new Country
        {
            Code = "FI", Name = "Finland", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+358", TaxRate = 0.24m
        },
        ["LU"] = new Country
        {
            Code = "LU", Name = "Luxembourg", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+352", TaxRate = 0.17m
        },
        ["IS"] = new Country
        {
            Code = "IS", Name = "Iceland", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+354", TaxRate = 0.24m
        },
        ["MT"] = new Country
        {
            Code = "MT", Name = "Malta", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+356", TaxRate = 0.18m
        },
        ["CY"] = new Country
        {
            Code = "CY", Name = "Cyprus", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+357", TaxRate = 0.19m
        },
        ["GR"] = new Country
        {
            Code = "GR", Name = "Greece", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+30", TaxRate = 0.24m
        },
        ["MC"] = new Country
        {
            Code = "MC", Name = "Monaco", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+377", TaxRate = 0.20m
        },
        ["LI"] = new Country
        {
            Code = "LI", Name = "Liechtenstein", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+423", TaxRate = 0.077m
        },
        ["AD"] = new Country
        {
            Code = "AD", Name = "Andorra", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+376", TaxRate = 0.045m
        },

        // Europe - Eastern
        ["PL"] = new Country
        {
            Code = "PL", Name = "Poland", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+48", TaxRate = 0.23m
        },
        ["CZ"] = new Country
        {
            Code = "CZ", Name = "Czech Republic", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+420", TaxRate = 0.21m
        },
        ["SK"] = new Country
        {
            Code = "SK", Name = "Slovakia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+421", TaxRate = 0.20m
        },
        ["HU"] = new Country
        {
            Code = "HU", Name = "Hungary", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+36", TaxRate = 0.27m
        },
        ["RO"] = new Country
        {
            Code = "RO", Name = "Romania", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+40", TaxRate = 0.19m
        },
        ["BG"] = new Country
        {
            Code = "BG", Name = "Bulgaria", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+359", TaxRate = 0.20m
        },
        ["HR"] = new Country
        {
            Code = "HR", Name = "Croatia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+385", TaxRate = 0.25m
        },
        ["SI"] = new Country
        {
            Code = "SI", Name = "Slovenia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+386", TaxRate = 0.22m
        },
        ["EE"] = new Country
        {
            Code = "EE", Name = "Estonia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+372", TaxRate = 0.22m
        },
        ["LV"] = new Country
        {
            Code = "LV", Name = "Latvia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+371", TaxRate = 0.21m
        },
        ["LT"] = new Country
        {
            Code = "LT", Name = "Lithuania", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+370", TaxRate = 0.21m
        },
        ["RS"] = new Country
        {
            Code = "RS", Name = "Serbia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+381", TaxRate = 0.20m
        },
        ["BA"] = new Country
        {
            Code = "BA", Name = "Bosnia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+387", TaxRate = 0.17m
        },
        ["ME"] = new Country
        {
            Code = "ME", Name = "Montenegro", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+382", TaxRate = 0.21m
        },
        ["MK"] = new Country
        {
            Code = "MK", Name = "North Macedonia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+389", TaxRate = 0.18m
        },
        ["AL"] = new Country
        {
            Code = "AL", Name = "Albania", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+355", TaxRate = 0.20m
        },
        ["UA"] = new Country
        {
            Code = "UA", Name = "Ukraine", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+380", TaxRate = 0.20m
        },
        ["MD"] = new Country
        {
            Code = "MD", Name = "Moldova", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+373", TaxRate = 0.20m
        },
        ["BY"] = new Country
        {
            Code = "BY", Name = "Belarus", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+375", TaxRate = 0.20m
        },

        // Asia - Pacific
        ["CN"] = new Country
        {
            Code = "CN", Name = "China", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "Province", PhoneCode = "+86", TaxRate = 0.13m
        },
        ["JP"] = new Country
        {
            Code = "JP", Name = "Japan", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "Prefecture", PhoneCode = "+81", TaxRate = 0.10m
        },
        ["KR"] = new Country
        {
            Code = "KR", Name = "South Korea", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+82", TaxRate = 0.10m
        },
        ["AU"] = new Country
        {
            Code = "AU", Name = "Australia", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postcode", RegionLabel = "State", PhoneCode = "+61", TaxRate = 0.10m
        },
        ["NZ"] = new Country
        {
            Code = "NZ", Name = "New Zealand", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postcode", PhoneCode = "+64", TaxRate = 0.15m
        },
        ["SG"] = new Country
        {
            Code = "SG", Name = "Singapore", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+65", TaxRate = 0.09m
        },
        ["HK"] = new Country
        {
            Code = "HK", Name = "Hong Kong", PostalCode = PostalCodeRequirement.None, HasRegion = false,
            PhoneCode = "+852", TaxRate = 0m
        },
        ["TW"] = new Country
        {
            Code = "TW", Name = "Taiwan", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+886", TaxRate = 0.05m
        },
        ["IN"] = new Country
        {
            Code = "IN", Name = "India", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "PIN Code", RegionLabel = "State", PhoneCode = "+91", TaxRate = 0.18m
        },
        ["ID"] = new Country
        {
            Code = "ID", Name = "Indonesia", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "Province", PhoneCode = "+62", TaxRate = 0.11m
        },
        ["TH"] = new Country
        {
            Code = "TH", Name = "Thailand", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+66", TaxRate = 0.07m
        },
        ["MY"] = new Country
        {
            Code = "MY", Name = "Malaysia", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "State", PhoneCode = "+60", TaxRate = 0.08m
        },
        ["PH"] = new Country
        {
            Code = "PH", Name = "Philippines", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "ZIP Code", PhoneCode = "+63", TaxRate = 0.12m
        },
        ["VN"] = new Country
        {
            Code = "VN", Name = "Vietnam", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+84", TaxRate = 0.10m
        },
        ["PK"] = new Country
        {
            Code = "PK", Name = "Pakistan", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "Province", PhoneCode = "+92", TaxRate = 0.17m
        },
        ["BD"] = new Country
        {
            Code = "BD", Name = "Bangladesh", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+880", TaxRate = 0.15m
        },
        ["LK"] = new Country
        {
            Code = "LK", Name = "Sri Lanka", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+94", TaxRate = 0.18m
        },
        ["NP"] = new Country
        {
            Code = "NP", Name = "Nepal", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+977", TaxRate = 0.13m
        },
        ["MN"] = new Country
        {
            Code = "MN", Name = "Mongolia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+976", TaxRate = 0.10m
        },
        ["KH"] = new Country
        {
            Code = "KH", Name = "Cambodia", PostalCode = PostalCodeRequirement.Optional, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+855", TaxRate = 0.10m
        },
        ["MM"] = new Country
        {
            Code = "MM", Name = "Myanmar", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+95", TaxRate = 0.05m
        },
        ["MO"] = new Country
        {
            Code = "MO", Name = "Macau", PostalCode = PostalCodeRequirement.None, HasRegion = false, PhoneCode = "+853",
            TaxRate = 0m
        },

        // Middle East
        ["AE"] = new Country
        {
            Code = "AE", Name = "United Arab Emirates", PostalCode = PostalCodeRequirement.None, HasRegion = true,
            RegionLabel = "Emirate", PhoneCode = "+971", TaxRate = 0.05m
        },
        ["SA"] = new Country
        {
            Code = "SA", Name = "Saudi Arabia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+966", TaxRate = 0.15m
        },
        ["IL"] = new Country
        {
            Code = "IL", Name = "Israel", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+972", TaxRate = 0.17m
        },
        ["QA"] = new Country
        {
            Code = "QA", Name = "Qatar", PostalCode = PostalCodeRequirement.None, HasRegion = false, PhoneCode = "+974",
            TaxRate = 0m
        },
        ["KW"] = new Country
        {
            Code = "KW", Name = "Kuwait", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+965", TaxRate = 0m
        },
        ["BH"] = new Country
        {
            Code = "BH", Name = "Bahrain", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+973", TaxRate = 0.10m
        },
        ["OM"] = new Country
        {
            Code = "OM", Name = "Oman", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+968", TaxRate = 0.05m
        },
        ["JO"] = new Country
        {
            Code = "JO", Name = "Jordan", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+962", TaxRate = 0.16m
        },
        ["LB"] = new Country
        {
            Code = "LB", Name = "Lebanon", PostalCode = PostalCodeRequirement.Optional, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+961", TaxRate = 0.11m
        },
        ["IQ"] = new Country
        {
            Code = "IQ", Name = "Iraq", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+964", TaxRate = 0m
        },
        ["TR"] = new Country
        {
            Code = "TR", Name = "Turkey", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+90", TaxRate = 0.20m
        },
        ["IR"] = new Country
        {
            Code = "IR", Name = "Iran", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+98", TaxRate = 0.09m
        },

        // South America
        ["BR"] = new Country
        {
            Code = "BR", Name = "Brazil", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "CEP", RegionLabel = "State", PhoneCode = "+55", TaxRate = 0.17m
        },
        ["AR"] = new Country
        {
            Code = "AR", Name = "Argentina", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "Province", PhoneCode = "+54", TaxRate = 0.21m
        },
        ["CL"] = new Country
        {
            Code = "CL", Name = "Chile", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+56", TaxRate = 0.19m
        },
        ["CO"] = new Country
        {
            Code = "CO", Name = "Colombia", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "Department", PhoneCode = "+57", TaxRate = 0.19m
        },
        ["PE"] = new Country
        {
            Code = "PE", Name = "Peru", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+51", TaxRate = 0.18m
        },
        ["VE"] = new Country
        {
            Code = "VE", Name = "Venezuela", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+58", TaxRate = 0.16m
        },
        ["EC"] = new Country
        {
            Code = "EC", Name = "Ecuador", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+593", TaxRate = 0.12m
        },
        ["BO"] = new Country
        {
            Code = "BO", Name = "Bolivia", PostalCode = PostalCodeRequirement.Optional, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+591", TaxRate = 0.13m
        },
        ["PY"] = new Country
        {
            Code = "PY", Name = "Paraguay", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+595", TaxRate = 0.10m
        },
        ["UY"] = new Country
        {
            Code = "UY", Name = "Uruguay", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+598", TaxRate = 0.22m
        },

        // Africa
        ["ZA"] = new Country
        {
            Code = "ZA", Name = "South Africa", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+27", TaxRate = 0.15m
        },
        ["NG"] = new Country
        {
            Code = "NG", Name = "Nigeria", PostalCode = PostalCodeRequirement.Required, HasRegion = true,
            PostalCodeLabel = "Postal Code", RegionLabel = "State", PhoneCode = "+234", TaxRate = 0.075m
        },
        ["EG"] = new Country
        {
            Code = "EG", Name = "Egypt", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+20", TaxRate = 0.14m
        },
        ["KE"] = new Country
        {
            Code = "KE", Name = "Kenya", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+254", TaxRate = 0.16m
        },
        ["GH"] = new Country
        {
            Code = "GH", Name = "Ghana", PostalCode = PostalCodeRequirement.Optional, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+233", TaxRate = 0.15m
        },
        ["ET"] = new Country
        {
            Code = "ET", Name = "Ethiopia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+251", TaxRate = 0.15m
        },
        ["TZ"] = new Country
        {
            Code = "TZ", Name = "Tanzania", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+255", TaxRate = 0.18m
        },
        ["UG"] = new Country
        {
            Code = "UG", Name = "Uganda", PostalCode = PostalCodeRequirement.None, HasRegion = false,
            PhoneCode = "+256", TaxRate = 0.18m
        },
        ["MA"] = new Country
        {
            Code = "MA", Name = "Morocco", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+212", TaxRate = 0.20m
        },
        ["DZ"] = new Country
        {
            Code = "DZ", Name = "Algeria", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+213", TaxRate = 0.19m
        },
        ["TN"] = new Country
        {
            Code = "TN", Name = "Tunisia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+216", TaxRate = 0.19m
        },
        ["SN"] = new Country
        {
            Code = "SN", Name = "Senegal", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+221", TaxRate = 0.18m
        },
        ["CI"] = new Country
        {
            Code = "CI", Name = "Ivory Coast", PostalCode = PostalCodeRequirement.None, HasRegion = false,
            PhoneCode = "+225", TaxRate = 0.18m
        },
        ["CM"] = new Country
        {
            Code = "CM", Name = "Cameroon", PostalCode = PostalCodeRequirement.None, HasRegion = false,
            PhoneCode = "+237", TaxRate = 0.1925m
        },
        ["AO"] = new Country
        {
            Code = "AO", Name = "Angola", PostalCode = PostalCodeRequirement.Optional, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+244", TaxRate = 0.14m
        },
        ["MZ"] = new Country
        {
            Code = "MZ", Name = "Mozambique", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+258", TaxRate = 0.17m
        },
        ["ZM"] = new Country
        {
            Code = "ZM", Name = "Zambia", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+260", TaxRate = 0.16m
        },
        ["ZW"] = new Country
        {
            Code = "ZW", Name = "Zimbabwe", PostalCode = PostalCodeRequirement.None, HasRegion = false,
            PhoneCode = "+263", TaxRate = 0.15m
        },

        // Central America & Caribbean
        ["GT"] = new Country
        {
            Code = "GT", Name = "Guatemala", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+502", TaxRate = 0.12m
        },
        ["CR"] = new Country
        {
            Code = "CR", Name = "Costa Rica", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+506", TaxRate = 0.13m
        },
        ["PA"] = new Country
        {
            Code = "PA", Name = "Panama", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+507", TaxRate = 0.07m
        },
        ["DO"] = new Country
        {
            Code = "DO", Name = "Dominican Republic", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+1-809", TaxRate = 0.18m
        },
        ["JM"] = new Country
        {
            Code = "JM", Name = "Jamaica", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+1-876", TaxRate = 0.15m
        },
        ["TT"] = new Country
        {
            Code = "TT", Name = "Trinidad and Tobago", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+1-868", TaxRate = 0.125m
        },
        ["CU"] = new Country
        {
            Code = "CU", Name = "Cuba", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+53", TaxRate = 0m
        },

        // Oceania
        ["FJ"] = new Country
        {
            Code = "FJ", Name = "Fiji", PostalCode = PostalCodeRequirement.None, HasRegion = false, PhoneCode = "+679",
            TaxRate = 0.09m
        },
        ["PG"] = new Country
        {
            Code = "PG", Name = "Papua New Guinea", PostalCode = PostalCodeRequirement.Required, HasRegion = false,
            PostalCodeLabel = "Postal Code", PhoneCode = "+675", TaxRate = 0.10m
        }
    };

    public static IEnumerable<Country> All => Countries.Values;
    public static IEnumerable<string> SupportedCountryCodes => Countries.Keys;

    public static Country? For(string countryCode)
    {
        return Countries.GetValueOrDefault(countryCode);
    }

    public static bool IsSupported(string countryCode)
    {
        return Countries.ContainsKey(countryCode);
    }
}