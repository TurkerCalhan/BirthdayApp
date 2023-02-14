using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirthdayApp.Models
{
    public static class Repository
    {
        static Repository()
        {
            AddResponse(new UserResponse() { Name = "Türker Çalhan", Email = "turker.calhan@outlook.com", Phone = "05350850893", WillAttend = true });
            AddResponse(new UserResponse() { Name = "Ahmet Yılmaz", Email = "turker.calhan@outlook.com", Phone = "05350850893", WillAttend = true });
            AddResponse(new UserResponse() { Name = "Mehmet Yıldız", Email = "turker.calhan@outlook.com", Phone = "05350850893", WillAttend = true });
        }


        private static List<UserResponse> responses = new List<UserResponse>();

        public static List<UserResponse> Responses
        {
            get
            {
                return responses;
            }
        }

        public static void AddResponse(UserResponse response)
        {
            response.Id = (new Random()).Next(1, 9999);
            responses.Add(response);
        }

        public static void Update(UserResponse response)
        {
            var entity = Responses.Find(i => i.Id == response.Id);

            if (entity != null)
            {
                entity.Name = response.Name;
                entity.Phone = response.Phone;
                entity.Email = response.Email;
                entity.WillAttend = response.WillAttend;
            }
        }

        public static void Delete(int id)
        {
            var entity = Repository.Responses.Find(i => i.Id == id);

            if (entity != null)
            {
                Repository.Responses.Remove(entity);
            }
        }
    }
}