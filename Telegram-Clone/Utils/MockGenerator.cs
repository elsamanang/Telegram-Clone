using Bogus;
using Bogus.DataSets;
using Bogus.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramClone.Models;

namespace TelegramClone.Utils
{
    public static class MockGenerator
    {
        public static IEnumerable<Message> GenerateMessages(int number)
        {
            var faker = new Faker<Message>()
                .RuleFor(m => m.Name, f => f.Person.FirstName)
                .RuleFor(m => m.UserName, f => f.Person.UserName)
                .RuleFor(m => m.UserPicture, f => f.Person.Avatar)
                .RuleFor(m => m.Phone, f => f.Person.Phone)
                .RuleFor(m => m.Bio, f => f.Company.CatchPhrase())
                .RuleFor(m => m.Time, f => f.Date.Past(Random.Shared.Next(1, 5), DateTime.Now))
                .RuleFor(m => m.Content, f => f.Lorem.Paragraph().Substring(0, 45) + "...");

            var data = faker.Generate(number);

            return data;
        }

        public static IEnumerable<MessageItem> GenerateMessageItems(int number)
        {
            string[] orientation = { "Left", "Right" };
            var faker = new Faker<MessageItem>()
                .RuleFor(mi => mi.Heure, f => f.Date.Past(Random.Shared.Next(1, 5), DateTime.Now).ToString("HH:mm"))
                .RuleFor(mi => mi.Message, f => f.Random.Word())
                .RuleFor(mi => mi.Orientation, f => orientation[new Random().Next(0,2)]);

            var data = faker.Generate(number);

            return data;
        }
    }
}
