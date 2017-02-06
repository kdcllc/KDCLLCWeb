"use strict";
var config_1 = require('../config');
var util = require('gulp-util');
var chalk = require("chalk");
var child_process_1 = require('child_process');
var semver = require('semver');
var async = require('async');
function reportError(message) {
    console.error(chalk.white.bgRed.bold(message));
    process.exit(1);
}
module.exports = function check(gulp, plugins, options) {
    return function (done) {
        async.series([
            execFn('npm --version', __dirname, config_1.VERSION_NPM),
            execFn('node --version', __dirname, config_1.VERSION_NODE)
        ], done);
    };
};
function execFn(cmd, dir, version) {
    return function (cb) {
        child_process_1.exec(cmd, {
            cwd: dir
        }, function (error, stdout, stderr) {
            if (error !== null) {
                reportError(cmd + ' preinstall error: ' + error + stderr);
            }
            if (!semver.gte(stdout.toString(), version)) {
                reportError(cmd + ' is not in required version! Required is ' + version + ' and you\'re using ' + stdout);
            }
            else {
                util.log('Current version:' + cmd, chalk.white.bgBlack.bold(stdout.toString()));
            }
            cb();
        });
    };
}
//# sourceMappingURL=check.versions.js.map