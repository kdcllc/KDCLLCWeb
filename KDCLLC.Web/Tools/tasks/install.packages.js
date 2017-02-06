"use strict";
var util = require('gulp-util');
var chalk = require("chalk");
var child_process_1 = require('child_process');
var yargs_1 = require('../../tools/utils/yargs');
function reportError(message) {
    console.error(chalk.white.bgRed.bold(message));
    process.exit(1);
}
module.exports = function installPackages(gulp, plugins, options) {
    return function (done) {
        var async = require('async');
        var command = '--save-dev';
        var args = yargs_1.argv.argv;
        var lib = args.library;
        if (args.library === undefined) {
            reportError('Libary name is missing');
            return;
        }
        switch (args.save) {
            case 'g':
                command = '--g';
                break;
            case 'r':
                command = '--save';
                break;
            default:
                break;
        }
        async.series([
            execFn('npm i ' + command + ' ' + lib, __dirname),
            execFn('tsd query -r -o -a install ' + lib + ' --save', '')
        ], done);
    };
};
function execFn(cmd, dir) {
    return function (cb) {
        util.log(dir);
        child_process_1.exec(cmd, {
            cwd: dir
        }, function (error, stdout, stderr) {
            if (error !== null) {
                reportError(cmd + '  error: ' + error + stderr);
            }
            util.log('Running:' + cmd, chalk.yellow.bgBlack.bold(stdout.toString()));
            cb();
        });
    };
}
//# sourceMappingURL=install.packages.js.map