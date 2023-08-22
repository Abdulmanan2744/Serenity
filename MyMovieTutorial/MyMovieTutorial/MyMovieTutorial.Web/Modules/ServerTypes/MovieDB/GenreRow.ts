import { getLookup, getLookupAsync, fieldsProxy } from "@serenity-is/corelib/q";

export interface GenreRow {
    GenreId?: number;
    Name?: string;
}

export abstract class GenreRow {
    static readonly idProperty = 'GenreId';
    static readonly nameProperty = 'Name';
    static readonly localTextPrefix = 'MovieDB.Genre';
    static readonly lookupKey = 'MovieDB.Genre';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<GenreRow>('MovieDB.Genre') }
    static async getLookupAsync() { return getLookupAsync<GenreRow>('MovieDB.Genre') }

    static readonly deletePermission = 'Administration:General';
    static readonly insertPermission = 'Administration:General';
    static readonly readPermission = 'Administration:General';
    static readonly updatePermission = 'Administration:General';

    static readonly Fields = fieldsProxy<GenreRow>();
}