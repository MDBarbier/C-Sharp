var gulp = require('gulp');

//Using package to minify html 
minifyHtml = require("gulp-minify-html");

//Using package to concat files 
concat = require("gulp-concat");

var paths = {
    webroot: "./wwwroot/"
};

//Getting Path of Javascript files 
paths.js = paths.webroot + "js/**/*.js";

//Path to Writing concatenated Files after concatenating
paths.Destination = paths.webroot + "ConcatenatedJsfiles";

// Name of new js file
var newconcat = "concatmain.js"; 

//Getting Path of Htmlfiles to Minifying
paths.html = paths.webroot + "Htmlfiles/**/*.html";

//Path to Writing minified Files after Minifying
paths.Destination = paths.webroot + "Compressedfile";

// Task Name [concatfiles]
gulp.task('concatfiles', function () {   // path to your files
    gulp.src(paths.js)
        // concat files
        .pipe(concat(newconcat))
        // Writing files to Destination
        .pipe(gulp.dest(paths.Destination));
});

gulp.task('minify-html', function () {   // path to your files
    gulp.src(paths.html)
        // Minifying files
        .pipe(minifyHtml())
        // Writing files to Destination
        .pipe(gulp.dest(paths.Destination));
});

// Main task to Call for Minifying html files
gulp.task("demo", ["minify-html", "concatfiles"]);
