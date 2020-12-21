using System;

namespace Core.Shared.Models.Entities
{
    public class ProfileModel<TSource> : BaseModel<TSource> where TSource : BaseModel<TSource>
    {
        // ======================================= //
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Picture { get; set; }
        // ======================================= //
        public ProfileModel() { }
        public ProfileModel(int age, string gender, string picture, bool isActive, string title, string details, DateTime? created = null) : base(isActive, title, details, created)
        {
            this.Age = age;
            this.Gender = gender;
            this.Picture = picture;
        }
    }
}