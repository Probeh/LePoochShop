using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Shared.Models.Entities
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
        // ======================================= //
        private DateTime? _created;
        private DateTime? _activeSince;
        private DateTime? _activeLast;
        private bool _isActive;
        // ======================================= //
        public string Title { get; set; }
        public string Details { get; set; }
        // ======================================= //
        protected BaseModel()
        {
            this.Created = DateTime.Now;
            this.IsActive = false;
            this.Title = this.GetType().Name;
            this.Details = $"{this.GetType().Name} Item #{this.GetHashCode()}";
        }
        protected BaseModel(bool isActive, string title, string details) : this()
        {
            Title = title;
            Details = details;
            IsActive = isActive;
        }
        protected BaseModel(DateTime? created, DateTime? activeSince, DateTime? activeLast, bool isActive, string title, string details) : this(isActive, title, details)
        {
            Created = created;
            ActiveSince = activeSince;
            ActiveLast = activeLast;
        }
        // ======================================= //
        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (_isActive) this.ActiveSince = DateTime.Now;
                else this.ActiveLast = DateTime.Now;
                _isActive = value;
            }
        }
        public DateTime? Created
        {
            get => _created;
            set => _created = value;
        }
        public DateTime? ActiveSince
        {
            get => _activeSince;
            set => _activeSince = value;
        }
        public DateTime? ActiveLast
        {
            get => _activeLast;
            set => _activeLast = value;
        }
        // ======================================= //
    }
    public abstract class BaseModel<TSource> : BaseModel where TSource : BaseModel<TSource>
    {
        protected BaseModel() { }
        protected BaseModel(bool isActive, string title, string details, DateTime? created = null) : base(isActive, title, details)
        {
            this.Created = created ?? created;
        }
    }
}