import * as gulp from 'gulp';
import { ENV } from './tools/config';
import { argv, ICommandLineArgs } from './tools/utils/yargs';
import { runSequence, task } from './tools/utils/tasks';

gulp.task('default', done => {
    let args: ICommandLineArgs = argv.argv;
    console.log('Environment is set to:', args.env);
    console.log(args.save + ' library + ' + args.library);
});

gulp.task('check.versions', task('check.versions'));

gulp.task('install', task('install.packages'));

gulp.task('docs', task('build.docs'));