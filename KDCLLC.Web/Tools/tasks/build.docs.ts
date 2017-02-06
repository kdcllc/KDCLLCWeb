import {join} from 'path';
import {APP_TITLE,
        APP_SRC,
        DOCS_DEST} from '../config'

export = function buildDocs(gulp,plugins,options) {
 return function() {

    let src = [
                join(APP_SRC, '**/*.ts'),
                '!' + join(APP_SRC, '**/*.spec.ts')
              ];

    return gulp.src(src)
      .pipe(plugins.typedoc({
        // TypeScript options (see typescript docs)
        module: 'commonjs',
        target: 'es5',
        includeDeclarations: false,
        // Output options (see typedoc docs)
        out: DOCS_DEST,
        json: join(DOCS_DEST , 'data/docs.json' ),
        name: APP_TITLE,
        ignoreCompilerErrors: true,
        experimentalDecorators: true,
        version: true
      }));
    };   
}