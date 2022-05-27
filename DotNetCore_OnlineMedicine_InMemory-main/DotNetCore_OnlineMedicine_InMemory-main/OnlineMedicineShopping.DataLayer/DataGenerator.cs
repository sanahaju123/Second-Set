using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineMedicineShopping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineMedicineShopping.DataLayer
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MedicineDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<MedicineDbContext>>()))
            {
                if (context.Categories.Any())
                {
                    return;   // Data was already seeded
                }
                context.Categories.AddRange(
                    new Category
                    {
                        Id = 1,
                        Title = "All Medicine",
                        Url = "~/",
                        OpenInNewWindow = false
                    },
                new Category
                {
                    Id = 2,
                    Title = "Hair & Beauty",
                    Url = "~/Medicine/Index/1",
                    OpenInNewWindow = false
                },
                new Category
                {
                    Id = 3,
                    Title = "Baby & Mother",
                    Url = "~/Medicine/Index/2",
                    OpenInNewWindow = false
                },
                new Category
                {
                    Id = 4,
                    Title = "Digital Devices",
                    Url = "~/Medicine/Index/3",
                    OpenInNewWindow = false
                },
                new Category
                {
                    Id = 5,
                    Title = "Food & Beverages",
                    Url = "~/Medicine/Index/4",
                    OpenInNewWindow = false
                },
                new Category
                {
                    Id = 6,
                    Title = "Women's Care",
                    Url = "~/Medicine/Index/5",
                    OpenInNewWindow = false
                },
                new Category
                {
                    Id = 7,
                    Title = "Men's Care",
                    Url = "~/Medicine/Index/6",
                    OpenInNewWindow = false
                });
                context.SaveChanges();
                if (context.Medicines.Any())
                {
                    return;   // Data was already seeded
                }
                context.Medicines.AddRange(
                new Medicine
                {
                    MedicineId = 1,
                    Name = "CETAPHIL GENTLE SKIN CLEANSER, 125ML",
                    Details = "Gentle face wash, Cetaphil Gentle Skin Cleanser",
                    Price = 129,
                    Size = "125 ML",
                    Stock = 10,
                    CatId = 1,
                    Features = "Feature 1	Gentle face wash, Feature 2   Trusted brand ,Feature 3   Easy to Use, Feature 4   Alcohol free formulation,FREE SHIPPING"
                },
                new Medicine
                {
                    MedicineId = 2,
                    Name = "JOHNSON'S TOP TO TOE BABY WASH 210ML",
                    Details = "A mother’s love is the most trusted test for mildness. When a new life is placed in your arms, you only let the purest and mildest touch her. This is what has inspired us to develop the Johnson’s top-to-toe range. It is clinically proven mild, for a newborn’s first bath. So what touches your baby is always as mild as your touch and as pure as your love. Johnson’s top-to-toe baby wash is a specially designed a perfectly pH balanced cleanser, as mild as pure water, for your baby's delicate skin and eyes. *Based on survey conducted by IMS health in selected Metro cities with Pediatricians of India during Aug-Sept 14.",
                    Brand = "JOHNSON & JOHNSON",
                    Price = 150,
                    Size = "210 ML",
                    Stock = 10,
                    CatId = 2,
                    Features = "Feature 1	Hypoallergenic, Dermatologist tested, Feature 2   No added parabens, Feature 3   Every Johnson's product passes a 5 level safety assurance process, Feature 4   No 1 Doctor recommended brand, FREE SHIPPING"
                });
                context.SaveChanges();
                if (context.Doctors.Any())
                {
                    return;   // Data was already seeded
                }
                context.Doctors.AddRange(
                new Doctor
                {
                    DoctorId = 1,
                    Name = "Rajnish Ranjan",
                    Specialization = "Eye Spe...",
                    Qualification = "MBBS DMCH",
                    PracticingFrom = DateTime.Now
                 });
                context.SaveChanges();
            }
        }
    }
}
