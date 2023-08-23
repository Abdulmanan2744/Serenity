import { initFullHeightGridPage } from '@serenity-is/corelib/q';
import { TenantsGrid } from './TenantsGrid';

export default function pageInit() {
    initFullHeightGridPage(new TenantsGrid($('#GridDiv')).element);
}