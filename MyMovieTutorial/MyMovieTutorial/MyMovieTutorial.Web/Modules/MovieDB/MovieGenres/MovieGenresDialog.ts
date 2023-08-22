import { Decorators, EntityDialog } from '@serenity-is/corelib';
import { MovieGenresForm, MovieGenresRow, MovieGenresService } from '../../ServerTypes/MovieDB';

@Decorators.registerClass('MyMovieTutorial.MovieDB.MovieGenresDialog')
export class MovieGenresDialog extends EntityDialog<MovieGenresRow, any> {
    protected getFormKey() { return MovieGenresForm.formKey; }
    protected getRowDefinition() { return MovieGenresRow; }
    protected getService() { return MovieGenresService.baseUrl; }

    protected form = new MovieGenresForm(this.idPrefix);
}