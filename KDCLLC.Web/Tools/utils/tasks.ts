import * as gulp from 'gulp';
import * as util from 'gulp-util';
import * as chalk from 'chalk';
import * as gulpLoadPlugins from 'gulp-load-plugins';
import * as _runSequence from 'run-sequence';
import {existsSync} from 'fs';
import {join} from 'path';
import {TOOLS_DIR} from '../config';
import * as wrench from 'wrench';

const TASKS_PATH = join(TOOLS_DIR, 'tasks');


export function task(taskname: string, option?: string) {
    util.log('Loading task', chalk.yellow(taskname, option || ''));
    return require(join('..', 'tasks', taskname))(gulp, gulpLoadPlugins(), option);
}

export function runSequence(...sequence: any[]) {
    let tasks = [];
    let _sequence = sequence.slice(0);
    sequence.pop();

    scanDir(TASKS_PATH, taskname => tasks.push(taskname));

    sequence.forEach(task => {
        if (tasks.indexOf(task) > -1) { registerTask(task); }
    });

    return _runSequence(..._sequence);
}

// ----------
// Private.

function registerTask(taskname: string, filename?: string, option: string = ''): void {
    gulp.task(taskname, task(filename || taskname, option));
}

function scanDir(root: string, cb: (taskname: string) => void) {

    if (!existsSync(root)) {
        return;
    }

    wrench.readdirSyncRecursive(TASKS_PATH).filter(function(file) {
        return (/\.(ts|)$/i).test(file);
    }).map(function(file) {
        let taskname = file.replace(/(\.ts)/, '');
        cb(taskname);
    });

}
