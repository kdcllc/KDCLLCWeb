"use strict";
var gulp = require('gulp');
var yargs_1 = require('./tools/utils/yargs');
var tasks_1 = require('./tools/utils/tasks');
gulp.task('default', function (done) {
    var args = yargs_1.argv.argv;
    console.log('Environment is set to:', args.env);
    console.log(args.save + ' library + ' + args.library);
});
gulp.task('check.versions', tasks_1.task('check.versions'));
gulp.task('install', tasks_1.task('install.packages'));
gulp.task('docs', tasks_1.task('build.docs'));
//# sourceMappingURL=gulpfile.js.map