define("gulpfile", ["require", "exports", 'gulp', './tools/utils/yargs', './tools/utils/tasks'], function (require, exports, gulp, yargs_1, tasks_1) {
    "use strict";
    gulp.task('default', function (done) {
        var args = yargs_1.argv.argv;
        console.log('Enviroment is set to:', args.env);
        console.log(args.save + ' library + ' + args.library);
    });
    gulp.task('check.versions', tasks_1.task('check.versions'));
    gulp.task('install', tasks_1.task('install.packages'));
    gulp.task('docs', tasks_1.task('build.docs'));
});
define("Tools/utils/application", ["require", "exports", "Tools/utils/yargs", 'fs'], function (require, exports, yargs_2, fs) {
    "use strict";
    exports.ENVIRONMENTS = {
        DEVELOPMENT: 'dev',
        PRODUCTION: 'prod'
    };
    /*
        retreive enviroment variable that is passed into the system
    */
    function getEnvironment() {
        if (yargs_2.argv.env != null) {
            if (yargs_2.argv.env === exports.ENVIRONMENTS.PRODUCTION) {
                return exports.ENVIRONMENTS.PRODUCTION;
            }
            else {
                //ability to extend more enviroments from here
                return exports.ENVIRONMENTS.DEVELOPMENT;
            }
        }
        else {
            return exports.ENVIRONMENTS.DEVELOPMENT;
        }
    }
    exports.getEnvironment = getEnvironment;
    function getApplicationTitle() {
        return JSON.parse(fs.readFileSync("package.json", "utf8")).description;
    }
    exports.getApplicationTitle = getApplicationTitle;
});
define("Tools/utils/yargs", ["require", "exports", "chalk", "Tools/utils/yargs"], function (require, exports, chalk, yargs) {
    "use strict";
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
});
define("Tools/config", ["require", "exports", "Tools/utils/application"], function (require, exports, application_1) {
    "use strict";
    exports.ENV = application_1.getEnvironment();
    exports.TOOLS_DIR = 'tools';
    //used by check.versions task
    exports.VERSION_NPM = '2.14.2';
    exports.VERSION_NODE = '4.0.0';
    exports.APP_TITLE = application_1.getApplicationTitle();
    exports.APP_SRC = 'app';
    exports.DOCS_DEST = 'docs';
});
//# sourceMappingURL=app.js.map