using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpixAPI.Data;
using TpixAPI.Models;
using TpixAPI.Models.Database;
using TpixAPI.Services;

namespace TpixAPI.Services.Helpers.For_Testing
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
                            MainBody = $"Main body for post{k} for topic{j} by person{i}",
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

        public static void GenerateFakePostsForTopics(int minTopicId,int maxTopicId, int amountOfPosts)
        {
            var context = new TpixContext();
            var memberId = 1;
            for (int i = minTopicId; i < maxTopicId; i++)
            {
                for (int j = 0; j < amountOfPosts; j++)
                {
                    context.Post.Add(new Post()
                    {
                        MainBody = $"Main body for post{j} for topic{i}",
                        CreatedAt = DateTime.UtcNow.AddDays(-j),
                        FkCreatedBy = memberId,
                        FkParentTopicId = i
                    });
                }

                memberId++;
                if (memberId > 9)
                    memberId = 1;
            }
            context.SaveChanges();
        }
    }
}
