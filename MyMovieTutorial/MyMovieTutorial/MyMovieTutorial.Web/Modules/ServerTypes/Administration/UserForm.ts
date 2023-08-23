import { StringEditor, EmailEditor, PasswordEditor, LookupEditor, PrefixedContext } from "@serenity-is/corelib";
import { initFormType } from "@serenity-is/corelib/q";

export interface UserForm {
    Username: StringEditor;
    DisplayName: StringEditor;
    Email: EmailEditor;
    Password: PasswordEditor;
    PasswordConfirm: PasswordEditor;
    Source: StringEditor;
    TenantId: LookupEditor;
}

export class UserForm extends PrefixedContext {
    static formKey = 'Administration.User';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!UserForm.init)  {
            UserForm.init = true;

            var w0 = StringEditor;
            var w1 = EmailEditor;
            var w2 = PasswordEditor;
            var w3 = LookupEditor;

            initFormType(UserForm, [
                'Username', w0,
                'DisplayName', w0,
                'Email', w1,
                'Password', w2,
                'PasswordConfirm', w2,
                'Source', w0,
                'TenantId', w3
            ]);
        }
    }
}