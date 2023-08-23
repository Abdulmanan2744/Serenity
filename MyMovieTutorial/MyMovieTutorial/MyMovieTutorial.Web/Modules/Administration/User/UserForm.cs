using Serenity;
using System;
using System.ComponentModel;
using Serenity.ComponentModel;
using System.Collections.Generic;

namespace MyMovieTutorial.Administration.Forms
{
    [FormScript("Administration.User")]
    [BasedOnRow(typeof(UserRow), CheckNames = true)]
    public class UserForm
    {


        public string Username { get; set; }
        public string DisplayName { get; set; }
        [EmailEditor]
        public string Email { get; set; }
        [PasswordEditor]
        public string Password { get; set; }
        [PasswordEditor, OneWay]
        public string PasswordConfirm { get; set; }
        [OneWay]
        public string Source { get; set; }
        public int? TenantId { get; set; }



    }
}