import { Decorators, Formatter } from "@serenity-is/corelib";
import { htmlEncode } from "@serenity-is/corelib/q";
import { FormatterContext } from "@serenity-is/sleekgrid";
import { GenreRow } from "../../ServerTypes/MovieDB";

@Decorators.registerFormatter("MyMovieTutorial.MovieDB.GenreListFormatter")
export class GenreListFormatter implements Formatter {
    format(ctx: FormatterContext) {
        let idList = ctx.value as number[];
        if (!idList || !idList.length)
            return "";

        let byId = GenreRow.getLookup().itemById;

        return idList.map(x => {
            let g = byId[x];
            if (!g)
                return x.toString();

            return htmlEncode(g.Name);
        }).join(", ");
    }
}