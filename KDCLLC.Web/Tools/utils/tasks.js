"use strict";
var gulp = require('gulp');
var util = require('gulp-util');
var chalk = require('chalk');
var gulpLoadPlugins = require('gulp-load-plugins');
var _runSequence = require('run-sequence');
var fs_1 = require('fs');
var path_1 = require('path');
var config_1 = require('../config');
var wrench = require('wrench');
var TASKS_PATH = path_1.join(config_1.TOOLS_DIR, 'tasks');
function task(taskname, option) {
    util.log('Loading task', chalk.yellow(taskname, option || ''));
    return require(path_1.join('..', 'tasks', taskname))(gulp, gulpLoadPlugins(), option);
}
exports.task = task;
function runSequence() {
    var sequence = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        sequence[_i - 0] = arguments[_i];
    }
    var tasks = [];
    var _sequence = sequence.slice(0);
    sequence.pop();
    scanDir(TASKS_PATH, function (taskname) { return tasks.push(taskname); });
    sequence.forEach(function (task) {
        if (tasks.indexOf(task) > -1) {
            registerTask(task);
        }
    });
    return _runSequence.apply(void 0, _sequence);
}
exports.runSequence = runSequence;
function registerTask(taskname, filename, option) {
    if (option === void 0) { option = ''; }
    gulp.task(taskname, task(filename || taskname, option));
}
function scanDir(root, cb) {
    if (!fs_1.existsSync(root)) {
        return;
    }
    wrench.readdirSyncRecursive(TASKS_PATH).filter(function (file) {
        return (/\.(ts|)$/i).test(file);
    }).map(function (file) {
        var taskname = file.replace(/(\.ts)/, '');
        cb(taskname);
    });
}
//# sourceMappingURL=tasks.js.map