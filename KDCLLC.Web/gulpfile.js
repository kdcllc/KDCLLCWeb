/// 
// include plug-ins
var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');
var path = require('path');
var minifyCSS = require('gulp-minify-css');
var copy = require('gulp-copy');
var bower = require('gulp-bower');
var sourcemaps = require('gulp-sourcemaps');
var less = require('gulp-less');

var plumber = require('gulp-plumber');

var useref = require('gulp-useref');
var gulpif = require('gulp-if');
var rev = require('gulp-rev');
var revReplace = require('gulp-rev-replace');

var paths = {
        webroot: './wwwroot/'
};

paths.boostrapless = paths.webroot + 'css/bootstrap.less'
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/site.min.js";
paths.concatCssDest = paths.webroot + "css/site.min.css";

gulp.task('bootstrapless', function () {
    return gulp.src(paths.boostrapless) 
    .pipe(plumber())
      .pipe(less({
          paths: [path.join(__dirname, 'less', 'includes')]
      }))
      .pipe(gulp.dest(paths.webroot + 'css/'));
});


// Concat & Minify JS
gulp.task('build_assets', function() {
  var assets = useref.assets({
      searchPath: '.'
      });
    gulp.src('Views/**/*.cshtml', {
          base: './' 
      })
      .pipe(assets)
      .pipe(gulpif('*.css', minifyCSS()))
      .pipe(gulpif('*.js', uglify()))
      .pipe(rev())
      .pipe(assets.restore())
      .pipe(useref())
    .pipe(revReplace({
    replaceInExtensions: ['.cshtml']
    }))
    .pipe(gulp.dest('./obj/Release/Package/PackageTmp'));
    });



//Restore all bower packages
gulp.task('bower-restore', function () {
    return bower();
});



// Default
gulp.task('default', ['bower-restore','build_assets']);