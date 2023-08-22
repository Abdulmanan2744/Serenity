import { StringEditor, ImageUploadEditor, MultipleImageUploadEditor, DateEditor, EnumEditor, IntegerEditor, PrefixedContext } from "@serenity-is/corelib";
import { Gender } from "./Gender";
import { PersonMovieGrid } from "@/MovieDB/Person/PersonMovieGrid";
import { initFormType } from "@serenity-is/corelib/q";

export interface PersonForm {
    FirstName: StringEditor;
    Lastname: StringEditor;
    PrimaryImage: ImageUploadEditor;
    GalleryImages: MultipleImageUploadEditor;
    BirthDate: DateEditor;
    BirthPlace: StringEditor;
    Gender: EnumEditor;
    Height: IntegerEditor;
    MoviesGrid: PersonMovieGrid;
}

export class PersonForm extends PrefixedContext {
    static formKey = 'MovieDB.Person';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!PersonForm.init)  {
            PersonForm.init = true;

            var w0 = StringEditor;
            var w1 = ImageUploadEditor;
            var w2 = MultipleImageUploadEditor;
            var w3 = DateEditor;
            var w4 = EnumEditor;
            var w5 = IntegerEditor;
            var w6 = PersonMovieGrid;

            initFormType(PersonForm, [
                'FirstName', w0,
                'Lastname', w0,
                'PrimaryImage', w1,
                'GalleryImages', w2,
                'BirthDate', w3,
                'BirthPlace', w0,
                'Gender', w4,
                'Height', w5,
                'MoviesGrid', w6
            ]);
        }
    }
}

[Gender]; // referenced types