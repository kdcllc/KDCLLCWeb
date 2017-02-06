"use strict";
var path_1 = require('path');
var config_1 = require('../config');
module.exports = function buildDocs(gulp, plugins, options) {
    return function () {
        var src = [
            path_1.join(config_1.APP_SRC, '**/*.ts'),
            '!' + path_1.join(config_1.APP_SRC, '**/*.spec.ts')
        ];
        return gulp.src(src)
            .pipe(plugins.typedoc({
            module: 'commonjs',
            target: 'es5',
            includeDeclarations: false,
            out: config_1.DOCS_DEST,
            json: path_1.join(config_1.DOCS_DEST, 'data/docs.json'),
            name: config_1.APP_TITLE,
            ignoreCompilerErrors: true,
            experimentalDecorators: true,
            version: true
        }));
    };
};
//# sourceMappingURL=build.docs.js.map