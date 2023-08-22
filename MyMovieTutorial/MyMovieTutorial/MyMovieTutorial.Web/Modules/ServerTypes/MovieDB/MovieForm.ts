import { StringEditor, TextAreaEditor, ImageUploadEditor, MultipleImageUploadEditor, IntegerEditor, DateEditor, LookupEditor, EnumEditor, PrefixedContext } from "@serenity-is/corelib";
import { MovieCastEditor } from "@/MovieDB/MovieCast/MovieCastEditor";
import { MovieKind } from "./MovieKind";
import { initFormType } from "@serenity-is/corelib/q";

export interface MovieForm {
    Title: StringEditor;
    Description: TextAreaEditor;
    CastList: MovieCastEditor;
    PrimaryImage: ImageUploadEditor;
    GalleryImages: MultipleImageUploadEditor;
    Storyline: TextAreaEditor;
    Year: IntegerEditor;
    ReleaseDate: DateEditor;
    GenreList: LookupEditor;
    Runtime: IntegerEditor;
    Kind: EnumEditor;
}

export class MovieForm extends PrefixedContext {
    static formKey = 'MovieDB.Movie';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!MovieForm.init)  {
            MovieForm.init = true;

            var w0 = StringEditor;
            var w1 = TextAreaEditor;
            var w2 = MovieCastEditor;
            var w3 = ImageUploadEditor;
            var w4 = MultipleImageUploadEditor;
            var w5 = IntegerEditor;
            var w6 = DateEditor;
            var w7 = LookupEditor;
            var w8 = EnumEditor;

            initFormType(MovieForm, [
                'Title', w0,
                'Description', w1,
                'CastList', w2,
                'PrimaryImage', w3,
                'GalleryImages', w4,
                'Storyline', w1,
                'Year', w5,
                'ReleaseDate', w6,
                'GenreList', w7,
                'Runtime', w5,
                'Kind', w8
            ]);
        }
    }
}

[MovieKind]; // referenced types