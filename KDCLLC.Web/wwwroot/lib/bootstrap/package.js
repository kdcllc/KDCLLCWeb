// package metadata file for Meteor.js

/* jshint strict:false */
/* global Package:true */

Package.describe({
  name: 'twbs:bootstrap',  // http://atmospherejs.com/twbs/bootstrap
  summary: 'The most popular front-end framework for developing responsive, mobile first projects on the web.',
<<<<<<< HEAD
  version: '3.3.5',
=======
  version: '3.3.7',
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
  git: 'https://github.com/twbs/bootstrap.git'
});

Package.onUse(function (api) {
  api.versionsFrom('METEOR@1.0');
  api.use('jquery', 'client');
<<<<<<< HEAD
  api.addFiles([
=======
  var assets = [
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
    'dist/fonts/glyphicons-halflings-regular.eot',
    'dist/fonts/glyphicons-halflings-regular.svg',
    'dist/fonts/glyphicons-halflings-regular.ttf',
    'dist/fonts/glyphicons-halflings-regular.woff',
<<<<<<< HEAD
    'dist/fonts/glyphicons-halflings-regular.woff2',
=======
    'dist/fonts/glyphicons-halflings-regular.woff2'
  ];
  if (api.addAssets) {
    api.addAssets(assets, 'client');
  } else {
    api.addFiles(assets, 'client', { isAsset: true });
  }
  api.addFiles([
>>>>>>> 7aa03263c89fb4913011931523097243dca57e8f
    'dist/css/bootstrap.css',
    'dist/js/bootstrap.js'
  ], 'client');
});
