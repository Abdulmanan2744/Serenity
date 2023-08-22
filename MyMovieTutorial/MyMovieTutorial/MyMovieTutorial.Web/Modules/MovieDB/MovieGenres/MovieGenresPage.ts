import { initFullHeightGridPage } from '@serenity-is/corelib/q';
import { MovieGenresGrid } from './MovieGenresGrid';

export default function pageInit() {
    initFullHeightGridPage(new MovieGenresGrid($('#GridDiv')).element);
}