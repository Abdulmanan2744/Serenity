import { IntegerEditor, PrefixedContext } from "@serenity-is/corelib";
import { initFormType } from "@serenity-is/corelib/q";

export interface MovieGenresForm {
    MovieId: IntegerEditor;
    GenreId: IntegerEditor;
}

export class MovieGenresForm extends PrefixedContext {
    static formKey = 'MovieDB.MovieGenres';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!MovieGenresForm.init)  {
            MovieGenresForm.init = true;

            var w0 = IntegerEditor;

            initFormType(MovieGenresForm, [
                'MovieId', w0,
                'GenreId', w0
            ]);
        }
    }
}