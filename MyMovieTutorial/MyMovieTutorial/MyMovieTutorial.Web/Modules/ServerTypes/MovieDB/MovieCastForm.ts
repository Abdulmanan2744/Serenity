import { LookupEditor, StringEditor, PrefixedContext } from "@serenity-is/corelib";
import { initFormType } from "@serenity-is/corelib/q";

export interface MovieCastForm {
    PersonId: LookupEditor;
    Character: StringEditor;
}

export class MovieCastForm extends PrefixedContext {
    static formKey = 'MovieDB.MovieCast';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!MovieCastForm.init)  {
            MovieCastForm.init = true;

            var w0 = LookupEditor;
            var w1 = StringEditor;

            initFormType(MovieCastForm, [
                'PersonId', w0,
                'Character', w1
            ]);
        }
    }
}