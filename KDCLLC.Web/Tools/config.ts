import {getEnvironment, 
        getApplicationTitle} from './utils/application';

export const ENV                    = getEnvironment() ;

export const TOOLS_DIR              = 'tools';

//used by check.versions task
export const VERSION_NPM          = '2.14.2';
export const VERSION_NODE         = '4.0.0';

export const APP_TITLE          = getApplicationTitle();
export const APP_SRC            = 'app';

export const DOCS_DEST          = 'docs';