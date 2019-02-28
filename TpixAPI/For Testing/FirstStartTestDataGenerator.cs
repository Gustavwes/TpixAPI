using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixAPI.Models;
using TpixAPI.Services;

namespace TpixAPI.For_Testing
{
    public static class FirstStartTestDataGenerator
    {

        public static void GenerateFakeData() // run once until we create a persistent database
        {
            var context = new TpixContext();
            for (int i = 1; i < 10; i++)
            {
                context.Member.Add(new Member() { Email = $"test{i}@person.com", Username = $"TestPerson{i}" });
                context.SaveChanges();
                context.Category.Add(new Category()
                {
                    Title = $"Category{i}",
                    Description = $"This is a description for Category {i}",
                    FkCreatedBy = i,
                    ImgUrl = $"the path to the image file which will come later"
                });
                context.SaveChanges();
                for (int j = 1; j < 5; j++)
                {
                    context.Topic.Add(new Topic()
                    {
                        Title = $"Title{j} for Category{i}",
                        ImgUrl = $"Img url that will path to the image file",
                        FkCreatedBy = i,
                        CreatedAt = DateTime.UtcNow.AddDays(-j),
                        FkCategoryId = i,
                        MainBody = $"This is the main body for topic{j}"
                    });
                    context.SaveChanges();
                    for (int k = 1; k < 7; k++)
                    {
                        context.Post.Add(new Post()
                        {
                            MainBody = $"Main body for post{k} for topic{j} in category{i}",
                            CreatedAt = DateTime.UtcNow.AddDays(-k),
                            FkCreatedBy = i,
                            FkParentTopicId = j
                        });
                    }
                    context.SaveChanges();
                }
            }

            context.SaveChanges();

        }
    }
}
