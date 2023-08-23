import { StringEditor, PrefixedContext } from "@serenity-is/corelib";
import { initFormType } from "@serenity-is/corelib/q";

export interface TenantsForm {
    TenantName: StringEditor;
}

export class TenantsForm extends PrefixedContext {
    static formKey = 'Administration.Tenants';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!TenantsForm.init)  {
            TenantsForm.init = true;

            var w0 = StringEditor;

            initFormType(TenantsForm, [
                'TenantName', w0
            ]);
        }
    }
}