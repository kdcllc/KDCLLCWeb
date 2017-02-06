import {VERSION_NPM, VERSION_NODE} from '../config';
import * as util from 'gulp-util';
import * as chalk from "chalk";
import {exec} from 'child_process';
import * as semver from 'semver';
import * as async from 'async';

function reportError(message: string) {
    console.error(chalk.white.bgRed.bold(message));
    process.exit(1);
}

module.exports = function check(gulp, plugins, options) {
    return function(done) {
        async.series([
            execFn('npm --version', __dirname, VERSION_NPM)
            , execFn('node --version', __dirname, VERSION_NODE)

        ], done);
    };

};

function execFn(cmd, dir, version) {
    return function(cb) {

        exec(cmd, {
            cwd: dir
        }, function(error, stdout, stderr) {

            if (error !== null) {
                reportError(cmd + ' preinstall error: ' + error + stderr);
            }

            if (!semver.gte(stdout.toString(), version)) {
                reportError(cmd + ' is not in required version! Required is ' + version + ' and you\'re using ' + stdout);
            } else {
                // + stderr.toString()
                util.log('Current version:' + cmd, chalk.white.bgBlack.bold(stdout.toString()));
            }
            cb();
        });
    };
}
