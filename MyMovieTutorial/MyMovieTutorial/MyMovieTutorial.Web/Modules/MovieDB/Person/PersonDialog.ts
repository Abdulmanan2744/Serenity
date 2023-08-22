import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { PersonForm, PersonRow, PersonService } from '../../ServerTypes/MovieDB';

@Decorators.registerClass('MyMovieTutorial.MovieDB.PersonDialog')
    @Decorators.panel()
export class PersonDialog extends EntityDialog<PersonRow, any> {
    protected getFormKey() { return PersonForm.formKey; }
    protected getIdProperty() { return PersonRow.idProperty; }
    protected getLocalTextPrefix() { return PersonRow.localTextPrefix; }
    protected getNameProperty() { return PersonRow.nameProperty; }
    protected getService() { return PersonService.baseUrl; }
    protected getDeletePermission() { return PersonRow.deletePermission; }
    protected getInsertPermission() { return PersonRow.insertPermission; }
    protected getUpdatePermission() { return PersonRow.updatePermission; }

    protected form = new PersonForm(this.idPrefix);

    protected afterLoadEntity() {
        super.afterLoadEntity();

        this.form.MoviesGrid.personID = this.entityId;
    }
}