using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TouristGuide.Entities;

namespace TouristGuide.DataLayer
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TouristguideDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<TouristguideDbContext>>()))
            {
                if (context.Destinations.Any())
                {
                    return;   // Data was already seeded
                }
                context.Destinations.AddRange(
                    new Destination
                    {
                        DestinationId = 1,
                        Name = "All Destinations",
                        Url = "~/Tourist",
                        OpenInNewWindow = false
                    },
                new Destination
                {
                    DestinationId = 2,
                    Name = "Popular Destinations",
                    Url = "~/Tourist/Index/1",
                    OpenInNewWindow = false
                },
                new Destination
                {
                    DestinationId = 3,
                    Name = "Spiritual Destinations",
                    Url = "~/Tourist/Index/2",
                    OpenInNewWindow = false
                },
                new Destination
                {
                    DestinationId = 4,
                    Name = "Heritage Destinations",
                    Url = "~/Tourist/Index/3",
                    OpenInNewWindow = false
                },
                new Destination
                {
                    DestinationId = 5,
                    Name = "States & Union Territories",
                    Url = "~/Tourist/Index/4",
                    OpenInNewWindow = false
                });
                context.SaveChanges();
                if (context.Places.Any())
                {
                    return;   // Data was already seeded
                }
                context.Places.AddRange(
                new Place
                {
                    PlaceId = 1,
                    Name = "Delhi",
                    Picture = "",
                    Description = "With old monuments and busy neighbourhoods subtly merging with a vibrant and contemporary cosmopolitan world, Delhi, the capital of India, is a fascinating tourist destination. Poised along the banks of River Yamuna, Delhi, which is almost 1,000 years old,",
                    Attraction = "India Gate, Red Fort, Akshardham, Jama Masjid",
                    Experiences = "Heritage, Spritual, Food And Cuisine",
                    Distance = 1,
                    DestinationId = 1
                },
                new Place
                {
                    PlaceId = 2,
                    Name = "Varanasi",
                    Picture = "",
                    Description = "One of the oldest living inhabitations of the world, the sacred city of Varanasi or Benaras, nestled on the banks of the holy Ganges river, has been attracting pilgrims for centuries. Celebrated author Mark Twain, who visited India in the last decade of the 19th century",
                    Attraction = "Ganga Ghat, Dashashwamedh Ghat, Sarnath, Banaras Hindu University",
                    Experiences = "Baati Chokha, Lassi, Kachori, Banarasi Paan",
                    Distance = 1,
                    DestinationId = 2
                },
                new Place
                {
                    PlaceId = 3,
                    Name = "Gaya",
                    Picture = "",
                    Description = "Gaya is a holy city beside the Falgu River, in the northeast Indian state of Bihar. It’s known for 18th-century Vishnupad Mandir, a riverside temple with an octagonal shrine.",
                    Attraction = "ancient Mangla Gauri Temple, Vishnupad Temple, Bodh Gaya, Maha Bodhi Temple",
                    Experiences = "Heritage, Spritual, Food And Cuisine",
                    Distance = 1,
                    DestinationId = 2
                },
                new Place
                {
                    PlaceId = 4,
                    Name = "Puri",
                    Picture = "",
                    Description = "Spirituality and divinity echo through every by-lane of the temple city of Puri. A very popular destination of pilgrimage for Hindus, the city is sprawled along the long and pristine coastline of the Bay of Bengal, in the state of Odisha. Buzzing with devotees, who come here to pay obeisance at the Lord Jagannath Temple",
                    Attraction = "Balighai Beach, Brahmagiri, Golden Beach, Chilka Lake",
                    Experiences = "Nature, Art and Craft, Food And Cuisine",
                    Distance = 1,
                    DestinationId = 3
                });
                context.SaveChanges();
                if (context.AboutIndias.Any())
                {
                    return;   // Data was already seeded
                }
                context.AboutIndias.AddRange(
                new AboutIndia
                {
                    Id = 1,
                    About = "India is one of the oldest civilizations in the world with a kaleidoscopic variety and rich cultural heritage. It has achieved all-round socio-economic progress during the last 65 years of its Independence. India has become self-sufficient in agricultural production and is now one of the top industrialized countries in the world and one of the few nations to have gone into outer space to conquer nature for the benefit of the people. It covers an area of 32, 87,263 sq. km, extending from the snow-covered Himalayan heights to the tropical rain forests of the south. As the 7th largest country in the world, India stands apart from the rest of Asia, marked off as it is by mountains and the sea, which give the country a distinct geographical entity. Bounded by the Great Himalayas in the north, it stretches southwards and at the Tropic of Cancer, tapers off into the Indian Ocean between the Bay of Bengal on the east and the Arabian Sea on the west. As you travel, India offers a range of vast tourism choices, diverse in land and nature, people, tribes, cuisine, faiths, dance forms, music, arts, crafts, adventure, sport, spirituality, history; even these vary as you journey from one state to another. As a country, India has achieved all-round socio-economic progress in the last 70 years of independence. The change is clearly visible in the Tier I and Tier II cities. However, the fascinating aspect lies in the stark difference as you travel through the new and old parts of its cities. From world-class airports and hotels, luxurious shopping malls, restaurants, pubs and cafes to overcrowded streets and alleyways, in the same cities, filled with thousands of little shops offering every possible modern and ethnic product and native street food is a fascinating experience.",
                    Visa = "All foreign nationals entering India are required to possess a valid international travel document in the form of a national passport with a valid visa obtained from an Indian Mission or Post abroad. Tourist Visa can only be granted to a foreigner who does not have a residence or occupation in India and whose sole objective of visiting India is recreation, sight seeing, casual visit to meet friends and relatives, etc.",
                    Currency = "India Rupees",
                    Language = "Hindi, English, Bengali, Marathi, Telugu, Tamil, Gujarati, Urdu, Kannada, Odia, Malayalam, Punjabi, Sanskrit",
                    State = "Andhra Pradesh, Arunachal Pradesh, Assam, Bihar, Chhattisgarh, Goa, Gujarat, Haryana, Himachal Pradesh, Jharkhand, Karnataka, Kerala, Madhya Pradesh, Maharashtra, Manipur, Meghalaya, Mizoram, Nagaland, Odisha, Punjab, Rajasthan, Sikkim, Tamil Nadu, Telangana, Tripura, Uttar Pradesh, Uttarakhand, West Bengal.",
                    UNION_TERRITORIES = "Andaman & Nicobar, Chandigarh, Dadra & Nagar Haveli, Daman & Diu, Delhi, Jammu & Kashmir, Ladakh, Lakshadweep, Puducherry",
                    Climate = "SUMME, WINTER, RAINY, SPRING",
                    How_Visit = "If you are from out of india, have a valid passport and visa., you can travel by air and train as well by road in india."
                });
                context.SaveChanges();
            }
        }
    }
}
