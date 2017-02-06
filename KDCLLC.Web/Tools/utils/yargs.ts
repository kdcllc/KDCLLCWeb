import * as chalk from "chalk";
import * as yargs from 'yargs';

import {ENVIRONMENTS} from './application';

export var argv = yargs
    .usage('$0 <command> [options] \n$0 help <command>')
    .alias('b', 'build')
    .command('build', chalk.yellow('S') + 'build',
    function(yargs: yargs.Argv) {
        argv = addGlobals(yargs)
            .option("library", {
                alias: "l",
                description: "libary provided"
            })
            .argv;

    })
    .option("env", {
        alias: "e",
        default: 'dev',
        description: "set build enviroment"
    })
    .option("save", {
        alias: "s",
        default: '--save-dev',
        description: "save-dev dependecies"
    })
    .option("library", {
        alias: "l",
        description: "libary provided"
    });
    
function addGlobals(argv: yargs.Argv) {
    argv
        // version
        .alias('v', 'version')
        .version(function() { return require('../package').version; })
        .describe('v', 'show version information')
        
        // OPTIONS
        .count('verbose').alias('v', 'verbose').describe('v', 'Set log verbosity level (-v = info, -vv = warnings, -vvv = debug )')
        // help text
        .alias('h', 'help')
        .help('help')
        .usage('Usage: $0 -x [num]')
        .showHelpOnFail(false, "Specify --help for available options");
    return argv;
    
}

export interface ICommandLineArgs {

    save: string;
    library: string;
    debug?: boolean;
    debugBrk?: boolean;
    nosync?: boolean;
    verbose?: boolean;
    /* tslint:disable */
    env: "dev" | "prod" | "qa";
    /* tslint:enable */ 
}
