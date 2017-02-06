// Compiled using typings@0.6.9
// Source: https://raw.githubusercontent.com/DefinitelyTyped/DefinitelyTyped/bd269cad4cb2b495f940c7b6afc5825d568029be/run-sequence/run-sequence.d.ts
// Type definitions for run-sequence
// Project: https://github.com/OverZealous/run-sequence
// Definitions by: Keita Kagurazaka <https://github.com/k-kagurazaka>
// Definitions: https://github.com/borisyankov/DefinitelyTyped


declare module "run-sequence" {
    import gulp = require('gulp');

    interface IRunSequence {
        (...streams: (string | string[] | gulp.TaskCallback)[]): NodeJS.ReadWriteStream;

        use(gulp: gulp.Gulp): IRunSequence;
    }

    var _tmp: IRunSequence;
    export = _tmp;
}