import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { TenantsForm, TenantsRow, TenantsService } from '../../ServerTypes/Administration';

@Decorators.registerClass('MyMovieTutorial.Administration.TenantsDialog')
export class TenantsDialog extends EntityDialog<TenantsRow, any> {
    protected getFormKey() { return TenantsForm.formKey; }
    protected getRowDefinition() { return TenantsRow; }
    protected getService() { return TenantsService.baseUrl; }

    protected form = new TenantsForm(this.idPrefix);
}