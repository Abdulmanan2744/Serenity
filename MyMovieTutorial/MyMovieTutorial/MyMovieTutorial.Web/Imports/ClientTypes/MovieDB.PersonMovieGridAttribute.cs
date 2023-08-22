using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyMovieTutorial.MovieDB;

public partial class PersonMovieGridAttribute : CustomEditorAttribute
{
    public const string Key = "MyMovieTutorial.MovieDB.PersonMovieGrid";

    public PersonMovieGridAttribute()
        : base(Key)
    {
    }
}