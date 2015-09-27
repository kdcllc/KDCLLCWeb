/// 
// include plug-ins
var gulp = require('gulp');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var del = require('del');
var minifyCSS = require('gulp-minify-css');
var copy = require('gulp-copy');
var bower = require('gulp-bower');
var sourcemaps = require('gulp-sourcemaps');

//-- running less files with gulp
var less = require('gulp-less');
var path = require('path');
var plumber = require('gulp-plumber');

var paths = {
    bower: "./bower_components/",
    css: "./Content",
};

var config = {
    //JavaScript files that will be combined into a jquery bundle
    jquerysrc: [
        './bower_components/jquery/dist/jquery.min.js',
        './bower_components/jquery-validation/dist/jquery.validate.min.js',
        './bower_components/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js'
    ],
    jquerybundle: './Scripts/jquery-bundle.min.js',

    //JavaScript files that will be combined into a Bootstrap bundle
    bootstrapsrc: [
        './bower_components/bootstrap/dist/js/bootstrap.min.js',
        './bower_components/respond-minmax/dest/respond.min.js'
    ],
    bootstrapbundle: './Scripts/bootstrap-bundle.min.js',

    //Modernizr
    modernizrsrc: ['./bower_components/modernizr/modernizr.js'],
    modernizrbundle: './Scripts/modernizer.min.js',

    //Bootstrap CSS and Fonts
    bootstrapcss: './bower_components/bootstrap/dist/css/bootstrap.css',
    boostrapfonts: './bower_components/bootstrap/dist/fonts/*.*',

    appcss: './Content/Site.css',
    fontsout: './Content/dist/fonts',
    cssout: './Content/dist/css'

}

// Synchronously delete the output script file(s)
gulp.task('clean-vendor-scripts', function (cb) {
    del([config.jquerybundle,
              config.bootstrapbundle,
              config.modernizrbundle], cb);
});

gulp.task("minifycss", function () {
    return gulp.src([paths.css + "/*.css",
                     "!" + paths.css + "/*.min.css"])
            .pipe(minifycss())
            .pipe(concat("site.min.css"))
            .pipe(gulp.dest(paths.css));
});

gulp.task('less', function () {
    // return gulp.src('./Content/**/*.less')
    return gulp.src('./Content/themes/default/bootstrap.less') 
    .pipe(plumber())
      .pipe(less({
          paths: [path.join(__dirname, 'less', 'includes')]
      }))
      .pipe(gulp.dest('./Content/themes/default'));
});


//Create a jquery bundled file
gulp.task('jquery-bundle', ['clean-vendor-scripts', 'bower-restore'], function () {
    return gulp.src(config.jquerysrc)
     .pipe(concat('jquery-bundle.min.js'))
     .pipe(gulp.dest('./Scripts/'));
});

//Create a bootstrap bundled file
gulp.task('bootstrap-bundle', ['clean-vendor-scripts', 'bower-restore'], function () {
    return gulp.src(config.bootstrapsrc)
     .pipe(sourcemaps.init())
     .pipe(concat('bootstrap-bundle.min.js'))
     .pipe(sourcemaps.write('maps'))
     .pipe(gulp.dest('Scripts'));
});

//Create a modernizr bundled file
gulp.task('modernizer', ['clean-vendor-scripts', 'bower-restore'], function () {
    return gulp.src(config.modernizrsrc)
        .pipe(sourcemaps.init())
        .pipe(uglify())
        .pipe(concat('modernizer-min.js'))
        .pipe(sourcemaps.write('maps'))
        .pipe(gulp.dest('Scripts'));
});

// Combine and the vendor files from bower into bundles (output to the Scripts folder)
gulp.task('vendor-scripts', ['jquery-bundle', 'bootstrap-bundle', 'modernizer'], function () {

});

// Synchronously delete the output style files (css / fonts)
gulp.task('clean-styles', function (cb) {
    del([config.fontsout,
              config.cssout], cb);
});

gulp.task('css', ['clean-styles', 'bower-restore'], function () {
    return gulp.src([config.bootstrapcss, config.appcss])
     .pipe(concat('app.css'))
     .pipe(gulp.dest(config.cssout))
     .pipe(minifyCSS())
     .pipe(concat('app.min.css'))
     .pipe(gulp.dest(config.cssout));
});

gulp.task('fonts', ['clean-styles', 'bower-restore'], function () {
    return
    gulp.src(config.boostrapfonts)
        .pipe(gulp.dest(config.fontsout));
});

// Combine and minify css files and output fonts
gulp.task('styles', ['css', 'fonts'], function () {

});

//Restore all bower packages
gulp.task('bower-restore', function () {
    return bower();
});

//Set a default tasks 
gulp.task('default', ['vendor-scripts', 'styles'], function () {

});