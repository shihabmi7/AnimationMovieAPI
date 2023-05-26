using System.ComponentModel.DataAnnotations;

namespace AnimationMovieAPI.Models
{
    public class AspNetUser
    {
        [Key]
        public string Id { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string? TermsNCondition { get; set; }
        public string Discriminator { get; set; }
        public string? Address { get; set; }
        public string? ProfilePic { get; set; }
        public string? DeviceId { get; set; }
        public string? FullName { get; set; }
        public bool? IsEnablePin { get; set; }
        public bool? IsFaceId { get; set; }
        public string? Pincode { get; set; }
    }

}
