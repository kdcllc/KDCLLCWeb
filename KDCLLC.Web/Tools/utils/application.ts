
import {argv} from 'yargs';
import * as fs from 'fs';

export const ENVIRONMENTS = {
    DEVELOPMENT: 'dev',
    PRODUCTION: 'prod'
};

/*
    retreive enviroment variable that is passed into the system
*/
export function getEnvironment(): string {
    if (argv.env != null) {
    
        if (argv.env === ENVIRONMENTS.PRODUCTION) {
            return ENVIRONMENTS.PRODUCTION;
        } else {
            //ability to extend more enviroments from here
            return ENVIRONMENTS.DEVELOPMENT;
        }
    } else {
        return ENVIRONMENTS.DEVELOPMENT;
    }
}

export function getApplicationTitle(): string {
    return JSON.parse(fs.readFileSync("package.json", "utf8")).description;
}