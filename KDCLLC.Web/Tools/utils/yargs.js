"use strict";
var chalk = require("chalk");
var yargs = require('yargs');
exports.argv = yargs
    .usage('$0 <command> [options] \n$0 help <command>')
    .alias('b', 'build')
    .command('build', chalk.yellow('S') + 'build', function (yargs) {
    exports.argv = addGlobals(yargs)
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
function addGlobals(argv) {
    argv
        .alias('v', 'version')
        .version(function () { return require('../package').version; })
        .describe('v', 'show version information')
        .count('verbose').alias('v', 'verbose').describe('v', 'Set log verbosity level (-v = info, -vv = warnings, -vvv = debug )')
        .alias('h', 'help')
        .help('help')
        .usage('Usage: $0 -x [num]')
        .showHelpOnFail(false, "Specify --help for available options");
    return argv;
}
//# sourceMappingURL=yargs.js.map