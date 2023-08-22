import { initFullHeightGridPage } from '@serenity-is/corelib/q';
import { MovieGrid } from './MovieGrid';

export default function pageInit() {
    initFullHeightGridPage(new MovieGrid($('#GridDiv')).element);
}