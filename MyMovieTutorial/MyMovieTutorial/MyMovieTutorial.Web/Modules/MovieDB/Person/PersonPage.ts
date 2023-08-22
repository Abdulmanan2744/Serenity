import { initFullHeightGridPage } from '@serenity-is/corelib/q';
import { PersonGrid } from './PersonGrid';

export default function pageInit() {
    initFullHeightGridPage(new PersonGrid($('#GridDiv')).element);
}