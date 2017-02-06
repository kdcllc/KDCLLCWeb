import * as util from 'gulp-util';
import * as chalk from "chalk";
import {exec} from 'child_process';
import {argv, ICommandLineArgs} from '../../tools/utils/yargs';

function reportError(message: string) {
    console.error(chalk.white.bgRed.bold(message));
    process.exit(1);
}

//TODO: add tsd global flag when needed to be
//depreciated due to usgage of Typings
module.exports = function installPackages(gulp, plugins, options) {
    return function(done) {
        let async = require('async');

        let command: string = '--save-dev';

        let args: ICommandLineArgs = argv.argv;
        let lib = args.library;

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
            execFn('npm i ' + command + ' ' + lib, __dirname)
            , execFn('tsd query -r -o -a install ' + lib + ' --save', '')
           // , execFn('typings install ' + lib + ' -A  --save', '')
        ], done);
    };

};

function execFn(cmd, dir) {
    return function(cb) {
        util.log(dir);
        exec(cmd, {
            cwd: dir
        }, function(error, stdout, stderr) {
            if (error !== null) {
                reportError(cmd + '  error: ' + error + stderr);
            }
            util.log('Running:' + cmd, chalk.yellow.bgBlack.bold(stdout.toString()));
            cb();
        });
    };
}
