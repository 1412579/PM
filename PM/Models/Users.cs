using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public string Mobile { get; set; }
        public int? CountryId { get; set; }
        public string Country { get; set; }
        public string AvatarImage { get; set; }
        public string AvatarImageName { get; set; }
        public string OrgAvatarImage { get; set; }
        public string CoverImage { get; set; }
        public string CoverImageName { get; set; }
        public int? Level { get; set; }
        public int? UserType { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsLock { get; set; }
        public int? LoginFailNumber { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool? NewFollow { get; set; }
        public bool? NewComment { get; set; }
        public bool? NewMessage { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActived { get; set; }
        public bool? IsHot { get; set; }
        public bool? IsUpdateAvatar { get; set; }
        public int? Posts { get; set; }
        public int? Views { get; set; }
        public int? Followers { get; set; }
        public int? Following { get; set; }
        public int? PositionCover { get; set; }
        public string Description { get; set; }
        public decimal? InCome { get; set; }
        public decimal? AccountBalance { get; set; }
        public decimal? AccountPoint { get; set; }
        public string UserSafe { get; set; }
        public string IdentityNumber { get; set; }
        public string FrontSide { get; set; }
        public string RearSide { get; set; }
        public bool? IsVip { get; set; }
        public bool? IsVerify { get; set; }
        public int? PositionCoverMobile { get; set; }
        public int? UserIdRef { get; set; }
        public DateTime? VerifyDate { get; set; }
        public string Address { get; set; }
        public string BankName { get; set; }
        public string BankLocation { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNumber { get; set; }
        public DateTime? MessageDate { get; set; }
        public bool? IsOnline { get; set; }
        public bool? IsShowCountry { get; set; }
        public bool? IsShowDate { get; set; }
        public DateTime? PasswordChangedDate { get; set; }
        public DateTime? LastPasswordFailureDate { get; set; }
        public int? PasswordfailuresSinceLastSuccess { get; set; }
        public string PasswordVerificationToken { get; set; }
        public DateTime? PasswordVerificationTokenExpirationDate { get; set; }
    }
}
