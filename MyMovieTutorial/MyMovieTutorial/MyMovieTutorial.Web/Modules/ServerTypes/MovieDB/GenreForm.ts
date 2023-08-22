import { StringEditor, PrefixedContext } from "@serenity-is/corelib";
import { initFormType } from "@serenity-is/corelib/q";

export interface GenreForm {
    Name: StringEditor;
}

export class GenreForm extends PrefixedContext {
    static formKey = 'MovieDB.Genre';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!GenreForm.init)  {
            GenreForm.init = true;

            var w0 = StringEditor;

            initFormType(GenreForm, [
                'Name', w0
            ]);
        }
    }
}