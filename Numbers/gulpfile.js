/// <binding AfterBuild='prepare' />
"use strict";

const { series } = require('gulp');

var gulp = require('gulp'),
    clean = require('gulp-clean'),
    minify = require('gulp-minify'),
    concat = require('gulp-concat'),
    cssmin = require('gulp-cssmin'),
    obfuscate = require('gulp-obfuscate')

var paths = {
    webroot: "./wwwroot/"
};


paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.resultCss = paths.webroot + "css/numbers.min.css";


function CleanJs() {
    return gulp.src([paths.webroot + "js/numbers-min.js", paths.webroot + "js/update-from-server-min.js"], { read: false, allowEmpty: true })
        .pipe(clean());   
}

function CleanCss() {
    return gulp.src(paths.webroot + "css/numbers.min.css", { read: false, allowEmpty: true })
        .pipe(clean());
}

function MinifyCss() {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.resultCss))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
}

function MinifyJs() {
    return gulp.src([paths.webroot + "js/numbers.js", paths.webroot + "js/update-from-server.js"])
        .pipe(minify())
        .pipe(gulp.dest("./wwwroot/js/"));
}


exports.prepare = series(CleanJs, CleanCss, MinifyCss, MinifyJs);