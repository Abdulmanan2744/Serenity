import { Decorators } from "@serenity-is/corelib";
import { GridEditorBase } from "@serenity-is/extensions";
import { MovieCastRow, PersonRow } from "../../ServerTypes/MovieDB";
import { MovieCastEditDialog } from "./MovieCastEditDialog";

@Decorators.registerEditor("MyMovieTutorial.MovieDB.MovieCastEditor")
export class MovieCastEditor extends GridEditorBase<MovieCastRow> {
    protected getColumnsKey() { return "MovieDB.MovieCast"; }
    protected getDialogType() { return MovieCastEditDialog; }
    protected getLocalTextPrefix() { return MovieCastRow.localTextPrefix; }

    constructor(container: JQuery) {
        super(container);
    }

    protected getAddButtonCaption() {
        return "Add";
    }

    protected validateEntity(row: MovieCastRow, id: number) {
        if (!super.validateEntity(row, id))
            return false;

        row.PersonFullname = PersonRow.getLookup()
            .itemById[row.PersonId].FullName;

        return true;
    }
}