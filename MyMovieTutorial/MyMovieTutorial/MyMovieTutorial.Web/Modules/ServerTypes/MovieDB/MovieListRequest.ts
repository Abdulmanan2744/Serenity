import { ListRequest } from "@serenity-is/corelib/q";

export interface MovieListRequest extends ListRequest {
    Genres?: number[];
}