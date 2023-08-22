import { Decorators, EntityGrid } from "@serenity-is/corelib";
import { MovieCastRow, MovieCastService } from "../../ServerTypes/MovieDB";

@Decorators.registerEditor("MyMovieTutorial.MovieDB.PersonMovieGrid")
export class PersonMovieGrid extends EntityGrid<MovieCastRow, any>
{
    protected getColumnsKey() { return "MovieDB.PersonMovie"; }
    protected getIdProperty() { return MovieCastRow.idProperty; }
    protected getLocalTextPrefix() { return MovieCastRow.localTextPrefix; }
    protected getService() { return MovieCastService.baseUrl; }

    constructor(container: JQuery) {
        super(container);
    }
    protected getButtons() {
        return null;
    }

    protected getInitialTitle() {
        return null;
    }

    protected usePager() {
        return false;
    }

    protected getGridCanLoad() {
        return this.personID != null;
    }

    private _personID: number;

    get personID() {
        return this._personID;
    }

    set personID(value: number) {
        if (this._personID != value) {
            this._personID = value;
            this.setEquality(MovieCastRow.Fields.PersonId, value);
            this.refresh();
        }
    }
}