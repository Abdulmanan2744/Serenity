using Serenity.ComponentModel;
using Serenity.Data;
using Serenity.Data.Mapping;
using System.ComponentModel;

namespace MyMovieTutorial.MovieDB;

[ConnectionKey("Default"), Module("MovieDB"), TableName("MovieCast")]
[DisplayName("Movie Cast"), InstanceName("Movie Cast")]
[ReadPermission("Administration:General")]
[ModifyPermission("Administration:General")]
public sealed class MovieCastRow : Row<MovieCastRow.RowFields>, IIdRow, INameRow
{
    const string jMovie = nameof(jMovie);
    const string jPerson = nameof(jPerson);

    [DisplayName("Movie Cast Id"), Identity, IdProperty]
    public int? MovieCastId
    {
        get => fields.MovieCastId[this];
        set => fields.MovieCastId[this] = value;
    }

    [DisplayName("Movie"), NotNull, ForeignKey("Movie", "MovieId"), LeftJoin(jMovie), TextualField(nameof(MovieTitle))]
    public int? MovieId
    {
        get => fields.MovieId[this];
        set => fields.MovieId[this] = value;
    }

    [DisplayName("Actor/Actress"), NotNull, ForeignKey("[dbo].[Person]", "PersonId")]
    [LeftJoin("jPerson"), TextualField("PersonFirstName")]
    [LookupEditor(typeof(PersonRow))]
    public int? PersonId
    {
        get => fields.PersonId[this];
        set => fields.PersonId[this] = value;
    }

    [DisplayName("Character"), Size(50), QuickSearch, NameProperty]
    public string Character
    {
        get => fields.Character[this];
        set => fields.Character[this] = value;
    }

    [DisplayName("Movie Title"), Expression($"{jMovie}.[Title]")]
    public string MovieTitle
    {
        get => fields.MovieTitle[this];
        set => fields.MovieTitle[this] = value;
    }

    [DisplayName("Person First Name"), Expression("jPerson.[FirstName]")]
    public string PersonFirstName
    {
        get => fields.PersonFirstName[this];
        set => fields.PersonFirstName[this] = value;
    }

    [DisplayName("Person Lastname"), Expression("jPerson.[Lastname]")]
    public string PersonLastname
    {
        get => fields.PersonLastname[this];
        set => fields.PersonLastname[this] = value;
    }

    [DisplayName("Actor/Actress"),
     Expression("(jPerson.Firstname + ' ' + jPerson.Lastname)")]
    public string PersonFullname
    {
        get => fields.PersonFullname[this];
        set => fields.PersonFullname[this] = value;
    }

    public class RowFields : RowFieldsBase
    {
        public Int32Field MovieCastId;
        public Int32Field MovieId;
        public Int32Field PersonId;
        public StringField Character;

        public StringField MovieTitle;
        public StringField PersonFirstName;
        public StringField PersonLastname;
        public StringField PersonFullname;
    }
}