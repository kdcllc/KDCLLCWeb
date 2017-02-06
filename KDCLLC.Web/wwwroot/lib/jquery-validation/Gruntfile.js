/*jshint node:true*/
<<<<<<< HEAD
module.exports = function(grunt) {
=======
module.exports = function( grunt ) {
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f

"use strict";

var banner,
	umdStart,
	umdMiddle,
	umdEnd,
	umdStandardDefine,
	umdAdditionalDefine,
	umdLocalizationDefine;

banner = "/*!\n" +
	" * jQuery Validation Plugin v<%= pkg.version %>\n" +
	" *\n" +
	" * <%= pkg.homepage %>\n" +
	" *\n" +
	" * Copyright (c) <%= grunt.template.today('yyyy') %> <%= pkg.author.name %>\n" +
<<<<<<< HEAD
	" * Released under the <%= _.pluck(pkg.licenses, 'type').join(', ') %> license\n" +
	" */\n";

// define UMD wrapper variables
=======
	" * Released under the <%= _.map(pkg.licenses, 'type').join(', ') %> license\n" +
	" */\n";

// Define UMD wrapper variables
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f

umdStart = "(function( factory ) {\n" +
	"\tif ( typeof define === \"function\" && define.amd ) {\n";

<<<<<<< HEAD
umdMiddle = "\t} else {\n" +
=======
umdMiddle = "\t} else if (typeof module === \"object\" && module.exports) {\n" +
	"\t\tmodule.exports = factory( require( \"jquery\" ) );\n" +
	"\t} else {\n" +
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
	"\t\tfactory( jQuery );\n" +
	"\t}\n" +
	"}(function( $ ) {\n\n";

<<<<<<< HEAD
umdEnd = "\n}));";
=======
umdEnd = "return $;" +
	"\n}));";
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f

umdStandardDefine = "\t\tdefine( [\"jquery\"], factory );\n";
umdAdditionalDefine = "\t\tdefine( [\"jquery\", \"./jquery.validate\"], factory );\n";
umdLocalizationDefine = "\t\tdefine( [\"jquery\", \"../jquery.validate\"], factory );\n";

<<<<<<< HEAD
grunt.initConfig({
	pkg: grunt.file.readJSON("package.json"),
	concat: {
		// used to copy to dist folder
=======
grunt.initConfig( {
	pkg: grunt.file.readJSON( "package.json" ),
	concat: {

		// Used to copy to dist folder
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
		dist: {
			options: {
				banner: banner +
					umdStart +
					umdStandardDefine +
					umdMiddle,
				footer: umdEnd
			},
			files: {
				"dist/jquery.validate.js": [ "src/core.js", "src/*.js" ]
			}
		},
		extra: {
			options: {
				banner: banner +
					umdStart +
					umdAdditionalDefine +
					umdMiddle,
				footer: umdEnd
			},
			files: {
				"dist/additional-methods.js": [ "src/additional/additional.js", "src/additional/*.js" ]
			}
		}
	},
	uglify: {
		options: {
			preserveComments: false,
			banner: "/*! <%= pkg.title || pkg.name %> - v<%= pkg.version %> - " +
				"<%= grunt.template.today('m/d/yyyy') %>\n" +
				" * <%= pkg.homepage %>\n" +
				" * Copyright (c) <%= grunt.template.today('yyyy') %> <%= pkg.author.name %>;" +
<<<<<<< HEAD
				" Licensed <%= _.pluck(pkg.licenses, 'type').join(', ') %> */\n"
=======
				" Licensed <%= _.map(pkg.licenses, 'type').join(', ') %> */\n"
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
		},
		dist: {
			files: {
				"dist/additional-methods.min.js": "dist/additional-methods.js",
				"dist/jquery.validate.min.js": "dist/jquery.validate.js"
			}
		},
		all: {
			expand: true,
			cwd: "dist/localization",
			src: "**/*.js",
			dest: "dist/localization",
			ext: ".min.js"
		}
	},
	compress: {
		dist: {
			options: {
				mode: "zip",
				level: 1,
				archive: "dist/<%= pkg.name %>-<%= pkg.version %>.zip",
				pretty: true
			},
			src: [
				"changelog.txt",
				"demo/**/*.*",
				"dist/**/*.js",
				"Gruntfile.js",
				"lib/**/*.*",
				"package.json",
				"README.md",
				"src/**/*.*",
				"test/**/*.*"
			]
		}
	},
	qunit: {
		files: "test/index.html"
	},
	jshint: {
		options: {
			jshintrc: true
		},
		core: {
			src: "src/**/*.js"
		},
		test: {
<<<<<<< HEAD
			src: "test/*.js"
=======
			src: [ "test/*.js", "test/additional/*.js" ]
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
		},
		grunt: {
			src: "Gruntfile.js"
		}
	},
	watch: {
		options: {
			atBegin: true
		},
		src: {
			files: "<%= jshint.core.src %>",
			tasks: [
				"concat"
			]
		}
	},
	jscs: {
		all: [ "<%= jshint.core.src %>", "<%= jshint.test.src %>", "<%= jshint.grunt.src %>" ]
	},
	copy: {
		dist: {
			options: {
<<<<<<< HEAD
				// append UMD wrapper
=======

				// Append UMD wrapper
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
				process: function( content ) {
					return umdStart + umdLocalizationDefine + umdMiddle + content + umdEnd;
				}
			},
			src: "src/localization/*",
			dest: "dist/localization",
			expand: true,
			flatten: true,
			filter: "isFile"
		}
	},
	replace: {
		dist: {
			src: "dist/**/*.min.js",
			overwrite: true,
			replacements: [
				{
					from: "./jquery.validate",
					to: "./jquery.validate.min"
				}
			]
		}
	}
<<<<<<< HEAD
});

grunt.loadNpmTasks("grunt-contrib-jshint");
grunt.loadNpmTasks("grunt-contrib-qunit");
grunt.loadNpmTasks("grunt-contrib-uglify");
grunt.loadNpmTasks("grunt-contrib-concat");
grunt.loadNpmTasks("grunt-contrib-compress");
grunt.loadNpmTasks("grunt-contrib-watch");
grunt.loadNpmTasks("grunt-jscs");
grunt.loadNpmTasks("grunt-contrib-copy");
grunt.loadNpmTasks("grunt-text-replace");

grunt.registerTask("default", [ "concat", "copy", "jscs", "jshint", "qunit" ]);
grunt.registerTask("release", [ "default", "uglify", "replace", "compress" ]);
grunt.registerTask("start", [ "concat", "watch" ]);
=======
} );

grunt.loadNpmTasks( "grunt-contrib-jshint" );
grunt.loadNpmTasks( "grunt-contrib-qunit" );
grunt.loadNpmTasks( "grunt-contrib-uglify" );
grunt.loadNpmTasks( "grunt-contrib-concat" );
grunt.loadNpmTasks( "grunt-contrib-compress" );
grunt.loadNpmTasks( "grunt-contrib-watch" );
grunt.loadNpmTasks( "grunt-jscs" );
grunt.loadNpmTasks( "grunt-contrib-copy" );
grunt.loadNpmTasks( "grunt-text-replace" );

grunt.registerTask( "default", [ "concat", "copy", "jscs", "jshint", "qunit" ] );
grunt.registerTask( "release", [ "default", "uglify", "replace", "compress" ] );
grunt.registerTask( "start", [ "concat", "watch" ] );
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f

};
