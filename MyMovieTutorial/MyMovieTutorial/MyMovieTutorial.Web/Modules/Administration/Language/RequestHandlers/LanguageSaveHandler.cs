﻿using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<MyMovieTutorial.Administration.LanguageRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = MyMovieTutorial.Administration.LanguageRow;


namespace MyMovieTutorial.Administration
{
    public interface ILanguageSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }
    public class LanguageSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, ILanguageSaveHandler
    {
        public LanguageSaveHandler(IRequestContext context)
             : base(context)
        {
        }
    }
}